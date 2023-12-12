namespace GameChanger.Models
{
    public class UserAccountViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string DNI { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }

    }


}
