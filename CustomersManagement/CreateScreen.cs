namespace CustomersManagement;

public partial class CreateScreen : Form
{
    DashboardScreen _parent;
    public CreateScreen(DashboardScreen parent)
    {
        _parent = parent;
        InitializeComponent();
    }

    private async Task saveButton_Click(object sender, EventArgs e)
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
}
