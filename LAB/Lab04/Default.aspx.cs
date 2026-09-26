using System;
using System.Web.UI;

namespace EventRegistrationform
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Visible = false;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                lblMessage.Text =
                    "Registration Successful! Welcome " +
                    txtName.Text + ". Your event has been registered.";

                lblMessage.Visible = true;
            }
            else
            {
                lblMessage.Visible = false;
            }
        }

        protected void cvType_ServerValidate(
            object source,
            System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = rblType.SelectedIndex != -1;
        }

        protected void cvTerms_ServerValidate(
            object source,
            System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = chkTerms.Checked;
        }
    }
}