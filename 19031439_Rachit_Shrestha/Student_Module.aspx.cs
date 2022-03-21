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
    public partial class Student_Attendance : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT BERKELEY_COLLEGE.STUDENT.STUDENT_ID, BERKELEY_COLLEGE.STUDENT.STUDENT_NAME, 
                                BERKELEY_COLLEGE.MODULE.MODULE_CODE, 
                                BERKELEY_COLLEGE.MODULE.MODULE_NAME FROM BERKELEY_COLLEGE.STUDENT INNER JOIN 
                                BERKELEY_COLLEGE.STUDENT_MODULE ON BERKELEY_COLLEGE.STUDENT.STUDENT_ID = 
                                BERKELEY_COLLEGE.STUDENT_MODULE.STUDENT_ID INNER JOIN BERKELEY_COLLEGE.MODULE 
                                ON BERKELEY_COLLEGE.STUDENT_MODULE.MODULE_CODE = BERKELEY_COLLEGE.MODULE.MODULE_CODE";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("student");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            studentAttendanceGV.DataSource = dt;
            studentAttendanceGV.DataBind();

        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(studentAttendanceGV.DataKeys[e.RowIndex].Values[0]);
            int moduleCode = Convert.ToInt32(studentAttendanceGV.DataKeys[e.RowIndex].Values[2]);
            string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM STUDENT_MODULE WHERE student_Id =" + ID + "AND MODULE_CODE="+ moduleCode))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
            //studentGridView.EditIndex = -1;
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != studentAttendanceGV.EditIndex)
            {
                //(e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";


            }
            //this.BindGrid();
            studentAttendanceGV.EditIndex = -1;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // insert code
                string student = StudentDD.SelectedValue.ToString();
                string module = ModuleDD.SelectedValue.ToString();


                string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
                OracleConnection con = new OracleConnection(constr);

                if (btnSubmit.Text == "Button")
                {
                    OracleCommand cmd = new OracleCommand("Insert into STUDENT_MODULE(MODULE_CODE, STUDENT_ID)Values('" + module  + "','" + student+ "')");
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }

                StudentDD.SelectedIndex = 0;
                ModuleDD.SelectedIndex = 0;

                this.BindGrid();
            }
            catch
            {

            }

            
        }

    }
}