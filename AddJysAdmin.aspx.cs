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
public partial class AddJysAdmin : System.Web.UI.Page
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
            InitWeb();
        }
    }
    public void InitWeb()
    {
        this.jysnameTBox.Text = "";
        this.AdminnoTBox.Text = "";
        this.teaNameTBox.Text = "";
    }
    protected void SendBT_Click(object sender, EventArgs e)
    {
        string jysname, teaName,asminnostr;
        int adminno;

        if (this.jysnameTBox.Text == "")
        {
           ds2.alert("请输入教研室名称！", "AddJysAdmin.aspx");
        }
        else if (this.AdminnoTBox.Text == "")
        {
            ds2.alert("请输入负责人教工号！", "AddJysAdmin.aspx");
        }
        else if (this.teaNameTBox.Text == "")
        {
            ds2.alert("请输入负责教师姓名！", "AddJysAdmin.aspx");
        }
        
        else
        {
            jysname = this.jysnameTBox.Text;
            teaName = this.teaNameTBox.Text;
            asminnostr = this.AdminnoTBox.Text.ToString();
            adminno = ds2.ChangeToInt(asminnostr);
            int tno = SeaTea(teaName);
            string isjysCopy = IsJysCopy(jysname);
            if (isjysCopy == "true")
            {
                ds2.alert("该教研室已经存在，请添加其他教研室！", "AddJysAdmin.aspx");
            }

           
            else if(tno==adminno)//判断教师名和教师号是不是相符的
            {
                string SQL = "insert into Jiaoyanshi(Jys_Name,Jys_Admin,Jys_psw,Tea_No) values ('"
                    + jysname + "','" + teaName + "','" + "1'," + adminno + ")";

                ds2.DBopen();

                ds2.ExecuteSql(SQL);
                InitWeb();
                ds2.alert("教研室添加成功！", "AddJysAdmin.aspx");
    
                ds2.DBclose();
      
            }
            else
            {
                InitWeb();
                ds2.alert("教师信息有误，请重新输入！", "AddJysAdmin.aspx");
                
            }

        }
    }
    public string IsJysCopy(string strJys)
    {
        string str = "select * from Jiaoyanshi where Jys_Name = '" + strJys + "'";
        string bl = "false";
        try
        {
            ds2.DBopen();
            rd = ds2.ExecuteOleDbDataReader(str);

            if (rd.HasRows)
            {
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
    public int SeaTea(string teaName)
    {
        string str = "select Tea_No from Teacher where Tea_Name = '" + teaName +"'";
        int teano = -1;
        try
        {
            ds2.DBopen();
            rd = ds2.ExecuteOleDbDataReader(str);

            if (rd.HasRows)
            {
                rd.Read();
                string teanostr = rd["Tea_No"].ToString();
                teano = ds2.ChangeToInt(teanostr);
                rd.Close();
            }

            return teano;
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
    protected void ReBT_Click(object sender, EventArgs e)
    {
        Response.Redirect("Superuser.aspx");

    }
    protected void ResetBT_Click(object sender, EventArgs e)
    {
        InitWeb();
    }
}
