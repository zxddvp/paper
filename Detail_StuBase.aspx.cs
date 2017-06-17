using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;



public partial class Detail_StuBase : System.Web.UI.Page
{
    string stunostr;
    protected string teaname;
    protected paper.Conn ds2 = new paper.Conn();
    protected int i = 0;
    protected string teano;
    protected OleDbDataReader rd;
    protected DataSet ds;
    protected DataTable dt;
    protected string roleno;
    Int64 stuno;


    protected void Page_Load(object sender, EventArgs e)
    {
        stunostr = Request.QueryString["id"].ToString();
        if (Request.Cookies["UserInfo"] == null)
        {
           Response.Redirect("Default.aspx");
        }
        else
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
           // string teaname1 = cookie.Values["teaname"].ToString();
          //  teaname = HttpUtility.UrlDecode(teaname1);
            teano = cookie.Values["teano"].ToString();
            roleno = cookie.Values["roleno"].ToString();            
        }
        dt = StuMessBind();
        this.Lblstuno.Text = dt.Rows[0]["Stu_No"].ToString();
        this.Lblstuname.Text = dt.Rows[0]["Stu_Name"].ToString();
        this.Lblstuclass.Text = dt.Rows[0]["Stu_Class"].ToString();
        this.Lblstuzhuanye.Text = dt.Rows[0]["Stu_Zhuanye"].ToString();
        this.Lblstutel.Text = dt.Rows[0]["Stu_Tel"].ToString();
        this.Lblstucourse.Text = dt.Rows[0]["Stu_Course"].ToString();
        this.Lblstuhuojiang.Text = dt.Rows[0]["Stu_Huojiang"].ToString();
        this.Lblstuaihao.Text = dt.Rows[0]["Stu_Aihao"].ToString();
        this.Lblstuziwopj.Text = dt.Rows[0]["Stu_ZiwoPJ"].ToString();
         legend.InnerText = "题目详细信息";

       
    }
    public DataTable StuMessBind()//读取学生的基本信息
    {
        stuno = Int64.Parse(stunostr);
        string str = "select Stu_No,Stu_Name,Stu_Class,Stu_Zhuanye,Stu_Tel,Stu_Course,Stu_Huojiang,Stu_Aihao,Stu_ZiwoPJ from Student where Stu_No="
                    + stuno;
        try
        {
            ds2.DBopen();

            ds = ds2.CreateDataSet(str, "Student");
            return dt = ds.Tables["Student"];
            //TextBox.databindings.add("text", Dt, "列"); 


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

    protected void ReturnBT_Click(object sender, EventArgs e)
    {
        Response.Write("<script> history.go(-2); </script>"); 

    }
}
