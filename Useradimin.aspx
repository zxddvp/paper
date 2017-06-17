<%@ Page Language="C#"    AutoEventWireup="true" CodeFile="Useradimin.aspx.cs" Inherits="Useradimin"  %>
<%--
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>系统管理员界面</title> 
         <link href="loginfont.css" type="text/css" rel="stylesheet"/>
</head>

<body style="margin-top: 0px; margin-bottom: 0px; margin-right:0px; margin-left:0px">
    <form id="form1" runat="server">
    <div>
    <fieldset style=" border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F;">
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>
    <table>
    <tr>
    
    <td align="left" style=" width:10%">
        <table style="width: 1010px; border="0" cellpadding="0" cellspacing="0" class="css">
            
            <tr style="height:20px">
                <td style="width: 100%; height: 20px">
                <table cellSpacing="0"  width="100%" align="center" border="0">
					<tr>
						<td align="left" style="height: 22px">请输入学生的学号：
                            <asp:TextBox ID="StuNoTBox" runat="server"></asp:TextBox>
							<asp:Button ID="DelStuTimuBT" runat="server" BackColor="White" BorderColor="#FFFFC0" ForeColor="DarkRed"  Text="删除学生选题记录" OnClick="DelStuTimuBT_Click" />
							<hr style="color:Fuchsia" />
							</td>
						
	
					</tr>
					<tr>
						<td align="left" style="height: 22px">请选择教师：
							 
                            <asp:DropDownList ID="DDLTeaName" runat="server" DataSourceID="DataSource1" 
                                DataTextField="Tea_Name" DataValueField="Tea_No">
                            </asp:DropDownList>
                            <asp:AccessDataSource ID="DataSource1" runat="server" 
                                DataFile="~/data/paper.mdb" 
                                SelectCommand="SELECT [Tea_No], [Tea_Name] FROM [Teacher]">
                            </asp:AccessDataSource>
                            请输入该教师允许被选的题目数：<asp:TextBox ID="TBoxAllowNum" runat="server"></asp:TextBox>
							<asp:Button ID="BTUpdateAllownum" runat="server" BackColor="White" 
                                BorderColor="#FFFFC0" ForeColor="DarkRed"  Text="更改教师允许被选题目数" 
                                onclick="BTUpdateAllownum_Click"  />
							<hr style="color:Fuchsia" />
							</td>
					</tr>
				</table>
                    </td>
            </tr>
            <tr >
                <td style="height: 20px" >
                <asp:Button ID="OutExcelBT" runat="server" BackColor="White" 
                                BorderColor="#FFFFC0" ForeColor="DarkRed"  Text="导出为Excel" 
                                onclick="OutExcelBT_Click" />
                                        <asp:Label ID="Label2" ForeColor ="Red" Text="点击表格标题可以进行排序" 
                                runat ="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td  style="vertical-align: top; text-align: left; width: 1020px;" align="center" >
                <asp:DataGrid ID="PaperShenbaoDG" runat="server" AutoGenerateColumns="False" 
                        allowsorting="True" CellPadding="4" 
                        Font-Size="12px"  DataKeyField="ID"
                        HorizontalAlign="Center"  PageSize="20" Width="1020px"  AllowPaging="True" 
                        OnPageIndexChanged="PaperShenbaoDG_PageIndexChanged" 
                        oncancelcommand="PaperShenbaoDG_CancelCommand" 
                        oneditcommand="PaperShenbaoDG_EditCommand" 
                        onupdatecommand="PaperShenbaoDG_UpdateCommand" 
                        onsortcommand="PaperShenbaoDG_SortCommand" BackColor="White" 
                        BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" >
                        <ItemStyle BackColor="White" ForeColor="#003399" />
                        <Columns>
                        <asp:BoundColumn DataField="ID" HeaderText="ID" Visible="false" ReadOnly="True"> <ItemStyle Width ="20px" /></asp:BoundColumn>
                        <asp:BoundColumn DataField="Tea_Name" HeaderText="教师姓名" ReadOnly="True" SortExpression="Tea_Name">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>     
                             <asp:BoundColumn DataField="TimuName" HeaderText="题目名称" ReadOnly="True" SortExpression="TimuName">
                             <ItemStyle Width ="200px" />
                                  </asp:BoundColumn> 
                                   
                                  <asp:TemplateColumn ItemStyle-Width ="60px" HeaderText="题目来源" SortExpression="TL_Name">
                                  <ItemTemplate>
                                   <asp:Label ID="tllbl" Text='<%# DataBinder.Eval(Container.DataItem, "TL_Name") %>' runat="server"/>
                                  
                                  </ItemTemplate>
                                   <EditItemTemplate>
                                  <asp:DropDownList ID="tlddl" runat="server" TextMode="SingleLine" 
                                           DataSourceID="AccessDataSource1" DataTextField="TL_Name" 
                                           DataValueField="TL_No" ></asp:DropDownList>
                                           <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
                                           DataFile="~/data/paper.mdb" 
                                           SelectCommand="SELECT [TL_No], [TL_Name] FROM [TimuLaiyuan]">
                                       </asp:AccessDataSource>
                                           </EditItemTemplate>

                                         <ItemStyle Width="75px"></ItemStyle>
                                  </asp:TemplateColumn>  
                                  <asp:TemplateColumn ItemStyle-Width ="80px" HeaderText="课题类型" SortExpression="TT_Name">
                                  <ItemTemplate>
                                   <asp:Label ID="ttlbl" Text='<%# DataBinder.Eval(Container.DataItem, "TT_Name") %>' runat="server"/>
                                  
                                  </ItemTemplate>
                                   <EditItemTemplate>
                                  <asp:DropDownList ID="ttddl" runat="server" TextMode="SingleLine" 
                                           DataSourceID="AccessDataSource2" DataTextField="TT_Name" 
                                           DataValueField="TT_No" ></asp:DropDownList>
                                           <asp:AccessDataSource ID="AccessDataSource2" runat="server" 
                                           DataFile="~/data/paper.mdb" 
                                           SelectCommand="SELECT [TT_No], [TT_Name] FROM [TimuType]">
                                       </asp:AccessDataSource>
                                           </EditItemTemplate>

                                         <ItemStyle Width="75px"></ItemStyle>
                                  </asp:TemplateColumn>    
                                   <asp:TemplateColumn ItemStyle-Width ="80px" HeaderText="专业方向" SortExpression="ZA_Name">
                                  <ItemTemplate>
                                   <asp:Label ID="zalbl" Text='<%# DataBinder.Eval(Container.DataItem, "ZA_Name") %>' runat="server"/>
                                  
                                  </ItemTemplate>
                                   <EditItemTemplate>
                                  <asp:DropDownList ID="zaddl" runat="server" TextMode="SingleLine" 
                                           DataSourceID="AccessDataSource3" DataTextField="ZA_Name" 
                                           DataValueField="ZA_No" ></asp:DropDownList>
                                           <asp:AccessDataSource ID="AccessDataSource3" runat="server" 
                                           DataFile="~/data/paper.mdb" 
                                           SelectCommand="SELECT [ZA_No], [ZA_Name] FROM [ZhuanyeArrow]">
                                       </asp:AccessDataSource>
                                           </EditItemTemplate>

                                         <ItemStyle Width="75px"></ItemStyle>
                                  </asp:TemplateColumn>                 
                                  <asp:TemplateColumn  HeaderText="所属教研室"  SortExpression="Jys_Name">
                                  <ItemStyle Width="170px" />
                                  <ItemTemplate>
                                   <asp:Label ID="jyslbl" Text='<%# DataBinder.Eval(Container.DataItem, "Jys_Name") %>' runat="server"/>
                                  
                                  </ItemTemplate>
                                   <EditItemTemplate>
                                  <asp:DropDownList ID="jysddl" runat="server" TextMode="SingleLine" 
                                           DataSourceID="AccessDataSource4" DataTextField="Jys_Name" 
                                           DataValueField="Jys_No" ></asp:DropDownList>
                                           <asp:AccessDataSource ID="AccessDataSource4" runat="server" 
                                           DataFile="~/data/paper.mdb" 
                                           SelectCommand="SELECT [Jys_No], [Jys_Name] FROM [Jiaoyanshi]">
                                       </asp:AccessDataSource>
                                           </EditItemTemplate>

                                         <ItemStyle Width="75px"></ItemStyle>
                                  </asp:TemplateColumn>                   
                            
                            
                            
                            
                            
                            <asp:BoundColumn DataField="JiaoyanshiFirst" HeaderText="教研室" ReadOnly="True">
                               <ItemStyle Width ="60px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="XiShenhe" HeaderText="院审核" ReadOnly="True">
                                <ItemStyle Width ="50px" />
                            </asp:BoundColumn>
                            
                                  <%--<asp:BoundColumn DataField="JiaoTime" HeaderText="教研室初审时间" ReadOnly="True" Visible="false">
                             <ItemStyle Width ="90px" />
                                  </asp:BoundColumn> 
                                  <asp:BoundColumn DataField="XiTime" HeaderText="院审核时间" ReadOnly="True" Visible="false">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn> 
                                  <asp:BoundColumn DataField="IsSel" HeaderText="题目是否已被选" ReadOnly="True">
                             <ItemStyle Width ="90px" />
                                  </asp:BoundColumn> --%>
                                  <asp:BoundColumn DataField="Stu_Name" HeaderText="学生姓名" ReadOnly="True" SortExpression="Stu_Name">
                             <ItemStyle Width ="60px" />
                                  </asp:BoundColumn> 
                                  <asp:BoundColumn DataField="Stu_No" HeaderText="学生学号" ReadOnly="True" SortExpression="Stu_No">
                             <ItemStyle Width ="60px" />
                                  </asp:BoundColumn> 
                                  <asp:BoundColumn DataField="Stu_Class" HeaderText="学生班级" ReadOnly="True" SortExpression="Stu_Class">
                             <ItemStyle Width ="60px" />
                                  </asp:BoundColumn> 
                                  <asp:EditCommandColumn  EditText="编辑" UpdateText="确定"  HeaderText = "编辑" CancelText = "取消"> <ItemStyle Width ="40px" /></asp:EditCommandColumn>
                         
                        </Columns>
                        
                        <SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" 
                            Font-Underline="True" Mode="NumericPages" />
                        <HeaderStyle BackColor="#003399" BorderStyle="None" Font-Bold="True"  HorizontalAlign="Center"
                            ForeColor="#CCCCFF" />
                        <AlternatingItemStyle BorderColor="#C0FFFF" BorderWidth="1px" 
                            HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <EditItemStyle  BorderColor="#C0FFFF" BorderWidth="1px" Height="20px" 
                            Width="40px" Wrap="True" />
                    </asp:DataGrid>
                    </td>
                    </tr>
                    <tr><td><asp:Button ID="OutExcelBT1" runat="server" BackColor="White" 
                                BorderColor="#FFFFC0" ForeColor="DarkRed"  Text="导出为Excel" 
                            onclick="OutExcelBT1_Click"  /></td></tr>
                    <tr><td>
                        <asp:GridView ID="StatisticTeaTimuGv" runat="server" BackColor="White" AutoGenerateColumns="False" 
                            BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                            AllowPaging="True" AllowSorting="True" 
                            Width="1020px" PageSize="30"  PagerSettings-Visible="true" 
                            onpageindexchanging="StatisticTeaTimuGv_PageIndexChanging" 
                            onsorting="StatisticTeaTimuGv_Sorting">
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399"  />
                            <RowStyle BackColor="White" ForeColor="#003399" />
                            <Columns>
                            
                                <asp:BoundField  ItemStyle-Width ="100px" HeaderText="教师姓名" 
                                    DataField="Tea_Name" SortExpression="Tea_Name" >
<ItemStyle Width="100px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField  ItemStyle-Width ="100px" HeaderText="学位" 
                                    DataField="Tea_xuewei" SortExpression="Tea_xuewei" >
<ItemStyle Width="100px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField  ItemStyle-Width ="100px" HeaderText="学历" DataField="Tea_xueli" 
                                    SortExpression="Tea_xueli" >
<ItemStyle Width="100px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField  ItemStyle-Width ="100px" HeaderText="职称" 
                                    DataField="Tea_zhicheng" SortExpression="Tea_zhicheng" >
<ItemStyle Width="100px"></ItemStyle>
                                </asp:BoundField>
                                <%--<asp:BoundField  ItemStyle-Width ="40px" HeaderText="年龄" DataField="Tea_Name" SortExpression="Tea_Name" />--%>
                               
                                <asp:BoundField  ItemStyle-Width ="100px" HeaderText="指导学生数" DataField="StuNum" 
                                    SortExpression="StuNum" >
<ItemStyle Width="100px"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle ForeColor="#003399" HorizontalAlign="Left" Font-Underline="true" 
                                BackColor="#99CCCC"  />
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        </asp:GridView>
                        </td></tr>
                    <tr>
                    
                    <td  style="vertical-align: top; text-align: left;  width: 1020px;" align="center" >
                <asp:DataGrid ID="StuDG" runat="server" AutoGenerateColumns="False" BackColor="White" allowsorting="True" 
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                            Font-Size="12px"  DataKeyField="ID"
                        HorizontalAlign="Center"  PageSize="8" Width="1020px"  AllowPaging="True" 
                            OnPageIndexChanged="StuDG_PageIndexChanged" 
                            oncancelcommand="StuDG_CancelCommand" oneditcommand="StuDG_EditCommand" 
                            onupdatecommand="StuDG_UpdateCommand" >
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <ItemStyle ForeColor="#000066" />
                        <Columns>
                        <asp:BoundColumn DataField="ID" HeaderText="ID" Visible="true" ReadOnly="True"> <ItemStyle Width ="65px" /></asp:BoundColumn>
                        <asp:BoundColumn DataField="Stu_No" HeaderText="学号" ReadOnly="True">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>     
                             <asp:BoundColumn DataField="Stu_Name" HeaderText="姓名" ReadOnly="True">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>  
                                 <asp:BoundColumn DataField="Stu_Class" HeaderText="班级" ReadOnly="True">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>  
                                  <asp:BoundColumn DataField="Role_No" HeaderText="角色号" ReadOnly="True">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn> 
              
                                  <asp:TemplateColumn ItemStyle-Width ="60px" HeaderText="密码" >
                                  <ItemTemplate>
                                   <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "Stu_psw") %>' runat="server" Visible="false"/>
                                  
                                  </ItemTemplate>
                                   <EditItemTemplate>
                                  <asp:TextBox ID="StuMimaTBox" runat="server" TextMode="SingleLine" ></asp:TextBox>
                                           </EditItemTemplate>
                                  </asp:TemplateColumn>   
                                                     
                           
                            <asp:BoundColumn DataField="IsSelected" HeaderText="是否已选题目" ReadOnly="True">
                               <ItemStyle Width ="70px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="STime" HeaderText="选题时间" ReadOnly="True">
                                <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            
                           <%-- <asp:BoundColumn DataField="PSB_Id" HeaderText="教师题目ID" ReadOnly="True">
                               <ItemStyle Width ="160px" />
                            </asp:BoundColumn>--%>
                            <asp:EditCommandColumn  EditText="修改密码" UpdateText="确定"  HeaderText = "修改密码" CancelText = "取消"> <ItemStyle Width ="90px" /></asp:EditCommandColumn>
                        </Columns>
                        
                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" 
                            Mode="NumericPages" />
                        <HeaderStyle BackColor="#006699" BorderStyle="None" Font-Bold="True" 
                            ForeColor="White" />
                        <AlternatingItemStyle BorderColor="#C0FFFF" BorderWidth="1px" 
                            HorizontalAlign="Left" VerticalAlign="Middle" />
                        <EditItemStyle  BorderColor="#C0FFFF" BorderWidth="1px" Height="20px" 
                            Width="40px" Wrap="True" />
                    </asp:DataGrid>
                    </td>
                    </tr>
                    <tr>
                    
                     <td  style="vertical-align: top; text-align: left; width: 1020px;" align="center" >
                <asp:DataGrid ID="TeaDG" runat="server" AutoGenerateColumns="False" BackColor="White" allowsorting="True" 
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                             Font-Size="12px"  DataKeyField="ID"
                        HorizontalAlign="Center"  PageSize="8" Width="1020px"  AllowPaging="True" 
                             OnPageIndexChanged="TeaDG_PageIndexChanged" oneditcommand="TeaDG_EditCommand" 
                             onupdatecommand="TeaDG_UpdateCommand" 
                             oncancelcommand="TeaDG_CancelCommand" >
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <ItemStyle ForeColor="#000066" />
                        <Columns>
                        <asp:BoundColumn DataField="ID" HeaderText="ID" Visible="true" ReadOnly="True"> <ItemStyle Width ="65px" /></asp:BoundColumn>
                        <asp:BoundColumn DataField="Tea_No" HeaderText="教工号" ReadOnly="True">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>     
                             <asp:BoundColumn DataField="Tea_Name" HeaderText="姓名" ReadOnly="True">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>  
                                 <asp:BoundColumn DataField="Tea_Zhicheng" HeaderText="职称" ReadOnly="True">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>  
                                  <asp:BoundColumn DataField="Role_No" HeaderText="角色号" ReadOnly="True">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>  
                                  <asp:TemplateColumn ItemStyle-Width ="60px" HeaderText="密码" >
                                  <ItemTemplate>
                                   <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "Tea_psw") %>' runat="server" Visible="false"/>
                                  
                                  </ItemTemplate>
                                   <EditItemTemplate>
                                  <asp:TextBox ID="TeaMimaTBox" runat="server" TextMode="SingleLine" ></asp:TextBox>
                                           </EditItemTemplate>
                                  </asp:TemplateColumn>   
                                                        
                           
                           
                             <asp:EditCommandColumn  EditText="编辑" UpdateText="确定"  HeaderText = "编辑教师信息" CancelText = "取消"> <ItemStyle Width ="50px" /></asp:EditCommandColumn>
                        </Columns>
                        
                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" 
                            Mode="NumericPages" />
                        <HeaderStyle BackColor="#006699" BorderStyle="None" Font-Bold="True" 
                            ForeColor="White" />
                        <AlternatingItemStyle BorderColor="#C0FFFF" BorderWidth="1px" 
                            HorizontalAlign="Left" VerticalAlign="Middle" />
                        <EditItemStyle  BorderColor="#C0FFFF" BorderWidth="1px" Height="20px" 
                            Width="40px" Wrap="True" />
                    </asp:DataGrid>
                    </td>
                    </tr>
                    <tr>
                    <td  style="vertical-align: top; text-align: left; width: 1020px;" align="center" >
                <asp:DataGrid ID="JysDG" runat="server" AutoGenerateColumns="False" BackColor="White" allowsorting="True" 
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                            Font-Size="12px" DataKeyField="Jys_No"
                        HorizontalAlign="Center"  PageSize="8" Width="1020px"  AllowPaging="True" 
                            OnPageIndexChanged="JysDG_PageIndexChanged" 
                            oncancelcommand="JysDG_CancelCommand" oneditcommand="JysDG_EditCommand" 
                            onupdatecommand="JysDG_UpdateCommand" >
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <ItemStyle ForeColor="#000066" />
                        <Columns>
                        
                        <asp:BoundColumn DataField="Jys_No" HeaderText="教研室号" ReadOnly="True">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>     
                             <asp:BoundColumn DataField="Jys_Name" HeaderText="教研室名称" ReadOnly="True">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>  
                                 <asp:BoundColumn DataField="Jys_Admin" HeaderText="教研室负责人" ReadOnly="True">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>  
                                   <asp:TemplateColumn ItemStyle-Width ="60px" HeaderText="密码" >
                                  <ItemTemplate>
                                   <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "Jys_psw") %>' runat="server" Visible="false"/>
                                  
                                  </ItemTemplate>
                                   <EditItemTemplate>
                                  <asp:TextBox ID="JysMimaTBox" runat="server" TextMode="SingleLine" ></asp:TextBox>
                                           </EditItemTemplate>
                                  </asp:TemplateColumn>   
                                                       
                            <asp:BoundColumn DataField="Role_No" HeaderText="角色名" ReadOnly="True">
                                <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Tea_No" HeaderText="教工号" ReadOnly="True">
                               <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            <asp:EditCommandColumn  EditText="修改密码" UpdateText="确定"  HeaderText = "修改密码" CancelText = "取消"> <ItemStyle Width ="90px" /></asp:EditCommandColumn>
                        </Columns>
                        
                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" 
                            Mode="NumericPages" />
                        <HeaderStyle BackColor="#006699" BorderStyle="None" Font-Bold="True" 
                            ForeColor="White" />
                        <AlternatingItemStyle BorderColor="#C0FFFF" BorderWidth="1px" 
                            HorizontalAlign="Left" VerticalAlign="Middle" />
                        <EditItemStyle  BorderColor="#C0FFFF" BorderWidth="1px" Height="20px" 
                            Width="40px" Wrap="True" />
                    </asp:DataGrid>
                    </td>
                    </tr>
                    <tr>
                    <td  style="vertical-align: top; text-align: left; width: 1020px;" align="center" >
                <asp:DataGrid ID="UADG" runat="server" AutoGenerateColumns="False" BackColor="White" allowsorting="True" 
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                            Font-Size="12px"  DataKeyField="ID"
                        HorizontalAlign="Center"  PageSize="8" Width="1020px"  AllowPaging="True" 
                            OnPageIndexChanged="UADG_PageIndexChanged" oncancelcommand="UADG_CancelCommand" 
                            oneditcommand="UADG_EditCommand" onupdatecommand="UADG_UpdateCommand" >
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <ItemStyle ForeColor="#000066" />
                        <Columns>
                        <asp:BoundColumn DataField="ID" HeaderText="ID" Visible="true" ReadOnly="True"> <ItemStyle Width ="65px" /></asp:BoundColumn>
                           
                             <asp:BoundColumn DataField="UA_Name" HeaderText="用户管理员名称" ReadOnly="True">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>  
                                  <asp:TemplateColumn ItemStyle-Width ="60px" HeaderText="密码" >
                                  <ItemTemplate>
                                   <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "UA_psw") %>' runat="server" Visible="false"/>
                                  
                                  </ItemTemplate>
                                   <EditItemTemplate>
                                  <asp:TextBox ID="UaMimaTBox" runat="server" TextMode="SingleLine" ></asp:TextBox>
                                           </EditItemTemplate>
                                  </asp:TemplateColumn>  
                                                        
                            <asp:BoundColumn DataField="Role_No" HeaderText="角色名" ReadOnly="True">
                                <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Tea_No" HeaderText="教工号" ReadOnly="True">
                               <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            <asp:EditCommandColumn  EditText="修改密码" UpdateText="确定"  HeaderText = "修改密码" CancelText = "取消"> <ItemStyle Width ="90px" /></asp:EditCommandColumn>
                        </Columns>
                        
                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" 
                            Mode="NumericPages" />
                        <HeaderStyle BackColor="#006699" BorderStyle="None" Font-Bold="True" 
                            ForeColor="White" />
                        <AlternatingItemStyle BorderColor="#C0FFFF" BorderWidth="1px" 
                            HorizontalAlign="Left" VerticalAlign="Middle" />
                        <EditItemStyle  BorderColor="#C0FFFF" BorderWidth="1px" Height="20px" 
                            Width="40px" Wrap="True" />
                    </asp:DataGrid>
                    </td>
                    </tr>
                    
                     <tr>
                    <td  style="vertical-align: top; text-align: left; width: 1020px;" align="center" >
                <asp:DataGrid ID="XiLeaderDG" runat="server" AutoGenerateColumns="False" 
                            BackColor="White" allowsorting="True" 
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                            Font-Size="12px"  DataKeyField="ID"
                        HorizontalAlign="Center"  PageSize="8" Width="1020px"  AllowPaging="True" 
                            OnPageIndexChanged="XiLeaderDG_PageIndexChanged" 
                            oncancelcommand="XiLeaderDG_CancelCommand" 
                            oneditcommand="XiLeaderDG_EditCommand" 
                            onupdatecommand="XiLeaderDG_UpdateCommand" >
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <ItemStyle ForeColor="#000066" />
                        <Columns>
                        <asp:BoundColumn DataField="ID" HeaderText="ID" Visible="true" ReadOnly="True"> <ItemStyle Width ="65px" /></asp:BoundColumn>
                           
                             <asp:BoundColumn DataField="XL_Name" HeaderText="院领导名称" ReadOnly="True">
                             <ItemStyle Width ="65px" />
                                  </asp:BoundColumn>  
                                 <asp:TemplateColumn ItemStyle-Width ="60px" HeaderText="密码" >
                                  <ItemTemplate>
                                   <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "XL_psw") %>' runat="server" Visible="false"/>
                                  
                                  </ItemTemplate>
                                   <EditItemTemplate>
                                  <asp:TextBox ID="XLMimaTBox" runat="server" TextMode="SingleLine" ></asp:TextBox>
                                           </EditItemTemplate>
                                  </asp:TemplateColumn>  
                                                   
                            <asp:BoundColumn DataField="Role_No" HeaderText="角色号" ReadOnly="True">
                                <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Tea_No" HeaderText="教工号" ReadOnly="True">
                               <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                             <asp:EditCommandColumn  EditText="修改密码" UpdateText="确定"  HeaderText = "修改密码" CancelText = "取消"> <ItemStyle Width ="90px" /></asp:EditCommandColumn>
                        </Columns>
                        
                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" 
                            Mode="NumericPages" />
                        <HeaderStyle BackColor="#006699" BorderStyle="None" Font-Bold="True" 
                            ForeColor="White" />
                        <AlternatingItemStyle BorderColor="#C0FFFF" BorderWidth="1px" 
                            HorizontalAlign="Left" VerticalAlign="Middle" />
                        <EditItemStyle  BorderColor="#C0FFFF" BorderWidth="1px" Height="20px" 
                            Width="40px" Wrap="True" />
                    </asp:DataGrid>
                    </td>
                    </tr>
                    <tr>
                  <td  style="vertical-align: top; text-align: left; width: 1020px;" align="center" >
                <asp:DataGrid ID="TimuTypeDG" runat="server" AutoGenerateColumns="False"  Visible="false"
                          BackColor="White" allowsorting="True" 
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="12px" 
                        HorizontalAlign="Center"  PageSize="8" Width="1020px"  AllowPaging="True" 
                          OnPageIndexChanged="TimuTypeDG_PageIndexChanged" >
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <ItemStyle ForeColor="#000066" />
                        <Columns>
                                 
                            <asp:BoundColumn DataField="TT_No" HeaderText="题目类型号" ReadOnly="True">
                                <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TT_Name" HeaderText="题目类型名称" ReadOnly="True">
                               <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                        </Columns>
                        
                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" 
                            Mode="NumericPages" />
                        <HeaderStyle BackColor="#006699" BorderStyle="None" Font-Bold="True" 
                            ForeColor="White" />
                        <AlternatingItemStyle BorderColor="#C0FFFF" BorderWidth="1px" 
                            HorizontalAlign="Left" VerticalAlign="Middle" />
                        <EditItemStyle  BorderColor="#C0FFFF" BorderWidth="1px" Height="20px" 
                            Width="40px" Wrap="True" />
                    </asp:DataGrid>
                    </td>  
            </tr>
            <tr>
                  <td  style="vertical-align: top; text-align: left; width: 1020px;" align="center" >
                <asp:DataGrid ID="TimuLaiyuanDG" runat="server" AutoGenerateColumns="False"  Visible="false"
                          BackColor="White" allowsorting="True" 
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="12px" 
                        HorizontalAlign="Center"  PageSize="8" Width="1020px"  AllowPaging="True" 
                          OnPageIndexChanged="TimuLaiyuanDG_PageIndexChanged" >
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <ItemStyle ForeColor="#000066" />
                        <Columns>
                                 
                            <asp:BoundColumn DataField="TL_No" HeaderText="题目来源号" ReadOnly="True">
                                <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TL_Name" HeaderText="题目来源名称" ReadOnly="True">
                               <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                        </Columns>
                        
                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" 
                            Mode="NumericPages" />
                        <HeaderStyle BackColor="#006699" BorderStyle="None" Font-Bold="True" 
                            ForeColor="White" />
                        <AlternatingItemStyle BorderColor="#C0FFFF" BorderWidth="1px" 
                            HorizontalAlign="Left" VerticalAlign="Middle" />
                        <EditItemStyle  BorderColor="#C0FFFF" BorderWidth="1px" Height="20px" 
                            Width="40px" Wrap="True" />
                    </asp:DataGrid>
                    </td>  
            </tr>
             <tr>
                  <td  style="vertical-align: top; text-align: left; width: 1020px;" align="center" >
                <asp:DataGrid ID="ZhuanyeDG" runat="server" AutoGenerateColumns="False"  Visible="false"
                          BackColor="White" allowsorting="True" 
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="12px" 
                        HorizontalAlign="Center"  PageSize="8" Width="1020px"  AllowPaging="True" 
                          OnPageIndexChanged="ZhuanyeDG_PageIndexChanged" >
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <ItemStyle ForeColor="#000066" />
                        <Columns>
                                 
                            <asp:BoundColumn DataField="ZA_No" HeaderText="专业方向号" ReadOnly="True">
                                <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ZA_Name" HeaderText="专业方向名称" ReadOnly="True">
                               <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                        </Columns>
                        
                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" 
                            Mode="NumericPages" />
                        <HeaderStyle BackColor="#006699" BorderStyle="None" Font-Bold="True" 
                            ForeColor="White" />
                        <AlternatingItemStyle BorderColor="#C0FFFF" BorderWidth="1px" 
                            HorizontalAlign="Left" VerticalAlign="Middle" />
                        <EditItemStyle  BorderColor="#C0FFFF" BorderWidth="1px" Height="20px" 
                            Width="40px" Wrap="True" />
                    </asp:DataGrid>
                    </td>  
            </tr>
            <tr>
                  <td  style="vertical-align: top; text-align: left; width: 1020px;" align="center" >
                <asp:DataGrid ID="RoleDG" runat="server" AutoGenerateColumns="False"  Visible="false"
                          BackColor="White" allowsorting="True" 
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                          Font-Size="12px"  DataKeyField="ID"
                        HorizontalAlign="Center"  PageSize="8" Width="1020px"  AllowPaging="True" 
                          OnPageIndexChanged="RoleDG_PageIndexChanged" >
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <ItemStyle ForeColor="#000066" />
                        <Columns>
                                 
                            <asp:BoundColumn DataField="ID" HeaderText="ID" ReadOnly="True">
                                <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Role_Name" HeaderText="角色名称" ReadOnly="True">
                               <ItemStyle Width ="65px" />
                            </asp:BoundColumn>
                        </Columns>
                        
                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" 
                            Mode="NumericPages" />
                        <HeaderStyle BackColor="#006699" BorderStyle="None" Font-Bold="True" 
                            ForeColor="White" />
                        <AlternatingItemStyle BorderColor="#C0FFFF" BorderWidth="1px" 
                            HorizontalAlign="Left" VerticalAlign="Middle" />
                        <EditItemStyle  BorderColor="#C0FFFF" BorderWidth="1px" Height="20px" 
                            Width="40px" Wrap="True" />
                    </asp:DataGrid>
                    </td>  
            </tr>
            <tr>
                <td style="width: 100%; height: 31px;" align="right">
                    &nbsp;
                    </td>
               
            </tr>
            <tr style="height: 4px">
                <td style="width: 100%; height: 4px;background-color:royalblue">
                    </td>
               
            </tr>
              </table>
           
       
    </td></tr></table>
    </fieldset>
    </div>
    </form></body></html>
<%--</asp:Content>--%>