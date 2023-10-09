using UniversalEncryptionMachine.Ciphers;

namespace UniversalEncryptionMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userInput;

            do
            {
                // Select encryption mechanism
                ShowCipherSelection();

                while (!int.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.Clear();
                    Console.WriteLine("You entered an invalid input");
                    ShowCipherSelection();
                }

                switch (userInput)
                {
                    case 1:
                        SubstitutionCipher substitutionCipher = new SubstitutionCipher();
                        HandleCipher(substitutionCipher);
                        break;
                    case 2:
                        VigenereCipher vigenereCipher = new VigenereCipher();
                        HandleCipher(vigenereCipher);
                        break;
                    case 3:
                        EnigmaCipher enigmaCipher = new EnigmaCipher();
                        HandleCipher(enigmaCipher);
                        break;
                    default:
                        break;
                }
            } while (userInput != 0);

            Console.WriteLine(@"Exiting program");
        }

        public static void HandleCipher(ICipher cipher)
        {
            Console.WriteLine($"You selected {cipher.CipherName}");
            int encryptOrDecrypt = EncryptOrDecrypt();
            string message = GetMessage();
            string? key = cipher.RequireKey ? GetKey() : null;
            switch (encryptOrDecrypt)
            {
                case 1:
                    Console.WriteLine(cipher.Encrypt(message, key));
                    break;
                case 2:
                    Console.WriteLine(cipher.Decrypt(message, key));
                    break;
                default:
                    break;
            }
        }

        public static string GetMessage()
        {
            Console.Write("Type your message here: ");
            return Console.ReadLine() ?? "";
        }

        public static string GetKey()
        {
            Console.Write("Type your key here: ");
            return Console.ReadLine() ?? "";
        }

        public static int EncryptOrDecrypt()
        {
            Console.WriteLine("Do you wan't to 1. Encrypt or 2. Decrypt");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    return choice;
                }
            }
        }

        public static void ShowCipherSelection()
        {
            Console.WriteLine(@"1. Substitution Cipher");
            Console.WriteLine(@"2. Vigenere Cipher");
            Console.WriteLine(@"3. Enigma Cipher");
            Console.WriteLine(@"0. To Exit the Program");
        }
    }
}