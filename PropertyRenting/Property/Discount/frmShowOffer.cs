using PropertyRenting.Property.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyRenting.Property.Discount
{
    public partial class frmShowOffer : Form
    {
        private int _DiscountID;
        public frmShowOffer(int discountID)
        {
            InitializeComponent();
            _DiscountID = discountID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowOffer_Load(object sender, EventArgs e)
        {
            ctrlShowDiscount1.LoadDiscountInfo(_DiscountID);
        }
    }
}
