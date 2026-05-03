namespace GovTaskManagement.Application.Dtos
{
    public class MlPredictionResponseDto
    {
        public int Prediction { get; set; }
        public string Label { get; set; }
        public double Confidence { get; set; }
        public AnalysisDto Analysis { get; set; }
    }

    public class AnalysisDto
    {
        public string RiskLevel { get; set; }
        public string Reason { get; set; }
    }
}