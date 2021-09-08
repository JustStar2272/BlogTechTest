using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BlogTechTest.Data;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System;

namespace BlogTechTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // CreateHostBuilder(args).Build().Run();
             var host = CreateHostBuilder(args).Build();

              try
              {


              var scope = host.Services.CreateScope();

              var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
              var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
              var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                  ctx.Database.EnsureCreated();

                  var adminRole = new IdentityRole("Admin");

                  if (!ctx.Roles.Any())
                  {
                      //create a role
                      roleMgr.CreateAsync(adminRole).GetAwaiter().GetResult();
                  }

                  if (!ctx.Users.Any(u => u.UserName == "juststar2272@gmail.com"))
                  {
                      //create an admin
                      var adminUser = new IdentityUser
                      {
                          UserName = "juststar2272@gmail.com",
                          Email = "juststar2272@gmail.com"
                      };
                      var result = userMgr.CreateAsync(adminUser, "Valeriy2001#").GetAwaiter().GetResult();
                      //add role to user
                      userMgr.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
                  }
              }
              catch (Exception e)
              {
                  Console.WriteLine(e.Message);
              }

              host.Run();
        
    }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
