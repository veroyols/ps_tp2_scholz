// See https://aka.ms/new-console-template for more information
using Infrastructure.Persistence;
using TP1_ORM_Scholz_Veronica.Menu;

Console.WriteLine("Hello, World!");

MainMenu mainMenu = new MainMenu(); 
do
{
    mainMenu.TextMenu();
    mainMenu.InsertOption();
    mainMenu.SelectOption(mainMenu.opt);
}
while (!mainMenu.exit);



Console.Write("Press any key to continue . . . ");
Console.ReadKey(true);

////MENU1
//static bool Menu1()
//{
//    Console.Clear();
//    Console.WriteLine("MENU1");
//    Console.WriteLine("1. Opción 1");
//    Console.WriteLine("2. Opción 2");
//    Console.WriteLine("7) Volver al menu anterior");
//    Console.Write("\r\nSeleccione una opción: ");

//    switch (Console.ReadLine())
//    {
//        case "1":
//            Console.WriteLine("Ha elegido 1");
//            Console.WriteLine("Presione una tecla para volver al menu...");
//            Console.ReadKey(true);
//            return true;
//        case "2":
//            Console.WriteLine("Ha elegido 2");
//            Console.WriteLine("Presione una tecla para volver al menu...");
//            Console.ReadKey(true);
//            return true;
//        case "7":
//            Console.Clear();
//            return false;
//        default:
//            return true;
//    }
//}
////ConectionString
////var conectionString = builder.Configuration["ConectionString"];
////builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conectionString));
////"ConectionString": "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;",
//  //"ConectionString": "Server=localhost\\SQLEXPRESS,1433;Database=master;User Id=sa;Password=1234;",


