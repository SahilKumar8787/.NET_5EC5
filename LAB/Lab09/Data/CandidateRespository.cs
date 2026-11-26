using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PlacementDashboard.Data
{
    public class CandidateRepository
    {
        public DataTable GetStatistics()
        {
            using var con = DatabaseConnection.GetConnection();
            using var cmd = new SqlCommand(@"
                SELECT
                    COUNT(*) AS Total,
                    SUM(CASE WHEN OfferStatus = 'Placed' THEN 1 ELSE 0 END) AS Placed,
                    SUM(CASE WHEN OfferStatus <> 'Placed' THEN 1 ELSE 0 END) AS NotPlaced
                FROM PlacementRecords", con);

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetAllCandidates()
        {
            using var con = DatabaseConnection.GetConnection();
            using var cmd = new SqlCommand(
                "SELECT CandidateId, CandidateName, RollNumber, BranchName, CGPA, RecruiterName, PackageLPA, OfferStatus FROM PlacementRecords ORDER BY CandidateId", con);

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable SearchCandidates(string keyword)
        {
            using var con = DatabaseConnection.GetConnection();
            using var cmd = new SqlCommand(@"
                SELECT CandidateId, CandidateName, RollNumber, BranchName, CGPA, RecruiterName, PackageLPA, OfferStatus
                FROM PlacementRecords
                WHERE CandidateName LIKE @Key
                   OR RollNumber LIKE @Key
                   OR BranchName LIKE @Key
                   OR ISNULL(RecruiterName, '') LIKE @Key
                   OR OfferStatus LIKE @Key
                ORDER BY CandidateId", con);

            cmd.Parameters.Add("@Key", SqlDbType.NVarChar, 120).Value = "%" + keyword + "%";

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void AddCandidate(string name, string rollNo, string branch, decimal cgpa, string recruiter, decimal? pkg, string status)
        {
            using var con = DatabaseConnection.GetConnection();
            using var cmd = new SqlCommand(@"
                INSERT INTO PlacementRecords (CandidateName, RollNumber, BranchName, CGPA, RecruiterName, PackageLPA, OfferStatus)
                VALUES (@Name, @RollNo, @Branch, @CGPA, @Recruiter, @Pkg, @Status)", con);

            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = name;
            cmd.Parameters.Add("@RollNo", SqlDbType.NVarChar, 30).Value = rollNo;
            cmd.Parameters.Add("@Branch", SqlDbType.NVarChar, 60).Value = branch;
            cmd.Parameters.Add("@CGPA", SqlDbType.Decimal).Value = cgpa;
            cmd.Parameters.Add("@Recruiter", SqlDbType.NVarChar, 100).Value =
                string.IsNullOrWhiteSpace(recruiter) ? (object)DBNull.Value : recruiter;
            cmd.Parameters.Add("@Pkg", SqlDbType.Decimal).Value =
                pkg.HasValue ? (object)pkg.Value : DBNull.Value;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 25).Value = status;

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void UpdateCandidate(int id, string name, string rollNo, string branch, decimal cgpa, string recruiter, decimal? pkg, string status)
        {
            using var con = DatabaseConnection.GetConnection();
            using var cmd = new SqlCommand(@"
                UPDATE PlacementRecords
                SET CandidateName = @Name,
                    RollNumber = @RollNo,
                    BranchName = @Branch,
                    CGPA = @CGPA,
                    RecruiterName = @Recruiter,
                    PackageLPA = @Pkg,
                    OfferStatus = @Status
                WHERE CandidateId = @Id", con);

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = name;
            cmd.Parameters.Add("@RollNo", SqlDbType.NVarChar, 30).Value = rollNo;
            cmd.Parameters.Add("@Branch", SqlDbType.NVarChar, 60).Value = branch;
            cmd.Parameters.Add("@CGPA", SqlDbType.Decimal).Value = cgpa;
            cmd.Parameters.Add("@Recruiter", SqlDbType.NVarChar, 100).Value =
                string.IsNullOrWhiteSpace(recruiter) ? (object)DBNull.Value : recruiter;
            cmd.Parameters.Add("@Pkg", SqlDbType.Decimal).Value =
                pkg.HasValue ? (object)pkg.Value : DBNull.Value;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 25).Value = status;

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void DeleteCandidate(int id)
        {
            using var con = DatabaseConnection.GetConnection();
            using var cmd = new SqlCommand("DELETE FROM PlacementRecords WHERE CandidateId = @Id", con);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}