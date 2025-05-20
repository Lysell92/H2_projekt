using H2_skoleprojekt.Server.DB;
using H2_skoleprojekt.Server.Models;
using Microsoft.EntityFrameworkCore;
namespace H2_skoleprojekt.Server.Services
{
    public class PlantDiagnosisRepository : IPlantDiagnosisRepository
    {
        private readonly PlantDbContext _context;


        public PlantDiagnosisRepository(PlantDbContext context)
        {
            _context = context;
        }

        public async Task<PlantDiagnosisModel> GetPlantByIdAsync(int id)
        {
            return await _context.PlantDiagnosis.FirstOrDefaultAsync(predicate : p.PlantID == id);
        }
    }
}
