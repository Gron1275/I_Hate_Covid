using System;

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
            bool Debug = false;
            string key = "$66";
            
            Console.Write("What is the string to encrypt?: ");
            string input = Console.ReadLine();
            
            int locZero = Convert.ToInt32(key[0]);
            int locOne = Convert.ToInt32(key[1]);
            int locTwo = Convert.ToInt32(key[2]);

            EnigmaMachine enigma = new EnigmaMachine();
            Wheel wheel0 = new Wheel((Debug == true) ? "wheel0": null);
            Wheel wheel1 = new Wheel((Debug == true) ? "wheel1": null);
            Wheel wheel2 = new Wheel((Debug == true) ? "wheel2": null);
            Wheel[] wheelz = new Wheel[]
            {
                wheel0, wheel1, wheel2
            };

            wheel0.Rotate(locZero);
            wheel1.Rotate(locOne);
            wheel2.Rotate(locTwo);
            
            if (Debug == true)
            {
                wheel0.Print(locZero);
                wheel1.Print(locOne);
                wheel2.Print(locTwo);
            }
            
            Console.WriteLine("");
            Console.WriteLine($"Input string: {input}");

            object[] final = enigma.Encrypt(input, wheelz, Debug);

            Console.WriteLine("");
            Console.Write("\nOutput string: ");
            for (int j = 0; j < final.Length; j++)
            {
                Console.Write($"{final[j]}");
            }
            Console.WriteLine("\n Press any key to exit...");
            Console.ReadKey();
        }
    }
}
