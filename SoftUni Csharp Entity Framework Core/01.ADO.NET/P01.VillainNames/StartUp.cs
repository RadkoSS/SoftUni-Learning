using P01.VillainNames;
using System.Text;
using Microsoft.Data.SqlClient;

await using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);

await sqlConnection.OpenAsync();

string result = await PrintAllMinionsNames(sqlConnection, 4);

Console.WriteLine(result);

static async Task<string> PrintAllVillainNames(SqlConnection connection)
{
    StringBuilder sb = new StringBuilder();

    SqlCommand cmd = new SqlCommand(SqlQueries.SelectVillainNames, connection);

    SqlDataReader reader = await cmd.ExecuteReaderAsync();

    while (reader.Read())
    {
        string? name = reader["Name"] as string;
        int? count = reader["MinionsCount"] as int?;

        sb.AppendLine($"{name} - {count}");
    }

    return sb.ToString().TrimEnd();
}

//To-Do
static async Task<string> PrintAllMinionsNames(SqlConnection connection, int villainId)
{
    StringBuilder sb = new StringBuilder();

    SqlCommand cmd = new SqlCommand(SqlQueries.SelectNameById, connection);

    cmd.Parameters.AddWithValue("@Id", villainId);

    string? name = await cmd.ExecuteScalarAsync() as string;

    if (name == null)
    { 
        sb.AppendLine($"No villain with ID {villainId} exists in the database.");
    }
    else
    {
        SqlCommand cmd2 = new SqlCommand(SqlQueries.SelectMinionsById, connection);

        cmd2.Parameters.AddWithValue("@Id", villainId);

        SqlDataReader reader = await cmd.ExecuteReaderAsync();

        sb.AppendLine($"Villain: {name}");
        if (!reader.HasRows)
        {
            sb.AppendLine("(no minions)");
        }

        while (reader.Read())
        {
            long rowNumber = (long)reader["RowNum"];
            string minionName = (string)reader["Name"];
            int age = (int)reader["Age"];

            sb.AppendLine($"{rowNumber} {minionName} {age}");
        }
    }
    return sb.ToString().TrimEnd();
}