using Microsoft.ML;
using MLAppAPI.Models;

namespace MLAppAPI.Services.Interfaces
{
    public interface IModelService
    {
        Task<PredictionEngine<ModelInput, ModelOutput>> GetPredictionEngineAsync();
    }
}
