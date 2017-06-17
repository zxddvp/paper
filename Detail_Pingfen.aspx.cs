using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Detail_Pingfen : System.Web.UI.Page
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
                this.DDLLunZheng.Items.Add(new ListItem(i.ToString(), i.ToString()));
                this.DDLFanyi.Items.Add(new ListItem(i.ToString(), i.ToString()));
                this.NewDDL.Items.Add(new ListItem(i.ToString(), i.ToString()));
                this.TaiduDDL.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            for (int i = 0; i <= 20; i++)
            {
                this.ShijiDDL.Items.Add(new ListItem(i.ToString(), i.ToString()));
                
            }
            for (int i = 0; i <= 15; i++)
            {
                this.WriteDDL.Items.Add(new ListItem(i.ToString(), i.ToString()));

            }
            for (int i = 0; i <= 25; i++)
            {
                this.ChengguoDDL.Items.Add(new ListItem(i.ToString(), i.ToString()));

            }
            InitWeb(); 
       
        
        legend.InnerText = "题目详细信息";
        } 
    
    }
    public void InitWeb()
    {
        dt = StuPingfenBind();
        this.stuNoLbl.Text = dt.Rows[0]["Stu_No"].ToString();
        this.stuNameLbl.Text = dt.Rows[0]["Stu_Name"].ToString();
        this.classLbl.Text = dt.Rows[0]["Stu_Class"].ToString();
        this.stuPaperTimuLbl.Text = dt.Rows[0]["TimuName"].ToString();
        this.DDLLunZheng.Text = dt.Rows[0]["Pingfen_LunZheng"].ToString();
        this.DDLFanyi.Text = dt.Rows[0]["Pingfen_Fanyi"].ToString();
        this.ShijiDDL.Text = dt.Rows[0]["Pingfen_Shiji"].ToString();
        this.ChengguoDDL.Text = dt.Rows[0]["Pingfen_Chengguo"].ToString();
        this.NewDDL.Text = dt.Rows[0]["Pingfen_New"].ToString();
        this.WriteDDL.Text = dt.Rows[0]["Pingfen_Write"].ToString();
        this.TaiduDDL.Text = dt.Rows[0]["Pingfen_Taidu"].ToString();
        this.zongfenLbl.Text = dt.Rows[0]["pingfen_Zong"].ToString();
    }
    public DataTable StuPingfenBind()
    {
        stuid = ds2.ChangeToInt(stuidstr);
        string str = "select p.TimuName,s.Stu_No,s.Stu_Name,s.Stu_Class,s.Pingfen_LunZheng,s.Pingfen_Fanyi,s.Pingfen_Shiji,s.Pingfen_Chengguo,Pingfen_New,s.Pingfen_Write,s.Pingfen_Taidu,s.pingfen_Zong"
                   + " from PaperShengbao as p,Student as s where p.ID = s.PSB_Id and "
                   + " s.ID= " + stuid;
        try
        {
            ds2.DBopen();

            ds = ds2.CreateDataSet(str, "StuPingfen");
            return dt = ds.Tables["StuPingfen"];
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
    protected void PingfenBT_Click(object sender, EventArgs e)
    {
        //string stuno = this.stuNoLbl.Text;
        //string stuname = this.stuNameLbl.Text;
        //string stuclass = this.classLbl.Text.ToString();
        //string timu = this.stuPaperTimuLbl.Text.ToString();
        string lunzhengstr = this.DDLLunZheng.Text.ToString();
        int lunzheng = ds2.ChangeToInt(lunzhengstr);
        string fanyistr = this.DDLFanyi.Text.ToString();
        int fanyi = ds2.ChangeToInt(fanyistr);
        string shijistr = this.ShijiDDL.Text.ToString();
        int shiji = ds2.ChangeToInt(shijistr);
        string chengguostr = this.ChengguoDDL.Text.ToString();
        int chengguo = ds2.ChangeToInt(chengguostr);
        string stunewstr = this.NewDDL.Text.ToString();
        int stunew = ds2.ChangeToInt(stunewstr);
        string writestr = this.WriteDDL.Text.ToString();
        int write = ds2.ChangeToInt(writestr);
        string taidustr = this.TaiduDDL.Text.ToString();
        int taidu = ds2.ChangeToInt(taidustr);
        string pingfenTime = DateTime.Now.ToString();
        int zong = lunzheng + fanyi + shiji + chengguo + stunew + write + taidu;
       

        //stuid = ds2.ChangeToInt(stuidstr);
        string SQL = "update Student set Pingfen_LunZheng = " + lunzheng + ", Pingfen_Fanyi = " + fanyi 
                   + ",Pingfen_Shiji = " + shiji + ",Pingfen_Chengguo = " + chengguo + ",Pingfen_New = " 
                   + stunew + ",Pingfen_Write = " + write + ",Pingfen_Taidu = " + taidu
                   + ",pingfen_Zong = " + zong
                   + ",pingfen_Time = '" + pingfenTime + "'"
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
}
