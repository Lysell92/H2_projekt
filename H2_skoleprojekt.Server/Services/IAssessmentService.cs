using System;

public interface IAssessmentService
{
    Task<List<string>> PredictTopAsync(IFormFile image, int topN);
}
