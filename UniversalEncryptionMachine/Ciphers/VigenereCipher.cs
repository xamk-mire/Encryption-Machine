namespace UniversalEncryptionMachine.Ciphers
{
    public class VigenereCipher : ICipher
    {
        public string CipherName { get => "Vigenere Cipher"; }
        public bool RequireKey { get => true; }

        public string Decrypt(string inputText, string? key)
        {
            if (key == null) return "Error, key not provided";
            string result = "";
            for (int i = 0; i < inputText.Length; i++)
            {
                char character = inputText[i];
                if (char.IsLetter(character))
                {
                    char offset = char.IsUpper(character) ? 'A' : 'a';
                    result += (char)((character + key[i % key.Length] - 2 * offset) % 26 + offset);
                }
                else
                {
                    result += character;
                }
            }
            return result;
        }

        public string Encrypt(string inputText, string? key)
        {
            if (key == null) return "Error, key not provided";
            string result = "";
            for (int i = 0; i < inputText.Length; i++)
            {
                char character = inputText[i];
                if (char.IsLetter(character))
                {
                    char offset = char.IsUpper(character) ? 'A' : 'a';
                    result += (char)((character - key[i % key.Length] + 26) % 26 + offset);
                }
                else
                {
                    result += character;
                }
            }
            return result;
        }
    }
}
