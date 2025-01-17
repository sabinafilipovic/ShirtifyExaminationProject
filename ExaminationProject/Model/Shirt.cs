using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProject.Model
{
    public class Shirt
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int Category_Id { get; set; } // Foreign key to Category

        [Indexed]
        public int Color_Id { get; set; } // Foreign key to Color

        [Indexed]
        public int Picture_Id { get; set; } // Foreign key to Color

        public string Brand {  get; set; } = string.Empty;

        
        // Computed properties to retrieve the names
        [Ignore]
        public string Category_Name => DatabaseService.GetCategoryNameById(Category_Id);

        [Ignore]
        public string Color_Name => DatabaseService.GetColorNameById(Color_Id);

        [Ignore]
        public string Picture_Filepath => DatabaseService.GetFilepathById(Picture_Id);
    }
}
