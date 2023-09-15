using System.Data.SqlClient;

namespace GameChanger.Repositories
{
   
    public class Repository
    {
        #region Propiedades
        public SqlConnection masterConnection;
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=DBGameChanger;Trusted_Connection=True;MultipleActiveResultSets=true";
        #endregion
        public Repository()
        {
            masterConnection = new SqlConnection(connectionString);

        }

    }


}
