using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProject.Model
{
    public class Picture
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Filepath { get; set; } = string.Empty;
    }
}
