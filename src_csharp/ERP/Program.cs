
using System.IO;
using System.Collections.Generic;
using MySqlConnector;
using System.Security.Cryptography;
using System.Text;

Console.CursorVisible = false;



int OptionMainMenuSelected = 1;

MainMenu();




void MainMenu()
{
    //ALL confings
    int initialposX =0;
    int initialposY =0;
    int posmin = 12;
    var FondVert = "\u001b[42m";
    ConsoleKeyInfo fléches;
    bool selection = false;




    //TITLE
    string[] lignes = new string[]
    {
    "  88888888b  888888ba   888888ba   ",
    "88         88    `8b  88    `8b ",
    "  a88aaaa    a88aaaa8P' a88aaa8P   ",     
    "  88         88   `8b.  88         ",
    " 88         88     88  88        ",
    "88888888P  dP     dP  dP        ",
    "┌─────────────────────────────────┐",
    "┌───────────────────────────┐"
    };
    for (int i = 0; i < lignes.Length; i++)
    {
        Console.SetCursorPosition((Console.WindowWidth - lignes[i].Length) / 2, Console.WindowHeight / 2 +i -4);
        Console.WriteLine(lignes[i]);
    }

    //ENTRER
    bool stop = true;
    void boucle01()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo commencer = Console.ReadKey(true);
            if (commencer.Key == ConsoleKey.Enter)
            {
                stop = false;
            }
        }
    }
    while (stop)
    {

        Console.CursorLeft = 44;
        Console.CursorTop = 23;
        Console.Write("APPUYEZ SUR <ENTER> POUR ENTRER");
        boucle01();
        Thread.Sleep(350);
        boucle01();
        Thread.Sleep(350);
        boucle01();
        Console.ForegroundColor = ConsoleColor.Black;
        Console.CursorLeft = 44;
        Console.CursorTop = 23;
        Console.Write("APPUYEZ SUR <ENTER> POUR ENTRER");
        Thread.Sleep(300);
        Console.ForegroundColor = ConsoleColor.White;
        boucle01();
    }
    Console.Clear();
    Console.ResetColor();





    string Menu = (@"
    ╔════════════════════════════════════════════════════════════════════════╗
    ║ ┌────────────────────────────────────────────────────────────────────┐ ║ 
    ║                                                                        ║
    ║                                clients                                 ║
    ║                                                                        ║
    ║                               Produits                                 ║
    ║                                                                        ║
    ║                               Commandes                                ║
    ║                                                                        ║
    ║                                Quitter                                 ║
    ║                                                                        ║
    ║ └────────────────────────────────────────────────────────────────────┘ ║
    ╚════════════════════════════════════════════════════════════════════════╝
    ");
    string[] SlitMenu = Menu.Split("\n");

    //isoler les lignes sans les symboles ne debut et fin
    string l4 = "                             clients                              ";
    string l6 = "                            Produits                              ";
    string l8 = "                            Commandes                             ";
    string l10 = "                             Quitter                                ";

    //écrire le tableau en entier
    for (int i = 0; i < SlitMenu.Length; i++)
    {
        Console.SetCursorPosition((Console.WindowWidth - SlitMenu[i].Length) / 2, Console.WindowHeight / 2 - 7 + i);
        if (i == 4) { initialposX = Console.CursorLeft +7; initialposY = Console.CursorTop +7 ; }
        Console.WriteLine($"\x1b[38;5;230m{SlitMenu[i]}");        
    }

    Console.SetCursorPosition(initialposX , initialposY);

    selection = false;
    while (!selection)
    {
        Console.SetCursorPosition(initialposX, posmin + (OptionMainMenuSelected - 1) * 2);
        Console.WriteLine($"{FondVert} \x1b[38;5;230m{LignesOptions(OptionMainMenuSelected)} \u001b[0m");

        fléches = Console.ReadKey(true);

        //Effacer le fond décoré de l'option actuelle
        Console.SetCursorPosition(initialposX, posmin + (OptionMainMenuSelected - 1) * 2);
        Console.WriteLine($" \x1b[38;5;230m{LignesOptions(OptionMainMenuSelected)} ");

        //Fléche haut - féche bas + et Enter suivant
        switch (fléches.Key)
        {
            case ConsoleKey.UpArrow:
                OptionMainMenuSelected = OptionMainMenuSelected == 1 ? 4 : OptionMainMenuSelected - 1;
                break;

            case ConsoleKey.DownArrow:
                OptionMainMenuSelected = OptionMainMenuSelected == 4 ? 1 : OptionMainMenuSelected + 1;
                break;

            case ConsoleKey.Enter:
                selection = true;
                Console.Clear();
                break;
        }
    }
    //Attribuer un nombre pour chaque lignes d'option pour ensuit pouvoir associer le nombre avec OPTION
    //Case 1 renvoie au contnue de l4...
    string LignesOptions(int option)
    {
        switch (option)
        {
            case 1:
                return l4;
            case 2:
                return l6;
            case 3:
                return l8;
            case 4:
                return l10;
            default:
                return "";
        }
    }
}

//clients
if (OptionMainMenuSelected == 1)
{

    string creatTableDB = @"CREATE TABLE IF NOT EXISTS clients
    (
        idClient INT PRIMARY KEY AUTO_INCREMENT,
        CliUsername VARCHAR(103) NULL,
        CliPassword VARCHAR(200) NULL,
        CliFirstName VARCHAR(255) NULL,
        CliLastName VARCHAR(255) NULL,
        CliCompanyName VARCHAR(255) NULL,
        CliAddress VARCHAR(255) NULL,
        CliCity VARCHAR(255) NULL,
        CliLocality VARCHAR(255) NULL,
        CliCountry VARCHAR(255) NULL,
        CliZip VARCHAR(20) NULL,
        CliPhoneFirst VARCHAR(20) NULL,
        CliPhoneSecond VARCHAR(20) NULL,
        CliEmail VARCHAR(255) NULL,
        CliWeb VARCHAR(255) NULL
    )";

    SQLCommand(creatTableDB);

    listenCsv();
}

#region Client
void listenCsv ()
{
    var username = "";
    var password = "";
    var first_name = "";
    var last_name = "";
    var compagny_name = "";
    var address = "";
    var city = "";
    var Locality = "";
    var Country = "";
    var zip = "";
    var phone_1 = "";
    var phone_2 = "";
    var email = "";
    var web = "";

    string CsvFile = @"D:\ERP\doc\Clients-Clean-Id(2).csv";

    foreach (string line in File.ReadAllLines(CsvFile))
    {
        string UploadTableSql = $@"
            INSERT INTO clients (CliUsername, CliPassword, CliFirstName, CliLastName, CliCompanyName, CliAddress, CliCity, CliLocality, CliCountry, CliZip, CliPhoneFirst, CliPhoneSecond, CliEmail, CliWeb)
            VALUES ('{username}', '{password}', '{first_name}', '{last_name}', '{compagny_name}', '{address}', '{city}', '{Locality}', '{Country}', '{zip}', '{phone_1}', '{phone_2}', '{email}', '{web}');
        ";

        var colunns = line.Split(";");

        first_name = colunns[1];
        last_name = colunns[2];

        username = (first_name.Length >= 3) ? first_name.Substring(0, 3) + last_name : first_name + last_name;
        password = sha256(random());
        
        compagny_name = colunns[3];
        address = colunns[4];
        city = colunns[5];
        Locality = colunns[6];
        Country = colunns[7];
        zip = colunns[8];
        phone_1 = colunns[9];
        phone_2 = colunns[10];
        email = colunns[11];
        web = colunns[12];
        
        SQLCommand(UploadTableSql);
    }
}

static string sha256(string input)
{
    using (var hashGenerator = SHA256.Create())
    {
        var hash = hashGenerator.ComputeHash(Encoding.Default.GetBytes(input));
        return BitConverter.ToString(hash);
    }
}
string random()
{
    string generatedChar = "";
    Random random = new Random();
    for (int i = 0; i < 12; i++)
    {
        char Char = Convert.ToChar(random.Next(1, 127));
        generatedChar = generatedChar + Char;
    }
    return generatedChar;
}

void SQLCommand(string commandSql)
{
    using (MySqlConnection connection = new MySqlConnection("server=localhost;userid=root;password=root;database=db_clients_erp;port=6033"))
    {
        connection.Open();

        using (var command = connection.CreateCommand())
        {
            command.CommandText = commandSql;
            command.ExecuteNonQuery();
        }
    }    
}
#endregion