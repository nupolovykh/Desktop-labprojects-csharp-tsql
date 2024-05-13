using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Interface
{
	public partial class Main : Form
	{
		private SqlConnection connection;
		private DataTable dataTable;
		private int amountOfRows = 0;

		public Main (SqlConnection connection)
		{
			InitializeComponent();
			this.connection = connection;
			FillComboBox();
		}

		private void FillComboBox()
		{
			try
			{
				using (DataTable schema = connection.GetSchema("Tables"))
				{
					foreach (DataRow row in schema.Rows)
					{
						comboBox1.Items.Add(row.Field<string>("TABLE_NAME"));
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error while retrieving tables: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				//if (connection.State != ConnectionState.Closed) connection.Close();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string selectedTable = comboBox1.SelectedItem?.ToString();
			if (!string.IsNullOrEmpty(selectedTable))
			{
				string query = $"SELECT * FROM [{selectedTable}]";
				ReadQuery(query);
			}
		}

		private void ReadQuery(string query)
		{
			try
			{
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (SqlDataAdapter adapter = new SqlDataAdapter(command))
					{
						dataTable = new DataTable();
						adapter.FillSchema(dataTable, SchemaType.Mapped);
						adapter.Fill(dataTable);

						//MessageBox.Show(MessageBoxCreator.ShowInfoAboutSelectedTable(dataTable)
						//    .ToString(), $"Info About {dataTable.TableName}", MessageBoxButtons.OK, MessageBoxIcon.Information);

						if (dataGridView1 != null) {
							dataGridView1.DataSource = dataTable;
							amountOfRows = dataTable.Rows.Count;
                            //LockColumnsWithSubstring();
                        }
						else MessageBox.Show("Error: dataGridView has not been initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error with executeing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void LockColumnsWithSubstring()
		{
			foreach (DataGridViewColumn column in dataGridView1.Columns)
			{
				if (column.Name.StartsWith("ID"))
				{
					column.ReadOnly = true;
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)  //Save button
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				foreach (DataGridViewRow row in dataGridView1.SelectedRows)
				{
					List<string> idFields = new List<string>();
					StringBuilder updateQuery = new StringBuilder();
					updateQuery.AppendLine($"UPDATE [{dataTable.TableName}] SET");

					for (int i = 0; i < row.Cells.Count; i++)
					{
						if (dataGridView1.Columns[i].Name.StartsWith("ID"))
						{
							idFields.Add(dataGridView1.Columns[i].Name);
						}
						else
						{
							updateQuery.Append($"{dataGridView1.Columns[i].Name} = '{row.Cells[i].Value}'");
							if (i + 1 < row.Cells.Count)
							{
								updateQuery.Append(", ");
							}
						}
					}

					StringBuilder updateWhere = new StringBuilder("WHERE ");
                    for (int i = 0; i < idFields.Count; i++)
					{
						updateWhere.Append($"{idFields[i]} = '{row.Cells[idFields[i]].Value}'");
						if (i + 1 < idFields.Count)
						{
							updateWhere.Append(" AND ");
						}
					}

					updateQuery.AppendLine(updateWhere.ToString());

                    // You can use the generated update query as needed, such as sending it to the database
                    try
                    {
                        using (SqlCommand command = new SqlCommand(updateQuery.ToString(), connection))
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                            // Check the value of rowsAffected to see how many rows were updated
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"SQL Connection Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
			}

			if (dataTable.Rows.Count > amountOfRows)
			{
				for (int i = amountOfRows; i < dataTable.Rows.Count; i++)
				{
					InsertDataIntoDatabase(dataGridView1.Rows[i]);
                    amountOfRows++;
                }
			}

            button1.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)	//Remove button
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    List<string> idFields = new List<string>();
                    StringBuilder removeQuery = new StringBuilder();
                    removeQuery.AppendLine($"DELETE [{dataTable.TableName}]");

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (dataGridView1.Columns[i].Name.StartsWith("ID"))
                        {
                            idFields.Add(dataGridView1.Columns[i].Name);
                        }
                    }

                    StringBuilder removeWhere = new StringBuilder("WHERE ");
                    for (int i = 0; i < idFields.Count; i++)
                    {
                        removeWhere.Append($"{idFields[i]} = '{row.Cells[idFields[i]].Value}'");
                        if (i + 1 < idFields.Count)
                        {
                            removeWhere.Append(" AND ");
                        }
                    }

                    removeQuery.AppendLine(removeWhere.ToString());

                    try
                    {
                        using (SqlCommand command = new SqlCommand(removeQuery.ToString(), connection))
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                            // Check the value of rowsAffected to see how many rows were updated
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"SQL Connection Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                button1.PerformClick();
            }
        }

        private void button4_Click(object sender, EventArgs e)  //Add button
		{
			if (dataTable != null) DefaultRowCreting();
		}

        private void InsertDataIntoDatabase(DataGridViewRow row)
        {
            List<string> columnNames = new List<string>();
            List<string> columnValues = new List<string>();

            foreach (DataGridViewCell cell in row.Cells)
            {
                string columnName = dataGridView1.Columns[cell.ColumnIndex].Name;
                if (columnName != $"ID_{dataTable.TableName}") // Exclude ID columns
                {
                    columnNames.Add(columnName);
                    columnValues.Add(cell.Value.ToString());
                }
            }

            string insertQuery = $"INSERT INTO [{dataTable.TableName}] (";
            insertQuery += string.Join(", ", columnNames) + ") VALUES (";
            insertQuery += string.Join(", ", columnValues.Select(value => $"'{value}'")) + ")";

            try
            {
                using (SqlCommand command = new SqlCommand(insertQuery.ToString(), connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    // Check the value of rowsAffected to see how many rows were updated
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Connection Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DefaultRowCreting()
		{
            List<string> types = GetTypesOfCells();
            DataRow dr = dataTable.NewRow();

            for (int j = 0; j < types.Count; j++)
            {
                if (dataTable.PrimaryKey.Any(p => dataGridView1.Columns[j].Name == p.ToString()))
                {
                    if (dataGridView1.Rows.Count > dataTable.Rows.Count)
                    {
                        int primaryKeyValue = dataTable.Rows.Count > 0 ?
                            (int)dataTable.Rows[dataTable.Rows.Count - 1][j] + 1 : 1;
                        dr[j] = primaryKeyValue;
                    }
                }
                else
                {
                    switch (types[j])
                    {
                        case "String":
                            dr[j] = "null";
                            break;
                        case "Int32":
                            dr[j] = 1;
                            break;
                        case "Float":
                            dr[j] = 0.0f;
                            break;
                        case "Decimal":
                            dr[j] = 0.0m;
                            break;
                        case "Boolean":
                            dr[j] = false;
                            break;
                        case "DateTime":
                            dr[j] = new DateTime(2022, 10, 15);
                            break;
                        default:
                            // Handle any other data types as per requirement
                            break;
                    }
                }
            }

            dataTable.Rows.Add(dr);
        }

		private List<string> GetTypesOfCells()
		{
			List<string> output = new List<string>();
            foreach (DataGridViewCell cell in dataGridView1.Rows[0].Cells)
            {
                output.Add(cell.Value.GetType().Name);
            }
            return output;
        }

    }
}
