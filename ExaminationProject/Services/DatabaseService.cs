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
        return Database.Table<Shirt>().FirstOrDefault(shirt => shirt.Id == shirtId);
    }

    public static void UpdateShirt(Shirt updatedShirt)
    {
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

    public static string GetCategoryNameById(int categoryId)
    {
        var category = Database.Table<Category>().FirstOrDefault(c => c.Id == categoryId);
        return category?.Name ?? "Saknar kategori";
    }

    // Method to update an existing category in the database
    public static void UpdateCategory(Category category)
    {
        if (category == null) throw new ArgumentNullException(nameof(category));
        Database.Update(category);
    }

    public static void DeleteCategory(int categoryId)
    {
        var category = Database.Table<Category>().FirstOrDefault(c => c.Id == categoryId);
        if (category != null)
        {
            Database.Delete(category);
        }
    }

    // Color Operations
    public static void AddColor(ExaminationProject.Model.Color color) => Database.Insert(color);
    public static List<ExaminationProject.Model.Color> GetColors() => Database.Table<ExaminationProject.Model.Color>().ToList();

    public static string GetColorNameById(int colorId)
    {
        var color = Database.Table<ExaminationProject.Model.Color>().FirstOrDefault(c => c.Id == colorId);
        return color?.Name ?? "Saknar färg";
    }

    // Update an existing color
    public static void UpdateColor(ExaminationProject.Model.Color color)
    {
        Database.Update(color);
    }

    public static void DeleteColor(int colorId)
    {
        var color = Database.Table<ExaminationProject.Model.Color>().FirstOrDefault(c => c.Id == colorId);
        if (color != null)
        {
            Database.Delete(color);
        }
    }

    

    //FILEPATH

    public static string GetFilepathById(int pictureId)
    {
        var picture = Database.Table<Picture>().FirstOrDefault(p => p.Id == pictureId);
        return picture?.Filepath ?? "Saknar bild";
    }

    public static int GetIdByFilepath(string pictureFilepath)
    {
        var picture = Database.Table<Picture>().FirstOrDefault(p => p.Filepath == pictureFilepath);
        return picture?.Id ?? 0;
    }
}