using TheSandwichShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSandwichShop.ViewModels;

namespace TheSandwichShop.Models
{
    public interface IRepository
    {
        Task<bool> SaveChangesAsync();
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<Shift[]> GetShiftsAsync();
        Task<Shift> GetShiftAsync(string shiftId);
        Task<EmployeeShift> GetEmployeeShiftAsync(string empShiftId);
        Task<EmpShiftListViewModel[]> GetEmployeeShiftsAsync(string employeeId);
        Task<EmployeeShift> GetEmployeeCurrentShift(string employeeId);
        Task<Employee> GetEmployeeAsync(string userId);
        Task<Item[]> GetItemsAsync();
        Task<Item> GetItemAsync(string itemId);
        Task<ItemBasePrice[]> GetItemBasePricesAsync();
        Task<ItemBasePrice> GetItemBasePriceAsync(string itemId);
        Task<Combo[]> GetCombosAsync();
        Task<Combo> GetComboAsync(string comboId);
        Task<ComboBasePrice[]> GetComboBasePricesAsync();
        Task<ComboBasePrice> GetComboBasePriceAsync(string comboId);
        Task<ComboItem[]> GetAllComboItemsAsync();
        Task<ComboItem[]> GetComboItemsAsync(string comboId);
        Task<ComboItem> GetComboItemAsync(string comboItemId);
        Task<Topping[]> GetToppingsAsync();
        Task<Topping> GetToppingAsync(string toppingId);
        Task<BreadType[]> GetBreadTypesAsync();
        Task<BreadType> GetBreadTypeAsync(string breadTypeId);
        Task<Size[]> GetSizesAsync();
        Task<Size> GetSizeAsync(string sizeId);
        Task<Order[]> GetOrdersAsync();

    }
}
