namespace GoEat.Infrastructure.Settings;

public class SqlServerSettings
{
    public string ConnectionString { get; }

    public SqlServerSettings(string conncectionString)
    {
        ConnectionString = conncectionString;
    }
}

