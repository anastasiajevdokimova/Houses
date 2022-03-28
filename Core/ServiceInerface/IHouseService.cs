using Houses.Core.Domain;
using Houses.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Houses.Core.ServiceInerface
{
    public interface IHouseService : IApplicationService
    {
        Task<House> Delete(Guid id);

        Task<House> Add(HouseDto dto);

        Task<House> Edit(Guid id);

        Task<House> Update(HouseDto dto);
    }
}
