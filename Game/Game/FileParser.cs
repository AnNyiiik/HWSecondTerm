namespace Game;

public class FileParser
{
    private string _mapPath;

    public string[] Map { get; }

    public FileParser(string path)
    {
        _mapPath = path;
        Map = File.ReadAllLines(_mapPath);
        if (Map.Length == 0)
        {
            throw new ArgumentException("empty map");
        }

        if (Map.Length <= 2)
        {
            throw new ArgumentException("incorrect data");
        }
        var lengthFirst = Map[0].Length;
        if (lengthFirst < 3)
        {
            throw new ArgumentException("incorrect data");
        }
        foreach (var str in Map)
        {
            if (str.Length != lengthFirst)
            {
                throw new ArgumentException("incorrect data input");
            }
        }

        if (Map[1][1] != '@')
        {
            throw new ArgumentException("incorrect data input");
        }

        var countAtPoint = 0;
        foreach (var str in Map)
        {
            foreach (var character in str)
            {
                if (character == '@')
                {
                    ++countAtPoint;
                    if (countAtPoint > 1)
                    {
                        throw new ArgumentException("incorrect data");
                    }
                }
                if (character != '*' && character != ' ' && character != '@')
                {
                    throw new ArgumentException("incorrect data");
                }
            }
        }
        for (var i = 0; i < lengthFirst; ++i) 
        {
            if (Map[0][i] != '*' || Map[Map.Length - 1][i] != '*')
            {
                throw new ArgumentException("incorrect data input");
            }
        }
        for (var i = 0; i < Map.Length; ++i) 
        {
            if (Map[i][0] != '*' || Map[i][lengthFirst - 1] != '*')
            {
                throw new ArgumentException("incorrect data input");
            }
        }
    }
}
//проверка по содержимому карты