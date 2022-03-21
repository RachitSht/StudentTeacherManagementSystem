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
    public partial class Teacher_Module : System.Web.UI.Page
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
                string t_id = Session["id"].ToString();
                Session.Remove("id");

                string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
                OracleCommand cmd = new OracleCommand();
                OracleConnection con = new OracleConnection(constr);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = @"SELECT t.TEACHER_ID, t.TEACHER_NAME, t.EMAIL, m.MODULE_CODE, m.MODULE_NAME, m.CREDIT_HOUR
                                FROM TEACHER t
                                INNER JOIN TEACHER_MODULE tm ON tm.TEACHER_ID = t.TEACHER_ID
                                INNER JOIN MODULE m ON tm.MODULE_CODE = m.MODULE_CODE
                                WHERE tm.TEACHER_ID = " + t_id;
                cmd.CommandType = CommandType.Text;

                DataTable dt = new DataTable("teacherModule");

                using (OracleDataReader sdr = cmd.ExecuteReader())
                {
                    dt.Load(sdr);
                }

                con.Close();

                teacherModuleGV.DataSource = dt;
                teacherModuleGV.DataBind();
            }

    }
}