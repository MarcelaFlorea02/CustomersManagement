using System.Data;

namespace CustomersManagement;

public partial class DashboardScreen : Form
{
    public DashboardScreen()
    {
        InitializeComponent();
    }

    private async Task DashboardScreen_Load(object sender, EventArgs e)
    {
       await LoadDataAsync();
    }

    public async Task LoadDataAsync()
    {
        DbHelper dbHelper = new DbHelper();
        List<Customer> customersList = await dbHelper.GetCustomersAsync();

        // Convert List<Customer> to DataTable
        DataTable customersTable = new DataTable();
        customersTable.Columns.Add("Id", typeof(int));
        customersTable.Columns.Add("Name", typeof(string));
        customersTable.Columns.Add("Email", typeof(string));
        customersTable.Columns.Add("Phone", typeof(string));
        customersTable.Columns.Add("CreatedAt", typeof(DateTime));
        // Add more columns as needed based on Customer properties

        foreach (var customer in customersList)
        {
            customersTable.Rows.Add(customer.Id, customer.FirstName + ' ' + customer.LastName, customer.Email, customer.Phone, customer.CreatedAt);
            // Add more fields as needed based on Customer properties
        }

        dataGridView1.DataSource = customersTable;
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        CreateScreen createScreen = new CreateScreen(this);
        createScreen.ShowDialog();
    }

    private void deleteButton_Click(object sender, EventArgs e)
    {
        DbHelper dbHelper = new DbHelper();
        if (dataGridView1.SelectedRows.Count > 0)
        {
            int selectedCustomerId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            dbHelper.DeleteCustomer(selectedCustomerId);
            LoadData();
        }
    }

    private void updateButton_Click(object sender, EventArgs e)
    {
        Customer customer = new Customer()
        {
            Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value),
            FirstName = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString().Split(' ')[0],
            LastName = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString().Split(' ')[1],
            Email = dataGridView1.SelectedRows[0].Cells["Email"].Value.ToString(),
            Phone = dataGridView1.SelectedRows[0].Cells["Phone"].Value.ToString(),
        };
        UpdateScreen updateScreen = new UpdateScreen(this, customer);
        updateScreen.ShowDialog();
    }
}
