<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="JysShenhe.aspx.cs" Inherits="JysShenhe" %>
<%--
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <form id="form1" runat="server">      
    <div>--%>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>学生选题页面</title>
     <link href="loginfont.css" type="text/css" rel="stylesheet"/>
</head>

<body style="margin-top: 0px; margin-bottom: 0px; margin-right:0px; margin-left:0px" class="css">
     <form id="form1" runat="server">
    <div>
    <fieldset style=" border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F;">
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>
    <table>
    <tr>
   
    <td style="width:50%" align="center">
        <table style="width: 760px; height: 550px;" border="0" cellpadding="0" cellspacing="0" class="css">
            
            <tr style="height: 8px">
                <td style="width: 100%; height: 20px">
               你好！<%=jysadmin%>，你审核的论文题目有 ：<asp:Label ID="Label2" ForeColor ="Red" Text="点击表格标题可以进行排序" runat ="server" ></asp:Label>
                    </td>
               
            </tr>
            <tr style="height: 440px">
                <td  style="vertical-align: top; text-align: left; height: 440px; width: 760px;" align="center" >
                <asp:DataGrid ID="JysShen" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" allowsorting="True" 
                        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
                        CellPadding="4" Font-Size="12px"  DataKeyField="ID"
                        HorizontalAlign="Center"  PageSize="30" Width="760px"  AllowPaging="True" 
                        OnPageIndexChanged="JysShen_PageIndexChanged" 
                        OnEditCommand="JysShen_EditCommand" OnUpdateCommand="JysShen_UpdateCommand" 
                        OnCancelCommand="JysShen_CancelCommand" 
                        OnItemCommand="JysShen_ItemCommand" CellSpacing="2" 
                        onsortcommand="JysShen_SortCommand">
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <ItemStyle BackColor="White" ForeColor="#333333" />
                        <Columns>
                        <asp:BoundColumn DataField="ID" Visible="False"></asp:BoundColumn>
                        <%--<asp:BoundColumn DataField="Tea_Name" HeaderText="教师姓名" ReadOnly="True" SortExpression="Tea_Name">
                             <ItemStyle Width ="40px" />
                                  </asp:BoundColumn>    --%> 
                             <asp:BoundColumn DataField="TimuName" HeaderText="题目名称" ReadOnly="True">
                             <ItemStyle Width ="220px" />
                                  </asp:BoundColumn>                         
                            <%--<asp:BoundColumn DataField="TL_Name" HeaderText="题目来源" ReadOnly="True" SortExpression="TL_Name">
                                <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TT_Name" HeaderText="课题类型" ReadOnly="True" SortExpression="TT_Name">
                               <ItemStyle Width ="75px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ZA_Name" HeaderText="专业方向" ReadOnly="True" SortExpression="ZA_Name">
                                <ItemStyle Width ="80px" />
                            </asp:BoundColumn>--%>
                            <asp:ButtonColumn  CommandName="Detail" HeaderText = "详细信息" ItemStyle-Width="60px"  Text="详细信息" ItemStyle-ForeColor="HotPink" >
                               <ItemStyle Width ="60px" />
                            </asp:ButtonColumn>
                            
                             <asp:TemplateColumn ItemStyle-Width ="60px" HeaderText="教研室意见" SortExpression="JiaoyanshiFirst">
                                  <ItemTemplate>
                                   <asp:Label ID="jyslbl" Text='<%# DataBinder.Eval(Container.DataItem, "JiaoyanshiFirst") %>' runat="server"/>
                                  
                                  </ItemTemplate>
                                   <EditItemTemplate>
                                  <asp:DropDownList ID="ddl" runat="server">
                      <asp:ListItem>同意</asp:ListItem>
                      <asp:ListItem>不同意</asp:ListItem></asp:DropDownList>
                                           </EditItemTemplate>

                                         
                                  </asp:TemplateColumn>  
                                  
                           

                           
                            <asp:BoundColumn DataField="XiShenhe" HeaderText="系审核意见" ReadOnly="True">
                                <ItemStyle Width ="60px" />
                            </asp:BoundColumn>
                             <%--<asp:BoundColumn DataField="ShenbaoTime" HeaderText="申报时间" ReadOnly="True">
                               <ItemStyle Width ="60px" />
                            </asp:BoundColumn>--%>
                           
                            <asp:EditCommandColumn  EditText="审核" UpdateText="审核确定"  HeaderText = "审核论文" CancelText = "取消" ItemStyle-ForeColor="HotPink"> <ItemStyle Width ="60px"  /></asp:EditCommandColumn>
                         
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
            
              </table>
           
       
    </td></tr></table>
    </fieldset>
    
    </div>
    </form>
    </body></html>
<%--</asp:Content>--%>