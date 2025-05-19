using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using MLAppAPI.Models;
using MLAppAPI.Services;

namespace MLAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictController : ControllerBase
    {
        private readonly IModelService _modelService;

        public PredictController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpPost]
        public async Task<IActionResult> Predict(PredictionRequest request)
        {
            var predictionEngine = await _modelService.GetPredictionEngineAsync();

            var input = new ModelInput
            {
                Col1 = request.Col1, // notDamagingMaterials
                Col2 = request.Col2  // damagingMaterials
            };

            var result = await Task.Run(() => predictionEngine.Predict(input));

            var damage = result.PredictedLabel switch
            { 
                0 => "Condition 0: No corrosion",
                1 => "Condition 1: Minor rust – safe.",
                2 => "Condition 2: Mild damage – monitor.",
                3 => "Condition 3: Moderate corrosion – needs checking.",
                4 => "Condition 4: Moderate corrosion – needs checking.",
                5 => "Condition 5: Severe corrosion – consider replacing.",
                6 => "Condition 6: Critical damage – must replace immediately.",
                _ => "Unknown condition."
            };

            var outputMessage = result.PredictedLabel switch
            {
                0 => $"Pipe appears to have <color=#228B22><b>NO DAMAGE</b></color> — {damage} ({request.Col2:F2}%).",
                1 or 2 => $"Pipe appears to have <color=#228B22><b>LOW DAMAGE</b></color> — {damage} ({request.Col2:F2}%).",
                3 or 4 => $"Pipe is likely to have <color=orange><b>MODERATE DAMAGE</b></color> — {damage} ({request.Col2:F2}%).",
                5 or 6 => $"Pipe is likely <color=red><b>DAMAGED</b></color> — {damage} ({request.Col2:F2}%).",
                _ => $"Pipe condition unknown. ({request.Col1:F2}%, {request.Col2:F2}%)"
            };

            return Ok(new
            {
                Prediction = result.PredictedLabel,
                Probability = result.Probability,
                Score = result.Score,
                Message = outputMessage
            });
        }

    }
}
