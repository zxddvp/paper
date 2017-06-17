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

public partial class StuBasedMess : System.Web.UI.Page
{
     protected string stuname;
    protected paper.Conn ds2 = new paper.Conn();
    protected int i = 0;
    protected string stunostr;
    Int64 stuno;
    protected OleDbDataReader rd;
    protected DataSet ds;
    protected string roleno; 
    protected string strSql;
    //protected DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    string stuclass, stuzhuanye, stuhuojiang, stuaihao, stucourse, stuziwopj, stutel;
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

            InitWeb();

        }
    }
    #region 初始化页面
    public void InitWeb()
    {
        
        
        this.LblStuno.Text = stunostr;
        
        this.Lblstuname.Text = stuname;
       
        string str = "select Stu_Name,Stu_Class,Stu_Zhuanye,Stu_Huojiang,Stu_Aihao,Stu_Course,Stu_ZiwoPJ,Stu_Tel from Student where Stu_No=" + stuno;
        try
        {
            ds2.DBopen();
            rd = ds2.ExecuteOleDbDataReader(str);

            if (rd.HasRows)
            {
                rd.Read();
                stuclass = rd["Stu_Class"].ToString();
                stuzhuanye = rd["Stu_Zhuanye"].ToString();
               
                stuhuojiang = rd["Stu_Huojiang"].ToString();
                stuaihao = rd["Stu_Aihao"].ToString();
                stucourse = rd["Stu_Course"].ToString();
                stuziwopj = rd["Stu_ZiwoPJ"].ToString();
                stutel = rd["Stu_Tel"].ToString();
               
                rd.Close();
               
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('inisial error！');</script>");
            }
            //DataTable dt1 = new DataTable();
            //dt1 = TeaBaseMessSel();
            //this.GridView1.DataSource = dt1;
            //this.GridView1.DataBind();
            //this.Lblclass.Focus();

            this.Lblclass.Text = stuclass;
            this.Lblzhuanye.Text = stuzhuanye;

            this.TBoxstuhuojiang.Text = stuhuojiang;
            this.TBoxStuaihao.Text = stuaihao;
            this.TBoxstucourse.Text = stucourse;
            this.TBoxStuziping.Text = stuziwopj;
            this.TBoxStutel.Text = stutel;
            
           
            legend.InnerText = "更新学生基本信息";
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
    #endregion

    #region 更新学生基本信息
    protected void Button1_Click(object sender, EventArgs e)
    {
        string stuclass, stuzhuanye, stuhuojiang, stuaihao, stucourse, stuziwopj, stutel;
      

        if ((this.TBoxStuaihao.Text == "") || (this.TBoxstucourse.Text == "") || (this.TBoxstuhuojiang.Text == "") || (this.TBoxStutel.Text == "")
            || (this.TBoxStuziping.Text == ""))
        {
            System.Web.HttpContext.Current.Response.Write("<script>alert('请确保填写完了‘要求’必须填写的空白信息！');</script>");
        }

        else
        {
            stuclass = this.Lblclass.Text.ToString();
            stuzhuanye = this.Lblzhuanye.Text.ToString();

            stuhuojiang = this.TBoxstuhuojiang.Text.ToString();
            stuaihao = this.TBoxStuaihao.Text.ToString();
            stucourse = this.TBoxstucourse.Text.ToString();
            stuziwopj = this.TBoxStuziping.Text;
            stutel = this.TBoxStutel.Text;

            //teasex = this.SexTBox.Text;
            //teaschool = this.SchoolTBox.Text;
            //teazhuanye = this.ZhuanyeTBox.Text;
            //teakeyan = this.TBoxKeyan.Value;
            //teaarrow = this.ArrowTBox.Text;
            //teacourse = this.CourseTBox.Text;
            //teajiaogai = this.JiaogaiTBox.Value;
            //teaxingqu = this.TBoxXingqu.Text;
            //teaxueshulw = this.TBoxXueshulw.Value;

            //使用DateTime对象的静态属性Now，获取一个表示当前时间的实例：
            //DateTime dt = DateTime.Now;

            //如果需要像23:46 2007-1-26这样的时间格式的话，自己用以下两个方法拼一下就可以了：
            //dt.ToShortTimeString()
            //dt.ToShortDateString()

            string SQL = "update Student set  Stu_Huojiang='" + stuhuojiang + "',Stu_Aihao='" + stuaihao + "',Stu_Course='" + stucourse + "',Stu_ZiwoPJ='"
                + stuziwopj + "',Stu_Tel='" + stutel + "' where Stu_No =" + stuno;
            try
            {
                ds2.DBopen();

                int result = ds2.ExecuteSql(SQL);


                if (result > 0)
                {
                    InitWeb();
                    System.Web.HttpContext.Current.Response.Write("<script>alert('学生信息更新成功！');</script>");
                }
                else
                {
                    InitWeb();
                    System.Web.HttpContext.Current.Response.Write("<script>alert('学生信息更新不成功！');</script>");
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
    }
   #endregion
}
