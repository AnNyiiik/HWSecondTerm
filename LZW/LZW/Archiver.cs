using System.Text;

using HW2_Bor;

namespace LZW;

public class Archiver
{
    private Trie alphabet;

    public Archiver()
    {
        alphabet = new Trie();
        for (byte i = 0; i < 255; ++i)
        {
            alphabet.Add(((char)i).ToString());
        }
    }

    public void ArchiveFile(string path)
    {
        using (var fileReader = new StreamReader(path))
        {
            var fileZipped = path.Substring(0, path.IndexOf('.')) + ".zipped";
            var buffer = new List<byte>();
            using (var fileStreamWriter = new BinaryWriter(File.Create(fileZipped), Encoding.ASCII))
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
                            if (code < 256)
                            {
                                fileStreamWriter.Write(bytes[0]);
                            } else 
                            {
                                fileStreamWriter.Write(bytes[1]);
                                fileStreamWriter.Write(bytes[0]);
                            } 
                            Console.WriteLine(BitConverter.ToString(bytes));
                        }

                        buffer.Clear();
                        buffer.Add(characterCode);
                    }

                    if (fileReader.Peek() < 0)
                    {
                        var code = alphabet.GetCode(Encoding.ASCII.GetString(buffer.ToArray()));
                        if (code != null)
                        {
                            var bytes = BitConverter.GetBytes((int)code);
                            if (code < 256)
                            {
                                Console.WriteLine(BitConverter.ToString(new[] { bytes[0] }));
                                fileStreamWriter.Write(bytes[0]);
                            } else if (code < 512)
                            {
                                Console.WriteLine(BitConverter.ToString(new[] { bytes[1], bytes[0] }));
                                fileStreamWriter.Write(bytes[1]);
                                fileStreamWriter.Write(bytes[0]);
                            }
                        }
                    }
                }
            }
        }
    }
}