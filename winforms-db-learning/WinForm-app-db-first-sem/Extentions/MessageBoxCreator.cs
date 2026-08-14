using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Extentions
{
    public static class MessageBoxCreator
    {
        public static StringBuilder ShowInfoAboutSelectedTable(DataTable table)
        {
            StringBuilder infoBuilder = new StringBuilder();

            // Building column information
            infoBuilder.AppendLine("Columns:");
            foreach (DataColumn column in table.Columns)
            {
                infoBuilder.AppendLine($" {column.ColumnName} - DataType: {column.DataType}");
            }

            // Building primary key information
            if (table.PrimaryKey.Length > 0)
            {
                infoBuilder.AppendLine("Primary Key(s):");
                foreach (DataColumn primaryKey in table.PrimaryKey)
                {
                    infoBuilder.AppendLine($" {primaryKey.ColumnName}");
                }
            }

            return infoBuilder;
        }

        public static string ShowInfoAboutConnection(SqlConnection connection)
        {
            string connectionInfo =
            $"DataSource = {connection.DataSource}\n" +
            $"ClientConnectionId = {connection.ClientConnectionId}\n" +
            $"ConnectionString = {connection.ConnectionString}\n" +
            $"Database = {connection.Database}\n" +
            $"State = {connection.State}";
            return connectionInfo;
        }
    }
}
