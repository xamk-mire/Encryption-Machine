using System;
namespace UniversalEncryptionMachine.Ciphers
{
    public interface ICipher
    {
        string CipherName { get; }

        bool RequireKey { get; }

        string Encrypt(string inputText, string? key);

        string Decrypt(string inputText, string? key);
    }
}
