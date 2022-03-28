using Houses.Core.Domain;
using Houses.Core.Dtos;
using Houses.Core.ServiceInerface;
using Houses.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Houses.ApplicationServices.Services
{
    public class HouseServices : IHouseService
    {
        private readonly HousesDbContext _context;
        public HouseServices
            (
            HousesDbContext context
            )
        {
            _context = context;
        }
        public async Task<House> Delete(Guid id)
        {
            
            var houseId = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.House.Remove(houseId);
            await _context.SaveChangesAsync();

            return houseId;
        }

        public async Task<House> Add(HouseDto dto)
        {
            House house = new House();

            house.Id = Guid.NewGuid();
            house.Address = dto.Address;
            house.Area = dto.Area;
            house.FloorsNumber = dto.FloorsNumber;
            house.Price = dto.Price;
            house.ModifiedAt = DateTime.Now;
            house.CreatedAt = DateTime.Now;

            await _context.House.AddAsync(house);
            await _context.SaveChangesAsync();

            return house;
        }

        public async Task<House> Edit(Guid id)
        {
            var result = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<House> Update(HouseDto dto)
        {
            House house = new House();

            house.Id = dto.Id;
            house.Address = dto.Address;
            house.Area = dto.Area;
            house.FloorsNumber = dto.FloorsNumber;
            house.Price = dto.Price;
            house.ModifiedAt = dto.ModifiedAt;
            house.CreatedAt = dto.CreatedAt;
            
            _context.House.Update(house);
            await _context.SaveChangesAsync();

            return house;
        }
    }
}
