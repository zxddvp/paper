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

public partial class Detail_Dabian : System.Web.UI.Page
{
    string stuidstr;
    protected string teaname;
    protected paper.Conn ds2 = new paper.Conn();
    protected int i = 0;
    protected string teano;
    protected OleDbDataReader rd;
    protected DataSet ds;
    protected DataTable dt;
    protected string roleno;
    int stuid;


    protected void Page_Load(object sender, EventArgs e)
    {
        stuidstr = Request.QueryString["id"].ToString();
        stuid = ds2.ChangeToInt(stuidstr);
        if (!IsPostBack)
        {
           
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

            /*初始化下拉框的值*/
            for (int i = 0; i <= 10; i++)
            {
                this.DDLKaiti.Items.Add(new ListItem(i.ToString(), i.ToString()));
                this.DDLStuYewu.Items.Add(new ListItem(i.ToString(), i.ToString()));
                this.DDLGZliang.Items.Add(new ListItem(i.ToString(), i.ToString()));
                
            }
            for (int i = 0; i <= 50; i++)
            {
                this.DDLHuida.Items.Add(new ListItem(i.ToString(), i.ToString()));
                
            }
            for (int i = 0; i <= 20; i++)
            {
                this.DDLZhiliang.Items.Add(new ListItem(i.ToString(), i.ToString()));

            }
           
            InitWeb();
            legend.InnerText = "答辩评分详细信息";
        } 
    
    }
    public void InitWeb()
    {
        dt = StuDabianBind();
        this.stuNoLbl.Text = dt.Rows[0]["Stu_No"].ToString();
        this.stuNameLbl.Text = dt.Rows[0]["Stu_Name"].ToString();
        this.classLbl.Text = dt.Rows[0]["Stu_Class"].ToString();
        this.stuPaperTimuLbl.Text = dt.Rows[0]["TimuName"].ToString();

        this.DDLKaiti.Text = dt.Rows[0]["dabian_Kaiti"].ToString();
        this.DDLStuYewu.Text = dt.Rows[0]["dabian_StuYewu"].ToString();
        this.DDLZhiliang.Text = dt.Rows[0]["dabian_Zhiliang"].ToString();
        this.DDLHuida.Text = dt.Rows[0]["dabian_Huida"].ToString();
        this.DDLGZliang.Text = dt.Rows[0]["dabian_GZliang"].ToString();
       
        this.zongfenLbl.Text = dt.Rows[0]["dabian_Zong"].ToString();
    }
    public DataTable StuDabianBind()
    {
        stuid = ds2.ChangeToInt(stuidstr);
        string str = "select p.TimuName,s.Stu_No,s.Stu_Name,s.Stu_Class,s.dabian_Kaiti,s.dabian_StuYewu,s.dabian_Zhiliang,s.dabian_Huida,s.dabian_GZliang,s.dabian_Zong"
                   + " from PaperShengbao as p,Student as s where p.ID = s.PSB_Id and "
                   + " s.ID= " + stuid;
        try
        {
            ds2.DBopen();

            ds = ds2.CreateDataSet(str, "StuDabian");
            return dt = ds.Tables["StuDabian"];
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

    //protected void ReturnBT_Click(object sender, EventArgs e)
    //{
    //    Response.Write("<script> history.go(-2); </script>");

    //}
    protected void DabianBT_Click(object sender, EventArgs e)
    {
        //string stuno = this.stuNoLbl.Text;
        //string stuname = this.stuNameLbl.Text;
        //string stuclass = this.classLbl.Text.ToString();
        //string timu = this.stuPaperTimuLbl.Text.ToString();
        string kaitistr = this.DDLKaiti.Text.ToString();
        int kaiti = ds2.ChangeToInt(kaitistr);
        string stuYewustr = this.DDLStuYewu.Text.ToString();
        int stuYewu = ds2.ChangeToInt(stuYewustr);
        string zhiliangstr = this.DDLZhiliang.Text.ToString();
        int zhiliang = ds2.ChangeToInt(zhiliangstr);
        string huidastr = this.DDLHuida.Text.ToString();
        int huida = ds2.ChangeToInt(huidastr);
        string gzliangstr = this.DDLGZliang.Text.ToString();
        int gzliang = ds2.ChangeToInt(gzliangstr);

        string dabianTime = DateTime.Now.ToString();
        int zong = kaiti + stuYewu + zhiliang + huida + gzliang;


        //stuid = ds2.ChangeToInt(stuidstr);
        string SQL = "update Student set dabian_Kaiti = " + kaiti + ", dabian_StuYewu = " + stuYewu
                   + ",dabian_Zhiliang = " + zhiliang + ",dabian_Huida = " + huida + ",dabian_GZliang = "
                   + gzliang + ",dabian_Zong = " + zong
                   + ",dabian_Time = '" + dabianTime + "'"
                   + " where ID = " + stuid;

        ds2.DBopen();

        int result = ds2.ExecuteSql(SQL);
        ds2.DBclose();

        if (result > 0)
        {
            InitWeb();
            System.Web.HttpContext.Current.Response.Write("<script>alert('成功！');</script>");
        }
        else
        {
            InitWeb();
            System.Web.HttpContext.Current.Response.Write("<script>alert('不成功！');</script>");
        }
    }

    protected void zongBT_Click(object sender, EventArgs e)
    {
      
        string scorestr = StuZongScore();
       
        SaveStuZongScore(scorestr);
        this.lblzhehezong.Text = scorestr;
    }
    public string StuZongScore()//学生折合总成绩：评分*0.4+评阅*0.2+答辩*0.4
    {
        string sql = "select Stu_No,(pingfen_Zong*0.4+pingyue_Zong*0.2+dabian_Zong*0.4) as ZongScore from Student where ID = " + stuid;
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
    public void SaveStuZongScore(string zongscroe)
    {
        try
        {
            string str = "update Student set Zhehe_Zong = '" + zongscroe
                       + "'where ID = " + stuid;
            ds2.DBopen();

            int result = ds2.ExecuteSql(str);

        }
        catch (System.Data.OleDb.OleDbException e)
        {
            Response.Write(e.ToString());
        }
        finally
        {
            ds2.DBclose();
        }

    }
   
}
