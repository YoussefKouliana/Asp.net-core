using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Environment;

namespace Northwind.DataContext.SqlServer
{
    /// <summary>
    /// logger for NorthwindContext, ska logggas till fill
    /// </summary>
    public class NorthwindContextLogger
    {
        public static void WriteLine(string message)
        {
            string path = Path.Combine(GetFolderPath(SpecialFolder.DesktopDirectory), "Northwindlog.txt");
            StreamWriter TextFile = File.AppendText(path);
            TextFile.WriteLine(message);
            TextFile.Close();
        }
    }
        
}
