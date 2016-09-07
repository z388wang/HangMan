using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
        static bool Restart(string answer)
        {

            string yes = "yes";
            Console.Write("Do you want to play another game? (yes/no)");
            answer = Console.ReadLine();
            if (answer == yes)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        static int Pick(int min, int max)
        {
            Random number = new Random();
            int index = number.Next(min, max);
            return index;
        }



        static void Main(string[] args)
        {
            Console.WriteLine("*********Welcome to HangMan, Let's begin!!********");
            string[] wordBank = new string[10];
            wordBank[0] = "september";
            wordBank[1] = "apple";
            wordBank[2] = "interview";
            wordBank[3] = "university";
            wordBank[4] = "message";
            wordBank[5] = "solution";
            wordBank[6] = "success";
            wordBank[7] = "victory";
            wordBank[8] = "different";
            wordBank[9] = "extraordinary";

            int chance = 5;
            int random = Pick(0, 9);
            string newWord = wordBank[random];

            char[] everyLetter = new char[newWord.Length];
            for (int i = 0; i < newWord.Length; i++)
            {
                everyLetter[i] = '*';
            }
         
            while (true)
            {
                Console.Write("Enter your Letter:   ");
                char guess = char.Parse(Console.ReadLine());
                for (int j = 0; j < newWord.Length; j++)
                {
                    if (guess == newWord[j])
                    {                 
                        everyLetter[j] = guess;
                    }
          
                }
                Console.WriteLine(everyLetter);

                if(!everyLetter.Contains(guess))
                {
                    chance -= 1;
                    Console.WriteLine("Wrong, you got {0} chances left", chance);
                
                    if (chance == 0)
                    {
                        Console.WriteLine("Game Over, you lose!");
                        if (Restart("yes"))
                        {
                           
                            chance = 5;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if(!everyLetter.Contains('*'))
                {
                    Console.WriteLine("********You Win!*********");
                    break;

                }
            }
            Console.ReadLine();

        }  
    } 
}
