using Core.Dtos;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
       // private readonly IMapper mapper;
       // private readonly HospitalDbContext ctx;

        private readonly IDoctorsService ctx;
        //public List<Doctor> list = new List<Doctor>();
        /// private readonly IFileServices fileServices;
        public DoctorsController( IDoctorsService doctorsService)
        {
            
           // this.ctx = hospitalDbContext;
           this.ctx = doctorsService;
          
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetOll()
        {

            return  Ok(await ctx.GetAll());
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            // .. load data from database ..
            //var doctors = ctx.Doctors.Find(Id);
            //if (doctors == null) return NotFound();

            //return Ok(doctors);
            return Ok(await ctx.Get(Id));

        }

        // GET: 
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    // ViewBag.PropertyName = value;
        //    ViewBag.Categories = new SelectList(ctx.Categories.ToList(), "Id", "Name");
        //    //LoadCategories();
        //    ViewBag.CreateMode = true;

        //    return View("Upsert");
        //}


        // POST
        [HttpPost]
        public async Task< IActionResult> Create(CreateDoctorDto model)
        {
            // TODO: add data validation
            //if (!ModelState.IsValid) return BadRequest();
            //ctx.Doctors.Add(model);
            //ctx.SaveChanges();
            //return Ok();
            await ctx.Create(model);
            return Ok();

        }




        [HttpPut]
        public async Task<IActionResult> Edit(EditDoctorDto model)
        {


            //if (doctors == null) return NotFound();

            //if (!ModelState.IsValid) return BadRequest();
            //ctx.Doctors.Update(model);
            //ctx.SaveChanges();



            //return Ok();
            await ctx.Edit(model);
            return Ok();

        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(DoctorDto model)
        //{
        //    // TODO: add data validation
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.CreateMode = false;
        //        LoadCategories();
        //        return View("Upsert", model);
        //    }
        //    if (model.Image != null)
        //    {
        //        model.ImageUrl = await fileServices.EditDoctorImage(model.ImageUrl, model.Image);
        //    }
        //    ctx.Doctors.Update(mapper.Map<Doctor>(model));
        //    ctx.SaveChanges();

        //    return RedirectToAction("Index");
        //}









        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            //var product = ctx.Doctors.Find(id);
            //if (product == null) return NotFound();

            //ctx.Doctors.Remove(product);
            //ctx.SaveChanges();

            //return Ok();
            await ctx.Delete(id);
            return Ok();

        }
        [HttpPatch("Archive")]
        public async Task<IActionResult> ArchiveItem(int Id)
        {
            //var doctors = ctx.Doctors.Find(Id);
            //if (doctors == null) return NotFound();
            //doctors.Archived = true;
            //ctx.SaveChanges();
            //return Ok(doctors);
            await ctx.Archive(Id);
            return Ok();

            //return Ok(doctors);
            //var doctors = ctx.Doctors.Find(id);

            //if (doctors == null) return NotFound();

            //doctors.Archived = true;

            //ctx.SaveChanges();

            //return RedirectToAction("Index");
        }
        [HttpPatch("respons")]
        public async Task<IActionResult> RestoreItem(int Id)
        {
            //var doctors = ctx.Doctors.Find(Id);
            //if (doctors == null) return NotFound();
            //doctors.Archived = false;
            //ctx.SaveChanges();
            //return Ok();
            await ctx.Restore(Id);
            return Ok();
        }
       

    }
}
