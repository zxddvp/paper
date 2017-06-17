<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StuTeaList.aspx.cs" Inherits="StuTeaList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="loginfont.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset style=" border-bottom-color:#385E9F; border-left-color:#385E9F; border-top-color:#385E9F; border-right-color:#385E9F; width:670px;">
    <legend style="color:#000000; font: smallcaption;" runat="server" id="legend"></legend>
        <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:DataList ID="DataList1" runat="server" BackColor="White" 
                        BorderColor="#CC3300" BorderWidth="1px" CellPadding="8" 
                        DataSourceID="AccessDataSource1" 
                         RepeatColumns="12"  DataKeyField="Tea_Name"
                        RepeatDirection="Horizontal" onitemcommand="DataList1_ItemCommand" 
                        Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                        Font-Strikeout="False" Font-Underline="False" ForeColor="#009900" 
                        GridLines="Both">
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <AlternatingItemStyle BackColor="White" Font-Bold="False" Font-Italic="False" 
                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                            ForeColor="#FF9999" />
                        <ItemStyle BackColor="White" ForeColor="Maroon" Font-Bold="False" 
                            Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                            Font-Underline="False" />
                        <SeparatorStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                            Font-Size="Small" Font-Strikeout="False" Font-Underline="False" />
                        <SelectedItemStyle BackColor="#CC0000" Font-Bold="True" ForeColor="#333333" 
                            Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                            Font-Underline="False" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <ItemTemplate>
                            
                            
                            <asp:LinkButton ID="Tea_NameLabel" CommandName="teamess" runat="server" Text='<%# Eval("Tea_Name") %>' />
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
                        DataFile="~/data/paper.mdb" 
                        
                        
                        SelectCommand="SELECT [Tea_Name] FROM [Teacher] WHERE ([Tea_Shenhe] IS NOT NULL)">
                    </asp:AccessDataSource>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </fieldset>
    </div>
    </form>
</body>
</html>
