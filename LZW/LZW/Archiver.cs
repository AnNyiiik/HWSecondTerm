using System.Text;

using HW2_Bor;

namespace LZW;

public class Archiver
{
    private Trie alphabet;
    public Archiver()
    {
        alphabet = new Trie();
        
        for (int i = 0; i < 256; ++i)
        {
            alphabet.Add(((char)i).ToString());
        }
        
    }

    public string ArchiveFile(string path)
    {
        var countBytes = 0;
        string fileZipped;
        try
        {
            using (var fileReader = new StreamReader(path))
            {
                var buffer = new List<byte>();
                fileZipped = path.Substring(0, path.LastIndexOf('.')) + ".zipped";
                using (var fileStreamWriter = new BinaryWriter(File.Create(fileZipped), Encoding.UTF8))
                {
                    while (fileReader.Peek() >= 0)
                    {
                        var characterCode = (byte)fileReader.Read();
                        buffer.Add(characterCode);
                        var currentWord = Encoding.Default.GetString(buffer.ToArray());
                        if (alphabet.Add(currentWord))
                        {
                            var code = alphabet.GetCode(currentWord.Substring(0,
                                currentWord.Length - 1));
                            if (code != null)
                            {
                                var bytes = BitConverter.GetBytes((int)code);

                                fileStreamWriter.Write(bytes[1]);
                                fileStreamWriter.Write(bytes[0]);
                                countBytes += 2;
                            }

                            buffer.Clear();
                            buffer.Add(characterCode);
                        }

                        if (fileReader.Peek() < 0)
                        {
                            var code = alphabet.GetCode(Encoding.UTF8.GetString(buffer.ToArray()));
                            if (code != null)
                            {
                                var bytes = BitConverter.GetBytes((int)code);

                                fileStreamWriter.Write(bytes[1]);
                                fileStreamWriter.Write(bytes[0]);
                                countBytes += 2;
                            }
                        }
                    }
                }
            }
        }
        catch (ArgumentException e1)
        {
            throw new ArgumentException();
        }
        catch (FileNotFoundException e2)
        {
            throw new FileNotFoundException();
        }

        catch (IOException e3)
        {
            throw new IOException();
        }

        try
        {
            using (var input = File.Open(path, FileMode.Open))
            {
                if (countBytes == 0)
                {
                    Console.WriteLine("Something went wrong.");
                }
                else
                {
                    Console.WriteLine("The compression coefficient is {0}", (double)input.Length / countBytes);
                }
            }
        }
        catch (IOException e)
        {
            throw new IOException();
        }

        return fileZipped;
    }
} 