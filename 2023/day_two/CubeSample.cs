namespace day_two {
    internal sealed class CubeSample {
        internal List<ColorSample> ColorSamples = [];

        internal CubeSample() { }

        internal void AddSample(ColorSample sample) {
            ColorSamples.Add(sample);
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

            internal KeyValuePair<Color, int> Sample { get; set; }

            internal ColorSample() { }
            internal ColorSample(Color color, int count) {
                Sample = new KeyValuePair<Color, int>(color, count);
            }
        }
    }
}
