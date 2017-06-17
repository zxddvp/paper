<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XiLeader.aspx.cs" Inherits="XiLeader"  %>
<script src="js/common.js" type="text/jscript"></script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>院领导审批页面</title>
   
   <link href="loginfont.css" type="text/css" rel="stylesheet"/>

<%--<link href="CSS/css.css" rel="stylesheet" type="text/css" />
--%>  
</head>
<body>
 <form id="form1" runat="server">
    <fieldset style=" width:680px; border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F;">
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>
     <table style="width:580px; height:299px;" border="0" cellpadding="0" cellspacing="0">
         <tr>
                <td>
                  <table width="420" border="0" align="center">
                 <tr><td> 
                      &nbsp;&nbsp;&nbsp;你好！<%=xlname%>，你审核的论文题目有：
                      <asp:Label ID="Label2" ForeColor ="Red" Text="点击表格标题可以进行排序" runat ="server" ></asp:Label>
                       <span id="OutputMsg" EnableViewState="false" runat="server"/>
				</td></tr>
				<tr>
   
    <td style="width:50%" align="center">
        <table style="width:680px; " border="0" cellpadding="0" cellspacing="0" >
           
           
            <tr><td align ="left" style=" height:20px; width:680px;">
                <asp:Button ID="allowAllTimuBT" runat="server" BackColor="#FFFF99" 
                    BorderColor="#0066FF" onclick="allowAllTimuBT_Click" Text="同意所有论文题目" />
                
              <asp:Button Text="同意选中的论文题目" BackColor="#FFFF99" 
                    BorderColor="#0066FF" OnClick="ShenheAllSel" ID="Confirm" runat="server" />
               
					<asp:Button ID="Button1" runat="server" BackColor="#FFFF99" 
                    BorderColor="#0066FF" OnClick="Button1_Click" Text="修改密码" />
					<%--<asp:Button id="LinkButton1" onclick="LinkButton1_Click" runat="server" Text="退  出" BackColor="#FFFF99" 
                    BorderColor="#0066FF"></asp:Button>--%>
					</td></tr>
            <tr >
                <td  style="vertical-align: top; text-align: left; width: 680px;" align="center" >
                <asp:DataGrid ID="XiShen" runat="server" AutoGenerateColumns="False" 
                        BackColor="LightGoldenrodYellow" allowsorting="True" 
                        BorderColor="Tan" BorderWidth="1px" 
                        CellPadding="2" Font-Size="12px"  DataKeyField="ID"
                        HorizontalAlign="Center"  PageSize="30" Width="680px"  AllowPaging="True" 
                        OnCancelCommand="XiShen_CancelCommand" OnEditCommand="XiShen_EditCommand" 
                        OnPageIndexChanged="XiShen_PageIndexChanged" 
                        OnUpdateCommand="XiShen_UpdateCommand" OnItemCommand="XiShen_ItemCommand" 
                        onsortcommand="XiShen_SortCommand" ForeColor="Black" GridLines="None"    >
                        <FooterStyle BackColor="Tan" />
                        <Columns>
                        
                        <asp:TemplateColumn>
                            <HeaderTemplate>
                                 <font face="Webdings" color="white" size="4">a</font> <asp:CheckBox ID="CheckAll" OnClick="javascript: return select_deselectAll (this.checked, this.id);" runat="server" Visible="false"/>
                            </HeaderTemplate>

                            <ItemTemplate>
                                 <asp:CheckBox ID="DeleteThis" OnClick="javascript: return select_deselectAll (this.checked, this.id);" runat="server"/>
                            </ItemTemplate>
                            <ItemStyle Width ="40px" />
                            </asp:TemplateColumn>
                            
                            <asp:TemplateColumn Visible="false">

                            <HeaderTemplate><b>ID</b></HeaderTemplate>

                                <EditItemTemplate>
                                  <%--<asp:DropDownList ID="ddl"   runat="server">
                      <asp:ListItem>同意</asp:ListItem>
                      <asp:ListItem>不同意</asp:ListItem>
                       
                  </asp:DropDownList>--%>
                                           
</EditItemTemplate>

                            <ItemTemplate>
                                 <asp:Label ID="ID"
                                     Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                      runat="server"/>
                            </ItemTemplate>

<ItemStyle Width="40px"></ItemStyle>

                            </asp:TemplateColumn> 



                        <%--<asp:BoundColumn DataField="ID" Visible="False"></asp:BoundColumn>--%>
                       <%-- <asp:BoundColumn DataField="Tea_Name" HeaderText="教师姓名" ReadOnly="True" SortExpression="Tea_Name" >
                             <ItemStyle Width ="45px" />
                                  </asp:BoundColumn>     --%>
                             <asp:BoundColumn DataField="TimuName" HeaderText="题目名称" ReadOnly="True" >
                             <ItemStyle Width ="200px" />
                                  </asp:BoundColumn>                         
                           <%-- <asp:BoundColumn DataField="TL_Name" HeaderText="题目来源" ReadOnly="True" SortExpression="TL_Name">
                                <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TT_Name" HeaderText="课题类型" ReadOnly="True" SortExpression="TT_Name">
                               <ItemStyle Width ="80px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ZA_Name" HeaderText="专业方向" ReadOnly="True" SortExpression="ZA_Name">
                                <ItemStyle Width ="80px" />
                            </asp:BoundColumn>--%>
                            <asp:ButtonColumn  CommandName="Detail" HeaderText = "详细信息" ItemStyle-Width="60px"  Text="详细信息" ItemStyle-ForeColor="HotPink" >
                               <ItemStyle Width ="60px" />
                            </asp:ButtonColumn>
                             <asp:BoundColumn DataField="XiShenhe" HeaderText="院意见" ReadOnly="True"  SortExpression="XiShenhe">
                             <ItemStyle Width ="200px" />
                                  </asp:BoundColumn>         
                          <%--  <asp:BoundColumn DataField="JiaoyanshiFirst" HeaderText="教研室初审意见" ReadOnly="True">
                                <ItemStyle Width ="80px" />
                            </asp:BoundColumn>--%>
                             <asp:ButtonColumn  CommandName="Shenhe" HeaderText = "审核论文" ItemStyle-Width="60px"  Text="审核" ItemStyle-ForeColor="Blue" >
                               <ItemStyle Width ="60px" />
                            </asp:ButtonColumn>
                            
                             <%-- <asp:TemplateColumn ItemStyle-Width ="50px" HeaderText="院意见" SortExpression="XiShenhe">
                                 
                                  <ItemTemplate>
                                   <asp:Label ID="xshlbl" Text='<%# DataBinder.Eval(Container.DataItem, "XiShenhe") %>' runat="server"/>
                                  
                                  </ItemTemplate>
                                   <EditItemTemplate>
                                  <asp:DropDownList ID="ddl"   runat="server">
                      <asp:ListItem>同意</asp:ListItem>
                      <asp:ListItem>不同意</asp:ListItem>
                       
                  </asp:DropDownList>
                                           </EditItemTemplate>

                                        
                                  </asp:TemplateColumn>  --%>
                            <%-- <asp:BoundColumn DataField="ShenbaoTime" HeaderText="申报时间" ReadOnly="True">
                               <ItemStyle Width ="60px" />
                            </asp:BoundColumn>--%>
                           
                          <%--  <asp:EditCommandColumn  EditText="审核" UpdateText="确定"  HeaderText = "审核论文" CancelText = "取消" ItemStyle-ForeColor="HotPink"> <ItemStyle Width ="50px" /></asp:EditCommandColumn>--%>
                         
                        </Columns>
                        
                        <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" 
                            Mode="NumericPages" Font-Underline="True" />
                        <HeaderStyle BackColor="Tan" BorderStyle="None" Font-Bold="True" 
                            HorizontalAlign="Left" />
                        <AlternatingItemStyle BorderColor="#C0FFFF" BorderWidth="1px" 
                            HorizontalAlign="Left" VerticalAlign="Middle" BackColor="PaleGoldenrod" />
                        <EditItemStyle  BorderColor="#C0FFFF" BorderWidth="1px" Height="20px" 
                            Width="40px" Wrap="True" />
                    </asp:DataGrid>
                    </td>
            </tr>
           
            
              </table>
           
       
    </td></tr></table>
     </fieldset> 
   </form>
</body>
</html>

   


