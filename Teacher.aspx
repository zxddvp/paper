<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="Teacher.aspx.cs" Inherits="Teacher"  %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>教师上传题目页面</title>
     <link href="loginfont.css" type="text/css" rel="stylesheet"/>
    
</head>

<body style="margin-top: 0px; margin-bottom: 0px; margin-right:0px; margin-left:0px" >

<form id="form1" runat="server">
    <div>
    <fieldset style=" width:790px; border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F;">
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>
    
        <table style="width: 100%;  height:600; border-color:#004156" border="0" cellpadding="0" cellspacing="0" >
           
            <tr style="height: 205px">
                <td colspan="3" style="vertical-align: top; text-align: left; height: 205px; width: 100%;">
                  <table style="width: 100%; height:10px; border-color:#004156;" border="0">
                    <tr><td  align="center">
                        <asp:Label ID="Label12" 
                            runat="server" Text="数信学院毕业论文（设计）题目申报表" Font-Size="X-Large" 
                            ForeColor="#993300" Font-Bold="False" Font-Names="黑体"></asp:Label></td></tr>
                    </table>
                    <table style="width: 680px; height:60px; border-color:#004156;" border="0" >
                    <tr>
                    <td style=" height:20px; width:80px;">
                        <asp:Label ID="Label5" runat="server" Text="教师姓名："></asp:Label>
                        <asp:Label ID="Label23" runat="server" Text="*" ForeColor="red"></asp:Label>
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="teacherTBox" runat="server" Width="112px" Enabled="False"></asp:Label></td>
                        </tr>
                     <tr>
                    <td style=" height:20px; width:80px;">
                        <asp:Label ID="Label8" runat="server" Text="教师职称："></asp:Label>
                        <asp:Label ID="Label22" runat="server" Text="*" ForeColor="red"></asp:Label>
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="TeazcTBox" runat="server" Width="103px" Enabled="False"></asp:Label></td>
                        </tr>
                        <tr>
                    <td style="width:80px; height: 20px;"> <asp:Label ID="Label10" runat="server" Text="教师学历："></asp:Label>
                    <asp:Label ID="Label21" runat="server" Text="*" ForeColor="red"></asp:Label>
                    </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="TeaxlTBox" runat="server" Width="98px" Enabled="False"></asp:Label></td>
                        </tr>
                        <tr>
                    <td style=" height:20px; width:80px;">
                        <asp:Label ID="Label11" runat="server" Text="教师学位："></asp:Label>
                        <asp:Label ID="Label20" runat="server" Text="*" ForeColor="red"></asp:Label>
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="TeaxwTBox" runat="server" Width="99px" Enabled="False"></asp:Label></td>
                   
                    </tr>
                    
                    <tr>
                    <td  style=" height:20px; width:80px;">
                        <asp:Label ID="Label1" runat="server" Text="题目来源："></asp:Label>
                       <asp:Label ID="Label13" runat="server" Text="*" ForeColor="red"></asp:Label>
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="TimuLaiyuanDDL" runat="server" DataSourceID="AccessDataSource1"
                            DataTextField="TL_Name" DataValueField="TL_No" AppendDataBoundItems="True" 
                            Width="190px" Height="17px">
                        </asp:DropDownList>
                        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/data/paper.mdb"
                            SelectCommand="SELECT [TL_No], [TL_Name] FROM [TimuLaiyuan]"></asp:AccessDataSource>
                    </td>
                   </tr>
                   <tr>
                    <td style="width:80px; height: 20px;">
                        <asp:Label ID="Label2" runat="server" Text="课题类型："></asp:Label>
                         <asp:Label ID="Label14" runat="server" Text="*" ForeColor="red"></asp:Label>
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="KeTiTypeDDL" runat="server" DataSourceID="AccessDataSource2"
                            DataTextField="TT_Name" DataValueField="TT_No" Width="190px" 
                            AppendDataBoundItems="True" Height="16px">
                        </asp:DropDownList><asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~/data/paper.mdb"
                            SelectCommand="SELECT [TT_No], [TT_Name] FROM [TimuType]"></asp:AccessDataSource>
                                           
                    </td>
                    </tr>
                    <tr>
                    <td style=" height:20px; width:80px;">
                        <asp:Label ID="Label3" runat="server" Text="专业方向："></asp:Label>
                         <asp:Label ID="Label15" runat="server" Text="*" ForeColor="red"></asp:Label>
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ZhuanyeDDL" runat="server" 
                            DataSourceID="Accesszhuanyefangxiang" DataTextField="ZA_Name" 
                            DataValueField="ZA_No" Width="190px" AppendDataBoundItems="True" 
                            Height="23px">
                        </asp:DropDownList><asp:AccessDataSource ID="Accesszhuanyefangxiang" runat="server"
                            DataFile="~/data/paper.mdb" SelectCommand="SELECT [ZA_No], [ZA_Name] FROM [ZhuanyeArrow]">
                        </asp:AccessDataSource>
                    </td>
                    </tr>                 
                   
                        <tr>
                    <td style="width:90px; height: 20px;"> <asp:Label ID="Label4" runat="server" Text="所属教研室：" Width="75px"></asp:Label>
                     <asp:Label ID="Label16" runat="server" Text="*" ForeColor="red" Width="5px"></asp:Label>
                    </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="JysDDL" runat="server" DataSourceID="Accessjys" 
                            DataTextField="Jys_Name" Width="190px"
                            DataValueField="Jys_No" AppendDataBoundItems="True" Height="16px">
                        </asp:DropDownList><asp:AccessDataSource ID="Accessjys" runat="server" DataFile="~/data/paper.mdb"
                            SelectCommand="SELECT [Jys_No], [Jys_Name] FROM [Jiaoyanshi]"></asp:AccessDataSource></td>
                            </tr>
                             
                        <tr>
                    <td style=" height:20px; width:80px;">
                        <asp:Label ID="Label6" runat="server" Text="论文题目："></asp:Label>
                         <asp:Label ID="Label17" runat="server" Text="*" ForeColor="red"></asp:Label>
                        </td>
                        <td align="left">
                        <asp:TextBox ID="timuNameTBox" runat="server" Height="18px" Width="400px" 
                                BackColor="#F0E68C"></asp:TextBox></td>
                   
                    </tr>
                    
                   
                    </table>
                    <table style="width: 680px; border-color:#004156; border-top-width:0;" border="0">
                     <tr><td align="center"> <asp:Label ID="Label7" runat="server" Text="题目简介：" Width="70px"></asp:Label>
                         <asp:Label ID="Label18" runat="server" Text="*" ForeColor="red"></asp:Label>
                         </td></tr>
                      <tr>
                    <td style="width:80px; height: 150px;" align="left">
                       
                        
		               <CE:Editor id="TimuJianjieTBox" EditorWysiwygModeCss="example.css" runat="server" Height="250px"></CE:Editor>
                           <%--<FCKeditorV2:FCKeditor ID="TimuJianjieTBox" ToolbarSet="Hugobasic" runat="server" Height="150px" width="600px"></FCKeditorV2:FCKeditor>--%></td>
                   </tr>
                   <tr><td align="center"><asp:Label ID="Label9" runat="server" Text="完成题目应具备的基本条件：" ></asp:Label>
                         <asp:Label ID="Label19" runat="server" Text="*" ForeColor="red"></asp:Label>
                         </td></tr>
                   <tr>
                    <td style="width:80; height: 150px;" align="left">
                        
                       
                       <CE:Editor id="TiaojianTBox" EditorWysiwygModeCss="example.css" runat="server" Height="250px"></CE:Editor>
                           <%--<FCKeditorV2:FCKeditor ID="TiaojianTBox" ToolbarSet="Hugobasic" runat="server" Height="150px" width="600px"></FCKeditorV2:FCKeditor>--%>
                                                   <asp:Button ID="SendBT" runat="server" Text="提  交" BackColor="SteelBlue" ForeColor="White" OnClick="SendBT_Click" />
                        <asp:Button ID="ResetBT" runat="server" Text="重　置" BackColor="SteelBlue" ForeColor="White" OnClick="ResetBT_Click" /></td>
                   
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
 

<%--</asp:Content>--%>