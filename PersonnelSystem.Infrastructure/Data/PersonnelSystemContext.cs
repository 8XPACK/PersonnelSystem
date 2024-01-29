using Microsoft.EntityFrameworkCore;
using PersonnelSystem.Core.Entities;
using PersonnelSystem.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Infrastructure.Data
{
    public class PersonnelSystemContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public PersonnelSystemContext(DbContextOptions<PersonnelSystemContext> options)
        : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            var users = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Surname = "Иванов",
                    Name = "Иван",
                    Patronymic = "Иванович"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Surname = "Сергеев",
                    Name = "Илья",
                    Patronymic = "Иванович"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Surname = "Николаев",
                    Name = "Дмитрий",
                    Patronymic = "Ильич"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Surname = "Семёнов",
                    Name = "Владислав",
                    Patronymic = "Ильич"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Surname = "Владимиров",
                    Name = "Савелий",
                    Patronymic = "Савельевич"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Surname = "Тихомиров",
                    Name = "Станислав",
                    Patronymic = "Савельевич"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Surname = "Богданов",
                    Name = "Богдан",
                    Patronymic = "Владимирович"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Surname = "Тарасов",
                    Name = "Руслан",
                    Patronymic = "Алексеевич"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Surname = "Русланов",
                    Name = "Тарас",
                    Patronymic = "Алексеевич"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Surname = "Дмитриев",
                    Name = "Алексей",
                    Patronymic = "Алексеевич"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Surname = "Евгеньев",
                    Name = "Жора",
                    Patronymic = "Алексеевич"
                }
            };
            var mainDepartId = Guid.NewGuid();
            var mainDepartId1 = Guid.NewGuid();
            var firstMainDepartId = Guid.NewGuid();
            var firstMainDepartId1 = Guid.NewGuid();
            var secondMainDepartId = Guid.NewGuid();
            var secondMainDepartId1 = Guid.NewGuid();
            var mainDepartId11 = Guid.NewGuid();
            var dep = new Department()
            {
                Id = mainDepartId,
                Name = "1 - самыый главный",
                Description = "Сааммый главный",
                DateOfCreation = DateTime.Now,
            };
            var dep1 = new Department
            {
                Id = firstMainDepartId,
                ParentId = mainDepartId,
                Name = "1 - 1",
                Description = "под первым самым главным",
                DateOfCreation = DateTime.Now,
            };
            var dep2 = new Department
            {
                Id = firstMainDepartId1,
                ParentId = firstMainDepartId,
                DateOfCreation = DateTime.Now,
                Name = "1 - 1 - 1",
                Description = "под первым, первым самым главным"
            };
            var dep3 = new Department
            {
                Id = secondMainDepartId1,
                ParentId = mainDepartId,
                Name = "1 - 2",
                Description = "под первым самым главным",
                DateOfCreation = DateTime.Now,
            };
            var dep4 = new Department
            {
                Id = secondMainDepartId,
                ParentId = secondMainDepartId,
                Name = "1 - 2 - 1",
                Description = "под первым, вторым самым главным",
                DateOfCreation = DateTime.Now,
            };
            var dep12 = new Department
            {
                Id = mainDepartId1,
                Name = "2 - самый главный",
                Description = "тоже главный но в другой теме",
                DateOfCreation = DateTime.Now,
            };
            var dep121 = new Department
            {
                Id = mainDepartId11,
                ParentId = secondMainDepartId,
                Name = "1 - 2 - 1",
                Description = "под первым, вторым самым главным",
                DateOfCreation = DateTime.Now,
            };
            Random rnd = new Random();
            var listDep = new List<Department>() { dep, dep1, dep2, dep3, dep4, dep12, dep121 };
            var employees = new List<Employee>();
            foreach (var user in users)
            {
                var index = rnd.Next(0, listDep.Count);
                employees.Add(new Employee
                {
                    UserId = user.Id,
                    Email = user.Name + $"{employees.Count + 1}" + "@OOO.ru",
                    DateOfEmployment = DateTime.Now.AddDays(employees.Count),
                    DepartmentId = listDep[index].Id
                });
            }
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Department>().HasData(listDep);
            modelBuilder.Entity<Employee>().HasData(employees);
            base.OnModelCreating(modelBuilder);
        }
    }
}
