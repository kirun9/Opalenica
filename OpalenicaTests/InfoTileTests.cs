namespace OpalenicaTests;

using NUnit.Framework;

using Opalenica.Tiles;

public class InfoTileTestsEmpty
{
    [Test]
    [TestOf(nameof(InfoTile.GetMessagesByTag))]
    public void GetMessagesByTagWhileEmpty()
    {
        var messages = InfoTile.GetMessagesByTag("tag1");
        Assert.Pass();
    }

    [Test]
    [TestOf(nameof(InfoTile.CountMessagesByTag))]
    public void CountMessagesByTagWhileEmpty()
    {
        var messages = InfoTile.CountMessagesByTag("tag1");
        Assert.Pass();
    }

    [Test]
    [TestOf(nameof(InfoTile.GetMessageByTag))]
    public void GetMessageByTagWhileEmpty()
    {
        var messages = InfoTile.GetMessageByTag("tag1");
        Assert.Pass();
    }
}

public class InfoTileTests
{
    List<int> ids = new List<int>();

    [OneTimeSetUp]
    public void SetUp()
    {
        ids.Add(InfoTile.AddInfo("Sample Error", MessageSeverity.Error, new[] { "tag1", "tag2" }));
        ids.Add(InfoTile.AddInfo("Sample Information", MessageSeverity.Help, new[] { "tag1", "tag3" }));
        ids.Add(InfoTile.AddInfo("Sample Help info", MessageSeverity.Help, new[] { "tag2", "tag3" }));
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        foreach (var id in ids)
        {
            InfoTile.RemoveInfo(id);
        }
        ids.Clear();
    }

    [Test]
    [TestOf(nameof(InfoTile.GetMessagesByTag))]
    public void GetMessagesByTag()
    {
        var messages = InfoTile.GetMessagesByTag(new[] { "tag1", "tag2" });

        Assert.That(messages.Count(), Is.EqualTo(1));
    }

    [Test]
    [TestOf(nameof(InfoTile.GetMessagesByTag))]
    public void GetMessagesByTag2()
    {
        var messages = InfoTile.GetMessagesByTag(new[] { "tag1" });

        Assert.That(messages.Count(), Is.EqualTo(2));
    }

    [Test]
    [TestOf(nameof(InfoTile.GetMessagesByTag))]
    public void GetMessagesByTag3()
    {
        var messages = InfoTile.GetMessagesByTag("tag1");

        Assert.That(messages.Count(), Is.EqualTo(2));
    }

    [Test]
    [TestOf(nameof(InfoTile.GetMessageByTag))]
    public void GetMessageByTag()
    {
        var message = InfoTile.GetMessageByTag("tag1");
        var messages = InfoTile.GetMessagesByTag("tag1");

        var isEqual = message.Equals(messages.First());

        Assert.That(isEqual, Is.True);
    }

    [Test]
    [TestOf(nameof(InfoTile.CountMessagesByTag))]
    public void CountMessagesByTag()
    {
        var count = InfoTile.CountMessagesByTag(new[] { "tag1", "tag2" });

        Assert.That(count, Is.EqualTo(1));
    }

    [Test]
    [TestOf(nameof(InfoTile.CountMessagesByTag))]
    public void CountMessagesByTag2()
    {
        var count = InfoTile.CountMessagesByTag(new[] { "tag1" });

        Assert.That(count, Is.EqualTo(2));
    }

    [Test]
    [TestOf(nameof(InfoTile.CountMessagesByTag))]
    public void CountMessagesByTag3()
    {
        var count = InfoTile.CountMessagesByTag("tag1");

        Assert.That(count, Is.EqualTo(2));
    }
}