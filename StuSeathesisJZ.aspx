<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StuSeathesisJZ.aspx.cs" Inherits="StuSeathesisJZ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>学生查询页面</title>
     <link href="loginfont.css" type="text/css" rel="stylesheet"/>
</head>

<body style="margin-top: 0px; margin-bottom: 0px; margin-right:0px; margin-left:0px" class="css">
     <form id="form1" runat="server">
    <div>
    <fieldset style=" border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F;">
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>

    <table>
    <tr>
    
    <td style="width:15%">
        <table style="width: 680px; " border="0" cellpadding="0" cellspacing="0" >
           
           <tr style="height: 8px">
                <td style="width: 100%;">
               
					你好！<%=stuname%>
						
                           
                    </td>
               
            </tr>
           
            <tr >
                <td  style="vertical-align: top; text-align: left;  width:600px;" align="center" >
                
                <asp:DataGrid ID="StuDataGrid1" runat="server" AutoGenerateColumns="False" 
                        BackColor="LightGoldenrodYellow" allowsorting="True" 
                        BorderColor="Tan" BorderWidth="1px" 
                        CellPadding="5" Font-Size="12px"  DataKeyField="ID"
                        HorizontalAlign="Center"  PageSize="15" Width="600px"  AllowPaging="True" 
                        
                        ForeColor="Black" 
                        GridLines="None" >
                        <FooterStyle BackColor="Tan" />
                        <Columns>
                        <asp:BoundColumn DataField="ID" Visible="false"></asp:BoundColumn>
                         <asp:BoundColumn DataField="Stu_No" HeaderText="学生学号">
                                <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                          
                         <asp:BoundColumn DataField="Stu_Name" HeaderText="学生姓名">
                                <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            
                         <asp:BoundColumn DataField="Tea_Name" HeaderText="指导教师姓名">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>  
                                   <asp:BoundColumn DataField="Stu_Istongyi" HeaderText="教师是否同意">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>      
                           
                        </Columns>
                        <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" 
                            Mode="NumericPages" Font-Underline="True" />
                        <HeaderStyle BackColor="Tan" BorderStyle="None" Font-Bold="True" />
                        <AlternatingItemStyle BorderColor="#C0FFFF" BorderWidth="1px" 
                            HorizontalAlign="Left" VerticalAlign="Middle" BackColor="PaleGoldenrod" />
                        <EditItemStyle BorderColor="#C0FFFF" BorderWidth="1px" Height="20px" />
                    </asp:DataGrid>
                
              
                
                    </td>
            </tr>
            
           
              </table>
           
       
    </td></tr></table>
   </fieldset>  </div>
    </form>
    </body>
    </html>