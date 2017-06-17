<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StuBasedMess.aspx.cs" Inherits="StuBasedMess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>更新学生信息页面</title>
     <link href="loginfont.css" type="text/css" rel="stylesheet"/>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <fieldset style=" border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F; width:670px;">
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>
    
        <table style="width:670px; border-bottom-color:Blue; border-left-color:Blue; border-right-color:Blue; border-top-color:Blue;" >
        <tr>
                <td colspan="2" style="height:80px">
                   <asp:Label ID="Label7" runat="server" 
                        Text="&nbsp; &nbsp;请认真填写您的基本信息，并保证信息真实、完整，指导教师将根据您填写的基本信息决定是否同意对您进行指导！" Font-Size="X-Large" 
                        Font-Bold="True" Font-Names="FangSong_GB2312" ForeColor="#006666"></asp:Label>
                </td>
                
              </tr>
            <tr>
                <td style=" border:1; border-bottom-color:Lime;" >
                   <asp:Label ID="Label2" runat="server" Text="学号："></asp:Label>
                </td>
                <td >
                     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="LblStuno" runat="server" Text=""></asp:Label>
                     <asp:Label ID="Label17" runat="server" Text="*以下所有的信息都为必填项，请填写完再提交。*" ForeColor="red"></asp:Label>
                </td>
              </tr>
                <tr>
                <td >
                     <asp:Label ID="Label1" runat="server" Text="姓名：" Width="60px"></asp:Label>
                </td>
                    <td >
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Lblstuname" runat="server" Text=""></asp:Label>
                        <asp:Label ID="Label11" runat="server" Text="*请仔细检查，不要出现错别字、不通顺的句子等。*" ForeColor="red"></asp:Label>
                </td>
                 </tr>
                <tr>
                    <td style=" width:60px;">
                        <asp:Label ID="Label4" runat="server" Text="班级：" Width="60px"></asp:Label>
                </td>
                    <td>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Lblclass" runat="server" Text=""></asp:Label>
                </td>
                 </tr>
                <tr>
                <td style=" width:60px;">
                        <asp:Label ID="Label16" runat="server" Text="专业："></asp:Label>
                </td>
                    <td>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Lblzhuanye" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <%--<tr><td colspan ="8" style=" background-color:Black; height:1px;"></td></tr>--%>
            <tr>
                <td style=" width:60px;">
                    <asp:Label ID="Label3" runat="server" Text="联系电话："></asp:Label>
                     
                </td>
                <td align="left">
                    
                    <asp:TextBox ID="TBoxStutel" runat="server" Width="200px" Height="19px" BackColor="#FFE4C4"></asp:TextBox>
                   
                    
                </td>
                 </tr>
                <tr>
                <td style=" width:80px;" align="left">
                    <asp:Label ID="Label6" runat="server" Text="所学课程："></asp:Label>
                   
                </td>
                    <td align="left" >
                        <asp:TextBox ID="TBoxstucourse" runat="server" TextMode="MultiLine" Height="80px" Width="540px" BackColor="#E6E6FA" ></asp:TextBox>
                        
                </td>
                 </tr>
                <tr>
                    <td style=" width:60px;">
                        <asp:Label ID="Label8" runat="server" Text="兴趣爱好："></asp:Label>
                        
                </td>
                    <td>
                        <asp:TextBox ID="TBoxStuaihao" runat="server" TextMode="MultiLine" Height="80px" Width="540px" BackColor="#FFE4C4"></asp:TextBox>
                       
                </td>
                 </tr>
                <tr>
                <td style=" width:80px;">
                        <asp:Label ID="Label5" runat="server" Text="获奖情况："></asp:Label>
                        
                </td>
                    <td>
                        <asp:TextBox ID="TBoxstuhuojiang" runat="server" TextMode="MultiLine" Height="80px" Width="540px" BackColor="#E6E6FA"></asp:TextBox>
                       
                </td>
            </tr>
           <%-- <tr><td colspan ="8" style=" background-color:Black; height:1px; width:670px;"></td></tr>--%>
            <tr>
                <td >
                    <asp:Label ID="Label10" runat="server" Text="自我评价："></asp:Label>
                  
                </td>
                <td align="left" >
                    <asp:TextBox ID="TBoxStuziping" runat="server" TextMode="MultiLine" Height="80px" Width="540px" BackColor="#FFE4C4"></asp:TextBox>
                    
                </td>
                 </tr>
                <%--<tr>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="教改课题及主要教改文章："></asp:Label>
                </td>
                    <td>
                        <asp:TextBox ID="JiaogaiTBox" runat="server" TextMode="MultiLine" Height="100px" Width="540px" BackColor="#E6E6FA"></asp:TextBox>
                         <FCKeditorV2:FCKeditor ID="JiaogaiTBox" ToolbarSet="Hugobasic" runat="server" Height="150px" width="600px"></FCKeditorV2:FCKeditor>
                </td>
                   
            </tr>--%>
           
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