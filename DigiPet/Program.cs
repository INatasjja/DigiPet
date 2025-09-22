// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class Digipet
{
    public static void Main()
    {
        string[] PetArray;
        string PetName;
        double Hunger;
        double Happiness;
        double Health;
        double TinyIncrease;
        DateTime time= DateTime.Now;
        TinyIncrease = 0.5;

        //Pet type selection
        PetArray = new string[] { "Dog", "Cat", "Parrot", "Fish", "Turtle" };

        int petType = 0;

        Console.WriteLine("\nWelcome, Please choose the kind of pet you want to adopt:\n");

        for (int i = 0; i < PetArray.Length; i++)
        {
            Console.WriteLine(i + 1 + " - " + PetArray[i]);
        }

        while (true)
        {
            petType = Convert.ToInt32(Console.ReadLine());

            if (petType > 0 && petType <= PetArray.Length)
            {
                Console.WriteLine("Congratulations, you just adopted a " + PetArray[petType - 1] + " on this day: "+ time.ToString()+"!!");
                time = time.AddMinutes(60);
                break;
            }

            else
            {
                Console.WriteLine("Insert a value between 1 and " + PetArray.Length);
            }
        }

        //Naming your pet
        Console.WriteLine("What should we name your new " + PetArray[petType - 1] + "?");
        PetName = Console.ReadLine();
        Console.WriteLine("\nYour new " + PetArray[petType - 1] + "'s name is: " + PetName+"\n");
        Console.WriteLine(PetName + " looks so happy to finally have a home, please make sure to check your " + PetArray[petType - 1] + "'s needs are meet.\n");

        //Menu

        Hunger = 5;
        Happiness = 5;
        Health = 5;
        DisplayStats();

        void DisplayStats()
        {
            Console.WriteLine("\nIs " + time.ToString() + " and:");
            Console.WriteLine(PetName + "'s happines level is:" + Happiness);
            Console.WriteLine(PetName + "'s health level is:" + Health);
            Console.WriteLine(PetName + "'s hunger level is:" + Hunger+"\n");
        }
        void MainMenu(string PetName)
        {
            int MenuChoice = 0;

            while (true)
            {
                Console.WriteLine("\nWhat do you wanna next?\n");
                Console.WriteLine("1 - Feed " + PetName);
                Console.WriteLine("2 - Play with " + PetName);
                Console.WriteLine("3 - Take " + PetName + " to bed");
                Console.WriteLine("4 - Close game");
                
                if (!int.TryParse(Console.ReadLine(),out MenuChoice))
                {
                    Console.WriteLine("Please insert a value from 1 to 4");
                    continue;
                }
      
                if (MenuChoice >=1 && MenuChoice <= 4)
                {
                    // stats range validation
                    if (Hunger == 10)
                    {
                        Console.WriteLine("Oh no!!! " + PetName + " seems to not be doing well. \nHe has been removed from your care");
                    }
                    else if (Hunger >= 8 && Hunger <= 9)
                    {
                        Console.WriteLine(PetName + " Is REALLY hungry, Please feed right away");
                    }
                    else if (Hunger <= 1)
                    {
                        Console.WriteLine(PetName + " Is satisfied, he couldn't eat more even if it wanted to!");
                    }

                    if (Happiness <= 1)
                    {
                        Console.WriteLine("Oh no!!! " + PetName + " seems to not be doing well. He has been removed from your care");
                    }
                    else if (Happiness >= 2 && Happiness <= 3)
                    {
                        Console.WriteLine(PetName + " Is feeling LONELY. \n Please play with"+ PetName);
                    }
                    else if (Happiness >= 10)
                    {
                        Console.WriteLine(PetName + " Couldn't be more happy!");
                    }

                    if (Health <= 1)
                    {
                        Console.WriteLine("Oh no!!! " + PetName + " seems to not be doing well. He has been removed from your care");
                    }
                    else if (Health >= 2 && Health <= 3)
                    {
                        Console.WriteLine(PetName + " Is getting SICK, let it rest");
                    }
                    else if (Health == 10)
                    {
                        Console.WriteLine(PetName + " Is thriving in your care!");
                    }


                    if (MenuChoice == 1)
                    {
                        if (Hunger > 1 && Hunger <= 10)
                        {
                            Hunger = Hunger - 1;
                            Health = Health + TinyIncrease;
                            time = time.AddMinutes(60);
                        }
                     
                    }
                    else if (MenuChoice == 2)
                    {
                        if (Happiness >= 1 && Happiness < 10)
                        {
                            Happiness = Happiness + 1;
                            Hunger = Hunger + TinyIncrease;
                            time = time.AddMinutes(60);
                        }
                    }
                    else if (MenuChoice == 3)
                    {
                        if (Health >= 1 && Health < 10)
                        {
                            Health = Health + 1;
                            Happiness = Happiness - TinyIncrease;
                            time = time.AddMinutes(60);
                        }
                    }
                    else if (MenuChoice == 4)
                    {
                        Console.WriteLine("Thank you for playing!");
                        break;
                    }
                    DisplayStats();
                }
                else
                {
                    Console.WriteLine("Please select a valid option");
                }
            }
        }

        MainMenu(PetName);

    }

}

