using P01.VillainNames;
using System.Text;
using Microsoft.Data.SqlClient;

await using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);

await sqlConnection.OpenAsync();

string result = await PrintAllVillainNames(sqlConnection);

Console.WriteLine(result);

static async Task<string> PrintAllVillainNames(SqlConnection connection)
{
    StringBuilder text = new StringBuilder();

    SqlCommand cmd = new SqlCommand(SqlQueries.SelectVillainNames, connection);

    SqlDataReader reader = await cmd.ExecuteReaderAsync();

    while (reader.Read())
    {
        string? name = reader["Name"] as string;
        int? count = reader["MinionsCount"] as int?;

        text.AppendLine($"{name} - {count}");
    }

    return text.ToString().TrimEnd();
}