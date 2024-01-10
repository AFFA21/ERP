using System;
using System.IO;
using System.Collections.Generic;

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
    ║                                Clients                                 ║
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
    string l4 = "                             Clients                              ";
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

        // Effacer le fond décoré de l'option actuelle
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
    // Case 1 renvoie au contnue de l4...
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

//CLIENT
if (OptionMainMenuSelected ==1)
{
    string dded(string modif)
    {
        
        string {(modif)};
    }

    string CsvFile = @"D:\PHP\ERP\doc\us-500(1).csv";
    var delimiters = new string[] { "\",\"", "\",", ",\""  };
    
    foreach (string line in File.ReadAllLines(CsvFile))
    {
        var colunns = line.Split(delimiters, StringSplitOptions.None);
        

    }
    
}
