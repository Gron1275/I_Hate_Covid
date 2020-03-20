namespace I_Hate_Covid
{
    class EnigmaMachine
    {
        private object EncryptChar(char inputChar, Wheel[] wheelzLoc, int wheelDes, bool debug)
        {
            int difference;
            difference = wheelzLoc[(wheelDes % 2 == 0) ? 0 : 1].ElementIndex(inputChar);
            foreach (Wheel iterWheel in wheelzLoc)
            {
                iterWheel.Rotate(difference + wheelDes);
                if (debug == true) { iterWheel.Print(difference + wheelDes); }

            }
            return wheelzLoc[2].ElementLoc(0);
        }
        private object DecryptChar(char inputChar, Wheel[] wheelzLoc, int wheelDes, bool debug)
        {
            int difference;
            difference = wheelzLoc[(wheelDes % 2 == 0) ? 0 : 1].ElementIndex(inputChar);
            foreach (Wheel iterWheel in wheelzLoc)
            {
                iterWheel.Rotate(difference + wheelDes, 'L');
                if (debug == true) { iterWheel.Print(difference + wheelDes); }
            }
            return wheelzLoc[wheelDes].ElementLoc(difference); //this might work but who knows at this point
        }
/////////////////////////////////////////////////////
        public object[] Encrypt(string inputLoc, Wheel[] wheelzLoc, bool debug)
        {
            object[] final = new object[inputLoc.Length];
            for (int i = 0; i < inputLoc.Length; i++)
            {
                final[i] = EncryptChar(inputLoc[i], wheelzLoc, i, debug);
            }
            return final;
        }
        public object[] Decrypt(string encLoc, Wheel[] wheelzLoc, bool debug)
        {
            object[] final = new object[encLoc.Length];
            for (int i = encLoc.Length - 1; i >= 0; i--)
            {
               final[i] = DecryptChar(encLoc[i], wheelzLoc, i, debug);
            }
            return final;
        }
    }
}