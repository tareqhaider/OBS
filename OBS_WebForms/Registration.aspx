<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="OBS_WebForms.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
</head>
<body>
    <form id="RegistrationForm" runat="server">
    
        <div>
           <table>
               <tr>
                   <td><asp:Label ID="Label1" runat="server" Text="First Name:"></asp:Label></td>
                   <td><asp:TextBox ID="fname" runat="server"></asp:TextBox><br/></td>
                   <td><asp:RequiredFieldValidator ControlToValidate="fname" Display="Static" ErrorMessage="First Name is required." ForeColor="IndianRed" ID="RequiredFieldValidator3" RunAt="server" /></td>
               </tr>

               <tr>
                   <td><asp:Label ID="Label2" runat="server" Text="Last Name:"></asp:Label></td>
                   <td><asp:TextBox ID="lname" runat="server"></asp:TextBox><br/></td>
                   <td><asp:RequiredFieldValidator ControlToValidate="lname" Display="Static" ErrorMessage="Last Name is required." ForeColor="IndianRed" ID="RequiredFieldValidator1" RunAt="server" /></td>
               </tr>

               <%--<tr>
                   <td><asp:Label ID="Label3" runat="server" Text="User Name:"></asp:Label></td>
                   <td><asp:TextBox ID="uname" runat="server"></asp:TextBox><br/></td>
               </tr>--%>

               <tr>
                   <td><asp:Label ID="Label4" runat="server" Text="Password:"></asp:Label></td>
                   <td><asp:TextBox ID="pass" runat="server"></asp:TextBox><br/></td>
                   <td><asp:RequiredFieldValidator ControlToValidate="pass" Display="Static" ErrorMessage="Password is required." ForeColor="IndianRed" ID="RequiredFieldValidator2" RunAt="server" /></td>
               </tr>


               <tr>
                   <td><asp:Label ID="Label5" runat="server" Text="Confirm Password:"></asp:Label></td>
                   <td><asp:TextBox ID="cpass" runat="server"></asp:TextBox></td>
                   <td><asp:RequiredFieldValidator ControlToValidate="cpass" Display="Static" ErrorMessage="Confirm Password." ForeColor="IndianRed" ID="RequiredFieldValidator4" RunAt="server" /></td>
               </tr>


               <tr>
                   <td><asp:Label ID="Label8" runat="server" Text="Gender:"></asp:Label></td>
                   <td>
                       <asp:RadioButtonList ID="genderList" runat="server">
                            <asp:ListItem Text="Male" Value="Male" ></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female" ></asp:ListItem>
                       </asp:RadioButtonList>
                   </td>
                   <td><asp:RequiredFieldValidator ControlToValidate="genderList" Display="Static" ErrorMessage="Select Gender is required." ForeColor="IndianRed" ID="RequiredFieldValidator5" RunAt="server" /></td>
               </tr>

               <tr>
                   <td><asp:Label ID="Label6" runat="server" Text="Phone:"></asp:Label></td>
                   <td><asp:TextBox ID="phone" runat="server"></asp:TextBox><br/></td>
                   <td><asp:RequiredFieldValidator ControlToValidate="phone" Display="Static" ErrorMessage="Phone Number is required." ForeColor="IndianRed" ID="RequiredFieldValidator6" RunAt="server" /></td>
               </tr>

               <tr>
                   <td><asp:Label ID="Label7" runat="server" Text="Email"></asp:Label></td>
                   <td><asp:TextBox ID="email" runat="server"></asp:TextBox><br/></td>
                   <td><asp:RequiredFieldValidator ControlToValidate="email" Display="Static" ErrorMessage="Email is Mandatory." ForeColor="IndianRed" ID="RequiredFieldValidator7" RunAt="server" /></td>
               </tr>

               <tr>
                   <td><asp:Label ID="Label9" runat="server" Text="Date of Birth:"></asp:Label></td>
                   <td>
                       <asp:Label ID="Label12" runat="server" Text="Format:01/01/2000"></asp:Label><br/>
                       <asp:TextBox ID="dob" runat="server"></asp:TextBox>

                   </td>
                   <td><asp:RequiredFieldValidator ControlToValidate="dob" Display="Static" ErrorMessage="Please Enter your Birth Date." ForeColor="IndianRed" ID="RequiredFieldValidator8" RunAt="server" /></td>
               </tr>

               <tr>
                   <td><asp:Label ID="Label10" runat="server" Text="Type:"></asp:Label></td>
                   <td><asp:DropDownList ID="typeList" runat="server">
                       <asp:ListItem>User</asp:ListItem>
                       <asp:ListItem>Seller</asp:ListItem>
                       </asp:DropDownList><br/></td>
                   
               </tr>

               <tr>
                   <td><asp:Button ID="back" Width="125px" runat="server" causesvalidation="false" Text="Back" OnClick="back_Click" /></td>
                   <td><asp:Button ID="register" Width="125px" runat="server" Text="Register" OnClick="register_Click" /></td>
               </tr>
           </table>
        </div>
        <asp:Label ID="msg" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lbl" runat="server" ></asp:Label>
    </form>
</body>
</html>
