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
using System.IO;
using System.Text;


public partial class Useradimin : System.Web.UI.Page
{
  
    protected paper.Conn ds2 = new paper.Conn();
    protected OleDbDataReader rd;
    protected DataSet ds;
    public string supname;
    protected DataView dv;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserInfo"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            string supname1 = cookie.Values["supname"].ToString();
            supname = HttpUtility.UrlDecode(supname1);
        }
        if(!IsPostBack)
        {
            if (this.PaperShenbaoDG.Attributes["SortExpression"] == null)
            {
                this.PaperShenbaoDG.Attributes["SortExpression"] = "Tea_Name,TimuName,TL_Name,TT_Name,ZA_Name,Jys_Name,Stu_Name,Stu_No,Stu_Class";

                this.PaperShenbaoDG.Attributes["SortDirection"] = "ASC";
            }
            this.StatisticTeaTimuGv.Attributes.Add("SortExpression", "Tea_Name");
            this.StatisticTeaTimuGv.Attributes.Add("SortDirection", "ASC");

            
            this.StuNoTBox.Text = "";
        PSB_DBind();
        Stu_DBind();
        Tea_DBind();
        Jys_DBind();
        Role_DBind();
        UserAdmin_DBind();
        XiLeader_DBind();
        TL_DBind();
        TT_DBind();
        ZA_DBind();
        TeaStuNum();
        }
    }

    #region 统计教师指导学生数
    public DataTable TeaStuNum()
    {
        string SortExpression = this.StatisticTeaTimuGv.Attributes["SortExpression"];
        string SortDirection = this.StatisticTeaTimuGv.Attributes["SortDirection"];
        DataTable dt = new DataTable();
        DataView dv1 = new DataView();
        string str = "SELECT DISTINCTROW PaperShengbao.Tea_Name, Teacher.Tea_zhicheng, Teacher.Tea_xueli, Teacher.Tea_xuewei, Count(*) AS StuNum"
                   + " FROM Teacher left JOIN PaperShengbao ON Teacher.Tea_Name = PaperShengbao.Tea_Name where PaperShengbao.IsSel = true"
                   + " GROUP BY PaperShengbao.Tea_Name, Teacher.Tea_Name, Teacher.Tea_zhicheng, Teacher.Tea_xueli, Teacher.Tea_xuewei";

        try
        {
            ds2.DBopen();
            ds = ds2.CreateDataSet(str, "TeaStuNum");
           dt = ds.Tables[0];
            dv1 = ds.Tables[0].DefaultView;
            dv1.Sort = SortExpression + " " + SortDirection;//指定视图的排序方式

            StatisticTeaTimuGv.DataSource = dv1;
            StatisticTeaTimuGv.DataBind();
            return dt;
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

    #region 题目基本信息绑定
    public DataTable PSB_DBind()
    {

        string SortExpression = this.PaperShenbaoDG.Attributes["SortExpression"];
        string SortDirection = this.PaperShenbaoDG.Attributes["SortDirection"];
        DataView dv1 = new DataView();
        DataTable dt = new DataTable();
        //string str = "select p.ID,p.Tea_Name,p.TimuName,tl.TL_Name,tt.TT_Name,za.ZA_Name,j.Jys_Name,p.JiaoyanshiFirst,p.XiShenhe,p.JiaoTime,p.XiTime,p.IsSel,s.Stu_Name,s.Stu_No,s.Stu_Class"
        //           + " from PaperShengbao as p left Join Student s on s.PSB_Id = p.ID ,TimuLaiyuan as tl,TimuType as tt,ZhuanyeArrow as za,Jiaoyanshi as j"
        //           + " where p.TL_No = tl.TL_No and p.TT_No = tt.TT_No and p.ZA_No = za.ZA_No and p.Jys_No = j.Jys_No ";

        string str = " SELECT PaperShengbao.ID, Jiaoyanshi.Jys_Name, PaperShengbao.Tea_Name, PaperShengbao.TimuName, PaperShengbao.TimuJianjie, PaperShengbao.TimuTiaojian, PaperShengbao.JiaoyanshiFirst, PaperShengbao.XiShenhe, Student.Stu_No, Student.Stu_Name, Student.Stu_Class, TimuLaiyuan.TL_Name, TimuType.TT_Name, ZhuanyeArrow.ZA_Name"
                   + " FROM ZhuanyeArrow INNER JOIN (TimuType INNER JOIN (TimuLaiyuan INNER JOIN ((Jiaoyanshi INNER JOIN PaperShengbao ON Jiaoyanshi.Jys_No = PaperShengbao.Jys_No) left JOIN Student ON PaperShengbao.ID = Student.PSB_Id) ON TimuLaiyuan.TL_No = PaperShengbao.TL_No) ON TimuType.TT_No = PaperShengbao.TT_No) ON ZhuanyeArrow.ZA_No = PaperShengbao.ZA_No";
        try
        {
            ds2.DBopen();
            ds = ds2.CreateDataSet(str, "PaperShengbao");
            dt = ds.Tables[0];
            dv1 = ds.Tables[0].DefaultView;
            dv1.Sort = SortExpression + " " + SortDirection;//指定视图的排序方式
           
            PaperShenbaoDG.DataSource = dv1;
            PaperShenbaoDG.DataBind();
            return dt;
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

    #region 学生基本信息绑定
    public DataSet Stu_DBind()
    {
        string str = "select * from Student";

        try
        {
            ds2.DBopen();
            ds = ds2.CreateDataSet(str, "Student");
            this.StuDG.DataSource = ds;
            StuDG.DataBind();
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

    #region 教师基本信息绑定
    public DataSet Tea_DBind()
    {
        string str = "select * from Teacher";

        try
        {
            ds2.DBopen();
            ds = ds2.CreateDataSet(str, "Teacher");
            this.TeaDG.DataSource = ds;
            TeaDG.DataBind();
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

    #region 教研室负责人绑定
    public DataSet Jys_DBind()
    {
        string str = "select * from Jiaoyanshi";

        try
        {
            ds2.DBopen();
            ds = ds2.CreateDataSet(str, "Jiaoyanshi");
            this.JysDG.DataSource = ds;
            JysDG.DataBind();
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

    #region 角色绑定
    public DataSet Role_DBind()
    {
        string str = "select * from Role";

        try
        {
            ds2.DBopen();
            ds = ds2.CreateDataSet(str, "Role");
            this.RoleDG.DataSource = ds;
            RoleDG.DataBind();
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

    #region  用户管理员绑定
    public DataSet UserAdmin_DBind()
    {
        string str = "select * from UserAdmin";

        try
        {
            ds2.DBopen();
            ds = ds2.CreateDataSet(str, "UserAdmin");
            this.UADG.DataSource = ds;
            UADG.DataBind();
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

    #region 院领导绑定
    public DataSet XiLeader_DBind()
    {
        string str = "select * from XiLeader";

        try
        {
            ds2.DBopen();
            ds = ds2.CreateDataSet(str, "XiLeader");
            this.XiLeaderDG.DataSource = ds;
            XiLeaderDG.DataBind();
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

    #region 题目来源绑定
    public DataSet TL_DBind()
    {
        string str = "select * from TimuLaiyuan";

        try
        {
            ds2.DBopen();
            ds = ds2.CreateDataSet(str, "TimuLaiyuan");
            this.TimuLaiyuanDG.DataSource = ds;
            TimuLaiyuanDG.DataBind();
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

    #region 题目类型绑定
    public DataSet TT_DBind()
    {
        string str = "select * from TimuType";

        try
        {
            ds2.DBopen();
            ds = ds2.CreateDataSet(str, "TimuType");
            this.TimuTypeDG.DataSource = ds;
            TimuTypeDG.DataBind();
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

    #region 专业方向绑定
    public DataSet ZA_DBind()
    {
        string str = "select * from ZhuanyeArrow";

        try
        {
            ds2.DBopen();
            ds = ds2.CreateDataSet(str, "ZhuanyeArrow");
            this.ZhuanyeDG.DataSource = ds;
            ZhuanyeDG.DataBind();
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

    #region 实现各个datagrid分页代码
    protected void PaperShenbaoDG_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        PaperShenbaoDG.CurrentPageIndex = e.NewPageIndex;
        PaperShenbaoDG.DataSource = PSB_DBind();
        PaperShenbaoDG.DataBind();
    }
    protected void StuDG_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        StuDG.CurrentPageIndex = e.NewPageIndex;
        StuDG.DataSource = Stu_DBind();
        StuDG.DataBind();
    }
    protected void TeaDG_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        TeaDG.CurrentPageIndex = e.NewPageIndex;
        TeaDG.DataSource = Tea_DBind();
        TeaDG.DataBind();
    }
    protected void JysDG_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        JysDG.CurrentPageIndex = e.NewPageIndex;
        JysDG.DataSource = Jys_DBind();
        JysDG.DataBind();
    }
    protected void UADG_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        UADG.CurrentPageIndex = e.NewPageIndex;
        UADG.DataSource = UserAdmin_DBind();
        UADG.DataBind();
    }
    protected void XiLeaderDG_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        XiLeaderDG.CurrentPageIndex = e.NewPageIndex;
        XiLeaderDG.DataSource = XiLeader_DBind();
        XiLeaderDG.DataBind();
    }
    protected void TimuTypeDG_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        TimuTypeDG.CurrentPageIndex = e.NewPageIndex;
        TimuTypeDG.DataSource = TT_DBind();
        TimuTypeDG.DataBind();
    }
    protected void TimuLaiyuanDG_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        TimuLaiyuanDG.CurrentPageIndex = e.NewPageIndex;
        TimuLaiyuanDG.DataSource = TL_DBind();
        TimuLaiyuanDG.DataBind();
    }
    protected void ZhuanyeDG_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        ZhuanyeDG.CurrentPageIndex = e.NewPageIndex;
        ZhuanyeDG.DataSource = ZA_DBind();
        ZhuanyeDG.DataBind();
    }
    protected void RoleDG_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        RoleDG.CurrentPageIndex = e.NewPageIndex;
        RoleDG.DataSource = Role_DBind();
        RoleDG.DataBind();
    }
    protected void StatisticTeaTimuGv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        StatisticTeaTimuGv.PageIndex = e.NewPageIndex;
        TeaStuNum();
    }
    #endregion

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
   

    #region 删除学生选课记录
    protected void DelStuTimuBT_Click(object sender, EventArgs e)
    {
        string stunostr = this.StuNoTBox.Text.ToString();
       // int stuno = ds2.ChangeToInt(stunostr);//int32长度不够
        double stuno = double.Parse(stunostr);
        string Sql = "update PaperShengbao set IsSel = false where ID = (select PSB_Id from Student where Stu_No = " + stuno + ")";
        string Str = "update Student set IsSelected = 0, PSB_Id = null,Stu_Istongyi=null where Stu_No = " + stuno + "";
        ds2.DBopen();
        OleDbTransaction tran = ds2.Lb_Conn.BeginTransaction();
       
        try
        {
            
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = ds2.Lb_Conn;
            cmd.Transaction = tran;
            cmd.CommandText = Sql;
            int result1 = cmd.ExecuteNonQuery();
            cmd.CommandText = Str;
            int result2 = cmd.ExecuteNonQuery();
            tran.Commit();

            if ((result1 > 0)&&(result2 > 0))
            {
                ds2.alert("删除选课记录成功！", "Useradimin.aspx");
            }
            else
            {

                ds2.alert("删除选课记录不成功！", "Useradimin.aspx");
            }

        }
        catch (System.Data.OleDb.OleDbException ex)
        {
            Response.Write(ex.ToString());
            tran.Rollback();
        }
        finally
        {
            ds2.DBclose();
        }
    }
    #endregion

    #region 修改学生密码
    protected void StuDG_EditCommand(object source, DataGridCommandEventArgs e)
    {
        StuDG.EditItemIndex = e.Item.ItemIndex;
        StuDG.DataSource = Stu_DBind();
        StuDG.DataBind();
    }
    protected void StuDG_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        string id1 = this.StuDG.DataKeys[e.Item.ItemIndex].ToString();
        string pswtbox = ((TextBox)e.Item.FindControl("StuMimaTBox")).Text.ToString();

        string stime = DateTime.Now.ToString();
        int id = ds2.ChangeToInt(id1);//被选择的学生ID号
        if (pswtbox=="")
        {
           System.Web.HttpContext.Current.Response.Write("<script>alert('密码不能为空，请输入密码！');</script>");
        }
        else
        {
        string str = "update Student set Stu_psw = '" + pswtbox + "' where ID = " + id;
        try
        {
            ds2.DBopen();

            int result = ds2.ExecuteSql(str);
            if (result > 0)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('密码修改成功！');</script>");
            }
            else
            {

                System.Web.HttpContext.Current.Response.Write("<script>alert('密码修改不成功！');</script>");
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
    protected void StuDG_CancelCommand(object source, DataGridCommandEventArgs e)
    {
        StuDG.EditItemIndex = -1;
        StuDG.DataSource = Stu_DBind();
        StuDG.DataBind();
    }
    #endregion

    #region 修改教师密码
    protected void TeaDG_EditCommand(object source, DataGridCommandEventArgs e)
    {
        TeaDG.EditItemIndex = e.Item.ItemIndex;
        TeaDG.DataSource = Tea_DBind();
        TeaDG.DataBind();
    }
    protected void TeaDG_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        string id1 = this.TeaDG.DataKeys[e.Item.ItemIndex].ToString();
        string pswtbox = ((TextBox)e.Item.FindControl("TeaMimaTBox")).Text.ToString();

        string stime = DateTime.Now.ToString();
        int id = ds2.ChangeToInt(id1);//被选择的教师ID号
        if (pswtbox == "")
        {
             System.Web.HttpContext.Current.Response.Write("<script>alert('密码不能为空，请输入密码！');</script>");
        }
        else
        {

            string str = "update Teacher set Tea_psw = '" + pswtbox + "' where ID = " + id;
            try
            {
                ds2.DBopen();

                int result = ds2.ExecuteSql(str);
                if (result > 0)
                {
                     System.Web.HttpContext.Current.Response.Write("<script>alert('密码修改成功！');</script>");
                }
                else
                {

                   System.Web.HttpContext.Current.Response.Write("<script>alert('密码修改不成功！');</script>");
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
    protected void TeaDG_CancelCommand(object source, DataGridCommandEventArgs e)
    {
        TeaDG.EditItemIndex = -1;
        TeaDG.DataSource = Tea_DBind();
        TeaDG.DataBind();
    }
    #endregion

    #region 修改教研室负责人密码
    protected void JysDG_EditCommand(object source, DataGridCommandEventArgs e)
    {
        JysDG.EditItemIndex = e.Item.ItemIndex;
        JysDG.DataSource = Jys_DBind();
        JysDG.DataBind();
    }
    protected void JysDG_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        string id1 = this.JysDG.DataKeys[e.Item.ItemIndex].ToString();
        string pswtbox = ((TextBox)e.Item.FindControl("JysMimaTBox")).Text.ToString();

        string stime = DateTime.Now.ToString();
        int id = ds2.ChangeToInt(id1);//被选择的教研室号
        if (pswtbox == "")
        {
            System.Web.HttpContext.Current.Response.Write("<script>alert('密码不能为空，请输入密码！');</script>");
        }
        else
        {

            string str = "update Jiaoyanshi set Jys_psw = '" + pswtbox + "' where Jys_No = " + id;
            try
            {
                ds2.DBopen();

                int result = ds2.ExecuteSql(str);
                if (result > 0)
                {
                    System.Web.HttpContext.Current.Response.Write("<script>alert('密码修改成功！');</script>");
                }
                else
                {

                     System.Web.HttpContext.Current.Response.Write("<script>alert('密码修改不成功！');</script>");
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
    protected void JysDG_CancelCommand(object source, DataGridCommandEventArgs e)
    {
        JysDG.EditItemIndex = -1;
        JysDG.DataSource = Jys_DBind();
        JysDG.DataBind();
    }
    #endregion

    #region 修改领导密码
    protected void XiLeaderDG_EditCommand(object source, DataGridCommandEventArgs e)
    {
        XiLeaderDG.EditItemIndex = e.Item.ItemIndex;
        XiLeaderDG.DataSource = XiLeader_DBind();
        XiLeaderDG.DataBind();
    }
    protected void XiLeaderDG_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        string id1 = this.XiLeaderDG.DataKeys[e.Item.ItemIndex].ToString();
        string pswtbox = ((TextBox)e.Item.FindControl("XLMimaTBox")).Text.ToString();

        string stime = DateTime.Now.ToString();
        int id = ds2.ChangeToInt(id1);//被选择的领导ID号
        if (pswtbox == "")
        {
             System.Web.HttpContext.Current.Response.Write("<script>alert('密码不能为空，请输入密码！');</script>");
        }
        else
        {

            string str = "update XiLeader set XL_psw = '" + pswtbox + "' where ID = " + id;
            try
            {
                ds2.DBopen();

                int result = ds2.ExecuteSql(str);
                if (result > 0)
                {
                     System.Web.HttpContext.Current.Response.Write("<script>alert('密码修改成功！');</script>");
                }
                else
                {

                   System.Web.HttpContext.Current.Response.Write("<script>alert('密码修改不成功！');</script>");
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
    protected void XiLeaderDG_CancelCommand(object source, DataGridCommandEventArgs e)
    {
        XiLeaderDG.EditItemIndex = -1;
        XiLeaderDG.DataSource = XiLeader_DBind();
        XiLeaderDG.DataBind();
    }
    #endregion

    #region 修改用户管理员密码
    protected void UADG_EditCommand(object source, DataGridCommandEventArgs e)
    {
        UADG.EditItemIndex = e.Item.ItemIndex;
        UADG.DataSource = UserAdmin_DBind();
        UADG.DataBind();
    }
    protected void UADG_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        string id1 = this.UADG.DataKeys[e.Item.ItemIndex].ToString();
        string pswtbox = ((TextBox)e.Item.FindControl("UaMimaTBox")).Text.ToString();

        string stime = DateTime.Now.ToString();
        int id = ds2.ChangeToInt(id1);//被选择的领导ID号

        if (pswtbox == "")
        {
            ds2.alert("密码不能为空，请输入密码！", "Useradimin.aspx");
        }
        else
        {
            string str = "update UserAdmin set UA_psw = '" + pswtbox + "' where ID = " + id;
            try
            {
                ds2.DBopen();

                int result = ds2.ExecuteSql(str);
                if (result > 0)
                {
                    ds2.alert("密码修改成功！", "Useradimin.aspx");
                }
                else
                {

                    ds2.alert("密码修改不成功！", "Useradimin.aspx");
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
    protected void UADG_CancelCommand(object source, DataGridCommandEventArgs e)
    {
        UADG.EditItemIndex = -1;
        UADG.DataSource = UserAdmin_DBind();
        UADG.DataBind();
    }
    #endregion

    #region 编辑论文题目信息
    protected void PaperShenbaoDG_EditCommand(object source, DataGridCommandEventArgs e)
    {
        PaperShenbaoDG.EditItemIndex = e.Item.ItemIndex;
        PaperShenbaoDG.DataSource = PSB_DBind();
        PaperShenbaoDG.DataBind();
    }
    protected void PaperShenbaoDG_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        string id1 = this.PaperShenbaoDG.DataKeys[e.Item.ItemIndex].ToString();
        //string pswtbox = ((TextBox)e.Item.FindControl("StuMimaTBox")).Text.ToString();
        string tldrl = ((DropDownList)e.Item.FindControl("tlddl")).SelectedValue.ToString();
        string ttdrl = ((DropDownList)e.Item.FindControl("ttddl")).SelectedValue.ToString();
        string zadrl = ((DropDownList)e.Item.FindControl("zaddl")).SelectedValue.ToString();
        string jysdrl = ((DropDownList)e.Item.FindControl("jysddl")).SelectedValue.ToString();
        int tlno = ds2.ChangeToInt(tldrl);
        int ttno = ds2.ChangeToInt(ttdrl);
        int zano = ds2.ChangeToInt(zadrl);
        int jysno = ds2.ChangeToInt(jysdrl);
        //int tlno = TlNametoNo(tldrl);
        // int ttno = TTNametoNo(ttdrl);
        // int zano = ZANametoNo(zadrl);
        // int jysno = JysNametoNo(jysdrl);
        string stime = DateTime.Now.ToString();
        int id = ds2.ChangeToInt(id1);//被选择的论文题目ID号
       
        string Sql = "update PaperShengbao set TL_No = " + tlno + ",TT_No = " + ttno + ",ZA_No = " + zano + ",Jys_No = " + jysno + " where ID = " + id ;
        
            try
            {
                ds2.DBopen();

                int result = ds2.ExecuteSql(Sql);
                if (result > 0)
                {
                    System.Web.HttpContext.Current.Response.Write("<script>alert('论文题目信息修改成功！');</script>");
                }
                else
                {

                   System.Web.HttpContext.Current.Response.Write("<script>alert('论文题目信息修改不成功！');</script>");
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
    protected void PaperShenbaoDG_CancelCommand(object source, DataGridCommandEventArgs e)
    {
        PaperShenbaoDG.EditItemIndex = -1;
        PaperShenbaoDG.DataSource = PSB_DBind();
        PaperShenbaoDG.DataBind();
    }
    #endregion

    #region 题目来源名称获取题目来源号
    public int TlNametoNo(string tlname)
    {
        int tlno = 0;
        string str = "select TL_No from TimuLaiyuan where TL_Name = '" + tlname + "'";
        try
        {
            ds2.DBopen();
             
            rd = ds2.ExecuteOleDbDataReader(str);
            if (rd.Read() == true)
            {
                string tlnostr = rd["TL_No"].ToString();
                tlno = ds2.ChangeToInt(tlnostr);
            }
            else
            {
                tlno = 0;
            }
            return tlno;
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

    #region 题目类型名称获取题目类型号
    public int TTNametoNo(string ttname)
    {
        int ttno = 0;
        string str = "select TT_No from TimuType where TT_Name = '" + ttname + "'";
        try
        {
            ds2.DBopen();

            rd = ds2.ExecuteOleDbDataReader(str);
            if (rd.Read() == true)
            {
                string ttnostr = rd["TT_No"].ToString();
                ttno = ds2.ChangeToInt(ttnostr);
            }
            else
            {
                ttno = 0;
            }
            return ttno;
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

    #region 专业方向名称获取专业方向号
    public int ZANametoNo(string zaname)
    {
        int zano = 0;
        string str = "select ZA_No from ZhuanyeArrow where ZA_Name = '" + zaname + "'";
        try
        {
            ds2.DBopen();

            rd = ds2.ExecuteOleDbDataReader(str);
            if (rd.Read() == true)
            {
                string zanostr = rd["ZA_No"].ToString();
                zano = ds2.ChangeToInt(zanostr);
            }
            else
            {
                zano = 0;
            }
            return zano;
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

    #region 题目所属教研室名称获取教研室号
    public int JysNametoNo(string jysname)
    {
        int jysno = 0;
        string str = "select Jys_No from Jiaoyanshi where Jys_Name = '" + jysname + "'";
        try
        {
            ds2.DBopen();

            rd = ds2.ExecuteOleDbDataReader(str);
            if (rd.Read() == true)
            {
                string jysnostr = rd["Jys_No"].ToString();
                jysno = ds2.ChangeToInt(jysnostr);
            }
            else
            {
                jysno = 0;
            }
            return jysno;
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

    #region 对Datagrid排序
    protected void PaperShenbaoDG_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
        string SortDirection = "ASC"; //为排序方向变量赋初值
        if (SortExpression == PaperShenbaoDG.Attributes["SortExpression"])  //如果为当前排序列
        {
            SortDirection = (PaperShenbaoDG.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态

        }
        PaperShenbaoDG.Attributes["SortExpression"] = SortExpression;
        PaperShenbaoDG.Attributes["SortDirection"] = SortDirection;
        PSB_DBind();
    }
    protected void StatisticTeaTimuGv_Sorting(object sender, GridViewSortEventArgs e)
    {

        // 从事件参数获取排序数据列
        string sortExpression = e.SortExpression.ToString();
        // 假定为排序方向为“顺序”
        string sortDirection = "ASC";
        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改
        if (sortExpression == this.StatisticTeaTimuGv.Attributes["SortExpression"])
        {
            //获得下一次的排序状态
            sortDirection = (this.StatisticTeaTimuGv.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");
        }
        // 重新设定GridView排序数据列及排序方向
        this.StatisticTeaTimuGv.Attributes["SortExpression"] = sortExpression;
        this.StatisticTeaTimuGv.Attributes["SortDirection"] = sortDirection;
        this.TeaStuNum();
    }
    #endregion    
   
    protected void OutExcelBT_Click(object sender, EventArgs e)
    {
        DataTable dtData = new DataTable();
        dtData = PSB_DBind();
        DataTable2Excel(dtData);
    }
    #region 将DataTable导出为Excel  
    public static void DataTable2Excel(System.Data.DataTable dtData)
    {
        System.Web.UI.WebControls.DataGrid dgExport = null;
        // 当前对话 
        System.Web.HttpContext curContext = System.Web.HttpContext.Current;
        // IO用于导出并返回excel文件 
        System.IO.StringWriter strWriter = null;
        System.Web.UI.HtmlTextWriter htmlWriter = null;

        if (dtData != null)
        {
            // 设置编码和附件格式 
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
            curContext.Response.Charset = "";

            // 导出excel文件 
            strWriter = new System.IO.StringWriter();
            htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);

            // 为了解决dgData中可能进行了分页的情况，需要重新定义一个无分页的DataGrid 
            dgExport = new System.Web.UI.WebControls.DataGrid();
            dgExport.DataSource = dtData.DefaultView;
            dgExport.AllowPaging = false;
            dgExport.DataBind();

            // 返回客户端 
            dgExport.RenderControl(htmlWriter);
            curContext.Response.Write(strWriter.ToString());
            curContext.Response.End();
        }
    }
    #endregion

    protected void OutExcelBT1_Click(object sender, EventArgs e)
    {
        DataTable dtData = new DataTable();
        dtData = TeaStuNum();
        DataTable2Excel(dtData);
    }
    protected void BTUpdateAllownum_Click(object sender, EventArgs e)
    {
        string teaName = this.DDLTeaName.SelectedItem.Text.ToString();
        string allownum = this.TBoxAllowNum.Text.ToString();
        if (allownum == "")
        {
            ds2.alert("请输入该教师允许被选的题目数！", "Useradimin.aspx");
        }
        else
        {
            string str = "update Teacher set Tea_AllowNum='" + allownum + "' where Tea_Name = '" + teaName + "'";
            try
            {
                ds2.DBopen();

                int result = ds2.ExecuteSql(str);
                if (result > 0)
                {
                    ds2.alert("该教师的允许被选题目数修改成功！", "Useradimin.aspx");
                }
                else
                {

                    ds2.alert("修改不成功！", "Useradimin.aspx");
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


