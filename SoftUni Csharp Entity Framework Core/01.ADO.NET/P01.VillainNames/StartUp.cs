using P01.VillainNames;
using System.Text;
using Microsoft.Data.SqlClient;

await using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);

await sqlConnection.OpenAsync();

string result = await RemoveVillainById(sqlConnection, 1);

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

        SqlDataReader reader = await cmd2.ExecuteReaderAsync();

        sb.AppendLine($"Villain: {name}");
        if (!reader.HasRows)
        {
            sb.AppendLine("(no minions)");
            return sb.ToString();
        }

        while (reader.Read())
        {
            long rowNumber = (long)reader["RowNum"];
            string minionName = (string)reader["Name"];
            int age = (int)reader["Age"];

            sb.AppendLine($"{rowNumber}. {minionName} {age}");
        }
    }
    return sb.ToString().TrimEnd();
}

static async Task<string> RemoveVillainById(SqlConnection connection, int villainId)
{
    SqlCommand command = new SqlCommand(SqlQueries.SelectNameById, connection);

    command.Parameters.AddWithValue("@Id", villainId);

    string? name = await command.ExecuteScalarAsync() as string;

    if (name == null)
    {
        return "No such villain was found.";
    }
    StringBuilder sb = new StringBuilder();

    SqlTransaction transaction = connection.BeginTransaction();

    try
    {
        SqlCommand command2 = new SqlCommand(SqlQueries.DeleteFromMappingTableById, connection, transaction);

        command2.Parameters.AddWithValue("@villainId", villainId);

        int rowsAffected = await command2.ExecuteNonQueryAsync();

        SqlCommand command3 = new SqlCommand(SqlQueries.DeleteFromVillainsById, connection, transaction);

        command3.Parameters.AddWithValue("@villainId", villainId);
        
        await command3.ExecuteNonQueryAsync();

        sb.AppendLine($"{name} was deleted.");
        sb.AppendLine($"{rowsAffected} minions were released.");

        await transaction.CommitAsync();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);

        await transaction.RollbackAsync();
    }

    return sb.ToString().TrimEnd();
}