
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

namespace PropertyRenting.Property.controls
{
    public partial class ctrlPropertyCard : UserControl
    {
        public ctrlPropertyCard()
        {
            InitializeComponent();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string img { get; set; }
        public string city { get; set; }

        private void _ResetValues()
        {

            pictureBox1.Image = Resources.info;
            lblName.Text = "???";
            lblPrice.Text = "???";
            lblCity2.Text = "???";

        }


        public async Task LoadPropertyData(int PropertyID)
        {
            var Property = await ApiClient.clsAPIFunctions<Models.PropertyAndContainer>.GetAsync("Property/GetPropertyByIDWithContainer?PropertyID=", PropertyID);
            if (Property != null)
            {


                pictureBox1.ImageLocation = Property.Container.ImageOnePath;
                lblName.Text = Property.Property.Name;
                lblPrice.Text = Convert.ToString(Math.Round(Property.Property.Price, 2));
         
                lblCity2.Text = Property.Property.City;


            }
            else _ResetValues();
        }
        private void ctrlPropertyCard_Load(object sender, EventArgs e)
        {

            pictureBox1.ImageLocation = img;
            lblName.Text = Name;
            lblPrice.Text = Convert.ToString(Math.Round(Price, 2));
        
            lblID.Visible = false;
            lblIdName.Visible = false;
            lblCity2.Text = city;
        }

       
        private void lblView_Click(object sender, EventArgs e)
        {
            BookAProperty frm = new BookAProperty(ID);
            frm.ShowDialog();

        }
    }
}
