using System;

namespace I_Hate_Covid
{
    class Wheel
    {
        private object[] elements = new object[93];
        private char lastDir;
        private readonly string wheelID;

        public object[] Elements
        {
            get { return elements; }
        }
        public int ElementIndex(char input)
        {
            int elementLoc;
            elementLoc = Array.IndexOf(elements, input);
            return elementLoc;
        }
        public object ElementLoc(int input)
        {
            object elementLoc;
            elementLoc = elements.GetValue(input);
            return elementLoc;
        }

        public Wheel(string name = null)
        {
            wheelID = name;
            for (int i = 33; i <= 125; i++)
            {
                elements[i - 33] = (char)(i);
            }
        }
        public void Rotate(int rot, char direction) //Main Rot function, an override will be for debugging with only right Rots
        {
            object[] Rotated = new object[93];
            int Len = elements.Length;
            int locRot = (rot % Len);
            if (direction == 'R')
            {
                for (int ind = 0; ind < Len; ind++)
                {
                    if (locRot + ind >= Len)
                    {
                        int supLoc = locRot - (Len - ind);
                        Rotated[supLoc] = elements[ind];
                    }
                    else
                    {
                        Rotated[ind + locRot] = elements[ind];
                    }
                }
                lastDir = 'R';
            }
            else
            {
                for (int ind = 0; ind < Len; ind++)
                {
                    if (locRot + ind >= Len)
                    {
                        int supLoc = locRot - (Len - ind);
                        Rotated[ind] = elements[supLoc];
                    }
                    else
                    {
                        Rotated[ind] = elements[ind + locRot];
                    }
                }
                lastDir = 'L';
            }
            Array.Copy(Rotated, elements, Rotated.Length);

        }
        public void Rotate(int rot)
        {
            object[] Rotated = new object[93];
            int Len = elements.Length;
            int locRot = (rot % Len);
            for (int ind = 0; ind < Len; ind++)
            {
                if (locRot + ind >= Len)
                {
                    int supLoc = locRot - (Len - ind);
                    Rotated[supLoc] = elements[ind];
                }
                else
                {
                    Rotated[ind + locRot] = elements[ind];
                }
            }
            lastDir = 'R';
            Array.Copy(Rotated, elements, Rotated.Length);
        }
        public void Print(int rotated = 0)
        {
            Console.Write($"{wheelID} rotated {rotated} {((lastDir == 'L') ? "left": "right")}: ");
            for (int i = 0; i < elements.Length; i++)
            {
                Console.Write($"{elements[i]}, ");
            }
            Console.WriteLine("");
        }
    }
}
