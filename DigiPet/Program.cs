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

            if (!int.TryParse(Console.ReadLine(), out petType))
            {
                Console.WriteLine("Please insert a numeric value from 1 to "+ PetArray.Length);
                continue;
            }

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

        //STATS BASE VALUES
        Hunger = 5;
        Happiness = 5;
        Health = 5;


        //Stats section
        void DisplayStats()
        {
            Console.WriteLine("\nIs " + time.ToString() + " and:");
            Console.WriteLine(PetName + "'s happines level is:" + Happiness);
            Console.WriteLine(PetName + "'s health level is:" + Health);
            Console.WriteLine(PetName + "'s hunger level is:" + Hunger+"\n");
        }

        //Adding 60mins per action affecting hunger and happiness
        void PastOfTime()

        {
            time = time.AddMinutes(60);
            Hunger = Hunger + TinyIncrease;
            Happiness= Happiness - TinyIncrease;
        }

        //Menu
        void MainMenu(string PetName)
        {
            int MenuChoice = 0;

            while (true)
            {
                Console.WriteLine("\nWhat do you wanna next?\n");
                Console.WriteLine("1 - Feed " + PetName);
                Console.WriteLine("2 - Play with " + PetName);
                Console.WriteLine("3 - Take " + PetName + " to bed");
                Console.WriteLine("4 - Check "+PetName+"'s stats");
                Console.WriteLine("5 - Close game");
                
                if (!int.TryParse(Console.ReadLine(),out MenuChoice))
                {
                    Console.WriteLine("Please insert a value from 1 to 5");
                    continue;
                }
     
                if (MenuChoice >=1 && MenuChoice <= 5)
                {
                    // stats range validation and messages
                    if (Hunger == 10)
                    {
                        Console.WriteLine("Oh no!!! " + PetName + " seems to not be doing well. \nHe has been removed from your care");
                        return;
                    }
                    else if (Hunger >= 8 && Hunger <= 9)
                    {
                        Console.WriteLine(PetName + " Is REALLY hungry, Please feed right away!!!!!!!!!!!");
                    }
                    else if (Hunger <= 1)
                    {
                        Console.WriteLine(PetName + " Is satisfied, he couldn't eat more even if it wanted to!");
                    }

                    if (Happiness == 1)
                    {
                        Console.WriteLine("Oh no!!! " + PetName + " seems to not be doing well. \nHe has been removed from your care");
                        return;
                    }
                    else if (Happiness >= 2 && Happiness <= 3)
                    {
                        Console.WriteLine(PetName + " Is feeling LONELY. \n Please play with "+ PetName+"!!!!!!!!!!");
                    }
                    else if (Happiness >= 10)
                    {
                        Console.WriteLine(PetName + " Loves playing with you, just Couldn't be more happy!");
                    }

                    if (Health == 1)
                    {
                        Console.WriteLine("Oh no!!! " + PetName + " seems to not be doing well.\n He has been removed from your care");
                        return;
                    }
                    else if (Health >= 2 && Health <= 3)
                    {
                        Console.WriteLine(PetName + " Is getting SICK, let it rest!!!!!!!!!!!!!");
                    }
                    else if (Health == 10)
                    {
                        Console.WriteLine(PetName + "'s health is at MAX " + PetName +"'s thriving in your care!");
                    }


                    if (MenuChoice == 1)
                    {
                        if (Hunger > 1 && Hunger <= 10)
                        {
                            Hunger = Hunger - 1;
                            Health = Health + TinyIncrease;
                            PastOfTime();
                            if (Hunger < 1) Hunger = 1;
                            if (Hunger > 10) Hunger = 10;
                            if (Health < 1) Health = 1;
                            if (Health > 10) Health = 10;
                        }
                        Console.WriteLine("\nYou have fed " + PetName + "." +
                                   "\n" + PetName + "'s hunger level have decreased and its health has slightly increased.");
                    }
                    else if (MenuChoice == 2)
                    {
                        if (Happiness >= 1 && Happiness < 10)
                        {
                            Happiness = Happiness + 1;
                            Hunger = Hunger + TinyIncrease;
                            PastOfTime();

                            if (Hunger < 1 )Hunger = 1;
                            if (Hunger > 10) Hunger = 10;
                            if (Happiness < 1) Happiness = 1;
                            if (Happiness > 10) Happiness = 10;
                        }
                        Console.WriteLine("\nYou have played with " + PetName + "." +
                                "\n" + PetName + "'s happiness level have increased but this activity increases slightly its hunger.");
                    }
                    else if (MenuChoice == 3)
                    {
                        if (Health >= 1 && Health < 10)
                        {
                            Health = Health + 1;
                            Happiness = Happiness - TinyIncrease;
                            PastOfTime();
                            if (Health < 1) Health = 1;
                            if (Health > 10) Health = 10;
                            if (Happiness < 1) Happiness = 1;
                            if (Happiness > 10) Happiness = 10;
                        }
                        Console.WriteLine("\n"+PetName + " Has gone to sleep" +
                                "\n" + PetName + "'s health levels have increased but its happiness has slightly decreased.");
                    }
                    else if (MenuChoice == 4)
                    {
                        DisplayStats();
                    }
                    else if (MenuChoice == 5)
                    {
                        Console.WriteLine("Thank you for playing!");
                        break;
                    }
                    
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

