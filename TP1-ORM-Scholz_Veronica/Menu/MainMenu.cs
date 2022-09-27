using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_ORM_Scholz_Veronica.Menu
{
    public class MainMenu
    {
        public bool exit { get; set; }
        public int opt { get; set; }
        public void TextMenu()
        {
            Console.Clear();
            Console.WriteLine("MENU DE OPCIONES");
            Console.WriteLine("1. Opción 1");
            Console.WriteLine("1. Opción 1");
            Console.WriteLine("1. Opción 1");
            Console.WriteLine("4. Salir");
            Console.Write("Ingrese un numero del 1 al 4: ");
        }
        public void InsertOption()
        {
            try
            {
                this.opt = int.Parse(Console.ReadLine()); 
            }
            catch (FormatException e)
            {
                Console.Write("Ha ingresado letras, por favor ingrese un numero entre 1 y 4");
                Console.ReadKey(true);
            }
            catch (OverflowException e)
            {
                Console.Write("Ha ingresado un valor muy grande, por favor ingrese un numero entre 1 y 4");
                Console.ReadKey(true);
            }
            catch (Exception e)
            {
                Console.Write("Ha ingresado una opcion erronea, por favor ingrese un numero entre 1 y 4");
                Console.ReadKey(true);
            }
        }
        public void SelectOption(int opt)
        {
           this.exit = false;
           switch (opt)
            {
                case 1:
                    Console.WriteLine("Ingreso la opción 1");
                    Console.WriteLine("--------------------");
                    return;
                case 2:
                    Console.WriteLine("Ingreso la opción 2");
                    Console.WriteLine("--------------------");
                    return;
                case 3:
                    Console.WriteLine("Ingreso la opción 3");
                    Console.WriteLine("--------------------");
                    return;
                case 4:
                    Console.WriteLine("4. Gracias por utilizar el servicio.");
                    Console.WriteLine("---------------------------------");
                    this.exit = true;
                    return;
                default:
                    Console.WriteLine("Ha ingresado un numero no valido. Ingrese un valor entre 1 y 4.");
                    return;
            }
        }
    }
}
