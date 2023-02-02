namespace Cobid.Api.Services.UserTypeService
{
    public class UserTypeService : IUserTypeService
    {
        private readonly CobidDbContext _context;
        public UserTypeService(CobidDbContext context) => _context = context;

        public async Task<ServiceResponse<List<UserType>>> GetUserTypesAsync()
        {
            var response = new ServiceResponse<List<UserType>>
            { Data = await _context.UserTypes.ToListAsync() };
            return response;
        }
        public async Task<ServiceResponse<UserType>> GetUserTypeAsync(int userTypeId)
        {
            var response = new ServiceResponse<UserType>();
            var userType = await _context.UserTypes.FindAsync(userTypeId);
            if (userType == null)
            {
                response.Success = false;
                response.Message = "User Type not found";
            }
            else
                response.Data = userType;
            return response;
        }
    }
}
