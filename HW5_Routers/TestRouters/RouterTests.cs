using HW5_Routers;

namespace TestRouters;

public class Tests
{
    [Test]
    public void TestCaseCorrect()
    {
        var graph = FileHandler.BuildGraphFromData("../../../../TestRouters/FileInput.txt");
        var result = graph.PrintMaxSpanningTree();
        FileHandler.WriteDataToFile(result, "../../../../TestRouters/FileOutput.txt");
        var lines = File.ReadAllLines("../../../../TestRouters/FileOutput.txt");
        var correctLines = File.ReadAllLines("../../../../TestRouters/FileCorrectAnswer.txt");
        Assert.That(lines.Length, Is.EqualTo(correctLines.Length));
        for (var i = 0; i < lines.Length; ++i)
        {
            Assert.That(String.Compare(lines[i], correctLines[i]) == 0);
        }
    }

    [Test]
    public void TestIncorrectDataFormatShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => 
            FileHandler.BuildGraphFromData("../../../../TestRouters/IncorrectDataFormatFile.txt"));
    }

    [Test]
    public void TestIncorrectPathShouldThrowException()
    {
        Assert.Throws<FileNotFoundException>(() => 
            FileHandler.BuildGraphFromData("../../../../TestRouters/NotExistingFile.txt"));
    }
}