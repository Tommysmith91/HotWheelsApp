using HotWheelsApp.Domain;
using HotWheelsDbContext;
using Microsoft.EntityFrameworkCore;

namespace HotWheelsApp.Infrastructure
{
    public class HotWheelsRepositary : IHotWheelsRepositary
    {
        private readonly HotWheelsCollectionDbContext _dbContext;

        public HotWheelsRepositary(HotWheelsCollectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<HotWheel> Add(HotWheel hotWheel)
        {
            _dbContext.HotWheel.Add(hotWheel);
            await _dbContext.SaveChangesAsync();
            return hotWheel;
        }

        public async Task Delete(HotWheel hotWheel)
        {
            _dbContext.HotWheel.Remove(hotWheel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<HotWheel> Get(int id)
        {
            var hotWheel = await _dbContext.HotWheel.FirstOrDefaultAsync(x => x.Id == id);
            return hotWheel;

        }

        public async Task<IEnumerable<HotWheel>> GetAll()
        {
            var hotWheels = await _dbContext.HotWheel.ToListAsync<HotWheel>();
            return hotWheels;
        }

        public async Task Put(HotWheel hotWheel)
        {
            _dbContext.HotWheel.Update(hotWheel);
            await _dbContext.SaveChangesAsync();
        }
    }
}