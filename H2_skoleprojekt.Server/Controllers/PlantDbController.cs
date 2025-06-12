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
    public class PlantDbController : ControllerBase
    {
        private readonly PlantDbContext _context;
        private readonly IAssessmentService _assessmentService;

        public PlantDbController(IAssessmentService assessmentService, PlantDbContext context)
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

            List<string> predictedLabels = await _assessmentService.PredictTopAsync(image, 5);

            string? matchedLabel = null;
            foreach (var label in predictedLabels)

            {
                var cleanlabel = label.Split('(')[0].Trim();
                var result = await _context.plantdb!.FirstOrDefaultAsync(p => p.stringlabel == cleanlabel);
                if (result != null)
                {
                    matchedLabel = label;
                    Console.WriteLine($"📸 Model predicted label: {matchedLabel}");
                    return Ok(new
                    {
                        prediction = matchedLabel,
                        details = result
                    });
                }
            }

            return NotFound("Plant or disease is not found in the database.");
        }
    }
}