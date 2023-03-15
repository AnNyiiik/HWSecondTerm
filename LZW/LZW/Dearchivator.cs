using System.Text;

using HW2_Bor;

namespace LZW;

public class Dearchivator
{
    private Trie alphabet;

    public Dearchivator()
    {
        alphabet = new Trie();
        for (byte i = 0; i < 255; ++i)
        {
            alphabet.Add(((char)i).ToString());
        }
    }
    
    public void UnzipFile(string path)
    {
        var fileUnzipped = path.Substring(0, path.IndexOf('.')) + ".txt";
        var bytes = File.ReadAllBytes(path);
        var dictionary = new Dictionary<int, string>();
        for (byte i = 0; i < 255; ++i)
        {
            dictionary.Add(i, ((char)i).ToString());
        }
        using (var fileStreamWriter = new StreamWriter(File.Create(fileUnzipped), Encoding.ASCII))
        {
            var numberOfCurrentByte = 0;
            var currentWord = new StringBuilder();
            var currentSequence = new StringBuilder();
            while (numberOfCurrentByte < bytes.Length)
            {
                if (numberOfCurrentByte < bytes.Length - 1 && dictionary.ContainsKey(16 * bytes[numberOfCurrentByte] 
                        + bytes[numberOfCurrentByte + 1]))
                {
                    currentSequence.Append(
                        dictionary[16 * bytes[numberOfCurrentByte] + bytes[numberOfCurrentByte + 1]]);
                    currentWord.Append(dictionary[16 * bytes[numberOfCurrentByte] + bytes[numberOfCurrentByte + 1]]
                            .Substring(0, 1));
                    Console.WriteLine(dictionary[16 * bytes[numberOfCurrentByte] + bytes[numberOfCurrentByte + 1]]);
                    ++numberOfCurrentByte;
                }
                else
                {
                    Console.WriteLine(dictionary[bytes[numberOfCurrentByte]]);
                    currentWord.Append(dictionary[bytes[numberOfCurrentByte]].Substring(0, 1));
                    currentSequence.Append(dictionary[bytes[numberOfCurrentByte]]);
                }
                if (!dictionary.ContainsValue(currentWord.ToString()))
                {
                    alphabet.Add(currentWord.ToString());
                    //Console.WriteLine(currentWord.ToString().Substring(0, currentWord.Length - 1));
                    var code = alphabet.GetCode(currentWord.ToString());
                    dictionary.Add((int)code, currentWord.ToString());
                    currentWord.Clear();
                    currentWord.Append(currentSequence);
                }
                currentSequence.Clear();
                ++numberOfCurrentByte;
                if (numberOfCurrentByte == bytes.Length)
                {
                    Console.WriteLine(currentWord.ToString().Substring(0, currentWord.Length - 1));
                }
            }
        }
    }
}