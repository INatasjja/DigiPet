// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;

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
                Console.WriteLine("Congratulations, you just adopted a " + PetArray[petType - 1] + "!!");
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
        Console.WriteLine("Your new " + PetArray[petType - 1] + "'s name is: " + PetName+"\n");
        Console.WriteLine(PetName + " looks so happy to finally have a home, please make sure to check your " + PetArray[petType - 1] + "'s needs are meet.");

        //Menu

        Hunger = 5;
        Happiness = 5;
        Health = 5;
        DisplayStats();

        void DisplayStats()
        {
            Console.WriteLine(PetName + "'s happines level is:" + Happiness);
            Console.WriteLine(PetName + "'s health level is:" + Health);
            Console.WriteLine(PetName + "'s hunger level is:" + Hunger);
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
                Console.WriteLine("4 - Close game\n");
                
                if (!int.TryParse(Console.ReadLine(),out MenuChoice))
                {
                    Console.WriteLine("Please insert a value from 1 to 4");
                    continue;

                }
                    ;
                if (MenuChoice >=1 && MenuChoice <= 4)
                {
                    if (MenuChoice == 1)
                    {
                        Hunger = Hunger - 1;
                        Health = Health + TinyIncrease;
                    }
                    else if (MenuChoice == 2)
                    {
                        Happiness = Happiness + 1;
                        Hunger = Hunger + TinyIncrease;
                    }
                    else if (MenuChoice == 3)
                    {
                        Health = Health + 1;
                        Happiness = Happiness - TinyIncrease;
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