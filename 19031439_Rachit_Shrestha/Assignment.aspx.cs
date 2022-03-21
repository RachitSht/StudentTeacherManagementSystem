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
    public partial class Assignment : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT BERKELEY_COLLEGE.ASSIGNMENT.ASSIGNMENT_ID, BERKELEY_COLLEGE.ASSIGNMENT.ASSIGNMENT_TYPE, 
                                BERKELEY_COLLEGE.DEPARTMENT.DEPARTMENT_ID, BERKELEY_COLLEGE.DEPARTMENT.DEPARTMENT_NAME FROM BERKELEY_COLLEGE.ASSIGNMENT INNER JOIN
                                BERKELEY_COLLEGE.DEPARTMENT ON BERKELEY_COLLEGE.ASSIGNMENT.DEPARTMENT_ID = BERKELEY_COLLEGE.DEPARTMENT.DEPARTMENT_ID";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("student");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            AssignmentGV.DataSource = dt;
            AssignmentGV.DataBind();

        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {

            this.BindGrid();
            AssignmentGV.EditIndex = -1;
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(AssignmentGV.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM ASSIGNMENT WHERE ASSIGNMENT_Id =" + ID))
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
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != AssignmentGV.EditIndex)
            {
                //(e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";


            }
            //this.BindGrid();
            AssignmentGV.EditIndex = -1;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // insert code
                string AssignmentType = AssignmentTypeTB.Text.ToString();
                string department = DepartmentDD.SelectedValue.ToString();

                string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
                OracleConnection con = new OracleConnection(constr);

                if (btnSubmit.Text == "Button")
                {
                    OracleCommand cmd = new OracleCommand("INSERT into Assignment(Assignment_Type, Department_ID)Values('" + AssignmentType + "','" + department + "')");
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                else if (btnSubmit.Text == "Update")
                {
                    //get ID for the Update
                    string ID = txtID.Text.ToString();
                    OracleCommand cmd = new OracleCommand("update assignment set assignment_type = '" + AssignmentType + "', Department_ID = '" + department + "' where assignment_Id = " + ID);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    btnSubmit.Text = "Button";
                    AssignmentGV.EditIndex = -1;
                }

                AssignmentTypeTB.Text = "";
                AssignmentTypeTB.Text = "";
            }
            catch { 
            
            }

            

            this.BindGrid();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            // get id for data update
            txtID.Text = this.AssignmentGV.Rows[e.NewEditIndex].Cells[2].Text;
            AssignmentTypeTB.Text = this.AssignmentGV.Rows[e.NewEditIndex].Cells[3].Text.ToString().TrimStart().TrimEnd(); // (row.Cells[2].Controls[0] as TextBox).Text;
            DepartmentDD.SelectedValue = this.AssignmentGV.Rows[e.NewEditIndex].Cells[4].Text;
            btnSubmit.Text = "Update";
        }

    }
}