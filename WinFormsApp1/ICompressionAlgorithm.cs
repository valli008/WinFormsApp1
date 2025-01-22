using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public interface ICompressionAlgorithm
    {
        string Name { get; }
        byte[] Compress(byte[] data);
        byte[] Decompress(byte[] data);
    }
}
