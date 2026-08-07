using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyRenting.Payment
{
    public partial class frmBill : Form
    {
        private int BookingId;
        public frmBill(int bookingId)
        {
            InitializeComponent();
            BookingId = bookingId;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            ctrlBill1.LoadBillInfo(BookingId);
        }
    }
}
