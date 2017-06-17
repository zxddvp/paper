<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeaDabianPingfen.aspx.cs" Inherits="TeaDabianPingfen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>答辩评分</title>
     <link href="loginfont.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset style=" border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F;">
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>
       <table>
    <tr>
    
    <td style=" align="center">
        <table style="width: 680px; " border="0" cellpadding="0" cellspacing="0" class="css">
            
            <tr style="height: 8px">
                <td style="width: 100%; height: 20px">
                <table cellspacing="0"  width="100%" ="center" border="0">
											
												<tr>
													<td align="left">您好！<%=teaname%>，请为在您答辩小组的学生论文评分 ：</td>
												</tr>
				</table>
                    </td>
               
            </tr>
            <tr style="height: 440px">
                <td  style="vertical-align: top; text-align: left; height: 440px; width: 100%;" align="center" >
                <asp:DataGrid ID="gvStuDabian" runat="server" AutoGenerateColumns="False" 
                        BackColor="LightGoldenrodYellow" allowsorting="True" 
                        BorderColor="Tan" BorderWidth="1px" 
                        CellPadding="5" Font-Size="12px"  DataKeyField="ID"
                        HorizontalAlign="Center"  PageSize="15" Width="100%"  AllowPaging="True" 
                        
                        
                        OnPageIndexChanged="gvStuDabian_PageIndexChanged" 
                        onitemcommand="gvStuDabian_ItemCommand" 
                        Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                        Font-Strikeout="False" Font-Underline="False" ForeColor="Black" 
                        GridLines="None">
                        <Columns>
                        <asp:BoundColumn DataField="ID" Visible="false"></asp:BoundColumn>
                       
                            <asp:BoundColumn DataField="Stu_No" HeaderText="学号">
                             <ItemStyle Width ="60px" Wrap="False" />
                                  </asp:BoundColumn>                         
                            <asp:BoundColumn DataField="Stu_Name" HeaderText="姓名">
                                <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                             <asp:BoundColumn DataField="TimuName" HeaderText="论文（设计）题目">
                               <ItemStyle Width ="80px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="dabian_Zong" HeaderText="答辩总分">
                                <ItemStyle Width ="60px" />
                            </asp:BoundColumn>
                           <asp:ButtonColumn   CommandName="Detail" HeaderText = "详细信息" ItemStyle-Width="60px"  Text="详细信息" ItemStyle-ForeColor="HotPink" >
                               <ItemStyle Width ="60px" />
                            </asp:ButtonColumn>
                             
                           
                             <%--<asp:BoundColumn DataField="JiaoTime" HeaderText="教研室审核时间">
                               <ItemStyle Width ="80px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="XiShenhe" HeaderText="院意见">
                                <ItemStyle Width ="60px" />
                            </asp:BoundColumn>--%>
                            
                           <%--<asp:BoundColumn DataField="XiTime" HeaderText="院领导审批时间">
                               <ItemStyle Width ="80px" />
                            </asp:BoundColumn>--%>
                            <%--<asp:ButtonColumn   Visible="false" CommandName="Edit" HeaderText = "编辑" ItemStyle-Width="60px"  Text="编辑"  ItemStyle-ForeColor="HotPink">
                               <ItemStyle Width ="60px" />
                            </asp:ButtonColumn>--%>
                            
                            <%--<asp:ButtonColumn  CommandName="Delete" HeaderText = "删除" ItemStyle-Width="60px"
                                         Text="&lt;div onclick=&quot;return confirm('确认删除该题目吗？')&quot;&gt;删除&lt;/div&gt;" ItemStyle-ForeColor="HotPink" >
                               <ItemStyle Width ="60px" />
                            </asp:ButtonColumn>--%>
                                                     
                            
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
</body>
</html>
