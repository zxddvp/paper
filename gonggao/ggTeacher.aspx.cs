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

public partial class gonggao_ggTeacher : System.Web.UI.Page
{
    public paper.Conn ds2 = new paper.Conn();

    protected OleDbDataReader rd;
    protected string strSql;
    protected DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            /*验证是否登陆了系统*/
            //if (Session["admin"] == null)
            //{
            //    Response.Write("<script>top.location.href='../login.aspx';</script>");
            //    return;
            //}
            //this.Btn_Delete.Attributes.Add("onclick", "confirm('决定删除员工吗,同时将删除相关考勤信息?');");
            /*对部门下拉框的项目进行初始化*/
            //this.DepartmentName.Items.Add(new ListItem("请选择",""));
            //DataSet departmentDs = (new DepartmentLogic()).GetAllDepartmentInfo();
            //foreach (DataRow dr in departmentDs.Tables[0].Rows)
            //    this.DepartmentName.Items.Add(new ListItem(dr["departmentName"].ToString(), dr["departmentName"].ToString()));
            ///*对职位类别下拉框项目进行初始化*/
            //this.WorkType.Items.Add(new ListItem("请选择",""));
            //DataSet workTypeNameDs = (new WorkTypeLogic()).GetAllWorkTypeInfo();
            //foreach(DataRow dr in workTypeNameDs.Tables[0].Rows)
            //    this.WorkType.Items.Add(new ListItem(dr["workTypeName"].ToString(),dr["workTypeName"].ToString()));
        }
    }
    //protected void Btn_Query_Click(object sender, EventArgs e)
    //{
    //    /*取得查询的各个参数*/
    //    string employeeNo = this.EmployeeNo.Text;
    //    string employeeName = this.EmployeeName.Text;
    //    string departmentName = this.DepartmentName.Text;
    //    string workTypeName = this.WorkType.Text;
    //    /*调用业务层得到查询的结果数据集*/
    //    EmployeeLogic employeeLogic = new EmployeeLogic();
    //    DataSet ds = employeeLogic.GetQueryEmployeeInfoView(employeeNo, employeeName, departmentName, workTypeName);
    //    /*将查询结果集绑定到gridview控件上*/
    //    this.gvTeaGG.DataSourceID = null;
    //    this.gvTeaGG.DataSource = ds;
    //    this.gvTeaGG.PageIndex = 0;
    //    this.gvTeaGG.DataBind();
    //}
    protected void gvTeaGG_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //当鼠标选择某行时变颜色
            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#00ffee';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            //e.Row.Cells[4].Text = Convert.ToDateTime(e.Row.Cells[4].Text).ToShortDateString();
        }
    }
    protected void CB_SelectAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < this.gvTeaGG.Rows.Count; i++)
        {
            GridViewRow gr = this.gvTeaGG.Rows[i];
            CheckBox chk = (CheckBox)gr.Cells[0].FindControl("CB_Select");
            chk.Checked = this.CB_SelectAll.Checked; //跟随全选按扭的状态变化;
        }
    }
    protected void Btn_Delete_Click(object sender, EventArgs e)
    {
        int selectCount = 0;　//要删除的员工总数
        string employeeNos = ""; //保存要删除的员工编号
        string oneEmployeeNo; //保存某行记录的员工编号
        foreach (GridViewRow gr in gvTeaGG.Rows)
        {
            CheckBox chk = (CheckBox)gr.Cells[0].FindControl("CB_Select");
            if (chk.Checked) //如果要删除该学生
            {
                oneEmployeeNo = gr.Cells[1].Text;
                if (0 == selectCount)
                    employeeNos = "'" + oneEmployeeNo + "'";
                else
                    employeeNos = employeeNos + ",'" + oneEmployeeNo + "'";
                selectCount++;

            }
        }
        if (0 == selectCount) //如果用户没有选择员工
            Response.Write("<script>alert('对不起，你没有选择员工!');</script>");
        else
        {
            /*如果选择了员工就执行调用业务层进行该些员工信息的删除*/         
           
         
            string SQL = "delete from [Gonggao] where gg_ID in (" + employeeNos + ")";

            ds2.DBopen();

            ds2.ExecuteSql(SQL);

            ds2.alert("教师公告删除成功！", "ggTeacher.aspx");

            ds2.DBclose();

            
        }


    }
   
    protected void gvTeaGG_PageIndexChanged(object sender, EventArgs e)
    {

    }
    //protected void gvTeaGG_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    /*取得查询的各个参数*/
    //    string employeeNo = this.EmployeeNo.Text;
    //    string employeeName = this.EmployeeName.Text;
    //    string departmentName = this.DepartmentName.Text;
    //    string workTypeName = this.WorkType.Text;
    //    /*调用业务层得到查询的结果数据集*/
    //    EmployeeLogic employeeLogic = new EmployeeLogic();
    //    DataSet ds = employeeLogic.GetQueryEmployeeInfoView(employeeNo, employeeName, departmentName, workTypeName);
    //    /*将查询结果集绑定到gridview控件上*/
    //    this.gvTeaGG.DataSourceID = null;
    //    this.gvTeaGG.DataSource = ds;
    //    this.gvTeaGG.PageIndex = e.NewPageIndex; ;
    //    this.gvTeaGG.DataBind();
    //}
}
