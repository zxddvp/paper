<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ggFirst.aspx.cs" Inherits="gonggao_ggFirst" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>发布公告</title>
     <link href="~/loginfont.css" type="text/css" rel="stylesheet"/>
    
</head>

<body style="margin-top: 0px; margin-bottom: 0px; margin-right:0px; margin-left:0px" >

<form id="form1" runat="server">
    <div>
    <fieldset style=" width:790px; border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F;">
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>
    
        <table style="width: 100%;  height:600; border-color:#004156" border="0" cellpadding="0" cellspacing="0" >
           
            <tr style="height: 205px">
                <td colspan="3" style="vertical-align: top; text-align: left; height: 205px; width: 100%;">
                  
                    <table style="width: 680px; height:60px; border-color:#004156;" border="0" >
                    <tr>
                    <td style=" height:20px;">
                        <asp:HyperLink ID="HLggTeacher" NavigateUrl="~/gonggao/ggTeacher.aspx"  runat="server">发布教师公告</asp:HyperLink>
                        </td>
                        
                        </tr>
                     <tr>
                    <td style=" height:20px;">
                      
                        <asp:HyperLink ID="HLggStudent" NavigateUrl="~/gonggao/ggStudent.aspx"  runat="server">发布学生公告</asp:HyperLink>
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
