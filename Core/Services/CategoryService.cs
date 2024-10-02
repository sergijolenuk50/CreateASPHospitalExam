using AutoMapper;
using Core.Dtos;
using Core.Exceptions;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CategoryService : ICategoryService
    {
       public readonly HospitalDbContext ctx;
       public readonly IMapper mapper;
        public CategoryService(HospitalDbContext hospitalDbContext, IMapper mapper)
        {
            this.ctx = hospitalDbContext;
            this.mapper = mapper;
        }    
        public async Task Create(CreateCategoryDto model)
        {
            ctx.Categories.Add(mapper.Map<Category>(model));
            await ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = await ctx.Categories.FindAsync(id);
            if (category == null) throw new HttpException("Doctor not faund", HttpStatusCode.NotFound); // TODO: exception

            ctx.Categories.Remove(category);
            await ctx.SaveChangesAsync();
        }

        public async Task Edit(EditCategoryDto model)
        {
            ctx.Categories.Update(mapper.Map<Category>(model));
            await ctx.SaveChangesAsync();
        }

        public async Task<CategoryDto?> Get(int id)
        {
            var category = await ctx.Categories.FindAsync(id);
            if (category == null) //return null;
                throw new HttpException("Doctor not faund", HttpStatusCode.NotFound);
            // load related table data
          //  await ctx.Entry(category).Reference(x => x.Category).LoadAsync();

            return mapper.Map<CategoryDto>(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            return mapper.Map<List<CategoryDto>>(await ctx.Categories.ToListAsync());
        }
    }
}
