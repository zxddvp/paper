using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

public partial class TeaPinyue : System.Web.UI.Page
{
    protected string Id;
    protected string teaname;
    protected paper.Conn ds2 = new paper.Conn();
    protected int i = 0;

    protected OleDbDataReader rd;
    protected DataSet ds;
    protected string roleno;
    protected string teano;


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
        ds = StuPingyueBind();
        
        this.gvJysPingyue.DataSource = ds;
        gvJysPingyue.DataBind();
        legend.InnerText = "教师评阅";
    }
    public DataSet StuPingyueBind()
    {
        
        string str = "select p.Tea_Name,p.TimuName,s.ID,s.Stu_No,s.Stu_Name,s.pingyue_Zong from PaperShengbao as p,Student as s where p.Tea_Name = "
                    + "'" + teaname + "'" + " and p.ID = s.PSB_Id ";
        try
        {
            ds2.DBopen();

            ds = ds2.CreateDataSet(str, "StuPingyue");
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




    protected void gvJysPingyue_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        gvJysPingyue.CurrentPageIndex = e.NewPageIndex;
        gvJysPingyue.DataSource = StuPingyueBind();
        //this.GridView2.DataKeyField = new string[]{"ID"}
        gvJysPingyue.DataBind();
    }

    protected void gvJysPingyue_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        //GridView2.DataKeyField = new string[]("ID" );
        if (e.Item.ItemIndex != -1 && e.Item.ItemIndex >= 0)
        {



            string cmd = e.CommandName;//获取命令名称
            int Id1 = Convert.ToInt32(gvJysPingyue.DataKeys[e.Item.ItemIndex].ToString());//获取命令参数
            if (cmd == "Detail")
            {
                //执行编辑
                Page.Server.Transfer("Detail_Pingyue.aspx?id=" + Id1.ToString());
                // Response.Write("<script>window.open('Detail.aspx?id=" + Id1.ToString() + ")</script>");

            }
        }
    }

}
