<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UadiminBackground.aspx.cs" Inherits="UadiminBackground" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>数信学院毕业论文（设计）管理系统</title>    
   <link href="loginfont.css" type="text/css" rel="stylesheet"/>

<%--<link href="CSS/css.css" rel="stylesheet" type="text/css" />
--%>
</head>
<body style=" margin-left:0; margin-top:0;">
 <form id="form1" runat="server">
    <div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" style="height:100px; background-color:#C5D8FF; border-top: #385e9f thin solid; border-right: #385e9f thin solid; border-left: #385e9f thin solid;">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td rowspan="2" style="width: 268px; background-color:#C5D8FF;">
                    <img src="img/images/welcome.png" alt="" />
                    </td>
                    <td style="height: 28px; width:28px;"><img src="img/images/123.jpg" alt=""  width="28px"/></td>
                    <td style="background-color: #375e9f; font-size:12px; color:#ffffff;">今天是：&nbsp;&nbsp;<script type="text/javascript">TodayDate();</script>
                    <%--<asp:Label ID="Label1" runat="server"></asp:Label>--%>
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <%-- <asp:LinkButton ID="LinkButton10" runat="server" style="color: #ffffff" PostBackUrl="http://www.njtc.edu.cn">进入内江师范学院</asp:LinkButton>--%>
                        <asp:Label ID="Label2" runat="server">
                       你好！<%=supname%>,你是系统管理员。欢迎光临数学与信息科学学院毕业论文（设计）管理系统 V1.0！</asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" style="color: #FF0000">
                     
                        <br />
                    
                        <br />
                       
                        <br />
                        <table cellpadding="0" cellspacing="0" style="height:30px; font-size:12px;" width="100%">
                            <tr><td><span id="OutputMsg" EnableViewState="false" runat="server"/>
                            </td>
                           
                                <%--<td style="background-color: #d9e8ff; width: 80px; text-align:center; height: 30px;">
                                <a href="TeaPSW.aspx" target="right">上传题目</a>
                                </td>
                                <td style="width: 2px; height: 30px;">&nbsp;</td>
                                <td style="background-color: #d9e8ff;width: 80px; text-align:center; height: 30px;">
                                <a href="" target="right">待定</a>
                                </td>
                                <td style="width: 2px; height: 30px;">&nbsp;</td>
                                <td style="background-color: #d9e8ff;width: 80px; text-align:center; height: 30px;">
                                    &nbsp;<a href="" target="right">待定</a></td>
                                <td style="width: 2px; height: 30px;">&nbsp;</td>
                                <td style="height: 30px">&nbsp;</td>--%>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            
            </td>
        </tr>
    </table>
    <table cellpadding="5" cellspacing="0" width="100%" style=" height:450px; border-right: #385e9f thin solid; border-top: #385e9f thin solid; border-left: #385e9f thin solid; border-bottom: #385e9f thin solid;">
        <tr>
            <td style=" text-align:center; vertical-align:top; width:150px">
            
            <table id="Table1" cellpadding="3" cellspacing="0" runat="server">
                <tr>
                <td id="Td1" style="background-color: #385e9f; width: 150px;" runat="server">
                <table  width="150px" style="font-size:12px; height:25px;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="background-image: url(img/titlemu_2.gif); text-align:left; font: smallcaption; color: White; height: 23px;" colspan="2">
                            毕业论文（设计）管理</td>
                    </tr>
                </table>
               <%-- <table  width="150px" style="font-size:12px; height:25px;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="background-image: url(img/titlemu_2.gif); text-align:left; font: smallcaption; color: White; height: 23px; width: 153px;">
                            &nbsp;论文管理</td>
                        <td style=" background-image: url(img/titlemu_2.gif); height: 23px;">
                           <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/images/jt.JPG" OnClick="ImageButton1_Click"/></td>
                    </tr>
                </table>--%>
                    <table width="150px" id="Table2" runat="server" visible="true" style="background-color:#E5ECF6; font-size:12px;border-right: #79b7cf 1px solid;border-left: #79b7cf 1px solid; border-bottom: #79b7cf 1px solid;">
                        <tr>
                            <td style="text-align:left; height:25px;">
                                &nbsp;<a href="Useradimin.aspx" target="right">基本业务</a></td>
                        </tr>
                        <tr>
                            <td style="text-align:left; height:25px;">
                                &nbsp;<a href="gonggao/ggFirst.aspx" target="right">发布公告</a></td>
                        </tr>
                        <tr>
                            <td style="text-align:left; height:25px;">
                                &nbsp;<a href="AdminStuPJTea.aspx" target="right">查看学生评价教师平均分</a></td>
                        </tr>
                        
                        <tr>
                            <td style="border-top: #d3d3d3 1px solid; height: 25px; text-align: left">
                                &nbsp;<a href="SystemAdminPSW.aspx" target="right">修改密码</a></td>
                        </tr>
                        
                    </table>
            </td>
        </tr>
       
                <%--<tr style="color: #000000">
                    <td style="width: 157px; background-color: #385e9f">
                        <table  width="150px" style="font-size:12px; height:25px;" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="background-image: url(img/titlemu_2.gif); text-align:left; font: smallcaption; color: White; height: 23px;" colspan="2">
                                    &nbsp;论文查阅</td>
                            </tr>
                        </table>
                        <table width="150px" id="Table4" runat="server" visible="true" style="background-color:#E5ECF6; font-size:12px;border-right: #79b7cf 1px solid;border-left: #79b7cf 1px solid; border-bottom: #79b7cf 1px solid;">
                            
                             <tr>
                            <td style="border-top: #d3d3d3 1px solid; height: 25px; text-align: left">
                                &nbsp;<a href="TeaSearch.aspx" target="right">查看上传题目</a></td>
                        </tr>
                         <tr>
                            <td style="border-top: #d3d3d3 1px solid; height: 25px; text-align: left">
                                &nbsp;<a href="teaSeaSelect.aspx" target="right">查看选题情况</a></td>
                        </tr>
                        </table>
                    </td>
                </tr>--%>
                 <tr style="color: #000000">
            <td style="background-color: #385e9f; width: 157px;">
                <table  width="150px" style="font-size:12px; height:25px;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="background-image: url(img/titlemu_2.gif); text-align:left; font: smallcaption; color: #707da7; height: 23px;" colspan="2">
                            &nbsp;</td>
                    </tr>
                    
                </table>
                <table width="150px" id="Table3" runat="server" visible="true" style="background-color:#E5ECF6; font-size:12px;border-right: #79b7cf 1px solid;border-left: #79b7cf 1px solid; border-bottom: #79b7cf 1px solid;">
                    <tr>
                        <td style="text-align:left; height:25px;">
                            &nbsp; 
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">注销登陆</asp:LinkButton></td>
                    </tr>
                </table>
            </td>
        </tr>
                </table></td>
            <td style="border-left: #385e9f thin solid; width: 1px; height: 100px; text-align: center">
                &nbsp;</td>
            <td style="height: 700; width:700px;">
                &nbsp;<iframe src="Useradimin.aspx" id="cwin"  name="right" height="900" width="1200px" frameborder="0" marginheight="0" marginwidth="0"></iframe>
       
   
            </td>
        </tr>
        
    </table>
    </div>
    <div style="text-align:center; font-size:12px;">
        数信学院毕业论文（设计）管理系统<br />
        </div>
        

   </form>
</body>
</html>


