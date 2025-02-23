using SharpCompress.Compressors.BZip2;

namespace SharedCode.Compression;

public class Bzip2Compression : ICompressionAlgorithm
{
    public string Name => "Bzip2";

    public byte[] Compress(byte[] data)
    {
        using (var ms = new MemoryStream())
        using (var bzip2 = new BZip2Stream(ms, SharpCompress.Compressors.CompressionMode.Compress, false))
        {
            bzip2.Write(data, 0, data.Length);
            bzip2.Close();
            return ms.ToArray();
        }
    }

    public byte[] Decompress(byte[] data)
    {
        using (var input = new MemoryStream(data))
        using (var bzip2 = new BZip2Stream(input, SharpCompress.Compressors.CompressionMode.Decompress, false))
        using (var output = new MemoryStream())
        {
            bzip2.CopyTo(output);
            return output.ToArray();
        }
    }
}