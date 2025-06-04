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
using System.Drawing.Printing;

#pragma warning disable CA1416 // Validate platform compability

public class AssessmentService : IAssessmentService
    
{
    private readonly InferenceSession _session;
    private readonly IPlantDbRepository _repository;
    
    public AssessmentService(IPlantDbRepository repository)
    {
        _session = new InferenceSession("ML/plant_classifier.onnx");
        _repository = repository;
    }

    public async Task<List<string>> PredictTopAsync(IFormFile image, int topN = 5)
    {
        using var stream = image.OpenReadStream();
        using var bitmap = new Bitmap(stream);

        var inputTensor = PreprocessImage(bitmap);

        var inputs = new List<NamedOnnxValue>
        {
            NamedOnnxValue.CreateFromTensor("input_layer", inputTensor)
        };

        var topPredictions = new List<string>();

        using (var results = _session.Run(inputs))
        {
            var resultTensor = results.First().AsEnumerable<float>().ToArray();

            var sortedIndices = resultTensor
                .Select((value, index) => new { Index = index, Value = value })
                .OrderByDescending(x => x.Value)
                .Take(topN);

            foreach (var pred in sortedIndices)
            {
                string label = ClassLabels.Labels[pred.Index];
                string confidence = pred.Value.ToString("P2");
                topPredictions.Add($"{label} ({confidence})");
            }
        }
        return topPredictions;
    }

    private DenseTensor<float> PreprocessImage(Bitmap image)
    {
        var resized = new Bitmap(128, 128);
        using (var g = Graphics.FromImage(resized))
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(image, 0, 0, 128, 128);
        }

        var input = new DenseTensor<float>(new[] { 1, 128, 128, 3 });
        for (int y = 0; y < 128; y++)
        {

            for (int x = 0; x < 128; x++)
            {
                var pixel = resized.GetPixel(x, y);
                input[0, y, x, 0] = pixel.R / 255f;
                input[0, y, x, 1] = pixel.G / 255f;
                input[0, y, x, 2] = pixel.B / 255f;
            }
        }
        return input;
    }
}

#pragma warning restore CA1416