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
                database.CreateTable<Shirt>();
                database.CreateTable<History>();
                database.CreateTable<Category>();
                database.CreateTable<ExaminationProject.Model.Color>();
                database.CreateTable<Picture>();
            }
            return database;
        }
    }

    //Used when changes have been made to the tables and need a reset
    public static void DeleteDatabase()
    {
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "shirts.db3");

        if (File.Exists(dbPath))
        {
            File.Delete(dbPath);
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

    public static void AddPicture(Picture picture)
    {
        Database.Insert(picture);
    }

    public static Picture GetPictureById(int pictureId)
    {
        return Database.Table<Picture>().FirstOrDefault(p => p.Id == pictureId);
    }

    public static List<Picture> GetAllPictures()
    {
        return Database.Table<Picture>().ToList();
    }

    // Category Operations
    public static void AddCategory(Category category) => Database.Insert(category);
    public static List<Category> GetCategories() => Database.Table<Category>().ToList();

    // Color Operations
    public static void AddColor(ExaminationProject.Model.Color color) => Database.Insert(color);
    public static List<ExaminationProject.Model.Color> GetColors() => Database.Table<ExaminationProject.Model.Color>().ToList();

    public static string GetCategoryNameById(int categoryId)
    {
        var category = Database.Table<Category>().FirstOrDefault(c => c.Id == categoryId);
        return category?.Name ?? "Unknown";
    }

    public static string GetColorNameById(int colorId)
    {
        var color = Database.Table<ExaminationProject.Model.Color>().FirstOrDefault(c => c.Id == colorId);
        return color?.Name ?? "Unknown";
    }

    public static string GetFilepathById(int pictureId)
    {
        var picture = Database.Table<Picture>().FirstOrDefault(p => p.Id == pictureId);
        return picture?.Filepath ?? "Unknown";
    }
}