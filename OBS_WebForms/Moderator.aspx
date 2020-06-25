<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Moderator.aspx.cs" Inherits="OBS_WebForms.Moderator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
            <table >
                <tr>
                    <td>
                        <asp:HyperLink ID="Login" NavigateUrl="~/Login.aspx" runat="server">Login</asp:HyperLink>
                        <asp:HyperLink ID="Register" NavigateUrl="~/Registration.aspx" runat="server">	&nbsp Register</asp:HyperLink>
                        <asp:HyperLink ID="Sell" NavigateUrl="~/Sell.aspx" runat="server">	&nbsp Sell</asp:HyperLink>
                        <asp:HyperLink ID="Buy" NavigateUrl="~/Home.aspx" runat="server">	&nbsp Buy</asp:HyperLink>
                    </td>

                    <td>
                        <asp:LinkButton ID="Logout" runat="server" OnClick="Logout_Click" >&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Logout</asp:LinkButton>
                    </td>
                </tr>
            </table>
         <br /><br /> <br /><br />
        <div>
            <asp:Label ID="lable2" Width="100px" runat="server" Text="Search:" Font-Bold="True" Font-Size="Large"></asp:Label><asp:TextBox width="250px" ID="txtSearch" runat="server"></asp:TextBox>
            <asp:DropDownList ID="cboSearchList" width="200px" runat="server">
                <asp:ListItem>All</asp:ListItem>
                <asp:ListItem>Seller</asp:ListItem>
                
            </asp:DropDownList><asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
             <br /><br /> <br />
            <asp:GridView ID="gvModerator" runat="server" AutoGenerateSelectButton="True" DataKeyNames="Id" OnSelectedIndexChanged="gvModerator_SelectedIndexChanged">
            </asp:GridView>
            <br /><br/>
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Book Name:" Width="100px"></asp:Label><asp:TextBox ID="txtBookName" Width="200px" runat="server"></asp:TextBox><br/><br/>
            <asp:Label ID="Label2" runat="server" Text="Author Name:" Width="100px"></asp:Label><asp:TextBox ID="txtAuthor" Width="200px" runat="server"></asp:TextBox><br/><br/>
            <asp:Label ID="Label3" runat="server" Text="Category:" Width="100px"></asp:Label><asp:DropDownList ID="cboCategory" Width="200px" runat="server">
                <asp:ListItem>New</asp:ListItem>
                <asp:ListItem>Used</asp:ListItem>
                <asp:ListItem>Rare</asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList><br/><br/>
            <asp:Label ID="Label4" runat="server" Text="Genre:" Width="100px"></asp:Label><asp:DropDownList ID="cboGenre" Width="200px" runat="server">
                <asp:ListItem>Science</asp:ListItem>
                <asp:ListItem>Technology</asp:ListItem>
                <asp:ListItem>Business</asp:ListItem>
                <asp:ListItem>Novel</asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList><br/><br/>
            <asp:Label ID="Label5" runat="server" Text="Price:" Width="100px"></asp:Label><asp:TextBox ID="txtPrice" Width="200px" runat="server"></asp:TextBox><br/><br/>
            <asp:Label ID="Label8" runat="server" Text="Seller:" Width="100px"></asp:Label><asp:TextBox ID="txtSeller" Width="200px" runat="server"></asp:TextBox><br/><br/>
            <asp:Label ID="Label7" runat="server" Text="Quantity:" Width="100px"></asp:Label><asp:TextBox ID="txtQuantity" Width="200px" runat="server"></asp:TextBox><br/><br/>
            <asp:Label ID="Label6" runat="server" Text="Status:" Width="100px"></asp:Label><asp:DropDownList ID="cboStatus" Width="200px" runat="server">
                <asp:ListItem>Active</asp:ListItem>
                <asp:ListItem>Inactive</asp:ListItem>
            </asp:DropDownList><br/>
        </div>

        
            <br />
            <asp:Button ID="Approve" runat="server" Text="Approve Post" OnClick="Approve_Click" />&nbsp &nbsp 
            <asp:Button ID="Update" runat="server" Text="Update Post" OnClick="Update_Click" />&nbsp   &nbsp 
            <asp:Button ID="Delete" runat="server" Text="Delete Post" OnClick="Delete_Click" />&nbsp &nbsp 
        

            <asp:Label ID="msg" runat="server" ></asp:Label>
        
        


    </form>
</body>
</html>
