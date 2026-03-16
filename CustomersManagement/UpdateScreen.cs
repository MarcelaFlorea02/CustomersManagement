namespace CustomersManagement;

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

    private async Task saveButton_Click(object sender, EventArgs e)
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
        await dbHelper.UpdateCustomerAsync(updatedCustomer);
        this.Hide();
        await _parent.LoadDataAsync();
    }
}
