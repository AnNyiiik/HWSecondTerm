using System.Text;

namespace Game;

using System.IO;

public class Game
{
    private FileParser _parser;

    public int CurrentPositionX { get; private set; }
    
    public int CurrentPositionY { get; private set; }

    private string[] _map;

    public Game(string mapPath)
    {
        _parser = new FileParser(mapPath);
        _map = _parser.Map;
        CurrentPositionX = 1;
        CurrentPositionY = 2;
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
        Console.CursorLeft = CurrentPositionX;
        Console.CursorTop = CurrentPositionY;
        Console.Write(' ');
        Console.CursorLeft = CurrentPositionX;
        switch (direction)
        {
            case Direction.Left:
                Console.CursorLeft = CurrentPositionX - 1;
                CurrentPositionX -= 1;
                Console.Write('@');
                break;
            case Direction.Up:
                Console.CursorTop = CurrentPositionY - 1;
                CurrentPositionY -= 1;
                Console.Write('@');
                break;
            case Direction.Right:
                Console.CursorLeft = CurrentPositionX + 1;
                CurrentPositionX += 1;
                Console.Write('@');
                break;
            case Direction.Down:
                Console.CursorTop = CurrentPositionY + 1;
                CurrentPositionY += 1;
                Console.Write('@');
                break;
        }
    }

    /// <summary>
    /// Write the initial map on the console.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void OnStart(object? sender, EventArgs args)
    {
        var lines = new StringBuilder();
        foreach (var line in _map)
        {
            lines.AppendLine(line);
        }
        Console.WriteLine(lines.ToString());
    }
    
    /// <summary>
    /// Move the player to the left side on the Console if it's possible.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void OnLeft(object? sender, EventArgs args)
    {
        if (_map[CurrentPositionY - 1][CurrentPositionX - 1] != '*')
        {
            MoveCharacter(Direction.Left);
        }
    }
    
    /// <summary>
    /// Move the player to the right side on the Console if it's possible.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void OnRight(object? sender, EventArgs args)
    {
        if (_map[CurrentPositionY - 1][CurrentPositionX + 1] != '*')
        {
            MoveCharacter(Direction.Right);
        }
    }

    /// <summary>
    /// Move the player to the top on the Console if it's possible.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void OnTop(object? sender, EventArgs args)
    {
        if (_map[CurrentPositionY - 2][CurrentPositionX] != '*')
        {
            MoveCharacter(Direction.Up);
        }
    }

    /// <summary>
    /// Move the player to the bottom side on the Console if it's possible.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void OnBottom(object? sender, EventArgs args)
    {
        if (_map[CurrentPositionY][CurrentPositionX] != '*')
        {
            MoveCharacter(Direction.Down);
        }
    }
}

// переименовать тестовые классы и файлы
// убрать магические константы из тестов
// проверить карту на корректность