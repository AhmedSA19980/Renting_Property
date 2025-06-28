using PR_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_BusinessLayer
{
    public  class clsPerson
    {


        public enum enMode { AddNew = 0, Update = 1 };
        public enMode _Mode = enMode.AddNew;

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

       
        public PersonDTO PDTO
        {
            get
            {
                return (new PersonDTO(
                this.PersonID,
                this.FirstName,
                this.LastName,
                this.DateOfBirth,
                this.Gender,
                this.Address,
                this.NationalityCountryID,
                this.Phone,
                this.Email,
                this.PersonalImage

               ));
            }
        }
        public static int GetPersonID; 

        public clsPerson(PersonDTO PDTO, enMode cMode = enMode.AddNew)
        {
            this.PersonID = PDTO.PersonID;
            this.FirstName = PDTO.FirstName;
            this.LastName = PDTO.LastName;
            this.DateOfBirth = PDTO.DateOfBirth;
            this.Gender = PDTO.Gender;
            this.Address = PDTO.Address;
            this.NationalityCountryID = PDTO.NationalityCountryID;
            this.Phone = PDTO.Phone;
            this.Email = PDTO.Email;
            this.PersonalImage = PDTO.PersonalImage;
          
            
            _Mode = cMode;
        }


        public static clsPerson Find(int PersonID)
        {
            PersonDTO PDTO = clsPeopleData.FindPersonByPersonID(PersonID);

            if (PDTO != null)
            {
                return new clsPerson(PDTO, enMode.Update);
            }
            else
                return null;
        }

        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.PersonID = clsPeopleData.AddNewPerson(PDTO);
            GetPersonID = this.PersonID;
            return (this.PersonID != -1);
        }


        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return clsPeopleData.UpdateUser(PDTO);

        }
        public bool Save()
        {


            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();
            }


            return false;
        }

    }
}
