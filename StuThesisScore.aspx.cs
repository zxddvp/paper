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

public partial class StuThesisScore : System.Web.UI.Page
{
     protected string stuname;
    protected paper.Conn ds2 = new paper.Conn();
    protected int i = 0;
    protected string stunostr;
    Int64 stuno;
    protected OleDbDataReader rd;
    protected DataSet ds;
    protected DataTable dt;
    protected string roleno;
    protected string ispjtea;



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
            int i = IsStuPITea();
            ispjtea = i.ToString();
        }

        legend.InnerText = "毕业论文成绩";
        string scorestr = StuZongScore();
        float score = float.Parse(scorestr);
        if (score >= 60)
        {
            this.LBLThesisScore.Text = "通过";
        }
        else
        {
            this.LBLThesisScore.Text = "还没有成绩";
        }
      
    
    }
    public int IsStuPITea()//查看学生是否对指导教师进行了评价，评价了就是1，否则就是0
    {
        try
        {

            string sql = "select count(*) from StuPJTea where Stu_No = "
                       + stuno;
            ds2.DBopen();

            ds = ds2.CreateDataSet(sql, "count");
            dt = ds.Tables["count"];
            string ispjstr = dt.Rows[0][0].ToString();
            int ispj = ds2.ChangeToInt(ispjstr);

            ds2.DBclose();

            if (ispj > 0)
            {

                return 1;
            }
            else
            {
                return 0;
            }
            
        }
        catch (System.Data.OleDb.OleDbException e)
        {
            Response.Write(e.ToString());
            return -1;

        }
        finally
        {
            ds2.DBclose();
        }
    }
    public string StuZongScore()//学生折合总成绩：评分*0.4+评阅*0.2+答辩*0.4
    {
        string sql = "select Stu_No,(pingfen_Zong*0.4+pingyue_Zong*0.2+dabian_Zong*0.4) as ZongScore from Student where Stu_No = " + stuno;
        try
        {
            ds2.DBopen();

            ds = ds2.CreateDataSet(sql, "Student");
            dt = ds.Tables["Student"];
            string stuScore = dt.Rows[0]["ZongScore"].ToString();
            return stuScore;

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
    //public void SaveStuZongScore(string zongscroe)
    //{
    //    try
    //    {
    //        string str = "update Student set Zhehe_Zong = '" + zongscroe
    //                   + "'where Stu_No = " + stuno;
    //        ds2.DBopen();

    //        int result = ds2.ExecuteSql(str);           
    //    }
    //    catch (System.Data.OleDb.OleDbException e)
    //    {
    //        Response.Write(e.ToString());
    //    }
    //    finally
    //    {
    //        ds2.DBclose();
    //    }

    //}
   
}
