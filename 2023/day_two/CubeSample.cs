namespace day_two {
    internal sealed class CubeSample {
        internal List<ColorSample> ColorSamples = [];

        internal CubeSample() { }

        internal CubeSample(ColorSample.Color color, int count) {
            AddSample(color, count);
        }

        internal CubeSample(List<KeyValuePair<ColorSample.Color, int>> samples) {
            AddSamples(samples);
        }

        internal void AddSample(ColorSample.Color color, int count) {
            ColorSamples.Add(new ColorSample(color, count));
        }

        internal void AddSamples(List<KeyValuePair<ColorSample.Color, int>> samples) {
            foreach (var item in samples) {
                ColorSamples.Add(new ColorSample(item.Key, item.Value));
            }
        }

        internal sealed class ColorSample {
            public enum Color {
                BLUE,
                RED,
                GREEN
            }

            internal KeyValuePair<Color, int> Sample { get; private set; }

            internal ColorSample(Color color, int count) {
                Sample = new KeyValuePair<Color, int>(color, count);
            }
        }
    }
}
