<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Electricity_Billing_Project.Home" %>

<!DOCTYPE html>
<html>
<head>
    <title>Electricity Bill</title>
    <style>
        body {
            font-family: Arial;
            background-color:white;
            /*background-color: #f0fdf4;*/
            margin: 0;
            padding: 0;
        }
        .container {
            display: flex;
            justify-content: space-between;
            padding: 50px;
        }
        .left {
            width: 50%;
            margin-left:30px;
            margin-top:110px;
        }
        .right {
            width: 50%;
            padding: 20px;
        }
        h1 {
            color: #2e7d32;
        }
        .btn-login {
            background-color: #2e7d32;
            color: white;
            padding: 12px 24px;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            margin-top: 20px;
        }
        .btn-login:hover {
            background-color: #1b5e20;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="left">
                <h1>Electricity Bill</h1>
                <p>Electricity Bill Automation System simplifies billing by calculating, storing, and retrieving consumer electricity bills efficiently.</p>
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn-login" OnClick="btnLogin_Click" />
            </div>
            <div class="right">
                <img src="HomePage.jpg" alt="Home Page Image" style="width:600px;height:400px;" />
            </div>
        </div>
    </form>
</body>
</html>
