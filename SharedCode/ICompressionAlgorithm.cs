namespace SharedCode;

public interface ICompressionAlgorithm
{
    string Name { get; }
    byte[] Compress(byte[] data);
    byte[] Decompress(byte[] data);
}