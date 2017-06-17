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

public partial class StuBackground : System.Web.UI.Page
{
    protected string stuname;
    protected paper.Conn ds2 = new paper.Conn();
   
    protected string stunostr;
    Int64 stuno;
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
            string stuname1 = cookie.Values["stuname"].ToString();
            stuname = HttpUtility.UrlDecode(stuname1);
            stunostr = cookie.Values["stuno"].ToString();
            stuno = Int64.Parse(stunostr);
            roleno = cookie.Values["roleno"].ToString();
            
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
