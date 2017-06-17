<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="Student.aspx.cs" Inherits="Student"  %>
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
    
    <td style="width:15%">
        <table  border="0" cellpadding="0" cellspacing="0" >
           
           <tr style="height: 8px">
                <td style="width: 100%; height:60px">
                <table cellSpacing="0"  width="100%" align="center" border="0" height="20px">
					<tr>
						<TD align="left">你好！<%=stuname%>，
							<% if ((isselect == "0") || ((isselect == "1") && (isallowed == "不同意")) || ((isselect == "1") && (isallowed == "未审核")) || ((isselect == "1") && (isallowed == "")))
          { %>在选择指导教师之前请先完善您的基本信息，教师将根据您填写的基本信息决定是否同意对您进行指导！<% }
                        else  {%>请查看指导教师回复！
                        <% } %>
                            </TD>
					</tr>
						
				</table>
			<% if ((isselect == "0") || ((isselect == "1") && (isallowed == "不同意")) || ((isselect == "1") && (isallowed == "未审核")) || ((isselect == "1") && (isallowed == "")))
          { %>
				<table cellSpacing="0"   align="center" border="0" style=" height:20px; width:100%;">
					<tr>
						<td align="left" style=" width:20%">
						<asp:CheckBox ID="TLCbox" runat="server" Text="题目来源：" />
                            <asp:DropDownList ID="TLDdl" runat="server" DataSourceID="AccessDataSource1" DataTextField="TL_Name" DataValueField="TL_No" Width="80px">
                            </asp:DropDownList><asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/data/paper.mdb"
                                SelectCommand="SELECT [TL_No], [TL_Name] FROM [TimuLaiyuan]"></asp:AccessDataSource>
                            
                                &nbsp;<asp:CheckBox ID="TTCbox" runat="server" Text="课题类型：" />
                            <asp:DropDownList ID="TTDdl" runat="server" DataSourceID="AccessDataSource2" DataTextField="TT_Name" DataValueField="TT_No"  Width="80px"></asp:DropDownList><asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~/data/paper.mdb"
                                SelectCommand="SELECT [TT_Name], [TT_No] FROM [TimuType]"></asp:AccessDataSource>
                            
                               <asp:CheckBox ID="ZACbox" runat="server" Text="专业方向：" />
                            <asp:DropDownList ID="ZADdl" runat="server" DataSourceID="AccessDataSource3" DataTextField="ZA_Name" DataValueField="ZA_No" Width="80px"></asp:DropDownList><asp:AccessDataSource ID="AccessDataSource3" runat="server" DataFile="~/data/paper.mdb"
                                SelectCommand="SELECT * FROM [ZhuanyeArrow]"></asp:AccessDataSource>
                           
                               <asp:Button ID="seaBt" runat="server" Text="确 定" BorderColor="RoyalBlue" OnClick="seaBt_Click" />
                            </td>
					</tr>	
					<tr><td> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Text="按教师查询："></asp:Label>
                        <asp:DropDownList ID="DDLSelTea" runat="server" 
                            DataSourceID="AccessDataSource4" DataTextField="Tea_Name" 
                            DataValueField="Tea_No" Height="16px" Width="86px">
                        </asp:DropDownList>
                           
                               <asp:AccessDataSource ID="AccessDataSource4" runat="server" 
                            DataFile="~/data/paper.mdb" 
                            SelectCommand="SELECT [Tea_Name], [Tea_No] FROM [Teacher]">
                        </asp:AccessDataSource>
                           
                               <asp:Button ID="BTSelTea" runat="server" Text="确 定" 
                            BorderColor="RoyalBlue" onclick="BTSelTea_Click"  />
                        <asp:Label ID="Label2" runat="server" Text="***选择教师姓名可以查看该教师指导的论文题目。***" ForeColor="red"></asp:Label>
                        </td></tr>
                        <tr><td>  <asp:DataGrid ID="StuDataGrid" runat="server" AutoGenerateColumns="False" 
                        BackColor="LightGoldenrodYellow" allowsorting="True" 
                        BorderColor="Tan" BorderWidth="1px" 
                        CellPadding="5" Font-Size="12px"  DataKeyField="ID"
                        HorizontalAlign="Center"  PageSize="25" Width="600px"  AllowPaging="false" 
                        ToolTip="你能选择其中一个题目，请慎重！"  OnEditCommand="StuDataGrid_EditCommand" 
                        OnPageIndexChanged="StuDataGrid_PageIndexChanged" 
                        OnItemCommand="StuDataGrid_ItemCommand" ForeColor="Black" GridLines="None">
                        <FooterStyle BackColor="Tan" />
                        <Columns>
                        <asp:BoundColumn DataField="ID" Visible="false"></asp:BoundColumn>
                              <asp:BoundColumn DataField="Tea_Name" HeaderText="教师姓名" HeaderStyle-Width ="100px">
                             
                                  <HeaderStyle Width="100px"></HeaderStyle>
                             
                                  </asp:BoundColumn>  
                             <asp:BoundColumn DataField="TimuName" HeaderText="题目名称" HeaderStyle-Width ="100px">
                             
                                  <HeaderStyle Width="100px"></HeaderStyle>
                             
                                  </asp:BoundColumn>                         
                           <%-- <asp:BoundColumn DataField="TL_Name" HeaderText="题目来源" HeaderStyle-Width ="100px">
                               
<HeaderStyle Width="100px"></HeaderStyle>
                               
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TT_Name" HeaderText="课题类型" HeaderStyle-Width ="100px">
                               
<HeaderStyle Width="100px"></HeaderStyle>
                               
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ZA_Name" HeaderText="专业方向" HeaderStyle-Width ="100px">
                              
<HeaderStyle Width="100px"></HeaderStyle>
                              
                            </asp:BoundColumn>--%>
                            <asp:ButtonColumn  CommandName="Detail" HeaderText = "详细信息" ItemStyle-Width="60px"  Text="详细信息" ItemStyle-ForeColor="HotPink" >
                             
<ItemStyle ForeColor="HotPink" Width="60px"></ItemStyle>
                             
                            </asp:ButtonColumn>
                            <asp:EditCommandColumn Visible="true" EditText="&lt;div onclick=&quot;return confirm('你只有一次选择题目的机会，一旦选择将不可以更改，你确定选择该题目吗？')&quot;&gt;选择该题目&lt;/div&gt;"  HeaderText = "选择" ItemStyle-ForeColor="Blue" ItemStyle-Width="60px"  >
                              
<ItemStyle Width="60px"></ItemStyle>
                              
                            </asp:EditCommandColumn> 
                        </Columns>
                        
                        <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" 
                            Mode="NumericPages" Font-Underline="True" />
                        <HeaderStyle BackColor="Tan" BorderStyle="None" Font-Bold="True" />
                        <AlternatingItemStyle BorderColor="#C0FFFF" BorderWidth="1px" 
                            HorizontalAlign="Left" VerticalAlign="Middle" BackColor="PaleGoldenrod" />
                        <EditItemStyle BorderColor="#C0FFFF" BorderWidth="1px" Height="20px" />
                    </asp:DataGrid></td></tr>
				</table><% } %>
                    </td>
               
            </tr>
          <%--  <tr><td>   
                请输入你的联系方式：
               <asp:TextBox ID="StuTelTBox" runat="server" BackColor="#AFEEEE"></asp:TextBox>
               <asp:Button ID="StuTelBTon" runat="server" Text="确 定" 
                    onclick="StuTelBTon_Click" />
           <asp:Label ID="Label3" runat="server" Text="***在选题前，请输入您的联系方式。***" ForeColor="red"></asp:Label>
           </td></tr>--%>
            <tr >
                <td  style="vertical-align: top; text-align: left;  width:600px;" align="center" >
                <% if(isselect == "1") {%>
               <%-- <asp:DataGrid ID="StuDataGrid1" runat="server" AutoGenerateColumns="False" 
                        BackColor="LightGoldenrodYellow" allowsorting="True" 
                        BorderColor="Tan" BorderWidth="1px" 
                        CellPadding="5" Font-Size="12px"  DataKeyField="ID"
                        HorizontalAlign="Center"  PageSize="15" Width="600px"  AllowPaging="True" 
                        ToolTip="你已经选择好题目了，请查询指导教师的回复！"  
                        OnPageIndexChanged="StuDataGrid1_PageIndexChanged" ForeColor="Black" 
                        GridLines="None" >
                        <FooterStyle BackColor="Tan" />
                        <Columns>
                        <asp:BoundColumn DataField="ID" Visible="false"></asp:BoundColumn>
                         <asp:BoundColumn DataField="Tea_Name" HeaderText="指导教师姓名">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>  
                                   <asp:BoundColumn DataField="Tea_Telno" HeaderText="联系方式">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>      
                             <asp:BoundColumn DataField="TimuName" HeaderText="题目名称">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>                         
                            <asp:BoundColumn DataField="TL_Name" HeaderText="题目来源">
                                <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TT_Name" HeaderText="课题类型">
                               <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ZA_Name" HeaderText="专业方向">
                                <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TimuJianjie" HeaderText="题目简介" >
                               <ItemStyle Width ="160px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TimuTiaojian" HeaderText="基本条件" >
                                <ItemStyle Width ="240px" />
                            </asp:BoundColumn>
                        </Columns>
                        <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" 
                            Mode="NumericPages" Font-Underline="True" />
                        <HeaderStyle BackColor="Tan" BorderStyle="None" Font-Bold="True" />
                        <AlternatingItemStyle BorderColor="#C0FFFF" BorderWidth="1px" 
                            HorizontalAlign="Left" VerticalAlign="Middle" BackColor="PaleGoldenrod" />
                        <EditItemStyle BorderColor="#C0FFFF" BorderWidth="1px" Height="20px" />
                    </asp:DataGrid>--%>
                
                <% } else if (isselect == "0"){ %>
              
                    <% } %>
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
   </fieldset>  </div>
    </form>
    </body>
    </html>
<%--</asp:Content>--%>