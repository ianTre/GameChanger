using System.Security.Cryptography.Xml;

namespace GameChanger.Models
{
    public class UserAccount
    {
        public int Id {get; set;}
        public string UserName { get; set; }
        public string Email { get; set; }
        public string DNI { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdCountry { get; set; }
        public int IdProvince { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

    }
}
