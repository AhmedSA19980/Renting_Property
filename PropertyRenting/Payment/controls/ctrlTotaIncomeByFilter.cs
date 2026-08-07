using Models;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PropertyRenting.Payment.controls
{
    public partial class ctrlTotaIncomeByFilter : UserControl
    {
        public ctrlTotaIncomeByFilter()
        {
            InitializeComponent();
          

        }
        public event Action<int> OnClientSelected;
        protected virtual void ClientSelected(int ClientId)
        {
            Action<int> handler = OnClientSelected;
            if (handler != null)
            {
                handler(ClientId); // Raise the event with the parameter
            }
        }
        private int _clientId = -1;
        private bool _enabledTBClientid = false;
        public bool EnabledFilterClientId { get { return _enabledTBClientid; }
            set {
                
                _enabledTBClientid = value ;
                txtbox.Enabled = _enabledTBClientid;
            }
        }

        public int ClientId  { get { return _clientId; } set { _clientId = value; }  }
        
        private void DateValidation(DateOnly stDateOnly,  DateOnly exDateOnly)
        {
            if (stDateOnly == exDateOnly || stDateOnly > exDateOnly)
            {
                MessageBox.Show("start date and expired date must be difference/ start date can't be greator than expired date", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private Models.IncomesByPeriodsValues FillIncomeInfo(DateOnly startDate , DateOnly exDate)
        {
            IncomesByPeriodsValues IncomeProps = new IncomesByPeriodsValues {
                ClientId = _clientId,
                StartDate = startDate,
                EndDate = exDate

            };
            return IncomeProps;
        }
        private  void FindNow()
        {
            
            string stDate = clsFormat.DateToShort(dtpStDate.Value);
            string exDate = clsFormat.DateToShort(dtpExDate.Value);

            DateOnly stDateOnly = DateOnly.Parse(stDate);
            DateOnly exDateOnly = DateOnly.Parse(exDate);

            //if (stDateOnly == exDateOnly || stDateOnly > exDateOnly)
            //{
            //    MessageBox.Show("start date and expired date must be difference/ start date can't be greator than expired date", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            DateValidation(stDateOnly, exDateOnly);

            //IncomesByPeriodsValues incomeProps = new IncomesByPeriodsValues
            //{
            //    ClientId = _clientId,
            //    StartDate = DateOnly.Parse(stDate),
            //    EndDate = DateOnly.Parse(exDate)
            //};

           var incomeProps =  FillIncomeInfo(stDateOnly , exDateOnly);
            
            if(!string.IsNullOrEmpty(txtbox.Text)  )
            {
                if (EnabledFilterClientId)
                {
                    _clientId = int.Parse(txtbox.Text);
                    incomeProps.ClientId = _clientId;
                }
            }

            ctrlTotalIncomeByPeriod1.LoadTotalIncomeInfo(incomeProps);

            if (OnClientSelected != null && !EnabledFilterClientId)
                // Raise the event with a parameter
                OnClientSelected(ctrlTotalIncomeByPeriod1.ClientId);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            FindNow();
          
        }

      
        public void frmClientLoad()
        {
            txtbox.Text = _clientId.ToString();
        }
        private void ctrlTotaIncomeByFilter_Load(object sender, EventArgs e)
        {
            
            frmClientLoad();
            txtbox.Focus();
        }
    }
}
