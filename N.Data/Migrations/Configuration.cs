namespace N.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using N.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<N.Data.NShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(N.Data.NShopDbContext context)
        {
            CreateProductCategorySample(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new NShopDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new NShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "nd1226",
            //    Email = "nd1226@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    Address = "196",
            //    FullName = "SysAdmin"
            //};
            //manager.Create(user, "123456$");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });

            //    var adminUser = manager.FindByEmail("nd1226@gmail.com");
            //    manager.AddToRoles(adminUser.Id,new string[] {"Admin","User" });
            //}
        }
        private void CreateProductCategorySample(NShopDbContext dbContext)
        {
            if(dbContext.ProductCategories.Count() == 0)
            {
                List<ProductCategory> lstProductCategory = new List<ProductCategory>()
            {
                new ProductCategory()
                {
                    Name = "Điện Lạnh",
                    Alias= "dien-lanh",
                    Status= true
                },
                new ProductCategory()
                {
                    Name = "Mỹ Phẩm",
                    Alias= "my-pham",
                    Status= true
                }
            };
                dbContext.ProductCategories.AddRange(lstProductCategory);
                dbContext.SaveChanges();
            }
        }
    }
}