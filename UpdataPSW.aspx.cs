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
using System.Windows.Forms;
using System.Data.OleDb;

public partial class UpdataPSW : System.Web.UI.Page
{
    protected string stuname;
    protected paper.Conn ds2 = new paper.Conn();
    protected int i = 0;
    protected string stuno;
    protected OleDbDataReader rd;
    protected DataSet ds;
    protected string roleno;
 
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
            stuno = cookie.Values["stuno"].ToString();
            roleno = cookie.Values["roleno"].ToString();
            
           
        }
        if (!IsPostBack)
        {
            IniWeb();
        }
        

    }
    public void IniWeb()
    {
        this.StunoTBox.Text = stuno;
        this.CurrentPassword.Focus();
        this.CurrentPassword.Text = "";
        this.NewPassword.Text = "";
        this.ConfirmNewPassword.Text = "";
        legend.InnerText = "修改密码";
    }
    protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
    {
        string stuuser = this.StunoTBox.Text.ToString();
        double stuuserno = double.Parse(stuuser);
        string cpsw = this.CurrentPassword.Text.ToString();
        string npsw = this.NewPassword.Text.ToString();
        string cnpsw = this.ConfirmNewPassword.Text.ToString();
        Check(stuuserno, cpsw, npsw);
        
    }
    protected void CancelPushButton_Click(object sender, EventArgs e)
    {
        this.StunoTBox.Text = stuno;
        this.CurrentPassword.Focus();
        this.CurrentPassword.Text = "";
        this.NewPassword.Text = "";
        this.ConfirmNewPassword.Text = "";

    }
    private void Check(double t1, string t2, string npsw)
    {

        double Stuuserno = t1;
        string PassWord = t2;
        string NewPassWord = npsw;
        try
        {

            ds2.DBopen();

            rd = ds2.ExecuteOleDbDataReader("select * from Student  where Stu_No=" + Stuuserno + " and Stu_psw='" + PassWord + "'");
            if (rd.Read() == true)
            {
                string str = "update Student set Stu_psw = '" + NewPassWord + "' where Stu_No = " + Stuuserno;
                int eql = ds2.ExecuteSql(str);
                if (eql == 1)
                {
                    IniWeb();
                    ds2.alert("密码更改成功", "UpdataPSW.aspx");
                }
                else
                {
                    IniWeb();
                    ds2.alert("密码更改不成功", "UpdataPSW.aspx");
                }
            }
            else
            {

                IniWeb();
                ds2.alert("学号或密码错误", "UpdataPSW.aspx");

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
