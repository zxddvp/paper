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

public partial class TeaBaseMessage : System.Web.UI.Page
{
    protected string teaname;
    protected string teazhicheng;
    protected string teaxueli;
    protected string teaxuewei;
    protected int teano;
    protected string teashenhe,teayijian, teasex, teaschool, teazhuanye, teaarrow, teacourse, teajiaogai, teakeyan,teaxueshulw, teaxingqu;

    protected string roleno;

    public paper.Conn ds2 = new paper.Conn();

    protected OleDbDataReader rd;
    protected string strSql;
    protected DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            InitWeb();

        }
    }
    public void InitWeb()
    {
        
        if (Request.Cookies["UserInfo"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            //t = 获取的中文cookies值;
            //t = HttpUtility.UrlDecode(teacher_name); 
            HttpCookie cookie = Request.Cookies["UserInfo"];
            string teaname1 = cookie.Values["teaname"].ToString();
            teaname = HttpUtility.UrlDecode(teaname1);

            string teazhicheng1 = cookie.Values["teazhicheng"].ToString();
            teazhicheng = HttpUtility.UrlDecode(teazhicheng1);

            string teaxueli1 = cookie.Values["teaxueli"].ToString();
            teaxueli = HttpUtility.UrlDecode(teaxueli1);
            string teaxuewei1 = cookie.Values["teaxuewei"].ToString();
            teaxuewei = HttpUtility.UrlDecode(teaxuewei1);

            string teanostr = cookie.Values["teano"].ToString();
            teano = ds2.ChangeToInt(teanostr);
            roleno = cookie.Values["roleno"].ToString();
        }
        
        this.NameLbl.Text = teaname;
        
        this.ZhichengLbl.Text = teazhicheng;
        this.XueliLbl.Text = teaxueli;
        this.XueweiLbl.Text = teaxuewei;
        string str = "select Tea_Shenhe,Tea_Suggest, Tea_Sex,Tea_School,Tea_Speciality,Tea_Arrow,Tea_Course,Tea_JiaoGai,Tea_Keyan,Tea_Xueshulw,Tea_Xingqu from Teacher where Tea_Name='" + teaname + "'";
        try
        {
            ds2.DBopen();
            rd = ds2.ExecuteOleDbDataReader(str);

            if (rd.HasRows)
            {
                rd.Read();
                teashenhe = rd["Tea_Shenhe"].ToString();
                teayijian = rd["Tea_Suggest"].ToString();
                teasex = rd["Tea_Sex"].ToString();
                teaschool = rd["Tea_School"].ToString();
                teazhuanye = rd["Tea_Speciality"].ToString();
                teaarrow = rd["Tea_Arrow"].ToString();
                teacourse = rd["Tea_Course"].ToString();
                teajiaogai = rd["Tea_JiaoGai"].ToString();
                teakeyan = rd["Tea_Keyan"].ToString();
                teaxingqu = rd["Tea_Xingqu"].ToString();
                teaxueshulw = rd["Tea_Xueshulw"].ToString();
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
            this.XLShenhe.Text = teashenhe;
            this.XLXiugai.Text = teayijian;
            this.SexTBox.Focus();

            this.SexTBox.Text = teasex;
            this.SchoolTBox.Text = teaschool;
            //this.TimuJianjieTBox.Text = "";
            this.ZhuanyeTBox.Text = teazhuanye;
            this.ArrowTBox.Text = teaarrow;
            this.CourseTBox.Text = teacourse;
            this.JiaogaiTBox.Value = teajiaogai;
            this.TBoxKeyan.Value = teakeyan;
            this.TBoxXingqu.Text = teaxingqu;
            this.TBoxXueshulw.Value = teaxueshulw;
            //this.SexTBox.Text = dt.Rows[0]["Tea_Sex"].ToString();
            //this.SchoolTBox.Text = dt.Rows[0]["Tea_School"].ToString();
            ////this.TimuJianjieTBox.Text = "";
            //this.ZhuanyeTBox.Text = dt.Rows[0]["Tea_Speciality"].ToString();
            //this.ArrowTBox.Text = dt.Rows[0]["Tea_Arrow"].ToString();
            //this.CourseTBox.Text = dt.Rows[0]["Tea_Course"].ToString();
            //this.JiaogaiTBox.Text = dt.Rows[0]["Tea_JiaoGai"].ToString();
            //this.TBoxKeyan.Text = dt.Rows[0]["Tea_Keyan"].ToString();
            //this.TBoxXingqu.Text = dt.Rows[0]["Tea_Xingqu"].ToString();
            legend.InnerText = "更新教师基本信息";
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

    #region 更新教师基本信息
    protected void Button1_Click(object sender, EventArgs e)
    {
        string teasex, teaschool, teazhuanye, teaarrow, teacourse, teajiaogai, teakeyan,teaxueshulw, teaxingqu;
        string teaname = this.NameLbl.Text.ToString(); 

        if ((this.SexTBox.Text == "") || (this.SchoolTBox.Text == "") || (this.ZhuanyeTBox.Text == "") || (this.ArrowTBox.Text == "")
            || (this.CourseTBox.Text == ""))
        {
            System.Web.HttpContext.Current.Response.Write("<script>alert('请确保填写完了‘要求’必须填写的空白信息！');</script>");
        }

        else
        {
            teasex = this.SexTBox.Text;
            teaschool = this.SchoolTBox.Text;
            teazhuanye = this.ZhuanyeTBox.Text;
            teakeyan = this.TBoxKeyan.Value;
            teaarrow = this.ArrowTBox.Text;
            teacourse = this.CourseTBox.Text;
            teajiaogai = this.JiaogaiTBox.Value;
            teaxingqu = this.TBoxXingqu.Text;
            teaxueshulw = this.TBoxXueshulw.Value;

            //使用DateTime对象的静态属性Now，获取一个表示当前时间的实例：
            //DateTime dt = DateTime.Now;

            //如果需要像23:46 2007-1-26这样的时间格式的话，自己用以下两个方法拼一下就可以了：
            //dt.ToShortTimeString()
            //dt.ToShortDateString()

            string SQL = "update Teacher set  Tea_Sex='" + teasex + "',Tea_School='" + teaschool + "',Tea_Speciality='" + teazhuanye + "',Tea_Arrow='" 
                + teaarrow + "',Tea_Course='" + teacourse + "',Tea_JiaoGai='" + teajiaogai + "',Tea_Keyan='" + teakeyan + "',Tea_Xingqu='" + teaxingqu
                + "',Tea_Xueshulw ='" + teaxueshulw 
                + "',Tea_Shenhe='未审核' where Tea_Name ='" + teaname + "'";
            try
            {
                ds2.DBopen();

                int result = ds2.ExecuteSql(SQL);
               

                if (result > 0)
                {
                    InitWeb();
                    System.Web.HttpContext.Current.Response.Write("<script>alert('教师信息更新成功！');</script>");
                }
                else
                {
                    InitWeb();
                    System.Web.HttpContext.Current.Response.Write("<script>alert('教师信息不更新成功！');</script>");
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

    //#region 读取教师基本信息
    //public DataTable TeaBaseMessSel()
    //{
    //    DataSet ds1 = new DataSet();
    //    DataTable dt = new DataTable();
    //    string teaname = this.NameLbl.Text.ToString();
       
        
    //    try
    //    {
           
    //        ds2.DBopen();

    //        ds = ds2.CreateDataSet(str, "TeacherBase");
    //        //dv1 = ds.Tables[0].DefaultView;
    //        //dv1.Sort = SortExpression + " " + SortDirection;//指定视图的排序方式
    //        //return dv1;
    //        this.GridView1.DataSource = ds;
    //        this.GridView1.DataBind();
    //        dt = ds1.Tables["TeacherBase"];
    //        return dt;

    //    }
    //    catch (System.Data.OleDb.OleDbException e)
    //    {
    //        Response.Write(e.ToString());
    //        return null;

    //    }
    //    finally
    //    {
    //        ds2.DBclose();
    //    }
    //}
    //#endregion
}
