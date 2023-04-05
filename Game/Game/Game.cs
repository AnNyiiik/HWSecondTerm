using System.Text;

namespace Game;

using System.IO;

public class Game
{
    private (int x , int y) _currentPosition;
    
    private string[] _map;

    public Game()
    {
        try
        {
            _map = File.ReadAllLines("/Users/annnikolaeff/" +
                                        "MyFolder/HWSecondTerm/Game/Game/Map.txt");
            if (_map.Length == 0)
            {
                throw new ArgumentException("empty map");
            }
            _currentPosition = (1, 1);
        }
        catch (IOException e)
        {
            throw new IOException();
        }
    }

    private enum Direction
    {
        Up,
        Left,
        Down,
        Right
    }

    private void MoveCharacter(Direction direction)
    {
        Console.CursorLeft = _currentPosition.x;
        Console.CursorTop = _currentPosition.y + 1;
        Console.Write(' ');
        switch (direction)
        {
            case Direction.Left:
                Console.CursorLeft = _currentPosition.x - 1;
                _currentPosition.x -= 1;
                Console.Write('@');
                break;
            case Direction.Up:
                Console.CursorTop = _currentPosition.y - 1;
                _currentPosition.y -= 1;
                Console.Write('@');
                break;
            case Direction.Right:
                Console.CursorLeft = _currentPosition.x + 1;
                _currentPosition.x += 1;
                Console.Write('@');
                break;
            case Direction.Down:
                Console.CursorTop = _currentPosition.y + 1;
                _currentPosition.y += 1;
                Console.Write('@');
                break;
        }
    }

    public void OnStart(object? sender, EventArgs args)
    {
        var lines = new StringBuilder();
        foreach (var line in _map)
        {
            lines.AppendLine(line);
        }
        Console.WriteLine(lines.ToString());
    }
    
    public void OnLeft(object? sender, EventArgs args)
    {
        if (_map[_currentPosition.y][_currentPosition.x - 1] != '*')
        {
            MoveCharacter(Direction.Left);
        }
    }
    public void OnRight(object? sender, EventArgs args)
    {
        if (_map[_currentPosition.y][_currentPosition.x + 1] != '*')
        {
            MoveCharacter(Direction.Right);
        }
    }

    public void OnTop(object? sender, EventArgs args)
    {
        if (_map[_currentPosition.y - 1][_currentPosition.x] != '*')
        {
            MoveCharacter(Direction.Up);
        }
    }
    
    public void OnBottom(object? sender, EventArgs args)
    {
        if (_map[_currentPosition.y + 1][_currentPosition.x] != '*')
        {
            MoveCharacter(Direction.Down);
        }
    }
}