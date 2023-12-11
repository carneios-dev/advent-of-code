namespace day_two {
    internal sealed class Game {
        internal List<CubeSample> Samples { set; get; }
        internal int ID { private set; get; }

        internal Game() { }

        internal Game(int id) {
            ID = id;
        }

        internal Game(int id, List<CubeSample> samples) {
            ID = id;
            Samples = samples;
        }

        internal bool IsGamePossible(int redMax, int greenMax, int blueMax) {
            if (GetHighestNumberRedSample() <= redMax && GetHighestNumberGreenSample() <= greenMax && GetHighestNumberBlueSample() <= blueMax) return true;

            return false;
        }

        private int GetHighestNumberRedSample() {
            return GetHighestNumberCubeSample(CubeSample.ColorSample.Color.RED);
        }

        private int GetHighestNumberGreenSample() {
            return GetHighestNumberCubeSample(CubeSample.ColorSample.Color.GREEN);
        }

        private int GetHighestNumberBlueSample() {
            return GetHighestNumberCubeSample(CubeSample.ColorSample.Color.BLUE);
        }

        private int GetHighestNumberCubeSample(CubeSample.ColorSample.Color color) {
            var maxVal = 0;

            foreach (var sample in Samples) {
                foreach (var colorSample in sample.ColorSamples) {
                    if (colorSample.Sample.Key == color && colorSample.Sample.Value > maxVal) {
                        maxVal = colorSample.Sample.Value;

                        break;
                    }
                }
            }

            return maxVal;
        }
    }
}
