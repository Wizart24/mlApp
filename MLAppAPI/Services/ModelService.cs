using Microsoft.ML;
using MLAppAPI.Models;

namespace MLAppAPI.Services
{
    public class ModelService : IModelService
    {
        private static PredictionEngine<ModelInput, ModelOutput>? predictionEngine;

        public async Task<PredictionEngine<ModelInput, ModelOutput>> GetPredictionEngineAsync()
        {
            if (predictionEngine == null)
            {
                await LoadModelAsync();
            }
            return predictionEngine!;
        }

        private async Task LoadModelAsync()
        {
            var modelPath = Path.Combine(AppContext.BaseDirectory, "Models", "corrosionModel.zip");
            var mlContext = new MLContext();

            if (!File.Exists(modelPath))
            {
                throw new FileNotFoundException($"Model file not found at {modelPath}");
            }

            await using var stream = new FileStream(modelPath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
            var model = mlContext.Model.Load(stream, out _);

            predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(model);
        }
    }
}
