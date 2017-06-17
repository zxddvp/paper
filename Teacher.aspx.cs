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
using System.Data.OleDb;
using System.Security;
using System.Windows.Forms;




public partial class Teacher : System.Web.UI.Page
{
    protected string teaname;
    protected string teazhicheng;
    protected string teaxueli;
    protected string teaxuewei;
    protected string teano;


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

            teano = cookie.Values["teano"].ToString();
            roleno = cookie.Values["roleno"].ToString();
        }
        this.timuNameTBox.Focus();
        this.teacherTBox.Text = teaname;
        this.timuNameTBox.Text = "";
        //this.TimuJianjieTBox.Text = "";
        this.TiaojianTBox.Text = "";
        this.TeazcTBox.Text = teazhicheng;
        this.TeaxlTBox.Text = teaxueli;
        this.TeaxwTBox.Text = teaxuewei;
        this.TimuLaiyuanDDL.Items.Insert(0, new ListItem("— —请选择— —", "— —请选择— —"));
        this.TimuLaiyuanDDL.SelectedIndex = 0;
        this.ZhuanyeDDL.Items.Insert(0, new ListItem("— —请选择— —", "— —请选择— —"));
        this.ZhuanyeDDL.SelectedIndex = 0;
        this.JysDDL.Items.Insert(0, new ListItem("— —请选择— —", "— —请选择— —"));
        this.JysDDL.SelectedIndex = 0;
        this.KeTiTypeDDL.Items.Insert(0, new ListItem("— —请选择— —", "— —请选择— —"));
        this.KeTiTypeDDL.SelectedIndex = 0;
        legend.InnerText = "教师上传题目";

    }
    protected void SendBT_Click(object sender, EventArgs e)
    {
        string teaname, timuname, timujianjie, tiaojian;
        int tl_no, tt_no, za_no;


        if (this.teacherTBox.Text == "")
        {
            ds2.alert("请输入教师名！", "Teacher.aspx");
        }

        else if (this.timuNameTBox.Text == "")
        {
            ds2.alert("请输入论文题目！", "Teacher.aspx");
        }
        else if (this.TimuJianjieTBox.Text == "")
        {
            ds2.alert("请输入题目简介！", "Teacher.aspx");
        }
        else if (this.TiaojianTBox.Text == "")
        {
            ds2.alert("请输入完成题目应具备的基本条件！", "Teacher.aspx");
        }
        else if ((this.TimuLaiyuanDDL.SelectedItem.Text.ToString() == "— —请选择— —") ||
                 (this.ZhuanyeDDL.SelectedItem.Text.ToString() == "— —请选择— —") ||
                 (this.JysDDL.SelectedItem.Text.ToString() == "— —请选择— —") ||
                 (this.KeTiTypeDDL.SelectedItem.Text.ToString() == "— —请选择— —"))
        {
            ds2.alert("请选择正确的题目来源、课题类型、专业方向、所属教研室等信息！", "Teacher.aspx");
        }

        else
        {
            teaname = this.teacherTBox.Text.ToString();
            timuname = this.timuNameTBox.Text.ToString();
            timujianjie = this.TimuJianjieTBox.Text.ToString();
            tiaojian = this.TiaojianTBox.Text.ToString();
            tl_no = SeacherTlno();
            tt_no = SeacherKTno();
            za_no = SeacherZAno();
            string jysNostr = this.JysDDL.SelectedItem.Text.ToString();

            int jysNo = JysNametoNo(jysNostr);
            string sbtime = DateTime.Now.ToString();

            string jystime = "";

            string xtime = "";

            //使用DateTime对象的静态属性Now，获取一个表示当前时间的实例：
            //DateTime dt = DateTime.Now;

            //如果需要像23:46 2007-1-26这样的时间格式的话，自己用以下两个方法拼一下就可以了：
            //dt.ToShortTimeString()
            //dt.ToShortDateString()


            string isTmCopy = IsTimuCopy(timuname);
            if (isTmCopy == "true")
            {
                ds2.alert("该论文题目已提交，请更改论文题目！", "Teacher.aspx");
            }
            else
            {

                string SQL = "insert into PaperShengbao(Tea_Name,TimuName,TimuJianjie,TimuTiaojian,TL_No,TT_No,ZA_No,ShenbaoTime,JiaoTime,XiTime,Jys_No) values ('"
                    + teaname + "','" + timuname + "','" + timujianjie + "','" + tiaojian + "'," + tl_no + "," + tt_no + ","
                    + za_no + ",'" + sbtime + "','" + jystime + "','" + xtime + "'," + jysNo + ")";

                ds2.DBopen();

                int result = ds2.ExecuteSql(SQL);
                ds2.DBclose();

                if (result > 0)
                {
                    InitWeb();
                    ds2.alert("申报表提交成功！", "Teacher.aspx");
                }
                else
                {
                    InitWeb();
                    ds2.alert("申报表提交不成功！", "Teacher.aspx");
                }
            }

        }
    }
    public int JysNametoNo(string jysname)//根据教研室名称找到教研室号
    {
        string str = "select Jys_No from Jiaoyanshi where Jys_Name = '" + jysname + "'";
        ds2.DBopen();
        rd = ds2.ExecuteOleDbDataReader(str);
        int jysno;
        if (rd.HasRows)
        {
            rd.Read();
            string jysnostr1 = rd["Jys_No"].ToString();
            rd.Close();
            jysno = ds2.ChangeToInt(jysnostr1);
        }
        else jysno = -1;
        return jysno;
    }

    public string IsTimuCopy(string timu)
    {
        string str = "select TimuName from PaperShengbao where TimuName = '" + timu + "'";
        string bl = "false";
        try
        {
            ds2.DBopen();
            rd = ds2.ExecuteOleDbDataReader(str);

            if (rd.HasRows)
            {
                rd.Read();
                string timuname = rd["TimuName"].ToString();
                rd.Close();
                bl = "true";
            }
            else bl = "false";
            return bl;
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

    public int SeacherTlno() //查找题目来源号
    {

        int tlno = LbNews_Default();

        return tlno;
    }
    public int SeacherKTno() //查找题目类型号
    {
        string ttname = this.KeTiTypeDDL.SelectedItem.Text.ToString();
        string str = "select TT_No from TimuType where TT_Name = " + "'" + ttname + "'";
        try
        {
            ds2.DBopen();
            rd = ds2.ExecuteOleDbDataReader(str);
            if (rd.HasRows)
            {
                rd.Read();
                string ttnoname = rd["TT_No"].ToString();
                rd.Close();
                int ttno = ds2.ChangeToInt(ttnoname);

                return ttno;
            }


            else
            {
                Response.Write("暂时没有记录！");
                return -1;
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

    public int SeacherZAno() //查找专业方向号
    {
        string zaname = this.ZhuanyeDDL.SelectedItem.Text.ToString();
        string str = "select ZA_No from ZhuanyeArrow where ZA_Name = " + "'" + zaname + "'";
        try
        {
            ds2.DBopen();
            rd = ds2.ExecuteOleDbDataReader(str);
            if (rd.HasRows)
            {
                rd.Read();
                string zanoname = rd["ZA_No"].ToString();
                rd.Close();
                int zano = ds2.ChangeToInt(zanoname);

                return zano;
            }


            else
            {
                Response.Write("暂时没有记录！");
                return -1;
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


    private int LbNews_Default()
    {
        try
        {

            ds2.DBopen();
            string tlname = this.TimuLaiyuanDDL.SelectedItem.Text.ToString();
            string str = "select TL_No from TimuLaiyuan where TL_Name = " + "'" + tlname + "'";

            rd = ds2.ExecuteOleDbDataReader(str);
            if (rd.HasRows)
            {
                rd.Read();
                string tlnoname = rd["TL_No"].ToString();
                rd.Close();
                int tlno = ds2.ChangeToInt(tlnoname);

                return tlno;
            }


            else
            {
                Response.Write("暂时没有记录！");
                return -1;
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

    protected void ResetBT_Click(object sender, EventArgs e)
    {
        InitWeb();

    }
    protected void SearchBt_Click(object sender, EventArgs e)
    {
        Response.Redirect("TeaSearch.aspx");

    }

    protected void UpdatePswBT_Click(object sender, EventArgs e)
    {
        Response.Redirect("TeaPSW.aspx");
    }
}

