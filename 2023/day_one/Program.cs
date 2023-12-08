static async Task<string[]?> ReadInputFileAsync() {
    return await File.ReadAllLinesAsync("input.txt");
}

static void GetCalibrations(ref List<int> calibrations, ref string[] lines) {
    // Iterate over each line that was retrieved from our input file.
    foreach (var line in lines) {
        int? firstNum = null;
        int? secondNum = null;

        // Iterate over the characters from the beginning and end.
        for (int i = 0, j = line.Length - 1; i <= j;) {
            // If there is a decimal number in the ith index, store that as the first number.
            if (!firstNum.HasValue && char.IsDigit(line[i])) {
                firstNum = int.Parse(line[i].ToString());
            }

            // If there is a decimal number at the jth index, store that as the second number.
            if (!secondNum.HasValue && char.IsDigit(line[j])) {
                secondNum = int.Parse(line[j].ToString());
            }

            // If both numbers were found, concat them together to form a two-digit number, and add that to our collection.
            if (firstNum.HasValue && secondNum.HasValue) {
                calibrations.Add(int.Parse(string.Concat(firstNum, secondNum)));
                break;
            }

            // If we didn't find a valid decimal number in the current indexes, increment or decrement them, accordingly.
            if (!firstNum.HasValue) {
                i++;
            }
            if (!secondNum.HasValue) {
                j--;
            }
        }
    }
}

static int CalculateSum(List<int> calibrations) {
    var sum = 0;

    foreach (var calibration in calibrations) {
        sum += calibration;
    }

    return sum;
}

// Entrypoint

var lines = ReadInputFileAsync().Result;

if (lines == null) {
    Console.WriteLine("No content was found in input file.");
    return;
}

List<int> calibrations = new();
GetCalibrations(ref calibrations, ref lines);

Console.WriteLine($"The sum of the calibrations is {CalculateSum(calibrations)}.");
