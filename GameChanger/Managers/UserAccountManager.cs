using GameChanger.Models;
using GameChanger.Repositories;

namespace GameChanger.Managers
{
    public class UserAccountManager 
    {
        private UserAccountRepository _UserAccountRepository;
        public UserAccountManager()
        {
            _UserAccountRepository = new UserAccountRepository();
        }
        
        public void Save(UserAccount user)
        {
            _UserAccountRepository.Save(user);

        }

        internal List<Province> GetProvinces()
        {
             List<Province> provinces = _UserAccountRepository.GetProvinces();

            //List<Province> provinces=new List<Province>();
            //provinces.Add(new Province(){Id=1,Name="Buenos Aires" });
            //provinces.Add(new Province() { Id = 2, Name = "Santa Fe" });
            //provinces.Add(new Province() { Id = 3, Name = "Cordoba" });

            return provinces;


        }
     
        public List<UserAccount> UserAccountGetAll()
        {
         List<UserAccount> list= _UserAccountRepository.UserAccountGetAll();
            return list;
        }

        internal List<UserAccount> UserAccountGetByUserName(UserAccount data)
        {
            List<UserAccount> list = _UserAccountRepository.UserAccountGetAll();
            list = list.Where(x => x.UserName == data.UserName).ToList();
            return list;

        }

        internal bool ComprobDeDNI(string dni)
        {
            if (string.IsNullOrEmpty(dni)) 
            {

                return false;
            
            }
            else
            { string dniSinEspacios= dni.Trim();
                try
                {
                    int dniNumero = Convert.ToInt32(dniSinEspacios);

                    return true;
                }
                catch (Exception)
                {
                    //dni.Length < 7 || dni.Length > 8 Primero hay que sacarle los puntos antes de validar el length


                    return false;
                }
                
            }


            return true;

        }
    }

}
