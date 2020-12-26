using System;

namespace snake_game
{
    class fizz_buzz
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 30; i++)
            {
                Console.WriteLine(fizz_buzz_func(i));
            }
        }

        static string fizz_buzz_func(int i)
        {
            if (i % 15 == 0) { return "FizzBuzz"; }
            if (i % 5 == 0) { return "Fizz"; }
            if (i % 3 == 0) { return "Buzz"; }
            return i.ToString();
        }
    }

}
