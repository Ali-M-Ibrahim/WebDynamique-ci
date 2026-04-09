using Microsoft.AspNetCore.Identity;
using USCJCI.Constant;

namespace USCJCI.Data
{
    public class UserSeeder
    {

        public static async Task SeedUsers(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            await CreateUser(userManager, "admin@usj.edu.lb", "Admin@123", Roles.Admin);
            await CreateUser(userManager, "user@usj.edu.lb", "User@123", Roles.User);
        }

       
        public static async Task CreateUser(UserManager<IdentityUser> userManager, string email, string password, string role)
        {

            if(await userManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityUser
                {
                    Email = email,
                    EmailConfirmed = true,
                    UserName = email
                };

                var result  = await userManager.CreateAsync(user, password);

                if (result.Succeeded) {

                    await userManager.AddToRoleAsync(user, role);

                }
                else
                {
                    Console.WriteLine("erorrrrrrrrrrrrrrrr");
                }

            }
        }

    }

}
