<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Detail_Dabian.aspx.cs" Inherits="Detail_Dabian" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>答辩评分</title>
    <link href="loginfont.css" type="text/css" rel="stylesheet"/>
    <style type="text/css">
        .style1
        {
            width: 240px;
            height: 57px;
        }
        .style2
        {
            width: 240px;
        }
    </style>
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
                    <td class="style1">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label1" runat="server" Text="学号：" Font-Bold="True" 
                            ForeColor="#006600" ></asp:Label>
                       </td> 
                       <td><asp:Label ID="stuNoLbl" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                       <tr>
                    <td class="style1"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label2" runat="server" Text="姓名："   Font-Bold="True" 
                            ForeColor="#006600"></asp:Label>
                        </td> 
                       <td><asp:Label ID="stuNameLbl" runat="server" Text="Label"></asp:Label>
                    </td>
                     </tr>
                        <tr>
                    <td class="style1"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label3" runat="server" Text="班级：" Font-Bold="True" 
                            ForeColor="#006600"></asp:Label>
                        </td> 
                       <td><asp:Label ID="classLbl" runat="server" Text="Label"></asp:Label>
                    </td>
                    </tr>
                     <tr>
                    <td class="style1"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label4" runat="server" Text="论文（设计）题目：" Font-Bold="True" 
                            ForeColor="#006600"></asp:Label>
                        </td> 
                       <td><asp:Label ID="stuPaperTimuLbl" runat="server" Text="Label"></asp:Label>
                    </td>
                    </tr>
                    <tr>
                <td class="style2"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label8" runat="server" Text="开题报告的情况（10）：" ForeColor="Brown"></asp:Label>
                    
                </td>
                <td align="left">
                    
                    <asp:DropDownList ID="DDLKaiti" runat="server" Width="80px">
                    </asp:DropDownList>
                   
                    
                </td>
                 </tr>
                <tr>
                <td align="left" class="style2"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label10" runat="server" Text="学生的业务水平（10）：" ForeColor="#006600"></asp:Label>
                   
                </td>
                    <td align="left" >
                        <asp:DropDownList ID="DDLStuYewu" runat="server" Width="80px">
                        </asp:DropDownList>
                        
                </td>
                 </tr>
                <tr>
                    <td class="style2"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label11" runat="server" Text="毕业论文（设计）的总体质量（20）：" ForeColor="Brown"></asp:Label>
                         
                </td>
                    <td>
                        <asp:DropDownList ID="DDLZhiliang" runat="server" Width="80px">
                        </asp:DropDownList>
                       
                </td>
                 </tr>
                <tr>
                <td class="style2"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label12" runat="server" Text="答辩中自述和回答问题的情况（50）：" ForeColor="#006600"></asp:Label>
                        
                </td>
                    <td>
                        <asp:DropDownList ID="DDLHuida" runat="server" Width="80px">
                        </asp:DropDownList>
                       
                </td>
            </tr>
            <tr>
                    <td class="style2"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label13" runat="server" Text="工作态度及工作量大小（10）：" ForeColor="Brown"></asp:Label>
                         
                </td>
                    <td>
                        <asp:DropDownList ID="DDLGZliang" runat="server" Width="80px">
                        </asp:DropDownList>
                       
                </td>
                 </tr>
               
           
                <tr>
                <td class="style2"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label17" runat="server" Text="总分（100）：" ForeColor="#006600"></asp:Label>
                       
                </td>
                    <td>
                        <asp:Label ID="zongfenLbl" runat="server" Text="Label"></asp:Label>
                       
                </td>
            </tr>
                 
                  
                     
                        <tr>
                        <td align="center">
                            <asp:Button ID="PingfenBT" runat="server" Text="更  新" 
                                onclick="DabianBT_Click" />
                       </td>
                      <%-- <td> <asp:Button ID="ReturnBT" runat="server" Text="返   回" Visible="true" onclick="ReturnBT_Click" />
                    </td>--%>
                   </tr>
                   <tr>
                        <td align="center">
                            <asp:Button ID="Button1" runat="server" Text="查看折合后的总成绩" 
                                onclick="zongBT_Click" />
                       </td>
                       <td>
                        <asp:Label ID="lblzhehezong" runat="server" Text=""></asp:Label>
                       
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
