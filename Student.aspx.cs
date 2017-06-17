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

public partial class Student : System.Web.UI.Page
{
    protected string stuname;
    protected paper.Conn ds2 = new paper.Conn();
    protected int i = 0;
    protected string stunostr;
    Int64 stuno;
    protected OleDbDataReader rd;
    protected DataSet ds;
    protected string roleno;
    protected string isselect;
    protected string isallowed;
    
    
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
            int i = IsStuSelected();
            isselect = i.ToString();
        }
        if(!IsPostBack)
        {            
        
        DataSet ds1 = new DataSet();
        ds1 = StuSelTimu();
        if ((isselect == "0")|| ((isselect == "1") && (isallowed != "同意")))
            {
                ds = TeaTimuBind();
        this.StuDataGrid.DataSource = ds;
        StuDataGrid.DataBind();
            }
        //    else
        //    {
        //this.StuDataGrid1.DataSource = ds1;
        //StuDataGrid1.DataBind();
        //    }
        legend.InnerText = "论文题目";  
        }
    }
    public DataSet StuSelTimu()//学生选择题目之后显示自己选择的题目信息
    {
        int id;
        string idstr = PSBId();
        if (idstr == "")
        {
            id = 0;

        }
        else id = ds2.ChangeToInt(idstr);
        string str = "select p.ID,t.Tea_Name,t.Tea_Telno,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za,Teacher as t "
                   + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No and p.Tea_Name = t.Tea_Name and p.ID=" + id;
        try
        {
            ds2.DBopen();

            ds = ds2.CreateDataSet(str, "PaperShengbao");
            return ds;

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
    public string PSBId()
    {
        string str = "select PSB_Id from student where Stu_No = " + stuno;
        try
        {
            ds2.DBopen();

            rd = ds2.ExecuteOleDbDataReader(str);
            if(rd.HasRows)
            {
                rd.Read();
                string psbidstr = rd["PSB_Id"].ToString();
               
                rd.Close();
                return psbidstr;
            }
            return null;

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

    #region 通过学号得到学生的专业“信本”“数本”
    public string StunotoClass()
    {
        string str = "select Stu_Zhuanye from Student where Stu_No = " + stuno;
        try
        {
            ds2.DBopen();

            rd = ds2.ExecuteOleDbDataReader(str);
            if (rd.HasRows)
            {
                rd.Read();
                string stuzhuanye = rd["Stu_Zhuanye"].ToString();

                rd.Close();
                return stuzhuanye;
            }
            return null;

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
    #endregion

    #region 读取教师题目允许被选的数目
    public string TeaAllowNum(string teaname)
    {
        string allownum ="10";
        string teaName = teaname;
        string str = "select Tea_AllowNum from Teacher where Tea_Name = '" + teaName + "'";
        try
        {
            ds2.DBopen();

            rd  = ds2.ExecuteOleDbDataReader(str);
            if( rd.HasRows)
            {
                rd.Read();
                allownum = rd["Tea_AllowNum"].ToString();
                
                rd.Close();
            }
            return allownum;

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
    #endregion

    #region 绑定所有通过审核并且没有被选择的论文题目
    public DataSet TeaTimuBind()
    {
        string stuZye = StunotoClass();
        string str;
        if (stuZye == "信本")
        {
            str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                  + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                  + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                 ;// +" and (p.Jys_No = 10 or p.Jys_No = 1 or Jys_No = 9)";
        }
        else
        {
            str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                   + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                   + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                   + " and p.Jys_No not in (select Jys_No from PaperShengbao where Jys_No = 10)";
        }
        try
        {
            ds2.DBopen();
            
            ds = ds2.CreateDataSet(str, "PaperShengbao");
            return ds;

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
    #endregion

    #region 按不同的条件范围搜索论文题目内容——信本专业
    public DataSet DBoundXinben()
    {
        if ((this.TLCbox.Checked == true) && (this.TTCbox.Checked == true) && (this.ZACbox.Checked == true))
        {
            string tlname = this.TLDdl.SelectedItem.Text.ToString();
            string ttname = this.TTDdl.SelectedItem.Text.ToString();
            string zaname = this.ZADdl.SelectedItem.Text.ToString();

            string str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                   + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No"
                   + " and tl.TL_Name = '" + tlname + "' and tt.TT_Name = '" + ttname + "' and za.ZA_Name = '" + zaname + "' and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                    + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                   ;// +" and p.Jys_No = 10"; 

            try
            {
                ds2.DBopen();

                ds = ds2.CreateDataSet(str, "PaperShengbao");

                

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
        else if ((this.TLCbox.Checked == true) && (this.TTCbox.Checked == true) && (this.ZACbox.Checked != true))
        {
            string tlname = this.TLDdl.SelectedItem.Text.ToString();
            string ttname = this.TTDdl.SelectedItem.Text.ToString();


            string str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                   + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No"
                   + " and tl.TL_Name = '" + tlname + "' and tt.TT_Name = '" + ttname + "' and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                    + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                   ;// +" and p.Jys_No = 10"; 
           
            try
            {
                ds2.DBopen();

                ds = ds2.CreateDataSet(str, "PaperShengbao");

               
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
        else if ((this.TLCbox.Checked == true) && (this.TTCbox.Checked != true) && (this.ZACbox.Checked == true))
        {
            string tlname = this.TLDdl.SelectedItem.Text.ToString();

            string zaname = this.ZADdl.SelectedItem.Text.ToString();

            string str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                   + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No"
                   + " and tl.TL_Name = '" + tlname + "' and za.ZA_Name = '" + zaname + "' and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                    + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                   ;// +" and p.Jys_No = 10"; 
          
            try
            {
                ds2.DBopen();

                ds = ds2.CreateDataSet(str, "PaperShengbao");

               

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
        else if ((this.TLCbox.Checked != true) && (this.TTCbox.Checked == true) && (this.ZACbox.Checked == true))
        {

            string ttname = this.TTDdl.SelectedItem.Text.ToString();
            string zaname = this.ZADdl.SelectedItem.Text.ToString();

            string str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                   + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No"
                   + " and tt.TT_Name = '" + ttname + "' and za.ZA_Name = '" + zaname + "' and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                    + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                    ;// +" and p.Jys_No = 10";
         
            try
            {
                ds2.DBopen();

                ds = ds2.CreateDataSet(str, "PaperShengbao");

              
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
        else if ((this.TLCbox.Checked != true) && (this.TTCbox.Checked != true) && (this.ZACbox.Checked == true))
        {

            string zaname = this.ZADdl.SelectedItem.Text.ToString();

            string str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                   + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No"
                   + " and za.ZA_Name = '" + zaname + "' and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                    + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                   ;// +" and p.Jys_No = 10";
           
            try
            {
                ds2.DBopen();

                ds = ds2.CreateDataSet(str, "PaperShengbao");

               

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
        else if ((this.TLCbox.Checked != true) && (this.TTCbox.Checked == true) && (this.ZACbox.Checked != true))
        {

            string ttname = this.TTDdl.SelectedItem.Text.ToString();


            string str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                   + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No"
                   + " and tt.TT_Name = '" + ttname + "' and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                    + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                   ;// +" and p.Jys_No = 10";
           
            try
            {
                ds2.DBopen();

                ds = ds2.CreateDataSet(str, "PaperShengbao");

              
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
        else if ((this.TLCbox.Checked == true) && (this.TTCbox.Checked != true) && (this.ZACbox.Checked != true))
        {
            string tlname = this.TLDdl.SelectedItem.Text.ToString();


            string str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                   + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No"
                   + " and tl.TL_Name = '" + tlname + "' and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                    + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                    ;// +" and p.Jys_No = 10";
          
            try
            {
                ds2.DBopen();

                ds = ds2.CreateDataSet(str, "PaperShengbao");

               

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
        else if ((this.TLCbox.Checked != true) && (this.TTCbox.Checked != true) && (this.ZACbox.Checked != true))
        {
            ds = TeaTimuBind();
            
        }
        return ds;
    }
    #endregion

    #region 按不同的条件范围搜索论文题目内容——数本专业
    public DataSet DBoundShuben()
    {
        if ((this.TLCbox.Checked == true) && (this.TTCbox.Checked == true) && (this.ZACbox.Checked == true))
        {
            string tlname = this.TLDdl.SelectedItem.Text.ToString();
            string ttname = this.TTDdl.SelectedItem.Text.ToString();
            string zaname = this.ZADdl.SelectedItem.Text.ToString();

            string str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                   + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No"
                   + " and tl.TL_Name = '" + tlname + "' and tt.TT_Name = '" + ttname + "' and za.ZA_Name = '" + zaname + "' and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                    + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                     + " and p.Jys_No not in (select Jys_No from PaperShengbao where Jys_No = 10)";

            try
            {
                ds2.DBopen();

                ds = ds2.CreateDataSet(str, "PaperShengbao");



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
        else if ((this.TLCbox.Checked == true) && (this.TTCbox.Checked == true) && (this.ZACbox.Checked != true))
        {
            string tlname = this.TLDdl.SelectedItem.Text.ToString();
            string ttname = this.TTDdl.SelectedItem.Text.ToString();


            string str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                   + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No"
                   + " and tl.TL_Name = '" + tlname + "' and tt.TT_Name = '" + ttname + "' and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                    + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                     + " and p.Jys_No not in (select Jys_No from PaperShengbao where Jys_No = 10)";

            try
            {
                ds2.DBopen();

                ds = ds2.CreateDataSet(str, "PaperShengbao");


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
        else if ((this.TLCbox.Checked == true) && (this.TTCbox.Checked != true) && (this.ZACbox.Checked == true))
        {
            string tlname = this.TLDdl.SelectedItem.Text.ToString();

            string zaname = this.ZADdl.SelectedItem.Text.ToString();

            string str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                   + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No"
                   + " and tl.TL_Name = '" + tlname + "' and za.ZA_Name = '" + zaname + "' and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                    + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                     + " and p.Jys_No not in (select Jys_No from PaperShengbao where Jys_No = 10)";

            try
            {
                ds2.DBopen();

                ds = ds2.CreateDataSet(str, "PaperShengbao");



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
        else if ((this.TLCbox.Checked != true) && (this.TTCbox.Checked == true) && (this.ZACbox.Checked == true))
        {

            string ttname = this.TTDdl.SelectedItem.Text.ToString();
            string zaname = this.ZADdl.SelectedItem.Text.ToString();

            string str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                   + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No"
                   + " and tt.TT_Name = '" + ttname + "' and za.ZA_Name = '" + zaname + "' and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                    + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                     + " and p.Jys_No not in (select Jys_No from PaperShengbao where Jys_No = 10)";

            try
            {
                ds2.DBopen();

                ds = ds2.CreateDataSet(str, "PaperShengbao");


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
        else if ((this.TLCbox.Checked != true) && (this.TTCbox.Checked != true) && (this.ZACbox.Checked == true))
        {

            string zaname = this.ZADdl.SelectedItem.Text.ToString();

            string str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                   + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No"
                   + " and za.ZA_Name = '" + zaname + "' and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                    + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                     + " and p.Jys_No not in (select Jys_No from PaperShengbao where Jys_No = 10)";

            try
            {
                ds2.DBopen();

                ds = ds2.CreateDataSet(str, "PaperShengbao");



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
        else if ((this.TLCbox.Checked != true) && (this.TTCbox.Checked == true) && (this.ZACbox.Checked != true))
        {

            string ttname = this.TTDdl.SelectedItem.Text.ToString();


            string str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                   + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No"
                   + " and tt.TT_Name = '" + ttname + "' and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                    + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                     + " and p.Jys_No not in (select Jys_No from PaperShengbao where Jys_No = 10)";

            try
            {
                ds2.DBopen();

                ds = ds2.CreateDataSet(str, "PaperShengbao");


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
        else if ((this.TLCbox.Checked == true) && (this.TTCbox.Checked != true) && (this.ZACbox.Checked != true))
        {
            string tlname = this.TLDdl.SelectedItem.Text.ToString();


            string str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                   + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No"
                   + " and tl.TL_Name = '" + tlname + "' and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                    + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                     + " and p.Jys_No not in (select Jys_No from PaperShengbao where Jys_No = 10)";

            try
            {
                ds2.DBopen();

                ds = ds2.CreateDataSet(str, "PaperShengbao");



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
        else if ((this.TLCbox.Checked != true) && (this.TTCbox.Checked != true) && (this.ZACbox.Checked != true))
        {
            ds = TeaTimuBind();

        }
        return ds;
    }
    #endregion

    public DataSet DBound()
    {
        string stuZye = StunotoClass();
        DataSet dset = new DataSet();
        if (stuZye == "信本")
        {
            dset = DBoundXinben();
        }
        else
        {
            dset = DBoundShuben();
        }
        return dset;
    }

    protected void seaBt_Click(object sender, EventArgs e)
    {
        DataSet ds1 = new DataSet();
        string stuZye = StunotoClass();
        
        if (stuZye == "信本")
        {
            ds1 = DBoundXinben();
        }
        else
        {
            ds1 = DBoundShuben();
        }
        if (isselect == "0")
        {
            this.StuDataGrid.DataSource = ds1;
            StuDataGrid.DataBind();
        }
        //else
        //{
            //this.StuDataGrid1.DataSource = ds1;
            //StuDataGrid1.DataBind();
        //}

    }

    #region 判断该学生是否已经选过题目了
    public int IsStuSelected()
    {
        string str = "select IsSelected from Student where Stu_No = " + stuno;
        
        ds2.DBopen();

        rd = ds2.ExecuteOleDbDataReader(str);
        if (rd.HasRows)
        {
            
            rd.Read();
            string isselected = rd["IsSelected"].ToString().ToUpper();
            rd.Close();
            ds2.DBclose();
            if (isselected == "1")
            {
                return 1;
            }
            else { return 0; }
           
        }
        else return -1;
    }
    #endregion

    //protected void StuDataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    //{
    //    if (e.NewPageIndex != -1 && e.NewPageIndex >= 0)
    //    {
    //        StuDataGrid1.CurrentPageIndex = e.NewPageIndex;
    //        StuDataGrid1.DataSource = DBound();
    //        StuDataGrid1.DataBind();
    //    }
    //}
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    public string StuHasTel()
    {
        string str = "select Stu_Tel from Student where Stu_No=" + stuno;
        try
        {
            ds2.DBopen();
            ds = ds2.CreateDataSet(str, "StuTel");
            string stutel = ds.Tables["StuTel"].Rows[0]["Stu_Tel"].ToString();

            return stutel;
        }
        catch (System.Data.OleDb.OleDbException ex)
        {
            Response.Write(ex.ToString());
            return null;
        }
        finally
        {
            ds2.DBclose();
        }

    }

    #region 判断被选题目是不是“中学数学教学”专业方向的论文
    public bool IsZxsxjxArrow(int Id)
    {
        
        string zaname = "";
        int id = Id;
        
        string str = "select za.ZA_Name from PaperShengbao as p,ZhuanyeArrow as za where p.ZA_No = za.ZA_No and p.ID = " + id + "";
        try
        {
            ds2.DBopen();

            rd = ds2.ExecuteOleDbDataReader(str);
            if (rd.HasRows)
            {
                rd.Read();
                zaname = rd["ZA_Name"].ToString();

                rd.Close();

                if (zaname == "中学数学教学")
                {
                    return true;
                }
                else return false;
            }
            else return false;

        }
        catch (System.Data.OleDb.OleDbException e)
        {
            Response.Write(e.ToString());
            return false;

        }
        finally
        {
            ds2.DBclose();
        }
    }
    #endregion

    #region 判断学生选择的论文题目是否已经被选
    public bool TimuIsSeled(int Id)
    {
        string isseled = "";
        int id = Id;

        string str = "select IsSel from PaperShengbao where ID = " + id + "";
        try
        {
            ds2.DBopen();

            rd = ds2.ExecuteOleDbDataReader(str);
            if (rd.HasRows)
            {
                rd.Read();
                isseled = rd["IsSel"].ToString().ToLower();

                rd.Close();

                if (isseled == "true")
                {
                    return true;
                }
                else return false;
            }
            else return false;

        }
        catch (System.Data.OleDb.OleDbException e)
        {
            Response.Write(e.ToString());
            return false;

        }
        finally
        {
            ds2.DBclose();
        }
    }
    #endregion

    #region 学生执行选择题目操作
    protected void StuDataGrid_EditCommand(object source, DataGridCommandEventArgs e)
    {
        int sel = IsStuSelected();
        string stutel = StuHasTel();

        if (sel == 1)
        {
            ds2.alert("你已经选过一个论文题目，不能再选了！", "Student.aspx");
            
        }
        else
        {

            string stime = DateTime.Now.ToString();
            int id = ds2.ChangeToInt(StuDataGrid.DataKeys[e.Item.ItemIndex].ToString());//被选择的论文题目的ID号
            bool issel = TimuIsSeled(id);
            string teanamesel = TeaNameforTmId(id);//通过题目找到教师名称
            int teatmselnum = TeaSelCount(teanamesel);//通过教师名称找到教师已同意学生数
            string teaAllowstr = TeaAllowNum(teanamesel);//通过教师名称找到教师被允许选择的题目数
            int teaAllownum = ds2.ChangeToInt(teaAllowstr);
            bool IsZxsxjx = IsZxsxjxArrow(id);
            int ZxsxjxNum = 0;
            if (IsZxsxjx == true)
            {
                ZxsxjxNum = ZxsxjxTimuNum();
            }
            if (teatmselnum >= teaAllownum)
            {
                ds2.alert("该教师被选的论文题目已超过限制，不能再选择了，请选择其他教师的论文题目！", "Student.aspx");
            }
            else if (ZxsxjxNum >= 40)
            {
                ds2.alert("“中学数学教学”专业方向的论文已经被选择了40个，不能再选该方向的论文题目了，请选择其他类型的题目！", "Student.aspx");
            }
            //else if (stutel=="")
            //{
            //    ds2.alert("选题前请先输入你的联系方式！", "Student.aspx");
            //}
            else if (issel == true)
            {
                ds2.alert("该论文题目已经被选择了，请选择其它题目！", "Student.aspx");
            }
            else
            {

                string SQL = "update Student set Stu_Istongyi = '未审核', IsSelected = 1,STime = '" + stime + "',PSB_Id = " + id + " where Stu_No = " + stuno;
                string str = "update PaperShengbao set IsSel = true where ID = " + id;
                try
                {
                    ds2.DBopen();
                    int result = ds2.ExecuteSql(SQL);
                    int result2 = ds2.ExecuteSql(str);
                    if ((result > 0) && (result2 > 0))
                    {
                        ds2.alert("选题成功！", "Student.aspx");
                    }
                    else
                    {

                        ds2.alert("选题不成功！", "Student.aspx");
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
    }
    #endregion

    protected void StuDataGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        if (e.NewPageIndex != -1 && e.NewPageIndex >= 0)
        {
            StuDataGrid.CurrentPageIndex = e.NewPageIndex;
            StuDataGrid.DataSource = DBound();
            StuDataGrid.DataBind();
        }

    }
   
    protected void StuDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.Item.ItemIndex != -1 && e.Item.ItemIndex >= 0)
        {
            string cmd = e.CommandName;//获取命令名称
            int Id1 = Convert.ToInt32(StuDataGrid.DataKeys[e.Item.ItemIndex].ToString());//获取命令参数
            if (cmd == "Detail")
            {
                //执行编辑
                Page.Server.Transfer("Detail_Stu.aspx?id=" + Id1.ToString());
            }
        }
    }
    public int ZxsxjxTimuNum()//"中学数学教学"题目被选择的数目
    {
        string str = "select count(IsSel) as ZxsxjxTNum from PaperShengbao where ZA_No = 1 and IsSel = true";
        try
        {
            ds2.DBopen();
            ds = ds2.CreateDataSet(str, "ZxsxjxTimuN");
            string numstr = ds.Tables["ZxsxjxTimuN"].Rows[0]["ZxsxjxTNum"].ToString();
            int num = ds2.ChangeToInt(numstr);

            return num;
        }
        catch (System.Data.OleDb.OleDbException ex)
        {
            Response.Write(ex.ToString());
            return -1;
        }
        finally
        {
            ds2.DBclose();
        }
    }
    public string TeaNameforTmId(int timuid)//通过题目ID号查找教师名字
    {
        string str = "select Tea_Name from PaperShengbao where ID = " + timuid;
        try
        {
            ds2.DBopen();
            ds = ds2.CreateDataSet(str, "TeaN");
            string teaname = ds.Tables["TeaN"].Rows[0]["Tea_Name"].ToString();

            return teaname;
        }
        catch (System.Data.OleDb.OleDbException ex)
        {
            Response.Write(ex.ToString());
            return null;
        }
        finally
        {
            ds2.DBclose();
        }
    }

    #region 教师目前被选的数目
    public int TeaSelCount(string teaname)
    {
        //Int32 teano1 = ds2.ChangeToInt(teano);
        string str = "select Tea_StuNum from Teacher where Tea_Name = '" + teaname + "'";
        try
        {
            ds2.DBopen();
            rd = ds2.ExecuteOleDbDataReader(str);
            if (rd.HasRows)
            {

                rd.Read();
                string teaselnumstr = rd["Tea_StuNum"].ToString();
                rd.Close();
                ds2.DBclose();
                int teaselnum = ds2.ChangeToInt(teaselnumstr);
                return teaselnum;
            }
            else return -1;
        }
        catch (System.Data.OleDb.OleDbException ex)
        {
            Response.Write(ex.ToString());
            return -1;
        }
        finally
        {
            ds2.DBclose();
        }
    }
    #endregion

    //public int TeaTimuSelCount(string teaname)//教师题目被选的数目
    //{
    //    string str = "select Tea_StuNum from Teacher where Tea_Name = '" + teaname + "'";
    //    try
    //    {
    //        ds2.DBopen();
    //        ds = ds2.CreateDataSet(str, "TeaTmSel");
    //        string numstr = ds.Tables["TeaTmSel"].Rows.Count.ToString();
    //        int num = ds2.ChangeToInt(numstr);
            
    //        return num;
    //    }
    //    catch (System.Data.OleDb.OleDbException ex)
    //    {
    //        Response.Write(ex.ToString());
    //        return -1;
    //    }
    //    finally
    //    {
    //        ds2.DBclose();
    //    }
    //}

    //#region 添加学生电话
    //protected void StuTelBTon_Click(object sender, EventArgs e)
    //{
    //    string stutel = this.StuTelTBox.Text.ToString();
    //    string str = "update student set Stu_Tel='" + stutel + "' where Stu_No= " + stuno;
    //    try
    //    {
    //        ds2.DBopen();
    //        int i = ds2.ExecuteSql(str);
    //        if (i > 0)
    //        {
    //            ds2.alert("添加联系方式成功！", "Student.aspx");
    //        }
    //        else
    //        {
    //            ds2.alert("失败！", "Student.aspx");
    //        }
    //    }
    //    catch (System.Data.OleDb.OleDbException ex)
    //    {
    //        Response.Write(ex.ToString());
            
    //    }
    //    finally
    //    {
    //        ds2.DBclose();
    //    }
    //}
    //#endregion

    protected void BTSelTea_Click(object sender, EventArgs e)
    {
        string teaname = this.DDLSelTea.SelectedItem.Text.ToString();
        string stuZye = StunotoClass();
        string str;
        if (stuZye == "信本")
        {
            str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                  + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                  + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                 // +" and p.Jys_No = 10"
                  + " and Tea_Name = '" + teaname + "'";
        }
        else
        {
            str = "select p.ID,p.Tea_Name,p.TimuName,p.TimuJianjie,p.TimuTiaojian,tl.TL_Name,tt.TT_Name,za.ZA_Name from PaperShengbao as p,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za "
                   + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No and p.IsSel = false and p.JiaoyanshiFirst ='同意' and p.XiShenhe = '同意'"
                   + " and p.Tea_Name not in (select Tea_Name from PaperShengbao where IsSel =true group by Tea_Name having count(IsSel)>=12)"
                   + " and p.Jys_No not in (select Jys_No from PaperShengbao where Jys_No = 10)"
                   + " and Tea_Name = '" + teaname + "'"; 
        }
        //string str = "select * from PaperShengbao where Tea_Name = '" + teaname + "'";
        try
        {
            ds2.DBopen();
            ds = ds2.CreateDataSet(str, "TeaSel");
            this.StuDataGrid.DataSource = ds;
            StuDataGrid.DataBind();
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
    #region 查看学生是否被教师同意通过
    public string StuAllowed(string stunostr)
    {
        Int64 stuno = Int64.Parse(stunostr);
        string str = "select Stu_Istongyi from Student where Stu_No = " + stuno;
        try
        {
            ds2.DBopen();

            rd = ds2.ExecuteOleDbDataReader(str);
            if (rd.HasRows)
            {
                rd.Read();
                isallowed = rd["Stu_Istongyi"].ToString();

                rd.Close();
            }
            return isallowed;

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
    #endregion
}
   
    
       
  


