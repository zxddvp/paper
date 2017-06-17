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
using System.Data.OleDb;

public partial class TeaBackground : System.Web.UI.Page
{
    protected string teaname;
    protected paper.Conn ds2 = new paper.Conn();
    protected int i = 0;
    protected string teano;
    protected OleDbDataReader rd;
    protected DataSet ds;
    protected string roleno;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserInfo"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            string teaname1 = cookie.Values["teaname"].ToString();
            teaname = HttpUtility.UrlDecode(teaname1);
            teano = cookie.Values["teano"].ToString();
            roleno = cookie.Values["roleno"].ToString();
        }
       
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
