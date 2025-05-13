using H2_skoleprojekt.Server.Models;
namespace H2_skoleprojekt.Server.Services

{
    public interface IPlantDiagnosisRepository
    {
        Task<PlantDiagnosisModel> GetPlantByIdAsync(int id);
    }
}