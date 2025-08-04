using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResturantManagementSystem.Application;
using ResturantManagementSystem.Contract.DTOs;

namespace ResturentAPIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        static FoodService foodService = new FoodService();

        static DrinkService drinkService = new DrinkService();

        [HttpGet]
        public List<DrinkDto> GetAll()
        {
            return drinkService.GetAll().ToList();
        }
    }
}
