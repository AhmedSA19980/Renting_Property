using System;
namespace SharedDTOLayer.Offer.DiscountDTO
{
    public class PropertyDiscountDTO
    {

        public PropertyDiscountDTO(int DiscountID, int PropertyID, string CountryName, string City, string Address, decimal Price,
            decimal DiscountPercentage, DateTime StartDate, DateTime EndDate, bool IsCompeleted, bool IsPropertyDeleted)
        {

            this.DiscountID = DiscountID;
            this.PropertyID = PropertyID;
            this.CountryName = CountryName;
            this.City = City;
            this.Address = Address;
            this.Price = Price;
            this.DiscountPercentage = DiscountPercentage;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.IsCompeleted = IsCompeleted;
            this.IsPropertyDeleted = IsPropertyDeleted;

        }
        public int DiscountID { get; set; }
        public int PropertyID { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompeleted { get; set; }


        public string CountryName { get; set; }

        public string City { get; set; }
        public string Address { get; set; }

        public decimal Price { get; set; }
        public bool IsPropertyDeleted { get; set; }


    }

}
