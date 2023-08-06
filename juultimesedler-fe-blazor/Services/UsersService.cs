using juultimesedler_fe_blazor.Shared.Models;

namespace juultimesedler_fe_blazor.Services;

public class UsersService
{
    public async Task<User> GetUser()
    {
        return new User { UserId = 10, UserName = "Wilfred Holm" };
    }
}