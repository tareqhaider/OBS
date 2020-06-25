<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="OBS_WebForms.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table >
                <tr>
                    <td>
                         <asp:HyperLink ID="profileD" NavigateUrl="~/Profile.aspx" runat="server">	&nbsp Profile</asp:HyperLink>
                        <asp:HyperLink ID="Login" NavigateUrl="~/Login.aspx" runat="server">	&nbsp Login</asp:HyperLink>
                        <asp:HyperLink ID="Register" NavigateUrl="~/Registration.aspx" runat="server">	&nbsp Register</asp:HyperLink>
                        <asp:HyperLink ID="Sell" NavigateUrl="~/Sell.aspx" runat="server">	&nbsp Sell</asp:HyperLink>
                        <asp:HyperLink ID="Buy" NavigateUrl="~/Home.aspx" runat="server">	&nbsp Buy</asp:HyperLink>
                       
                    </td>

                    <td>
                        <asp:LinkButton ID="Logout" runat="server" OnClick="Logout_Click" >&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Logout</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
         <br /><br /> <br />
        <br />
        <div>
            <asp:Label ID="Label2" runat="server" Text="Profile Details"></asp:Label>
            <br /><br /> 

            <asp:DetailsView ID="dvProfile" runat="server" Height="50px"  Width="125px">
            </asp:DetailsView>
            <br /><br /> <br />
            <%--<asp:Button ID="btnProfileInfo" runat="server" Text="Change Profile Information" OnClick="btnProfileInfo_Click" /><asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />--%>

        </div>

       <%-- <div id="changePersonal" runat="server">
        <br /><br /> 
        <asp:Label ID="Label3" runat="server" Text="First Name:" Width="100px"></asp:Label>
            <asp:TextBox ID="txtFname" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtFname" Display="Static" ErrorMessage="First Name is required." ForeColor="IndianRed" ID="RequiredFieldValidator4" RunAt="server" />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Last Name:" Width="100px"></asp:Label>
            <asp:TextBox ID="txtLname" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtLname" Display="Static" ErrorMessage="Last Name is required." ForeColor="IndianRed" ID="RequiredFieldValidator2" RunAt="server" />
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Phone Number:" Width="100px"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtPhone" Display="Static" ErrorMessage="Phone is required." ForeColor="IndianRed" ID="RequiredFieldValidator1" RunAt="server" />
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Current Password:" Width="100px"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtPassword" Display="Static" ErrorMessage="Enter Current Password." ForeColor="IndianRed" ID="RequiredFieldValidator5" RunAt="server" />
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="New Password:" Width="100px"></asp:Label>
            <asp:TextBox ID="txtNewPassword" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtNewPassword" Display="Static" ErrorMessage="Enter New Password." ForeColor="IndianRed" ID="RequiredFieldValidator3" RunAt="server" />
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Confirm Password:" Width="100px"></asp:Label>
            <asp:TextBox ID="txtConfirmNewPassword" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtConfirmNewPassword" Display="Static" ErrorMessage="Confirm New Password." ForeColor="IndianRed" ID="RequiredFieldValidator6" RunAt="server" />
            <br />
            <br />
            <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" />
        <br />
        <br />
        <br />
            </div>--%>
        <div>
            <br />
        <br />
            <asp:Label ID="Label1" runat="server" Text="Order Details"></asp:Label>
             <br /><br /> 

            <asp:GridView ID="gvOrder" runat="server"></asp:GridView>
            <br />
        </div>
        <asp:Label ID="msg" runat="server"></asp:Label>
    </form>
</body>
</html>
