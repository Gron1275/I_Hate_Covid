using System;

namespace I_Hate_Covid
{
    class Wheel
    {
        private object[] elements = new object[26];

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

        public Wheel()
        {
            for (int i = 65; i <= 90; i++)
            {
                elements[i - 65] = (char)(i);
            }
        }
        public void Rotate(int rot, char direction)
        {
            object[] Rotated = new object[26];
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
            }
            Array.Copy(Rotated, elements, Rotated.Length);

        }
    }

}
