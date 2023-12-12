using GameChanger.Models;
using GameChanger.Repositories;
using System.Collections.Generic;

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
            List<UserAccount> list = _UserAccountRepository.UserAccountGetAll();
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
            {
                try
                {
                    int dniNumero = Convert.ToInt32(dni);
                    if (dni.Length < 7 || dni.Length > 8)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }



            }

        }

        internal bool CheckforCredentials(string username, string passoword) //terminar con Germán tiene que chequear que el usuario y las pass coincidan y existan
        {
            return true;
        }

        internal List<UserAccountViewModel> UserAccountViewModelGetAll()
        {
            List<UserAccount> fulllist = _UserAccountRepository.UserAccountGetAll();
            List<UserAccountViewModel> modelList= new List<UserAccountViewModel>();
            foreach (UserAccount account in fulllist) 
            {
                UserAccountViewModel viewModel = new UserAccountViewModel();

                string province = _UserAccountRepository.GetProvinceById(account.IdProvince);

              viewModel.Id = account.Id;
              viewModel.UserName = account.UserName;
              viewModel.Email = account.Email;
              viewModel.DNI = account.DNI;
              viewModel.Name = account.Name;
              viewModel.Surname = account.Surname;
              viewModel.Country = "Argentina";
              viewModel.Province = province;
              viewModel.CreationDate = account.CreationDate;
              viewModel.BirthDate = account.BirthDate;
              viewModel.IsActive = account.IsActive;
              
              modelList.Add(viewModel);

            }
            return modelList;
        }

        internal void Delete(int id)
        {
            _UserAccountRepository.Delete(id);

        }
    }

}
