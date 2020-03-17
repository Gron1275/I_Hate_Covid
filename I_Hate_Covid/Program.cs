using System;

namespace I_Hate_Covid
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] key = new char[3];
            for (int i = 0; i < 3; i++)
            {
                System.Console.WriteLine("What is the {0} character of the 3 char key?: ", i);
                key[i] = Convert.ToChar(Console.ReadLine());
            }
            int locOne = Convert.ToInt32(key[1]);
            int locTwo = Convert.ToInt32(key[2]);
            int locZero = Convert.ToInt32(key[0]);
            Wheel wheel0 = new Wheel();
            Wheel wheel1 = new Wheel();
            Wheel wheel2 = new Wheel();
            wheel0.Rotate(locZero, (locZero % 2 == 0) ? 'L' : 'R');
            wheel1.Rotate(locOne, (locOne % 2 == 0) ? 'L' : 'R');
            wheel2.Rotate(locTwo, (locTwo % 2 == 0) ? 'L' : 'R');

            //Console.WriteLine(wheel2);
            //Console.WriteLine("What is the sentence you wanna encrypt?: ");
            //string rawInput = Console.ReadLine();



        }
        public static void EncryptChar(char input, Wheel wheel0)
        {
            int difference;
            difference = wheel0.ElementIndex(input);
            wheel0.Rotate(difference, 'R');
            Console.Write(wheel0.Elements[0]);


        }
        
    }
}
