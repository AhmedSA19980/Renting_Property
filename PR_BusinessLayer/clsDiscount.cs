using PR_DataAccessLayer;
using SharedDTOLayer.Offer.DiscountDTO;
using System.Data;




namespace PR_BusinessLayer
{
    public class clsDiscount
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        public int DiscountID { get; set; }
        public int PropertyID { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }



        public DiscountDTO DDTO { get { return (new DiscountDTO(
            this.DiscountID,
            this.PropertyID,    
            this.DiscountPercentage,
            this.StartDate,
            this.EndDate,
            this.IsDeleted
            )); } 
        
        }


        public clsDiscount(DiscountDTO DDTO  , enMode cMode = enMode.AddNew)
        {
            this.DiscountID = DDTO.DiscountID;
            this.PropertyID = DDTO.PropertyID;
            this.DiscountPercentage = DDTO.DiscountPercentage;
            this.StartDate = DDTO.StartDate;
            this.EndDate = DDTO.EndDate;
            this.IsDeleted = this.IsDeleted; // Assuming new discounts are not deleted by default
            _Mode = cMode;
        }


        private bool _AddNewDiscount()
        {
            // Call DataAccess Layer
            this.DiscountID = clsDiscountData.AddNewDiscount(DDTO);

            return (this.DiscountID != -1);
        }

        private bool _UpdateDiscount()
        {
            // Call DataAccess Layer
            return clsDiscountData.UpdateDiscount(DDTO);
        }


        public static int DeleteDiscountOffer(int discountID)
        {

            return (clsDiscount.Find(discountID) != null) ? clsDiscountData.DeleteDiscount(discountID) ? 1 :-1: -1;
            
        }


        public static clsDiscount Find(int discountID)
        {
            DiscountDTO DDTO = clsDiscountData.FindDiscountByDiscountID(discountID);

            if (DDTO != null)
            {
                return new clsDiscount(DDTO, enMode.Update);
            }
            else
                return null;
        }



        public static decimal ImplementDiscount(int PropertyID)
        {
            int FindValidDiscount = clsProperty.FindActiveDiscount(PropertyID);
            var DiscuntPrecentage =(decimal) clsDiscount.Find(FindValidDiscount).DiscountPercentage; // error
           

            clsProperty Property = clsProperty.Find(PropertyID);
            decimal PropertyPrice = Property.Price;

            decimal AmountPrecent = (DiscuntPrecentage / 100) * PropertyPrice;
            decimal TotalPriceAfterDiscount =Math.Abs( PropertyPrice - AmountPrecent);

            return TotalPriceAfterDiscount;



        }
        public static clsDiscount GetDiscountsByPropertyID(int propertyID )
        {
            DiscountDTO DDTO = clsDiscountData.FindDiscountByPropertyID(propertyID);

            if (DDTO != null)
            {
                return new clsDiscount(DDTO, enMode.Update);
            }
            else
                return null;
        }

        public static List<DiscountDTO> GetAllDiscountsByPropertyID(int propertyID)
        {
            List<DiscountDTO> Discounts;
            if (propertyID != -1)
            {
                if (clsDiscountData.FindAllDiscountByPropertyID(propertyID) != null)
                {
                   Discounts =  clsDiscountData.FindAllDiscountByPropertyID(propertyID);
                    return Discounts;
                }
            }
          
           
            return null;
        }

        // possibility to  add optional constructors for Update scenario if needed
        public static  DataTable GetPropertysDiscounts(int propertyID)
        {
            return clsDiscountData.GetPropertysDiscounts(propertyID);   
        }
        public static List<PropertyDiscountDTO> FindAllDiscountBelongToAPropertyByPropertyID(int PropertyID)
        {
            return clsDiscountData.FindAllDiscountBelongToAPropertyByPropertyID(PropertyID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDiscount())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateDiscount();

                default:
                    return false;
            }
        }

    }
}
