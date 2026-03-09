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
    public partial class UpdateScreen : Form
    {
        DashboardScreen _parent;
        int _customerId;
        public UpdateScreen(DashboardScreen parent, Customer customer)
        {
            InitializeComponent();
            _parent = parent;
            firstNameInput.Text = customer.FirstName;
            lastNameInput.Text = customer.LastName;
            emailInput.Text = customer.Email;
            phoneInput.Text = customer.Phone;
            _customerId = customer.Id;

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DbHelper dbHelper = new DbHelper();
            Customer updatedCustomer = new Customer
            {
                Id = _customerId,
                FirstName = firstNameInput.Text,
                LastName = lastNameInput.Text,
                Email = emailInput.Text,
                Phone = phoneInput.Text
            };
            dbHelper.UpdateCustomer(updatedCustomer);
            this.Hide();
            _parent.LoadData();
        }
    }
}
