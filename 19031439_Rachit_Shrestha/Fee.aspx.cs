using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _19031439_Rachit_Shrestha
{
    public partial class Fee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddFee(object sender, EventArgs e)
        {
            string student = StudentDD.SelectedValue.ToString();
            string department = DepartmentDD.SelectedValue.ToString();
            string fee = FeeStatusDD.SelectedValue.ToString();


            string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            OracleCommand insert_fee = new OracleCommand("INSERT into FEE(DEPARTMENT_ID, STUDENT_ID, FEE_STATUS)Values('" + student + "','" + department + "','" + fee + "' )");
            insert_fee.Connection = con;
            con.Open();
            insert_fee.ExecuteNonQuery();
            con.Close();

        }
    }
}