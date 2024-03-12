using TextFile;
using System;

namespace Pingvin_3 {
    public class Observation {
        public string date;
        public int estimate;
        public int sum;

        public Observation(string date = "", int estimate = 0, int sum = 0) {
            this.date = date;
            this.estimate = estimate;
            this.sum = sum;
        }
    }

    public class Infile {
        private TextFileReader reader;

        public Infile(string filename) {
            reader = new TextFileReader(filename);
        }

        public bool ReadObservation(out Observation e) {
            e = new Observation();
            bool l = reader.ReadLine(out string line);
            if (l) {
                char[] seperators = new char[] { ' ', '\t' };
                string[] tokens = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

                string date = tokens[0];
                int estimate = int.Parse(tokens[1]);
                int sum = 0;

                for (int i = 2; i < tokens.Length; i += 3) {
                    sum += int.Parse(tokens[i + 2]);
                }

                e = new Observation(date, estimate, sum);

                return true;
            } else {
                return false;
            }
        }
    }
}