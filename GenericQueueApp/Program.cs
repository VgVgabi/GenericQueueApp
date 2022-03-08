using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GenericQueueApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> studentsNames = new Queue<int>();
            void GetQueue()
            {
                foreach (var item in studentsNames)
                    Console.WriteLine($"Current Queue List Row: {item}");
            }
            bool breakFlag = false;
            //
            while (!breakFlag)
            {
                try
                {
                    Console.WriteLine("\nWhat action would you like to take in Generic Queue List?\na - Add\nd - Remove\ne - Enumerate\nb - Contains\nc - Clear\nq - Quit");
                    string userActionListiner = Console.ReadLine().ToLower();
                    // -->
                    switch (userActionListiner)
                    {
                        case "a":
                            Console.WriteLine("Please, add an item number:");
                            int userItemAdd = int.Parse(Console.ReadLine());
                            studentsNames.Enqueue(userItemAdd);
                            GetQueue();
                            break;
                        //
                        case "d":
                            if (studentsNames.Count > 0)
                            {
                                Console.WriteLine("DO YOU SURE THAT YOU WANT TO DELETE? Y/N ");
                                string UserAnswer = Console.ReadLine().ToLower();
                                switch (UserAnswer)
                                {
                                    case "y":
                                        studentsNames.Dequeue();
                                        Console.WriteLine("Remove Operation Succeeded From First Limb!");
                                        break;
                                    //
                                    default:
                                        Console.WriteLine("Remove Operation Canceled!");
                                        break;
                                }
                            }
                            break;
                        //
                        case "e":
                            if (studentsNames.Count > 0)
                                GetQueue();
                            else
                                Console.WriteLine("No Record In Queue List");
                            break;
                        //
                        case "b":
                            if (studentsNames.Count > 0)
                            {
                                try
                                {
                                    Console.WriteLine("Set The Search Input Number Please:");
                                    int userInnerListiner = int.Parse(Console.ReadLine());
                                    bool searchStatus = studentsNames.Contains(userInnerListiner);
                                    if (searchStatus == true)
                                        Console.WriteLine("The Element Exists In Queue List");
                                    else
                                        Console.WriteLine("The Element NOT Exists In Queue List");
                                }
                                catch
                                {
                                    Console.WriteLine("Checking element in Queue List Operation is failure!");
                                }
                            }
                            break;
                        //
                        case "c":
                            studentsNames.Clear();
                            Console.WriteLine("The Queue List Cleared!");
                            break;
                        //
                        case "q":
                            breakFlag = true;
                            break;
                    }                    
                }
                catch (Exception)
                {
                    Console.WriteLine("The Operation is failure!");
                }
            }
        }
    }
}