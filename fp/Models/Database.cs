using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibrary;

namespace fp.Models
{
    public class Database
    {
        public static MyDatabaseContext Context = new MyDatabaseContext();

        static Database()
        {
            Context.Database.Migrate();
        }

    }
}
