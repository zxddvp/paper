<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XiLeader.aspx.cs" Inherits="XiLeader"  %>
<script src="js/common.js" type="text/jscript"></script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ժ�쵼����ҳ��</title>
   
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
                      &nbsp;&nbsp;&nbsp;��ã�<%=xlname%>������˵�������Ŀ�У�
                      <asp:Label ID="Label2" ForeColor ="Red" Text="�����������Խ�������" runat ="server" ></asp:Label>
                       <span id="OutputMsg" EnableViewState="false" runat="server"/>
				</td></tr>
				<tr>
   
    <td style="width:50%" align="center">
        <table style="width:680px; " border="0" cellpadding="0" cellspacing="0" >
           
           
            <tr><td align ="left" style=" height:20px; width:680px;">
                <asp:Button ID="allowAllTimuBT" runat="server" BackColor="#FFFF99" 
                    BorderColor="#0066FF" onclick="allowAllTimuBT_Click" Text="ͬ������������Ŀ" />
                
              <asp:Button Text="ͬ��ѡ�е�������Ŀ" BackColor="#FFFF99" 
                    BorderColor="#0066FF" OnClick="ShenheAllSel" ID="Confirm" runat="server" />
               
					<asp:Button ID="Button1" runat="server" BackColor="#FFFF99" 
                    BorderColor="#0066FF" OnClick="Button1_Click" Text="�޸�����" />
					<%--<asp:Button id="LinkButton1" onclick="LinkButton1_Click" runat="server" Text="��  ��" BackColor="#FFFF99" 
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
                      <asp:ListItem>ͬ��</asp:ListItem>
                      <asp:ListItem>��ͬ��</asp:ListItem>
                       
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
                       <%-- <asp:BoundColumn DataField="Tea_Name" HeaderText="��ʦ����" ReadOnly="True" SortExpression="Tea_Name" >
                             <ItemStyle Width ="45px" />
                                  </asp:BoundColumn>     --%>
                             <asp:BoundColumn DataField="TimuName" HeaderText="��Ŀ����" ReadOnly="True" >
                             <ItemStyle Width ="200px" />
                                  </asp:BoundColumn>                         
                           <%-- <asp:BoundColumn DataField="TL_Name" HeaderText="��Ŀ��Դ" ReadOnly="True" SortExpression="TL_Name">
                                <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TT_Name" HeaderText="��������" ReadOnly="True" SortExpression="TT_Name">
                               <ItemStyle Width ="80px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ZA_Name" HeaderText="רҵ����" ReadOnly="True" SortExpression="ZA_Name">
                                <ItemStyle Width ="80px" />
                            </asp:BoundColumn>--%>
                            <asp:ButtonColumn  CommandName="Detail" HeaderText = "��ϸ��Ϣ" ItemStyle-Width="60px"  Text="��ϸ��Ϣ" ItemStyle-ForeColor="HotPink" >
                               <ItemStyle Width ="60px" />
                            </asp:ButtonColumn>
                             <asp:BoundColumn DataField="XiShenhe" HeaderText="Ժ���" ReadOnly="True"  SortExpression="XiShenhe">
                             <ItemStyle Width ="200px" />
                                  </asp:BoundColumn>         
                          <%--  <asp:BoundColumn DataField="JiaoyanshiFirst" HeaderText="�����ҳ������" ReadOnly="True">
                                <ItemStyle Width ="80px" />
                            </asp:BoundColumn>--%>
                             <asp:ButtonColumn  CommandName="Shenhe" HeaderText = "�������" ItemStyle-Width="60px"  Text="���" ItemStyle-ForeColor="Blue" >
                               <ItemStyle Width ="60px" />
                            </asp:ButtonColumn>
                            
                             <%-- <asp:TemplateColumn ItemStyle-Width ="50px" HeaderText="Ժ���" SortExpression="XiShenhe">
                                 
                                  <ItemTemplate>
                                   <asp:Label ID="xshlbl" Text='<%# DataBinder.Eval(Container.DataItem, "XiShenhe") %>' runat="server"/>
                                  
                                  </ItemTemplate>
                                   <EditItemTemplate>
                                  <asp:DropDownList ID="ddl"   runat="server">
                      <asp:ListItem>ͬ��</asp:ListItem>
                      <asp:ListItem>��ͬ��</asp:ListItem>
                       
                  </asp:DropDownList>
                                           </EditItemTemplate>

                                        
                                  </asp:TemplateColumn>  --%>
                            <%-- <asp:BoundColumn DataField="ShenbaoTime" HeaderText="�걨ʱ��" ReadOnly="True">
                               <ItemStyle Width ="60px" />
                            </asp:BoundColumn>--%>
                           
                          <%--  <asp:EditCommandColumn  EditText="���" UpdateText="ȷ��"  HeaderText = "�������" CancelText = "ȡ��" ItemStyle-ForeColor="HotPink"> <ItemStyle Width ="50px" /></asp:EditCommandColumn>--%>
                         
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

   


