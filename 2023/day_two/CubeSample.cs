namespace day_two {
    internal sealed class CubeSample {
        internal List<ColorSample> ColorSamples = [];

        internal CubeSample() { }

        internal void AddSample(ColorSample sample) {
            ColorSamples.Add(sample);
        }

        internal sealed class ColorSample {
            public enum Color {
                BLUE,
                RED,
                GREEN
            }

            internal KeyValuePair<Color, int> Sample { get; set; }

            internal ColorSample() { }
        }
    }
}
