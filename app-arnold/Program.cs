using System;
using System.Diagnostics;
using System.IO;
namespace app_arnold
{
    class Program
    {
        private static string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private static string rutaSalida = Path.Combine(rutaEscritorio, "documentación");
        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 40);
            Console.WriteLine("Verificando si existe la ruta de salida…");
            if (!Directory.Exists(rutaSalida))
            {
                Directory.CreateDirectory(rutaSalida);
                Console.WriteLine("Creando la ruta de salida…");
            }
            Console.WriteLine($"La ruta de salida es: {rutaSalida}");
            Esperar();
            Borrar();

            while (true)
            {
                Menu();
                string opcion = Console.ReadLine();
                int parseInt;
                if (int.TryParse(opcion, out parseInt))
                {
                    switch (parseInt)
                    {
                        case 1:
                            ObtenerBIOS();
                            break;
                        case 2:
                            ObtenerCPU();
                            break;
                        case 3:
                            ObtenerRedes();
                            break;
                        case 4:
                            ObtenerSystem();
                            break;
                        case 5:
                            ObtenerCSPRODUCT();
                            break;
                        case 6:
                            ObtenerRAM();
                            break;
                        case 7:
                            EjecutarUsuario();
                            break;
                        case 8:
                            EjecutarControl();
                            break;
                        case 9:
                            EjecutarMsConfig();
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("La opción debe ser del 1 al 9 o 0 para salir…");
                    Esperar();
                }
                Borrar();
            }

        }
        private static void Menu()
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            string hora = DateTime.Now.ToString("HH:mm tt");
            Console.WriteLine("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█");
            Console.WriteLine("█						SOPORTE Y REDES                                   █");
            Console.WriteLine("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█  ECJECUCIÓN:");
            Console.WriteLine($"█ ████     ████ ██████████ ████      ██ ██        ██            █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█          █  FECHA - {fecha}              ");
            Console.WriteLine($"█ ██ ██   ██ ██ ██         ██ ██     ██ ██        ██            █   1.) BIOS           █          █  HORA  - {hora}              ");
            Console.WriteLine("█ ██  ██ ██  ██ ██         ██  ██    ██ ██        ██            █▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█          █");
            Console.WriteLine("█ ██   ███   ██ ██████     ██   ██   ██ ██        ██            █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█          █  DIRECCION ID:SOPORTE Y REDES");
            Console.WriteLine("█ ██         ██ ██         ██   ███  ██ ██        ██            █   2.) CPU            █          █      .......");
            Console.WriteLine("█ ██         ██ ██         ██     ██ ██ ██        ██            █▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█          █  .:::::::::::::.");
            Console.WriteLine("█ ██         ██ ██         ██      ████ ██        ██            █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█          █ .::'  '''''  '::.");
            Console.WriteLine("█ ██         ██ ██████████ ██       ███ ████████████            █   3.) REDES          █          █ :::           :::");
            Console.WriteLine("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄          █▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█          █ :::           :::");
            Console.WriteLine("                                                     █          █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█          █ ::'           '::");
            Console.WriteLine("   HOLA JERBOS ███████████████████████████           █          █   4.) SYSTEM         █          █: : /~~~' '~~~\\ : :");
            Console.WriteLine("                                                     █          █▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█          █:(:^<o^>^|^<o^> :):");
            Console.WriteLine("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█          █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█          █ .:     / \\     :.'");
            Console.WriteLine("█                                                    █          █   5.) CSPRODUCT      █          █ ':    (. .)    :'");
            Console.WriteLine("█                                                    █          █▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█          █ '.   .:::::.  .'");
            Console.WriteLine("█        INDIQUE SU OPCION [1-9]                     █          █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█          █  :  ^<-----^> :");
            Console.WriteLine("█                                                    █          █   6.) RAM            █          █  '.   ~:::~  .'");
            Console.WriteLine("█                  [ 0.) SALIR ]                     █          █▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█          █    '........'");
            Console.WriteLine("█                                                    █          █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█          █       ");
            Console.WriteLine("█                                                    █          █   7.) NETPLWIZ       █          █");
            Console.WriteLine("█                                                    █          █▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█          █");
            Console.WriteLine("█                                                    █          █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█          █");
            Console.WriteLine("█      Diseñado por Arnold Layseca                   █          █   8.) SISTEMA        █          █");
            Console.WriteLine("█      Desarrollado por @DonTulio                    █          █▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█          █");
            Console.WriteLine("█                                                    █          █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█          █");
            Console.WriteLine("█                                                    █          █   9.) MSCONFIG       █          █");
            Console.WriteLine("█                                                    █          █▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█          █");
            Console.WriteLine("█                                                    █                                            █");
            Console.WriteLine("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█");
            Console.WriteLine("Escriba la opción y pulsa ENTER: ");
        }
        private static void ObtenerBIOS()
        {
            Console.WriteLine("Obteniendo información de la BIOS…");
            string rutaBios = Path.Combine(rutaSalida, "BIOS.txt");
            Process procesoBios = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "wmic",
                    Arguments = "BIOS get /all /format:LIST",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            procesoBios.Start();
            if (File.Exists(rutaBios))
            {
                File.Delete(rutaBios);
            }
            using (StreamWriter sw = File.CreateText(rutaBios))
            {
                sw.WriteLine("Información de la BIOS");
                while (!procesoBios.StandardOutput.EndOfStream)
                {
                    string salidaTemp = procesoBios.StandardOutput.ReadLine().Trim();
                    if (salidaTemp.Length > 0)
                    {
                        Console.WriteLine(salidaTemp);
                        sw.Write($"{salidaTemp}\n");
                    }
                }
            }
            Console.WriteLine($"Se guardo esta salida en: {rutaBios}");
            Esperar();
        }

        private static void ObtenerCPU()
        {
            Console.WriteLine("Obteniendo información de la CPU…");
            string rutaCPU = Path.Combine(rutaSalida, "CPU.txt");
            Process procesoBios = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "wmic",
                    Arguments = "CPU get /all /format:LIST",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            procesoBios.Start();
            if (File.Exists(rutaCPU))
            {
                File.Delete(rutaCPU);
            }
            using (StreamWriter sw = File.CreateText(rutaCPU))
            {
                sw.WriteLine("Información de la CPU");
                while (!procesoBios.StandardOutput.EndOfStream)
                {
                    string salidaTemp = procesoBios.StandardOutput.ReadLine().Trim();
                    if (salidaTemp.Length > 0)
                    {
                        Console.WriteLine(salidaTemp);
                        sw.Write($"{salidaTemp}\n");
                    }
                }
            }
            Console.WriteLine($"Se guardo esta salida en: {rutaCPU}");
            Esperar();
        }
        private static void ObtenerRedes()
        {
            Console.WriteLine("Obteniendo información de la RED…");
            string rutaRED = Path.Combine(rutaSalida, "REDES.txt");
            Process procesoBios = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "wmic",
                    Arguments = "NICCONFIG get /all /format:LIST",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            procesoBios.Start();
            if (File.Exists(rutaRED))
            {
                File.Delete(rutaRED);
            }
            using (StreamWriter sw = File.CreateText(rutaRED))
            {
                sw.WriteLine("Información de la RED");
                while (!procesoBios.StandardOutput.EndOfStream)
                {
                    string salidaTemp = procesoBios.StandardOutput.ReadLine().Trim();
                    if (salidaTemp.Length > 0)
                    {
                        Console.WriteLine(salidaTemp);
                        sw.Write($"{salidaTemp}\n");
                    }
                }
            }
            Console.WriteLine($"Se guardo esta salida en: {rutaRED}");
            Esperar();
        }
        private static void ObtenerSystem()
        {
            Console.WriteLine("Obteniendo información del Sistema…");
            string rutaSystem = Path.Combine(rutaSalida, "SYSTEM.txt");
            Process procesoBios = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "wmic",
                    Arguments = "COMPUTERSYSTEM get /all /format:LIST",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            procesoBios.Start();
            if (File.Exists(rutaSystem))
            {
                File.Delete(rutaSystem);
            }
            using (StreamWriter sw = File.CreateText(rutaSystem))
            {
                sw.WriteLine("Información del Sistema");
                while (!procesoBios.StandardOutput.EndOfStream)
                {
                    string salidaTemp = procesoBios.StandardOutput.ReadLine().Trim();
                    if (salidaTemp.Length > 0)
                    {
                        Console.WriteLine(salidaTemp);
                        sw.Write($"{salidaTemp}\n");
                    }
                }
            }
            Console.WriteLine($"Se guardo esta salida en: {rutaSystem}");
            Esperar();
        }
        private static void ObtenerCSPRODUCT()
        {
            Console.WriteLine("Obteniendo información del PRODUCTO…");
            string rutaProducto = Path.Combine(rutaSalida, "PRODUCTO.txt");
            Process procesoBios = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "wmic",
                    Arguments = "csproduct get /all /format:LIST",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            procesoBios.Start();
            if (File.Exists(rutaProducto))
            {
                File.Delete(rutaProducto);
            }
            using (StreamWriter sw = File.CreateText(rutaProducto))
            {
                sw.WriteLine("Información del Producto");
                while (!procesoBios.StandardOutput.EndOfStream)
                {
                    string salidaTemp = procesoBios.StandardOutput.ReadLine().Trim();
                    if (salidaTemp.Length > 0)
                    {
                        Console.WriteLine(salidaTemp);
                        sw.Write($"{salidaTemp}\n");
                    }
                }
            }
            Console.WriteLine($"Se guardo esta salida en: {rutaProducto}");
            Esperar();
        }
        private static void ObtenerRAM()
        {
            Console.WriteLine("Obteniendo información de la RAM…");
            string rutaRam = Path.Combine(rutaSalida, "RAM.txt");
            Process procesoBios = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "wmic",
                    Arguments = "MemoryChip get BankLabel, Capacity, MemoryType, TypeDetail, Speed, Manufacturer",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            procesoBios.Start();
            if (File.Exists(rutaRam))
            {
                File.Delete(rutaRam);
            }
            using (StreamWriter sw = File.CreateText(rutaRam))
            {
                sw.WriteLine("Información de la RAM");
                while (!procesoBios.StandardOutput.EndOfStream)
                {
                    string salidaTemp = procesoBios.StandardOutput.ReadLine().Trim();
                    if (salidaTemp.Length > 0)
                    {
                        Console.WriteLine(salidaTemp);
                        sw.Write($"{salidaTemp}\n");
                    }
                }
            }
            Console.WriteLine($"Se guardo esta salida en: {rutaRam}");
            Esperar();
        }

        private static void EjecutarUsuario()
        {
            Console.WriteLine("Ejecutando Usuarios...");
            Process procesoUsuario = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = "netplwiz.exe",
                    WorkingDirectory = Environment.SystemDirectory
                }
            };
            procesoUsuario.Start();
            Esperar();
        }
        private static void EjecutarControl()
        {
            Console.WriteLine("Ejecutando Control de Sistema...");
            Process procesoSistema = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = "control.exe",
                    Arguments = "system",
                    WorkingDirectory = Environment.SystemDirectory
                }
            };
            procesoSistema.Start();
            Esperar();
        }

        private static void EjecutarMsConfig()
        {
            Console.WriteLine("Ejecutando MSCONFIG.exe...");
            Process procesoMsConfig = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = "msconfig.exe",
                    WorkingDirectory = Environment.SystemDirectory
                }
            };
            procesoMsConfig.Start();
            Esperar();
        }
        private static void Esperar()
        {
            Console.WriteLine("Presione una tecla para continuar…");
            Console.ReadKey();
        }
        private static void Borrar()
        {
            Console.Clear();
        }
    }
}

