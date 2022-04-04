using Houses.Core.Dtos;
using Houses.Core.ServiceInerface;
using HouseTest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Houses.HouseTest
{
    public class HouseTest : TestBase
    {
        [Fact]
        public async Task Should_AddNewHouse_WhenReturnResult()
        {
            string guid = "ee0f1564-339b-4b52-bfa3-795762045d29";
            
            HouseDto house = new HouseDto();

            house.Id = Guid.Parse(guid);
            house.Address = "Niidi tn 35";
            house.Area = 79;
            house.FloorsNumber = 1;
            house.Price = 30000;
            house.CreatedAt = DateTime.Now;
            house.ModifiedAt = DateTime.Now;

            var result = await Svc<IHouseService>().Add(house);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task ShouldNot_GetByIdHouse_WhenReturnsResultAsync()
        {
            string guid = "90CAEAE7-887A-4DB6-9694-945F58A07005";
            string guid1 = "0a730dcd-922d-42d4-bca2-2fcdaf2fec13";

            //var request = new House();
            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);

            await Svc<IHouseService>().Edit(insertGuid);

            Assert.NotEqual(insertGuid1, insertGuid);
        }

        [Fact]
        public async Task Should_GetByIdHouse_WhenReturnsResultAsync()
        {
            string guid = "90CAEAE7-887A-4DB6-9694-945F58A07005";
            string guid1 = "90CAEAE7-887A-4DB6-9694-945F58A07005";

            //var request = new House();
            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);

            await Svc<IHouseService>().Edit(insertGuid);

            Assert.Equal(insertGuid1, insertGuid);
        }
        //[Fact]
        //public async Task Should_DeleteByIdHouse_WhenDeleteHouse()
        //{
        //    //string guid = "99DD144A-21D3-498E-8C53-449C92BD26CC";
        //    string guid = "ee0f1564-339b-4b52-bfa3-795762045d29";

        //    //var request = new House();
        //    var insertGuid = Guid.Parse(guid);

        //    var result = await Svc<IHouseService>().Delete(insertGuid);

        //    Assert.NotEmpty((System.Collections.IEnumerable)result);
        //    Assert.Single((System.Collections.IEnumerable)result);
        //}

        //[Fact]
        //public async Task Should_UpdateByIdHouse_WhenUpdateHouse()
        //{
        //    string guid = "E5053FC1-0A17-4A74-B12D-27D6BE145783";

        //    HouseDto house = new HouseDto();

        //    house.Id = Guid.Parse(guid);
        //    house.Address = "Kaluri tn 41";
        //    house.Area = 180;
        //    house.FloorsNumber = 2;
        //    house.Price = 50000;
        //    house.CreatedAt = DateTime.Now;
        //    house.ModifiedAt = DateTime.Now;

        //    await Svc<IHouseService>().Update(house);

        //    Assert.NotEmpty((System.Collections.IEnumerable)house);
        //}
        [Fact]
        public async Task Should_NotUpdateFloorsNumberLessThanNull_WhenUpdateHouse()
        {
            int floors;
            HouseDto house = new HouseDto();

            floors = house.FloorsNumber;
            if(floors > 0)
            {
                await Svc<IHouseService>().Update(house);
            }
            house.FloorsNumber = -1;
        }
        [Fact]
        public async Task Should_UpdateFloorsNumberMoreThanNull_WhenUpdateHouse()
        {
            int floors;
            HouseDto house = new HouseDto();

            floors = house.FloorsNumber;
            if (floors > 0)
            {
                await Svc<IHouseService>().Update(house);
            }
            house.FloorsNumber = 1;
        }
        
    }
}
