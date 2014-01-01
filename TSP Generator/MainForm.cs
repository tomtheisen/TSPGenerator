using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TspGenerator {
    public partial class MainForm : Form {
        private SalesSet SalesSet;
        
        public MainForm() {
            InitializeComponent();
        }

        private void GenerateDestinationsButton_Click(object sender, EventArgs e) {
            const int TravelerWidth = 1000;
            const int TravelerHeight = 1000;

            int destinationCount = int.Parse(this.DestinationsTextbox.Text);
            this.SalesSet = new SalesSet(TravelerWidth, TravelerHeight, destinationCount);
            this.DestinationsPictureBox.Invalidate();
        }

        private void DestinationsPictureBox_Paint(object sender, PaintEventArgs e) {
            e.Graphics.Clear(this.DestinationsPictureBox.BackColor);
            if (this.SalesSet == null) return;

            var size = this.DestinationsPictureBox.ClientSize;

            var set = this.SalesSet;
            if (set != null) {
                foreach (var d in this.SalesSet.Destinations) {
                e.Graphics.DrawArc(SystemPens.ControlText, 
                    d.X * size.Width / set.Width,   
                    d.Y * size.Height / set.Height, 
                    3, 3, 0, 360);
                }

                var path = set.BestPath;
                if (path != null) {
                    e.Graphics.DrawString(set.BestLength.ToString(), this.Font, SystemBrushes.ControlText, 0, 0);
                    for (int i = 0; i < path.Count; i++) {
                        e.Graphics.DrawLine(
                            SystemPens.ControlText,
                            path[i].X * size.Width / set.Width, 
                            path[i].Y * size.Height / set.Height, 
                            path[(i + 1) % path.Count].X * size.Width / set.Width, 
                            path[(i + 1) % path.Count].Y * size.Height / set.Height);
                    }
                }
            }
        }

        private CancellationTokenSource CancelTokenSource;
        async private void SearchButton_Click(object sender, EventArgs e) {
            if (this.SalesSet == null) return;

            this.CancelTokenSource = new CancellationTokenSource();
            this.SearchButton.Enabled = false;
            this.AbortButton.Enabled = true;

            await Task.Run(() => { this.SalesSet.Search(this.CancelTokenSource.Token); });

            this.SearchButton.Enabled = true;
            this.AbortButton.Enabled = false;
        }

        private void AbortButton_Click(object sender, EventArgs e) {
            this.CancelTokenSource.Cancel();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e) {
            this.DestinationsPictureBox.Invalidate();
        }

        private void BreakerDestinationsButton_Click(object sender, EventArgs e) {
            const int TravelerWidth = 100;
            const int TravelerHeight = 100;
            const int SequenceLength = 5;
            var breakerpoints = 
                from ring in Enumerable.Range(0, 10)
                from direction in new[] {new Point(0,1), new Point(1, 0), new Point(0, -1), new Point(-1, 0)}
                from sequence in Enumerable.Range(ring * SequenceLength, SequenceLength)
                select new Point(TravelerWidth / 2 + direction.X * sequence, TravelerHeight / 2 + direction.Y * sequence);
            this.SalesSet = new SalesSet(TravelerWidth, TravelerHeight, breakerpoints);
        }
    }
}
