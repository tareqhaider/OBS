<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sell.aspx.cs" Inherits="OBS_WebForms.Sell" %>

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
                        <asp:HyperLink ID="Login" NavigateUrl="~/Login.aspx" runat="server">Login</asp:HyperLink>
                        <asp:HyperLink ID="Register" NavigateUrl="~/Registration.aspx" runat="server">	&nbsp Register</asp:HyperLink>
                        <asp:HyperLink ID="nSell" NavigateUrl="~/Sell.aspx" runat="server">	&nbsp Sell</asp:HyperLink>
                        <asp:HyperLink ID="Buy" NavigateUrl="~/Home.aspx" runat="server">	&nbsp Buy</asp:HyperLink>
                    </td>

                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" causesvalidation="false" onclick="Logout_Click">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Logout</asp:LinkButton>
                    </td>
                </tr>
            </table>
            <br /><br /><br /><br />
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Book Name:"></asp:Label>
                    </td>

                    <td>
                        <asp:TextBox ID="bname" runat="server"></asp:TextBox>
                    </td>

                    <td>
                        <asp:RequiredFieldValidator ControlToValidate="bname" Display="Static" ErrorMessage="Book Name is required." ForeColor="IndianRed" ID="validator_bname" RunAt="server" />
                    </td>

                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Author Name:"></asp:Label>
                    </td>

                    <td>
                        <asp:TextBox ID="author" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ControlToValidate="author" Display="Static" ErrorMessage="Author Name is required." ForeColor="IndianRed" ID="RequiredFieldValidator1" RunAt="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Category:"></asp:Label>
                    </td>

                    <td>
                        <asp:DropDownList ID="category" runat="server">
                            <asp:ListItem>New</asp:ListItem>
                            <asp:ListItem>Used</asp:ListItem>
                            <asp:ListItem>Rare</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Genre:"></asp:Label>
                    </td>

                    <td>
                        <asp:DropDownList ID="genre" runat="server">
                            <asp:ListItem>Science</asp:ListItem>
                            <asp:ListItem>Technology</asp:ListItem>
                            <asp:ListItem>Programming</asp:ListItem>
                            <asp:ListItem>Business</asp:ListItem>
                            <asp:ListItem>Novel</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Price:"></asp:Label>
                    </td>

                    <td>
                        <asp:TextBox ID="price" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ControlToValidate="price" Display="Static" ErrorMessage="Price is required." ForeColor="IndianRed" ID="RequiredFieldValidator2" RunAt="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Quantity:"></asp:Label>
                    </td>

                    <td>
                        <asp:TextBox ID="quantity" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ControlToValidate="quantity" Display="Static" ErrorMessage="Quantity available is required." ForeColor="IndianRed" ID="RequiredFieldValidator3" RunAt="server" />
                    </td>
                </tr>
                
                <tr>
                    <td>
                        
                    </td>

                    <td>
                        <asp:Button ID="back" runat="server" Text="Back" causesvalidation="false" OnClick="back_Click" />
                        <asp:Button ID="confirm" runat="server" Text="Confirm" OnClick="confirm_Click" />
                        <asp:Button ID="update" runat="server" Text="Update" OnClick="update_Click" />
                    </td>
                    <td>
                        
                    </td>
                </tr>

            </table>
        </div>
        <br /><br /><br /><br />
        <div>
            <asp:GridView ID="gvSell" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvSell_SelectedIndexChanged1">
            </asp:GridView>
        </div>
        <br /><br /><br /><br />

        <div id="Seller">
            <br />
        </div>
        <asp:Label ID="msg" runat="server"></asp:Label>
    </form>

</body>
</html>
