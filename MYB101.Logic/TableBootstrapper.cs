using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYB101.Logic
{
    public static class TableBootstrapper
    {
        public static void CheckCreateTables()
        {
            Data.DatabaseBootstrapper.CreateCustomTables();
        }
    }
}
