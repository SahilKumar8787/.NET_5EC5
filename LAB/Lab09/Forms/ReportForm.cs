using System;
using System.Drawing;
using System.Windows.Forms;
using PlacementDashboard.Data;

namespace PlacementDashboard.Forms
{
    public class ReportForm : Form
    {
        public ReportForm()
        {
            Text = "Placement Summary Report";
            Size = new Size(1000, 600);
            StartPosition = FormStartPosition.CenterScreen;

            Label title = new Label
            {
                Text = "CANDIDATE PLACEMENT REPORT",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(20, 15),
                Size = new Size(600, 40)
            };
            Controls.Add(title);

            DataGridView grid = new DataGridView
            {
                Location = new Point(20, 70),
                Size = new Size(940, 440),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            Controls.Add(grid);

            Button btnRefresh = new Button
            {
                Text = "Refresh Report",
                Location = new Point(20, 525),
                Size = new Size(140, 30)
            };
            btnRefresh.Click += (s, e) => LoadReport(grid);
            Controls.Add(btnRefresh);

            LoadReport(grid);
        }

        private void LoadReport(DataGridView grid)
        {
            try
            {
                grid.DataSource = new CandidateRepository().GetAllCandidates();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Report error: " + ex.Message);
            }
        }
    }
}