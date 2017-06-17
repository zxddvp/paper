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
using System.Windows.Forms;
using System.Data.OleDb;

public partial class Superuser : System.Web.UI.Page
{
    protected string uaname;
    protected paper.Conn ds2 = new paper.Conn();
   
    protected string teano;
    protected OleDbDataReader rd;
    protected DataSet ds;
   

    protected void Page_Load(object sender, EventArgs e)
    {
        
        InitCook();
        if (!IsPostBack)
        {
            ds = JysAdminBind();
            this.JysDg.DataSource = ds;
            JysDg.DataBind();
        }

    }
    public void InitCook()
    {
        if (Request.Cookies["UserInfo"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            string uaname1 = cookie.Values["uaname"].ToString();
            uaname = HttpUtility.UrlDecode(uaname1);
            teano = cookie.Values["teano"].ToString();
           
        }
        
    }
    public DataSet JysAdminBind()
    {
        
        string str = "select Jys_No,Jys_Name,Jys_Admin,Tea_No from Jiaoyanshi";
        try
        {
            ds2.DBopen();

            ds = ds2.CreateDataSet(str, "JiaoyanshiAdmin");
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


    protected void JysDg_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            ds2.DBopen();

            int id = ds2.ChangeToInt(JysDg.DataKeys[e.Item.ItemIndex].ToString());

            
               
                string SqlDelNews = "delete from Jiaoyanshi where Jys_No = " + id + "";


                int re = ds2.ExecuteSql(SqlDelNews);

                if (re > 0)
                {
                    string lf = "" + uaname + "进行了删除教研室负责人的操作。";
                    ds2.WriteLogfile(lf);
                    ds2.alert("删除成功", "Superuser.aspx");

                }
                else
                {

                    ds2.alert("删除失败", "Superuser.aspx");

                }
           
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddJysAdmin.aspx");
    }
    protected void GaiPsw_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserAdminPSW.aspx");//用户管理员更改密码
    }
}
