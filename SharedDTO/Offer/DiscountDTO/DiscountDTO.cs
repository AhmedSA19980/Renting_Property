using System;

namespace SharedDTOLayer.Offer.DiscountDTO
{
    public class DiscountDTO
    {
        public DiscountDTO(int discountID, int propertyId, decimal discountPercentage,
            DateTime startDate, DateTime endDate, bool isDeleted)
        {
            this.DiscountID = discountID;
            this.PropertyID = propertyId;
            this.DiscountPercentage = discountPercentage;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.IsDeleted = isDeleted;

        }
        public DiscountDTO() {
            this.DiscountID = -1;
            this.PropertyID = -1;
            this.DiscountPercentage = 0;
            this.StartDate = DateTime.MinValue;
            this.EndDate = DateTime.MinValue;
            this.IsDeleted = false;


        }



        public int DiscountID { get; set; }
        public int PropertyID { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }
    }

}
