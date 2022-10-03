using _3.PL.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PL
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmQLNsx());
        }
        //Scaffold-DbContext 'Data Source=DESKTOP-D08A7VN;Initial Catalog=FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041;User ID=duytdph20598;Password=123456' Microsoft.EntityFrameworkCore.SqlServer -OutputDir DomainClass -context FpolyDBContext -Contextdir Context -DataAnnotations -Force
        
    }
}
