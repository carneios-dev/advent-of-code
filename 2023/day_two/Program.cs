using day_two;

static List<Game> ReadAndParseInputFile() {
    var lines = File.ReadLines("input.txt");
    var options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };
    List<Game> games = [];

    // E.g., "Game 1: 2 red, 2 green; 1 red, 1 green, 2 blue; 3 blue, 3 red, 3 green; 1 blue, 3 green, 7 red; 5 red, 3 green, 1 blue"
    Parallel.ForEach(lines, options, line => {
        // Parse the line.
        var splitLine = line.Split(": ");
        var newGame = new Game(int.Parse(splitLine[0].Split(' ')[1]));
        var sampleHands = splitLine[1].Split("; ");

        // E.g., "1 red, 1 green, 2 blue"
        foreach (var hand in sampleHands) {
            var cubesInHand = hand.Split(", ");

            // E.g., "1 red"
            foreach (var cubeSample in cubesInHand) {
                var cubeSampleSplit = cubeSample.Split(' ');
                var newCubeSample = new CubeSample();

                switch (cubeSampleSplit[1].ToLower()) {
                    case "red":
                        newCubeSample.AddSample(CubeSample.ColorSample.Color.RED, int.Parse(cubeSampleSplit[0]));
                        break;
                    case "green":
                        newCubeSample.AddSample(CubeSample.ColorSample.Color.GREEN, int.Parse(cubeSampleSplit[0]));
                        break;
                    case "blue":
                        newCubeSample.AddSample(CubeSample.ColorSample.Color.BLUE, int.Parse(cubeSampleSplit[0]));
                        break;
                    default:
                        Console.WriteLine("Incorrect color found.");
                        return;
                }

                newGame.Samples.Add(newCubeSample);
            }
        }

        games.Add(newGame);
    });

    return games;
}

// Entrypoint

const int redMax = 12;
const int greenMax = 13;
const int blueMax = 14;

var games = ReadAndParseInputFile();
var gameIDSum = 0;

foreach (var game in games) {
    if (game.IsGamePossible(redMax, greenMax, blueMax)) gameIDSum += game.ID;
}

Console.WriteLine($"The sum of the game IDs that are possible with a bag of {redMax} red cubes, {greenMax} green cubes, and {blueMax} blue cubes is {gameIDSum}.");
