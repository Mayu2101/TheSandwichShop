using TheSandwichShop.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSandwichShop.ViewModels;
using TheSandwichShop.Models.Entities;
using System.Drawing;

namespace TheSandwichShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public ProductController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetProductDashboard")]
        public async Task<ActionResult<dynamic>> GetProductDashboard()
        { 
            try
            {
                List<dynamic> productdashboard = new List<dynamic>();

                var items = await _repository.GetItemsAsync();

                productdashboard.Add(items);
                
                return productdashboard;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpGet]
        [Route("GetToppings")]
        public async Task<IActionResult> GetToppings()
        {
            try
            {
                var toppings = await _repository.GetToppingsAsync();

                return Ok(toppings);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpGet]
        [Route("GetTopping")]
        public async Task<IActionResult> GetTopping(string toppingId)
        {
            try
            {
                var topping = await _repository.GetToppingAsync(toppingId);

                return Ok(topping);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpPost]
        [Route("AddTopping")]
        public async Task<IActionResult> AddToppingAsync(ToppingViewModel dvm)
        {
            var newGuid = new Guid();
            var topping = new Topping
            {
                ToppingId = newGuid,
                Description = dvm.Description,
                Price = dvm.Price
            };
            try
            {
                _repository.Add(topping);
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
            return Ok(topping);

        }
        [HttpPost]
        [Route("UpdateTopping")]
        public async Task<IActionResult> UpdateToppingAsync(ToppingViewModel dvm)
        {
            var existingTopping = await _repository.GetToppingAsync(dvm.ToppingId);
            try
            {
                existingTopping.Description = dvm.Description;
                existingTopping.Price = dvm.Price;
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
            return Ok(existingTopping);

        }
        [HttpGet]
        [Route("GetSizes")]
        public async Task<IActionResult> GetSizes()
        {
            try
            {
                var sizes = await _repository.GetSizesAsync();

                return Ok(sizes);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpGet]
        [Route("GetSize")]
        public async Task<IActionResult> GetSize(string sizeId)
        {
            try
            {
                var size = await _repository.GetSizeAsync(sizeId);

                return Ok(size);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpPost]
        [Route("AddSize")]
        public async Task<IActionResult> AddSizeAsync(SizeViewModel svm)
        {
            var newGuid = new Guid();
            var size = new Models.Entities.Size
            {
                SizeId = newGuid,
                Description = svm.Description,
                ExtraCost = svm.ExtraCost
            };
            try
            {
                _repository.Add(size);
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
            return Ok(size);

        }
        [HttpPost]
        [Route("UpdateSize")]
        public async Task<IActionResult> UpdateSizeAsync(SizeViewModel svm)
        {
            var existingSize = await _repository.GetSizeAsync(svm.SizeId);
            try
            {
                existingSize.Description = svm.Description;
                existingSize.ExtraCost = svm.ExtraCost;
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
            return Ok(existingSize);

        }
        [HttpGet]
        [Route("GetBreadTypes")]
        public async Task<IActionResult> GetBreadTypes()
        {
            try
            {
                var breadTypes = await _repository.GetBreadTypesAsync();

                return Ok(breadTypes);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpGet]
        [Route("GetBreadType")]
        public async Task<IActionResult> GetBreadType(string breadTypeId)
        {
            try
            {
                var breadType = await _repository.GetBreadTypeAsync(breadTypeId);

                return Ok(breadType);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpPost]
        [Route("AddBreadType")]
        public async Task<IActionResult> AddBreadTypeAsync(BreadTypeViewModel btvm)
        {
            var newGuid = new Guid();
            var breadType = new BreadType
            {
                BreadTypeId = newGuid,
                Description = btvm.Description
            };
            try
            {
                _repository.Add(breadType);
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
            return Ok(breadType);

        }
        [HttpPost]
        [Route("UpdateBreadType")]
        public async Task<IActionResult> UpdateBreadTypeAsync(BreadTypeViewModel btvm)
        {
            var existingBreadType = await _repository.GetBreadTypeAsync(btvm.BreadTypeId);
            try
            {
                existingBreadType.Description = btvm.Description;
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
            return Ok(existingBreadType);

        }
        [HttpGet]
        [Route("GetItems")]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                var items = await _repository.GetItemsAsync();

                return Ok(items);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpGet]
        [Route("GetItem")]
        public async Task<IActionResult> GetItem(string itemId)
        {
            try
            {
                var item = await _repository.GetItemAsync(itemId);

                return Ok(item);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpGet]
        [Route("GetItemBasePrice")]
        public async Task<IActionResult> GetItemBasePrice(string itemId)
        {
            try
            {
                var itemBasePrice = await _repository.GetItemBasePriceAsync(itemId);

                return Ok(itemBasePrice);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpPost]
        [Route("AddItemBasePrice")]
        public async Task<IActionResult> AddItemBasePriceAsync(ItemBasePriceViewModel ivm)
        {
            var currentItemBasePrice = await _repository.GetItemBasePriceAsync(ivm.ItemId);
            if (currentItemBasePrice != null)
            {
                currentItemBasePrice.EndDate = DateTime.Now;
                await _repository.SaveChangesAsync();
            }

            var item = await _repository.GetItemAsync(ivm.ItemId);
            var newGuid = new Guid();
            var itemBasePrice = new ItemBasePrice
            {
                ItemBasePriceId = newGuid,
                ItemId = item.ItemId,
                StartDate = DateTime.Now,
                EndDate = DateTime.MaxValue,
                Price = ivm.Price,

            };
            try
            {
                _repository.Add(itemBasePrice);
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
            return Ok(itemBasePrice);

        }
        [HttpPost]
        [Route("AddItem")]
        public async Task<IActionResult> AddItemAsync(ItemViewModel ivm)
        {
            var newGuid = new Guid();
            var item = new Item
            {
                ItemId = newGuid,
                Category = ivm.Category,
                Description = ivm.Description
            };
            try
            {
                _repository.Add(item);
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
            return Ok(item);

        }
        [HttpPost]
        [Route("UpdateItem")]
        public async Task<IActionResult> UpdateItemAsync(ItemViewModel ivm)
        {
            var existingItem = await _repository.GetItemAsync(ivm.ItemId);
            
            try
            {
                existingItem.Category = ivm.Category;
                existingItem.Description = ivm.Description;
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
            return Ok(existingItem);

        }
        [HttpGet]
        [Route("GetCombos")]
        public async Task<IActionResult> GetCombos()
        {
            try
            {
                var combos = await _repository.GetCombosAsync();

                return Ok(combos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpGet]
        [Route("GetCombo")]
        public async Task<IActionResult> GetCombo(string comboId)
        {
            try
            {
                var combo = await _repository.GetComboAsync(comboId);

                return Ok(combo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpGet]
        [Route("GetComboBasePrice")]
        public async Task<IActionResult> GetComboBasePrice(string comboId)
        {
            try
            {
                var combo = await _repository.GetComboBasePriceAsync(comboId);

                return Ok(combo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpPost]
        [Route("AddComboBasePrice")]
        public async Task<IActionResult> AddComboBasePriceAsync(ComboBasePriceViewModel cvm)
        {
            var currentComboBasePrice = await _repository.GetComboBasePriceAsync(cvm.ComboId);
            if (currentComboBasePrice != null)
            {
                currentComboBasePrice.EndDate = DateTime.Now;
                await _repository.SaveChangesAsync();
            }

            var combo = await _repository.GetComboAsync(cvm.ComboId);
            var newGuid = new Guid();
            var comboBasePrice = new ComboBasePrice
            {
                ComboBasePriceId = newGuid,
                ComboId = combo.ComboId,
                StartDate = DateTime.Now,
                EndDate = DateTime.MaxValue,
                Price = cvm.Price,

            };
            try
            {
                _repository.Add(comboBasePrice);
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
            return Ok(comboBasePrice);

        }
        [HttpPost]
        [Route("AddCombo")]
        public async Task<IActionResult> AddComboAsync(ComboViewModel cvm)
        {
            var newGuid = new Guid();
            var combo = new Combo
            {
                ComboId = newGuid,
                Description = cvm.Description
            };
            try
            {
                _repository.Add(combo);
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
            return Ok(combo);

        }
        [HttpPost]
        [Route("UpdateCombo")]
        public async Task<IActionResult> UpdateComboAsync(ComboViewModel cvm)
        {
            var existingCombo = await _repository.GetComboAsync(cvm.ComboId.ToString());

            try
            {
                existingCombo.Description = cvm.Description;
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
            return Ok(existingCombo);

        }
        [HttpGet]
        [Route("GetComboItems")]
        public async Task<IActionResult> GetComboItems()
        {
            try
            {
                var comboItems = await _repository.GetAllComboItemsAsync();

                return Ok(comboItems);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpGet]
        [Route("GetComboItem")]
        public async Task<IActionResult> GetComboItem(string comboItemId)
        {
            try
            {
                var comboItem = await _repository.GetComboItemAsync(comboItemId);

                return Ok(comboItem);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
        }
        [HttpPost]
        [Route("AddComboItem")]
        public async Task<IActionResult> AddComboItemAsync(ComboItemViewModel cvm)
        {
            var item = await _repository.GetItemAsync(cvm.ItemId);
            var comboName = await _repository.GetComboAsync(cvm.ComboId);
            var newGuid = new Guid();
            var comboItem = new ComboItem
            {
                ComboItemId = newGuid,
                ItemId = item.ItemId,
                ComboId = comboName.ComboId

            };
            try
            {
                _repository.Add(comboItem);
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
            return Ok(comboItem);

        }
        [HttpPost]
        [Route("UpdateComboItem")]
        public async Task<IActionResult> UpdateComboItemAsync(ComboItemViewModel cvm)
        {
            var existingComboItem = await _repository.GetComboItemAsync(cvm.ComboItemId);
            var item = await _repository.GetItemAsync(cvm.ItemId);
            var combo = await _repository.GetComboAsync(cvm.ComboId);
            try
            {
                existingComboItem.ItemId = item.ItemId;
                existingComboItem.ComboId = combo.ComboId;
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
            return Ok("Item Updated In Database.");

        }
    }
}
