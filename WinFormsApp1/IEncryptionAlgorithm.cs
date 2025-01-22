using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public interface IEncryptionAlgorithm
    {
        string Name { get; }
        byte[] Encrypt(byte[] data, string password);
        byte[] Decrypt(byte[] data, string password);
    }
}
