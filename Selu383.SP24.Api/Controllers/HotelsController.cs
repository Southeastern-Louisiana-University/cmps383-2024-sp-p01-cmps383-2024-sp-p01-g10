using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Selu383.SP24.Api.Features.Hotel;
using System.Linq.Expressions;

namespace Selu383.SP24.Api.Controllers
{
    [ApiController]
    [Route("api/hotels")]
    public class HotelsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public HotelsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        private static Expression<Func<Hotel, HotelDto>> MapDto()
        {
            return x => new HotelDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address
            };
        }

        [HttpGet]
        public ActionResult<IEnumerable<HotelDto>> Get()
        {
            return GetDtos().ToList();
        }

        private IQueryable<HotelDto> GetDtos()
        {
            return dataContext.Set<Hotel>().Select(MapDto());
        }

        [HttpGet]
        [Route("{id}")]

        public ActionResult<HotelDto> GetById(int id)
        {
            var result = dataContext
                .Set<Hotel>()
                .Select(MapDto()).
                FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        [HttpPost]
        public ActionResult<HotelDto> Create(HotelDto createDto)
        {

            if (createDto.Name.Equals (""))
            {
                return BadRequest();
            }

            if (createDto.Name.Length > 120)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(createDto.Address))
            {
                return BadRequest();
            }

            var hotelToCreate = new Hotel
            {
                Name = createDto.Name,
                Address = createDto.Address,
            };

            dataContext.Set<Hotel>().Add(hotelToCreate);
            dataContext.SaveChanges();

            var createdDto = MapDto().Compile().Invoke(hotelToCreate);
            return CreatedAtAction(nameof(GetById), new { id = createdDto.Id }, createdDto);
        }

        [HttpDelete ("{id}")]
        public ActionResult Delete(int id)
        {
            var hotelToDelete = dataContext.Set<Hotel>()
            .FirstOrDefault(hotel => hotel.Id == id);

            if (hotelToDelete == null)
            {
                return NotFound();
            }

            dataContext.Set<Hotel>().Remove(hotelToDelete);
            dataContext.SaveChanges();

            return Ok();
        }


    }
}

