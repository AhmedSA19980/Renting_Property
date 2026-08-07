
using ApiClient;
using PropertyRenting.ClassGlobal;
using PropertyRenting.Properties;
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
    public partial class frmAddUpdateCard : Form
    {

      //  public event EventHandler DataAddOrUpdate;
        enum enMode { AddNew = 0, Update = 1 };
        enMode _mode = enMode.AddNew;
        int _CardId = 0;
        int _ClientID = 0;

        private Models.CustomerCard _Card;//  private clsCustomerCard _Card;


        public   frmAddUpdateCard(int ClientID)
        {

            InitializeComponent();
            _ClientID = ClientID;
            var client = Task.Run(() => clsAPIFunctions<Models.Client>.GetAsync("/Clients/clientInfo?id=", ClientID));  
            if (client != null) _ClientID = client.Result.ClientID;

        }
        public frmAddUpdateCard(int ClientID, int CardID)
        {

            InitializeComponent();
            _ClientID = ClientID;
            _CardId = CardID;
            _mode = enMode.Update;


        }


        private void _ResetValues()
        {

            if (_mode == enMode.AddNew && _ClientID != -1)
            {

             //   CustomersPaymentsCardsDataSettingCVVDTO ClientCard;
              //  ClientCard = new CustomersPaymentsCardsDataSettingCVVDTO(-1, "", "", DateTime.MinValue, DateTime.Now, -1, "");
               // _Card = new clsCustomerCard(ClientCard);

            }
            else
            {


            }
            lblCardID.Text = "???";
            lblClientID.Text = "???";
            txtCardno.Text = "???";
            txtCardName.Text = "";
            txtCvv.Text = "";
            //DTPEStablishedD.Value =DateTime.min ;
            //DTPEndD.Value = DateTime.Now;
        }
        public void LoadCardData(int CardID)
        {
            _CardId = CardID;
          //  _Card = clsCustomerCard.Find_2(_CardId);
            if (_Card != null)
            {


                lblCardID.Text = Convert.ToString(_Card.ID);
                lblClientID.Text = Convert.ToString(_Card.ClientID);
                txtCardName.Text = _Card.CardName;
                txtCardno.Text = _Card.CardNo;
                txtCvv.Text = _Card.CVV;
                DTPEStablishedD.Text = clsFormat.DateToShort(_Card.EstablishedDate);
                DTPEndD.Text = clsFormat.DateToShort(_Card.ExpiryDate);




            }
        }
        private void Card_Load(object sender, EventArgs e)
        {

            _ResetValues();
            lblClientID.Text = Convert.ToString(_ClientID);
            if (_mode == enMode.Update)
                LoadCardData(_CardId);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) return;


            _Card.CardName = txtCardName.Text;
            //_Card.CardNo =PR_BusinessLayer.Utilities.clsGlobal.Mask(txtCardno.Text);
            _Card.EstablishedDate = DTPEStablishedD.Value;
            _Card.ExpiryDate = DTPEndD.Value;
            _Card.ClientID = Convert.ToInt32(lblClientID.Text);
            _Card.CVV = txtCvv.Text;

            //if (_Card.Save())
            //{
            //    string result = _mode == enMode.AddNew ? "Created" : "Update";
                
            //    lblCardID.Text = Convert.ToString(_Card.ID);
            //    MessageBox.Show($"Card has {result} successfully! with id: {lblCardID.Text}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //   // DataAddOrUpdate(this, EventArgs.Empty);
            //    _mode = enMode.Update;
            //}
            //else
            //{
            //    MessageBox.Show($"Error: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}



        }

        private void txtCardName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCardName.Text.Trim()) || txtCardName.Text.Length < 9)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCardName, "Field! CardName cannot be empty or less than 10 character");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCardName, null);
            };

        }

        private void txtCvv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCvv.Text.Trim()) || (txtCvv.Text.Length < 3 && txtCvv.Text.Length > 4))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCvv, "Field! CVV cannot be empty or less than 3 numbers");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCvv, null);
            };
        }

        private void DTPEndD_Validating(object sender, CancelEventArgs e)
        {
            if (DTPEndD.Value < DateTime.Now)
            {
                e.Cancel = true;
                errorProvider1.SetError(DTPEndD, "Invalid card epiration Date");
                return;
            }
            else
            {
                errorProvider1.SetError(DTPEndD, null);
            };
        }

        private void txtCvv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtCardno_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCvv.Text.Trim()) || (txtCvv.Text.Length < 13 && txtCvv.Text.Length > 20))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCvv, "Field! CVV cannot be empty or less than 3 numbers");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCvv, null);
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
