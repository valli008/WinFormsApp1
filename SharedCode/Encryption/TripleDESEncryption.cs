using System.Security.Cryptography;
using System.Text;

namespace SharedCode.Encryption;

public class TripleDESEncryption : IEncryptionAlgorithm
{
    public string Name => "3DES";

    public byte[] Encrypt(byte[] data, string password)
    {
        using (var tripleDES = TripleDES.Create())
        {
            var key = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes("salt"));
            tripleDES.Key = key.GetBytes(tripleDES.KeySize / 8);
            tripleDES.IV = key.GetBytes(tripleDES.BlockSize / 8);

            using (var ms = new MemoryStream())
            using (var cryptoStream = new CryptoStream(ms, tripleDES.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();
                return ms.ToArray();
            }
        }
    }

    public byte[] Decrypt(byte[] data, string password)
    {
        using (var tripleDES = TripleDES.Create())
        {
            var key = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes("salt"));
            tripleDES.Key = key.GetBytes(tripleDES.KeySize / 8);
            tripleDES.IV = key.GetBytes(tripleDES.BlockSize / 8);

            using (var ms = new MemoryStream())
            using (var cryptoStream = new CryptoStream(ms, tripleDES.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();
                return ms.ToArray();
            }
        }
    }
}