<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XLTeaBaseMess.aspx.cs" Inherits="XLTeaBaseMess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    <title>审核教师基本信息页面</title>
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
                    &nbsp;未审核教师信息，请审核：</td>
                    </tr><tr>
                <td>
                    <asp:DataList ID="DListNotshen" runat="server" BackColor="#99CCFF" 
                        BorderColor="Maroon" BorderStyle="Ridge" BorderWidth="1px" CellPadding="5" 
                        DataSourceID="AccessDataSource1" RepeatColumns="10" CellSpacing="5" 
                        Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small" 
                        Font-Strikeout="False" Font-Underline="False" ForeColor="Maroon"  DataKeyField="Tea_Name" 
                        HorizontalAlign="Center" onitemcommand="DListNotshen_ItemCommand">
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <AlternatingItemStyle Font-Bold="False" Font-Italic="False" 
                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                            ForeColor="Maroon" />
                        <ItemStyle BackColor="#99CCFF" Font-Bold="False" Font-Italic="False" 
                            Font-Overline="False" Font-Size="Small" Font-Strikeout="False" 
                            Font-Underline="False" ForeColor="Red" />
                        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="Maroon" 
                            Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                            Font-Underline="False" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <ItemTemplate>
                          
                            <asp:LinkButton ID="Tea_NameLabel" CommandName="TeaMess" runat="server" Text='<%# Eval("Tea_Name") %>' />
                           
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
                        DataFile="~/data/paper.mdb" 
                        SelectCommand="SELECT [Tea_Name] FROM [Teacher] WHERE ([Tea_Shenhe] = ?) ORDER BY [Tea_Name]">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="未审核" Name="Tea_Shenhe" Type="String" />
                        </SelectParameters>
                    </asp:AccessDataSource>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;已审核教师信息：    
                    &nbsp;</td>
            </tr>
           
                   <tr>
                <td>
                    <asp:DataList ID="DListshenhe" runat="server" BackColor="#FFCC99" 
                        BorderColor="Tan" BorderWidth="1px" CellPadding="2" 
                        DataSourceID="AccessDataSource2" ForeColor="#006666" RepeatColumns="10" 
                        Font-Bold="False" Font-Italic="False" Font-Overline="False"  DataKeyField="Tea_Name" 
                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                        onitemcommand="DListshenhe_ItemCommand">
                        <FooterStyle BackColor="Tan" />
                        <AlternatingItemStyle BackColor="PaleGoldenrod" />
                        <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <ItemTemplate>
                           
                            <asp:LinkButton ID="Tea_NameLabel" CommandName="TeaMess" runat="server" Text='<%# Eval("Tea_Name") %>' />
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:AccessDataSource ID="AccessDataSource2" runat="server" 
                        DataFile="~/data/paper.mdb" 
                        SelectCommand="SELECT [Tea_Name] FROM [Teacher] WHERE ([Tea_Shenhe] = ?) ORDER BY [Tea_Name]">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="同意" Name="Tea_Shenhe" Type="String" />
                        </SelectParameters>
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
        </table>
    </fieldset>
    </div>
    </form>
</body>
</html>

