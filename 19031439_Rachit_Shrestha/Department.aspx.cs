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
    public partial class Department : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT DEPARTMENT_ID, DEPARTMENT_NAME FROM DEPARTMENT";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("department");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            departmentGV.DataSource = dt;
            departmentGV.DataBind();

        }


        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {

            this.BindGrid();
            departmentGV.EditIndex = -1;
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(departmentGV.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM department WHERE department_Id =" + ID))
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
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != departmentGV.EditIndex)
            {
                //(e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";


            }
            //this.BindGrid();
            departmentGV.EditIndex = -1;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            // insert code
            string name = DepartmentName.Text.ToString();



            string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            if (btnSubmit.Text == "Button")
            {
                OracleCommand cmd = new OracleCommand("Insert into Department(Department_Name)Values('" + name + "')");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

            else if (btnSubmit.Text == "Update")
            {
                //get ID for the Update
                string ID = txtID.Text.ToString();
                OracleCommand cmd = new OracleCommand("update department set Department_name = '" + name + "' where Department_ID = " + ID);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                btnSubmit.Text = "Button";
                departmentGV.EditIndex = -1;
            }



            DepartmentName.Text = "";

            this.BindGrid();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            // get id for data update
            txtID.Text = this.departmentGV.Rows[e.NewEditIndex].Cells[2].Text;
            DepartmentName.Text = this.departmentGV.Rows[e.NewEditIndex].Cells[3].Text.ToString().TrimStart().TrimEnd(); // (row.Cells[2].Controls[0] as TextBox).Text;
            btnSubmit.Text = "Update";

            // For foreging key
            //string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //OracleCommand cmd = new OracleCommand();
            //OracleConnection con = new OracleConnection(constr);
            //con.Open();
            //cmd.Connection = con;
            //cmd.CommandText = "select FieldValue,FieldName from setupinfo where Name = 'Gender'";
            //cmd.CommandType = CommandType.Text;

            //DataTable dt = new DataTable("Setup");

            //using (OracleDataReader sdr = cmd.ExecuteReader())
            //{
            //    dt.Load(sdr);
            //}

            //con.Close();

            //ddlGender.DataSource = dt;
            //ddlGender.DataTextField = "FieldName";
            //ddlGender.DataValueField = "FieldValue";
            //ddlGender.DataBind();

            // end foreign key

            // ddlGender.Items.FindByValue(this.gvAuthor.Rows[e.NewEditIndex].Cells[3].Text).Selected = true;





        }
    }
}