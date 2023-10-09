namespace UniversalEncryptionMachine.Ciphers
{
    public class EnigmaCipher : ICipher
    {
        public string CipherName { get => "Enigma Cipher"; }
        public bool RequireKey { get => true; }

        private readonly List<Rotor> rotors;

        private const string Alphabeth = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /* Example enigma keys to use 
         * Key 1: EKMFLGDQVZNTOWYHXUSPAIBRCJ
         * Key 2: CRNELKJUVOGQAXFMYSPDZIWHBT
         * Key 3: FHZGLCUIRNSMWDQVYJXKPOBAET
         */

        public EnigmaCipher()
        {
            rotors = new List<Rotor>
            {
                new Rotor("AJDKSIRUXBLHWTMCQGZNPYFVOE"),
                new Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO")
            };
        }

        public string Decrypt(string inputText, string? key)
        {
            if (key == null) return "Error, missing key value";
            rotors.Add(new Rotor(key));
            string result = "";
            inputText = inputText.Trim().ToUpper();
            for (int i = 0; i < inputText.Length; i++)
            {
                char character = inputText[i];
                foreach (Rotor rotor in rotors)
                {
                    character = rotor.Decrypt(i, character);
                }
                result += character;
                Rotate();

                
            }
            return result;
        }

        public string Encrypt(string inputText, string? key)
        {
            if (key == null) return "Error, missing key value";
            rotors.Add(new Rotor(key));
            string result = "";
            inputText = inputText.Trim().ToUpper();
            for (int i = 0; i < inputText.Length; i++)
            {
                char character = inputText[i];
                foreach (Rotor rotor in rotors)
                {
                    character = rotor.Encrypt(i, character);
                }
                result += character;
                Rotate();


            }
            return result;
        }

        private void Rotate()
        {
            if (rotors[0].Rotate())
            {
                if (rotors[1].Rotate())
                {
                    rotors[2].Rotate();
                }
            }
        }

        public void Reset()
        {
            foreach (Rotor rotor in rotors)
            {
                rotor.Reset();
            }
        }
    }

    public class Rotor
    {
        private readonly string mapping;
        private int position = 0;

        public Rotor(string mapping)
        {
            this.mapping = mapping;
        }

        public int Transform(int offset, char character)
        {

            return (mapping.IndexOf(character) + offset) % 26;
        }

        public char Encrypt(int index, char character)
        {
            if (char.IsLetter(character))
            {
                return (char)((character - mapping[index % mapping.Length] + 26) % 26 + 'A');
            }
            else
            {
                return character;
            }
        }

        public char Decrypt(int index, char character)
        {
            if (char.IsLetter(character))
            {
                return (char)((character + mapping[index % mapping.Length] - 2 * 'A') % 26 + 'A');
            }
            else
            {
                return character;
            }
        }

        public bool Rotate()
        {
            position = (position + 1) % mapping.Length;
            return position == 0;  // returns true if it has made a full rotation
        }

        public void Reset()
        {
            position = 0;
        }
    }

}

