<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="OBS_WebForms.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <table >
                <tr>
                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="Username">Username</asp:LinkButton>
                        <asp:HyperLink ID="Login" NavigateUrl="~/Login.aspx" runat="server">Login</asp:HyperLink>
                        <asp:HyperLink ID="Register" NavigateUrl="~/Registration.aspx" runat="server">	&nbsp Register</asp:HyperLink>
                        <asp:HyperLink ID="Sell" NavigateUrl="~/Sell.aspx" runat="server">	&nbsp Sell</asp:HyperLink>
                        <asp:HyperLink ID="Buy" NavigateUrl="~/Home.aspx" runat="server">	&nbsp Buy</asp:HyperLink>
                    </td>

                    <td>
                        <asp:LinkButton ID="Logout" runat="server" causesvalidation="false" OnClick="Logout_Click" >&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Logout</asp:LinkButton>
                    </td>
                </tr>
            </table>
            
         <br /><br /> <br /><br />
        <div>
            <asp:Label ID="lable2" Width="100px" runat="server" Text="Search:" Font-Bold="True" Font-Size="Large"></asp:Label><asp:TextBox width="250px" ID="txtSearch" runat="server"></asp:TextBox>
            <asp:DropDownList ID="SearchList" width="200px" runat="server">
                <asp:ListItem>Email</asp:ListItem>
            </asp:DropDownList><asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
             <br /><br /> <br /><br />
        </div>
        <div>
            <asp:GridView ID="gvAdmin" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvAdmin_SelectedIndexChanged">
            </asp:GridView>
             <br /><br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="First Name:" Width="100px"></asp:Label>
            <asp:TextBox ID="txtFname" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtFname" Display="Static" ErrorMessage="First Name is required." ForeColor="IndianRed" ID="RequiredFieldValidator4" RunAt="server" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Last Name:" Width="100px"></asp:Label>
            <asp:TextBox ID="txtLname" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtLname" Display="Static" ErrorMessage="Last Name is required." ForeColor="IndianRed" ID="RequiredFieldValidator2" RunAt="server" />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Phone Number:" Width="100px"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtPhone" Display="Static" ErrorMessage="Phone is required." ForeColor="IndianRed" ID="RequiredFieldValidator1" RunAt="server" />
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Email:" Width="100px"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtEmail" Display="Static" ErrorMessage="Email is required." ForeColor="IndianRed" ID="RequiredFieldValidator3" RunAt="server" />
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Password:" Width="100px"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtPassword" Display="Static" ErrorMessage="Password is required." ForeColor="IndianRed" ID="RequiredFieldValidator5" RunAt="server" />
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Birth Date:" Width="100px"></asp:Label>
            <asp:TextBox ID="txtDob" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtDob" Display="Static" ErrorMessage="Birth Date is required." ForeColor="IndianRed" ID="RequiredFieldValidator6" RunAt="server" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Gender:" Width="100px"></asp:Label>
            <asp:DropDownList ID="cboGender" runat="server" Width="200px">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>

            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Balance:" Width="100px"></asp:Label>
            <asp:TextBox ID="txtBalance" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtBalance" Display="Static" ErrorMessage="Balance is required." ForeColor="IndianRed" ID="RequiredFieldValidator7" RunAt="server" />
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" Text="User Type:" Width="100px"></asp:Label>
            <asp:DropDownList ID="cboType" Width="200px" runat="server">
                <asp:ListItem>Seller</asp:ListItem>
                <asp:ListItem>User</asp:ListItem>
                <asp:ListItem>Moderator</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="Status:" Width="100px"></asp:Label>
            <asp:DropDownList ID="cboStatus" Width="200px" runat="server">
                <asp:ListItem>Active</asp:ListItem>
                <asp:ListItem>Inactive</asp:ListItem>
                <asp:ListItem>Banned</asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>

        <br />
            <asp:Button ID="Create" runat="server" Text="Create Account" OnClick="Create_Click" />&nbsp &nbsp 
            <asp:Button ID="Update" runat="server" Text="Update Account" OnClick="Update_Click" />&nbsp   &nbsp 
            <asp:Button ID="Delete" runat="server" Text="Delete Account" OnClick="Delete_Click" />&nbsp &nbsp 
            <asp:Button ID="Approve" runat="server" Text="Approve Account" OnClick="Approve_Click" />
        

 

        <br />
        <asp:Label ID="msg" runat="server" ></asp:Label>
    </form>
</body>
</html>
