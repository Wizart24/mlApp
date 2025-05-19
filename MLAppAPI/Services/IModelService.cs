using Microsoft.ML;
using MLAppAPI.Models;

namespace MLAppAPI.Services
{
    public interface IModelService
    {
        Task<PredictionEngine<ModelInput, ModelOutput>> GetPredictionEngineAsync();
    }
}
