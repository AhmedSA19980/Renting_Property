using PropertyRenting.Card;
using PropertyRenting.ClassGlobal;
using PropertyRenting.Property;
using PropertyRenting.Property.Discount;
using PropertyRenting.Reservation;
using PropertyRenting.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyRenting
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static  void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool isAuthenticated;
          
            try {
            
                isAuthenticated =   GetUserData.InitializeSession().Result;
            } catch (Exception ex) { 
            
            
                isAuthenticated = false;
            }


            Application.Run(isAuthenticated ? new frmMain(clsGlobal.CurrentUser) : new frmMain(null));

           
        }
    }
}
