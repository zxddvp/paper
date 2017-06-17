<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StuSelTeaMess.aspx.cs" Inherits="StuSelTeaMess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生查看教师信息页面</title>
     <link href="loginfont.css" type="text/css" rel="stylesheet"/>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <fieldset style=" border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F; width:670px;">
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>
    
        <table style="width:670px; border-bottom-color:Blue; border-left-color:Blue; border-right-color:Blue; border-top-color:Blue;" >
            <tr>
                <td style=" border:1; border-bottom-color:Lime;" >
                    <asp:Label ID="Label1" runat="server" Text="姓名：" Width="60px"></asp:Label>
                </td>
                <td >
                     <asp:Label ID="NameLbl" runat="server" Text=""></asp:Label>
                </td>
              </tr>
                <tr>
                <td >
                    <asp:Label ID="Label2" runat="server" Text="学历："></asp:Label>
                </td>
                    <td >
                        <asp:Label ID="XueliLbl" runat="server" Text=""></asp:Label>
                </td>
                 </tr>
                <tr>
                    <td style=" width:60px;">
                        <asp:Label ID="Label4" runat="server" Text="学位：" Width="60px"></asp:Label>
                </td>
                    <td>
                       <asp:Label ID="XueweiLbl" runat="server" Text=""></asp:Label>
                </td>
                 </tr>
                <tr>
                <td style=" width:60px;">
                        <asp:Label ID="Label16" runat="server" Text="职称："></asp:Label>
                </td>
                    <td>
                        <asp:Label ID="ZhichengLbl" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <%--<tr><td colspan ="8" style=" background-color:Black; height:1px;"></td></tr>--%>
            <tr>
                <td style=" width:60px;">
                    <asp:Label ID="Label3" runat="server" Text="性别："></asp:Label>
                </td>
                <td align="left">
                    
                    <asp:Label ID="SexTBox" runat="server" Width="200px" Height="19px" BackColor="#FFE4C4"></asp:Label>
                   
                    
                </td>
                 </tr>
                <tr>
                <td style=" width:80px;" align="left">
                    <asp:Label ID="Label6" runat="server" Text="毕业院校："></asp:Label>
                </td>
                    <td align="left" >
                        <asp:Label ID="SchoolTBox" runat="server" Width="200px" BackColor="#E6E6FA" ></asp:Label>
                        
                </td>
                 </tr>
                <tr>
                    <td style=" width:60px;">
                        <asp:Label ID="Label8" runat="server" Text="专业："></asp:Label>
                </td>
                    <td>
                        <asp:Label ID="ZhuanyeTBox" runat="server" Width="200px" BackColor="#FFE4C4"></asp:Label>
                       
                </td>
                 </tr>
                <tr>
                <td style=" width:80px;">
                        <asp:Label ID="Label5" runat="server" Text="研究方向："></asp:Label>
                </td>
                    <td>
                        <asp:Label ID="ArrowTBox" runat="server" Width="200px" BackColor="#E6E6FA"></asp:Label>
                       
                </td>
            </tr>
           <%-- <tr><td colspan ="8" style=" background-color:Black; height:1px; width:670px;"></td></tr>--%>
            <tr>
                <td >
                    <asp:Label ID="Label10" runat="server" Text="担任的主要课程："></asp:Label>
                </td>
                <td align="left" >
                    <asp:Label ID="CourseTBox" runat="server" TextMode="MultiLine" Width="540px" BackColor="#FFE4C4"></asp:Label>
                    
                </td>
                 </tr>
                <tr>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="教改课题及主要教改文章："></asp:Label>
                </td>
                    <td>
                        <asp:Label ID="JiaogaiTBox" runat="server" TextMode="MultiLine"  Width="540px" BackColor="#E6E6FA"></asp:Label>
                </td>
                   
            </tr>
            <%--<tr><td colspan ="8" style=" background-color:Black; height:1px;"></td></tr>--%>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="科研课题："></asp:Label>
                </td>
                <td  >
                    <asp:Label ID="TBoxKeyan" runat="server" TextMode="MultiLine"  Width="540px" BackColor="#FFE4C4"></asp:Label>
                </td>
                 </tr>
                  <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="主要学术论文："></asp:Label>
                </td>
                <td  >
                    <asp:Label ID="LblXueshulw" runat="server" TextMode="MultiLine"  Width="540px" BackColor="#FFE4C4"></asp:Label>
                </td>
                 </tr>
                <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="兴趣与爱好："></asp:Label>
                </td>
                    <td   >
                        <asp:Label ID="TBoxXingqu" runat="server" TextMode="MultiLine" Width="540px" BackColor="#E6E6FA"></asp:Label>
                </td>
                   
            </tr>
           <%-- <tr><td colspan ="8" style=" background-color:Black; height:1px;"></td></tr>--%>
            <tr><td></td><td align="center" >
                <asp:Button ID="BTReturn" runat="server" Text="返  回" BackColor="#FFE4C4" 
                    BorderWidth="2px" BorderColor="#E6E6FA" onclick="Button1_Click" />                    
                </td>
               </tr>
                
        </table>
    </fieldset>
    </div>
    </form>
</body>
</html>

