using BaketMicroservice_Domain.BasketEntities;
using BasketMicroserviceCleanArchitecture_Application.IBasketService;
using BasketMicroserviceCleanArchitecture_Infrastracture.Application_Context;
using Microsoft.AspNetCore.Mvc;

namespace BasketMicroserviceCleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly ICustomService<Basket> _customService;
        private readonly ApplicationDbContext _applicationDbContext;
        public BasketController(ICustomService<Basket> customService,
            ApplicationDbContext applicationDbContext)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet(nameof(GetBasketById))]
        public IActionResult GetBasketById(int Id)
        {

             return Ok("Farrukh");
            var obj = _customService.Get(Id);
            if(obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpGet(nameof(GetAllBaskets))]
        public IActionResult GetAllBaskets()
        {
            var obj = _customService.GetAll();
            if(obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }

        [HttpPost(nameof(CreateBasketItem))]
        public IActionResult CreateBasketItem(Basket student)
        {
            if(student != null)
            {
                _customService.Insert(student);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }

        [HttpPost(nameof(UpdateBasketItem))]
        public IActionResult UpdateBasketItem(Basket student)
        {
            if(student != null)
            {
                _customService.Update(student);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete(nameof(DeleteBasketItem))]
        public IActionResult DeleteBasketItem(Basket student)
        {
            if(student != null)
            {
                _customService.Delete(student);
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

    }
}
