<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditTeaTimu.aspx.cs" Inherits="EditTeaTimu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>教师编辑题目页面</title>
     <link href="loginfont.css" type="text/css" rel="stylesheet"/>
</head>


<body style="margin-top: 0px; margin-bottom: 0px; margin-right:0px; margin-left:0px" class="css">
    <form id="form2" runat="server">
    <div>
    <table>
    <tr>
    
    <td style="width:50%" align="center">
        <table style="width: 760px; height: 620px; background-color: #dee9f9;" border="0" cellpadding="0" cellspacing="0" class="css">
            
            <tr style="height: 8px">
                <td style="width: 100%; height: 8px;background-color:royalblue">
                    </td>
               
            </tr>
            <tr style="height: 205px">
                <td colspan="3" style="vertical-align: top; text-align: left; height: 205px; width: 761px;">
                  
                    <table style="width: 760px">
                    <tr>
                    <td style="width:27%; height: 57px;">
                        <asp:Label ID="Label1" runat="server" Text="题目来源："></asp:Label>
                        <asp:DropDownList ID="TimuLaiyuanDDL" runat="server" DataSourceID="AccessDataSource1"
                            DataTextField="TL_Name" DataValueField="TL_No" AppendDataBoundItems="True">
                        </asp:DropDownList>
                        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/data/paper.mdb"
                            SelectCommand="SELECT [TL_No], [TL_Name] FROM [TimuLaiyuan]" 
                            OldValuesParameterFormatString="original_{0}"></asp:AccessDataSource>
                    </td>
                   
                    <td style="width:23%; height: 57px;">
                        <asp:Label ID="Label2" runat="server" Text="课题类型："></asp:Label>
                        <asp:DropDownList ID="KeTiTypeDDL" runat="server" DataSourceID="AccessDataSource2"
                            DataTextField="TT_Name" DataValueField="TT_No" Width="160px" 
                            AppendDataBoundItems="True">
                        </asp:DropDownList><asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~/data/paper.mdb"
                            SelectCommand="SELECT [TT_No], [TT_Name] FROM [TimuType]"></asp:AccessDataSource>
                       
                    
                    </td>
                    <td style="width:25%; height: 57px;">
                        <asp:Label ID="Label3" runat="server" Text="专业方向："></asp:Label>
                        <asp:DropDownList ID="ZhuanyeDDL" runat="server" 
                            DataSourceID="Accesszhuanyefangxiang" DataTextField="ZA_Name" 
                            DataValueField="ZA_No" Width="160px" AppendDataBoundItems="True">
                        </asp:DropDownList><asp:AccessDataSource ID="Accesszhuanyefangxiang" runat="server"
                            DataFile="~/data/paper.mdb" SelectCommand="SELECT [ZA_No], [ZA_Name] FROM [ZhuanyeArrow]">
                        </asp:AccessDataSource>
                    </td>
                    </tr>
                    
                    <tr>
                    <td style="width:27%; height: 63px;">
                        <asp:Label ID="Label5" runat="server" Text="教师姓名："></asp:Label>
                        <asp:TextBox ID="teacherTBox" runat="server" Width="160px" Enabled="false"></asp:TextBox></td>
                    <td style="width:23%; height: 63px;"> <asp:Label ID="Label4" runat="server" Text="所属教研室："></asp:Label>
                        <asp:DropDownList ID="JysDDL" runat="server" DataSourceID="Accessjys" DataTextField="Jys_Name"
                            DataValueField="Jys_No" AppendDataBoundItems="True">
                        </asp:DropDownList><asp:AccessDataSource ID="Accessjys" runat="server" DataFile="~/data/paper.mdb"
                            SelectCommand="SELECT [Jys_No], [Jys_Name] FROM [Jiaoyanshi]"></asp:AccessDataSource></td>
                    <td style="width:25%; height: 63px;">
                        <asp:Label ID="Label6" runat="server" Text="论文题目："></asp:Label>
                        <asp:TextBox ID="timuNameTBox" runat="server" Width="160px"></asp:TextBox></td>
                   
                    </tr>
                     <tr>
                    <td style="width:27%; height: 63px;">
                        <asp:Label ID="Label8" runat="server" Text="教师职称："></asp:Label>
                        <asp:TextBox ID="TeazcTBox" runat="server" Width="158px" Enabled="false"></asp:TextBox></td>
                    <td style="width:23%; height: 63px;"> <asp:Label ID="Label10" runat="server" Text="教师学历："></asp:Label>
                        <asp:TextBox ID="TeaxlTBox" runat="server" Width="158px" Enabled="false"></asp:TextBox></td>
                    <td style="width:25%; height: 63px;">
                        <asp:Label ID="Label11" runat="server" Text="教师学位："></asp:Label>
                        <asp:TextBox ID="TeaxwTBox" runat="server" Width="161px" Enabled="false"></asp:TextBox></td>
                   
                    </tr></table>
                    <table>
                      <tr>
                    <td style="width:20%; height: 271px;" align="center">
                        <asp:Label ID="Label7" runat="server" Text="题目简介："></asp:Label>
                        <asp:TextBox Height="228px" ID="TimuJianjieTBox" runat="server" TextMode="MultiLine" Width="311px"></asp:TextBox></td>
                   
                    <td style="width:23%; height: 271px;" align="center">
                        <asp:Label ID="Label9" runat="server" Text="完成题目应具备的基本条件："></asp:Label>
                        <asp:TextBox Height="226px" ID="TiaojianTBox" runat="server" TextMode="MultiLine" Width="373px"></asp:TextBox></td>
                   
                    </tr>
                    
                    </table>
                    <table>
                      <tr align="center">
                      <td style="width:380px; height: 20px;" >
                          &nbsp;</td>
                      <td style="width:380px; height: 20px;" >
                          &nbsp;</td>
                    <td style="width:415px; height: 20px;" align="right" >
                        <asp:Button ID="SendBT" runat="server" Text="提　交" BackColor="SteelBlue" ForeColor="White" OnClick="SendBT_Click" /></td>
                   
                    <td style="width:106px; height: 20px;" align="center">
                       <asp:Button ID="ReturnBT" runat="server" Text="返  回" 
                            BackColor="SteelBlue" ForeColor="White"  onclick="ReturnBT_Click" /></td>
                   
                    </tr>
                    
                    </table>
                </td>
            </tr>
            <tr style="height: 4px">
                <td style="width: 100%; height: 4px;background-color:royalblue">
                    </td>
               
            </tr>
              </table>
           
       
    </td></tr></table>
    </div>
    </form>
</body>
</html>
