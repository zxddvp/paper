<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Superuser.aspx.cs" Inherits="Superuser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>管理教研室负责人页面</title>
         <link href="loginfont.css" type="text/css" rel="stylesheet"/>
</head>

<body style="margin-top: 0px; margin-bottom: 0px; margin-right:0px; margin-left:0px">
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td style="width:35%"></td>
    <td>
        <table style="width: 460px; height: 550px; background-color: #dee9f9;" border="0" cellpadding="0" cellspacing="0" class="css">
            <tr >
                <td style="height: 15px" >
                    <!-- 新闻顶部 //-->
			     
                </td>
            </tr>
            <tr style="height: 8px">
                <td style="width: 100%; height: 20px">
                    <asp:Button ID="Button1" runat="server" BorderColor="Blue" OnClick="Button1_Click"
                        Text="添  加" /><asp:Button ID="Button2" runat="server" BackColor="White" BorderColor="#FFFFC0" ForeColor="DarkRed" OnClick="GaiPsw_Click" Text="修改密码" /></td>
               
            </tr>
            <tr style="height: 440px">
                <td  style="vertical-align: top; text-align: left; height: 440px; width: 460px;" align="center" >
                <asp:DataGrid ID="JysDg" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" allowsorting="True" 
                        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
                        CellPadding="4" Font-Size="12px"  DataKeyField="Jys_No"
                        HorizontalAlign="Center"  PageSize="8" Width="460px"  AllowPaging="True" 
                        OnDeleteCommand="JysDg_DeleteCommand" CellSpacing="2" Font-Bold="False" 
                        Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                        Font-Underline="False" >
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <ItemStyle BackColor="White" ForeColor="#333333" />
                        <Columns>
                        <asp:BoundColumn DataField="Jys_No" HeaderText="教研室ID号" Visible="True"><ItemStyle Width ="90px" /></asp:BoundColumn>
                        <asp:BoundColumn DataField="Jys_Name" HeaderText="教研室名称" ReadOnly="True">
                             <ItemStyle Width ="90px" />
                                  </asp:BoundColumn>     
                             <asp:BoundColumn DataField="Jys_Admin" HeaderText="教研室负责人" ReadOnly="True">
                             <ItemStyle Width ="90px" />
                                  </asp:BoundColumn>                         
                            <asp:BoundColumn DataField="Tea_No" HeaderText="负责人教师号" ReadOnly="True">
                                <ItemStyle Width ="90px" />
                            </asp:BoundColumn>
                            

                           
                            <asp:ButtonColumn  CommandName="Delete" Text="&lt;div onclick=&quot;return confirm('确认删除该题目吗？')&quot;&gt;删除&lt;/div&gt;" HeaderText = "删除负责人" > <ItemStyle Width ="90px" /></asp:ButtonColumn>
                         
                

                         
                                                     
                            
                        </Columns>
                        
                        <SelectedItemStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" 
                            Mode="NumericPages" Font-Bold="False" Font-Italic="False" 
                            Font-Overline="False" Font-Strikeout="False" Font-Underline="True" 
                            Position="TopAndBottom" />
                        <HeaderStyle BackColor="#336666" BorderStyle="None" Font-Bold="True" 
                            ForeColor="White" />
                        <AlternatingItemStyle BorderColor="#C0FFFF" BorderWidth="1px" 
                            HorizontalAlign="Left" VerticalAlign="Middle" />
                        <EditItemStyle  BorderColor="#C0FFFF" BorderWidth="1px" Height="20px" 
                            Width="40px" Wrap="True" />
                    </asp:DataGrid>
                    </td>
            </tr>
            <tr>
                <td style="width: 100%; height: 21px;" align="right">
                    &nbsp;
                    </td>
               
            </tr>
            <tr style="height: 4px">
                <td style="width: 100%; height: 4px;background-color:#003333">
                    </td>
               
            </tr>
              </table>
           
       
    </td></tr></table>
    </div>
    </form>
</body>
</html>
