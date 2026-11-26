using System.Globalization;

namespace PlacementDashboard.Helpers
{
    public static class InputValidator
    {
        public static bool IsValidEntry(
            string name,
            string rollNo,
            string branch,
            string cgpaText,
            string packageText,
            string status,
            out decimal cgpa,
            out decimal? packageLpa,
            out string errorMessage)
        {
            cgpa = 0;
            packageLpa = null;
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
                errorMessage = "Candidate name is required.";
            else if (string.IsNullOrWhiteSpace(rollNo))
                errorMessage = "Roll number is required.";
            else if (string.IsNullOrWhiteSpace(branch))
                errorMessage = "Please select or enter a branch.";
            else if (!decimal.TryParse(cgpaText, NumberStyles.Number, CultureInfo.InvariantCulture, out cgpa) || cgpa < 0 || cgpa > 10)
                errorMessage = "CGPA must be between 0 and 10.";
            else if (!string.IsNullOrWhiteSpace(packageText))
            {
                if (!decimal.TryParse(packageText, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal pkg) || pkg < 0 || pkg > 500)
                    errorMessage = "Package (LPA) must be a valid positive number.";
                else
                    packageLpa = pkg;
            }

            if (errorMessage == string.Empty && status != "Placed" && status != "Not Placed")
                errorMessage = "Select status as Placed or Not Placed.";

            return errorMessage == string.Empty;
        }
    }
}