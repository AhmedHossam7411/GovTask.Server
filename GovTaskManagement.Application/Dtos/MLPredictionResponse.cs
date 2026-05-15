namespace GovTaskManagement.Application.Dtos
{
    public class MlPredictionResponseDto
    {
        public double Confidence { get; set; }
        public TabPfnDto TabPfn { get; set; }
        public AnalysisDto Analysis { get; set; }
    }

    public class TabPfnDto
    {
        public double Score { get; set; }
        public string Label { get; set; }
        public string Verdict { get; set; }
    }

    public class AnalysisDto
    {
        public string RiskLevel { get; set; }
        public string Reason { get; set; }
    }
}