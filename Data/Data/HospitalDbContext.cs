using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Data.Data
{
    public class HospitalDbContext : IdentityDbContext<User>
    {

        public HospitalDbContext() { }
        public HospitalDbContext(DbContextOptions options) : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    string str = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Hospital_Olenuk;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        //    //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShopMvc_PV212;Integrated Security=True;");
        //    optionsBuilder.UseSqlServer(str);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new List<Category>()
            {
                new Category() { Id = 1,Name = "Otorhinolaryngologist"    },
                new Category() { Id = 2,Name = "Therapist"},
                new Category() { Id = 3,Name = "Surgeon" },
                new Category() { Id = 4,Name ="Bacteriologist"},
                new Category() { Id = 5,Name ="Homeopath"},
                new Category() { Id = 6,Name ="Endoscopist"},
                new Category() { Id = 7,Name ="Podiatrist"},
                new Category() { Id = 8,Name ="Narcologist"},
            });
            modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
            {
            new Doctor() {Id = 1, FirstName ="Grec", Name = "Stepan", LastName = "Ivanivuch" , Birthday = new DateTime(1985,05,01),      Work_experience =5, CategoryId = 3, ImageUrl="https://img.freepik.com/free-photo/portrait-of-handsome-bearded-man-outside_23-2150266915.jpg"},
            new Doctor() {Id = 2, FirstName ="Ivanov", Name = "Stanislav", LastName = "Ivanivuch" , Birthday = new DateTime(1988,11,12), Work_experience =6, CategoryId = 8, ImageUrl="https://cdn.pixabay.com/photo/2016/11/23/00/57/adult-1851571_640.jpg"},
            new Doctor() {Id = 3, FirstName ="Sidorov", Name = "Sergii", LastName = "Romanovich" , Birthday = new DateTime(1981,06,25),  Work_experience =10, CategoryId = 2, ImageUrl="https://st4.depositphotos.com/1325771/39150/i/450/depositphotos_391507238-stock-photo-confident-smiling-doctor-posing-in.jpg"},
            });
            //modelBuilder.Entity<User>().HasData(new List<User>() {
            //new User() {Id = 1, FirstName="Ivanov", Name="Dima", LastName="Dmitrovich", Birthday=new DateTime(1985,06,15), PhoneNumber="0970251515", City="Rivne", Email="dim@ukr.net", Password="1234", DoctorId=1 }
            //});
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<User> Users { get; set; }

    }

}
