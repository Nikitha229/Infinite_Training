<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Electricity_Billing_Project.Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>Electricity Bill - Admin Login</title>
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
/*            align-items: center;
            height: 100vh;*/
            padding: 50px;
        }
        .login-section {
            width: 45%;
            padding: 30px;
            /*background-color: #e8f5e9;*/
            border-radius: 10px;
            margin-top:85px;
        }
        .login-section h2 {
            color: #2e7d32;
            margin-bottom: 20px;
        }
        .login-section label {
            display: block;
            margin-top: 10px;
            font-weight: bold;
        }
        .login-section input {
            width: 200px;
            padding: 10px;
            margin-top: 5px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
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
        .image-section {
           width: 50%;
           padding: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="login-section">
                <h2>Admin Login</h2>
                <asp:Label ID="lblUser" runat="server" Text="Username:" />
                <asp:TextBox ID="txtUser" runat="server" />
                <asp:RequiredFieldValidator ID="username" runat="server" ErrorMessage="Enter username" ForeColor="Red" ControlToValidate="txtUser"></asp:RequiredFieldValidator>
                <br/>
                <asp:Label ID="lblPass" runat="server" Text="Password:" />
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" />
                <asp:RequiredFieldValidator ID="pswd" runat="server" ErrorMessage="Enter Password" ForeColor="Red" ControlToValidate="txtPass"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn-login" />
                <br />
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
            </div>
            <div class="image-section">
                 <img src="HomePage.jpg" alt="Home Page Image" style="width:600px;height:400px;" />
            </div>
        </div>
    </form>
</body>
</html>
