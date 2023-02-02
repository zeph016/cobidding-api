namespace Cobid.Api.Services.GenderService
{
    public class GenderService : IGenderService
    {
        private readonly CobidDbContext _context;
        public GenderService(CobidDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<Gender>> GetGenderAsync(int genderId)
        {
            var response = new ServiceResponse<Gender>();
            var gender = await _context.Genders.FindAsync(genderId);
            if (gender == null)
            {
                response.Success = false;
                response.Message = "Gender not found";
            }
            else
                response.Data = gender;
            return response;
        }

        public async Task<ServiceResponse<List<Gender>>> GetGendersAsync()
        {
            var response = new ServiceResponse<List<Gender>>
            { Data = await _context.Genders.ToListAsync() };
            return response;
        }
    }
}
