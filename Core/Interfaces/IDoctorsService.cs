using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDoctorsService
    {
        Task<IEnumerable<DoctorDto>> GetAll();
        Task<DoctorDto?> Get(int id);
        Task Edit(EditDoctorDto model);
        Task Create(CreateDoctorDto model);
        Task Delete(int id);
        Task Archive(int id);
        Task Restore(int id);
    }
}
