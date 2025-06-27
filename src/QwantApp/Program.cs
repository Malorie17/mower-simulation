namespace QwantApp;

public static class Program
{
    public static async Task Main(string[] args)
    {
        if (args.Length == 0)
        {
            return;
        }

        var inputFilePath = args[0];
        if (!File.Exists(inputFilePath))
        {
            return;
        }

        var lines = (await File.ReadAllLinesAsync(inputFilePath)).ToList();

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

        var mowerTasks = mowers.Select(m => m.Execute()).ToList();
        await Task.WhenAll(mowerTasks);

        foreach (var mower in mowers)
        {
            Console.WriteLine(mower.ToString());
        }
    }
}
