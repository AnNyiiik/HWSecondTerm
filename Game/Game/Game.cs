using System.Text;

namespace Game;

using System.IO;

public class Game
{
    private int _currentPositionX;

    private int _currentPositionY;

    public int CurrentPositionX { get => _currentPositionX; set => _currentPositionX = value; }
    
    public int CurrentPositionY { get => _currentPositionY; set => _currentPositionY = value; }

    private string[] _map;

    public Game(string mapPath)
    {
        _map = File.ReadAllLines(mapPath);
        if (_map.Length == 0)
        {
            throw new ArgumentException("empty map");
        }

        _currentPositionX = 1;
        _currentPositionY = 2;
        CurrentPositionX = _currentPositionX;
        CurrentPositionY = _currentPositionY;
    }

    public enum Direction
    {
        Up,
        Left,
        Down,
        Right
    }

    private void MoveCharacter(Direction direction)
    {
        Console.CursorLeft = _currentPositionX;
        Console.CursorTop = _currentPositionY;
        Console.Write(' ');
        Console.CursorLeft = _currentPositionX;
        switch (direction)
        {
            case Direction.Left:
                Console.CursorLeft = _currentPositionX - 1;
                _currentPositionX -= 1;
                Console.Write('@');
                break;
            case Direction.Up:
                Console.CursorTop = _currentPositionY - 1;
                _currentPositionY -= 1;
                Console.Write('@');
                break;
            case Direction.Right:
                Console.CursorLeft = _currentPositionX + 1;
                _currentPositionX += 1;
                Console.Write('@');
                break;
            case Direction.Down:
                Console.CursorTop = _currentPositionY + 1;
                _currentPositionY += 1;
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

    public bool IsStepPossible(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                if (_map[_currentPositionY - 1][_currentPositionX - 1] != '*')
                {
                    return true;
                }
                break;
            case Direction.Up:
                if (_map[_currentPositionY - 2][_currentPositionX] != '*')
                {
                    return true;
                }
                break;
            case Direction.Right:
                if (_map[_currentPositionY - 1][_currentPositionX + 1] != '*')
                {
                    return true;
                }
                break;
            case Direction.Down:
                if (_map[_currentPositionY][_currentPositionX] != '*')
                {
                    return true;
                }
                break;
        }

        return false;
    }
    
    public void OnLeft(object? sender, EventArgs args)
    {
        if (_map[_currentPositionY - 1][_currentPositionX - 1] != '*')
        {
            MoveCharacter(Direction.Left);
        }
    }
    
    public void OnRight(object? sender, EventArgs args)
    {
        if (_map[_currentPositionY - 1][_currentPositionX + 1] != '*')
        {
            MoveCharacter(Direction.Right);
        }
    }

    public void OnTop(object? sender, EventArgs args)
    {
        if (_map[_currentPositionY - 2][_currentPositionX] != '*')
        {
            MoveCharacter(Direction.Up);
        }
    }

    public void OnBottom(object? sender, EventArgs args)
    {
        if (_map[_currentPositionY][_currentPositionX] != '*')
        {
            MoveCharacter(Direction.Down);
        }
    }
}

// вынести в отдельный класс логику построения карты
// auto implemented properties
// нельзя публичный сеттер
// переименовать тестовые классы и файлы
// добавить комментарии
// убрать магические константы из тестов
// проверить карту на корректность