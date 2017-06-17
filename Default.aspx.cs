using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Windows.Forms;

public partial class _Default : System.Web.UI.Page 
{
    public paper.Conn ds2 = new paper.Conn();

    protected OleDbDataReader rd;
    protected string strSql;
    protected DataSet ds = new DataSet();
    DataTable dt = new DataTable();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.userIDtBox.Focus();
            this.userIDtBox.Text = "";
            this.pswtBox.Text = "";

           // this.userType.Items.Insert(0, new ListItem("— —请选择— —", "— —请选择— —"));
            this.userType.SelectedIndex = 0;
        }
       
       
    }
    protected void userType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void enterBt_Click(object sender, EventArgs e)
    {
        if (this.userIDtBox.Text == "")
        {
            ds2.alert("请输入用户名！", "Default.aspx");
        }
        else if (this.pswtBox.Text=="")
        {
            ds2.alert("请输入密码！", "Default.aspx");
        }
        
        else
        {
            

            string username = this.userIDtBox.Text.ToString();
            string password = this.pswtBox.Text.ToString();
            string role = this.userType.SelectedItem.Value.ToString();
            int roleno = ds2.ChangeToInt(role);
            if (roleno == 0)
            {
                ds2.alert("请选择用户类型！", "Default.aspx");
            }
            else

            Check(username, password, roleno);
        }

    }
    private void Check(string t1, string t2,int no)
    {


        string UserName = t1;
        string PassWord = t2;
        int roleno = no;

        ds2.DBopen();
        if (roleno == 4)
        {
            rd = ds2.ExecuteOleDbDataReader("select * from Student  where Stu_Name='" + UserName + "' and Stu_psw='" + PassWord + "'");
            if (rd.Read() == true)
            {
                string t = HttpUtility.UrlEncode(rd["Stu_Name"].ToString());
                HttpCookie MyCookies;
                MyCookies = new HttpCookie("UserInfo");
                MyCookies.Values.Add("stuname", t);
                MyCookies.Values.Add("stuno", rd["Stu_No"].ToString());
                MyCookies.Values.Add("roleno", rd["Role_No"].ToString());
                MyCookies.Expires = DateTime.MaxValue;
                Response.AppendCookie(MyCookies);
                Response.Redirect("StuBackground.aspx");
            }
            else
            {


                ds2.alert("用户名或者密码错误", "Default.aspx");

            }

        }
        else if (roleno == 1)
        {

            rd = ds2.ExecuteOleDbDataReader("select * from Teacher  where Tea_Name = '" + UserName + "' and Tea_psw='" + PassWord + "'" + "and Role_No =" + roleno);


            if (rd.Read() == true)
            {

                string t = HttpUtility.UrlEncode(rd["Tea_Name"].ToString());
                string tzc = HttpUtility.UrlEncode(rd["Tea_zhicheng"].ToString());
                string txl = HttpUtility.UrlEncode(rd["Tea_xueli"].ToString());
                string txw = HttpUtility.UrlEncode(rd["Tea_xuewei"].ToString());
                
                //Response.Cookies.Add(c);
                ////读取cookies时 
                //t = 获取的中文cookies值;
                //t = HttpUtility.UrlDecode(teacher_name); 

                HttpCookie MyCookies;
                MyCookies = new HttpCookie("UserInfo");
                MyCookies.Values.Add("teaname", t);
                MyCookies.Values.Add("teazhicheng",tzc);
                MyCookies.Values.Add("teaxueli", txl);
                MyCookies.Values.Add("teaxuewei", txw);

                MyCookies.Values.Add("teano", rd["Tea_No"].ToString());
                MyCookies.Values.Add("roleno", rd["Role_No"].ToString());
                MyCookies.Expires = DateTime.MaxValue;
                Response.AppendCookie(MyCookies);
                //Response.Redirect("TeaSearch.aspx");
                Response.Redirect("TeaBackground.aspx");
               
            }
               
                
            else
            {


                ds2.alert("用户名或者密码错误", "Default.aspx");

            }
        }
        else if (roleno == 2)
        {
            rd = ds2.ExecuteOleDbDataReader("select * from Jiaoyanshi  where Jys_Admin = '" + UserName + "' and Jys_psw='" + PassWord + "'" + "and Role_No =" + roleno);


            if (rd.Read() == true)
            {
                string t = HttpUtility.UrlEncode(rd["Jys_Admin"].ToString());
                HttpCookie MyCookies;
                MyCookies = new HttpCookie("UserInfo");
                MyCookies.Values.Add("jysadmin",t);
                MyCookies.Values.Add("teano", rd["Tea_No"].ToString());
                MyCookies.Values.Add("roleno", rd["Role_No"].ToString());
                MyCookies.Values.Add("jysno", rd["Jys_No"].ToString());
                MyCookies.Expires = DateTime.MaxValue;
                Response.AppendCookie(MyCookies);
                Response.Redirect("JysBackground.aspx");
            }


            else
            {


                ds2.alert("用户名或者密码错误", "Default.aspx");

            }
           
        }
        else if (roleno == 5)
        {
            rd = ds2.ExecuteOleDbDataReader("select * from UserAdmin  where UA_Name = '" + UserName + "' and UA_psw='" + PassWord + "'" + "and Role_No =" + roleno);


            if (rd.Read() == true)
            {
                string t = HttpUtility.UrlEncode(rd["UA_Name"].ToString());
                HttpCookie MyCookies;
                MyCookies = new HttpCookie("UserInfo");
                MyCookies.Values.Add("uaname",t);
                MyCookies.Values.Add("teano", rd["Tea_No"].ToString());
                MyCookies.Values.Add("roleno", rd["Role_No"].ToString());
                MyCookies.Expires = DateTime.MaxValue;
                Response.AppendCookie(MyCookies);
                Response.Redirect("Superuser.aspx");
            }


            else
            {


                ds2.alert("用户名或者密码错误", "Default.aspx");

            }

        }
        else if (roleno == 6)
        {
            rd = ds2.ExecuteOleDbDataReader("select * from SuperUser  where Sup_Name = '" + UserName + "' and Sup_psw='" + PassWord + "'" + "and Role_No =" + roleno);


            if (rd.Read() == true)
            {
                string t = HttpUtility.UrlEncode(rd["Sup_Name"].ToString());
                HttpCookie MyCookies;
                MyCookies = new HttpCookie("UserInfo");
                MyCookies.Values.Add("supname",t);
                
                MyCookies.Values.Add("roleno", rd["Role_No"].ToString());
                
                Response.AppendCookie(MyCookies);
                Response.Redirect("UadiminBackground.aspx");
            }


            else
            {


                ds2.alert("用户名或者密码错误", "Default.aspx");

            }

        }
        else if (roleno == 3)
        {
            rd = ds2.ExecuteOleDbDataReader("select * from XiLeader  where XL_Name = '" + UserName + "' and XL_psw='" + PassWord + "'" + "and Role_No =" + roleno);


            if (rd.Read() == true)
            {
                string t = HttpUtility.UrlEncode(rd["XL_Name"].ToString());
                HttpCookie MyCookies;
                MyCookies = new HttpCookie("UserInfo");
                MyCookies.Values.Add("xlname",t);
                MyCookies.Values.Add("teano", rd["Tea_No"].ToString());
                MyCookies.Values.Add("roleno", rd["Role_No"].ToString());
                MyCookies.Expires = DateTime.MaxValue;
                Response.AppendCookie(MyCookies);
                Response.Redirect("XiLeaderBackground.aspx");
            }


            else
            {


                ds2.alert("用户名或者密码错误", "Default.aspx");

            }

        }
            

        rd.Close();
        ds2.DBclose();

    }

    protected void userType_SelectedIndexChanged1(object sender, EventArgs e)
    {
        this.enterBt.Focus();
    }
}
