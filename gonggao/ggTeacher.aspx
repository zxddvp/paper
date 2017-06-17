<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ggTeacher.aspx.cs" Inherits="gonggao_ggTeacher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>教师公告</title>
     <link href="~/loginfont.css" type="text/css" rel="stylesheet"/>
    
</head>

<body style="margin-top: 0px; margin-bottom: 0px; margin-right:0px; margin-left:0px" >

<form id="form1" runat="server">
    <div>
    <fieldset style=" width:790px; border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F;">
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>
         
               <table width=600 border=0 cellpadding=0 cellspacing=0 align="center">
        
        <tr>
          <td style="height: 37px">
       <%-- 员工编号:<asp:TextBox ID="EmployeeNo" runat="server" Width="66px"></asp:TextBox>
        员工姓名:<asp:TextBox ID="EmployeeName" runat="server" Width="66px"></asp:TextBox>
        所在部门:<asp:DropDownList ID="DepartmentName" runat="server">
        </asp:DropDownList>&nbsp;
        职位类别:<asp:DropDownList ID="WorkType" runat="server">
        </asp:DropDownList>&nbsp;<asp:Button ID="Btn_Query" runat="server" OnClick="Btn_Query_Click"
            Text="查询" /><br />--%>
              <asp:GridView ID="gvTeaGG" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                  CellPadding="4" DataKeyNames="gg_ID" DataSourceID="AccessDataSource1"
                  ForeColor="#333333" GridLines="None" Width="603px" 
                  OnRowDataBound="gvTeaGG_RowDataBound" PageSize="8" 
                  OnPageIndexChanged="gvTeaGG_PageIndexChanged" 
                  >
                  <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <Columns>
                   <asp:TemplateField HeaderText="选择">
                          <ItemTemplate>
                              <asp:CheckBox ID="CB_Select" runat="server" />
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:BoundField DataField="gg_ID" HeaderText="gg_ID" ReadOnly="True" 
                          SortExpression="gg_ID" InsertVisible="False" />
                      <asp:BoundField DataField="gg_Role" HeaderText="gg_Role" 
                          SortExpression="gg_Role" />
                      <asp:BoundField DataField="gg_Content" HeaderText="gg_Content" 
                          SortExpression="gg_Content" />
                      <asp:BoundField DataField="gg_AddTime" HeaderText="gg_AddTime" 
                          SortExpression="gg_AddTime" />
                         <%-- <asp:HyperLinkField DataNavigateUrlFields="employeeNo" DataNavigateUrlFormatString="EmployeeInfoUpdate.aspx?employeeNo={0}"
                          HeaderText="编辑" Text="进入" />--%>
                  </Columns>
                  <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                  <EmptyDataTemplate>
                      对不起，没有当前的查询记录存在!
                  </EmptyDataTemplate>
                  <EditRowStyle BackColor="#999999" />
                  <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                  <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              </asp:GridView>
              <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
                  DataFile="~/data/paper.mdb" 
                  SelectCommand="SELECT * FROM [Gonggao] WHERE ([gg_Role] = ?) ORDER BY [gg_AddTime]">
                  <SelectParameters>
                      <asp:Parameter DefaultValue="1" Name="gg_Role" Type="Int32" />
                  </SelectParameters>
              </asp:AccessDataSource>
              <br />
              <asp:CheckBox ID="CB_SelectAll" runat="server" AutoPostBack="True" OnCheckedChanged="CB_SelectAll_CheckedChanged"
                  Text="全选" />&nbsp;
              <asp:Button ID="Btn_Delete" runat="server" OnClick="Btn_Delete_Click" Text="删除" /><br />
              <br />
        </td>
      </tr>
    </table>
    </fieldset>
    </div>
 </form>
 </body>
 </html>

  
     
