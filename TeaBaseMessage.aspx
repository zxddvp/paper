<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeaBaseMessage.aspx.cs" Inherits="TeaBaseMessage" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>更新教师信息页面</title>
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
                     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="NameLbl" runat="server" Text=""></asp:Label>
                     <asp:Label ID="Label17" runat="server" Text="*名称后面有“*”标记的为必填项，请填写完再提交。*" ForeColor="red"></asp:Label>
                </td>
              </tr>
                <tr>
                <td >
                    <asp:Label ID="Label2" runat="server" Text="学历："></asp:Label>
                </td>
                    <td >
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="XueliLbl" runat="server" Text=""></asp:Label>
                        <asp:Label ID="Label11" runat="server" Text="*为了避免您的重复填写，请仔细检查，不要出现错别字、不通顺的句子等。*" ForeColor="red"></asp:Label>
                </td>
                 </tr>
                <tr>
                    <td style=" width:60px;">
                        <asp:Label ID="Label4" runat="server" Text="学位：" Width="60px"></asp:Label>
                </td>
                    <td>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="XueweiLbl" runat="server" Text=""></asp:Label>
                </td>
                 </tr>
                <tr>
                <td style=" width:60px;">
                        <asp:Label ID="Label16" runat="server" Text="领导审核结果：" ForeColor="DarkBlue" Font-Bold="true"></asp:Label>
                </td>
                    <td>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="XLShenhe" runat="server" Text=""></asp:Label>
                </td>
            </tr>
             <tr>
                <td style=" width:60px;">
                        <asp:Label ID="Label21" runat="server" Text="领导的修改意见：" ForeColor="DarkBlue"></asp:Label>
                </td>
                    <td>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="XLXiugai" runat="server" Text=""></asp:Label>
                </td>
            </tr>
             <tr>
                <td style=" width:60px;">
                        <asp:Label ID="Label23" runat="server" Text="职称："></asp:Label>
                </td>
                    <td>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="ZhichengLbl" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <%--<tr><td colspan ="8" style=" background-color:Black; height:1px;"></td></tr>--%>
            <tr>
                <td style=" width:60px;">
                    <asp:Label ID="Label3" runat="server" Text="性别："></asp:Label>
                     <asp:Label ID="Label13" runat="server" Text="*" ForeColor="red"></asp:Label>
                </td>
                <td align="left">
                    
                    <asp:TextBox ID="SexTBox" runat="server" Width="200px" Height="19px" BackColor="#FFE4C4"></asp:TextBox>
                   
                    
                </td>
                 </tr>
                <tr>
                <td style=" width:80px;" align="left">
                    <asp:Label ID="Label6" runat="server" Text="毕业院校："></asp:Label>
                    <asp:Label ID="Label14" runat="server" Text="*" ForeColor="red"></asp:Label>
                </td>
                    <td align="left" >
                        <asp:TextBox ID="SchoolTBox" runat="server" Width="200px" BackColor="#E6E6FA" ></asp:TextBox>
                        
                </td>
                 </tr>
                <tr>
                    <td style=" width:60px;">
                        <asp:Label ID="Label8" runat="server" Text="专业："></asp:Label>
                         <asp:Label ID="Label15" runat="server" Text="*" ForeColor="red"></asp:Label>
                </td>
                    <td>
                        <asp:TextBox ID="ZhuanyeTBox" runat="server" Width="200px" BackColor="#FFE4C4"></asp:TextBox>
                       
                </td>
                 </tr>
                <tr>
                <td style=" width:80px;">
                        <asp:Label ID="Label5" runat="server" Text="研究方向："></asp:Label>
                         <asp:Label ID="Label18" runat="server" Text="*" ForeColor="red"></asp:Label>
                </td>
                    <td>
                        <asp:TextBox ID="ArrowTBox" runat="server" Width="200px" BackColor="#E6E6FA"></asp:TextBox>
                       
                </td>
            </tr>
           <%-- <tr><td colspan ="8" style=" background-color:Black; height:1px; width:670px;"></td></tr>--%>
            <tr>
                <td >
                    <asp:Label ID="Label10" runat="server" Text="担任的主要课程："></asp:Label>
                    <asp:Label ID="Label19" runat="server" Text="*" ForeColor="red"></asp:Label>
                </td>
                <td align="left" >
                    <asp:TextBox ID="CourseTBox" runat="server" TextMode="MultiLine" Height="80px" Width="540px" BackColor="#FFE4C4"></asp:TextBox>
                    
                </td>
                 </tr>
                <tr>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="教改课题及主要教改文章："></asp:Label>
                </td>
                    <td>
                        <%--<asp:TextBox ID="JiaogaiTBox" runat="server" TextMode="MultiLine" Height="100px" Width="540px" BackColor="#E6E6FA"></asp:TextBox>--%>
                         <FCKeditorV2:FCKeditor ID="JiaogaiTBox" ToolbarSet="Hugobasic" runat="server" Height="150px" width="600px"></FCKeditorV2:FCKeditor>
                </td>
                   
            </tr>
            <%--<tr><td colspan ="8" style=" background-color:Black; height:1px;"></td></tr>--%>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="科研课题："></asp:Label>
                </td>
                <td  >
                    <%--<asp:TextBox ID="TBoxKeyan" runat="server" TextMode="MultiLine" Height="100px" Width="540px" BackColor="#FFE4C4"></asp:TextBox>--%>
                    <FCKeditorV2:FCKeditor ID="TBoxKeyan" ToolbarSet="Hugobasic" runat="server" Height="150px" width="600px"></FCKeditorV2:FCKeditor>
                </td>
                 </tr>
                  <tr>
                <td>
                    <asp:Label ID="Label20" runat="server" Text="主要学术论文："></asp:Label>
                </td>
                <td  >
                    <%--<asp:TextBox ID="TBoxKeyan" runat="server" TextMode="MultiLine" Height="100px" Width="540px" BackColor="#FFE4C4"></asp:TextBox>--%>
                    <FCKeditorV2:FCKeditor ID="TBoxXueshulw" ToolbarSet="Hugobasic" runat="server" Height="150px" width="600px"></FCKeditorV2:FCKeditor>
                </td>
                 </tr>
                <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="兴趣与爱好："></asp:Label>
                </td>
                    <td   >
                        <asp:TextBox ID="TBoxXingqu" runat="server" TextMode="MultiLine" Height="40px" Width="540px" BackColor="#E6E6FA"></asp:TextBox>
                </td>
                   
            </tr>
           <%-- <tr><td colspan ="8" style=" background-color:Black; height:1px;"></td></tr>--%>
            <tr><td></td><td align="center" >
                <asp:Button ID="Button1" runat="server" Text="确  定" BackColor="#FFE4C4" 
                    BorderWidth="2px" BorderColor="#E6E6FA" onclick="Button1_Click" />                    
                </td>
               </tr>
               
        </table>
    </fieldset>
    </div>
    </form>
</body>
</html>
