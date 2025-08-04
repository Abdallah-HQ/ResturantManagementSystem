using Microsoft.AspNetCore.Mvc;
using ResturantManagementSystem.Contract.DTOs;
using ResturantManagementSystem.Contract.Interfaces;
using ResturantManagementSystem.Domain.Shared.Constants;

namespace ResturantManagementSystem.APIS
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinkService _drinkService;
        private readonly ILogger<DrinksController> _logger;

        public DrinksController(IDrinkService drinkService, ILogger<DrinksController> logger)
        { 
            this._drinkService = drinkService;
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var drinks = _drinkService.GetAll();
           
            if (drinks == null || !drinks.Any())
            {
                _logger.LogWarning(DrinkConstants.DrinkNotFound);
                return NotFound(DrinkConstants.DrinkNotFound);
            }
           
            _logger.LogInformation(DrinkConstants.returnAllDrinksSuccessfully);
            return Ok(drinks);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DrinkDto drink = _drinkService.GetById(id);
            
            if (drink == null)
            {
                _logger.LogWarning(DrinkConstants.DrinkNotFound);
                return NotFound(DrinkConstants.DrinkNotFound);
            }
            
            return Ok(drink);
        }

        [HttpPost]
        public IActionResult AddDrink(CreateDrinkDto createDrinkDto)
        {
            if (createDrinkDto == null)
            {
                _logger.LogWarning(DrinkConstants.DrinkDataIsNull);
                return BadRequest(DrinkConstants.DrinkDataIsNull);
            }
           
            if (string.IsNullOrWhiteSpace(createDrinkDto.Name))
            {
                _logger.LogWarning(DrinkConstants.DrinkNameShouldntBeNullOrEmpty);
                return BadRequest(DrinkConstants.DrinkNameShouldntBeNullOrEmpty);
            }
           
            if (createDrinkDto.Price <= 0)
            {
                _logger.LogWarning(DrinkConstants.DrinkPriceMustBePositive);
                return BadRequest(DrinkConstants.DrinkPriceMustBePositive);
            }
           
            var result = _drinkService.AddDrink(createDrinkDto);
           
            if (!result.Success)
            {
                _logger.LogWarning(result.Message);
                return BadRequest(result.Message);
            }
            
            _logger.LogInformation(DrinkConstants.DrinkAddedSuccessfully);
            return Ok(DrinkConstants.DrinkAddedSuccessfully);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDrink(int id)
        {
            var result = _drinkService.DeleteDrink(id);
            if (!result.Success)
            {
                _logger.LogWarning(result.Message);
                return NotFound(result.Message);
            }
           
            _logger.LogInformation(DrinkConstants.DrinkDeletedSuccessfully);
            return Ok(DrinkConstants.DrinkDeletedSuccessfully);
        }

        [HttpPut]
        public ActionResult Update(UpdatedDrinkDto updatedDrink)
        {
            if (updatedDrink == null)
            {
                _logger.LogWarning(DrinkConstants.DrinkDataIsNull);
                return BadRequest(DrinkConstants.DrinkDataIsNull);
            }
            if (string.IsNullOrWhiteSpace(updatedDrink.Name))
            {
                _logger.LogWarning(DrinkConstants.DrinkNameShouldntBeNullOrEmpty);
                return BadRequest(DrinkConstants.DrinkNameShouldntBeNullOrEmpty);
            }
            if (updatedDrink.Price <= 0)
            {
                _logger.LogWarning(DrinkConstants.DrinkPriceMustBePositive);
                return BadRequest(DrinkConstants.DrinkPriceMustBePositive);
            }
            var result = _drinkService.Update(updatedDrink);
            if (!result.Success)
            {
                _logger.LogWarning(result.Message);
                return NotFound(result.Message);
            }

            _logger.LogInformation(DrinkConstants.DrinkUpdatedSuccessfully);
            return Ok(DrinkConstants.DrinkUpdatedSuccessfully);
        }
    }
}
