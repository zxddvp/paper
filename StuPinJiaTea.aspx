<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StuPinJiaTea.aspx.cs" Inherits="StuPinJiaTea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>学生评价指导教师</title>
    <link href="loginfont.css" type="text/css" rel="stylesheet"/>
    <style type="text/css">
        .style1
        {
            width: 660px;
            height: 57px;
        }
        .style2
        {
            width: 660px;
        }
    </style>
</head>
<body>
       <form id="form2" runat="server">
    <div>
    <fieldset style=" width:660px; border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F;">
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>
        <table style="width: 660px; height: 600px;" border="0" cellpadding="0" cellspacing="0">
         
            <tr style="height: 205px">
                <td colspan="3" style="vertical-align: top; text-align: left; height: 205px; width: 100%;">
                  
                    <table style="width: 100%">
                       
                      
                       
                     <tr>
                    <td class="style1"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label4" runat="server" 
                            Text="请本着对自己、对教师、对数学与信息科学学院负责的态度，认真、客观的对您的论文指导教师作出评价，您的评价指导教师看不见，也不会影响您的毕业论文成绩。只有您作出客观评价后，您的成绩才能显示在管理系统中。" Font-Bold="False" 
                            ForeColor="Blue"></asp:Label>
                        </td> 
                    
                    
                    </tr>
                    <tr>
                <td class="style2"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label8" runat="server" Text="1、指导教师态度情况，是否认真、严格和热情？" ForeColor="Brown"></asp:Label>
                    
                </td>
                <td align="left">
                    
                    
                </td>
                 </tr>
                <tr>
                <td align="left" class="style2">           
                    <asp:RadioButtonList ID="RBL1" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>好</asp:ListItem>
                        <asp:ListItem>较好</asp:ListItem>
                        <asp:ListItem>一般</asp:ListItem>
                    </asp:RadioButtonList>
                   
                </td>
                    
                 </tr>
                <tr>
                    <td class="style2"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label11" runat="server" Text="2、指导教师在讲解毕业论文的重要性和意义时？" ForeColor="#006600"></asp:Label>
                         
                </td>
                    <td>
                        &nbsp;</td>
                 </tr>
                <tr>
                <td class="style2">                         
                    <asp:RadioButtonList ID="RBL2" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>认真</asp:ListItem>
                        <asp:ListItem>较认真</asp:ListItem>
                        <asp:ListItem>一般</asp:ListItem>
                    </asp:RadioButtonList>
                        
                </td>
                    <td>
                        &nbsp;</td>
            </tr>
            <tr>
                    <td class="style2"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label13" runat="server" Text="3、指导教师在指导您对题目的理解时？" ForeColor="Brown"></asp:Label>
                         
                </td>
                                 </tr>
               
           
                <tr>
                <td class="style2">                       
                       
                    <asp:RadioButtonList ID="RBL3" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>认真</asp:ListItem>
                        <asp:ListItem>较认真</asp:ListItem>
                        <asp:ListItem>一般</asp:ListItem>
                    </asp:RadioButtonList>
                        
                       
                </td>
                    
            </tr>
                  <tr>
                    <td class="style2"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label1" runat="server" Text="4、指导教师在指导您如何查阅资料时？" ForeColor="#006600"></asp:Label>
                         
                </td>
                    <td>
                        &nbsp;</td>
                 </tr>
                <tr>
                <td class="style2">                         
                    <asp:RadioButtonList ID="RBL4" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>认真、有效</asp:ListItem>
                        <asp:ListItem>较认真</asp:ListItem>
                        <asp:ListItem>一般</asp:ListItem>
                    </asp:RadioButtonList>
                        
                </td>
                    <td>
                        &nbsp;</td>
            </tr>
            <tr>
                    <td class="style2"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label2" runat="server" Text="5、指导教师在指导您修改并填写开题报告方面？" ForeColor="Brown"></asp:Label>
                         
                </td>
                                 </tr>
               
           
                <tr>
                <td class="style2">                       
                       
                    <asp:RadioButtonList ID="RBL5" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>认真细致</asp:ListItem>
                        <asp:ListItem>较认真</asp:ListItem>
                        <asp:ListItem>一般</asp:ListItem>
                    </asp:RadioButtonList>
                        
                       
                </td>
                    
            </tr>
                <tr>
                    <td class="style2"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label3" runat="server" Text="6、指导教师在指导您撰写论文提纲（论文框架）方面？" ForeColor="#006600"></asp:Label>
                         
                </td>
                    <td>
                        &nbsp;</td>
                 </tr>
                <tr>
                <td class="style2">                         
                    <asp:RadioButtonList ID="RBL6" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>认真细致</asp:ListItem>
                        <asp:ListItem>较认真</asp:ListItem>
                        <asp:ListItem>一般</asp:ListItem>
                    </asp:RadioButtonList>
                        
                </td>
                    <td>
                        &nbsp;</td>
            </tr>
            <tr>
                    <td class="style2"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label5" runat="server" Text="7、指导教师在阅读您的论文初稿、提出具体的修改意见时？" ForeColor="Brown"></asp:Label>
                         
                </td>
                                 </tr>
               
           
                <tr>
                <td class="style2">                       
                       
                    <asp:RadioButtonList ID="RBL7" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>认真细致</asp:ListItem>
                        <asp:ListItem>较认真</asp:ListItem>
                        <asp:ListItem>一般</asp:ListItem>
                    </asp:RadioButtonList>
                        
                       
                </td>
                    
            </tr>   
                 <tr>
                    <td class="style2"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label6" runat="server" Text="8、指导教师在阅读您的论文第二稿、提出进一步修改意见时？" ForeColor="#006600"></asp:Label>
                         
                </td>
                    <td>
                        &nbsp;</td>
                 </tr>
                <tr>
                <td class="style2">                         
                    <asp:RadioButtonList ID="RBL8" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>认真细致</asp:ListItem>
                        <asp:ListItem>较认真</asp:ListItem>
                        <asp:ListItem>一般</asp:ListItem>
                    </asp:RadioButtonList>
                        
                </td>
                    <td>
                        &nbsp;</td>
            </tr>
            <tr>
                    <td class="style2"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label7" runat="server" Text="9、指导教师在指导您如何参加论文答辩时？" ForeColor="Brown"></asp:Label>
                         
                </td>
                                 </tr>
               
           
                <tr>
                <td class="style2">                       
                       
                    <asp:RadioButtonList ID="RBL9" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>认真、具体</asp:ListItem>
                        <asp:ListItem>较认真</asp:ListItem>
                        <asp:ListItem>一般</asp:ListItem>
                    </asp:RadioButtonList>
                        
                       
                </td>
                    
            </tr>    
            <tr>
                    <td class="style2"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label9" runat="server" Text="10、在指导教师指导下是否有收获？" ForeColor="#006600"></asp:Label>
                         
                </td>
                    <td>
                        &nbsp;</td>
                 </tr>
                <tr>
                <td class="style2">                         
                    <asp:RadioButtonList ID="RBL10" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>收获大</asp:ListItem>
                        <asp:ListItem>收获一般</asp:ListItem>
                        <asp:ListItem>没有收获</asp:ListItem>
                    </asp:RadioButtonList>
                        
                </td>
                    <td>
                        &nbsp;</td>
            </tr>
            
                        <tr>
                        <td align="center"><% if(isPingJia=="1") {%>您已经对您的指导教师做过评价了<% }
                                              else if (isPingJia == "0")
                                              { %><asp:Button ID="StuPJTeaBT" runat="server" Text="提  交"  Enabled="false"
                                onclick="StuPJTeaBT_Click" /><% } %>
                            
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
