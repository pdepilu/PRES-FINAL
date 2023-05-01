using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entrega_Final
{
    class Program
    {
        struct recibo
        {
            public string nombreSucursal;
            public int sala;
            public string Formato;
            public string edad;
            public int cantidadEntradas, indiceSucursal;
        }
        static bool[,] butacas = new bool[8, 5];
        static double precioButaca = 5.80;
        public static void Main(string[] args)
        {
            LogIn();
            MENU();
            Recibo();
            informe();
        }
        static void LogIn()
        {
            Console.WindowWidth = 65;
            Console.WindowHeight = 40;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Title = "Inicio de Sesión";
            string usersFile = "users.txt";
            bool isLoggedIn = false;

            Console.WriteLine("Ingrese su nombre de usuario:");
            string username = Console.ReadLine();
            Console.WriteLine("Ingrese su contraseña:");
            string password = Console.ReadLine();


            if (File.Exists(usersFile))
            {
                string[] users = File.ReadAllLines(usersFile);
                foreach (string user in users)
                {
                    string[] userDetails = user.Split(',');
                    if (userDetails[0] == username && userDetails[1] == password)
                    {
                        isLoggedIn = true;
                        break;
                    }
                }
            }

            if (isLoggedIn)
            {
                Console.WriteLine("Inicio de sesión exitoso.");
            }
            else
            {
                Console.WriteLine("Usuario no encontrado. Por favor, regístrese.");
                RegisterUser(usersFile);
            }

            Console.ReadKey();
        }
        static void RegisterUser(string usersFile)
        {
            Console.WriteLine("Ingrese su nombre:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Ingrese su apellido:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Ingrese su correo electrónico:");
            string email = Console.ReadLine();
            Console.WriteLine("Ingrese su número de identificación:");
            string idNumber = Console.ReadLine();
            Console.WriteLine("Ingrese su número de teléfono:");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Ingrese su nombre de usuario:");
            string username = Console.ReadLine();

            if (IsUserRegistered(usersFile, username, email, idNumber, phoneNumber))
            {
                Console.WriteLine("Una de las credenciales que ha querido regirtrar, ya ha sido utilizada anteriormente. Por favor, intente de nuevo.");
                RegisterUser(usersFile);
                return;
            }

            Console.WriteLine("Ingrese su contraseña:");
            string password = Console.ReadLine();


            using (StreamWriter sw = File.AppendText(usersFile))
            {
                sw.WriteLine($"{username},{password},{firstName},{lastName},{email},{idNumber},{phoneNumber}");
            }

            Console.WriteLine("Registro exitoso");
        }

        static bool IsUserRegistered(string usersFile, string username, string email, string idNumber, string phoneNumber)
        {
            if (File.Exists(usersFile))
            {
                string[] users = File.ReadAllLines(usersFile);
                foreach (string user in users)
                {
                    string[] userDetails = user.Split(',');
                    if (userDetails[0] == username || userDetails[4] == email || userDetails[5] == idNumber || userDetails[6] == phoneNumber)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static void MENU()
        {
            Console.WriteLine("Opciones de seleccion de funcion disponibles: ");
            Console.WriteLine("\nBusqueda determinada por peliculas disponibles");
            Console.WriteLine("\nBusqueda determinada por sucursales disponibles");
            Console.Write("\tDetermine su metodo de busqueda (P/S): ");
            string opcion = Console.ReadLine();
            if (opcion == "P" || opcion == "p")
            {
                Peliculas();
            }
            else if (opcion == "S" || opcion == "s")
            {
                Sucursales();
            }
            else
            {
                Console.WriteLine("\nERROR *OPCION NO VALIDA*");
            }
        }
        static void Peliculas()
        {
            Console.WriteLine("\nFormatos de funciones disponibles: ");
            Console.WriteLine("\nFormato Tradicional ");
            Console.WriteLine("\nFormato 3D ");
            Console.Write("\tDetermine el formato de funcion (T/3D)");
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "T":
                    Console.WriteLine("\nPeliculas disponibles en Formato tradicional");
                    Console.WriteLine("\nPelicula [1]");
                    Console.WriteLine("\nPelicula [2]");
                    Console.WriteLine("\nPelicula [3]");
                    Console.Write("\tDetermine su eleccion de pelicula: ");
                    int option1 = int.Parse(Console.ReadLine());
                    switch (option1)
                    {
                        case 1:
                            Movie1();
                            break;
                        case 2:
                            Movie2();
                            break;
                        case 3:
                            Movie3();
                            break;
                        default:
                            Console.WriteLine("\nERROR *OPCION NO VALIDA*");
                            break;
                    }
                    break;
                case "3D":
                    Console.WriteLine("\nPeliculas disponibles en Formato 3D");
                    Console.WriteLine("\nPelicula [4]");
                    Console.WriteLine("\nPelicula [5]");
                    Console.Write("\tDetermine su eleccion de pelicula: ");
                    int option2 = int.Parse(Console.ReadLine());
                    switch (option2)
                    {
                        case 4:
                            Movie4();
                            break;
                        case 5:
                            Movie5();
                            break;
                        default:
                            Console.WriteLine("\nERROR *OPCION NO VALIDA*");
                            break;
                    }
                    break;
            }
        }
        public static void Movie1()
        {
            Console.WriteLine("\nPelicula disponible 1");
            Console.WriteLine("\nInformación disponible acerca de pelicula [1] ");
            Console.WriteLine("\nGenero de la función, Clasificacion, Formato tradicional");
            Console.WriteLine("\nValor de la función, en base a la edad del usuario:");
            Console.WriteLine("\nUsuarios de la tercera edad: $3.90; Adultos: $5.00");
            Console.WriteLine("\nSucursales con funciones disponibles: ");
            Console.WriteLine("\nSucursal [A]");
            Console.WriteLine("\nSucursal [B]");
            Console.WriteLine("\nSucursal [C]");
            Console.WriteLine("\nSucursal [D]");
            Console.WriteLine("\nSucursal [E]");
            Console.Write("\tDetermine la sucursal a la que quiere asistir");
            string opcion = Console.ReadLine();
            if (opcion == "A" || opcion == "B" || opcion == "C" || opcion == "D" || opcion == "E")
            {
                Funciones1();
            }
            else
            {
                Console.WriteLine("\nOPCION NO VALIDA");
            }
        }
        static void Movie2()
        {
            Console.WriteLine("\nPelicula disponible 2");
            Console.WriteLine("\nInformación disponible acerca de pelicula [2] ");
            Console.WriteLine("\nGenero de la función, Clasificacion, Formato tradicional");
            Console.WriteLine("\nValor de la función, en base a la edad del usuario:");
            Console.WriteLine("\nUsuarios de la tercera edad: $3.90; Adultos: $5.00");
            Console.WriteLine("\nSucursales con funciones disponibles: ");
            Console.WriteLine("\nSucursal [F]");
            Console.WriteLine("\nSucursal [G]");
            Console.WriteLine("\nSucursal [H]");
            Console.WriteLine("\nSucursal [I]");
            Console.WriteLine("\nSucursal [J]");
            Console.Write("\tDetermine la sucursal a la que quiere asistir");
            string opcion = Console.ReadLine();
            if (opcion == "F" || opcion == "G" || opcion == "H" || opcion == "I" || opcion == "J")
            {
                Funciones1();
            }
            else
            {
                Console.WriteLine("\nOPCION NO VALIDA");
            }
        }
        static void Movie3()
        {
            Console.WriteLine("\nPelicula disponible 3");
            Console.WriteLine("\nInformación disponible acerca de pelicula [3] ");
            Console.WriteLine("\nGenero de la función, Clasificacion, Formato tradicional");
            Console.WriteLine("\nValor de la función, en base a la edad del usuario:");
            Console.WriteLine("\nUsuarios de la tercera edad: $3.90; Adultos: $5.00");
            Console.WriteLine("\nSucursales con funciones disponibles: ");
            Console.WriteLine("\nSucursal [A]");
            Console.WriteLine("\nSucursal [B]");
            Console.WriteLine("\nSucursal [C]");
            Console.WriteLine("\nSucursal [D]");
            Console.WriteLine("\nSucursal [E]");
            string opcion = Console.ReadLine();
            if (opcion == "A" || opcion == "B" || opcion == "C" || opcion == "D" || opcion == "E")
            {
                Funciones2();
            }
            else
            {
                Console.WriteLine("\nOPCION NO VALIDA");
            }
        }
        static void Movie4()
        {
            Console.WriteLine("\nPelicula disponible 4");
            Console.WriteLine("\nInformación disponible acerca de pelicula [4] ");
            Console.WriteLine("\nGenero de la función, Clasificacion, Formato 3D");
            Console.WriteLine("\nValor de la función, en base a la edad del usuario:");
            Console.WriteLine("\nUsuarios de la tercera edad: $5.60; Adultos: $6.55");
            Console.WriteLine("\nSucursales con funciones disponibles: ");
            Console.WriteLine("\nSucursal [F]");
            Console.WriteLine("\nSucursal [G]");
            Console.WriteLine("\nSucursal [H]");
            Console.WriteLine("\nSucursal [I]");
            Console.WriteLine("\nSucursal [J]");
            string opcion = Console.ReadLine();
            if (opcion == "F" || opcion == "G" || opcion == "H" || opcion == "I" || opcion == "J")
            {
                Funciones2();
            }
            else
            {
                Console.WriteLine("\nOPCION NO VALIDA");
            }
        }
        static void Movie5()
        {
            Console.WriteLine("\nPelicula disponible 5");
            Console.WriteLine("\nInformación disponible acerca de pelicula [5] ");
            Console.WriteLine("\nGenero de la función, Clasificacion, Formato 3D");
            Console.WriteLine("\nValor de la función, en base a la edad del usuario:");
            Console.WriteLine("\nUsuarios de la tercera edad: $5.60; Adultos: $6.55");
            Console.WriteLine("\nSucursales con funciones disponibles: ");
            Console.WriteLine("\nSucursal [A]");
            Console.WriteLine("\nSucursal [B]");
            Console.WriteLine("\nSucursal [C]");
            string opcion = Console.ReadLine();
            if (opcion == "A" || opcion == "B" || opcion == "C")
            {
                Funciones3();
            }
            else
            {
                Console.WriteLine("\nOPCION NO VALIDA");
            }
        }
        static void Funciones1()
        {
            Console.WriteLine("\nSalas con funciones disponibles");
            Console.WriteLine("\nSala [1]");
            Console.WriteLine("\nSala [2]");
            Console.Write("\tDetermine el numero de sala: ");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Horario();
                    break;
                case 2:
                    Horario();
                    break;
                default:
                    Console.WriteLine("\nERROR *OPCION NO VALIDA*");
                    break;
            }
        }
        static void Funciones2()
        {
            Console.WriteLine("\nSalas con funciones disponibles");
            Console.WriteLine("\nSala [3]");
            Console.WriteLine("\nSala [4]");
            Console.Write("\tDetermine el numero de sala: ");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 3:
                    Horario();
                    break;
                case 4:
                    Horario();
                    break;
                default:
                    Console.WriteLine("\nERROR *OPCION NO VALIDA*");
                    break;
            }
        }
        static void Funciones3()
        {
            Console.WriteLine("\nSalas con funciones disponibles");
            Console.WriteLine("\nSala [5]");
            Console.WriteLine("\nSala [6]");
            Console.Write("\tDetermine el numero de sala: ");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 5:
                    Horario();
                    break;
                case 6:
                    Horario();
                    break;
                default:
                    Console.WriteLine("\nERROR *OPCION NO VALIDA*");
                    break;
            }
        }
        static void Horario()
        {
            Console.WriteLine("\nHorarios disponibles");
            Console.WriteLine("\nHorario [1]");
            Console.WriteLine("\nHorario [2]");
            Console.Write("\tDetermine el horario a asistir: ");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Butacas();
                    break;
                case 2:
                    Butacas();
                    break;
                default:
                    Console.WriteLine("\nERROR *OPCION NO DISPONIBLE*");
                    break;
            }
        }
        static void Sucursales()
        {
            Console.WriteLine("\nSucursales disponibles");
            Console.WriteLine("\nSucursal [A]");
            Console.WriteLine("\nSucursal [B]");
            Console.WriteLine("\nSucursal [C]");
            Console.WriteLine("\nSucursal [D]");
            Console.WriteLine("\nSucursal [E]");
            Console.WriteLine("\nSucursal [F]");
            Console.WriteLine("\nSucursal [G]");
            Console.WriteLine("\nSucursal [H]");
            Console.WriteLine("\nSucursal [I]");
            Console.WriteLine("\nSucursal [J]");
            Console.Write("\tDetermine sucursal de su eleccion: ");
            string opcion = Console.ReadLine();
            Console.WriteLine("\nSucursal [" + opcion + "]");
            if (opcion == "A" || opcion == "B" || opcion == "C")
            {
                cineABC();
            }
            else if (opcion == "D" || opcion == "E")
            {
                cineDE();
            }
            else if (opcion == "F" || opcion == "G" || opcion == "H" || opcion == "I" || opcion == "J")
            {
                cineFGHIJ();
            }
            else
            {
                Console.WriteLine("\nERROR *OPCION NO VALIDA*");
            }
        }
        static void cineABC()
        {
            Console.WriteLine("\nInformacion pertinente : ");
            Console.WriteLine("\nNombre del gerente, Dirección de la sucursal, Numero de telefono");
            Console.WriteLine("\nPeliculas disponibles: ");
            Console.WriteLine("\nPelicula [1]");
            Console.WriteLine("\nPelicula [3]");
            Console.WriteLine("\nPelicula [5]");
            Console.Write("\tDetermine su seleccion: ");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("\nPelicula disponible 1");
                    Console.WriteLine("\nInformación disponible acerca de pelicula [1] ");
                    Console.WriteLine("\nGenero de la función, Clasificacion, Formato tradicional");
                    Console.WriteLine("\nValor de la función, en base a la edad del usuario:");
                    Console.WriteLine("\nUsuarios de la tercera edad: $3.90; Adultos: $5.00");
                    Funciones1();
                    break;
                case 3:
                    Console.WriteLine("\nPelicula disponible 3");
                    Console.WriteLine("\nInformación disponible acerca de pelicula [3] ");
                    Console.WriteLine("\nGenero de la función, Clasificacion, Formato tradicional");
                    Console.WriteLine("\nValor de la función, en base a la edad del usuario:");
                    Console.WriteLine("\nUsuarios de la tercera edad: $3.90; Adultos: $5.00");
                    Funciones2();
                    break;
                case 5:
                    Console.WriteLine("\nPelicula disponible 5");
                    Console.WriteLine("\nInformación disponible acerca de pelicula [5] ");
                    Console.WriteLine("\nGenero de la función, Clasificacion, Formato 3D");
                    Console.WriteLine("\nValor de la función, en base a la edad del usuario:");
                    Console.WriteLine("\nUsuarios de la tercera edad: $5.60; Adultos: $6.55");
                    Funciones3();
                    break;
                default:
                    Console.WriteLine("\nERROR *OPCION NO VALIDA*");
                    break;
            }
        }
        static void cineDE()
        {
            Console.WriteLine("\nInformacion pertinente : ");
            Console.WriteLine("\nNombre del gerente, Dirección de la sucursal, Numero de telefono");
            Console.WriteLine("\nPeliculas disponibles: ");
            Console.WriteLine("\nPelicula [1]");
            Console.WriteLine("\nPelicula [3]");
            Console.Write("\tDetermine su seleccion: ");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("\nPelicula disponible 1");
                    Console.WriteLine("\nInformación disponible acerca de pelicula [1] ");
                    Console.WriteLine("\nGenero de la función, Clasificacion, Formato tradicional");
                    Console.WriteLine("\nValor de la función, en base a la edad del usuario:");
                    Console.WriteLine("\nUsuarios de la tercera edad: $3.90; Adultos: $5.00");
                    Funciones1();
                    break;
                case 3:
                    Console.WriteLine("\nPelicula disponible 3");
                    Console.WriteLine("\nInformación disponible acerca de pelicula [3] ");
                    Console.WriteLine("\nGenero de la función, Clasificacion, Formato tradicional");
                    Console.WriteLine("\nValor de la función, en base a la edad del usuario:");
                    Console.WriteLine("\nUsuarios de la tercera edad: $3.90; Adultos: $5.00");
                    Funciones2();
                    break;
                default:
                    Console.WriteLine("\nERROR *OPCION NO VALIDA*");
                    break;
            }
        }
        static void cineFGHIJ()
        {
            Console.WriteLine("\nInformacion pertinente : ");
            Console.WriteLine("\nNombre del gerente, Dirección de la sucursal, Numero de telefono");
            Console.WriteLine("\nPeliculas disponibles: ");
            Console.WriteLine("\nPelicula [2]");
            Console.WriteLine("\nPelicula [4]");
            Console.Write("\tDetermine su seleccion: ");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 2:
                    Console.WriteLine("\nPelicula disponible 2");
                    Console.WriteLine("\nInformación disponible acerca de pelicula [2] ");
                    Console.WriteLine("\nGenero de la función, Clasificacion, Formato tradicional");
                    Console.WriteLine("\nValor de la función, en base a la edad del usuario:");
                    Console.WriteLine("\nUsuarios de la tercera edad: $3.90; Adultos: $5.00");
                    Funciones1();
                    break;
                case 4:
                    Console.WriteLine("\nPelicula disponible 4");
                    Console.WriteLine("\nInformación disponible acerca de pelicula [4] ");
                    Console.WriteLine("\nGenero de la función, Clasificacion, Formato 3D");
                    Console.WriteLine("\nValor de la función, en base a la edad del usuario:");
                    Console.WriteLine("\nUsuarios de la tercera edad: $5.60; Adultos: $6.55");
                    Funciones2();
                    break;
                default:
                    Console.WriteLine("\nERROR *OPCION NO VALIDA*");
                    break;
            }
        }
        static void Butacas()
        {
            MostrarButacas();

            int numButacas = 0;
            while (true)
            {
                Console.Write("Elija una fila (1-8): ");
                int fila = int.Parse(Console.ReadLine()) - 1;

                Console.Write("Elija una columna (1-5): ");
                int columna = int.Parse(Console.ReadLine()) - 1;

                if (ElegirButaca(fila, columna))
                {
                    Console.WriteLine($"Butaca {fila + 1}-{columna + 1} elegida con éxito.");
                    MostrarButacas();

                    numButacas++;
                    Console.Write("¿Desea comprar otra butaca? (S/N): ");
                    string respuesta = Console.ReadLine();
                    if (respuesta.ToLower() == "n")
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("La butaca ya está ocupada. Elija otra.");
                }
            }

            double total = numButacas * precioButaca;
            Console.WriteLine($"Total a pagar: ${total}");
            Console.Write("Ingrese el monto con el que pagará: $");
            double pago = double.Parse(Console.ReadLine());

            while (pago < total)
            {
                Console.WriteLine("El monto ingresado es insuficiente. Intente de nuevo.");
                Console.Write("Ingrese el monto con el que pagará: $");
                pago = double.Parse(Console.ReadLine());
            }

            double cambio = pago - total;
            Console.WriteLine($"Cambio a entregar: ${cambio}");
            Console.WriteLine("Registro de ventas:");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (butacas[i, j])
                    {
                        double precio = precioButaca;
                        Console.WriteLine($"Butaca {i + 1}-{j + 1} vendida por ${precio}");
                    }
                }
            }
        }
        static bool ElegirButaca(int fila, int columna)
        {
            if (butacas[fila, columna] == false)
            {
                butacas[fila, columna] = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        static void MostrarButacas()
        {
            Console.WriteLine("Estado de las butacas:");
            Console.Write(" ");
            for (int j = 0; j < 5; j++)
            {
                Console.Write($" {j + 1}");
            }
            Console.WriteLine();
            for (int i = 0; i < 8; i++)
            {
                Console.Write($"{i + 1}");
                for (int j = 0; j < 5; j++)
                {
                    if (butacas[i, j])
                    {
                        Console.Write("[X]");
                    }
                    else
                    {
                        Console.Write("[ ]");
                    }
                }
                Console.WriteLine();
            }
        }
        static void Recibo()
        {
            const double precio_tradicional_adulto = 5.00;
            const double precio_tradicional_tercera_edad = 3.90;
            const double precio_3D_adulto = 6.55;
            const double precio_3D_tercera_edad = 5.60;
            string[] sucursales = {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"
        };
            bool[] esFormato3D = { true, true, true, false, false, false, false, false, false, false };

            int[] salas = { 6, 6, 6, 4, 4, 4, 4, 4, 4, 4 };
            recibo r = new recibo();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Ingrese el nombre de la sucursal (A, B, C, D, E, F, G, H, I, J): ");
            r.nombreSucursal = Console.ReadLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Ingrese el número de sala de cine (1, 2, 3, 4, 5, 6): ");
            r.sala = int.Parse(Console.ReadLine() ?? "");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Ingrese el formato de la película (Tradicional o 3D): ");
            r.Formato = Console.ReadLine() ?? "";
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Ingrese la edad del asistente (Adulto o Tercera edad): ");
            r.edad = Console.ReadLine() ?? "";
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Ingrese la cantidad de entradas compradas: ");
            r.cantidadEntradas = int.Parse(Console.ReadLine() ?? "");
            Console.ResetColor();

            double precio = 0.0;
            r.indiceSucursal = Array.IndexOf(sucursales, r.nombreSucursal.ToUpper());
            bool esFormato3DSucursal = esFormato3D[r.indiceSucursal];

            if (r.Formato.ToLower() == "tradicional")
            {
                if (r.edad.ToLower() == "adulto")
                {
                    precio = precio_tradicional_adulto;
                }
                else
                {
                    precio = precio_tradicional_tercera_edad;
                }
            }
            else
            {
                if (r.edad.ToLower() == "adulto")
                {
                    precio = precio_3D_adulto;
                }
                else
                {
                    precio = precio_3D_tercera_edad;
                }

                if (!esFormato3DSucursal)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("La sucursal seleccionada no cuenta con formato 3D. El precio de la función será el correspondiente al formato tradicional.");
                    Console.ResetColor();

                    precio = precio_tradicional_adulto;
                }
            }

            double precioTotal = precio * r.cantidadEntradas;

            // Generar reporte
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nSucursal: {r.nombreSucursal}");
            Console.WriteLine($"Sala de cine: {r.sala}");
            Console.WriteLine($"Formato: {r.Formato}");
            Console.WriteLine($"Edad: {r.edad}");
            Console.WriteLine($"Cantidad de entradas: {r.cantidadEntradas}");
            Console.WriteLine($"Precio de la función: ${precio:F2}");
            Console.WriteLine($"Precio total: ${precioTotal:F2}");
            Console.ResetColor();
        }
        static void informe()
        {
            // Información de la cartelera
            string[] peliculas = {
            "Pelicula 1",
            "Pelicula 2",
            "Pelicula 3",
            "Pelicula 4",
            "Pelicula 5",
        };

            string[] sucursales = {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"
        };

            bool[] esFormato3D = { true, true, true, false, false, false, false, false, false, false };

            int[] salas = { 6, 6, 6, 4, 4, 4, 4, 4, 4, 4 };

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---- Bienvenido a PrimeCinema ----\n");

            Console.WriteLine("Películas en cartelera:\n");

            for (int i = 0; i < peliculas.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {peliculas[i]}");
            }

            Console.WriteLine();

            Console.WriteLine("Seleccione la sucursal que desea consultar:\n");

            for (int i = 0; i < sucursales.Length; i++)
            {
                Console.WriteLine($"{i + 1}. Sucursal {sucursales[i]}");
            }

            Console.WriteLine();

            Console.Write("Opción: ");
            int opcionSucursal = int.Parse(Console.ReadLine() ?? "");

            string nombreSucursal = sucursales[opcionSucursal - 1];
            int indiceSucursal = Array.IndexOf(sucursales, nombreSucursal.ToUpper());
            bool esFormato3DSucursal = esFormato3D[indiceSucursal];
            int numSalas = salas[indiceSucursal];

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nPelículas en cartelera en Sucursal {nombreSucursal}:\n");

            for (int i = 0; i < peliculas.Length; i++)
            {
                Console.WriteLine(peliculas[i]);
            }

            Console.WriteLine();

            Console.WriteLine($"La sucursal {nombreSucursal} cuenta con {numSalas} salas de cine.");

            if (esFormato3DSucursal)
            {
                Console.WriteLine("La sucursal cuenta con formato 3D.");
            }
            else
            {
                Console.WriteLine("La sucursal no cuenta con formato 3D.");
            }

            Console.ResetColor();
        }
    }
}
