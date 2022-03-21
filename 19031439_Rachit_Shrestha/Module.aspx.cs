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
    public partial class Module : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT MODULE_CODE, MODULE_NAME, CREDIT_HOUR FROM MODULE  ";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("module");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            moduleGV.DataSource = dt;
            moduleGV.DataBind();

        }


        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {

            this.BindGrid();
            moduleGV.EditIndex = -1;
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(moduleGV.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM module WHERE module_CODE =" + ID))
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
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != moduleGV.EditIndex)
            {
                //(e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";


            }
            //this.BindGrid();
            moduleGV.EditIndex = -1;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            // insert code
            string name = ModuleName.Text.ToString();
            string creditHour = CreditHour.Text.ToString();



            string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            if (btnSubmit.Text == "Button")
            {
                OracleCommand cmd = new OracleCommand("Insert into module(Module_Name, Credit_Hour)Values('" + name + "','" + creditHour + "')");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

            else if (btnSubmit.Text == "Update")
            {
                //get ID for the Update
                string ID = txtID.Text.ToString();
                OracleCommand cmd = new OracleCommand("update module set Module_name = '" + name + "', Credit_Hour = '" + creditHour + "' where Module_CODE = " + ID);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                btnSubmit.Text = "Button";
                moduleGV.EditIndex = -1;
            }



            ModuleName.Text = "";
            CreditHour.Text = "";

            this.BindGrid();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            // get id for data update
            txtID.Text = this.moduleGV.Rows[e.NewEditIndex].Cells[2].Text;
            ModuleName.Text = this.moduleGV.Rows[e.NewEditIndex].Cells[3].Text.ToString().TrimStart().TrimEnd(); // (row.Cells[2].Controls[0] as TextBox).Text;
            CreditHour.Text = this.moduleGV.Rows[e.NewEditIndex].Cells[4].Text;
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