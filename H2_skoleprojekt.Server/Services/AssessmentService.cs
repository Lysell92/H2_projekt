using Microsoft.AspNetCore.Http;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using H2_skoleprojekt.Server.Services;
using H2_skoleprojekt.Server.Models;
using H2_skoleprojekt.Server.DB;
using H2_skoleprojekt.Server.Controllers;

#pragma warning disable CA1416 // Validate platform compability

public class AssessmentService : IAssessmentService
    
{
    private readonly InferenceSession _session;
    private readonly IPlantDiagnosisRepository _repository;
    
    public AssessmentService(IPlantDiagnosisRepository repository)
    {
        _session = new InferenceSession("Models/plant_classifier.onnx");
        _repository = repository;
    }
    public async Task<string> PredictAsync(IFormFile image)
    {
        var tempFilePath = Path.GetTempFileName();
        using (var stream = new FileStream(tempFilePath, FileMode.Create))
        {
            await image.CopyToAsync(stream);
        }

        using var bitmap = new Bitmap(tempFilePath);
        var inputTensor = PreprocessImage(bitmap);

        var inputs = new List<NamedOnnxValue>
        {
            NamedOnnxValue.CreateFromTensor("input_name", inputTensor)
        };

        int predictedClass;
        using (var results = _session.Run(inputs))
        {
            var output = results.First().AsEnumerable<float>().ToArray();
            predictedClass = Array.IndexOf(output, output.Max());
        }

        var plant = await _repository.GetPlantByIdAsync(predictedClass);
        string predictionResult = plant != null
            ? $"{plant.PlantType}: {plant.DiseaseName} - {plant.Description}"
            : "Plant is not recognizable by the model";
        if (File.Exists(tempFilePath))
            File.Delete(tempFilePath);

        return predictionResult;
    }

    private DenseTensor<float> PreprocessImage(Bitmap image)
    {
        var resized = new Bitmap(128, 128);
        using (var g = Graphics.FromImage(resized))
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(image, 0, 0, 128, 128);
        }

        var input = new DenseTensor<float>(new[] { 1, 3, 128, 128 });
        for (int y = 0; y < 128; y++)
        {

            for (int x = 0; x < 128; x++)
            {
                var pixel = resized.GetPixel(x, y);
                input[0, 0, y, x] = pixel.R / 255f;
                input[0, 1, y, x] = pixel.G / 255f;
                input[0, 2, y, x] = pixel.B / 255f;
            }
        }
        return input;
    }
}

#pragma warning restore CA1416