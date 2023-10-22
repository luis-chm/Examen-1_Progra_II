using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examen_1_Progra_II
{
    internal class ClassEmpleado
    {
        // atributos de empleados
        public static int cantidad = 3;
        static private string[] cedula = new string[cantidad];
        static private string[] nombre = new string[cantidad];
        static private string[] direccion = new string[cantidad];
        static private string[] telefono = new string[cantidad];
        static private float[] salario = new float[cantidad];
        private static int indice;
        private static bool empleadoEncontrado;
      
        // metodos
        public static void Inicializar()
        {
            indice = 0;
            cedula = Enumerable.Repeat("", cantidad).ToArray();
            nombre = Enumerable.Repeat("", cantidad).ToArray();
            direccion = Enumerable.Repeat("", cantidad).ToArray();
            telefono = Enumerable.Repeat("", cantidad).ToArray();
            salario = Enumerable.Repeat(0.0f, cantidad).ToArray();

            Console.WriteLine("Cargando arreglos al programa.");
            Console.WriteLine("Por favor espere...");
            // Limpia la pantalla después de 2 segundos
            Thread.Sleep(2000); // Espera 2 segundos (2500 milisegundos)
            Console.WriteLine("Arreglos inicializados con exito.\n");
            Thread.Sleep(1500);
            Console.Clear(); // Limpia la pantalla
        }// fin incializar

        public static void Agregar()
        {
            char respuesta = 'N';
            do
            {
                if (indice < cantidad)
                {
                    Console.Clear();
                    Console.WriteLine($"Digite el número de cedula del empleado ({indice}):");
                    cedula[indice] = Console.ReadLine();
                    Console.WriteLine($"Digite el nombre del empleado ({indice}):");
                    nombre[indice] = Console.ReadLine();
                    Console.WriteLine($"Digite la direccion del empleado ({indice}):");
                    direccion[indice] = Console.ReadLine();
                    Console.WriteLine($"Digite el # telefono del empleado ({indice}):");
                    telefono[indice] = Console.ReadLine();
                    Console.WriteLine($"Digite el salario del empleado ({indice}):");
                    float.TryParse(Console.ReadLine(), out salario[indice]);
                    Console.WriteLine($"\nEmpleado ({indice}) agregado correctamente.\n"); // Agregamos el número del estudiante a la salida
                    indice++;
                    Console.WriteLine("Desea ingresar otro empleado (S/N)");
                    respuesta = Char.Parse(Console.ReadLine().ToString().ToUpper());
                    Console.Clear();
                }//fin if
                else
                {
                    Console.WriteLine("El arreglo se encuentra lleno. No se pueden agregar mas empleados");
                    break;
                }
            } while (respuesta != 'N');
        }//fin metodo agregar
        public static void Consultar(string CedBuscarv)
        {
            Console.Clear();
            Console.WriteLine("Ingrese la cédula del empleado que desea consultar: ");
            CedBuscarv = Console.ReadLine(); // se le ingresa data al parámetro
            Console.Clear();
            empleadoEncontrado = false;// variable abooleana indicando que el empleado encontrado es falso para luego encontrado hacerla true
                         
            foreach (var ced in cedula)// para cada ced en el arreglo cedula si coincide lo ingresado en parametro CedBuscarv imprime los datos del usuario ya que el booleano se vuelve un true
            {
                if (ced == CedBuscarv)// verifica si el valor en ced que ya busco el dato en el arreglo es igual al valor almacenado en CedBuscarv que digito el usuario.
                {
                    int i = Array.IndexOf(cedula, ced); /*básicamente busca el valor ced en el arreglo cedula y almacena el índice de la primera ocurrencia de ese valor en la variable i. 
                     * Esto se usa posteriormente para acceder a los datos relacionados con ese valor en otros arreglos, como nombre, direccion, telefono y salario, para mostrar la información completa d
                     * el empleado encontrado.*/
                    Console.WriteLine("Datos del empleado\n");
                    Console.WriteLine($"N° Cédula: {cedula[i]}");
                    Console.WriteLine($"Nombre: {nombre[i]}");
                    Console.WriteLine($"Dirección: {direccion[i]}");
                    Console.WriteLine($"Teléfono: {telefono[i]}");
                    Console.WriteLine($"Salario: {salario[i]}\n");
                    empleadoEncontrado = true;
                }//fin if
            }// fin for each 
            if (!empleadoEncontrado)//si empleado encontrado no se esta en el analisis anterior de inmediatO lo toma como falso y regresa que no hay datos de ese empleado
            {
                Console.WriteLine($"No se encontró un empleado con la cédula: {CedBuscarv}\n");
            }
            Console.WriteLine("Presione ENTER para regresar al menu");
            Console.ReadLine();
            Console.Clear();
        }//fin metodo consultar

        public static void Modificar()
        {
            Console.Clear();
            Console.WriteLine("Ingrese la cédula del empleado que desea modificar: ");
            string id = Console.ReadLine();
            empleadoEncontrado = false; // Indicador para verificar si se encontró un empleado
            for (indice = 0; indice < cantidad; indice++)
            {
                if (id.Equals(cedula[indice])) 
                {
                    empleadoEncontrado = true; // Se encontró un empleado
                    //modificar cedula
                    Console.WriteLine($"Empleado encontrado.\nModificando empleado ({indice})");
                    Console.WriteLine($"N° Cedula actual: {cedula[indice]}");
                    Console.WriteLine("Digite el nuevo N° Cedula: ");
                    cedula[indice] = Console.ReadLine();
                    //modificar nombre
                    Console.WriteLine($"Nombre actual: {nombre[indice]}");
                    Console.WriteLine("Digite el nuevo nombre: ");
                    nombre[indice] = Console.ReadLine();
                    //modificar direccion
                    Console.WriteLine($"Direccion actual: {direccion[indice]}");
                    Console.WriteLine("Digite el nuevo nombre: ");
                    direccion[indice] = Console.ReadLine();
                    //modifiar telefono
                    Console.WriteLine($"Telefono actual: {telefono[indice]}");
                    Console.WriteLine("Digite el nuevo telefono: ");
                    telefono[indice] = Console.ReadLine();
                    //modificar salario
                    Console.WriteLine($"Salario actual: {salario[indice]}");
                    Console.WriteLine("Digite el nuevo salario: ");
                    float.TryParse(Console.ReadLine(), out salario[indice]);
                    
                    Console.Clear();
                    Console.WriteLine("Nos encontramos guardando los cambios");
                    Console.WriteLine("Por favor espere...");
                    // Limpia la pantalla después de 2 segundos
                    Thread.Sleep(2000); // Espera 2 segundos (2500 milisegundos)
                    Console.WriteLine("Cambios realizados con exito.\n");
                    Thread.Sleep(1500);
                    Console.WriteLine($"\nEmpleado ({indice}) modificado correctamente.\n");
                    Console.WriteLine("Presione ENTER para regresar al menu1");
                    Console.ReadLine();
                    Console.Clear();
                }//fin if encontrar y modificar
            }//fin for each
            if (!empleadoEncontrado)// Se encontró un empleado)
            {
                Console.Clear();
                Console.WriteLine("N° Cédula no encontrada...\n");
                Console.WriteLine("Presione ENTER para regresar al menu2");
                Console.ReadLine();
                Console.Clear();
            }
        }//fin metodo modificar
        public static void Borrar()
        {
            Console.Clear();
            Console.WriteLine("Ingrese la cédula del empleado que desea borrar: ");
            string CedDel = Console.ReadLine();
            empleadoEncontrado = false; // Indicador para verificar si se encontró un empleado
            for (indice = 0; indice < cantidad; indice++)
            {
                if (CedDel.Equals(cedula[indice]))
                {
                    empleadoEncontrado = true;
                    /* Usa Array.Clear para borrar los datos del empleado
                     * Referencias: 
                     * https://learn.microsoft.com/es-es/dotnet/api/system.array.clear?view=net-7.0
                     * https://tinchicus.com/2023/03/22/c-array-clear/  */
                    Array.Clear(cedula, indice, 1);
                    Array.Clear(nombre, indice, 1);
                    Array.Clear(direccion, indice, 1);
                    Array.Clear(telefono, indice, 1);
                    salario[indice] = 0.0f; // 0.0 se utiliza como un valor predeterminado 

                    Console.WriteLine($"Empleado con cédula {CedDel} eliminado con éxito.");
                    break;
                }//fin if 
            }//fin for
            if (!empleadoEncontrado)
            {
                Console.Clear();
                Console.WriteLine("N° de Cédula no encontrada. No se pudo eliminar al empleado.\n");
            }
            Console.WriteLine("Presione ENTER para regresar al menu");
            Console.ReadLine();
            Console.Clear();
        }//fin metodo borrar

        public static void ReportesAll()
        {
            Console.Clear();
            Console.WriteLine("\t\tReporte todos los empleados\n");
            for (indice = 0; indice < cantidad; indice++)
            {
                Console.WriteLine("Cedula\t\tNombre\t\tDireccion\tTelefono\tSalario");
                Console.WriteLine("=========================================================================");
                Console.WriteLine($"{cedula[indice]}\t\t{nombre[indice]}\t\t{direccion[indice]}\t\t{telefono[indice]}\t\t{salario[indice]}\n");
                Console.WriteLine("=========================================================================\n");
            }//fin for
                Date();
                Console.WriteLine("\t\t <PULSE CUALQUIER TECLA PARA ABANDONAR>");
                Console.ReadKey();
                Console.Clear();
        }// fin metodo reporte All
        public static void ReportesAverage(float promedio)
        {
            promedio = salario.Average();
            Console.WriteLine("Calculando. Por favor espere...");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine($"╔═════════════════════════════════════════════╗\r\n║ Promedio de todos los salarios registrados. ║\r\n╠═════════════════════════════════════════════╣\r\n║ Promedio: {promedio}                          ║\r\n╚═════════════════════════════════════════════╝\n");
            Console.WriteLine("\t<PULSE CUALQUIER TECLA PARA ABANDONAR>");
            Console.ReadKey();
            Console.Clear();

        }// fin metodo reporte Average

        public static void ReportesMinMax(float min, float max)
        {
            max = salario[0];
            min = salario[0];

            for (indice = 0; indice < salario.Length; indice++)
            {
                if (salario[indice] > max)
                    max = salario[indice];
                {

                }// fin if
                if (salario[indice] < min)
                {
                    min = salario[indice];
                }
            }//fin for 
            Console.WriteLine("Calculando. Por favor espere...");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine($"╔═════════════════════════════════════════════════════╗\r\n║ Salario más alto y más bajo de todos los empleados. ║\r\n╠═════════════════════════════════════════════════════╣\r\n║ Salario mínimo: {min}                                 ║\r\n║ Salario máximo: {max}                                 ║\r\n╚═════════════════════════════════════════════════════╝");
            Console.WriteLine("\t<PULSE CUALQUIER TECLA PARA ABANDONAR>");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"Min: {min} Max: {max}");
            
        }// fin metodo reporte Min Max
        //Referencia: https://youtu.be/3b5QlkXiUnQ?si=8Dw2jhFzX8hksBoe

        public static void Date()
        {
            DateTime fecha = DateTime.Now; //Instancia == copia de un obketo
            Console.WriteLine($"\t\t\t      {fecha.Day}/{fecha.Month}/{fecha.Year} {fecha.Hour}:{fecha.Minute}");
        }
    }//fin class
}// fin namespace
