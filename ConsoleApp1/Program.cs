using SharedCode;
using SharedCode.Compression;

const string path = "./cat.jpeg";

ICompressionAlgorithm[] compressionAlgorithms =
[
    new Bzip2Compression(),
    new DeflateCompression(),
    new LZ77Compression(),
    new LZMACompression(),
    new PPMCompression(),
];

if (Directory.Exists("./zips"))
{
    Directory.Delete("./zips", true);
}

if (Directory.Exists("./imgs"))
{
    Directory.Delete("./imgs", true);
}

Directory.CreateDirectory("./zips");
Directory.CreateDirectory("./imgs");

var inputBytes = File.ReadAllBytes(path);

foreach (var algorithm in compressionAlgorithms)
{
    var resultBytes = algorithm.Compress(inputBytes);
    File.WriteAllBytes($"./zips/{algorithm.Name}.zip", resultBytes);
 
    var decompressedBytes = algorithm.Decompress(resultBytes);
    File.WriteAllBytes($"./imgs/{algorithm.Name}.jpeg", decompressedBytes);

    if (decompressedBytes.Length != inputBytes.Length)
    {
        Console.WriteLine($"{algorithm.Name}: different size: {decompressedBytes.Length} != {inputBytes.Length}");
    }
    else
    {
        var count = 0;
        for (var i = 0; i < decompressedBytes.Length; i++)
        {
            if (decompressedBytes[i] != inputBytes[i])
            {
                count++;
            }
        }

        Console.WriteLine($"{algorithm.Name}: different byte values count = '{count}'");
    }
}