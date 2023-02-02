namespace Cobid.Api.Services.LiveSellingService
{
    public class LiveSellingService : ILiveSellingService
    {
        private readonly CobidDbContext _context;
        public LiveSellingService(CobidDbContext context) => _context = context;

        public async Task<ServiceResponse<List<LiveSelling>>> AddLiveSelling(LiveSelling liveSelling)
        {
            _context.LiveSellings.Add(liveSelling);
            await _context.SaveChangesAsync();
            return await GetLiveSellings();
            //return new ServiceResponse<LiveSelling> { Data = liveSelling, Message = "Successfully added event." };
        }

        public async Task<ServiceResponse<List<LiveSelling>>> DeleteLiveSelling(long liveSellingId)
        {
            LiveSelling liveSelling = await GetLiveSellingById(liveSellingId);
            if (liveSelling == null)
            {
                return new ServiceResponse<List<LiveSelling>>
                {
                    Success = false,
                    Message = "Lobby not found"
                };
            }

            //Disable Lobby
            liveSelling.IsActive = false;
            await _context.SaveChangesAsync();
            return await GetLiveSellings();
        }

        private async Task<LiveSelling> GetLiveSellingById(long liveSellingId)
        {
            return await _context.LiveSellings.FirstOrDefaultAsync(ls => ls.LiveSellingId == liveSellingId) ?? new();
        }

        public async Task<ServiceResponse<LiveSelling>> GetLiveSelling(long liveSellingId)
        {
            var response = new ServiceResponse<LiveSelling>();
            var liveselling = await _context.LiveSellings.FindAsync(liveSellingId);
            if (liveselling == null)
            {
                response.Success = false;
                response.Message = "Lobby not found";
            }
            else
                response.Data = liveselling;
            return response;
        }

        public async Task<ServiceResponse<List<LiveSelling>>> GetLiveSellings()
        {
            var response = new ServiceResponse<List<LiveSelling>>
            { Data = await _context.LiveSellings.Where(x => x.IsActive).ToListAsync() };
            return response;
        }

        public async Task<ServiceResponse<List<LiveSelling>>> UpdateLiveSelling(LiveSelling liveSelling)
        {
            var dbLiveSelling = await GetLiveSellingById(liveSelling.LiveSellingId);
            if (dbLiveSelling == null)
            {
                return new ServiceResponse<List<LiveSelling>>
                { Success = false, Message = "Lobby not found" };
            }

            dbLiveSelling.LiveSellingTitle = liveSelling.LiveSellingTitle;
            dbLiveSelling.LiveSellingPassword = liveSelling.LiveSellingPassword;
            dbLiveSelling.LiveSellingDescription = liveSelling.LiveSellingDescription;
            dbLiveSelling.LiveSellingLink = liveSelling.LiveSellingLink;
            dbLiveSelling.LiveSellingDateStart = liveSelling.LiveSellingDateStart;
            dbLiveSelling.LiveSellingDateEnd = liveSelling.LiveSellingDateEnd;
            dbLiveSelling.LiveSellingImages = liveSelling.LiveSellingImages;
            dbLiveSelling.IsActive = liveSelling.IsActive;
            dbLiveSelling.HasEnded = liveSelling.HasEnded;
            dbLiveSelling.Deleted = liveSelling.Deleted;

            await _context.SaveChangesAsync();
            return await GetLiveSellings();
        }
    }
}
