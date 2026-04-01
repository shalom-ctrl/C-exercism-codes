using System;

public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        // The using statement ensures database.Dispose() is called 
        // at the end of the block, even if an exception occurs.
        using (database)
        {
            database.BeginTransaction();
            database.Write(data);
            database.EndTransaction();
        }
    }

    public bool WriteSafely(string data)
    {
        try
        {
            // We can call our existing Write method to reuse the logic
            Write(data);
            return true;
        }
        catch (Exception)
        {
            // Any exception (bad data, bad commit, etc.) returns false
            return false;
        }
    }
}