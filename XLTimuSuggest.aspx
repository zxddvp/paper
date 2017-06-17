<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XLTimuSuggest.aspx.cs" Inherits="XLTimuSuggest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>领导审核教师题目</title>
    <link href="loginfont.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form2" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;审核结果：</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DDLShhTeaBMess" runat="server" BackColor="#FFEBCD" 
                        Height="16px" Width="136px">
                        <asp:ListItem>— —请选择— —</asp:ListItem>
                        <asp:ListItem>同意</asp:ListItem>
                        <asp:ListItem>不同意</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;具体意见：</td>
                <td>
                    <asp:TextBox ID="TBoxSuggest" TextMode="MultiLine" Height="100px"  
                        runat="server" Width="413px" BackColor="#FFEBCD"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BTSuggest" Visible="true"  runat="server" Text="确  定" 
                        onclick="BTSuggest_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>