﻿using PR_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PR_BusinessLayer
{
    public class clsClients : clsPerson
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        public int ClientID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PersonID { get; set; }


        public int getPersonID { get { return clsPerson.Find(PersonID).PersonID; } }

        public ClientDTO CDTO
        {
            get
            {
                return (new ClientDTO(
               this.ClientID,
               this.UserName,
               this.Password,
               this.PersonID
            
               ));
            }
        }

        public FullClientDTO FCDTO
        {
            get
            {
                return (new FullClientDTO(
                   
               this.ClientID,
               this.UserName,
               this.Password,
               this.PersonID,

                this.PersonID,
                this.FirstName ,
                this.LastName ,
                this.DateOfBirth ,
                this.Gender ,
                this.Address,
                this.NationalityCountryID ,
                this.Phone ,
                this.Email ,
                this.PersonalImage
             

               ));
            }
        }

      

        public clsClients(FullClientDTO CDTO, enMode cMode = enMode.AddNew) : base(new PersonDTO( // Call base class constructor with PersonDTO data
            CDTO.PersonID,
            CDTO.FirstName,
            CDTO.LastName,
            CDTO.DateOfBirth,
            CDTO.Gender,
            CDTO.Address,
            CDTO.NationalityCountryID,
            CDTO.Phone,
            CDTO.Email,
            CDTO.PersonalImage
        ))
        {
            this.PersonID = CDTO.PersonID;
            this.FirstName = CDTO.FirstName;
            this.LastName = CDTO.LastName;
            this.Email = CDTO.Email;
            this.Phone = CDTO.Phone;
            this.NationalityCountryID = CDTO.NationalityCountryID;  
            this.Gender = CDTO.Gender;
            this.Address = CDTO.Address;    
            this.PersonalImage = CDTO.PersonalImage;    
            this.DateOfBirth = CDTO.DateOfBirth;
          
            this.ClientID = CDTO.ClientID;
            this.UserName = CDTO.UserName;
            this.Password = CDTO.Password;
        
            this.PersonID = CDTO.PersonID;

            _Mode = cMode;
        }



        private bool _AddNewClient()
        {
            //call DataAccess Layer 
            this.PersonID = clsPerson.GetPersonID;
            this.ClientID = clsClientsData.AddNewClient(CDTO);
          
            return (this.ClientID != -1);
        }


        private bool _UpdateClient()
        {
            //call DataAccess Layer 

            return clsClientsData.UpdateClient(CDTO);

        }

        public static bool BlockClient(int PersonID)
        {
            return clsPeopleData.Blockuser(PersonID);   
        }


        public static bool UnBlockClient(int PersonID)
        {

            return clsPeopleData.UnBlockuser(PersonID);

        }



        public static bool FindUserNameAndPassword(string UserName , string Password)
        {
            return clsClientsData.GetUserByUserNameAndPassword(UserName , Password) ;
        }

        public static clsClients FindFullInfoUserNameAndPassword(string UserName, string Password)
        {

            FullClientDTO FDTO = clsClientsData.GetUserInfoByUserNameAndPassword(UserName , Password);
            if (FDTO != null)
            {
                return new clsClients(FDTO, enMode.Update);
            }
            else return null;
            
        }

        public static bool FindUserInfoNameAndPassword(string UserName, string Password)
        {
            ClientDTO CDTO = clsClientsData.GetUserInfoByUserNameAndPassword_2(UserName, Password);
            return CDTO != null ?  true : false;
        }


        public static clsClients Find(int ClientID)
        {
            FullClientDTO CDTO = clsClientsData.GetFullClientInfoByID(ClientID);

            if (CDTO != null)
            {
                return new clsClients(CDTO, enMode.Update);
            }
            else
                return null;
        }


        public static bool IsUserBlocked(int PersonID)
        {
            return clsPeopleData.IsUserBlocked(PersonID);
        }
        public static bool ChangePassword(int clientID, string Password)
        {
            return clsClientsData.ChangePassword(clientID, Password);
        }


        public bool Save()
        {

            base._Mode =(clsPerson.enMode) _Mode;
            if (!base.Save()) return false;


            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewClient())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateClient();
            }


            return false;
        }



    }

}


