<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeaPSW.aspx.cs" Inherits="TeaPSW" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>教师更改密码页面</title>
     <link href="loginfont.css" type="text/css" rel="stylesheet"/>
</head>

<body style="margin-top: 0px; margin-bottom: 0px; margin-right:0px; margin-left:0px" class="css">
    <form id="form2" runat="server">
    <div>
    <fieldset style=" border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F;">
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>
    <table>
    <tr>
    <td style="width:25%"></td>
    <td>
        <table style="width: 560px; " border="0" cellpadding="0" cellspacing="0" class="css">
         <%--   
            <tr style="height: 8px">
                <td style="width: 100%; height: 8px;background-color:royalblue">
                    </td>
               
            </tr>--%>
            <tr>
                <td colspan="3" style="vertical-align: top; text-align: left; height: 205px; width:535px;">
                  
                    <table style="width:600px">
                    
                    <tr>
                    
                    <td style="width:23%; height: 63px;"> &nbsp;
                            <table border="0" cellpadding="4" cellspacing="0" style="border-collapse: collapse">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" style="width: 531px; height: 393px">
                                           <%-- <tr>
                                                <td align="center" colspan="2" style="font-weight: bold; font-size: 1.2em; color: white;
                                                    background-color: #1c5e55">
                                                    更改密码</td>
                                            </tr>--%>
                                             <tr>
                                                <td align="right" style="width: 169px">
                                                    <asp:Label ID="Label1" runat="server" AssociatedControlID="StunoTBox"
                                                        Font-Size="Larger">教工号：</asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="StunoTBox" runat="server" Font-Size="0.8em" TextMode="SingleLine"
                                                        Width="156px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="StunoTBox"
                                                        ErrorMessage="必须填写“学号”。" ToolTip="必须填写“学号”。" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 169px">
                                                    <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword"
                                                        Font-Size="Larger">密    码：</asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="CurrentPassword" runat="server" Font-Size="0.8em" TextMode="Password"
                                                        Width="156px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                                        ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 169px">
                                                    <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword"
                                                        Font-Size="Larger">新密码:</asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="NewPassword" runat="server" Font-Size="0.8em" TextMode="Password"
                                                        Width="156px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                                        ErrorMessage="必须填写“新密码”。" ToolTip="必须填写“新密码”。" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 169px">
                                                    <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword"
                                                        Font-Size="Larger">确认新密码:</asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="ConfirmNewPassword" runat="server" Font-Size="0.8em" TextMode="Password"
                                                        Width="156px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                                        ErrorMessage="必须填写“确认新密码”。" ToolTip="必须填写“确认新密码”。" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                                        ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="“确认新密码”与“新密码”项必须匹配。"
                                                        ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color: red">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 169px">
                                                    <asp:Button ID="ChangePasswordPushButton" runat="server" BackColor="White" BorderColor="#C5BBAF"
                                                        BorderStyle="Solid" BorderWidth="1px" CommandName="ChangePassword" Font-Names="Verdana"
                                                        Font-Size="Larger" ForeColor="#1C5E55" Height="25px" OnClick="ChangePasswordPushButton_Click"
                                                        Text="更改密码" ValidationGroup="ChangePassword1" Width="73px" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="CancelPushButton" runat="server" BackColor="White" BorderColor="White"
                                                        BorderStyle="Solid" BorderWidth="1px" CausesValidation="False" CommandName="Cancel"
                                                        Font-Names="Verdana" Font-Size="Larger" ForeColor="#1C5E55" OnClick="CancelPushButton_Click"
                                                        Text="取  消" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                       
                    </td>
                   
                    </tr></table>
                    
                    <table>
                      <tr align="center">
                      <td style="width:380px; height: 20px;" >
                          <asp:Button ID="BackBt" runat="server" Text="返  回"  BackColor="SteelBlue" ForeColor="White" OnClick="BackBt_Click" />
                          </td>
                    <td style="width:415px; height: 20px;" align="right" >
                        </td>
                   
                    <td style="width:106px; height: 20px;" align="center">
                        </td>
                   
                    </tr>
                    
                    </table>
                </td>
            </tr>
           <%-- <tr style="height: 4px">
                <td style="width: 100%; height: 4px;background-color:royalblue">
                    </td>
               
            </tr>--%>
              </table>
           
       
    </td></tr></table>
    </fieldset>
    </div>
    </form>
</body>
</html>
