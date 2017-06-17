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

public partial class XLSelTeaMess : System.Web.UI.Page
{
    protected string teaname, teazhicheng, teaxueli, teaxuewei, teasex, teaschool, teazhuanye, teaarrow, teacourse, teajiaogai, teakeyan,teaxueshulw, teaxingqu;
    public paper.Conn ds2 = new paper.Conn();
    string teaName;
    protected OleDbDataReader rd;
    protected void Page_Load(object sender, EventArgs e)
    {
        teaName = Request.QueryString["id"].ToString();
        BindTeaMess(teaName);

    }
    public void BindTeaMess(string teaName)
    {
        string teaname = teaName;
        string str = "select Tea_name,Tea_Zhicheng,Tea_Xueli,Tea_Xuewei,Tea_Sex,Tea_School,Tea_Speciality,Tea_Arrow,Tea_Course,Tea_JiaoGai,Tea_Keyan,Tea_Xueshulw,Tea_Xingqu from Teacher where Tea_Name='"
                   + teaname + "'";
        ds2.DBopen();
        rd = ds2.ExecuteOleDbDataReader(str);

        if (rd.HasRows)
        {
            rd.Read();
            teaname = rd["Tea_name"].ToString();
            teazhicheng = rd["Tea_Zhicheng"].ToString();
            teaxueli = rd["Tea_Xueli"].ToString();
            teaxuewei = rd["Tea_Xuewei"].ToString();
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
            ds2.DBclose();
        }
        else
        {
            System.Web.HttpContext.Current.Response.Write("<script>alert('inisial error！');</script>");
        }
        this.NameLbl.Text = teaname;
        this.ZhichengLbl.Text = teazhicheng;
        this.XueliLbl.Text = teaxueli;
        this.XueweiLbl.Text = teaxuewei;
        this.SexTBox.Text = teasex;
        this.SchoolTBox.Text = teaschool;
        //this.TimuJianjieTBox.Text = "";
        this.ZhuanyeTBox.Text = teazhuanye;
        this.ArrowTBox.Text = teaarrow;
        this.CourseTBox.Text = teacourse;
        this.JiaogaiTBox.Text = teajiaogai;
        this.TBoxKeyan.Text = teakeyan;
        this.TBoxXingqu.Text = teaxingqu;
        this.LblXueshulw.Text = teaxueshulw;
        //this.SexTBox.Text = dt.Rows[0]["Tea_Sex"].ToString();
        //this.SchoolTBox.Text = dt.Rows[0]["Tea_School"].ToString();
        ////this.TimuJianjieTBox.Text = "";
        //this.ZhuanyeTBox.Text = dt.Rows[0]["Tea_Speciality"].ToString();
        //this.ArrowTBox.Text = dt.Rows[0]["Tea_Arrow"].ToString();
        //this.CourseTBox.Text = dt.Rows[0]["Tea_Course"].ToString();
        //this.JiaogaiTBox.Text = dt.Rows[0]["Tea_JiaoGai"].ToString();
        //this.TBoxKeyan.Text = dt.Rows[0]["Tea_Keyan"].ToString();
        //this.TBoxXingqu.Text = dt.Rows[0]["Tea_Xingqu"].ToString();
        legend.InnerText = "教师基本信息";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("<script> history.go(-2); </script>");
    }
    protected void BTShenhe_Click(object sender, EventArgs e)
    {
        Page.Server.Transfer("XLTeaBMSuggest.aspx?id=" + Request.QueryString["id"].ToString());
    }
}
