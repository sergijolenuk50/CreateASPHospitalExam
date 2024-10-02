using AutoMapper;
using Core.Dtos;
using Core.Exceptions;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class DoctorsService : IDoctorsService
    {
        public readonly HospitalDbContext ctx;
        public readonly IMapper mapper;
        public readonly IRepository<Doctor> repositoryD;
        public DoctorsService(HospitalDbContext hospitalDbContext, IMapper mapper, IRepository<Doctor> repositoryD)
        {
            this.ctx = hospitalDbContext;
            this.mapper = mapper;
            this.repositoryD = repositoryD;
        }
        public async Task Archive(int id)
        {
            var doctor = await repositoryD.GetById(id);
            if (doctor == null) 
                throw new HttpException("Doctors not faund", HttpStatusCode.NotFound); // TODO: exception

            doctor.Archived = true;
            await repositoryD.Save();
        }

        public async Task Create(CreateDoctorDto model)
        {
            repositoryD.Insert(mapper.Map<Doctor>(model));
            await repositoryD.Save(); ;
        }

        public async Task Delete(int id)
        {
            var doctor = await repositoryD.GetById(id);
            if (doctor == null) throw new HttpException("Doctor not faund", HttpStatusCode.NotFound); // TODO: exception

            repositoryD.Delete(doctor);
            await repositoryD.Save();
        }

        public async Task Edit(EditDoctorDto model)
        {
            ctx.Doctors.Update(mapper.Map<Doctor>(model));
            await ctx.SaveChangesAsync();
        }

        public async Task<DoctorDto?> Get(int id)
        {
            var doctor = await repositoryD.GetById(id);
            if (doctor == null) //return null;
                throw new HttpException("Doctor not faund", HttpStatusCode.NotFound);
            // load related table data
         //   await ctx.Entry(doctor).Reference(x => x.Category).LoadAsync();

            return mapper.Map<DoctorDto>(doctor);
        }

        public async Task<IEnumerable<DoctorDto>> GetAll()
        {
            return mapper.Map<List<DoctorDto>>(await repositoryD.GetAll());
        }

        public async Task Restore(int id)
        {
            var doctor = await repositoryD.GetById(id);
            if (doctor == null) //return; // TODO: exception
                throw new HttpException("Doctor not faund", HttpStatusCode.NotFound);
            doctor.Archived = false;
            await repositoryD.Save();
        }
    }
}
