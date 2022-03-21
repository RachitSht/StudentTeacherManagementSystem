using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _19031439_Rachit_Shrestha
{
    public partial class Add_Student_Module : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT BERKELEY_COLLEGE.STUDENT.STUDENT_ID,BERKELEY_COLLEGE.STUDENT.STUDENT_NAME,
                                BERKELEY_COLLEGE.MODULE.MODULE_NAME,BERKELEY_COLLEGE.MODULE.MODULE_CODE, 
                                BERKELEY_COLLEGE.MODULE.CREDIT_HOUR FROM BERKELEY_COLLEGE.STUDENT INNER JOIN BERKELEY_COLLEGE.STUDENT_MODULE ON 
                                BERKELEY_COLLEGE.STUDENT.STUDENT_ID = BERKELEY_COLLEGE.STUDENT_MODULE.STUDENT_ID INNER JOIN BERKELEY_COLLEGE.MODULE ON 
                                BERKELEY_COLLEGE.STUDENT_MODULE.MODULE_CODE = BERKELEY_COLLEGE.MODULE.MODULE_CODE";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("add_module_to_student");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void addModule(object sender, EventArgs e)
        {
            try
            {
                string studentID = StudentDD.SelectedValue.ToString();
                string moduleCode = ModuleDD.SelectedValue.ToString();


                string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
                OracleConnection con = new OracleConnection(constr);

                OracleCommand insert_module = new OracleCommand("INSERT into STUDENT_MODULE(STUDENT_ID, MODULE_CODE)Values('" + studentID + "','" + moduleCode + "')");
                insert_module.Connection = con;
                con.Open();
                insert_module.ExecuteNonQuery();
                con.Close();

                StudentDD.SelectedIndex = 0;
                ModuleDD.SelectedIndex = 0;

                this.BindGrid();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record already exist')", true);
            }
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int TeacherID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            int ModuleCode = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[3]);

            string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM TEACHER_MODULE WHERE TEACHER_ID = '" + TeacherID + "' AND MODULE_CODE = '" + ModuleCode + "'"))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                //(e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";


            }
            //this.BindGrid();
            GridView1.EditIndex = -1;

        }
    }
}