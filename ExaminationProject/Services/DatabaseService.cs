using SQLite;
using ExaminationProject.Model;

public static class DatabaseService
{
    static SQLiteConnection database;

    public static SQLiteConnection Database
    {
        get
        {
            if (database == null)
            {
                var dbPath = Path.Combine(FileSystem.AppDataDirectory, "shirts.db3");
                database = new SQLiteConnection(dbPath);
                database.CreateTable<Shirt>(); // Create the table if it doesn't exist
            }
            return database;
        }
    }

    public static void AddShirt(Shirt shirt)
    {
        Database.Insert(shirt);
    }

    public static List<Shirt> GetShirts()
    {
        return Database.Table<Shirt>().ToList();
    }

    public static void RemoveShirt(int shirtId) 
    {
        // Find the shirt by its ID
        var shirtToDelete = Database.Table<Shirt>().FirstOrDefault(shirt => shirt.Id == shirtId);

        // If the shirt exists, delete it from the database
        if (shirtToDelete != null)
        {
            Database.Delete(shirtToDelete);
        }
    }
    public static Shirt GetShirtById(int shirtId)
    {
        // Retrieve the shirt by its ID
        return Database.Table<Shirt>().FirstOrDefault(shirt => shirt.Id == shirtId);
    }

    public static void UpdateShirt(Shirt updatedShirt)
    {
        // Update the shirt in the database
        Database.Update(updatedShirt);
    }
}