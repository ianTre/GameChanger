using System.Data.SqlClient;
using System.Data;
using GameChanger.Models;
using System.Reflection.PortableExecutable;

namespace GameChanger.Repositories
{
    public class UserAccountRepository : Repository
    {
        public void Save(UserAccount entry)

        {
            try
            {
                var connection = this.masterConnection;


                SqlCommand command = new SqlCommand("dbo.UserAccount_Save", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = entry.UserName;
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = entry.Email == null ? DBNull.Value : entry.Email;
                command.Parameters.Add("@DNI", SqlDbType.VarChar).Value = entry.DNI;
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = entry.Name == null ? DBNull.Value : entry.Name;
                command.Parameters.Add("@Surname", SqlDbType.VarChar).Value = entry.Surname == null ? DBNull.Value : entry.Surname;
                command.Parameters.Add("@IdCountry", SqlDbType.Int).Value = entry.IdCountry;
                command.Parameters.Add("@IdProvince", SqlDbType.Int).Value = entry.IdProvince;
                command.Parameters.Add("@CreationDate", SqlDbType.DateTime).Value=  entry.CreationDate ==  DateTime.MinValue? DBNull.Value : entry.CreationDate;
                command.Parameters.Add("@BirthDate", SqlDbType.DateTime).Value = entry.BirthDate == DateTime.MinValue ? DBNull.Value : entry.BirthDate;
                command.Parameters.Add("@Password", SqlDbType.VarChar).Value = entry.Password == null ? DBNull.Value : entry.Password;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entry.IsActive;
                                                            

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();


            }
            catch (Exception ex)
            {
                throw ex;
            }




        }

        internal List<Province> GetProvinces()
        {
            
                List<Province> list = new List<Province>();
                var connection = this.masterConnection;
                SqlCommand command = new SqlCommand("dbo.ProvinceGetAll", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                connection.Open();
                var reader = command.ExecuteReader();
                bool isStillData = reader.Read();
                while (isStillData == true)
                {
                    //TODO check for null data incoming from DB
                    Province dataItem = new Province();
                    dataItem.Id = Convert.ToInt32(reader.GetValue(0).ToString());
                    dataItem.Name = Convert.ToString(reader.GetValue(1));
                
                    list.Add(dataItem);

                    isStillData = reader.Read();
                }

                connection.Close();

            return list;    

        }
    }

}
