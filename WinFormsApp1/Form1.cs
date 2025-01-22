using WinFormsApp1.Compression.ConsoleApp2.Compression;
using WinFormsApp1.Compression;
using WinFormsApp1.Encryption;
using System.IO;
using System.IO.Compression;
using Org.BouncyCastle.Crypto.Tls;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Ініціалізація списків доступних алгоритмів
        private readonly List<IEncryptionAlgorithm> encryptionAlgorithms = new List<IEncryptionAlgorithm>
        {
            new AESEncryption(),
            new DESEncryption(),
            new TripleDESEncryption(),
            new BlowfishEncryption(),
            new RC4Encryption()
        };

        private readonly List<ICompressionAlgorithm> compressionAlgorithms = new List<ICompressionAlgorithm>
        {
            new DeflateCompression(),
            new LZ77Compression(),
            new Bzip2Compression(),
            new LZMACompression(),
            new PPMCompression()
        };
        // Обробка кнопки "Навчити"
        private void button1_Click(object sender, EventArgs e)
        {
            // Отримуємо шлях до папки та пароль від користувача
            string folderPath = textBox1.Text; // Текстбокс для шляху до папки
            string password = textBox2.Text;  // Текстбокс для введення пароля

            // Перевіряємо, чи існує вказана папка
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("Папку не знайдено. Введіть коректний шлях.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Вказуємо шлях до файлу бази даних для запису результатів навчання
            string trainingFilePath = "results_database.txt";

            // Формуємо списки алгоритмів стиснення
            var compressionAlgorithms = new List<ICompressionAlgorithm>
            {
                new DeflateCompression(),
                new LZ77Compression(),
                new Bzip2Compression(),
                new LZMACompression(),
                new PPMCompression()
            };

            // Формуємо списки алгоритмів шифрування
            var encryptionAlgorithms = new List<IEncryptionAlgorithm>
            {
                new AESEncryption(),
                new DESEncryption(),
                new TripleDESEncryption(),
                new BlowfishEncryption(),
                new RC4Encryption()
            };

            // Додавання назв алгоритмів у ComboBox
            comboBox1.Items.AddRange(encryptionAlgorithms.Select(a => a.Name).ToArray()); // Шифрування/Розшифрування
            comboBox2.Items.AddRange(compressionAlgorithms.Select(a => a.Name).ToArray()); // Архівування/Розархівування

            // Аналізуємо всі файли в папці
            foreach (var filePath in Directory.GetFiles(folderPath))
            {
                // Обчислюємо унікальний хеш для файлу
                string fileHash = ComputeFileHash(filePath);

                // Перевіряємо, чи файл вже є в базі даних
                if (File.Exists(trainingFilePath) && File.ReadAllText(trainingFilePath).Contains(fileHash))
                {
                    continue; // Пропускаємо обробку, якщо файл уже проаналізовано
                }

                // Збираємо базову інформацію про файл
                var fileInfo = new FileInfo(filePath);
                string fileExtension = fileInfo.Extension; // Розширення файлу
                long fileSizeBefore = fileInfo.Length;      // Розмір до обробки

                // Додаємо хеш файлу у файл бази даних
                File.AppendAllText(trainingFilePath, $"#{fileHash}{Environment.NewLine}");

                // Перебираємо всі комбінації алгоритмів шифрування і стиснення
                foreach (var encryption in encryptionAlgorithms)
                {
                    foreach (var compression in compressionAlgorithms)
                    {
                        // Зчитуємо вміст файлу
                        byte[] fileData = File.ReadAllBytes(filePath);

                        // Комбінація: спочатку шифрування, потім стиснення
                        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
                        byte[] encryptedData = encryption.Encrypt(fileData, password);
                        byte[] compressedData = compression.Compress(encryptedData);
                        stopwatch.Stop();

                        // Обчислюємо результати
                        long fileSizeAfter = compressedData.Length;
                        double compressionRatio = (double)fileSizeAfter / fileSizeBefore;
                        long processingTime = stopwatch.ElapsedMilliseconds;

                        // Записуємо результати у файл бази даних
                        string resultEncryptThenCompress = $"{fileExtension}|{fileSizeBefore}|{encryption.Name} -> {compression.Name}|{fileSizeAfter}|{compressionRatio:F2}|{processingTime} мс";
                        File.AppendAllText(trainingFilePath, resultEncryptThenCompress + Environment.NewLine);

                        // Комбінація: спочатку стиснення, потім шифрування
                        stopwatch.Restart();
                        byte[] compressedDataFirst = compression.Compress(fileData);
                        byte[] encryptedDataAfterCompression = encryption.Encrypt(compressedDataFirst, password);
                        stopwatch.Stop();

                        // Обчислюємо результати
                        fileSizeAfter = encryptedDataAfterCompression.Length;
                        compressionRatio = (double)fileSizeAfter / fileSizeBefore;
                        processingTime = stopwatch.ElapsedMilliseconds;

                        // Записуємо результати у файл бази даних
                        string resultCompressThenEncrypt = $"{fileExtension}|{fileSizeBefore}|{compression.Name} -> {encryption.Name}|{fileSizeAfter}|{compressionRatio:F2}|{processingTime} мс";
                        File.AppendAllText(trainingFilePath, resultCompressThenEncrypt + Environment.NewLine);
                    }
                }
            }

            // Повідомляємо користувача про завершення процесу навчання
            MessageBox.Show("Навчання завершено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Метод для обчислення унікального хешу файлу
        private string ComputeFileHash(string filePath)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    var hash = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        // Обробка кнопки "Підбір алгоритму"
        private void button2_Click(object sender, EventArgs e)
        {
            // Отримуємо шлях до файлу
            string filePath = textBox3.Text;

            // Перевіряємо, чи існує файл
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл не знайдено. Введіть коректний шлях.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Збираємо базову інформацію про файл
            var fileInfo = new FileInfo(filePath);
            string fileExtension = fileInfo.Extension; // Розширення файлу
            long fileSize = fileInfo.Length;           // Розмір файлу

            // Зчитуємо базу даних
            string[] databaseLines = File.ReadAllLines("results_database.txt");

            // Фільтруємо записи, які відповідають розширенню файлу
            var similarFiles = new List<FileEntry>();
            string currentHash = null;

            foreach (var line in databaseLines)
            {
                if (line.StartsWith("#"))
                {
                    currentHash = line; // Хеш файлу
                }
                else
                {
                    var parts = line.Split('|');
                    if (parts[0] == fileExtension)
                    {
                        long databaseFileSize = long.Parse(parts[1]);
                        string algorithm = parts[2];
                        long compressedSize = long.Parse(parts[3]);
                        double compressionRatio = double.Parse(parts[4]);
                        long processingTime = long.Parse(parts[5].Replace(" мс", ""));

                        similarFiles.Add(new FileEntry
                        {
                            FileHash = currentHash,
                            FileExtension = fileExtension,
                            FileSize = databaseFileSize,
                            Algorithm = algorithm,
                            CompressedSize = compressedSize,
                            CompressionRatio = compressionRatio,
                            ProcessingTime = processingTime
                        });
                    }
                }
            }

            // Якщо немає подібних файлів, повідомляємо користувача
            if (similarFiles.Count == 0)
            {
                MessageBox.Show("Подібних файлів у базі не знайдено.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Аналізуємо результати з використанням нечіткої логіки
            var fuzzyResults = similarFiles.Select(f =>
            {
                double sizeMembership = GetSizeMembership(f.FileSize, "Medium");
                double timeMembership = GetTimeMembership(f.ProcessingTime, "Fast");
                double score = ApplyFuzzyRules(sizeMembership, timeMembership);

                return new
                {
                    Algorithm = f.Algorithm,
                    Score = score
                };
            }).OrderByDescending(r => r.Score).FirstOrDefault();

            if (fuzzyResults != null)
            {
                // Додаємо пояснення для рейтингу
                string explanation = "Рейтинг обчислюється на основі нечіткої логіки, враховуючи:\n" +
                                     "- Розмір файлу\n" +
                                     "- Час обробки\n" +
                                     "- Комбінацію алгоритмів\n" +
                                     "Чим ближче значення рейтингу до 1.0, тим кращою вважається комбінація для вашого файлу.";

                // Виводимо результат із поясненням
                MessageBox.Show($"Рекомендована комбінація: {fuzzyResults.Algorithm}\nРейтинг: {fuzzyResults.Score:F2}\n\n{explanation}",
                                "Результат",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не вдалося знайти відповідний алгоритм.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        // Функція фазифікації для розміру файлу
        private double GetSizeMembership(long fileSize, string category)
        {
            if (category == "Small")
            {
                return fileSize <= 1000 ? 1.0 : fileSize <= 5000 ? (5000 - fileSize) / 4000.0 : 0.0;
            }
            if (category == "Medium")
            {
                return fileSize > 1000 && fileSize <= 10000 ? (fileSize - 1000) / 9000.0 : fileSize > 10000 && fileSize <= 20000 ? (20000 - fileSize) / 10000.0 : 0.0;
            }
            if (category == "Large")
            {
                return fileSize > 10000 ? 1.0 : 0.0;
            }
            return 0.0;
        }

        // Функція фазифікації для часу обробки
        private double GetTimeMembership(long processingTime, string category)
        {
            if (category == "Fast")
            {
                return processingTime <= 10 ? 1.0 : processingTime <= 50 ? (50 - processingTime) / 40.0 : 0.0;
            }
            if (category == "Moderate")
            {
                return processingTime > 10 && processingTime <= 100 ? (processingTime - 10) / 90.0 : processingTime > 100 && processingTime <= 200 ? (200 - processingTime) / 100.0 : 0.0;
            }
            if (category == "Slow")
            {
                return processingTime > 100 ? 1.0 : 0.0;
            }
            return 0.0;
        }

        // Нечіткі правила для визначення рейтингу
        private double ApplyFuzzyRules(double sizeMembership, double timeMembership)
        {
            // Використовується правило: мінімальне значення ступенів належності
            return Math.Min(sizeMembership, timeMembership);
        }

        // Клас для зберігання інформації про записи у базі
        private class FileEntry
        {
            public string FileHash { get; set; }
            public string FileExtension { get; set; }
            public long FileSize { get; set; }
            public string Algorithm { get; set; }
            public long CompressedSize { get; set; }
            public double CompressionRatio { get; set; }
            public long ProcessingTime { get; set; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Читаємо значення лейблів
            string label5Text = label5.Text;
            string label6Text = label6.Text;

            // Міняємо значення між 1 і 2
            if (label5Text == "1" && label6Text == "2")
            {
                label5.Text = "2";
                label6.Text = "1";
            }
            else
            {
                label5.Text = "1";
                label6.Text = "2";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Зчитуємо шлях до файлу з текстового поля
            string filePath = textBox4.Text;

            // Зчитуємо парольну фразу
            string password = textBox5.Text;

            // Перевірка: чи введено шлях до файлу
            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Шлях до файлу не може бути порожнім.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Перевірка: чи введено парольну фразу
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Парольне слово не може бути порожнім.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Зчитуємо дані з файлу
                byte[] fileData = File.ReadAllBytes(filePath);
                byte[] resultData = null; // Змінна для зберігання результату

                // Отримуємо вибраний алгоритм шифрування (якщо обрано)
                var encryption = (checkBox1.Checked || checkBox2.Checked)
                    ? encryptionAlgorithms.FirstOrDefault(a => a.Name == comboBox1.SelectedItem?.ToString())
                    : null;

                // Отримуємо вибраний алгоритм стиснення (якщо обрано)
                var compression = (checkBox3.Checked || checkBox4.Checked)
                    ? compressionAlgorithms.FirstOrDefault(a => a.Name == comboBox2.SelectedItem?.ToString())
                    : null;

                // Перевірка: чи знайдено вибраний алгоритм шифрування
                if ((checkBox1.Checked || checkBox2.Checked) && encryption == null)
                {
                    MessageBox.Show("Не знайдено вибраного алгоритму шифрування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Перевірка: чи знайдено вибраний алгоритм стиснення
                if ((checkBox3.Checked || checkBox4.Checked) && compression == null)
                {
                    MessageBox.Show("Не знайдено вибраного алгоритму архівування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Виконання обраних дій
                if (checkBox1.Checked && checkBox3.Checked) // Шифрування + архівування
                {
                    if (label5.Text == "1") // Спочатку шифрування, потім стиснення
                    {
                        resultData = encryption.Encrypt(fileData, password); // Шифрування
                        resultData = compression.Compress(resultData); // Стиснення
                    }
                    else // Спочатку стиснення, потім шифрування
                    {
                        resultData = compression.Compress(fileData); // Стиснення
                        resultData = encryption.Encrypt(resultData, password); // Шифрування
                    }
                }
                else if (checkBox2.Checked && checkBox4.Checked) // Розшифрування + розархівування
                {
                    if (label5.Text == "1") // Спочатку розшифрування, потім розархівування
                    {
                        resultData = encryption.Decrypt(fileData, password); // Розшифрування
                        resultData = compression.Decompress(resultData); // Розархівування
                    }
                    else // Спочатку розархівування, потім розшифрування
                    {
                        resultData = compression.Decompress(fileData); // Розархівування
                        resultData = encryption.Decrypt(resultData, password); // Розшифрування
                    }
                }
                else if (checkBox1.Checked) // Тільки шифрування
                {
                    resultData = encryption.Encrypt(fileData, password);
                }
                else if (checkBox2.Checked) // Тільки розшифрування
                {
                    resultData = encryption.Decrypt(fileData, password);
                }
                else if (checkBox3.Checked) // Тільки стиснення
                {
                    resultData = compression.Compress(fileData);
                }
                else if (checkBox4.Checked) // Тільки розархівування
                {
                    resultData = compression.Decompress(fileData);
                }

                // Збереження результату у файл
                string outputFilePath = Path.Combine(
                    Path.GetDirectoryName(filePath),
                    Path.GetFileNameWithoutExtension(filePath) + "_processed" + Path.GetExtension(filePath)
                );
                File.WriteAllBytes(outputFilePath, resultData);

                // Повідомлення про успішну обробку
                MessageBox.Show($"Файл успішно оброблено та збережено: {outputFilePath}", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Повідомлення про помилку
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
