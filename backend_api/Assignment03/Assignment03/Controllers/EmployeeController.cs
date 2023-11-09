using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TheSandwichShop.Models;
using TheSandwichShop.Models.Entities;
using TheSandwichShop.ViewModels;

namespace TheSandwichShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly UserManager<AppUser> _userManager;
        public EmployeeController(IRepository repository, UserManager<AppUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(EmployeeViewModel evm)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(evm.UserName);
                var newEmployee = new Employee
                {
                    EmployeeId = evm.EmployeeId,
                    UserId = user.Id,
                    Firstname = evm.Firstname,
                    Surname = evm.Surname,
                    CellNumber = evm.CellNumber,
                    Email = evm.Email
                };

                _repository.Add(newEmployee);
                await _repository.SaveChangesAsync();
                return Ok(newEmployee);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
    }
}
