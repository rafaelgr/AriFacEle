using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace DatosFacturaLib
{
    public static class ficherosLib
    {
        public static void delFicherosDirectorio(string path)
        {
            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path, true);
                }
                catch (Exception e)
                {
                    throw new Exception("Error: El directorio "+path+ " no puede eliminarse.");
                }
            }
            
        }

        public static void CopiarFicheros(string dirOrigen, string dirDestino)
        {
            if (!Directory.Exists(dirDestino))
            {
                Directory.CreateDirectory(dirDestino);
            }
            //comprobamos que existe el directorio origen
            if (Directory.Exists(dirOrigen))
            {
                string[] files = Directory.GetFiles(dirOrigen);
                //copiamos o sobreescribimos los ficheros que se encuentran en el directorio origen
                foreach (string s in files)
                {
                    string fileName="";
                    try
                    {
                        fileName = Path.GetFileName(s);
                        string destFile = Path.Combine(dirDestino, fileName);
                        File.Copy(s, destFile, true);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error: El archivo: " + fileName + ", no puede copiarse.");
                    }
                }
            }
            else
            {
                throw new Exception("Error: El directorio origen no existe");
            }
        }

        public static void CopiarFichero(string pathFichero, string dirDestino)
        {
            if (!Directory.Exists(dirDestino))
            {
                Directory.CreateDirectory(dirDestino);
            }

            //comprobamos que existe el directorio origen
            if (File.Exists(pathFichero))
            {
                string fileName="";
                try
                {
                    fileName = Path.GetFileName(pathFichero);
                    string destFile = Path.Combine(dirDestino, fileName);
                    File.Copy(pathFichero, destFile, true);
                }
                catch (Exception e)
                {
                    throw new Exception("Error: El archivo: " + fileName + ", no puede copiarse.");
                }
            }
            else
            { 
                throw new Exception("Error: El archivo no existe.");
                
            }
        }



    }
}
