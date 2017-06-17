<%@ Page Language ="C#" AutoEventWireup="true" CodeFile="TeaSearch.aspx.cs" Inherits="TeaSearch" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>教师查询页面</title>
     <link href="loginfont.css" type="text/css" rel="stylesheet"/>
</head>

<body style="margin-top: 0px; margin-bottom: 0px; margin-right:0px; margin-left:0px">
     <form id="form1" runat="server">
    <div>
    <fieldset style=" border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F; width: 690px;" >
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>
   
   
    <table>
    <tr>
    
    <td style=" align="center">
        <table style="width: 680px; " border="0" cellpadding="0" cellspacing="0" class="css">
            
            <tr style="height: 8px">
                <td style="width: 100%; height: 20px">
                <table cellspacing="0"  width="100%" ="center" border="0">
											
												<tr>
													<td align="left">你好！<%=teaname%>，你提交的论文题目有 ：</td>
												</tr>
				</table>
                    </td>
               
            </tr>
            <tr style="height: 440px">
                <td  style="vertical-align: top; text-align: left; height: 440px; width: 100%;" align="center" >
                <asp:DataGrid ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        BackColor="LightGoldenrodYellow" allowsorting="True" 
                        BorderColor="Tan" BorderWidth="1px" 
                        CellPadding="5" Font-Size="12px"  DataKeyField="ID"
                        HorizontalAlign="Center"  PageSize="15" Width="100%"  AllowPaging="True" 
                        OnDeleteCommand="GridView2_DeleteCommand" 
                        
                        OnPageIndexChanged="GridView2_PageIndexChanged" 
                        onitemcommand="GridView2_ItemCommand" 
                        Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                        Font-Strikeout="False" Font-Underline="False" ForeColor="Black" 
                        GridLines="None">
                        <Columns>
                        <asp:BoundColumn DataField="ID" Visible="false"></asp:BoundColumn>
                       
                            <asp:BoundColumn DataField="TimuName" HeaderText="题目名称">
                             <ItemStyle Width ="200px" Wrap="False" />
                                  </asp:BoundColumn>                         
                             <%--<asp:BoundColumn DataField="TL_Name" HeaderText="题目来源">
                                <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TT_Name" HeaderText="课题类型">
                               <ItemStyle Width ="80px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ZA_Name" HeaderText="专业方向">
                                <ItemStyle Width ="80px" />
                            </asp:BoundColumn>
                           <asp:BoundColumn DataField="Jys_Name" HeaderText="所属教研室">
                                <ItemStyle Width ="80px" />
                            </asp:BoundColumn>--%>
                           <asp:ButtonColumn   CommandName="Detail" HeaderText = "详细信息" ItemStyle-Width="60px"  Text="详细信息" ItemStyle-ForeColor="HotPink" >
                               <ItemStyle Width ="60px" />
                            </asp:ButtonColumn>
                             
                            <asp:BoundColumn DataField="JiaoyanshiFirst" HeaderText="教研室意见">
                               <ItemStyle Width ="60px" />
                            </asp:BoundColumn>
                             <%--<asp:BoundColumn DataField="JiaoTime" HeaderText="教研室审核时间">
                               <ItemStyle Width ="80px" />
                            </asp:BoundColumn>--%>
                            <asp:BoundColumn DataField="XiShenhe" HeaderText="院审核结果">
                                <ItemStyle Width ="60px" />
                            </asp:BoundColumn>
                              <asp:BoundColumn DataField="XiSuggest" HeaderText="院更改建议">
                                <ItemStyle Width ="60px" />
                            </asp:BoundColumn>
                           <%--<asp:BoundColumn DataField="XiTime" HeaderText="院领导审批时间">
                               <ItemStyle Width ="80px" />
                            </asp:BoundColumn>--%>
                            <asp:ButtonColumn   Visible="false" CommandName="Edit" HeaderText = "编辑" ItemStyle-Width="60px"  Text="编辑"  ItemStyle-ForeColor="HotPink">
                               <ItemStyle Width ="60px" />
                            </asp:ButtonColumn>
                            
                            <asp:ButtonColumn  CommandName="Delete" HeaderText = "删除" ItemStyle-Width="60px"
                                         Text="&lt;div onclick=&quot;return confirm('确认删除该题目吗？')&quot;&gt;删除&lt;/div&gt;" ItemStyle-ForeColor="HotPink" >
                               <ItemStyle Width ="60px" />
                            </asp:ButtonColumn>
                                                     
                            
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
<%--</asp:Content>--%>