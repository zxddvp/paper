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

public partial class Detail_Pingyue : System.Web.UI.Page
{
    string stuidstr;
   
    protected paper.Conn ds2 = new paper.Conn();
    protected int i = 0;
    protected string teano;
    protected string teaname;
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
                string teaname1 = cookie.Values["teaname"].ToString();
                teaname = HttpUtility.UrlDecode(teaname1);
                teano = cookie.Values["teano"].ToString();
                roleno = cookie.Values["roleno"].ToString();

            }

            /*初始化下拉框的值*/
            for (int i = 0; i <= 20; i++)
            {
                this.DDLGuifan.Items.Add(new ListItem(i.ToString(), i.ToString()));
                this.DDLWNengli.Items.Add(new ListItem(i.ToString(), i.ToString()));


            }
            for (int i = 0; i <= 15; i++)
            {
                this.DDLJiehe.Items.Add(new ListItem(i.ToString(), i.ToString()));

            }
            for (int i = 0; i <= 10; i++)
            {
                this.DDLNew.Items.Add(new ListItem(i.ToString(), i.ToString()));

            }
            for (int i = 0; i <= 35; i++)
            {
                this.DDLZonghe.Items.Add(new ListItem(i.ToString(), i.ToString()));

            }

            InitWeb();
            legend.InnerText = "教师评阅详细信息";
        }

    }
    public void InitWeb()
    {
        dt = JysPingyueBind();
        this.LblTea.Text = dt.Rows[0]["Tea_Name"].ToString();
        this.stuNoLbl.Text = dt.Rows[0]["Stu_No"].ToString();
        this.stuNameLbl.Text = dt.Rows[0]["Stu_Name"].ToString();
        this.classLbl.Text = dt.Rows[0]["Stu_Class"].ToString();
        this.stuPaperTimuLbl.Text = dt.Rows[0]["TimuName"].ToString();

        this.DDLGuifan.Text = dt.Rows[0]["pingyue_Guifan"].ToString();
        this.DDLWNengli.Text = dt.Rows[0]["pingyue_WNengli"].ToString();
        this.DDLZonghe.Text = dt.Rows[0]["pingyue_Zonghe"].ToString();
        this.DDLJiehe.Text = dt.Rows[0]["pingyue_Jiehe"].ToString();
        this.DDLNew.Text = dt.Rows[0]["pingyue_New"].ToString();

        this.zongfenLbl.Text = dt.Rows[0]["pingyue_Zong"].ToString();
    }
    public DataTable JysPingyueBind()
    {
        stuid = ds2.ChangeToInt(stuidstr);
        string str = "select p.Tea_Name,p.TimuName,s.Stu_No,s.Stu_Name,s.Stu_Class,s.pingyue_Guifan,s.pingyue_WNengli,s.pingyue_Zonghe,s.pingyue_Jiehe,s.pingyue_New,s.pingyue_Zong"
                   + " from PaperShengbao as p,Student as s where p.ID = s.PSB_Id and "
                   + " s.ID= " + stuid;
        try
        {
            ds2.DBopen();

            ds = ds2.CreateDataSet(str, "JysPingyue");
            return dt = ds.Tables["JysPingyue"];
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
    protected void PingyueBT_Click(object sender, EventArgs e)
    {
        //string stuno = this.stuNoLbl.Text;
        //string stuname = this.stuNameLbl.Text;
        //string stuclass = this.classLbl.Text.ToString();
        //string timu = this.stuPaperTimuLbl.Text.ToString();
        string Guifanstr = this.DDLGuifan.Text.ToString();
        int Guifan = ds2.ChangeToInt(Guifanstr);
        string Jiehestr = this.DDLJiehe.Text.ToString();
        int Jiehe = ds2.ChangeToInt(Jiehestr);
        string pingyueNewstr = this.DDLNew.Text.ToString();
        int pingyueNew = ds2.ChangeToInt(pingyueNewstr);
        string WNenglistr = this.DDLWNengli.Text.ToString();
        int WNengli = ds2.ChangeToInt(WNenglistr);
        string Zonghestr = this.DDLZonghe.Text.ToString();
        int Zonghe = ds2.ChangeToInt(Zonghestr);

        string pingyueTime = DateTime.Now.ToString();
        int zong = Guifan + Jiehe + pingyueNew + WNengli + Zonghe;

       
        //stuid = ds2.ChangeToInt(stuidstr);
        string SQL = "update Student set pingyue_Guifan = " + Guifan + ", pingyue_Jiehe = " + Jiehe
                   + ",pingyue_New = " + pingyueNew + ",pingyue_WNengli = " + WNengli + ",pingyue_Zonghe = "
                   + Zonghe + ",pingyue_Zong = " + zong
                   + ",pingyue_Time = '" + pingyueTime + "'"
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
