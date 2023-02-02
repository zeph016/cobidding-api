namespace Cobid.Api.Services.EnumsService.GovernmentIdService
{
    public class GovernmentIdService : IGovernmentIdService
    {
        private readonly CobidDbContext _context;
        public GovernmentIdService(CobidDbContext context) => _context = context;

        public async Task<ServiceResponse<List<GovernmentIdentification>>> GetAllGovIdTypes()
        {
            var response = new ServiceResponse<List<GovernmentIdentification>>
            { Data = await _context.GovernmentTypeIds.Where(x => x.isActive).ToListAsync() };
            return response;
        }
    }
}
