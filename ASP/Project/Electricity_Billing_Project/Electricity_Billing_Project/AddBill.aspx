<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBill.aspx.cs" Inherits="Electricity_Billing_Project.AddBill" %>

<!DOCTYPE html>
<html>
<head>
    <title>Add Electricity Bill</title>
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
            width: 50%;
            padding: 20px;
            border-radius: 10px;
            margin-top: 50px;
        }
        .form-section h2 {
            color: #2e7d32;
            margin-bottom: 20px;
        }
        .form-section label {
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
        .btn-submit {
            background-color: #2e7d32;
            color: white;
            padding: 12px 24px;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            margin-top: 20px;
        }
        .btn-submit:hover {
            background-color: #1b5e20;
        }
        .image-section {
            width: 45%;
            padding: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-section">
                <h2>Add Electricity Bill</h2>
                <asp:Label ID="lblConsumerNumber" runat="server" Text="Consumer Number:" />
                <asp:TextBox ID="txtConsumerNumber" runat="server" />
                <asp:RequiredFieldValidator ID="custno" runat="server" ErrorMessage="Enter Customer number " ForeColor="Red" ControlToValidate="txtConsumerNumber"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtConsumerNumber" Display="Dynamic" ErrorMessage="Entered Customer number should be in format (EBXXXXX)" ForeColor="Red" ValidationExpression="^EB\d{5}$"></asp:RegularExpressionValidator>
                <br />
                <asp:Label ID="lblConsumerName" runat="server" Text="Consumer Name:" />
                <asp:TextBox ID="txtConsumerName" runat="server" />
                <asp:RequiredFieldValidator ID="custname" runat="server" ErrorMessage="Customer name is required" ForeColor="Red" ControlToValidate="txtConsumerName"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblUnits" runat="server" Text="Units Consumed:" />
                <asp:TextBox ID="txtUnits" runat="server" />
                <asp:RequiredFieldValidator ID="units" runat="server" ErrorMessage="Enter number of units" ForeColor="Red" ControlToValidate="txtUnits"></asp:RequiredFieldValidator>
                <br /><br />
                <asp:Button ID="btnCalculate" runat="server" Text="Calculate & Save" OnClick="btnCalculate_Click" CssClass="btn-submit" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRetrieve" runat="server" Text="View Bills" OnClick="btnRetrieve_Click" CssClass="btn-submit" />              
                <br />
                <asp:Label ID="lblResult" runat="server" ForeColor="Green" />
            </div>
            <div class="image-section">
                <img src="HomePage.jpg" alt="Home Page Image" style="width:600px;height:400px;" />
            </div>
        </div>
    </form>
</body>
</html>
