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
    public partial class Student : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT STUDENT_ID, STUDENT_NAME, STUDENT_ADDRESS, ATTENDANCE, EXAM_STATUS FROM STUDENT";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("student");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            studentGV.DataSource = dt;
            studentGV.DataBind();

        }


        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {

            this.BindGrid();
            studentGV.EditIndex = -1;
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(studentGV.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM student WHERE student_Id =" + ID))
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
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != studentGV.EditIndex)
            {
                //(e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";


            }
            //this.BindGrid();
            studentGV.EditIndex = -1;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            // insert code
            string name = StudentName.Text.ToString();
            string address = StudentAddress.Text.ToString();
            string attendance = StudentAttendance.Text.ToString();
            string exam_status = "Not Eligible";

            string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            if (btnSubmit.Text == "Button")
            {
                OracleCommand cmd = new OracleCommand("Insert into student(Student_Name, Student_Address,Attendance,Exam_Status)Values('" + name + "','" + address + "','" + attendance + "','" + exam_status + "')");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

            else if (btnSubmit.Text == "Update")
            {
                //get ID for the Update
                string ID = txtID.Text.ToString();
                OracleCommand cmd = new OracleCommand("update student set Student_name = '" + name + "', Student_address = '" + address + "', Attendance = '" + attendance + "' where Student_Id = " + ID);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                btnSubmit.Text = "Button";
                studentGV.EditIndex = -1;
            }



            StudentName.Text = "";
            StudentAddress.Text = "";
            StudentAttendance.Text = "";

            this.BindGrid();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            // get id for data update
            txtID.Text = this.studentGV.Rows[e.NewEditIndex].Cells[3].Text;
            StudentName.Text = this.studentGV.Rows[e.NewEditIndex].Cells[4].Text.ToString().TrimStart().TrimEnd(); // (row.Cells[2].Controls[0] as TextBox).Text;
            StudentAddress.Text = this.studentGV.Rows[e.NewEditIndex].Cells[5].Text;
            StudentAttendance.Text = this.studentGV.Rows[e.NewEditIndex].Cells[6].Text;
            btnSubmit.Text = "Update";
        }

        protected void OnSelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Session["id"] = this.studentGV.Rows[e.NewSelectedIndex].Cells[3].Text;
            Server.Transfer("Student_Fee.aspx");
        }
    }
}