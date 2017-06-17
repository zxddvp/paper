<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StuThesisScore.aspx.cs" Inherits="StuThesisScore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>毕业论文成绩</title>
    <link href="loginfont.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset style=" width:660px; border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F;">
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>
    <table>
    <tr>
    <td align="center" style="height:200px; ">
    <% if (ispjtea == "0")
       {%>对不起，您必须对您的指导教师进行了客观的评价才能看到您的成绩，请先给指导教师做出客观的评价，谢谢！<% }
       else if (ispjtea == "1")
                            { %> 您的毕业论文<asp:Label ID="LBLThesisScore" runat="server" 
            Font-Size="XX-Large" ForeColor="#009933"></asp:Label><% } %>
        
    
    </td>
    </tr>
    
    </table>
    
    
    
     </fieldset>
    </div>
    </form>
</body>
</html>
