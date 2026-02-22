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
    public partial class ctrlFindProperty : UserControl
    {
        public event Action<string> OnPropertySelected;
        protected virtual void PropertySelected(string PropertyID)
        {
            Action<string> handler = OnPropertySelected;
            if (handler != null)
            {
                handler(PropertyID); // Raise the event with the parameter
            }
        }
        private int _propertyID;
        private string _text;
        public ctrlFindProperty()
        {
            InitializeComponent();
        }

        public int propertyID { get { return _propertyID; } }
        public string SearchText { get; set; }
        public bool CursorFocused { get; set; }




       


        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            SearchText = txtFind.Text;
            _text = txtFind.Text;
            

            if (OnPropertySelected != null)
            {
                OnPropertySelected(_text);
            }

        }

        private void ctrlFindProperty_Load(object sender, EventArgs e)
        {
            txtFind.TabStop = false;

        }

 

      

    }
}
