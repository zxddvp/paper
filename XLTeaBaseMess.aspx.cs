using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class XLTeaBaseMess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void DListNotshen_ItemCommand(object source, DataListCommandEventArgs e)
    {
        string cmd = e.CommandName.ToLower();//获取命令名称
        string Id1 = DListNotshen.DataKeys[e.Item.ItemIndex].ToString();//获取命令参数
        if (cmd == "teamess")
            //Response.Redirect("StuSelTeaMess.aspx");
            Page.Server.Transfer("XLSelTeaMess.aspx?id=" + Id1.ToString());
    }
    protected void DListshenhe_ItemCommand(object source, DataListCommandEventArgs e)
    {
        string cmd = e.CommandName.ToLower();//获取命令名称
        string Id1 = DListshenhe.DataKeys[e.Item.ItemIndex].ToString();//获取命令参数
        if (cmd == "teamess")
            //Response.Redirect("StuSelTeaMess.aspx");
            Page.Server.Transfer("XLSelTeaMess.aspx?id=" + Id1.ToString());
    }
}
