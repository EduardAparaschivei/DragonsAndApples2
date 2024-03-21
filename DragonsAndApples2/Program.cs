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
            //Player player = new Player();
            //char choice,choice2;
            //Dragon dragon = new Dragon("Asmogold", 10, 100);
            //Console.WriteLine(dragon.InfoDragon());
            ItemsDataStorage_Memory adminItems = new ItemsDataStorage_Memory();
            int nritems;
            string optiune,name,damage;

            Item sword = new Item("Sword",10,10);
            Item Spear = new Item("Spear",20,20);
            Item Axe = new Item("Axe",30,30);
            Console.WriteLine(sword.Info());
            Console.WriteLine(Spear.Info());
            Console.WriteLine(Axe.Info());
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

                switch(optiune)
                {
                    case "1":
                       adminItems.AddItem(sword); break;
                    case "2":
                        adminItems.AddItem(Spear); break;
                    case "3":
                        adminItems.AddItem(Axe); break;
                    case "4":
                        Item[] items = adminItems.GetItems(out nritems);
                        ShowItems(items,nritems);
                        break;
                    case "5":
                        Item[] fitems = adminItems.GetItems(out nritems);
                        Console.Write("Name: ");
                        name=Console.ReadLine().ToLower();
                        for(int i=0;i<=nritems;i++)
                        {
                            if (fitems[i].Name.ToLower()==name)
                            {
                                Console.Write("Item Found: ");
                                ShowItem(fitems, i);
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

        public static void ShowItem(Item[] item,int position)
        {
            string infoitem = item[position].Info();
            Console.WriteLine(infoitem);
        }
    }
}
