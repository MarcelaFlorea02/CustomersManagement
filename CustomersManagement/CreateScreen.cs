using System.Diagnostics;

namespace CustomersManagement;

public partial class CreateScreen : Form
{
    DashboardScreen _parent;
    public CreateScreen(DashboardScreen parent)
    {
        _parent = parent;
        InitializeComponent();
    }

    private async void saveButton_Click(object sender, EventArgs e)
    {
        try
        {
            DbHelper dbHelper = new DbHelper();
            Customer newCustomer = new Customer
            {
                FirstName = firstNameInput.Text,
                LastName = lastNameInput.Text,
                Email = emailInput.Text,
                Phone = phoneInput.Text
            };
            await dbHelper.CreateCustomerAsync(newCustomer);
            this.Hide();

            await _parent.LoadDataAsync();
        }
        catch (Exception ex) {
            Trace.TraceError("Create Customer error: {0}", ex.Message);
            MessageBox.Show(this, "An error occured while trying to create a customer. See logs for details",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
