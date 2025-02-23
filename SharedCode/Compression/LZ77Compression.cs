namespace SharedCode.Compression;

public class LZ77Compression : ICompressionAlgorithm
{
    public string Name => "LZ77";

    // Метод для стиснення
    public byte[] Compress(byte[] data)
    {
        using (var output = new MemoryStream())
        {
            int windowSize = 4096; // Розмір вікна
            int maxMatchLength = 255; // Максимальна довжина збігу

            for (int i = 0; i < data.Length; i++)
            {
                int matchLength = 0;
                int matchDistance = 0;

                // Пошук збігів
                for (int j = 1; j <= Math.Min(i, windowSize); j++)
                {
                    int currentLength = 0;
                    while (currentLength < maxMatchLength &&
                           i + currentLength < data.Length &&
                           data[i + currentLength] == data[i - j + currentLength])
                    {
                        currentLength++;
                    }

                    if (currentLength > matchLength)
                    {
                        matchLength = currentLength;
                        matchDistance = j;
                    }
                }

                if (matchLength >= 3) // Якщо знайдено збіг
                {
                    output.WriteByte((byte)(0x80 | (matchLength - 3))); // Довжина збігу
                    output.WriteByte((byte)matchDistance); // Відстань
                    i += matchLength - 1; // Пропускаємо оброблені символи
                }
                else
                {
                    output.WriteByte(data[i]); // Просто записуємо символ
                }
            }

            return output.ToArray();
        }
    }

    // Метод для розпакування
    public byte[] Decompress(byte[] data)
    {
        using (var output = new MemoryStream())
        {
            byte[] window = new byte[4096]; // Вікно
            int windowPos = 0;

            for (int i = 0; i < data.Length; i++)
            {
                byte currentByte = data[i];
                if ((currentByte & 0x80) == 0x80) // Якщо це маркер
                {
                    int matchLength = (currentByte & 0x7F) + 3; // Довжина збігу
                    int matchDistance = data[++i]; // Відстань

                    for (int j = 0; j < matchLength; j++)
                    {
                        int position = (windowPos - matchDistance + window.Length) % window.Length;
                        byte value = window[position];
                        output.WriteByte(value);
                        window[windowPos] = value;
                        windowPos = (windowPos + 1) % window.Length;
                    }
                }
                else
                {
                    output.WriteByte(currentByte);
                    window[windowPos] = currentByte;
                    windowPos = (windowPos + 1) % window.Length;
                }
            }

            return output.ToArray();
        }
    }

}