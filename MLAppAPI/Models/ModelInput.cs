using Microsoft.ML.Data;

namespace MLAppAPI.Models
{
    public class ModelInput
    {
        [LoadColumn(0)]
        public float Col1 { get; set; }

        [LoadColumn(1)]
        public float Col2 { get; set; }

        [LoadColumn(2)]
        public float Col3 { get; set; }
    }
}
