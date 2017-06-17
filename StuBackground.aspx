<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StuBackground.aspx.cs" Inherits="StuBackground" %>


<script src="js/common.js" type="text/jscript"></script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <title>数信学院毕业论文（设计）管理系统</title>    
   <link href="loginfont.css" type="text/css" rel="stylesheet"/>

<%--<link href="CSS/css.css" rel="stylesheet" type="text/css" />
--%>   <%-- <asp:contentplaceholder id="head" runat="Server">
</asp:contentplaceholder>--%>
</head>
<body style="margin-left:0; margin-top:0;">
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
                    <td style="background-color: #375e9f; font-size:12px; color:#ffffff; height:20px;">今天是：&nbsp;&nbsp;<script type="text/javascript">TodayDate();</script>
                    <%--<asp:Label ID="Label1" runat="server"></asp:Label>--%>
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <%-- <asp:LinkButton ID="LinkButton10" runat="server" style="color: #ffffff" PostBackUrl="http://www.njtc.edu.cn">进入内江师范学院</asp:LinkButton>--%>
                        <asp:Label ID="Label2" runat="server">你好！<%=stuname%>，欢迎光临数信学院毕业论文(设计)管理系统 V1.0</asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" style="color: #FF0000">
                    * 各位同学您一旦选题便不能更改，请慎重！*
                        <br />
                        * 在选题前，请先了解“本科毕业论文写作意义”、“教师信息”、“选题指南”、“题目详细信息”。*
                        <br />
                        * 请保证您输入的联系方式准确。*
                        <br />
                        * 谢谢合作，祝同学们顺利完成毕业论文！*
                        
                       <%-- <table cellpadding="0" cellspacing="0" style="height:30px; font-size:12px;" width="100%">
                            <tr>
                                <td style="background-color: #d9e8ff; width: 80px; text-align:center; height: 30px;">
                                <a href="" target="right">待定</a>
                                </td>
                                <td style="width: 2px; height: 30px;">&nbsp;</td>
                                <td style="background-color: #d9e8ff;width: 80px; text-align:center; height: 30px;">
                                <a href="" target="right">待定</a>
                                </td>
                                <td style="width: 2px; height: 30px;">&nbsp;</td>
                                <td style="background-color: #d9e8ff;width: 80px; text-align:center; height: 30px;">
                                    &nbsp;<a href="" target="right">待定</a></td>
                                <td style="width: 2px; height: 30px;">&nbsp;</td>
                                <td style="height: 30px">&nbsp;</td>
                            </tr>
                        </table>--%>
                    </td>
                   
                </tr>
            </table>
            
            </td>
        </tr>
    </table>
    <table cellpadding="5" cellspacing="0" width="100%" style=" height:450px; border-right: #385e9f thin solid; border-top: #385e9f thin solid; border-left: #385e9f thin solid; border-bottom: #385e9f thin solid;">
        <tr>
            <td style=" width:100px;text-align:center; height: 100px; vertical-align:top;">
            
            <table id="Table1" cellpadding="3" cellspacing="0" runat="server">
                <tr>
                <td id="Td1" style="background-color: #385e9f; width: 157px;" runat="server">
                <table  width="150px" style="font-size:12px; height:25px;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="background-image: url(img/titlemu_2.gif); text-align:left; font: smallcaption; color: White; height: 23px;" colspan="2">
                            毕业论文（设计）管理</td>
                    </tr>
                </table>
               <%-- <table  width="150px" style="font-size:12px; height:25px;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="background-image: url(img/titlemu_2.gif); text-align:left; font: smallcaption; color: #707da7; height: 23px; width: 153px;">
                            &nbsp;论文管理</td>
                        <td style=" background-image: url(img/titlemu_2.gif); height: 23px;">
                           <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/images/jt.JPG" OnClick="ImageButton1_Click"/></td>
                    </tr>
                </table>--%>
                    <table width="150px" id="Table2" runat="server" visible="true" style="background-color:#E5ECF6; font-size:12px;border-right: #79b7cf 1px solid;border-left: #79b7cf 1px solid; border-bottom: #79b7cf 1px solid;">
                        <tr>
                            <td style="text-align:left; height:25px;">
                                &nbsp;<a href="StuThesisYiyi.htm" target="right">本科毕业论文写作意义</a></td>
                        </tr>
                        <tr>
                            <td style="text-align:left; height:25px; border-top: #d3d3d3 1px solid;">
                                &nbsp;<a href="StuTeaList.aspx" target="right">教师简介</a></td>
                        </tr>
                        <tr>
                            <td style="border-top: #d3d3d3 1px solid; height: 25px; text-align: left">
                                &nbsp;<a href="StuXuantiZhinan.htm" target="right">选题指南</a></td>
                        </tr>
                         <tr>
                            <td style="border-top: #d3d3d3 1px solid; height: 25px; text-align: left">
                                &nbsp;<a href="StuBasedMess.aspx" target="right">更新基本信息</a></td>
                        </tr>
                         <tr>
                            <td style="border-top: #d3d3d3 1px solid; height: 25px; text-align: left">
                                &nbsp;<a href="Student.aspx" target="right">题目信息</a></td>
                        </tr>
                        <tr>
                            <td style="border-top: #d3d3d3 1px solid; height: 25px; text-align: left">
                                &nbsp;<a href="StuSeathesisJZ.aspx" target="right">查看题目</a></td>
                        </tr>
                         <tr>
                            <td style="border-top: #d3d3d3 1px solid; height: 25px; text-align: left">
                                &nbsp;<a href="StuPinJiaTea.aspx" target="right">评价教师</a></td>
                        </tr>
                        <tr>
                            <td style="border-top: #d3d3d3 1px solid; height: 25px; text-align: left">
                                &nbsp;<a href="StuThesisScore.aspx" target="right">查看成绩</a></td>
                        </tr>
                         <tr>
                            <td style="border-top: #d3d3d3 1px solid; height: 25px; text-align: left">
                                &nbsp;<a href="UpdataPSW.aspx" target="right">修改密码</a></td>
                        </tr>
                    </table>
            </td>
        </tr>
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
               <%-- <tr style="color: #000000">
                    <td style="width: 157px; background-color: #385e9f">
                        <table  width="150px" style="font-size:12px; height:25px;" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="background-image: url(img/titlemu_2.gif); text-align:left; font: smallcaption; color: #707da7; height: 23px;" colspan="2">
                                    &nbsp;待定</td>
                            </tr>
                        </table>
                        <table width="150px" id="Table4" runat="server" visible="true" style="background-color:#E5ECF6; font-size:12px;border-right: #79b7cf 1px solid;border-left: #79b7cf 1px solid; border-bottom: #79b7cf 1px solid;">
                            <tr>
                                <td style="text-align:left; height:25px;">
                                    &nbsp;
                                    <asp:LinkButton ID="index" runat="server"></asp:LinkButton></td>
                            </tr>
                        </table>
                    </td>
                </tr>--%>
                </table></td>
            <td style="border-left: #385e9f thin solid; width: 1px; height: 100px; text-align: center">
                &nbsp;</td>
            <td style="height: 100px; width:700px;">
                &nbsp;<iframe src="StuXuantiZhinan.htm" id="cwin" width="700" height="700" name="right" frameborder="0"> <div>
       <%-- <asp:contentplaceholder id="ContentPlaceHolder1" runat="server">
        </asp:contentplaceholder>--%>
       
    </div></iframe>
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

