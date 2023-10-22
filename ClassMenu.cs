using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examen_1_Progra_II
{
    internal class ClassMenu
    {
        private static int opcion = 0; //atributo var global
        static public void Menu()
        {
            do
            {
                Console.WriteLine("\t      Examen 1 \t\n");
                Console.WriteLine("-------------Menu Principal-------------");
                Console.WriteLine("Opcion 1:  Inicializar Arreglos");
                Console.WriteLine("Opcion 2:  Agregar Empleados");
                Console.WriteLine("Opcion 3:  Consultar Empleados");
                Console.WriteLine("Opcion 4:  Modificar Empleados");
                Console.WriteLine("Opcion 5:  Borrar Empleados");
                Console.WriteLine("Opcion 6:  Reportes");
                Console.WriteLine("Opcion 7:  Salir");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Seleccione su opcion: ");
                int.TryParse(Console.ReadLine(), out opcion);// si ingresa una letra no va a dejar continuar
                switch (opcion)
                {
                    case 1: ClassEmpleado.Inicializar(); break;
                    case 2: ClassEmpleado.Agregar(); break;
                    case 3: ClassEmpleado.Consultar("");  break;
                    case 4: ClassEmpleado.Modificar(); break;
                    case 5: ClassEmpleado.Borrar(); break;
                    case 6: SubMenuReportes(); break;
                    case 7:
                        Console.WriteLine("¡Hasta pronto! Gracias");
                        Thread.Sleep(1500);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("+------------------------------------------+\r\n| ¡Opcion no valida! Elige una entre 1 y 7 |\r\n+------------------------------------------+");
                        break;
                }// fin switch
            } while (opcion != 7);
        }// fin metodo menu

        public static void SubMenuReportes()
        {
            Console.Clear();
            do
            {
                Console.WriteLine("-------------Submenu Reportes-------------");
                Console.WriteLine("Opcion 1:  Consultar Empleados.");
                Console.WriteLine("Opcion 2:  Reporte de todos los empleados.");
                Console.WriteLine("Opcion 3:  Reporte promedio de los salarios.");
                Console.WriteLine("Opcion 4:  Reporte del salario más alto y el más bajo.");
                Console.WriteLine("Opcion 5:  Regresar al Menu Principal.");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Seleccione su opcion: ");
                int.TryParse(Console.ReadLine(), out opcion);// si ingresa una letra no va a dejar continuar
                switch (opcion)
                {
                    case 1: ClassEmpleado.Consultar(""); break;
                    case 2: ClassEmpleado.ReportesAll(); break;
                    case 3: ClassEmpleado.ReportesAverage(0.0f); break;
                    case 4: ClassEmpleado.ReportesMinMax(0, 0); break;
                    case 5:
                        Console.WriteLine("Regresando...");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("+------------------------------------------+\r\n| ¡Opcion no valida! Elige una entre 1 y 5 |\r\n+------------------------------------------+");
                        break;
                }//fin switch

            } while (opcion != 5);
        }// fin metodo Submenu
    }// fin clase menu
}// fin namespace
