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
    public partial class Module_Assignment : System.Web.UI.Page
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
                                BERKELEY_COLLEGE.MODULE.MODULE_CODE, BERKELEY_COLLEGE.MODULE.MODULE_NAME, 
                                BERKELEY_COLLEGE.ASSIGNMENT.ASSIGNMENT_ID, BERKELEY_COLLEGE.ASSIGNMENT.ASSIGNMENT_TYPE,
                                BERKELEY_COLLEGE.MODULE_ASSIGNMENT.GRADE, BERKELEY_COLLEGE.MODULE_ASSIGNMENT.STATUS FROM
                                BERKELEY_COLLEGE.STUDENT INNER JOIN BERKELEY_COLLEGE.MODULE_ASSIGNMENT ON 
                                BERKELEY_COLLEGE.STUDENT.STUDENT_ID = BERKELEY_COLLEGE.MODULE_ASSIGNMENT.STUDENT_ID INNER 
                                JOIN BERKELEY_COLLEGE.MODULE ON BERKELEY_COLLEGE.MODULE_ASSIGNMENT.MODULE_CODE = 
                                BERKELEY_COLLEGE.MODULE.MODULE_CODE INNER JOIN BERKELEY_COLLEGE.ASSIGNMENT ON 
                                BERKELEY_COLLEGE.MODULE_ASSIGNMENT.ASSIGNMENT_ID = BERKELEY_COLLEGE.ASSIGNMENT.ASSIGNMENT_ID";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("Module_Assignment_DT");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            ModuleAssignmentGV.DataSource = dt;
            ModuleAssignmentGV.DataBind();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {

            this.BindGrid();
            ModuleAssignmentGV.EditIndex = -1;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            // insert code
            string assignment = AssignmentDD.SelectedValue.ToString();
            string student = StudentDD.SelectedValue.ToString();
            string module = ModuleDD.SelectedValue.ToString();
            string grade = GradeDD.SelectedValue.ToString();
            string status = "Pass";

            if (grade == "F")
            {
                status = "Fail";
            }

            string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            if (btnSubmit.Text == "Button")
            {
                OracleCommand cmd = new OracleCommand("Insert into module_assignment(Assignment_ID, Student_ID, Module_CODE,grade,status)" +
                    "Values('" + assignment + "','" + student + "','" + module + "','" + grade + "','" + status + "')");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

            else if (btnSubmit.Text == "Update")
            {
                //get ID for the Update
                string assignmentID = assignmentTB.Text.ToString();
                string studentID = studentTB.Text.ToString();
                string moduleID = moduleTB.Text.ToString();
                string gradeUpdate = GradeDD.SelectedValue.ToString();

                OracleCommand cmd = new OracleCommand("update module_assignment set assignment_id = '" + assignmentID + "'," +
                    " Student_ID = '" + studentID + "', module_ID = '" + moduleID + "', grade = '" + grade + "'" +
                    ", status = '" + status + "' where Student_Id = " + ID);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                btnSubmit.Text = "Button";
                ModuleAssignmentGV.EditIndex = -1;
            }



            AssignmentDD.SelectedIndex = 0;
            StudentDD.SelectedIndex = 0;
            ModuleDD.SelectedIndex = 0;

            this.BindGrid();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            // get id for data update
            AssignmentDD.Text = this.ModuleAssignmentGV.Rows[e.NewEditIndex].Cells[3].Text;
            StudentDD.SelectedValue = this.ModuleAssignmentGV.Rows[e.NewEditIndex].Cells[4].Text.ToString().TrimStart().TrimEnd(); // (row.Cells[2].Controls[0] as TextBox).Text;
            ModuleDD.SelectedValue= this.ModuleAssignmentGV.Rows[e.NewEditIndex].Cells[5].Text;
            GradeDD.SelectedValue = this.ModuleAssignmentGV.Rows[e.NewEditIndex].Cells[6].Text;
            btnSubmit.Text = "Update";

        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int StudentID = Convert.ToInt32(ModuleAssignmentGV.DataKeys[e.RowIndex].Values[0]);
            string ModuleCode = Convert.ToString(ModuleAssignmentGV.DataKeys[e.RowIndex].Values[2]);
            int AssignmentID = Convert.ToInt32(ModuleAssignmentGV.DataKeys[e.RowIndex].Values[4]);

            string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM MODULE_ASSIGNMENT WHERE STUDENT_ID = '" + StudentID + "' " +
                    "AND ASSIGNMENT_ID = '" + AssignmentID + "' AND MODULE_CODE = '" + ModuleCode + "' "))
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
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != ModuleAssignmentGV.EditIndex)
            {
                //(e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";


            }
            //this.BindGrid();
            ModuleAssignmentGV.EditIndex = -1;

        }
    }
}