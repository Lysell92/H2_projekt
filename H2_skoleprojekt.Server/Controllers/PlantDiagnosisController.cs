using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using H2_skoleprojekt.Server.Services;
using H2_skoleprojekt.Server.Models;
using H2_skoleprojekt.Server.DB;

namespace H2_skoleprojekt.Server.Controllers
{ 
[ApiController]
[Route("api/[controller]")]
    public class PlantDiagnosisController : ControllerBase
    {
        private readonly PlantDbContext _context;
        private readonly IAssessmentService _assessmentService;

        public PlantDiagnosisController(IAssessmentService assessmentService, PlantDbContext context)
        {
            _assessmentService = assessmentService;
            _context = context;
        }

        [HttpPost("diagnose")]
        public async Task<IActionResult> Diagnose([FromForm] IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("No image uploaded.");
            }

            var prediction = await _assessmentService.PredictAsync(image);

            var parts = prediction.Split(" - ");
            if (parts.Length != 2)
                return BadRequest("Invalid prediction format.");

            var plantType = parts[0];
            var diseaseName = parts[1];

            // Looks into the Database for match
            var diagnosis = await _context.PlantDiagnosis!.FirstOrDefaultAsync(p => p.PlantType == plantType && p.DiseaseName == diseaseName);

            if (diagnosis == null)
                return NotFound("Diagnosis not found in database.");

            return Ok(diagnosis);
        }
    }
}