using System.Data.SqlClient;

namespace Aquapark
{
    public static class DB
    {
       
       public static SqlConnection con = new SqlConnection(Properties.Settings.Default.aparkConnectionString);
       public static SqlCommand com = new SqlCommand();
       


    }

}
