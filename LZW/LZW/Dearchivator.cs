using System.Text;

using HW2_Bor;

namespace LZW;

public class Dearchivator
{
    private Dictionary<int, string> dictionary;

    public Dearchivator()
    {
        dictionary = new Dictionary<int, string>();
        for (byte i = 0; i < 255; ++i)
        {
            dictionary.Add(i, ((char)i).ToString());
        }
    }
    
    public void UnzipFile(string path)
    {
        var fileUnzipped = path.Substring(0, path.IndexOf('.')) + ".txt";
        var bytes = File.ReadAllBytes(path);
        using (var fileStreamWriter = new StreamWriter(File.Create(fileUnzipped), Encoding.ASCII))
        {
            var numberOfCurrentByte = 0;
            var currentWord = new StringBuilder();
            var currentSequence = new StringBuilder();
            while (numberOfCurrentByte < bytes.Length)
            {
                if (numberOfCurrentByte < bytes.Length - 1 && dictionary.ContainsKey(256 * bytes[numberOfCurrentByte] 
                        + bytes[numberOfCurrentByte + 1]))
                {
                    var code = 256 * bytes[numberOfCurrentByte]
                              + bytes[numberOfCurrentByte + 1];
                    currentSequence.Append(
                        dictionary[code]);
                    currentWord.Append(dictionary[code]
                            .Substring(0, 1));
                    fileStreamWriter.Write(dictionary[code]);
                    ++numberOfCurrentByte;
                }
                else
                {
                    fileStreamWriter.Write(dictionary[bytes[numberOfCurrentByte]]);
                    currentWord.Append(dictionary[bytes[numberOfCurrentByte]].Substring(0, 1));
                    currentSequence.Append(dictionary[bytes[numberOfCurrentByte]]);
                }
                if (!dictionary.ContainsValue(currentWord.ToString()))
                {
                    var code = dictionary.Count;
                    dictionary.Add(code, currentWord.ToString());
                    currentWord.Clear();
                    currentWord.Append(currentSequence);
                }
                
                ++numberOfCurrentByte;
                currentSequence.Clear();
            }
        }
    }
}