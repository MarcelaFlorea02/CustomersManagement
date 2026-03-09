using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomersManagement
{
    public partial class CreateScreen : Form
    {
        DashboardScreen _parent; 
        public CreateScreen(DashboardScreen parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DbHelper dbHelper = new DbHelper();
            Customer newCustomer = new Customer
            {
                FirstName = firstNameInput.Text,
                LastName = lastNameInput.Text,
                Email = emailInput.Text,
                Phone = phoneInput.Text
            };
            dbHelper.AddCustomer(newCustomer);
            this.Hide();

            _parent.LoadData(); 
        }
    }
}
