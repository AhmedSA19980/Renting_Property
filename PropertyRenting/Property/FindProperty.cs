using ApiClient;
using Microsoft.VisualBasic.Devices;
using Models;
using Newtonsoft.Json.Linq;
using PropertyRenting.Property.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PropertyRenting.Property
{
    public partial class FindProperty : Form
    {


        private BindingList<Models.Property> _PropertiesInfo;
        private Models.Property _PropertyImg;
        public FindProperty()
        {
            InitializeComponent();
        }


        List<ctrlPropertyCard> _allPropertyCard;

        private async Task<BindingList<Models.Property>> ListAllActiveProperties()
        {
            var activeProperties = await clsAPIFunctions<BindingList<Models.Property>>.GetAsync2("Property/AllActive");
            if (!activeProperties.IsSuccess) return null;
            return activeProperties.Value;

        }
        private async Task<Models.Property> GetFullPropertyInfo(int propertyId)
        {
            return await ApiClient.clsAPIFunctions<Models.Property>.GetAsync("Property/GetPropertyByIDWithContainer?PropertyID=", propertyId);
        }
        private async void FindProperty_Load(object sender, EventArgs e)
        {

            _PropertiesInfo = await ListAllActiveProperties();
            _allPropertyCard = new List<ctrlPropertyCard>();


            flowLayoutPanel1.SuspendLayout();

            foreach (var property in _PropertiesInfo)
            {
                _PropertyImg = await GetFullPropertyInfo(property.PropertyID);
                ctrlPropertyCard propertyCard = new ctrlPropertyCard
                {
                    Name = property.Name,
                    Price = property.Price,
                    img = _PropertyImg.Container.ImageOnePath,
                    ID = property.PropertyID,
                    city = property.City,
                };
             
                _allPropertyCard.Add(propertyCard);
                flowLayoutPanel1.Controls.Add(propertyCard);
            }


            flowLayoutPanel1.ResumeLayout();
        }

       

        private void ctrlFindProperty1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlFindProperty1_OnPropertySelected(string obj)
        {
            obj = ctrlFindProperty1.SearchText;
            foreach (var card in _allPropertyCard)
            {
                card.Visible = card.city
                    .StartsWith(ctrlFindProperty1.SearchText, StringComparison.OrdinalIgnoreCase) || card.Name
                    .StartsWith(obj, StringComparison.OrdinalIgnoreCase);
            }

        }

        private void FindProperty_Click(object sender, EventArgs e)
        {
           ctrlFindProperty1.CursorFocused = false;
        }
    }
}
