using System;

public interface IAssessmentService
{
    Task<string> PredictAsync(IFormFile image);
    void PrintonnxNames();
}
