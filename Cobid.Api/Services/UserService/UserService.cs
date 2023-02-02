namespace Cobid.Api.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly CobidDbContext _context;
        public UserService(CobidDbContext context) => _context = context;

        public async Task<ServiceResponse<List<User>>> AddUser(User user)
        {
            user.IsEdit = user.IsNew = false;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return await GetUsersAsync();
        }

        public async Task<ServiceResponse<List<User>>> DeleteUser(int userId)
        {
            User user = await GetUserById(userId);
            if (user == null)
            {
                return new ServiceResponse<List<User>>
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            //Disable user
            user.IsActive = false;
            await _context.SaveChangesAsync();
            return await GetUsersAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(uId => uId.UserId == userId) ?? new();
        }

        public async Task<ServiceResponse<User>> GetUserAsync(int userId)
        {
            var response = new ServiceResponse<User>();
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found";
            }
            else
                response.Data = user;
            return response;
        }

        public async Task<ServiceResponse<List<User>>> GetUsersAsync()
        {
            var response = new ServiceResponse<List<User>>
            { Data = await _context.Users.Where(u => u.IsActive).ToListAsync() };
            return response;
        }

        public async Task<ServiceResponse<List<User>>> UpdateUser(User user)
        {
            var dbUser = await GetUserById(user.UserId);
            if (dbUser == null)
            {
                return new ServiceResponse<List<User>>
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            dbUser.FirstName = user.FirstName;
            dbUser.MiddleName = user.MiddleName;
            dbUser.LastName = user.LastName;
            dbUser.NameExtension = user.NameExtension;
            dbUser.UserName = user.UserName;
            dbUser.UserTypeId = user.UserTypeId;
            //dbUser.GenderId = user.GenderId;
            dbUser.UpdatedTimeSpan = DateTime.Now;
            dbUser.Address = user.Address;
            dbUser.Phone = user.Phone;
            dbUser.ShipppingAddress = user.ShipppingAddress;
            dbUser.UserProfilePic = user.UserProfilePic;
            dbUser.ValidationIds = user.ValidationIds;

            await _context.SaveChangesAsync();
            return await GetUsersAsync();
        }
    }
} 
