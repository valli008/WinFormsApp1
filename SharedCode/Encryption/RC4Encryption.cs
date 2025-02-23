using System.Text;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;

namespace SharedCode.Encryption;

public class RC4Encryption : IEncryptionAlgorithm
{
    public string Name => "RC4";

    public byte[] Encrypt(byte[] data, string password)
    {
        RC4Engine engine = new RC4Engine();
        byte[] key = Encoding.UTF8.GetBytes(password);
        engine.Init(true, new KeyParameter(key));

        byte[] output = new byte[data.Length];
        engine.ProcessBytes(data, 0, data.Length, output, 0);
        return output;
    }

    public byte[] Decrypt(byte[] data, string password)
    {
        // RC4 is symmetric, decryption is the same as encryption
        return Encrypt(data, password);
    }
}