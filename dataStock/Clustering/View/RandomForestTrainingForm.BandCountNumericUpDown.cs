using System.Windows.Forms;

namespace Giwer.dataStock.Clustering.View
{
    public partial class RandomForestTrainingForm
    {
        private class BandCountNumericUpDown : NumericUpDown
        {
            public BandCountNumericUpDown()
            { }

            private int _totalBands;
            public int TotalBands { set { _totalBands = value; UpdateEditText(); } }

            protected override void UpdateEditText()
            {
                if (Value == 0)
                {
                    if (_totalBands == 0)
                        Text = "–";
                    else
                        Text = $"sqrt({_totalBands})";
                }
                else
                {
                    base.UpdateEditText();
                }
            }
        }
    }
}
