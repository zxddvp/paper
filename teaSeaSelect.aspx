<%@ Page Language="C#" AutoEventWireup="true" CodeFile="teaSeaSelect.aspx.cs" Inherits="teaSeaSelect"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>教师查看被选题目页面</title>
     <link href="loginfont.css" type="text/css" rel="stylesheet"/>
</head>

<body style="margin-top: 0px; margin-bottom: 0px; margin-right:0px; margin-left:0px" >
     <form id="form1" runat="server">
    <div>
    <fieldset style=" border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F;">
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>
   
    <table>
    <tr>
    
    <td>
        <table style="width: 520px; " border="0" cellpadding="0" cellspacing="0" class="css">
           <tr style="height: 20px">
                <td style="width: 100%; height: 20px" align="left">
              
				你好！<%=teaname%>，选择你论文题目的学生有：</td>
               
            </tr>
           
            <tr style="height: 440px">
                <td  style="vertical-align: top; text-align: left; width: 680px;" align="center" >
                <asp:DataGrid ID="DgTeaStu" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" allowsorting="True" 
                        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="5" Font-Size="12px"  DataKeyField="Stu_No"
                        HorizontalAlign="Center"  PageSize="15" Width="680px"  AllowPaging="True" 
                        OnPageIndexChanged="DgTeaStu_PageIndexChanged" GridLines="Horizontal" 
                        onitemcommand="DgTeaStu_ItemCommand" 
                        oncancelcommand="DgTeaStu_CancelCommand" oneditcommand="DgTeaStu_EditCommand" 
                        onupdatecommand="DgTeaStu_UpdateCommand" >
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <Columns>
                       
                             <asp:BoundColumn DataField="TimuName" HeaderText="题目名称" ReadOnly="true">
                             <ItemStyle Width ="200px" />
                                  </asp:BoundColumn>                         
                            
                            
                            <asp:BoundColumn DataField="Stu_No" HeaderText="学生学号" ReadOnly="true">
                                <ItemStyle Width ="80px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Stu_Name" HeaderText="学生姓名" ReadOnly="true">
                                <ItemStyle Width ="80px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Stu_Class" HeaderText="学生班级" ReadOnly="true">
                                <ItemStyle Width ="80px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Stu_Tel" HeaderText="联系方式" ReadOnly="true">
                                <ItemStyle Width ="80px" />
                            </asp:BoundColumn>
                             <asp:ButtonColumn   CommandName="Detail" HeaderText = "详细信息" ItemStyle-Width="80px"  Text="详细信息" ItemStyle-ForeColor="HotPink" >
                              
<ItemStyle ForeColor="HotPink" Width="80px"></ItemStyle>
                              
                            </asp:ButtonColumn>
                            
                            <asp:TemplateColumn ItemStyle-Width ="80px" HeaderText="教师意见" >
                                  <ItemTemplate>
                                   <asp:Label ID="lblTeaYijian" Text='<%# DataBinder.Eval(Container.DataItem, "Stu_Istongyi") %>' runat="server"/>
                                  
                                  </ItemTemplate>
                                   <EditItemTemplate>
                                  <asp:DropDownList ID="ddl" runat="server">
                      <asp:ListItem>同意</asp:ListItem>
                      <asp:ListItem>不同意</asp:ListItem>
                      </asp:DropDownList>
                                           </EditItemTemplate>

<ItemStyle Width="80px"></ItemStyle>

                                  </asp:TemplateColumn>  
                                   
                                  <asp:EditCommandColumn Visible="true" EditText="&lt;div onclick=&quot;return confirm('一旦审核将不可以更改，你确定执行该操作吗？')&quot;&gt;审核&lt;/div&gt;"   UpdateText="确定"  HeaderText = "是否同意" CancelText = "取消" ItemStyle-ForeColor="HotPink"> <ItemStyle Width ="80px"  /></asp:EditCommandColumn>
                             <asp:BoundColumn DataField="Zhehe_Zong" HeaderText="总成绩" ReadOnly="true">
                                <ItemStyle Width ="60px" />
                            </asp:BoundColumn>
                            
                        </Columns>
                        
                        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" 
                            Mode="NumericPages" Font-Underline="True" />
                        <HeaderStyle BackColor="#4A3C8C" BorderStyle="None" Font-Bold="True" 
                            ForeColor="#F7F7F7" />
                        <AlternatingItemStyle BorderColor="#C0FFFF" BorderWidth="1px" 
                            HorizontalAlign="Left" VerticalAlign="Middle" BackColor="#F7F7F7" />
                        <EditItemStyle BorderColor="#C0FFFF" BorderWidth="1px" Height="20px" />
                    </asp:DataGrid>
                    </td>
            </tr>
            　
            <tr>
                <td style="width: 100%; height: 21px;" align="right">
                    &nbsp;</td>
               
            </tr>
            <%--<tr style="height: 4px">
                <td style="width: 100%; height: 4px;background-color:#003333">
                    </td>
               
            </tr>--%>
              </table>
           
       
    </td></tr></table>
    </fieldset>
    </div>
    </form>
    </body></html>
<%--</asp:Content>--%>