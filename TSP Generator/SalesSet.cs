using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace TspGenerator {
    class SalesSet {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public IReadOnlyList<Point> Destinations { get; private set; }
        public IReadOnlyDictionary<Tuple<Point, Point>, int> Distances { get; private set; }

        private static Random Rng = new Random();
        
        internal SalesSet(int width, int height, int destinationCount) 
            : this(width, height, GetRandomDestinations(width, height, destinationCount)) 
        { 
        }

        public SalesSet(int width, int height, IEnumerable<Point> points) {
            this.Width = width;
            this.Height = height;
            this.Destinations = points.ToList().AsReadOnly();
            this.Distances = GetDistances(this.Destinations);
        }

        private static IReadOnlyDictionary<Tuple<Point, Point>, int> GetDistances(IEnumerable<Point> points) {
            return new ReadOnlyDictionary<Tuple<Point, Point>, int>((
                    from source in points.Distinct()
                    from destination in points.Distinct()
                    select new { source, destination }
                ).ToDictionary(
                    t => Tuple.Create(t.source, t.destination),
                    t => GetDistance(t.source, t.destination)
                )
            );
        }  

        private static IEnumerable<Point> GetRandomDestinations(int width, int height, int destinationCount) {
            for (int i = 0; i < destinationCount; i++) {
                yield return new Point(Rng.Next(width), Rng.Next(height));
            }
        }

        private static int GetDistance(Point a, Point b) {
            return (int)Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }

        public IReadOnlyList<Point> BestPath { get; private set; }
        public int BestLength { get; private set; }
        public void Search(CancellationToken cancelToken = default(CancellationToken)) {
            this.BestPath = this.Destinations.OrderBy(d => Rng.NextDouble()).ToList().AsReadOnly();
            this.BestLength = GetLength(this.BestPath);

            while (!cancelToken.IsCancellationRequested) {
                for (int i = 0; i < this.Destinations.Count; i++) {
                    var newPath = this.BestPath.Take(i)
                            .Concat(this.BestPath.Skip(i).Reverse())
                            .ToList();
                    var newLength = GetLength(newPath);
                    if (newLength < this.BestLength) {
                        this.BestLength = newLength;
                        this.BestPath = newPath.AsReadOnly();
                    }

                    for (int j = i + 1; j < this.Destinations.Count; j++) {
                        newPath = this.BestPath.Take(i)
                            .Concat(this.BestPath.Skip(j))
                            .Concat(this.BestPath.Skip(i).Take(j - i))
                            .ToList();
                        newLength = GetLength(newPath);
                        if (newLength < this.BestLength) {
                            this.BestLength = newLength;
                            this.BestPath = newPath.AsReadOnly();
                        }
                    }
                }
                this.BestPath = this.BestPath.Skip(1).Concat(this.BestPath.Take(1)).ToList().AsReadOnly();
            }
        }

        private int GetLength(IEnumerable<Point> path) {
            return path.Zip(path.Skip(1).Concat(path), (a, b) => this.Distances[Tuple.Create(a, b)]).Sum();
        }
    }
}
