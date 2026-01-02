using System;


namespace SharedDTOLayer.People.PeopleDTO
{
    public class PersonDTO
    {

        public int PersonID { get; set; }
        public string FirstName { set; get; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public int NationalityCountryID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PersonalImage { get; set; }
        public PersonDTO()
        {
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
        public PersonDTO(int PersonID, string firstname, string lastname, DateTime dateOfBirth, bool Gender,
            string Address, int nationalityCountryId, string phone, string email, string personalImage)
        {

            this.PersonID = PersonID;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.DateOfBirth = dateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.NationalityCountryID = nationalityCountryId;
            this.Phone = phone;
            this.Email = email;
            this.PersonalImage = personalImage;


        }
    }
}
