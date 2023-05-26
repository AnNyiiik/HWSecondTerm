using Game;

var eventLoop = new EventLoop();
var game = new Game.Game("../../../../Game/Map.txt");
eventLoop.StartGame += game.OnStart;
eventLoop.LeftHandler += game.OnLeft;
eventLoop.RightHandler += game.OnRight;
eventLoop.UpHandler += game.OnTop;
eventLoop.DownHandler += game.OnBottom;
eventLoop.Run();