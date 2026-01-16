using PR_DataAccessLayer;
using SharedDTOLayer.clients.clientsDTO;
using SharedDTOLayer.Earning;
using SharedDTOLayer.Income.IncomesDTO;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_BusinessLayer
{
    public class clsEarnings
    {

        public int ClientID { get; set; }
        public int PropertyID { get; set; }

        public string CountryName { get; set; }

        public decimal Price { get; set; }
        public string DiscountPer { get; set; }
        public string Name { get; set; }
        public bool IsPropertyDeleted { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int BookingClientID { get; set; }

        public string PaymentStatus { get; set; }

        public decimal PricePerDay { get; set; }
        public decimal DiscountAfterPrice { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime PaidDate { get; set; }

        public int BookingID { get; set; }


        public AllOwnerEarningsDTO AOEDTO
        {
            get
            {
                return (new AllOwnerEarningsDTO(


                this.PropertyID,
                this.CountryName,
                this.Price,
                this.DiscountPer,
                this.Name,
                this.IsPropertyDeleted,
                this.StartDate,
                this.EndDate,
                this.BookingClientID,
                this.PaymentStatus,
                this.PricePerDay,
                this.DiscountAfterPrice,
                this.TotalAmount,
                this.PaidDate,
                this.BookingID

               ));
            }
        }

        public AllOwnerEarningsByPropertyDTO AOEBPDTO
        {
            get
            {
                return (new AllOwnerEarningsByPropertyDTO(
                    this.ClientID ,
                this.PropertyID,
                this.CountryName,
                this.Price,
                this.DiscountPer,
                this.Name,
                this.IsPropertyDeleted,
                this.StartDate,
                this.EndDate,
                this.BookingClientID,
                this.PaymentStatus,
                this.PricePerDay,
                this.DiscountAfterPrice,
                this.TotalAmount,
                this.PaidDate,
                this.BookingID
               ));
            }
        }


        public static SettleClientIncomeByPeriodDTO SettleClientIncomeByPeriod(SettleClientIncomeByPeriodValuesDTO Values) {

            return clsEarningData.SettleClientIncomeByPeriod(Values);
        }

        public static decimal TotalIncomeByProperty(int PropertyId)
        {

            return clsEarningData.TotalIncomeByProperty(PropertyId);
        }
        public static List<AllOwnerEarningsDTO> GetAllOwnerEarnings(int ClientID)
        {
            return clsEarningData.GetAllOwnerEarnings (ClientID);

        }

        public static List<AllOwnerEarningsByPropertyDTO> GetAllOwnerEarningsByProperty(int PropertyID)
        {
            return clsEarningData.AllOwnerEarningsByProperty(PropertyID);

        }

    }
}