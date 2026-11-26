using System;
using System.Drawing;
using System.Windows.Forms;
using PlacementDashboard.Data;
using PlacementDashboard.Helpers;

namespace PlacementDashboard.Forms
{
    public class CandidateForm : Form
    {
        private readonly CandidateRepository repo = new CandidateRepository();
        private TextBox txtName, txtRoll, txtCGPA;
        private TextBox txtRecruiter, txtPackage, txtSearch;
        private ComboBox cmbBranch, cmbStatus;
        private DataGridView dgvCandidates;

        public CandidateForm()
        {
            Text = "Candidate Placement Management";
            Size = new Size(1100, 700);
            StartPosition = FormStartPosition.CenterScreen;
            BuildInterface();
            LoadCandidates();
        }

        private void BuildInterface()
        {
            Label title = new Label
            {
                Text = "CANDIDATE PLACEMENT MANAGEMENT",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Location = new Point(25, 15),
                Size = new Size(650, 40)
            };
            Controls.Add(title);

            AddLabel("Candidate Name", 25, 65);
            AddLabel("Roll Number", 260, 65);
            AddLabel("CGPA (0-10)", 495, 65);

            AddLabel("Recruiter Name", 25, 125);
            AddLabel("Package (LPA)", 260, 125);
            AddLabel("Branch", 495, 125);
            AddLabel("Offer Status", 730, 125);

            txtName = AddTextBox(25, 85, 200);
            txtRoll = AddTextBox(260, 85, 200);
            txtCGPA = AddTextBox(495, 85, 200);

            txtRecruiter = AddTextBox(25, 145, 200);
            txtPackage = AddTextBox(260, 145, 200);

            cmbBranch = new ComboBox
            {
                Location = new Point(495, 145),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDown
            };
            cmbBranch.Items.AddRange(new object[]
            {
                "Computer Engineering",
                "Information Technology",
                "Electronics Engineering",
                "Mechanical Engineering",
                "Civil Engineering"
            });
            Controls.Add(cmbBranch);

            cmbStatus = new ComboBox
            {
                Location = new Point(730, 145),
                Width = 180,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStatus.Items.AddRange(new object[] { "Placed", "Not Placed" });
            cmbStatus.SelectedIndex = 1;
            Controls.Add(cmbStatus);

            AddButton("Add", 25, 200, AddCandidate);
            AddButton("Update", 125, 200, UpdateCandidate);
            AddButton("Delete", 225, 200, DeleteCandidate);
            AddButton("Clear", 325, 200, ClearFields);

            AddLabel("Search by name, roll, branch, recruiter or status", 495, 185);
            txtSearch = AddTextBox(495, 205, 260);
            AddButton("Search", 770, 200, SearchCandidates);
            AddButton("Refresh", 870, 200, LoadCandidates);

            dgvCandidates = new DataGridView
            {
                Location = new Point(25, 255),
                Size = new Size(1030, 380),
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                MultiSelect = false
            };
            dgvCandidates.CellClick += DgvCandidates_CellClick;
            Controls.Add(dgvCandidates);
        }

        private void AddLabel(string text, int x, int y)
        {
            Controls.Add(new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            });
        }

        private TextBox AddTextBox(int x, int y, int width)
        {
            TextBox box = new TextBox { Location = new Point(x, y), Width = width };
            Controls.Add(box);
            return box;
        }

        private void AddButton(string text, int x, int y, Action action)
        {
            Button button = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(90, 32)
            };
            button.Click += (s, e) => action();
            Controls.Add(button);
        }

        private void LoadCandidates()
        {
            try
            {
                dgvCandidates.DataSource = repo.GetAllCandidates();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private bool GetInput(out decimal cgpa, out decimal? package, out string status)
        {
            status = cmbStatus.Text;
            if (!InputValidator.IsValidEntry(
                txtName.Text.Trim(),
                txtRoll.Text.Trim(),
                cmbBranch.Text.Trim(),
                txtCGPA.Text.Trim(),
                txtPackage.Text.Trim(),
                status,
                out cgpa,
                out package,
                out string error))
            {
                MessageBox.Show(error, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void AddCandidate()
        {
            try
            {
                if (!GetInput(out decimal cgpa, out decimal? package, out string status)) return;
                repo.AddCandidate(txtName.Text.Trim(), txtRoll.Text.Trim(), cmbBranch.Text.Trim(), cgpa, txtRecruiter.Text.Trim(), package, status);
                LoadCandidates();
                ClearFields();
                MessageBox.Show("Candidate added successfully.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void UpdateCandidate()
        {
            if (dgvCandidates.CurrentRow == null)
            {
                MessageBox.Show("Select a candidate first.");
                return;
            }
            try
            {
                if (!GetInput(out decimal cgpa, out decimal? package, out string status)) return;
                int id = Convert.ToInt32(dgvCandidates.CurrentRow.Cells["CandidateId"].Value);
                repo.UpdateCandidate(id, txtName.Text.Trim(), txtRoll.Text.Trim(), cmbBranch.Text.Trim(), cgpa, txtRecruiter.Text.Trim(), package, status);
                LoadCandidates();
                ClearFields();
                MessageBox.Show("Candidate updated successfully.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void DeleteCandidate()
        {
            if (dgvCandidates.CurrentRow == null)
            {
                MessageBox.Show("Select a candidate first.");
                return;
            }
            if (MessageBox.Show("Delete the selected candidate?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                int id = Convert.ToInt32(dgvCandidates.CurrentRow.Cells["CandidateId"].Value);
                repo.DeleteCandidate(id);
                LoadCandidates();
                ClearFields();
                MessageBox.Show("Candidate deleted successfully.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void SearchCandidates()
        {
            try
            {
                dgvCandidates.DataSource = repo.SearchCandidates(txtSearch.Text.Trim());
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void DgvCandidates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvCandidates.Rows[e.RowIndex];
            txtName.Text = Convert.ToString(row.Cells["CandidateName"].Value);
            txtRoll.Text = Convert.ToString(row.Cells["RollNumber"].Value);
            cmbBranch.Text = Convert.ToString(row.Cells["BranchName"].Value);
            txtCGPA.Text = Convert.ToString(row.Cells["CGPA"].Value);
            txtRecruiter.Text = Convert.ToString(row.Cells["RecruiterName"].Value);
            txtPackage.Text = Convert.ToString(row.Cells["PackageLPA"].Value);
            cmbStatus.Text = Convert.ToString(row.Cells["OfferStatus"].Value);
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtRoll.Clear();
            txtCGPA.Clear();
            txtRecruiter.Clear();
            txtPackage.Clear();
            txtSearch.Clear();
            cmbBranch.SelectedIndex = -1;
            cmbStatus.SelectedIndex = 1;
            dgvCandidates.ClearSelection();
        }

        private void ShowError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}