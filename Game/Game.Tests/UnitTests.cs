using Game;

namespace UnitTests;

public class Tests
{
    private Game.Game game;

    [SetUp]
    public void SetUp()
    {
        game = new Game.Game("Game.Tests../UnitTests/MapCheckCorrectness.txt");
    }
    
    [Test]
    public void ShouldNotGoThroughWallAndShouldGoIfVacant()
    {
        var X = game.CurrentPositionX;
        var Y = game.CurrentPositionY;
        game.OnTop(null, EventArgs.Empty);
        Assert.That((game.CurrentPositionX, game.CurrentPositionY), Is.EqualTo((X, Y)));
        game.OnLeft(null, EventArgs.Empty);
        Assert.That((game.CurrentPositionX, game.CurrentPositionY), Is.EqualTo((X, Y)));
        for (var i = 0; i < 3; ++i)
        {
            game.OnRight(null, EventArgs.Empty);
            Assert.That((game.CurrentPositionX, game.CurrentPositionY), Is.EqualTo((++X, Y)));
        }
        game.OnRight(null, EventArgs.Empty);
        Assert.That((game.CurrentPositionX, game.CurrentPositionY), Is.EqualTo((X, Y)));
        for (var i = 0; i < 2; ++i)
        {
            game.OnBottom(null, EventArgs.Empty);
            Assert.That((game.CurrentPositionX, game.CurrentPositionY), Is.EqualTo((X, ++Y)));
        }
        game.OnBottom(null, EventArgs.Empty);
        Assert.That((game.CurrentPositionX, game.CurrentPositionY), Is.EqualTo((X, Y)));
    }
}