using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProject.Model
{
    public class History
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int Shirt_Id { get; set; } // Foreign key to Shirt

        public DateTime ReviewDate { get; set; }

        public string Comment { get; set; } = string.Empty;

        public int Rating { get; set; }
    }
}
