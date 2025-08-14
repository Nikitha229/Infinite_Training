<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question_1_Validator.aspx.cs" Inherits="Assignement_1.Validator" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validator Form</title>
    <style>
        .form-container {
            margin: 40px;
            font-family: Arial;
        }
        .form-container h2 {
            color: darkblue;
            text-align: center;
        }
        .form-container div {
            margin-bottom: 10px;
        }
        .error {
            color: red;
        }
    </style>

        <script type="text/javascript">
            function validateForm() {
                var errors = [];

                var name = document.getElementById("txtName").value.trim();
                var familyName = document.getElementById("txtFamilyName").value.trim();
                var address = document.getElementById("txtAddress").value.trim();
                var city = document.getElementById("txtCity").value.trim();
                var zip = document.getElementById("txtZip").value.trim();
                var phone = document.getElementById("txtPhone").value.trim();
                var email = document.getElementById("txtEmail").value.trim();

                if (name === "") errors.push("Name is required.");
                if (familyName === "") errors.push("Family Name is required.");
                if (name === familyName) errors.push("Name and Family Name must be different.");
                if (address.length < 2) errors.push("Address must be at least 2 characters.");
                if (city.length < 2) errors.push("City must be at least 2 characters.");
                if (!/^\d{5}$/.test(zip)) errors.push("Zip Code must be 5 digits.");
                if (!/^\d{2,3}-\d{7}$/.test(phone)) errors.push("Phone must be in format XX-XXXXXXX or XXX-XXXXXXX.");
                if (!/^\w+([-.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/.test(email)) errors.push("Invalid email format.");

                if (errors.length > 0) {
                    alert("Please fix the following errors:\n\n" + errors.join("\n"));
                    return false;
                }

                return true;
            }
        </script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return validateForm()">
        <div class="form-container">
            <h2>Validator Form</h2>
            <asp:Label ID="lblResult" runat="server" CssClass="error" />

            <div>
                Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtName" runat="server" />
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required" CssClass="error" />
            </div>

            <div>
                Family Name:&nbsp;
                <asp:TextBox ID="txtFamilyName" runat="server" />
                <asp:RequiredFieldValidator ID="rfvFamilyName" runat="server" ControlToValidate="txtFamilyName" ErrorMessage="Family Name is required" CssClass="error" />
            </div>

            <div>
                Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtAddress" runat="server" />
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address is required" CssClass="error" />
                <asp:RegularExpressionValidator ID="revAddress" runat="server" ControlToValidate="txtAddress" ValidationExpression=".{2,}" ErrorMessage="Address must be at least 2 characters" CssClass="error" />
            </div>

            <div>
                City:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtCity" runat="server" />
                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity" ErrorMessage="City is required" CssClass="error" />
                <asp:RegularExpressionValidator ID="revCity" runat="server" ControlToValidate="txtCity" ValidationExpression=".{2,}" ErrorMessage="City must be at least 2 characters" CssClass="error" />
            </div>

            <div>
                Zip Code:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtZip" runat="server" />
                <asp:RequiredFieldValidator ID="rfvZip" runat="server" ControlToValidate="txtZip" ErrorMessage="Zip Code is required" CssClass="error" />
                <asp:RegularExpressionValidator ID="revZip" runat="server" ControlToValidate="txtZip" ValidationExpression="^\d{5}$" ErrorMessage="Zip Code must be 5 digits" CssClass="error" />
            </div>

            <div>
                Phone:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtPhone" runat="server" />
                <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone is required" CssClass="error" />
                <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhone" ValidationExpression="^\d{2,3}-\d{7}$" ErrorMessage="Phone must be in format XX-XXXXXXX or XXX-XXXXXXX" CssClass="error" />
            </div>

            <div>
                Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtEmail" runat="server" />
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required" CssClass="error" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid email format" CssClass="error" />
                <br />
            </div>

            <div>
                <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" />
            </div>


        </div>
    </form>
</body>
</html>


