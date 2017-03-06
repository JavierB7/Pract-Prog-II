using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1
{
    class BarajeoPerfecto
    {
        public BarajeoPerfecto()
        {

        }

        public string[] lineasArchivo(string nombreArchivo)
        {
            string ruta = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directorio = System.IO.Path.GetDirectoryName(ruta);
            for (var i = 0; i < 3; i++)
            {
                directorio = System.IO.Path.GetDirectoryName(directorio);
            }
            var rutaArchivo = directorio + "\\" + nombreArchivo;
            string[] lineas = System.IO.File.ReadAllLines(rutaArchivo);
            return lineas;
        }

        static void Main(string[] args)
        {
            BarajeoPerfecto baraja = new BarajeoPerfecto();
            var nombreArchivo = "barajeo.in";
            string[] lineas = baraja.lineasArchivo(nombreArchivo);

            Console.WriteLine("\t/-Barajeo Perfecto-/");
            Console.WriteLine("    Entrada: \n");
            for (var i = 0; i < lineas.Length; i++) {
                Console.WriteLine(lineas[i]);
            }

            int tamano = lineas.Length - 2;
            int primeraMitad = tamano / 2;
            string[] vector1 = new string[primeraMitad];
            int segundaMitad = tamano - primeraMitad;
            string[] vector2 = new string[segundaMitad];
            int c1 = 0;
            int c2 = 0;
            for (var i = 2; i < lineas.Length; i++)
            {
                if (i < primeraMitad + 2)
                {
                    vector1[c1] = lineas[i];
                    c1++;
                }
                else
                {
                    vector2[c2] = lineas[i];
                    c2++;
                }
                
            }

            c1 = 0;
            c2 = 0;
            for (var i = 2; i < lineas.Length; i++)
            {
                if (((i % 2) == 0))
                {
                    if (i <= (primeraMitad * 2))
                    {
                        lineas[i] = vector1[c1];
                        c1++;
                    }
                }
                else
                {
                    lineas[i] = vector2[c2];
                    c2++;
                }
            }
        
            Console.WriteLine("\n    Salida: \n");
            for (var i = 2; i < lineas.Length; i++)
            {
                Console.WriteLine(lineas[i]);
            }

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
