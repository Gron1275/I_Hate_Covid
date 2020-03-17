using System;

namespace I_Hate_Covid
{
    class Program
    {
        public static void Main(string[] args)
        {
            //char[] key = new char[3];
            //for (int i = 0; i < 3; i++)
            //{
            //    System.Console.WriteLine("What is the {0} character of the 3 char key?: ", i);
            //    key[i] = Convert.ToChar(Console.ReadLine());
            //}
            Console.Write("What is the 3 character key?: ");
            string key = Console.ReadLine();

            int locZero = Convert.ToInt32(key[0]);
            int locOne = Convert.ToInt32(key[1]);
            int locTwo = Convert.ToInt32(key[2]);

            Wheel wheel0 = new Wheel();
            Wheel wheel1 = new Wheel();
            Wheel wheel2 = new Wheel();
            Wheel[] wheelz = new Wheel[]
            {
                wheel0, wheel1, wheel2
            };
            Console.Write("Wheel0: ");
            for (int i = 0; i < wheel0.Elements.Length; i++)
            {
                Console.Write($"{wheel0.ElementLoc(i)} ");
            }
            wheel0.Rotate(locZero, (locZero % 2 == 0) ? 'L' : 'R');
            wheel1.Rotate(locOne, (locOne % 2 == 0) ? 'L' : 'R');
            wheel2.Rotate(locTwo, (locTwo % 2 == 0) ? 'L' : 'R');

            Console.WriteLine("");
            Console.Write($"Wheel0 Rotated {locZero} {((locZero % 2 == 0) ? "Left" : "Right")}: ");
            for (int i = 0; i < wheel0.Elements.Length; i++)
            {
                Console.Write($"{wheel0.ElementLoc(i)} ");
            }

            string input = "Grennon".ToUpper();
            Console.WriteLine("");
            Console.WriteLine($"Input string: {input}");
            object[] final = new object[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                final[i] = EncryptChar(input[i], wheelz);
            }
            Console.Write("Output string: ");
            for (int j = 0; j < final.Length; j++)
            {
                Console.Write($"{final[j]}");
            }
        }
        public static object EncryptChar(char inputChar, Wheel[] wheelzLoc) //difference might hafta be constant for each string
                                                                            // if so declare and pass it bc variability not good
                                                                            // for when I need to decrypt - rn code is like hasher
        {
            int difference;
            difference = wheelzLoc[0].ElementIndex(inputChar);
            foreach (Wheel iterWheel in wheelzLoc)
            {
                iterWheel.Rotate(difference, (difference % 2 == 0) ? 'L' : 'R');
            }
            return wheelzLoc[2].ElementLoc(0);

            //RotateAll(difference I HAVE AN ISSUE WITH SCOPE LEVELS!!!!!!


        }
        /*public static void RotateAll(int rot, Wheel[] wheelzLoc) //need wheelz to be defualt parameter b/c i want ease
        {
            foreach (Wheel iterWheel in wheelzLoc)
            {
                iterWheel.Rotate(rot, (rot % 2 == 0) ? 'L': 'R');
            }
        }*/

    }
}
