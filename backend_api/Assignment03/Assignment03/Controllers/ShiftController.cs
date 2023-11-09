using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheSandwichShop.Models;
using TheSandwichShop.Models.Entities;
using TheSandwichShop.ViewModels;

namespace TheSandwichShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly UserManager<AppUser> _userManager;
        public ShiftController(IRepository repository, UserManager<AppUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("GetShifts")]
        public async Task<ActionResult<dynamic>> GetShiftsAsync()
        {
            try
            {
                var shifts = await _repository.GetShiftsAsync();
                return shifts;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }

        [HttpGet]
        [Route("GetEmployeeShifts")]
        public async Task<IActionResult> GetEmployeeShifts(string employeeId)
        {
            try
            {
                var empShift = await _repository.GetEmployeeShiftsAsync(employeeId);
                return Ok(empShift);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpGet]
        [Route("GetShift")]
        public async Task<IActionResult> GetShiftAsync(string shiftId)
        {
            try
            {
                var shift = await _repository.GetShiftAsync(shiftId);
                return Ok(shift);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpGet]
        [Route("GetEmployeeShift")]
        public async Task<IActionResult> GetEmployeeShiftAsync(string empShiftId)
        {
            try
            {
                var empShift = await _repository.GetEmployeeShiftAsync(empShiftId);
                return Ok(empShift);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }

        [HttpPost]
        [Route("AddShift")]
        public async Task<IActionResult> AddShiftAsync(ShiftViewModel svm)
        {
            try
            {
                var newGuid = new Guid();
                var shift = new Shift
                {
                    ShiftId = newGuid,
                    ShiftDate = svm.ShiftDate,
                    ShiftType = svm.ShiftType
                };
                _repository.Add(shift);
                await _repository.SaveChangesAsync();
                return Ok(shift);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }

        [HttpPost]
        [Route("BookShift")]
        public async Task<IActionResult> BookShift(UserShiftViewModel usvm)
        {
            try
            {
                var newGuid = new Guid();
                var newEmpShift = new EmployeeShift
                {
                    EmployeeShiftId = newGuid,
                    ShiftId = usvm.ShiftId,
                    EmployeeId = usvm.EmployeeId
                };
                _repository.Add(newEmpShift);
                await _repository.SaveChangesAsync();
                return Ok(newEmpShift);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpPost]
        [Route("UpdateEmployeeShift")]
        public async Task<IActionResult> UpdateEmployeeShift(UserShiftViewModel usvm)
        {
            try
            {
                var shift = await _repository.GetEmployeeShiftAsync(usvm.EmployeeShiftId);
                shift.ShiftId = usvm.ShiftId;
                await _repository.SaveChangesAsync();
                return Ok(shift);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
    }
}
