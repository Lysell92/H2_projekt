using H2_skoleprojekt.Server.Models;
namespace H2_skoleprojekt.Server.Services

{
    public interface IPlantDbRepository
    {
        Task<PlantDbModel> GetPlantByIdAsync(int id);
    }
}