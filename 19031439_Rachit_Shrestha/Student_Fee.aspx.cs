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
    public partial class Student_Fee : System.Web.UI.Page
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
            string s_id = Session["id"].ToString();
            Session.Remove("id");

            string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT s.STUDENT_ID, s.STUDENT_NAME, f.FEE_STATUS, f.AMOUNT, f.DATE_OF_PAYMENT
                                FROM STUDENT s
                                INNER JOIN FEE f ON f.STUDENT_ID = s.STUDENT_ID
                                WHERE s.STUDENT_ID = " + s_id;
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("teacherModule");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            studentFeeGV.DataSource = dt;
            studentFeeGV.DataBind();
        }
    }
}