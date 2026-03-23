using System.Data;
using System.Diagnostics;

namespace CustomersManagement;

public partial class DashboardScreen : Form
{
    public DashboardScreen()
    {
        InitializeComponent();
    }

    private async void DashboardScreen_Load(object sender, EventArgs e)
    {
        try
        {
            await LoadDataAsync();
        }
        catch (Exception ex)
        {
            Trace.TraceError("DashboardScreen load error: ", ex.Message);
            MessageBox.Show(this, "An error occured while loading the data. Check logs for details.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public async Task LoadDataAsync()
    {
        try
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
        catch (Exception ex)
        {
            Trace.TraceError("LoadDataAsyc failed: {0}", ex.Message);
            MessageBox.Show("An error ocurred while loading the data. See logs for details",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        try
        {
            CreateScreen createScreen = new CreateScreen(this);
            createScreen.ShowDialog();
        }
        catch (Exception ex)
        {
            Trace.TraceError("Add Button Click failed: {0}", ex.Message);
            MessageBox.Show(this, "An error occured while opening the Add Screen", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void deleteButton_Click(object sender, EventArgs e)
    {
        try
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Please select a customer row before attempting to delete.",
                    "No selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(this, "Are you sure you want to delete the customer?",
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            DbHelper dbHelper = new DbHelper();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedCustomerId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                await dbHelper.DeleteCustomerAsync(selectedCustomerId);
                await LoadDataAsync();
            }
        }
        catch (Exception ex)
        {
            Trace.TraceError("Delete Customer error: {0}", ex.Message);
            MessageBox.Show(this, "An error occured while trying to delete a customer. See logs for details",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void updateButton_Click(object sender, EventArgs e)
    {
        try
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
        catch(Exception ex)
        {
            Trace.TraceError("Update Customer error: {0}", ex.Message);
            MessageBox.Show(this, "An error occured while trying to update a customer. See logs for details",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
