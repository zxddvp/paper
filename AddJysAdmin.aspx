<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddJysAdmin.aspx.cs" Inherits="AddJysAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加教研室负责人页面</title>
     <link href="loginfont.css" type="text/css" rel="stylesheet"/>
</head>


<body style="margin-top: 0px; margin-bottom: 0px; margin-right:0px; margin-left:0px" class="css">
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td style="width:25%"></td>
    <td>
        <table style="width: 660px; height: 620px; background-color: #dee9f9;" border="0" cellpadding="0" cellspacing="0" class="css">
           
            <tr style="height: 8px">
                <td style="width: 100%; height: 8px;background-color:royalblue">
                    </td>
               
            </tr>
            <tr style="height: 205px">
                <td colspan="3" style="vertical-align: top; text-align: left; height: 205px; width: 756px;">
                  
                    <table style="width: 660px">
                    <tr>
                    <td style="width:27%; height: 63px;">
                        <asp:Label ID="Label5" runat="server" Text="教研室名称："></asp:Label>
                        <asp:TextBox ID="jysnameTBox" runat="server" Width="160px" Enabled="true"></asp:TextBox></td>
                    </tr>
                    
                    <tr>
                    
                    <td style="width:23%; height: 63px;"> <asp:Label ID="Label4" runat="server" Text="负责教师号："></asp:Label>
                        <asp:TextBox ID="AdminnoTBox" runat="server" Width="161px"></asp:TextBox></td>
                    
                   
                    </tr>
                    <tr>
                    <td style="width:25%; height: 63px;">
                        <asp:Label ID="Label6" runat="server" Text="负责人姓名："></asp:Label>
                        <asp:TextBox ID="teaNameTBox" runat="server" Width="160px"></asp:TextBox></td></tr></table>
                  
                    <table>
                      <tr align="center">
                      <td style="width:180px; height: 20px;" ></td>
                      <td style="width:180px; height: 20px;" align="right" >
                         <asp:Button ID="ReBT" runat="server" Text="返  回" BackColor="SteelBlue" ForeColor="White" OnClick="ReBT_Click"  /></td>
                    <td style="width:150px; height: 20px;" align="right" >
                        <asp:Button ID="SendBT" runat="server" Text="确　定" BackColor="SteelBlue" ForeColor="White" OnClick="SendBT_Click" /></td>
                   
                    <td style="width:150px; height: 20px;" align="center">
                        <asp:Button ID="ResetBT" runat="server" Text="重　置" BackColor="SteelBlue" ForeColor="White" OnClick="ResetBT_Click" /></td>
                   
                    </tr>
                    
                    </table>
                </td>
            </tr>
            <tr style="height: 4px">
                <td style="width: 100%; height: 4px;background-color:royalblue">
                    </td>
               
            </tr>
              </table>
           
       
    </td></tr></table>
    </div>
    </form>
</body>
</html>
