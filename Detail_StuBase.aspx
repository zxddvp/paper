<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Detail_StuBase.aspx.cs" Inherits="Detail_StuBase" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>教师查看学生详细信息</title>
     <link href="loginfont.css" type="text/css" rel="stylesheet"/>
</head>


<body style="margin-top: 0px; margin-bottom: 0px; margin-right:0px; margin-left:0px" >
    <form id="form2" runat="server">
    <div>
    <fieldset style=" width:680px; border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F;">
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>
        <table style="width: 680px; height: 600px;" border="0" cellpadding="0" cellspacing="0">
         
            <tr style="height: 205px">
                <td colspan="3" style="vertical-align: top; text-align: left; height: 205px; width: 100%;">
                  
                    <table style="width: 100%">
                    <tr>
                    <td style="width:27%; height: 57px;">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label1" runat="server" Text="学号：" Font-Bold="True" 
                            ForeColor="#006600" ></asp:Label>
                        <asp:Label ID="Lblstuno" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                       <tr>
                    <td style="width:23%; height: 57px;"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label2" runat="server" Text="姓名："   Font-Bold="True" 
                            ForeColor="#006600"></asp:Label>
                        <asp:Label ID="Lblstuname" runat="server" Text="Label"></asp:Label>
                    </td>
                     </tr>
                        <tr>
                    <td style="width:25%; height: 57px;"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label3" runat="server" Text="班级：" Font-Bold="True" 
                            ForeColor="#006600"></asp:Label>
                        <asp:Label ID="Lblstuclass" runat="server" Text="Label"></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td style="width:25%; height: 57px;"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label4" runat="server" Text="专业：" Font-Bold="True" 
                            ForeColor="#006600"></asp:Label>
                        <asp:Label ID="Lblstuzhuanye" runat="server" Text="Label"></asp:Label>
                    </td>
                    </tr>
                    
                    <tr>
                    <td style="width:27%; height: 63px;"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label5" runat="server" Text="联系方式：" Font-Bold="True" 
                            ForeColor="#006600"></asp:Label>
                        <asp:Label ID="Lblstutel" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                        <tr>
                    <td style="width:25%; height: 63px;"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label6" runat="server" Text="主要课程：" Font-Bold="True" 
                            ForeColor="#006600"></asp:Label>
                        <asp:Label ID="Lblstucourse" runat="server" Text="Label"></asp:Label>
                        </td>
                   
                    </tr>
                    </table>
                    <table>
                      <tr>
                    <td style="width:20%; height:100px;"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label7" runat="server" Text="获奖情况：" Font-Bold="True" 
                            ForeColor="#006600"></asp:Label><br />
                        <asp:Label ID="Lblstuhuojiang" runat="server" Text="Label"></asp:Label>
                          </td>
                    </tr>
                        <tr>
                    <td style="width:23%; height:100px;" > &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label9" runat="server" Text="兴趣爱好：" Font-Bold="True" 
                            ForeColor="#006600"></asp:Label><br />
                        <asp:Label ID="Lblstuaihao" runat="server" Text="Label"></asp:Label>
                          </td>
                   
                    </tr>
                     <tr>
                    <td style="width:23%; height:100px;" > &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label8" runat="server" Text="自我评价：" Font-Bold="True" 
                            ForeColor="#006600"></asp:Label><br />
                        <asp:Label ID="Lblstuziwopj" runat="server" Text="Label"></asp:Label>
                          </td>
                   
                    </tr>
                    
                        <tr>
                        <td align="center">
                        <asp:Button ID="ReturnBT" runat="server" Text="返   回" Visible="true" onclick="ReturnBT_Click" />
                    </td>
                   </tr>
                   </table>
                   </td>
           </tr>
              </table>
              </fieldset>
    </div>
    </form>
</body>
</html>
