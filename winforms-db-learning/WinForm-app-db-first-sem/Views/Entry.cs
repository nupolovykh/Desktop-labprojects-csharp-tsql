using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Interface
{
    public partial class Entry : Form
    {
        public Entry()
        {
            InitializeComponent();
            comboBox1.Items.Add("home database");
            comboBox1.Items.Add("collegue database");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string server, database;
            
            if(comboBox1.SelectedItem.ToString() == "home") {
                server = "MIZANTROP";
                database = "107g2_PolovykhNA";
            }
            else
            {
                server = "MIZANTROP";
                database = "107g2_PolovykhNA";
            }

            string connectionString = $"Data Source={server};Initial Catalog={database};Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //MessageBox.Show(MessageBoxCreator.ShowInfoAboutConnection(connection), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Main connectForm = new Main(connection);

                    this.Hide();
                    connectForm.ShowDialog();
                    this.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Connection Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Log the exception for further analysis if needed
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Connection Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Log the exception for further analysis if needed
                }
                finally
                {
                    connection.Close(); // Ensure the connection is closed even if an error occurs
                }
            }
        }
	}
}
