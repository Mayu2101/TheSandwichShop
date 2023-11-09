using TheSandwichShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSandwichShop.ViewModels;
using TheSandwichShop.Migrations;

namespace TheSandwichShop.Models
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _appDbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _appDbContext.Remove(entity);
        }

        public async Task<BreadType[]> GetBreadTypesAsync()
        {
            IQueryable<BreadType> query = _appDbContext.BreadTypes;
            return await query.ToArrayAsync();
        }

        public async Task<Order[]> GetOrdersAsync()
        {
            IQueryable<Order> query = _appDbContext.Orders;
            return await query.ToArrayAsync();
        }

        public async Task<Item[]> GetItemsAsync()
        {
            IQueryable<Item> query = _appDbContext.Items;
            return await query.ToArrayAsync();
        }

        public async Task<Topping[]> GetToppingsAsync()
        {
            IQueryable<Topping> query = _appDbContext.Toppings;
            return await query.ToArrayAsync();
        }

        public async Task<Size[]> GetSizesAsync()
        {
            IQueryable<Size> query = _appDbContext.Sizes;
            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<Shift[]> GetShiftsAsync()
        {
            IQueryable<Shift> query = _appDbContext.Shifts;
            return await query.ToArrayAsync();
        }

        public async Task<EmpShiftListViewModel[]> GetEmployeeShiftsAsync(string employeeId)
        {
            IQueryable<EmpShiftListViewModel> query = _appDbContext.EmployeeShifts
                .Join(_appDbContext.Shifts,
                    employeeShift => employeeShift.ShiftId,
                    shift => shift.ShiftId.ToString(),
                    (employeeShift, shift) => new { EmployeeShift = employeeShift, Shift = shift })
                .Where(s => s.EmployeeShift.EmployeeId == employeeId)
                .Select(s => new EmpShiftListViewModel
                { EmployeeShiftId = s.EmployeeShift.EmployeeShiftId.ToString(), 
                    EmployeeId = s.EmployeeShift.EmployeeId, ShiftType = s.Shift.ShiftType, ShiftDate = s.Shift.ShiftDate });
            return await query.ToArrayAsync();
        }

        public async Task<Shift> GetShiftAsync(string shiftId)
        {
            IQueryable<Shift> query = _appDbContext.Shifts
                .Where(s => s.ShiftId.ToString() == shiftId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<EmployeeShift> GetEmployeeShiftAsync(string empShiftId)
        {
            IQueryable<EmployeeShift> query = _appDbContext.EmployeeShifts
                .Where(s => s.EmployeeShiftId.ToString() == empShiftId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Employee> GetEmployeeAsync(string userId)
        {
            IQueryable<Employee> query = _appDbContext.Employees
                .Where(s => s.UserId == userId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<EmployeeShift> GetEmployeeCurrentShift(string employeeId)
        {
            var today = DateTime.Today;
            var shiftType = DateTime.Now.Hour < 13 ? "Morning" : "Afternoon";
            IQueryable<EmployeeShift> query = _appDbContext.EmployeeShifts
                .Join(_appDbContext.Shifts,
                    employeeShift => employeeShift.ShiftId,
                    shift => shift.ShiftId.ToString(),
                    (employeeShift, shift) => new { EmployeeShift = employeeShift, Shift = shift})
                .Where(s => s.EmployeeShift.ShiftId == s.Shift.ShiftId.ToString())
                .Where(s => s.Shift.ShiftDate == today)
                .Where(s => s.Shift.ShiftType == shiftType)
                .Select(s => s.EmployeeShift);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Topping> GetToppingAsync(string toppingId)
        {
            IQueryable<Topping> query = _appDbContext.Toppings
                .Where(s => s.ToppingId.ToString() == toppingId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<BreadType> GetBreadTypeAsync(string breadTypeId)
        {
            IQueryable<BreadType> query = _appDbContext.BreadTypes
                .Where(s => s.BreadTypeId.ToString() == breadTypeId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Size> GetSizeAsync(string sizeId)
        {
            IQueryable<Size> query = _appDbContext.Sizes
                .Where(s => s.SizeId.ToString() == sizeId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Item> GetItemAsync(string itemId)
        {
            IQueryable<Item> query = _appDbContext.Items
                .Where(s => s.ItemId.ToString() == itemId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Combo[]> GetCombosAsync()
        {
            IQueryable<Combo> query = _appDbContext.Combos;
            return await query.ToArrayAsync();
        }

        public async Task<Combo> GetComboAsync(string comboId)
        {
            IQueryable<Combo> query = _appDbContext.Combos
                .Where(s => s.ComboId.ToString() == comboId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<ComboItem[]> GetComboItemsAsync(string comboId)
        {
            IQueryable<ComboItem> query = _appDbContext.ComboItems
                .Where(s => s.ComboId.ToString() == comboId);
            return await query.ToArrayAsync();
        }

        public async Task<ComboItem> GetComboItemAsync(string comboItemId)
        {
            IQueryable<ComboItem> query = _appDbContext.ComboItems
                .Where(s => s.ComboItemId.ToString() == comboItemId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<ComboItem[]> GetAllComboItemsAsync()
        {
            IQueryable<ComboItem> comboItems = _appDbContext.ComboItems;
            return await comboItems.ToArrayAsync();
        }

        public async Task<ItemBasePrice[]> GetItemBasePricesAsync()
        {
            IQueryable<ItemBasePrice> itemBasePrices = _appDbContext.ItemBasePrices;
            return await itemBasePrices.ToArrayAsync();
        }

        public async Task<ItemBasePrice> GetItemBasePriceAsync(string itemId)
        {
            IQueryable<ItemBasePrice> query = _appDbContext.ItemBasePrices
                .Where(s => s.ItemId.ToString() == itemId)
                .Where(s => s.StartDate <= DateTime.Now && s.EndDate >= DateTime.Now);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<ComboBasePrice[]> GetComboBasePricesAsync()
        {
            IQueryable<ComboBasePrice> comboBasePrice = _appDbContext.ComboBasePrices;
            return await comboBasePrice.ToArrayAsync();
        }

        public async Task<ComboBasePrice> GetComboBasePriceAsync(string comboId)
        {
            IQueryable<ComboBasePrice> query = _appDbContext.ComboBasePrices
                .Where(s => s.ComboId.ToString() == comboId)
                .Where(s => s.StartDate <= DateTime.Now && s.EndDate >= DateTime.Now);
            return await query.FirstOrDefaultAsync();
        }

        /*public async Task<Product[]> GetProductsDashboardReportAsync()
        {
            IQueryable<Product> query = _appDbContext.Products.Include(p => p.Brand).Include(p => p.ProductType);

            return await query.ToArrayAsync();
        }*/
    }
}
