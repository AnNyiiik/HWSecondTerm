using Game;

namespace UnitTests;

public class Tests
{
    private event EventHandler<EventArgs> LeftHandler = (sender, args) => { };
    private event EventHandler<EventArgs> RightHandler = (sender, args) => { };
    private event EventHandler<EventArgs> UpHandler = (sender, args) => { };
    private event EventHandler<EventArgs> DownHandler = (sender, args) => { };
    private Game.Game game;

    [SetUp]
    public void SetUp()
    {
        game = new Game.Game("../../../../UnitTests/MapCheckCorrectness.txt");
        LeftHandler += (sender, args) =>
        {
            if (game.IsStepPossible(Game.Game.Direction.Left))
            {
                game.CurrentPositionX -= 1;
            }
        };
        
        RightHandler += (sender, args) =>
        {
            if (game.IsStepPossible(Game.Game.Direction.Right))
            {
                game.CurrentPositionX += 1;
            }
        };
        
        UpHandler += (sender, args) =>
        {
            if (game.IsStepPossible(Game.Game.Direction.Up))
            {
                game.CurrentPositionY -= 1;
            }
        };
        
        DownHandler += (sender, args) =>
        {
            if (game.IsStepPossible(Game.Game.Direction.Down))
            {
                game.CurrentPositionY += 1;
            }
        };
    }
    
    [Test]
    public void ShouldNotGoThroughWallAndShouldGoIfVacant()
    {
        var X = game.CurrentPositionX;
        var Y = game.CurrentPositionY;
        UpHandler(this, EventArgs.Empty);
        Assert.That((game.CurrentPositionX, game.CurrentPositionY), Is.EqualTo((X, Y)));
        LeftHandler(this, EventArgs.Empty);
        Assert.That((game.CurrentPositionX, game.CurrentPositionY), Is.EqualTo((X, Y)));
        for (var i = 0; i < 3; ++i)
        {
            RightHandler(this, EventArgs.Empty);
            Assert.That((game.CurrentPositionX, game.CurrentPositionY), Is.EqualTo((++X, Y)));
        }
        RightHandler(this, EventArgs.Empty);
        Assert.That((game.CurrentPositionX, game.CurrentPositionY), Is.EqualTo((X, Y)));
        for (var i = 0; i < 2; ++i)
        {
            DownHandler(this, EventArgs.Empty);
            Assert.That((game.CurrentPositionX, game.CurrentPositionY), Is.EqualTo((X, ++Y)));
        }
        DownHandler(this, EventArgs.Empty);
        Assert.That((game.CurrentPositionX, game.CurrentPositionY), Is.EqualTo((X, Y)));
    }
}