
using PropertyRenting.ClassGlobal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyRenting.Card
{
    public partial class ctrlCardDetail : UserControl
    {
        

        public event EventHandler DataDeleted;


        Models.CustomerCard  _card;
        int _CardId;

      
        public ctrlCardDetail()
        {
            InitializeComponent();
        }

        public bool EnableCvv { get { return txtCvv.Visible; } set { txtCvv.Visible = value; } }
        public bool EnableLableCvv { get { return lblCVV.Visible; } set { lblCVV.Visible = value; } }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to This Card [" + _CardId + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                //if (clsCustomerCard.RemoveCard(_CardId) != -1 && DataDeleted != null)
                //{
                //    MessageBox.Show("Card Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    DataDeleted(this, EventArgs.Empty);
                //}

                //else
                //    MessageBox.Show("Card was not Deleted ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void LoadCardData(int CardID)
        {
            _CardId = CardID;
            //_card = clsCustomerCard.Find_2(_CardId);
            //if (_card != null)
            //{


            //    lblCardID.Text = Convert.ToString(_card.ID);
            //    lblClientID.Text = Convert.ToString(_card.ClientID);
            //    lblCardName.Text = _card.CardName;
            //    lblCardNo.Text = _card.CardNo;
            //    //  txtCvv.Text = _card.CVV;
            //    lblEstablishedDate.Text = clsFormat.DateToShort(_card.EstablishedDate);
            //    lblExpairyDate.Text = clsFormat.DateToShort(_card.ExpiryDate);

               

            //}
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ctrlCardDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
