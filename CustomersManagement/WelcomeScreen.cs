using System.Diagnostics;

namespace CustomersManagement;

public partial class WelcomeScreen : Form
{
    public WelcomeScreen()
    {
        InitializeComponent();
    }

    private void loginButton_Click(object sender, EventArgs e)
    {
        try
        {
            DashboardScreen dashboardScreen = new DashboardScreen();
            dashboardScreen.Show();
        }
        catch (Exception ex)
        {
            Trace.TraceError("Error on DashboardScreen load - {0}", ex.Message);
            MessageBox.Show(this, "An error occured while trying to open the Dashboard screen.", "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            this.Hide();
        }
    }
}
