<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Detail_Pingyue.aspx.cs" Inherits="Detail_Pingyue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>教研室评阅</title>
    <link href="loginfont.css" type="text/css" rel="stylesheet"/>
</head>
<body>
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
                        <asp:Label ID="Label5" runat="server" Text="指导教师：" Font-Bold="True" 
                            ForeColor="#006600" ></asp:Label>
                       </td> 
                       <td><asp:Label ID="LblTea" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                       <tr>
                    <td style="width:27%; height: 57px;">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label1" runat="server" Text="学号：" Font-Bold="True" 
                            ForeColor="#006600" ></asp:Label>
                       </td> 
                       <td><asp:Label ID="stuNoLbl" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                       <tr>
                    <td style="width:23%; height: 57px;"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label2" runat="server" Text="姓名："   Font-Bold="True" 
                            ForeColor="#006600"></asp:Label>
                        </td> 
                       <td><asp:Label ID="stuNameLbl" runat="server" Text="Label"></asp:Label>
                    </td>
                     </tr>
                        <tr>
                    <td style="width:25%; height: 57px;"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label3" runat="server" Text="班级：" Font-Bold="True" 
                            ForeColor="#006600"></asp:Label>
                        </td> 
                       <td><asp:Label ID="classLbl" runat="server" Text="Label"></asp:Label>
                    </td>
                    </tr>
                     <tr>
                    <td style="width:25%; height: 57px;"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label4" runat="server" Text="论文（设计）题目：" Font-Bold="True" 
                            ForeColor="#006600"></asp:Label>
                        </td> 
                       <td><asp:Label ID="stuPaperTimuLbl" runat="server" Text="Label"></asp:Label>
                    </td>
                    </tr>
                    <tr>
                <td style=" width:200px;"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label8" runat="server" Text="论文规范性（20）：" ForeColor="Brown"></asp:Label>
                    
                </td>
                <td align="left">
                    
                    <asp:DropDownList ID="DDLGuifan" runat="server" Width="80px">
                    </asp:DropDownList>
                   
                    
                </td>
                 </tr>
                <tr>
                <td style=" width:200px;" align="left"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label10" runat="server" Text="撰写水平（20）：" ForeColor="#006600"></asp:Label>
                   
                </td>
                    <td align="left" >
                        <asp:DropDownList ID="DDLWNengli" runat="server" Width="80px">
                        </asp:DropDownList>
                        
                </td>
                 </tr>
                <tr>
                    <td style=" width:40%;"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label11" runat="server" Text="综合能力（35）：" ForeColor="Brown"></asp:Label>
                         
                </td>
                    <td>
                        <asp:DropDownList ID="DDLZonghe" runat="server" Width="80px">
                        </asp:DropDownList>
                       
                </td>
                 </tr>
                <tr>
                <td style=" width:40%;"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label12" runat="server" Text="理论与实际结合（15）：" ForeColor="#006600"></asp:Label>
                        
                </td>
                    <td>
                        <asp:DropDownList ID="DDLJiehe" runat="server" Width="80px">
                        </asp:DropDownList>
                       
                </td>
            </tr>
            <tr>
                    <td style=" width:40%;"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label13" runat="server" Text="创新性（10）：" ForeColor="Brown"></asp:Label>
                         
                </td>
                    <td>
                        <asp:DropDownList ID="DDLNew" runat="server" Width="80px">
                        </asp:DropDownList>
                       
                </td>
                 </tr>
               
           
                <tr>
                <td style=" width:200px;"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label17" runat="server" Text="总分（100）：" ForeColor="#006600"></asp:Label>
                       
                </td>
                    <td>
                        <asp:Label ID="zongfenLbl" runat="server" Text="Label"></asp:Label>
                       
                </td>
            </tr>
                 
                  
                     
                        <tr>
                        <td align="center">
                            <asp:Button ID="PingyueBT" runat="server" Text="更  新" 
                                onclick="PingyueBT_Click" />
                       </td>
                      <%-- <td> <asp:Button ID="ReturnBT" runat="server" Text="返   回" Visible="true" onclick="ReturnBT_Click" />
                    </td>--%>
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
