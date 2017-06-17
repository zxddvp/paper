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

public partial class StuSeathesisJZ : System.Web.UI.Page
{
    protected string stuname;
    protected paper.Conn ds2 = new paper.Conn();
    protected int i = 0;
    protected string stunostr;
    Int64 stuno;
    protected OleDbDataReader rd;
    protected DataSet ds;
    protected string roleno;
    protected string isselect;
    
    
    
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
        if (!IsPostBack)
        {

            StutermthesisBind();

            legend.InnerText = "毕业论文查询";
        }
    }


   

    public void StutermthesisBind()
    {
        
        string str;

        str = "select s.ID,p.Tea_Name,s.Stu_No,s.Stu_Name,s.Stu_Istongyi from Student as s,PaperShengbao as p "
                   + " where p.ID = s.PSB_Id and s.Stu_No = " + stuno; 
       
        try
        {
            ds2.DBopen();
            ds = ds2.CreateDataSet(str, "TeaSel");
            this.StuDataGrid1.DataSource = ds;
            StuDataGrid1.DataBind();
        }
        catch (System.Data.OleDb.OleDbException ex)
        {
            Response.Write(ex.ToString());           
        }
        finally
        {
            ds2.DBclose();
        }
        
    }
}
