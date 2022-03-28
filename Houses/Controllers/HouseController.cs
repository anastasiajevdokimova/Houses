
using Houses.Core.Dtos;
using Houses.Core.ServiceInerface;
using Houses.Data;
using Houses.Models.House;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Houses.Controllers
{
    public class HouseController : Controller
    {
        private readonly HousesDbContext _context;
        private readonly IHouseService _houseService;

        public HouseController
            (
            HousesDbContext context,
            IHouseService houseService
            )
        {
            _context = context;
            _houseService = houseService;
        }
        public IActionResult Index()
        {
            var result = _context.House
                .Select(x => new HouseListViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    Area = x.Area,
                    FloorsNumber = x.FloorsNumber,
                    Price = x.Price
                });

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {

            var house = await _houseService.Delete(id);


            if (house == null)
            {
                RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Add()
        {
            HouseViewModel model = new HouseViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HouseViewModel model)
        {
            var dto = new HouseDto()
            {
                Id = model.Id,
                Address = model.Address,
                Area = model.Area,
                FloorsNumber = model.FloorsNumber,
                Price = model.Price,
                CreatedAt = model.CreatedAt,
                ModifiedAt = model.ModifiedAt
            };

            var result = await _houseService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var house = await _houseService.Edit(id);

            if (house == null)
            {
                return NotFound();
            }

            var model = new HouseViewModel();

            model.Id = house.Id;
            model.Address = house.Address;
            model.Area = house.Area;
            model.FloorsNumber = house.FloorsNumber;
            model.Price = house.Price;
            model.ModifiedAt = house.ModifiedAt;
            model.CreatedAt = house.CreatedAt;
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(HouseViewModel model)
        {
            var dto = new HouseDto()
            {
                Id = model.Id,
                Address = model.Address,
                Area = model.Area,
                FloorsNumber = model.FloorsNumber,
                Price = model.Price,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt,
                
            };

            var result = await _houseService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);
        }

    }
}
