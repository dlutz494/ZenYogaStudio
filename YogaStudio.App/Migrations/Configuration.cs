namespace YogaStudio.App.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using YogaStudio.App.Models.EntityModels;

    public sealed class Configuration : DbMigrationsConfiguration<Data.YogaStudioContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Data.YogaStudioContext";
        }

        protected override void Seed(Data.YogaStudioContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Trainner"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Trainner" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "Trainner"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = "Trainner", Email = "trainner@gmail.com" };

                manager.Create(user, "Trainner1!");
                manager.AddToRole(user.Id, "Trainner");
            }

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = "Admin", Email = "admin@gmail.com" };

                manager.Create(user, "Admin1!");
                manager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
