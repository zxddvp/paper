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
using System.Windows.Forms;



public partial class XiLeaderPSW : System.Web.UI.Page
{
    protected string xlname;
    protected string teano;
    protected string roleno;
    public paper.Conn ds2 = new paper.Conn();
    protected OleDbDataReader rd;
    protected string strSql;
    protected DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserInfo"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];

            string xlname1 = cookie.Values["xlname"].ToString();
            xlname = HttpUtility.UrlDecode(xlname1);
            teano = cookie.Values["teano"].ToString();
            roleno = cookie.Values["roleno"].ToString();


        }
        if (!IsPostBack)
        {
            IniWeb();
        }


    }
    public void IniWeb()
    {
        this.StunoTBox.Text = xlname;
        this.CurrentPassword.Focus();
        this.CurrentPassword.Text = "";
        this.NewPassword.Text = "";
        this.ConfirmNewPassword.Text = "";
    }
    protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
    {
        string stuuser = this.StunoTBox.Text.ToString();

        string cpsw = this.CurrentPassword.Text.ToString();
        string npsw = this.NewPassword.Text.ToString();
        string cnpsw = this.ConfirmNewPassword.Text.ToString();
        Check(stuuser, cpsw, npsw);

    }
    protected void CancelPushButton_Click(object sender, EventArgs e)
    {
        IniWeb();

    }
    private void Check(string t1, string t2, string npsw)
    {

        string Teauser = t1;
        string PassWord = t2;
        string NewPassWord = npsw;
        try
        {

            ds2.DBopen();

            rd = ds2.ExecuteOleDbDataReader("select * from XiLeader  where XL_Name='" + Teauser + "' and XL_psw='" + PassWord + "'");
            if (rd.Read() == true)
            {
                string str = "update XiLeader set XL_psw = '" + NewPassWord + "' where XL_Name = '" + Teauser + "'";
                int eql = ds2.ExecuteSql(str);
                if (eql == 1)
                {
                    IniWeb();
                    ds2.alert("密码更改成功！", "XiLeader.aspx");
                }
                else
                {
                    IniWeb();
                     ds2.alert("密码更改不成功！", "XiLeader.aspx");
                }
            }
            else
            {

                IniWeb();
                ds2.alert("用户名或密码错误！", "XiLeader.aspx");

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


    protected void BackBt_Click(object sender, EventArgs e)
    {
        Response.Redirect("XiLeader.aspx");
    }



}


