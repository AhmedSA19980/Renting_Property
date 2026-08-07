
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
    public partial class ShowClientCards : Form
    {
        int _CardID;
        int _ClientID;
        private static DataTable _Cards;

        public ShowClientCards(int CardID, int ClientID = 4)
        {
            InitializeComponent();
            _CardID = CardID;
            _ClientID = ClientID;
            ctrlCardDetail1.DataDeleted += ctrlCardDetail1_DataDeleted;
          //  _Cards = clsCustomerCard.GetCardClients(_ClientID);


        }


    

        private void ShowClientCards_Load(object sender, EventArgs e)
        {
            //ctrlCardDetail1.LoadCardData();

            ctrlCardDetail1.LoadCardData(_CardID);
            _Cards = null;//clsCustomerCard.GetCardClients(_ClientID);
            DgvCards.DataSource = _Cards;
            lblTotalRecords.Text = DgvCards.Rows.Count.ToString();



            DgvCards.DataSource = _Cards;
            cbFilterBy.SelectedIndex = 0;
            lblTotalRecords.Text = DgvCards.Rows.Count.ToString();
            if (DgvCards.Rows.Count > 0)
            {

                DgvCards.Columns[0].HeaderText = "Card ID";
                DgvCards.Columns[0].Width = 110;


                DgvCards.Columns[1].HeaderText = "Card Name";
                DgvCards.Columns[1].Width = 110;



                DgvCards.Columns[2].HeaderText = "Card No";
                DgvCards.Columns[2].Width = 120;


                DgvCards.Columns[3].HeaderText = "E Date.";
                DgvCards.Columns[3].Width = 120;

                DgvCards.Columns[4].HeaderText = "Exp Date.";
                DgvCards.Columns[4].Width = 140;


                DgvCards.Columns[5].HeaderText = "Client ID";
                DgvCards.Columns[5].Width = 150;



            }
        }




        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            /*
        None
       Card ID
       Card Name
       Card No
        */

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Card ID":
                    FilterColumn = "ID";
                    break;

                case "Card Name":
                    FilterColumn = "CardName";
                    break;

                case "Card No":
                    FilterColumn = "CardNo";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _Cards.DefaultView.RowFilter = "";
                lblTotalRecords.Text = DgvCards.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "ID")
                //in this case we deal with integer not string.

                _Cards.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _Cards.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblTotalRecords.Text = _Cards.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }




        }

        private void ShowClientCards_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cbFilterBy.Text == "Card ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //ShowClientCards frm  = new ShowClientCards(2);
            //frm.ShowDialog();(int)DgvCards.CurrentRow.Cells[0].Value
            //ShowClientCards_Load(null , null);

            ctrlCardDetail frm = new ctrlCardDetail();
            frm.Show();


            //            ShowClientCards_Load((int)DgvCards.CurrentRow.Cells[0].Value, null);
            //ShowClientCards_Load(null, null);
            _CardID = (int)DgvCards.CurrentRow.Cells[0].Value;
            ctrlCardDetail1.LoadCardData(_CardID);
            ShowClientCards_Load(null, null);
          //  MessageBox.Show($"{_CardID}");

        }


        private void ctrlCardDetail1_DataDeleted(object sender, EventArgs e)
        {
            int topRow = (int)DgvCards.Rows[0].Cells[0].Value;

            ShowClientCards_Load(null, null);

            if (DgvCards.Rows.Count > 0)
            {
                _CardID = topRow;
                ctrlCardDetail1.LoadCardData(_CardID);

            }
            else
            {
                MessageBox.Show("Customers Cards are empty! ", "Empty", MessageBoxButtons.OK);
                this.Close();

            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            int SelectedCard = (int)DgvCards.CurrentRow.Cells[0].Value;
            _CardID = SelectedCard;
            frmAddUpdateCard frm =new  frmAddUpdateCard( _ClientID,_CardID);
            frm.Show();
            ShowClientCards_Load(null, null);
          
        }
    }
}
