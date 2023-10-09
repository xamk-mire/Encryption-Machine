namespace UniversalEncryptionMachine.Ciphers
{
    public class SubstitutionCipher : ICipher
    {
        private Dictionary<char, char> _encryptTable = new Dictionary<char, char>();
        private Dictionary<char, char> _decryptTable = new Dictionary<char, char>();

        public string CipherName { get => "Substitution Cipher"; }

        public bool RequireKey { get => false; }

        public SubstitutionCipher()
        {
            string plainAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string cipherAlphabet = "ZYXWVUTSRQPONMLKJIHGFEDCBA";

            // Needed if passing plain&cipher as params
            if (plainAlphabet.Length != cipherAlphabet.Length)
            {
                throw new ArgumentException("Alphabets must be of the same length.");
            }

            for (int i = 0; i < plainAlphabet.Length; i++)
            {
                _encryptTable[plainAlphabet[i]] = cipherAlphabet[i];
                _decryptTable[cipherAlphabet[i]] = plainAlphabet[i];
            }
        }


        public string Encrypt(string plainText, string? key)
        {
            char[] encryptedChars = new char[plainText.Length];
            for (int i = 0; i < plainText.Length; i++)
            {
                encryptedChars[i] = _encryptTable.ContainsKey(plainText[i])
                                    ? _encryptTable[plainText[i]]
                                    : plainText[i];
            }
            return new string(encryptedChars);
        }

        public string Decrypt(string cipherText, string? key)
        {
            char[] decryptedChars = new char[cipherText.Length];
            for (int i = 0; i < cipherText.Length; i++)
            {
                decryptedChars[i] = _decryptTable.ContainsKey(cipherText[i])
                                    ? _decryptTable[cipherText[i]]
                                    : cipherText[i];
            }
            return new string(decryptedChars);
        }

    }
}
