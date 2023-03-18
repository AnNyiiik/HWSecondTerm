using System.Text;

namespace LZW;

public class Dearchivator
{
    private Dictionary<int, string> dictionary;

    public Dearchivator()
    {
        dictionary = new Dictionary<int, string>();
        for (int i = 0; i < 256; ++i)
        {
            dictionary.Add(i, ((char)i).ToString());
        }
    }
    
    public bool UnzipFile(string path)
    {
        var fileUnzipped = path.Substring(0, path.IndexOf('.'));
        try
        {
            using (var fileStreamWriter = new StreamWriter(File.Create(fileUnzipped), Encoding.UTF8))
            {
                var bytes = File.ReadAllBytes(path);
                var numberOfCurrentByte = 0;
                var currentWord = new StringBuilder();
                var currentSequence = new StringBuilder();
                while (numberOfCurrentByte < bytes.Length - 1)
                {
                    var code = 256 * bytes[numberOfCurrentByte]
                               + bytes[numberOfCurrentByte + 1];
                    
                    if (!dictionary.ContainsKey(code))
                    {
                        var newWord = currentWord.Append(currentWord.ToString().Substring(0, 1)).
                                ToString();
                        dictionary.Add(code, newWord);
                        fileStreamWriter.Write(newWord);
                    }
                    else   
                    {
                        currentSequence.Append(dictionary[code]);
                        currentWord.Append(dictionary[code].Substring(0, 1));
                        fileStreamWriter.Write(dictionary[code]);
                    }
                    if (!dictionary.ContainsValue(currentWord.ToString()))
                    {
                        code = dictionary.Count;
                        dictionary.Add(code, currentWord.ToString());
                        currentWord.Clear();
                        currentWord.Append(currentSequence);
                    }
                    numberOfCurrentByte += 2;
                    currentSequence.Clear();
                }
            }
            
        }
        catch (ArgumentException e)
        {
            return false;
        }

        return true;
    }
}