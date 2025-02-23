using System.Security.Cryptography;
using System.Text;

namespace SharedCode.Encryption;

public class AESEncryption : IEncryptionAlgorithm
{
    public string Name => "AES";

    public byte[] Encrypt(byte[] data, string password)
    {
        using (var aes = Aes.Create())
        {
            var key = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes("salt"));
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);

            using (var ms = new MemoryStream())
            using (var cryptoStream = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();
                return ms.ToArray();
            }
        }
    }

    public byte[] Decrypt(byte[] data, string password)
    {
        using (var aes = Aes.Create())
        {
            var key = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes("salt"));
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);

            using (var ms = new MemoryStream())
            using (var cryptoStream = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();
                return ms.ToArray();
            }
        }
    }
}