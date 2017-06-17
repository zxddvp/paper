
# region 导入命名空间
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

# endregion



namespace paper
{
	
	// 数据库操作
	public class Conn   //数据访问类
	{
		public Conn()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
     
		// 数据库连接字符串
		public  OleDbConnection Lb_Conn=new OleDbConnection(strConn);
	
		private string vername;


		public int grade;
		

		public string verName
		{
			get
			
			{
				
				vername="毕业论文(设计)管理系统";
			
				return vername;

			}
		
		}


		public static string strConn
		{
			get
			{
				StringBuilder strResult = new StringBuilder();
				strResult.Append("Provider = Microsoft.Jet.OLEDB.4.0");
				strResult.Append("; ");
				strResult.Append("Data Source = ");
                strResult.Append(HttpContext.Current.Server.MapPath("."));
				strResult.Append("\\");
				strResult.Append(System.Configuration.ConfigurationSettings.AppSettings["PdbPath"]);
				return strResult.ToString();
			}
		}
        public void WriteLogfile(string s)
        {
            string str = s;
            string dtime = DateTime.Now.ToString();
            string sql = "insert into LogFile (LF_content,LF_Time)values('" + s + "','" + dtime + "')";
            this.DBopen();

            this.ExecuteSql(sql);
            this.DBclose();
        }



		public void DBopen()
		{
			if (Lb_Conn.State==ConnectionState.Closed)
			{
				Lb_Conn.Open();	
			}
		}

		public void DBclose()
		{
			if (Lb_Conn.State==ConnectionState.Open)
			{
				Lb_Conn.Close();
			}
		}

		public OleDbDataReader ExecuteOleDbDataReader(string strSql)
		{		

			OleDbCommand cmd=new OleDbCommand(strSql,Lb_Conn);				
			OleDbDataReader rd=cmd.ExecuteReader();
			return rd;
	
		}
	


		public DataSet CreateDataSet(string strSql,string tableName)
		{
			OleDbDataAdapter da=new OleDbDataAdapter(strSql,Lb_Conn);
			DataSet dst=new DataSet();
			da.Fill(dst,tableName);
			return dst;
				
		}
		
		public int ChangeToInt(string a)
		{
			
			int b=Int32.Parse(a.ToString());
			return b;
		
		}

		
		public int ExecuteSql(string strSql)
		{
			
			OleDbCommand cmd2=new OleDbCommand(strSql,Lb_Conn);	
			int	result=cmd2.ExecuteNonQuery();

			return result;
		
		}

		//登陆检验 or 管理页面检验

		public void CheckCookies(int check_grade)
		{


		
		
			if (System.Web.HttpContext.Current.Request.Cookies["UserInfo"]==null)
			{
				System.Web.HttpContext.Current.Response.Redirect ("admin_login.aspx");
			
			}
			else
			{
				
				HttpCookie Mycookie=System.Web.HttpContext.Current.Request.Cookies["UserInfo"];
                    
				grade=ChangeToInt(Mycookie.Values["grade"].ToString());
              
				if (grade<check_grade)
				{
				
					 

					System.Web.HttpContext.Current.Response.Write ("<script>alert('你的权限不够');location.href('admin_main.htm')</script>");
				
				}
			
				
				
			}
			System.Web.HttpContext.Current.Response.Write("<div align='center'><a style='font-size:15px;color:#FFFFFF;font-weight:bold;'>新闻后台管理区</a></div>");

			
		
		}

	
		//javascript

		public void alert(string a,string b) 
		{
			string Content=a.ToString();
			string Url=b.ToString();
			 
			System.Web.HttpContext.Current.Response.Write ("<script>alert('"+Content+"');location.href('"+Url+"')</script>");

		}

	

		//测试
		public void test()
		{
		
			System.Web.HttpContext.Current.Response.Write ("Hello World!");

		}

	}

	//ReWrite
	public class UrlFormat
	{

		public UrlFormat()
		{
		}

		public virtual string NewsUrl(int NewsID)
		{
			return GetUrl("n" + NewsID + ".aspx");
		}

		public virtual string ClassUrl(int ClassID)
		{
			return GetUrl("c" + ClassID + ".aspx");
		}

		protected virtual string GetUrl(string pattern, params object[] items)
		{
			return string.Format(pattern,items);
		}

	}
}
