
using PropertyRenting.ClassGlobal;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace PropertyRenting.Property.controls
{
   
    public partial class ctrlShowDiscount : UserControl
    {
        public ctrlShowDiscount()
        {
            InitializeComponent();
        }

        private void _RestValues()
        {
            lblDiscountID.Text = "???";
            lblPropertyID.Text = "???"; 
            lblStartDate.Text = "???";  
            lblEndDate.Text = "???";
            lblPerOffer.Text = "???";   

        }
   

        public async Task  LoadDiscountInfo(int DiscountID)
        {
            
            var Discount = await ApiClient.clsAPIFunctions<Models.Discount>.GetAsync("Discount/getDicountbyID?DicountID=", DiscountID);
     
            if (Discount != null ){

                lblDiscountID.Text = Convert.ToString( Discount.DiscountID);
                lblPropertyID.Text = Convert.ToString(Discount.PropertyID);
                lblStartDate.Text =clsFormat.DateToShort( Discount.StartDate);
                lblEndDate.Text = clsFormat.DateToShort(Discount.EndDate);
                lblPerOffer.Text = Convert.ToString(Discount.DiscountPercentage);


            }
            else _RestValues();

        }
       
    }
}
