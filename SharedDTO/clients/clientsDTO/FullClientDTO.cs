
using SharedDTOLayer.People.PeopleDTO;
using System;


namespace SharedDTOLayer.clients.clientsDTO
{
    public class FullClientDTO : PersonDTO
    {
      

            public FullClientDTO(int ClientID, string UserName, string Password, int ClientPersonID, byte Role, int PersonID,
                string FirstName, string LastName, DateTime DateOfBirth, bool Gender,
                string Address, int NationalityCountryID, string Phone, string email, string personalImage) : base(PersonID, FirstName, LastName, DateOfBirth, Gender,
                 Address, NationalityCountryID, Phone, email, personalImage)
            {
                this.ClientID = ClientID;
                this.UserName = UserName;
                this.Password = Password;
                this.ClientPersonID = ClientPersonID;
                this.Role = Role;

                this.PersonID = PersonID;
                this.FirstName = FirstName;
                this.LastName = LastName;
                this.DateOfBirth = DateOfBirth;
                this.Gender = Gender;
                this.Address = Address;
                this.NationalityCountryID = NationalityCountryID;
                this.Phone = Phone;
                this.Email = email;
                this.PersonalImage = personalImage;


            }
            public FullClientDTO()
            {

                this.ClientID = -1;
                this.UserName = "";
                this.Password = "";
                this.ClientPersonID = -1;
                this.Role = 0;

                this.PersonID = -1;
                this.FirstName = "";
                this.LastName = "";
                this.DateOfBirth = DateTime.MinValue;
                this.Gender = false;
                this.Address = "";
                this.NationalityCountryID = -1;
                this.Phone = "";
                this.Email = "";
                this.PersonalImage = "";
            }


            public int ClientID { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public int ClientPersonID { get; set; }
            public byte Role { get; set; }

        }
    
}
