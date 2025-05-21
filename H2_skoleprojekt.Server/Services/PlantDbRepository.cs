using H2_skoleprojekt.Server.DB;
using H2_skoleprojekt.Server.Models;
using Microsoft.EntityFrameworkCore;
namespace H2_skoleprojekt.Server.Services
{
    public class PlantDbRepository : IPlantDbRepository
    {
        private readonly PlantDbContext _context;


        public PlantDbRepository(PlantDbContext context)
        {
            _context = context;
        }

        public async Task<PlantDbModel> GetPlantByIdAsync(int id)
        {          
            return await _context.plantdb!.FirstOrDefaultAsync(p => p.plantid == id);
        }
    }
}
