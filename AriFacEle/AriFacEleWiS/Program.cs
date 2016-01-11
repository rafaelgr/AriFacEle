using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;


namespace AriFacEleWiS
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {

            //if (ComoServicio())
            StartAsAService();
            ////StartAsConsole(); //DEBUG
            //else
            //{
            //    StartAsConsole();
            //}
            //StartAsConsole();
        }


        static bool ComoServicio()
        {
            try
            {
                if (File.Exists("ComoExe.dat"))
                    return false;
                
                else
                    return true;

            }
            catch (Exception e)
            {
                return true ;

            }
        }


        static void StartAsAService()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new AriFacService() 
			};
            ServiceBase.Run(ServicesToRun);
        }
        static void StartAsConsole()
        {
            //CntWiS.MarkAsConsole();
            CntWiS.myOnStart(null);
            CntWiS.CopyFiles();
            CntWiS.myOnStop();
        }
    }
}
