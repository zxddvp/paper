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

public partial class JysAdminPSW : System.Web.UI.Page
{
   // protected string jysadmin;


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
           // string jysadmin1 = cookie.Values["teaname"].ToString();
            //jysadmin = HttpUtility.UrlDecode(jysadmin1);
            
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
        this.StunoTBox.Text = teano;
        this.CurrentPassword.Focus();
        this.CurrentPassword.Text = "";
        this.NewPassword.Text = "";
        this.ConfirmNewPassword.Text = "";
    }
    protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
    {
        string stuuser = this.StunoTBox.Text.ToString();
        int stuuserno = ds2.ChangeToInt(stuuser);
        string cpsw = this.CurrentPassword.Text.ToString();
        string npsw = this.NewPassword.Text.ToString();
        string cnpsw = this.ConfirmNewPassword.Text.ToString();
        Check(stuuserno, cpsw, npsw);

    }
    protected void CancelPushButton_Click(object sender, EventArgs e)
    {
        IniWeb();

    }
    private void Check(int t1, string t2, string npsw)
    {

        int Teauserno = t1;
        string PassWord = t2;
        string NewPassWord = npsw;
        try
        {

            ds2.DBopen();

            rd = ds2.ExecuteOleDbDataReader("select * from Jiaoyanshi  where Tea_No=" + Teauserno + " and Jys_psw='" + PassWord + "'");
            if (rd.Read() == true)
            {
                string str = "update Jiaoyanshi set Jys_psw = '" + NewPassWord + "' where Tea_No = " + Teauserno;
                int eql = ds2.ExecuteSql(str);
                if (eql == 1)
                {
                    IniWeb();
                     ds2.alert("密码更改成功！", "JysAdminPSW.aspx");
                }
                else
                {
                    IniWeb();
                    ds2.alert("密码更改不成功！", "JysAdminPSW.aspx");
                }
            }
            else
            {

                IniWeb();
                ds2.alert("教工号或密码错误！", "JysAdminPSW.aspx");

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
        Response.Redirect("JysShenhe.aspx");
    }
    
        
   
}
