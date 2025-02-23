namespace SharedCode;

public interface IEncryptionAlgorithm
{
    string Name { get; }
    byte[] Encrypt(byte[] data, string password);
    byte[] Decrypt(byte[] data, string password);
}