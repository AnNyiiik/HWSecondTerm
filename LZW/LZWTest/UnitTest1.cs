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

    /*private static IEnumerable<TestCaseData> NotExistingFiles
        => new TestCaseData[]
        {
            new TestCaseData(/Users/annnikolaeff/MyFolder/HWSecondTerm/HW2_Bor/HW2_Bor/Trie),
            new TestCaseData()
        };

    [TestCaseSource(nameof(NotExistingFiles))]
    public void NotExistingFileShouldThrowFileNotFoundException(string path)
    {
        var archiver = new Archiver();
        Assert.Throws<FileNotFoundException>(() => archiver.ArchiveFile(path));
    } */
    
    [Test]
    public void DecompressionShouldReturnTheCopyOfCompressedFile()
    {
        var pathToArchive = "/Users/annnikolaeff/MyFolder/HWSecondTerm/HW2_Bor/HW2_Bor/Trie.cs";
        var pathToDecompress = "/Users/annnikolaeff/MyFolder/HWSecondTerm/HW2_Bor/HW2_Bor/Trie" + ".zipped";
        var archiver = new Archiver();
        archiver.ArchiveFile(pathToArchive);
        var dearchiver = new Dearchivator();
        dearchiver.UnzipFile(pathToDecompress);
        var pathUnzipped = "/Users/annnikolaeff/MyFolder/HWSecondTerm/HW2_Bor/HW2_Bor/Trie";
        var stringsInput = File.ReadAllLines(pathToArchive);
        var stringsOut = File.ReadAllLines(pathUnzipped);
        Assert.That(stringsInput.Length, Is.EqualTo(stringsOut.Length));
        for (var i = 0; i < stringsInput.Length; ++i)
        {
            Assert.That(stringsInput[i], Is.EqualTo(stringsOut[i]));
        }
    }
}