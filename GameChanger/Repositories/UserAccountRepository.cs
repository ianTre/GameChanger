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
            int IdArgentina = 1; //Valor Temporal mientras solo Funcione en Argentina
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
                command.Parameters.Add("@IdCountry", SqlDbType.Int).Value = IdArgentina;
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
     
        public List<UserAccount> UserAccountGetAll() 
        {
            List<UserAccount> list = new List<UserAccount>();
            var connection = this.masterConnection;
            SqlCommand command = new SqlCommand("dbo.UserAccountGetAll", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;


            connection.Open();
            var reader = command.ExecuteReader();
            bool isStillData = reader.Read();
            while (isStillData == true)
            {
                UserAccount user = new UserAccount();

                user.Id = Convert.ToInt32(reader.GetValue(0).ToString());
                user.UserName = Convert.ToString(reader.GetValue(1));
                user.Email = Convert.ToString(reader.GetValue(2));
                user.DNI = Convert.ToString(reader.GetValue(3));
                user.Name = Convert.ToString(reader.GetValue(4));
                user.Surname = Convert.ToString(reader.GetValue(5));
                user.IdCountry = Convert.ToInt32(reader.GetValue(6).ToString());
                user.IdProvince = Convert.ToInt32(reader.GetValue(7).ToString());

                var dateReaderData = reader.GetValue(8);
                user.CreationDate = dateReaderData == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dateReaderData);
                var BirthReaderData = reader.GetValue(9);
                user.BirthDate = BirthReaderData == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(BirthReaderData);

                //user.CreationDate = Convert.ToDateTime(reader.GetValue(8).ToString());
                //user.BirthDate = Convert.ToDateTime(reader.GetValue(9).ToString());
                user.Password = Convert.ToString(reader.GetValue(10));
                user.IsActive= Convert.ToBoolean(reader.GetValue(11).ToString());




                list.Add(user);

                isStillData = reader.Read();
            }

            connection.Close();
            list=list.Where(x => x.IsActive == true).ToList();

            return list;


        }
    
    
    }

}
