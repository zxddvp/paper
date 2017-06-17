<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminStuPJTea.aspx.cs" Inherits="AdminStuPJTea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看学生评价教师的平均分</title>
<link href="loginfont.css" type="text/css" rel="stylesheet"/>
</head>

<body style="margin-top: 0px; margin-bottom: 0px; margin-right:0px; margin-left:0px">
     <form id="form1" runat="server">
    <div>
    <fieldset style=" border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F; width: 690px;" >
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>
   
   
    <table>
    <tr>
    
    <td align="center">
        <table style="width: 680px; " border="0" cellpadding="0" cellspacing="0" class="css">
            
          
            <tr style="height: 440px">
                <td  style="vertical-align: top; text-align: left; height: 440px; width: 100%;" align="center" >
                <asp:DataGrid ID="GVAdminStuPJTea" runat="server" AutoGenerateColumns="False" 
                        BackColor="LightGoldenrodYellow" allowsorting="True" 
                        BorderColor="Tan" BorderWidth="1px" 
                        CellPadding="5" Font-Size="12px"  
                        HorizontalAlign="Center"  PageSize="15" Width="100%"  AllowPaging="True" 
                       
                        
                        OnPageIndexChanged="GVAdminStuPJTea_PageIndexChanged" 
                       
                        Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                        Font-Strikeout="False" Font-Underline="False" ForeColor="Black" 
                        GridLines="None">
                        <Columns>
                        
                       
                            <asp:BoundColumn DataField="Tea_Name" HeaderText="教师姓名">
                             <ItemStyle Width ="200px" Wrap="False" />
                                  </asp:BoundColumn>                         
                             <asp:BoundColumn DataField="PJ_Avg" HeaderText="学生评价平均分">
                             <ItemStyle Width ="200px" Wrap="False" />
                                  </asp:BoundColumn> 
                        </Columns>
                        
                        <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" 
                            Mode="NumericPages" Font-Underline="True" />
                        <HeaderStyle BackColor="Tan" BorderStyle="None" Font-Bold="True" />
                        <AlternatingItemStyle BorderColor="#C0FFFF" BorderWidth="1px" 
                            HorizontalAlign="Left" VerticalAlign="Middle" BackColor="PaleGoldenrod" />
                        <FooterStyle BackColor="Tan" />
                        <EditItemStyle BorderColor="#C0FFFF" BorderWidth="1px" Height="20px" />
                    </asp:DataGrid>
                    </td>
            </tr> </table>
           
       
    </td></tr></table>
    </fieldset>
    </div>
    </form>
    </body></html>