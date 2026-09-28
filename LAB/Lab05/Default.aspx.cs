using System;
using System.Data;

namespace AcademicLeaveManagement
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblWelcome.Text =
                    "Please enter your details to apply for leave.";

                // Create Leave Table in Session
                if (Session["LeaveTable"] == null)
                {
                    DataTable table = new DataTable();

                    table.Columns.Add("Student Name");
                    table.Columns.Add("Course");
                    table.Columns.Add("Leave Type");
                    table.Columns.Add("Leave Date");
                    table.Columns.Add("Reason");

                    Session["LeaveTable"] = table;
                }

                // Get Student Name from Session
                if (Session["StudentName"] != null)
                {
                    txtName.Text =
                        Session["StudentName"].ToString();

                    lblWelcome.Text =
                        "Welcome, " +
                        Session["StudentName"].ToString();
                }

                // Get Student Name from Cookie
                if (Request.Cookies["StudentName"] != null)
                {
                    txtName.Text =
                        Request.Cookies["StudentName"].Value;

                    lblWelcome.Text =
                        "Welcome back, " +
                        Request.Cookies["StudentName"].Value;
                }
            }
        }


        // Calendar Date Selection
        protected void Calendar1_SelectionChanged(
            object sender,
            EventArgs e)
        {
            string selectedDate =
                Calendar1.SelectedDate.ToString("dd-MM-yyyy");

            // Put selected date in textbox
            txtDate.Text = selectedDate;

            // Display selected date
            lblSelectedDate.Text =
                "Selected Date: " + selectedDate;

            // Show Leave Application
            pnlLeave.Visible = true;

            // Welcome message
            lblWelcome.Text =
                "Date selected. Please fill the leave application.";
        }


        // Apply Leave Button
        protected void btnApply_Click(
            object sender,
            EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }


            // Store Student Name in Session
            Session["StudentName"] =
                txtName.Text.Trim();


            // Store Student Name in Cookie
            Response.Cookies["StudentName"].Value =
                txtName.Text.Trim();

            Response.Cookies["StudentName"].Expires =
                DateTime.Now.AddDays(7);


            // Get Leave Table from Session
            DataTable table =
                (DataTable)Session["LeaveTable"];


            // Create New Row
            DataRow row =
                table.NewRow();


            row["Student Name"] =
                txtName.Text.Trim();

            row["Course"] =
                ddlCourse.SelectedValue;

            row["Leave Type"] =
                ddlLeaveType.SelectedValue;

            row["Leave Date"] =
                txtDate.Text;

            row["Reason"] =
                txtReason.Text.Trim();


            // Add Row
            table.Rows.Add(row);


            // Store Updated Table
            Session["LeaveTable"] =
                table;


            // Show Leave Records
            pnlRecords.Visible = true;

            gvLeaves.DataSource = table;

            gvLeaves.DataBind();


            // Success Message
            lblMessage.Text =
                "Leave application submitted successfully.";


            lblWelcome.Text =
                "Welcome, " +
                txtName.Text.Trim();


            // Clear some fields
            ddlCourse.SelectedIndex = 0;

            ddlLeaveType.SelectedIndex = 0;

            txtReason.Text = "";
        }
    }
}