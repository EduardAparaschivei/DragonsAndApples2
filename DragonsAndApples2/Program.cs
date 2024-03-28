using Entities;
using DataStorageLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsAndApples2
{
    class Program
    {
        static void Main()
        {

            ItemsDataStorage_Memory adminItems = new ItemsDataStorage_Memory();
            DragonsDataStorage_Memory adminDragons = new DragonsDataStorage_Memory();
            int nritems,nrdragons;
            string optiune, name, damage;

            Item sword = new Item("Sword", 10, 10);
            Item Spear = new Item("Spear", 20, 20);
            Item Axe = new Item("Axe", 30, 30);

            Dragon Aor = new Dragon("Aor", 2, 200);
            Dragon Bor = new Dragon("Bor", 4, 400);
            Dragon Nor = new Dragon("Nor", 6, 600);

            Console.WriteLine("1.Meniu Items");
            Console.WriteLine("2.Meniu Dragoni");

            Console.Write("Alege: ");
            optiune = Console.ReadLine();
            //Interfata
            switch (optiune)
            {



                //Meniu pentru Items
                case "1":
            Console.WriteLine("1.Add Sword to inventory.");
            Console.WriteLine("2.Add Spear to inventory.");
            Console.WriteLine("3.Add Axe to inventory.");
            Console.WriteLine("4.Show Inventory.");
            Console.WriteLine("5.Search by Name.");
            Console.WriteLine("6.Search by Damage.");
            Console.WriteLine("0.Exit");
            do
            {
                Console.Write("Chose: ");
                optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        adminItems.AddItem(sword); break;
                    case "2":
                        adminItems.AddItem(Spear); break;
                    case "3":
                        adminItems.AddItem(Axe); break;
                    case "4":
                        Item[] items = adminItems.GetItems(out nritems);
                        ShowItems(items, nritems);
                        break;
                    case "5":
                        Console.Write("Numele item-ului: ");
                        string srchname = Console.ReadLine();
                        Item[] Sitems = adminItems.SearchItemByName(srchname);
                        if (Sitems.Length == 0)
                        {
                            Console.WriteLine("Nu s-a gasit Item.");
                        }
                        else
                        {
                            foreach (Item item in Sitems)
                            {
                                Console.WriteLine("S-a gasit Item-ul!");
                                Console.WriteLine(item.Info());
                            }
                        }
                        break;
                    case "6":
                        bool check;
                        int Sdamage;
                        do
                        {
                            Console.Write("Care este damage-ul: ");
                            check = Int32.TryParse(Console.ReadLine(), out Sdamage);
                        } while (!check);
                        Sitems = adminItems.SearchItemByDamage(Sdamage);
                        if (Sitems.Length == 0)
                        {
                            Console.WriteLine("Nu s-a gasit Item.");
                        }
                        else
                        {
                            foreach (Item item in Sitems)
                            {
                                Console.WriteLine("S-a gasit Item-ul!");
                                Console.WriteLine(item.Info());
                            }
                        }
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Error, try again!");
                        break;

                }
            } while (optiune != "0");
            break;

                //Meniu pentru dragoni
                case "2":
                    Console.WriteLine("1.Adauga-l pe Aor");
                    Console.WriteLine("2.Adauga-l pe Bor");
                    Console.WriteLine("3.Adauga-l pe Nor");
                    Console.WriteLine("4.Arata dragonii salvati.");
                    Console.WriteLine("5.Cauta dupa nume.");
                    Console.WriteLine("6.Cauta dupa dificultate.");
                    Console.WriteLine("0.Exit");
                    do
                    {
                        Console.Write("Alege: ");
                        optiune = Console.ReadLine();

                        switch (optiune)
                        {
                            case "1":
                                adminDragons.AddDragon(Aor); break;
                            case "2":
                                adminDragons.AddDragon(Bor); break;
                            case "3":
                                adminDragons.AddDragon(Nor); break;
                            case "4":
                                Dragon[] dragons = adminDragons.GetDragons(out nrdragons);
                                ShowDragons(dragons, nrdragons);
                                break;
                            case "5":
                                Console.Write("Numele dragonului: ");
                                string srchname = Console.ReadLine();
                                Dragon[] Sdragons = adminDragons.SearchDragonByName(srchname);
                                if (Sdragons.Length == 0)
                                {
                                    Console.WriteLine("Nu s-a gasit dragon-ul.");
                                }
                                else
                                {
                                    foreach (Dragon dragon in Sdragons)
                                    {
                                        Console.WriteLine("S-a gasit dragonul!");
                                        Console.WriteLine(dragon.InfoDragon());
                                    }
                                }
                                break;
                            case "6":
                                bool check;
                                int Sdamage;
                                do
                                {
                                    Console.Write("Care este dificultatea: ");
                                    check = Int32.TryParse(Console.ReadLine(), out Sdamage);
                                } while (!check);
                                Sdragons = adminDragons.SearchDragonByDifficulty(Sdamage);
                                if (Sdragons.Length == 0)
                                {
                                    Console.WriteLine("Nu s-a gasit dragonul.");
                                }
                                else
                                {
                                    foreach (Dragon dragon in Sdragons)
                                    {
                                        Console.WriteLine("S-a gasit dragonul!");
                                        Console.WriteLine(dragon.InfoDragon());
                                    }
                                }
                                break;
                            case "0":
                                return;
                            default:
                                Console.WriteLine("Error, try again!");
                                break;

                        }
                    } while (optiune != "0");

                    break;

                default:
                    Console.WriteLine("Nu exista optiunea.");
                    break;
        }
        
        
        


            //Nu am nevoie
            /**
            do
            {
                Console.WriteLine("1.Create Player");
                Console.WriteLine("2.Show Created Player");
                Console.WriteLine("0.Exit");
                Console.Write("Enter your choice: ");
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        player = new Player(GetPlayerName());
                        Console.WriteLine("You have 5 points for now.");
                        Console.WriteLine("Put them in Strength, Intelligence and Agility as you wish.");
                        Console.WriteLine("1.Put a point in Strength");
                        Console.WriteLine("2.Put a point in Intelligence");
                        Console.WriteLine("3.Put a point in Agility");
                        do
                        {
                            Console.Write("Choice: ");
                            choice2 = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                            switch (choice2)
                            {
                                case '1':
                                    player.Strength++;
                                    player.AbilityPoints--;
                                    Console.WriteLine("You put a point in Strength");
                                    Console.WriteLine($"Points left {player.AbilityPoints}");
                                    break;
                                case '2':
                                    player.Intelligence++;
                                    player.AbilityPoints--;
                                    Console.WriteLine("You put a point in Intelligence");
                                    Console.WriteLine($"Points left {player.AbilityPoints}");
                                    break;
                                case '3':
                                    player.Agility++;
                                    player.AbilityPoints--;
                                    Console.WriteLine("You put a point in Agility");
                                    Console.WriteLine($"Points left {player.AbilityPoints}");
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice.");
                                    break;
                            }
                        } while (player.AbilityPoints > 0);
                        break;
                    case '2':
                        if (player != null)
                        {
                            Console.WriteLine(player.Info());
                        }
                        else 
                        {
                            Console.WriteLine("No player created.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            } while (choice != '0'); **/

        } 

        static string GetPlayerName()
        {
            Console.Write("Enter your name:");
            return Console.ReadLine();
        }

        public static void ShowItems(Item[] items,int nritems)
        {
            Console.WriteLine("The items are:");
            for(int i = 0;i<nritems;i++) 
            {
                string infoitem = items[i].Info();
                Console.WriteLine(infoitem);
            }
        }
        public static void ShowDragons(Dragon[] dragons, int nrDragons)
        {
            Console.WriteLine("The dragons are:");
            for (int i = 0; i < nrDragons; i++)
            {
                string infodragon = dragons[i].InfoDragon();
                Console.WriteLine(infodragon);
            }
        }

    }
}
