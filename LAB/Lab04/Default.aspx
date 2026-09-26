<%@ Page Title="Event Registration" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="EventRegistrationform._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>

        body {
            background-color: #eef4f8;
            font-family: Arial, sans-serif;
        }

        .event-container {
            width: 700px;
            margin: 20px auto;
            padding: 22px 35px;
            background-color: #f9fcff;
            border: 1px solid #d5e3ee;
            border-radius: 10px;
            box-shadow: 0 3px 12px rgba(0,0,0,0.08);
        }

        .event-title {
            text-align: center;
            color: #315a7d;
            font-size: 30px;
            margin: 0 0 20px 0;
        }

        .form-row {
            display: flex;
            align-items: flex-start;
            margin-bottom: 10px;
            min-height: 48px;
        }

        .form-label {
            width: 190px;
            font-weight: bold;
            color: #333;
            padding-top: 8px;
        }

        .input-area {
            width: 360px;
        }

        .form-control {
            width: 360px;
            height: 34px;
            padding: 5px 8px;
            border: 1px solid #bdccd8;
            border-radius: 5px;
            box-sizing: border-box;
            font-size: 14px;
        }

        .validator {
            display: block;
            color: #d9534f;
            font-size: 12px;
            margin-top: 3px;
        }

        .radio-area {
            padding-top: 5px;
        }

        .terms-area {
            margin: 5px 0 8px 190px;
        }

        .register-btn {
            display: block;
            width: 550px;
            height: 38px;
            margin: 12px auto 0 auto;
            background-color: #5b8db8;
            color: white;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            font-weight: bold;
            cursor: pointer;
        }

        .register-btn:hover {
            background-color: #47799f;
        }

        .validation-summary {
            color: #d9534f;
            margin: 8px 0;
            font-size: 13px;
        }

        .success-message {
            display: block;
            margin-top: 12px;
            padding: 8px;
            color: #287a3e;
            background-color: #e9f6ed;
            border: 1px solid #b9dfc2;
            border-radius: 5px;
            text-align: center;
            font-weight: bold;
            font-size: 13px;
        }

    </style>


    <div class="event-container">

        <!-- Heading -->

        <h1 class="event-title">
            Event Registration Portal
        </h1>


        <!-- FULL NAME -->

        <div class="form-row">

            <asp:Label ID="lblName"
                runat="server"
                Text="Full Name"
                CssClass="form-label" />

            <div class="input-area">

                <asp:TextBox ID="txtName"
                    runat="server"
                    CssClass="form-control"
                    placeholder="Enter Name" />

                <asp:RequiredFieldValidator
                    ID="rfvName"
                    runat="server"
                    ControlToValidate="txtName"
                    ErrorMessage="Enter Name"
                    CssClass="validator"
                    Display="Dynamic" />

            </div>

        </div>


        <!-- EMAIL -->

        <div class="form-row">

            <asp:Label ID="lblEmail"
                runat="server"
                Text="Email Address"
                CssClass="form-label" />

            <div class="input-area">

                <asp:TextBox ID="txtEmail"
                    runat="server"
                    CssClass="form-control"
                    TextMode="Email"
                    placeholder="Enter Email" />

                <asp:RequiredFieldValidator
                    ID="rfvEmail"
                    runat="server"
                    ControlToValidate="txtEmail"
                    ErrorMessage="Enter Email"
                    CssClass="validator"
                    Display="Dynamic" />

                <asp:RegularExpressionValidator
                    ID="revEmail"
                    runat="server"
                    ControlToValidate="txtEmail"
                    ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                    ErrorMessage="Enter valid Email"
                    CssClass="validator"
                    Display="Dynamic" />

            </div>

        </div>


        <!-- MOBILE -->

        <div class="form-row">

            <asp:Label ID="lblMobile"
                runat="server"
                Text="Mobile Number"
                CssClass="form-label" />

            <div class="input-area">

                <asp:TextBox ID="txtMobile"
                    runat="server"
                    CssClass="form-control"
                    MaxLength="10"
                    placeholder="Enter Mobile Number" />

                <asp:RequiredFieldValidator
                    ID="rfvMobile"
                    runat="server"
                    ControlToValidate="txtMobile"
                    ErrorMessage="Enter Mobile Number"
                    CssClass="validator"
                    Display="Dynamic" />

                <asp:RegularExpressionValidator
                    ID="revMobile"
                    runat="server"
                    ControlToValidate="txtMobile"
                    ValidationExpression="^[0-9]{10}$"
                    ErrorMessage="Enter 10 digit Mobile Number"
                    CssClass="validator"
                    Display="Dynamic" />

            </div>

        </div>


        <!-- COLLEGE -->

        <div class="form-row">

            <asp:Label ID="lblCollege"
                runat="server"
                Text="College / Organization"
                CssClass="form-label" />

            <div class="input-area">

                <asp:TextBox ID="txtCollege"
                    runat="server"
                    CssClass="form-control"
                    placeholder="Enter College / Organization" />

                <asp:RequiredFieldValidator
                    ID="rfvCollege"
                    runat="server"
                    ControlToValidate="txtCollege"
                    ErrorMessage="Enter College / Organization"
                    CssClass="validator"
                    Display="Dynamic" />

            </div>

        </div>


        <!-- EVENT -->

        <div class="form-row">

            <asp:Label ID="lblEvent"
                runat="server"
                Text="Select Event"
                CssClass="form-label" />

            <div class="input-area">

                <asp:DropDownList
                    ID="ddlEvent"
                    runat="server"
                    CssClass="form-control">

                    <asp:ListItem
                        Text="-- Select Event --"
                        Value="" />

                    <asp:ListItem
                        Text="Tech Fest 2026"
                        Value="Tech Fest 2026" />

                    <asp:ListItem
                        Text="Coding Competition"
                        Value="Coding Competition" />

                    <asp:ListItem
                        Text="AI & ML Workshop"
                        Value="AI & ML Workshop" />

                    <asp:ListItem
                        Text="Web Development Seminar"
                        Value="Web Development Seminar" />

                </asp:DropDownList>

                <asp:RequiredFieldValidator
                    ID="rfvEvent"
                    runat="server"
                    ControlToValidate="ddlEvent"
                    InitialValue=""
                    ErrorMessage="Select Event"
                    CssClass="validator"
                    Display="Dynamic" />

            </div>

        </div>


        <!-- SHIFT -->

        <div class="form-row">

            <asp:Label ID="lblShift"
                runat="server"
                Text="Select Shift"
                CssClass="form-label" />

            <div class="input-area">

                <asp:DropDownList
                    ID="ddlShift"
                    runat="server"
                    CssClass="form-control">

                    <asp:ListItem
                        Text="-- Select Shift --"
                        Value="" />

                    <asp:ListItem
                        Text="Morning Shift"
                        Value="Morning Shift" />

                    <asp:ListItem
                        Text="Afternoon Shift"
                        Value="Afternoon Shift" />

                    <asp:ListItem
                        Text="Evening Shift"
                        Value="Evening Shift" />

                </asp:DropDownList>

                <asp:RequiredFieldValidator
                    ID="rfvShift"
                    runat="server"
                    ControlToValidate="ddlShift"
                    InitialValue=""
                    ErrorMessage="Select Shift"
                    CssClass="validator"
                    Display="Dynamic" />

            </div>

        </div>


        <!-- PARTICIPANTS -->

        <div class="form-row">

            <asp:Label ID="lblParticipants"
                runat="server"
                Text="No. of Participants"
                CssClass="form-label" />

            <div class="input-area">

                <asp:TextBox
                    ID="txtParticipants"
                    runat="server"
                    CssClass="form-control"
                    TextMode="Number"
                    placeholder="Enter Number (1-10)" />

                <asp:RequiredFieldValidator
                    ID="rfvParticipants"
                    runat="server"
                    ControlToValidate="txtParticipants"
                    ErrorMessage="Enter Number of Participants"
                    CssClass="validator"
                    Display="Dynamic" />

                <asp:RangeValidator
                    ID="rvParticipants"
                    runat="server"
                    ControlToValidate="txtParticipants"
                    MinimumValue="1"
                    MaximumValue="10"
                    Type="Integer"
                    ErrorMessage="Participants must be between 1 and 10"
                    CssClass="validator"
                    Display="Dynamic" />

            </div>

        </div>


        <!-- PARTICIPATION TYPE -->

        <div class="form-row">

            <asp:Label ID="lblType"
                runat="server"
                Text="Participation Type"
                CssClass="form-label" />

            <div class="radio-area">

                <asp:RadioButtonList
                    ID="rblType"
                    runat="server"
                    RepeatDirection="Horizontal">

                    <asp:ListItem
                        Text="Student"
                        Value="Student" />

                    <asp:ListItem
                        Text="Faculty"
                        Value="Faculty" />

                    <asp:ListItem
                        Text="Other"
                        Value="Other" />

                </asp:RadioButtonList>

            </div>

        </div>


        <!-- TERMS -->

        <div class="terms-area">

            <asp:CheckBox
                ID="chkTerms"
                runat="server"
                Text=" I agree to Terms & Conditions" />

        </div>


        <!-- CUSTOM VALIDATORS -->

        <asp:CustomValidator
            ID="cvType"
            runat="server"
            ErrorMessage="Select Participation Type"
            CssClass="validator"
            Display="Dynamic"
            OnServerValidate="cvType_ServerValidate" />

        <asp:CustomValidator
            ID="cvTerms"
            runat="server"
            ErrorMessage="Accept Terms & Conditions"
            CssClass="validator"
            Display="Dynamic"
            OnServerValidate="cvTerms_ServerValidate" />


        <!-- VALIDATION SUMMARY -->

        <asp:ValidationSummary
            ID="ValidationSummary1"
            runat="server"
            HeaderText="Please correct the following:"
            CssClass="validation-summary"
            DisplayMode="BulletList" />


        <!-- REGISTER BUTTON -->

        <asp:Button
            ID="btnRegister"
            runat="server"
            Text="REGISTER"
            CssClass="register-btn"
            OnClick="btnRegister_Click" />


        <!-- SUCCESS MESSAGE -->

        <asp:Label
            ID="lblMessage"
            runat="server"
            CssClass="success-message"
            Visible="false" />

    </div>

</asp:Content>