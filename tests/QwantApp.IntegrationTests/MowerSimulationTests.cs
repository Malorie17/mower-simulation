namespace QwantApp.IntegrationTests;

public class MowerSimulationTests
{
    private const string TestInputFileName = "test_input.txt";

    [SetUp]
    public void Setup()
    {
        string content = @"5 5
1 2 N
LFLFLFLFF
3 3 E
FFRFFRFRRF";
        File.WriteAllText(TestInputFileName, content);
    }

    [Test]
    public async Task FullSimulation_ShouldProduceCorrectFinalPositions()
    {
        //Given
        var lines = (await File.ReadAllLinesAsync(TestInputFileName)).ToList();
        var lawnDimensions = lines[0].Split(' ');
        var maxX = int.Parse(lawnDimensions[0]);
        var maxY = int.Parse(lawnDimensions[1]);
        var lawn = new Lawn(maxX, maxY);
        var mowers = new List<Mower>();
        for (var i = 1; i < lines.Count; i += 2)
        {
            var posAndOrientation = lines[i].Split(' ');
            var startX = int.Parse(posAndOrientation[0]);
            var startY = int.Parse(posAndOrientation[1]);
            var orientation = Enum.Parse<Orientation>(posAndOrientation[2]);
            var instructions = lines[i + 1];

            mowers.Add(new Mower(mowers.Count + 1, startX, startY, orientation, instructions, lawn));
        }

        //When
        var mowerTasks = mowers.Select(m => m.Execute()).ToList();
        await Task.WhenAll(mowerTasks);

        //Then
        Assert.That(mowers[0].CurrentPosition, Is.EqualTo(new Point(1, 3)));
        Assert.That(mowers[0].Orientation, Is.EqualTo(Orientation.N));
        Assert.That(mowers[1].CurrentPosition, Is.EqualTo(new Point(5, 1)));
        Assert.That(mowers[1].Orientation, Is.EqualTo(Orientation.E));
    }
}
