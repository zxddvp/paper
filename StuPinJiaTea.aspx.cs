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

public partial class StuPinJiaTea : System.Web.UI.Page
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
    int best = 3;
    int better = 2;
    int good = 1;
    protected string isPingJia;

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
                isPingJia = IsPingjia();
                legend.InnerText = "评价指导教师";
            }
            
    }

    public string IsPingjia()//判断学生是否已经做过评价了
    {
        string str = "select count(*) from StuPJTea where Stu_No = " + stuno;
         try
         {
             ds2.DBopen();
             ds = ds2.CreateDataSet(str, "count");
             dt = ds.Tables["count"];
             string ispjstr = dt.Rows[0][0].ToString();
             int ispj = ds2.ChangeToInt(ispjstr);            
            
             ds2.DBclose();

             if (ispj > 0)
             {

                 return "1";
             }
             else
             {
                 return "0";
             }
         }
         catch (System.Data.OleDb.OleDbException e)
         {
             Response.Write(e.ToString());
             return "dberror";

         }
         finally
         {
             ds2.DBclose();
         }
    }
    
    public int ZhiDaoTea()//获取该学生的指导教师的教工号
    {
        
        string str = "select t.Tea_No"
                   + " from PaperShengbao as p,Student as s,Teacher as t where p.ID = s.PSB_Id and t.Tea_Name = p.Tea_Name "
                   + " and s.Stu_No = " + stuno;
        try
        {
            ds2.DBopen();

            ds = ds2.CreateDataSet(str, "tea_no");            
            dt = ds.Tables["tea_no"];
            string teanostr = dt.Rows[0]["Tea_No"].ToString();
            int teano = ds2.ChangeToInt(teanostr);
            return teano;
            //TextBox.databindings.add("text", Dt, "列"); 


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
    public string ZhiDaoTeaName()//获取该学生的指导教师的姓名
    {

        string str = "select p.Tea_Name"
                   + " from PaperShengbao as p,Student as s where p.ID = s.PSB_Id "
                   + " and s.Stu_No = " + stuno;
        try
        {
            ds2.DBopen();

            ds = ds2.CreateDataSet(str, "tea_name");
            dt = ds.Tables["tea_name"];
            string teaname = dt.Rows[0]["Tea_Name"].ToString();

            return teaname;
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

   

    protected void StuPJTeaBT_Click(object sender, EventArgs e)
    {
        int t1 = 0; 
        int t2 = 0; 
        int t3 = 0; 
        int t4 = 0; 
        int t5 = 0; 
        int t6 = 0; 
        int t7 = 0; 
        int t8 = 0; 
        int t9 = 0; 
        int t10 = 0;//将选择项转换成分值

        #region 将选择项转换成分值
        if (this.RBL1.SelectedIndex == 0)
        {
            t1 = best;
        }
        else if (this.RBL1.SelectedIndex == 1)
        {
            t1 = better;
        }
        else if (this.RBL1.SelectedIndex == 2)
        {
            t1 = good;
        }
        if (this.RBL2.SelectedIndex == 0)
        {
            t2 = best;
        }
        else if (this.RBL2.SelectedIndex == 1)
        {
            t2 = better;
        }
        else if (this.RBL2.SelectedIndex == 2)
        {
            t2 = good;
        }
        if (this.RBL3.SelectedIndex == 0)
        {
            t3 = best;
        }
        else if (this.RBL3.SelectedIndex == 1)
        {
            t3 = better;
        }
        else if (this.RBL3.SelectedIndex == 2)
        {
            t3 = good;
        }
        if (this.RBL4.SelectedIndex == 0)
        {
            t4 = best;
        }
        else if (this.RBL4.SelectedIndex == 1)
        {
            t4 = better;
        }
        else if (this.RBL4.SelectedIndex == 2)
        {
            t4 = good;
        }
        if (this.RBL5.SelectedIndex == 0)
        {
            t5 = best;
        }
        else if (this.RBL5.SelectedIndex == 1)
        {
            t5 = better;
        }
        else if (this.RBL5.SelectedIndex == 2)
        {
            t5 = good;
        }
        if (this.RBL6.SelectedIndex == 0)
        {
            t6 = best;
        }
        else if (this.RBL6.SelectedIndex == 1)
        {
            t6 = better;
        }
        else if (this.RBL6.SelectedIndex == 2)
        {
            t6 = good;
        }
        if (this.RBL7.SelectedIndex == 0)
        {
            t7 = best;
        }
        else if (this.RBL7.SelectedIndex == 1)
        {
            t7 = better;
        }
        else if (this.RBL7.SelectedIndex == 2)
        {
            t7 = good;
        }
        if (this.RBL8.SelectedIndex == 0)
        {
            t8 = best;
        }
        else if (this.RBL8.SelectedIndex == 1)
        {
            t8 = better;
        }
        else if (this.RBL8.SelectedIndex == 2)
        {
            t8 = good;
        }
        if (this.RBL9.SelectedIndex == 0)
        {
            t9 = best;
        }
        else if (this.RBL9.SelectedIndex == 1)
        {
            t9 = better;
        }
        else if (this.RBL9.SelectedIndex == 2)
        {
            t9 = good;
        }
        if (this.RBL10.SelectedIndex == 0)
        {
            t10 = best;
        }
        else if (this.RBL10.SelectedIndex == 1)
        {
            t10 = better;
        }
        else if (this.RBL10.SelectedIndex == 2)
        {
            t10 = good;
        }
        #endregion

        if (RBL1.SelectedIndex == -1 || RBL2.SelectedIndex == -1 || RBL3.SelectedIndex == -1 || RBL4.SelectedIndex == -1 || RBL5.SelectedIndex == -1 || RBL6.SelectedIndex == -1 || RBL7.SelectedIndex == -1 || RBL8.SelectedIndex == -1 || RBL9.SelectedIndex == -1 || RBL10.SelectedIndex == -1)
        {
            ds2.alert("请做完所有的评价！", "StuPinJiaTea.aspx");
        }
        else
        {

            int teano = ZhiDaoTea();
            string teaname = ZhiDaoTeaName();
            int zong = t1 + t2 + t3 + t4 + t5 + t6 + t7 + t8 + t9 + t10;
            string SQL = "insert into StuPJTea(Stu_No,Tea_No,Tea_Name,Ti_1,Ti_2,Ti_3,Ti_4,Ti_5,Ti_6,Ti_7,Ti_8,Ti_9,Ti_10,Ti_Zong,IsPingJTea) values("
                       + stuno + ',' + teano + ",'" + teaname + "'," + t1 + ',' + t2 + ',' + t3 + ',' + t4 + ',' + t5 + ',' + t6 + ',' + t7 + ',' + t8 + ',' + t9 + ',' + t10 + ',' + zong + ',' + 1 + ")";

            ds2.DBopen();

            int result = ds2.ExecuteSql(SQL);
            ds2.DBclose();

            if (result > 0)
            {

                System.Web.HttpContext.Current.Response.Write("<script>alert('成功！');</script>");
            }
            else
            {

                System.Web.HttpContext.Current.Response.Write("<script>alert('不成功！');</script>");
            }

        }
    }
}
