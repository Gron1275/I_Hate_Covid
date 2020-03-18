﻿using System;

namespace I_Hate_Covid
{
    class Program
    {
        /*                                                  [ROTCRYPT]
         *                                                Grennon Gurney
         *                                                    Notes:
         *                                    For my sanity, I am making rotations only
         *                                 work in the left direction FOR NOW until i can make
         *                               the code way better. I will leave the Left Rot method open   
         *                                                 for later use!
         */
        public static void Main(string[] args)
        {

            Console.Write("What is the character key?: ");
            string key = Console.ReadLine();
            Console.Write("What is the string to encrypt?: ");
            string input = Console.ReadLine().ToUpper();

            int locZero = Convert.ToInt32(key[0]);
            int locOne = Convert.ToInt32(key[1]);
            int locTwo = Convert.ToInt32(key[2]);

            Wheel wheel0 = new Wheel("wheel0");
            Wheel wheel1 = new Wheel("wheel1");
            Wheel wheel2 = new Wheel("wheel2");
            Wheel[] wheelz = new Wheel[]
            {
                wheel0, wheel1, wheel2
            };

            wheel0.Rotate(locZero);
            wheel1.Rotate(locOne);
            wheel2.Rotate(locTwo);

            wheel0.Print(locZero);
            wheel1.Print(locOne);
            wheel2.Print(locTwo);

            Console.WriteLine("");
            Console.WriteLine($"Input string: {input}");
            object[] final = new object[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                final[i] = EncryptChar(input[i], wheelz, i);
            } 
            Console.Write("Output string: ");
            for (int j = 0; j < final.Length; j++)
            {
                Console.Write($"{final[j]}");
            }
        }
        public static object EncryptChar(char inputChar, Wheel[] wheelzLoc, int wheelDes) 
        {
            int difference;
            difference = wheelzLoc[(wheelDes % 2 == 0) ? 0 : 1].ElementIndex(inputChar);
            foreach (Wheel iterWheel in wheelzLoc)
            {
                iterWheel.Rotate(difference + wheelDes);
                iterWheel.Print(difference + wheelDes);
            }
            return wheelzLoc[2].ElementLoc(0);
        }
    }
}
