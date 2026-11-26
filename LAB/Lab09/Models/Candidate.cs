namespace PlacementDashboard.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string CandidateName { get; set; } = string.Empty;
        public string RollNumber { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public decimal CGPA { get; set; }
        public string RecruiterName { get; set; } = string.Empty;
        public decimal? PackageLPA { get; set; }
        public string OfferStatus { get; set; } = "Not Placed";
    }
}
