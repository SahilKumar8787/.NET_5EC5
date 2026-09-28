<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="AcademicLeaveManagement.Default"
    UnobtrusiveValidationMode="None" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Academic Calendar & Leave Management</title>

    <style>

        * {
            box-sizing: border-box;
            font-family: Arial, sans-serif;
        }

        body {
            margin: 0;
            background: #f3f6fa;
            color: #222;
        }

        /* Header */

        .header {
            background: #294a7a;
            color: white;
            text-align: center;
            padding: 22px 10px;
        }

        .header h1 {
            margin: 0;
            font-size: 27px;
        }

        .header p {
            margin: 7px 0 0;
            font-size: 14px;
        }

        /* Main container */

        .container {
            width: 92%;
            max-width: 1050px;
            margin: 25px auto;
        }

        /* Card */

        .card {
            background: white;
            padding: 22px;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.08);
            margin-bottom: 22px;
        }

        .card h2 {
            margin-top: 0;
            color: #294a7a;
            font-size: 20px;
            border-bottom: 1px solid #ddd;
            padding-bottom: 10px;
        }

        /* Calendar */

        .calendar-card {
            text-align: center;
        }

        .calendar-card table {
            margin: auto;
        }

        .calendar-info {
            display: block;
            margin-top: 12px;
            color: #198754;
            font-weight: bold;
        }

        .instruction {
            color: #666;
            font-size: 14px;
            margin-bottom: 15px;
        }

        /* Welcome */

        .welcome {
            display: block;
            background: #eef4fb;
            padding: 10px;
            border-radius: 5px;
            margin-bottom: 15px;
            color: #294a7a;
        }

        /* Form */

        .form-table {
            width: 100%;
            max-width: 750px;
        }

        .form-table td {
            padding: 8px;
            vertical-align: top;
        }

        .form-table td:first-child {
            width: 150px;
            font-weight: bold;
            padding-top: 12px;
        }

        .input {
            width: 100%;
            padding: 9px;
            border: 1px solid #bbb;
            border-radius: 5px;
            font-size: 14px;
        }

        .validator {
            display: block;
            color: #d32f2f;
            font-size: 12px;
            margin-top: 4px;
        }

        /* Button */

        .btn {
            background: #294a7a;
            color: white;
            border: none;
            padding: 10px 22px;
            border-radius: 5px;
            cursor: pointer;
            font-size: 14px;
        }

        .btn:hover {
            background: #1f3b63;
        }

        /* Messages */

        .message {
            display: block;
            color: green;
            font-weight: bold;
            margin-top: 12px;
        }

        /* GridView */

        .grid {
            width: 100%;
            border-collapse: collapse;
        }

        .grid th {
            background: #294a7a;
            color: white;
            padding: 10px;
        }

        .grid td {
            padding: 9px;
            border: 1px solid #ddd;
            text-align: center;
        }

        .grid tr:nth-child(even) {
            background: #f7f9fc;
        }

        /* Responsive */

        @media (max-width: 700px) {

            .header h1 {
                font-size: 22px;
            }

            .form-table td {
                display: block;
                width: 100% !important;
            }

        }

    </style>

</head>


<body>

<form id="form1" runat="server">


    <!-- HEADER -->

    <div class="header">

        <h1>
            Academic Calendar & Leave Management System
        </h1>

        <p>
            Student Academic Calendar and Leave Application Portal
        </p>

    </div>


    <div class="container">


        <!-- STEP 1 : CALENDAR -->

        <div class="card calendar-card">

            <h2>
                Academic Calendar
            </h2>

            <p class="instruction">
                Please select a date from the calendar to apply for leave.
            </p>


            <asp:Calendar
                ID="Calendar1"
                runat="server"
                SelectionMode="Day"
                OnSelectionChanged="Calendar1_SelectionChanged">

                <TitleStyle
                    BackColor="#294a7a"
                    ForeColor="White"
                    Font-Bold="True" />

                <SelectedDayStyle
                    BackColor="#294a7a"
                    ForeColor="White"
                    Font-Bold="True" />

                <TodayDayStyle
                    BackColor="#e8eef7" />

            </asp:Calendar>


            <asp:Label
                ID="lblSelectedDate"
                runat="server"
                CssClass="calendar-info">
            </asp:Label>

        </div>



        <!-- STEP 2 : LEAVE APPLICATION -->

        <asp:Panel
            ID="pnlLeave"
            runat="server"
            CssClass="card"
            Visible="false">

            <h2>
                Leave Application
            </h2>


            <asp:Label
                ID="lblWelcome"
                runat="server"
                CssClass="welcome">
            </asp:Label>


            <table class="form-table">


                <!-- Student Name -->

                <tr>

                    <td>
                        Student Name
                    </td>

                    <td>

                        <asp:TextBox
                            ID="txtName"
                            runat="server"
                            CssClass="input"
                            placeholder="Enter student name">
                        </asp:TextBox>


                        <asp:RequiredFieldValidator
                            ID="rfvName"
                            runat="server"
                            ControlToValidate="txtName"
                            ErrorMessage="Student name is required."
                            CssClass="validator">
                        </asp:RequiredFieldValidator>

                    </td>

                </tr>


                <!-- Course -->

                <tr>

                    <td>
                        Course
                    </td>

                    <td>

                        <asp:DropDownList
                            ID="ddlCourse"
                            runat="server"
                            CssClass="input">

                            <asp:ListItem
                                Text="-- Select Course --"
                                Value="" />

                            <asp:ListItem
                                Text="B.Tech CSE"
                                Value="B.Tech CSE" />

                            <asp:ListItem
                                Text="B.Tech IT"
                                Value="B.Tech IT" />

                            <asp:ListItem
                                Text="BCA"
                                Value="BCA" />

                        </asp:DropDownList>


                        <asp:RequiredFieldValidator
                            ID="rfvCourse"
                            runat="server"
                            ControlToValidate="ddlCourse"
                            InitialValue=""
                            ErrorMessage="Please select course."
                            CssClass="validator">
                        </asp:RequiredFieldValidator>

                    </td>

                </tr>


                <!-- Leave Type -->

                <tr>

                    <td>
                        Leave Type
                    </td>

                    <td>

                        <asp:DropDownList
                            ID="ddlLeaveType"
                            runat="server"
                            CssClass="input">

                            <asp:ListItem
                                Text="-- Select Leave Type --"
                                Value="" />

                            <asp:ListItem
                                Text="Medical Leave"
                                Value="Medical Leave" />

                            <asp:ListItem
                                Text="Personal Leave"
                                Value="Personal Leave" />

                            <asp:ListItem
                                Text="Emergency Leave"
                                Value="Emergency Leave" />

                            <asp:ListItem
                                Text="Other"
                                Value="Other" />

                        </asp:DropDownList>


                        <asp:RequiredFieldValidator
                            ID="rfvLeaveType"
                            runat="server"
                            ControlToValidate="ddlLeaveType"
                            InitialValue=""
                            ErrorMessage="Please select leave type."
                            CssClass="validator">
                        </asp:RequiredFieldValidator>

                    </td>

                </tr>


                <!-- Leave Date -->

                <tr>

                    <td>
                        Leave Date
                    </td>

                    <td>

                        <asp:TextBox
                            ID="txtDate"
                            runat="server"
                            CssClass="input"
                            ReadOnly="true">
                        </asp:TextBox>

                    </td>

                </tr>


                <!-- Reason -->

                <tr>

                    <td>
                        Reason
                    </td>

                    <td>

                        <asp:TextBox
                            ID="txtReason"
                            runat="server"
                            CssClass="input"
                            TextMode="MultiLine"
                            Rows="3"
                            placeholder="Enter reason for leave">
                        </asp:TextBox>


                        <asp:RequiredFieldValidator
                            ID="rfvReason"
                            runat="server"
                            ControlToValidate="txtReason"
                            ErrorMessage="Please enter reason."
                            CssClass="validator">
                        </asp:RequiredFieldValidator>

                    </td>

                </tr>


                <!-- Button -->

                <tr>

                    <td></td>

                    <td>

                        <asp:Button
                            ID="btnApply"
                            runat="server"
                            Text="Apply Leave"
                            CssClass="btn"
                            OnClick="btnApply_Click" />

                    </td>

                </tr>


            </table>


            <asp:Label
                ID="lblMessage"
                runat="server"
                CssClass="message">
            </asp:Label>


        </asp:Panel>



        <!-- STEP 3 : LEAVE RECORDS -->

        <asp:Panel
            ID="pnlRecords"
            runat="server"
            CssClass="card"
            Visible="false">

            <h2>
                Leave Records
            </h2>


            <asp:GridView
                ID="gvLeaves"
                runat="server"
                CssClass="grid"
                AutoGenerateColumns="true">
            </asp:GridView>


        </asp:Panel>


    </div>

</form>

</body>

</html>