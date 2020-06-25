<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OBS_WebForms.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Book Store</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table >
                <tr>
                    <td>
                        <asp:HyperLink ID="Login" NavigateUrl="~/Login.aspx" runat="server">Login</asp:HyperLink>
                        <asp:HyperLink ID="Register" NavigateUrl="~/Registration.aspx" runat="server">	&nbsp Register</asp:HyperLink>
                        <asp:HyperLink ID="Sell" NavigateUrl="~/Sell.aspx" runat="server">	&nbsp Sell</asp:HyperLink>
                        <asp:HyperLink ID="Buy" NavigateUrl="~/Home.aspx" runat="server">	&nbsp Buy</asp:HyperLink>
                    </td>

                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" onclick="Logout_Click">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Logout</asp:LinkButton>
                    </td>
                </tr>
            </table>
            <br /><br /><br /><br />
        </div>

        <div>
            <asp:Label ID="lable2" Width="100px" runat="server" Text="Search:" Font-Bold="True" Font-Size="Large"></asp:Label><asp:TextBox width="250px" ID="search" runat="server"></asp:TextBox>
            <asp:DropDownList ID="SearchList" width="200px" runat="server">
                <asp:ListItem Value="2">Search By Book Name</asp:ListItem>
                <asp:ListItem Value="1">Search By Book ID</asp:ListItem>
                <asp:ListItem Value="3">Search By Author</asp:ListItem>
            </asp:DropDownList><asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
            
            
           
            <br/>
            <br/>
        </div>
        <div id="abc">
             <asp:DetailsView ID="dvHome" runat="server" Height="50px" Width="125px">
            </asp:DetailsView>

            <br />
            <br />
            <br />
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Quantity" Font-Size="Large"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" Width="29px"></asp:TextBox>
                        <asp:Button ID="sub" runat="server" Text="-" Width="30px" OnClick="sub_Click" />
                        <asp:Button ID="add" runat="server" Text="+" Width="62px" OnClick="add_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="order" runat="server" Width="128px" Text="Order" OnClick="order_Click" />
                    </td>
                </tr>
            </table>


            <asp:Label ID="msg" runat="server" ></asp:Label>


            <br />

        </div>

        <div>
            <br/><br/><br/>
            <asp:GridView ID="GridView1" Width="50%" runat="server" AutoGenerateSelectButton="True" DataKeyNames="Id" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
        </div>
        

        
    </form>
</body>
</html>
