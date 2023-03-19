namespace LZW.Tests;

public class Tests
{
    private static IEnumerable<TestCaseData> IncorrectPaths
        => new TestCaseData[]
        {
            new TestCaseData("*/278398/###+-"),
            new TestCaseData("./bebebebe/aaaa.txt"),
        };
    
    
    [TestCaseSource(nameof(IncorrectPaths))]
    public void IncorrectPathPassedShouldThrowIOException(string path)
    {
        var archiver = new Archiver();
        Assert.Throws<IOException>(() => archiver.ArchiveFile(path));
    }

    private static IEnumerable<TestCaseData> NotExistingFiles
        => new TestCaseData[]
        {
            new TestCaseData("../../../../LZWTest/File1.txt"),
            new TestCaseData("../../../../LZWTest/File2.txt")
        };

    [TestCaseSource(nameof(NotExistingFiles))]
    public void NotExistingFileShouldThrowFileNotFoundException(string path)
    {
        var archiver = new Archiver();
        Assert.Throws<FileNotFoundException>(() => archiver.ArchiveFile(path));
    } 
    
    [Test]
    public void DecompressionShouldReturnTheCopyOfCompressedFile()
    {
        var pathToArchive = "../../../../LZWTest/TestData.txt";
        var archiver = new Archiver();
        var pathZipped = archiver.ArchiveFile(pathToArchive);
        var dearchiver = new Dearchivator();
        var pathUnzipped = dearchiver.UnzipFile(pathZipped);
        var stringsInput = File.ReadAllLines(pathToArchive);
        var stringsOut = File.ReadAllLines(pathUnzipped);
        Assert.That(stringsInput.Length, Is.EqualTo(stringsOut.Length));
        for (var i = 0; i < stringsInput.Length; ++i)
        {
            Assert.That(stringsInput[i], Is.EqualTo(stringsOut[i]));
        }
    }
}