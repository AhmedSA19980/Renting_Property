﻿
using PR_DataAccessLayer;
using System.Security.Cryptography;

namespace PR_BusinessLayer
{
    public class clsProperty
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;


        public int PropertyID { get; set; }
        public int CountryID { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PlaceDescription { get; set; }
        public string Name { get; set; }    
        public int ContainerID { get; set; }
        public byte NumberOfBedrooms { get; set; }
        public byte NumberOfBathrooms { get; set; }
        public sbyte PropertyTypeID { get; set; }


        public decimal Price { get; set; }

        public clsImages Container { get; set; }
        public clsPropertyType PropertyTypeInfo { get; set; }

        public clsDiscount DiscountInfo { get; set; }
        public int DiscountID { get; set; }
      


        public PropertyDTO PDTO
        {
            get
            {
                return (new PropertyDTO(
                this.PropertyID,
                this.CountryID,
                this.City,
                this.Address,
                this.PlaceDescription,
                this.ContainerID,
               
               
                this.NumberOfBedrooms,
                this.NumberOfBathrooms,
                (byte)this.PropertyTypeID,
                 this.Price,
                this.Name

               ));
            }
        }
        
        public clsProperty(PropertyDTO PDTO, enMode cMode = enMode.AddNew)
        {
            this.PropertyID = PDTO.PropertyID;
            this.CountryID = PDTO.CountryID;
            this.City = PDTO.City;
            this.Address = PDTO.Address;
            this.PlaceDescription = PDTO.PlaceDescription;
            this.ContainerID = PDTO.ContainerID;
            this.NumberOfBedrooms = PDTO.NumberOfBedrooms;
            this.NumberOfBathrooms = PDTO.NumberOfBedrooms;
            this.PropertyTypeID = (sbyte)PDTO.PropertyTypeID;
            this.Price = PDTO.Price;
            this.Name = PDTO.Name;
            this.Container = clsImages.Find(ContainerID);
            this.DiscountID = clsProperty.FindActiveDiscount(PropertyID);
            this.DiscountInfo = clsDiscount.Find(this.DiscountID);
            _Mode = cMode;
        }

     

        public static clsProperty Find(int PropertyID)
        {
            PropertyDTO PDTO = clsPropertyData.FindPropertyByPropertyID2(PropertyID);

            if (PDTO != null)
            {
                return new clsProperty(PDTO, enMode.Update);
            }
            else
                return null;
        }

        private bool _AddNewProperty()
        {
            //call DataAccess Layer 

            this.PropertyID = clsPropertyData.AddProperty(PDTO);

            return (this.PropertyID != -1);
        }


        private bool _UpdateProperty()
        {
            //call DataAccess Layer 

            return clsPropertyData.UpdateProperty(PDTO);

        }

        public static int DeleteProperty(int PropertyID)
        {
            if (PropertyID != -1)
            {
                if(clsPropertyData.DeleteProperty(PropertyID) != false)
                    return 1;
            }
            return -1;
        }

        public static List<PropertyDTO> GetAllProperties() {

            return clsPropertyData.GetAllProperty();
        }




        //public static clsproperty Find(string PropertyName)
        //{

        //    int CountryID = -1, ImagesContainerID = -1; string City = "", Address = "", PlaceDescription = "";
        //    float Price = 0;





        //    if (clsPropertyData.FindPropertyByPropertyID(PropertyID, ref CountryID, ref City, ref Address, ref PlaceDescription, ref ImagesContainerID, ref Price))

        //        return new clsproperty(PropertyID, CountryID, City, Address, PlaceDescription, ImagesContainerID, Price);
        //    else
        //        return null;

        //}


        public static int FindActiveDiscount(int PropertyID)
        {
            return clsPropertyData.CheckActivePropertyDiscount(PropertyID);

        }

        // public 

        public static int FindActiveDiscountByID(int PropertyID)
        {
            int DiscountID = FindActiveDiscount(PropertyID);
            if (DiscountID != 0)
            {
                return clsDiscount.Find(DiscountID).DiscountID;
            }
            return -1;


        }

        public static clsDiscount PropertyPricePrecentOFF(int PropertyID, decimal PrecentOff, string StartDate, string EndDate)
        {
            clsDiscount discount = null;
            int exitOffer = clsProperty.FindActiveDiscountByID(PropertyID);
            if (exitOffer != -1)
            {
                discount = clsDiscount.Find(exitOffer);
                discount.PropertyID = PropertyID;
                discount.StartDate = DateTime.Parse(StartDate);
                discount.EndDate = DateTime.Parse(EndDate);
                discount.DiscountPercentage = PrecentOff;
            }

            if (discount == null)
            {
                DiscountDTO DDTO; DDTO =  new DiscountDTO ( -1,PropertyID , PrecentOff, DateTime.Parse(StartDate)  , DateTime.Parse(EndDate) ,false);
                discount = new clsDiscount(DDTO);
                //discount.PropertyID = PropertyID;
                //discount.StartDate = DateTime.Parse(StartDate);
                //discount.EndDate = DateTime.Parse(EndDate);
                //discount.DiscountPercentage = PrecentOff;
            }
            if (discount.Save())
            {
                return discount;
            }

            return null;

        }
        public static int GetRandomPropertyID()
        {
            return clsPropertyData.GetRandomPropertyID();
        }
        public bool Save()
        {


            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewProperty())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateProperty();
            }


            return false;
        }


    }
}
