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

public partial class TeaDabianPingfen : System.Web.UI.Page
{
    protected string Id;
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
        ds = StuDabianPingfenBind();
        this.gvStuDabian.DataSource = ds;
        gvStuDabian.DataBind();
        legend.InnerText = "答辩评分";
    }
    public DataSet StuDabianPingfenBind()
    {

        string str = "select p.TimuName,s.ID,s.Stu_No,s.Stu_Name,s.dabian_Zong from PaperShengbao as p,Student as s where p.Tea_Name = "
                    + "'" + teaname + "'" + " and p.ID = s.PSB_Id ";
        try
        {
            ds2.DBopen();

            ds = ds2.CreateDataSet(str, "StuDabianPingfen");
            return ds;

        }
        catch (System.Data.OleDb.OleDbException e)
        {
            Response.Write(e.ToString());
            return null;

        }
        finally
        {
            ds2.DBclose();
        }
    }




    protected void gvStuDabian_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        gvStuDabian.CurrentPageIndex = e.NewPageIndex;
        gvStuDabian.DataSource = StuDabianPingfenBind();
        //this.GridView2.DataKeyField = new string[]{"ID"}
        gvStuDabian.DataBind();
    }

    protected void gvStuDabian_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        //GridView2.DataKeyField = new string[]("ID" );
        if (e.Item.ItemIndex != -1 && e.Item.ItemIndex >= 0)
        {



            string cmd = e.CommandName;//获取命令名称
            int Id1 = Convert.ToInt32(gvStuDabian.DataKeys[e.Item.ItemIndex].ToString());//获取命令参数
            if (cmd == "Detail")
            {
                //执行编辑
                Page.Server.Transfer("Detail_Dabian.aspx?id=" + Id1.ToString());
                // Response.Write("<script>window.open('Detail.aspx?id=" + Id1.ToString() + ")</script>");

            }
        }
    }
}
