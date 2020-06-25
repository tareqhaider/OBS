<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OBS_WebForms.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="LoginForm" runat="server">
        <div>
            <table>
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Email"></asp:Label></td>
                    <td><asp:TextBox ID="email" runat="server"></asp:TextBox><br/></td>
                    <td><asp:RequiredFieldValidator ControlToValidate="email" Display="Static" ErrorMessage="Email is required." ID="validator_email" RunAt="server" /></td>
                    
                </tr>

                <tr>
                    <td><asp:Label ID="Label2" runat="server" Text="Password"></asp:Label></td>
                    <td><asp:TextBox ID="pass" runat="server" TextMode="Password"></asp:TextBox><br/></td>
                    <td><asp:RequiredFieldValidator ControlToValidate="pass" Display="Static" ErrorMessage="Password is required." ID="validator_password" RunAt="server" /></td>
                </tr>

                <%--<tr>
                    <td></td>
                    <td><asp:CheckBox ID="remember" runat="server" Text="Remember Me"/></td>
                </tr>--%>

                <tr>
                    <td><asp:Button ID="Button2" Width="125px" runat="server" Text="Register" causesvalidation="false" OnClick="Button2_Click" /></td>
                    <td><asp:Button ID="Button1" Width="125px" runat="server" Text="Login" OnClick="Button1_Click" /></td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>


