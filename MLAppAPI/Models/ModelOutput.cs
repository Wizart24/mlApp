using Microsoft.ML.Data;

namespace MLAppAPI.Models
{
    public class ModelOutput
    {
        [ColumnName("PredictedLabel")]
        public float PredictedLabel { get; set; }
        public float Probability { get; set; }
        public float[] Score { get; set; }
    }
}
