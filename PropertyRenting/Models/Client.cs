using System;


namespace Models
{
    public class Client
    {
      public  int ClientID {  get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int ClientPersonID { get; set; }
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public int NationalityCountryID { get; set; }
        public string Phone { get; set; }
        public string email { get; set; }
        public string personalImage { get; set; }

        

     
    }
}
