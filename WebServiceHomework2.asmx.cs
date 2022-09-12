using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

namespace Web_Service_Homework2
{
    /// <summary>
    /// Summary description for WebServicewithSQLDBConnection
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService_Homework2 : System.Web.Services.WebService
    {
        SqlConnection myConnection = new SqlConnection();
        DataSet dataset;

        [WebMethod]

        public DataSet DataSetInventar()
        {
            myConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Alexandru-Valentin C\source\repos\Web Service Homework2\App_Data\Database1.mdf;Integrated Security=True;";
            myConnection.Open();

            dataset = new DataSet();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Inventar", myConnection);

            sqlDataAdapter.Fill(dataset, "Inventar");

            myConnection.Close();

            return dataset;
        }

        [WebMethod]
        public void CommandinInventar(string command)
        {

            myConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Alexandru-Valentin C\source\repos\Web Service Homework2\App_Data\Database1.mdf;Integrated Security=True;";
            //"C:\Users\Alexandru-Valentin C\source\repos\Web Service Homework2\App_Data\Database1.mdf"

            myConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = myConnection;
            sqlCommand.CommandText = command;

            sqlCommand.ExecuteNonQuery();

        }
    }
}
