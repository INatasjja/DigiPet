// See https://aka.ms/new-console-template for more information

public class Digipet
{
    public static void Main()
    {
        string[] PetArray;
        PetArray = new string[] { "Dog", "Cat", "Parrot", "Fish", "Turtle" };

        int petType = 0;

        Console.WriteLine("Welcome, Please choose the kind of pet you want to adopt:");


        for (int i = 0; i < PetArray.Length; i++)
        {
            Console.WriteLine(i + 1 + " - " + PetArray[i]);
        }

        while (true) 
        {

  
                petType = Convert.ToInt32(Console.ReadLine());

                if (petType > 0 || petType <= PetArray.Length)
                {
                    Console.WriteLine("Congratulations, you just adopted a " + PetArray[petType - 1] + "!!");
                }

                else
                {
                    Console.WriteLine("Insert a value between 1 and " + PetArray.Length);
                }

                
                break;
        }
            
        Console.WriteLine("What should we name your new " + PetArray[petType - 1] + "?");
        
        }
}