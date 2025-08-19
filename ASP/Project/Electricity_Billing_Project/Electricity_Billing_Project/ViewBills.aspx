<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBills.aspx.cs" Inherits="Electricity_Billing_Project.ViewBills" %>

<!DOCTYPE html>
<html>
<head>
    <title>View Last N Bills</title>
    <style>
        body {
            font-family: Arial;
            background-color: white;
            margin: 0;
            padding: 0;
        }
        .container {
            display: flex;
            justify-content: space-between;
            padding: 50px;
        }
        .form-section {
            width: 45%;
            padding: 30px;
            border-radius: 10px;
            margin-top: 50px;
        }
        .form-section h2 {
            color: #2e7d32;
            margin-bottom: 20px;
        }
        #lblN {
            display: block;
            margin-top: 10px;
            font-weight: bold;
        }
        .form-section input {
            width: 200px;
            padding: 10px;
            margin-top: 5px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .btn-retrieve {
            background-color: #2e7d32;
            color: white;
            padding: 12px 24px;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            margin-top: 20px;
        }
        .btn-retrieve:hover {
            background-color: #1b5e20;
        }
        .image-section {
            width: 50%;
            padding: 20px;
        }
        .gridview {
            margin-top: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-section">
                <h2>Retrieve Last N Bills</h2>
                <asp:Label ID="lblN" runat="server" Text="Enter N:" />
                <asp:TextBox ID="txtN" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtN" ErrorMessage="Enter N values it is required" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve" OnClick="btnRetrieve_Click" CssClass="btn-retrieve" /><br /><br />
                <div class="gridview">
                    <asp:GridView ID="gvBills" runat="server" AutoGenerateColumns="true" />
                </div>
            </div>
            <div class="image-section">
                <img src="HomePage.jpg" alt="Home Page Image" style="width:600px;height:400px;" />
            </div>
        </div>
    </form>
</body>
</html>

