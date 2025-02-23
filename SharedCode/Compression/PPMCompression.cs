using System.Text;

namespace SharedCode.Compression;

public class PPMCompression : ICompressionAlgorithm
{
    public string Name => "PPM";

    private const int ContextSize = 4; // Максимальна глибина контексту

    public byte[] Compress(byte[] data)
    {
        var contextCounts = new Dictionary<string, Dictionary<byte, int>>();
        var compressedData = new List<byte>();
        int contextSize = 4; // Розмір контексту

        for (int i = 0; i < data.Length; i++)
        {
            string context = i >= contextSize
                ? Encoding.UTF8.GetString(data[(i - contextSize)..i])
                : Encoding.UTF8.GetString(data[0..i]);

            if (!contextCounts.ContainsKey(context))
            {
                contextCounts[context] = new Dictionary<byte, int>();
            }

            byte symbol = data[i];
            if (!contextCounts[context].ContainsKey(symbol))
            {
                contextCounts[context][symbol] = 1;
            }

            compressedData.Add((byte)contextCounts[context][symbol]);
            contextCounts[context][symbol]++;
        }

        return compressedData.ToArray();
    }

    public byte[] Decompress(byte[] data)
    {
        var contextCounts = new Dictionary<string, Dictionary<byte, int>>();
        var decompressedData = new List<byte>();
        int contextSize = 4;

        for (int i = 0; i < data.Length; i++)
        {
            string context = decompressedData.Count >= contextSize
                ? Encoding.UTF8.GetString(decompressedData.ToArray(), decompressedData.Count - contextSize,
                    contextSize)
                : Encoding.UTF8.GetString(decompressedData.ToArray());

            if (!contextCounts.ContainsKey(context))
            {
                contextCounts[context] = new Dictionary<byte, int>();
                for (byte b = 0; b < 255; b++)
                {
                    contextCounts[context][b] = 1; // Мінімальна частота
                }
            }

            int frequency = data[i];
            foreach (var kvp in contextCounts[context])
            {
                frequency -= kvp.Value;
                if (frequency <= 0)
                {
                    decompressedData.Add(kvp.Key);
                    contextCounts[context][kvp.Key]++;
                    break;
                }
            }
        }

        return decompressedData.ToArray();
    }
}