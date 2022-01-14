using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Giwer.dataStock.Clustering.View
{
    public partial class ManualClusterSelectControl : CentroidBasedParamsControl
    {
        string actualCPName;
        private int _sampleCellIndex = -1;
        public ImageWindow _imW;
        private Int32[] _colorPalette;
        private int imgWidth = 1;
        public bool isPoly = false;
        private List<int> samplePointIndexes = new List<int>();
        private List<List<int>> sampleAreasIndexes = new List<List<int>>();
        private List<List<int>> samplePolyInPointIndexes = new List<List<int>>();

        public float ChangeThreshold { get { return (float)numChangeThreshold.Value; } }

        public List<int> SamplePointIndexes { get => samplePointIndexes; set => samplePointIndexes = value; }
        public List<List<int>> SampleAreasIndexes { get => sampleAreasIndexes; set => sampleAreasIndexes = value; }
        public List<List<int>> SamplePolyInPointIndexes { get => samplePolyInPointIndexes; set => samplePolyInPointIndexes = value; }

        public List<Color> getColors()
        {
            List<Color> retList = new List<Color>();
            for (int i = 0; i < dgvMCS.Rows.Count - 1; i++)
            {
                retList.Add(dgvMCS.Rows[i].Cells["Color"].Style.BackColor);
            }
            return retList;
        }

        public List<String> getCategories()
        {
            List<String> retList = new List<String>();
            for (int i = 0; i < dgvMCS.Rows.Count - 1; i++)
            {
                if (dgvMCS.Rows[i].Cells["Category"].Value != null)
                    retList.Add(dgvMCS.Rows[i].Cells["Category"].Value.ToString());
                else
                    retList.Add("");
            }
            return retList;
        }

        public ManualClusterSelectControl()
        {
            InitializeComponent();
            InitColorPalettes();
            typeCmbx.Items.Add("Point");
            typeCmbx.Items.Add("Polygon");
            typeCmbx.SelectedItem = "Point";
        }

        public void init(ImageWindow imW)
        {
            imW.MouseClicked += imgWindowMouseClicked;
            cmbColPaletteTables_SelectedIndexChanged(null, null);
            _imW = imW;
        }

        void InitTable()
        {
            dgvMCS.RowHeadersVisible = false;
            dgvMCS.Columns.Clear();
            dgvMCS.Columns.Add("Sample", "Sample");
            dgvMCS.Columns.Add("Color", "Color");
            dgvMCS.Columns.Add("Category", "Category");
            SamplePointIndexes.Add(0);
            SampleAreasIndexes.Add(new List<int>(0));
            SamplePolyInPointIndexes.Add(new List<int>(0));

            for (int i = 1; i < numberOfClustersChanger.Value; i++)
            {
                dgvMCS.Rows.Add();
                SamplePointIndexes.Add(0);
                SampleAreasIndexes.Add(new List<int>(0));
                SamplePolyInPointIndexes.Add(new List<int>(0));
            }
            dgvMCS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            int col = 200 / (int)numberOfClustersChanger.Value;
            for (int j = 0; j < numberOfClustersChanger.Value; j++)
            {
                dgvMCS.Rows[j].Cells["Color"].Style.BackColor = Color.FromArgb(28 + col * j, 28 + col * j, 28 + col * j);
                dgvMCS.Rows[j].Cells["Sample"].Value = "Click to sample";
            }
        }

        private void dgvBaseColors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != dgvMCS.Rows.Count - 1)
            {
                int[] custom_colors = new int[1];
                ColorDialog cold = new ColorDialog();
                custom_colors[0] = ColorTranslator.ToWin32(dgvMCS.Rows[e.RowIndex].Cells[1].Style.BackColor);
                cold.CustomColors = custom_colors;
                if (cold.ShowDialog() == DialogResult.OK)
                {
                    dgvMCS.Rows[e.RowIndex].Cells[1].Style.BackColor = cold.Color;
                }
            }
            if (e.ColumnIndex == 0 && e.RowIndex != dgvMCS.Rows.Count - 1)
            {
                _sampleCellIndex = e.RowIndex;
                SampleAreasIndexes[_sampleCellIndex] = new List<int>();
                SamplePolyInPointIndexes[_sampleCellIndex] = new List<int>();
                dgvMCS.Rows[e.RowIndex].Cells[0].Value = "Pick point";
            }
        }

        private void imgWindowMouseClicked(object sender, Tuple<int, int, int> loc)
        {
            imgWidth = Math.Abs(loc.Item3);
            if (_sampleCellIndex != -1)
            {
                if (typeCmbx.SelectedItem.Equals("Point"))
                {
                    dgvMCS.Rows[_sampleCellIndex].Cells[0].Value = "(" + loc.Item1 + "," + loc.Item2 + ")";
                    SamplePointIndexes[_sampleCellIndex] = loc.Item2 * Math.Abs(loc.Item3) + loc.Item1;
                    _sampleCellIndex = -1;
                }
                else
                {
                    dgvMCS.Rows[_sampleCellIndex].Cells[0].Value = "Polygon";
                    SampleAreasIndexes[_sampleCellIndex].Add(loc.Item2 * Math.Abs(loc.Item3) + loc.Item1);

                    if (loc.Item3 < 0)
                    {
                        int first = SampleAreasIndexes[_sampleCellIndex][0];
                        SampleAreasIndexes[_sampleCellIndex].Add(first);
                        drawPolygon();
                        SamplePolyInPointIndexes[_sampleCellIndex] = getPolyInPoints(_sampleCellIndex);
                        _sampleCellIndex = -1;
                    }
                }
                drawPolygon();
            }
        }

        private void numberOfClustersChanger_ValueChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("SamplePointIndexes.Count: " + SamplePointIndexes.Count);
            System.Diagnostics.Debug.WriteLine("SamplePolyInPointIndexes.Count: " + SamplePolyInPointIndexes.Count);
            int d = (int)numberOfClustersChanger.Value - dgvMCS.Rows.Count + 1;
            int count = dgvMCS.Rows.Count;
            if (d == 0) return;
            if (d < 0)
            {
                for (int i = 0; i < -d; i++)
                {
                    dgvMCS.Rows.RemoveAt(count - 2 - i);
                    SamplePointIndexes.RemoveAt(count - 2 - i);
                    SampleAreasIndexes.RemoveAt(count - 2 - i);
                    SamplePolyInPointIndexes.RemoveAt(count - 2 - i);
                }
            }
            if (d > 0)
            {
                for (int i = 0; i < d; i++)
                {
                    dgvMCS.Rows.Add();
                    dgvMCS.Rows[dgvMCS.Rows.Count - 2].Cells["Color"].Style.BackColor = Color.Gray;
                    dgvMCS.Rows[dgvMCS.Rows.Count - 2].Cells["Sample"].Value = "Click to sample";
                    SamplePointIndexes.Add(0);
                    SampleAreasIndexes.Add(new List<int>(0));
                    SamplePolyInPointIndexes.Add(new List<int>(0));
                }
            }
        }

        private void cmbColPaletteTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbColPaletteTables.SelectedItem == null) return;

            actualCPName = cmbColPaletteTables.SelectedItem.ToString();
            _colorPalette = loadColorPalette(Application.StartupPath + "\\" + cmbColPaletteTables.SelectedItem + ".cp");
            if (File.Exists(Application.StartupPath + "\\" + actualCPName + ".lut"))
                loadTable(actualCPName + ".lut");
            else
                InitTable();
        }

        void loadTable(string fname)
        {
            dgvMCS.RowHeadersVisible = false;
            System.Diagnostics.Debug.WriteLine("Load table:" + fname);
            dgvMCS.Rows.Clear();
            dgvMCS.Columns.Clear();
            SamplePointIndexes = new List<int>();
            SampleAreasIndexes = new List<List<int>>();
            SamplePolyInPointIndexes = new List<List<int>>();
            using (FileStream fs = new FileStream(fname, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line = sr.ReadLine();
                    string[] ln = line.Split(';');
                    dgvMCS.Columns.Add("Sample", "Sample");
                    dgvMCS.Columns.Add("Color", "Color");
                    dgvMCS.Columns.Add("Category", "Category");
                    int i = 0;
                    while (!sr.EndOfStream)
                    {
                        dgvMCS.Rows.Add();
                        SamplePointIndexes.Add(i);
                        SampleAreasIndexes.Add(new List<int>(0));
                        SamplePolyInPointIndexes.Add(new List<int>(0));
                        System.Diagnostics.Debug.WriteLine("Row " + i + " added!");
                        line = sr.ReadLine();
                        ln = line.Split(';');
                        dgvMCS.Rows[i].Cells["Sample"].Value = "Click to sample";
                        Int32 c = Convert.ToInt32(ln[1]);
                        Color col = ColorTranslator.FromWin32(c);
                        dgvMCS.Rows[i].Cells["Color"].Style.BackColor = col;
                        dgvMCS.Rows[i].Cells["Category"].Value = ln[2];
                        i += 1;
                    }
                    numberOfClustersChanger.Value = SamplePointIndexes.Count;
                }
            }
            dgvMCS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void InitColorPalettes()
        {
            string[] fileEntries = Directory.GetFiles(Application.StartupPath, "*.cp");
            foreach (string item in fileEntries)
            {
                cmbColPaletteTables.Items.Add(Path.GetFileNameWithoutExtension(item));
            }
            cmbColPaletteTables.SelectedItem = "manualClustering";
            cmbColPaletteTables_SelectedIndexChanged(null, null);
        }

        private Int32[] loadColorPalette(string fileName) // from frmDataStock
        {
            Int32[] cp = new Int32[256];
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    sr.ReadLine();
                    for (int i = 0; i < 256; i++)
                    {
                        string line = sr.ReadLine();
                        Int32 col = Convert.ToInt32(line.Split(';')[1]);
                        cp[i] = col;
                    }
                }
            }
            return cp;
        }

        public void saveCP() // save manual clustering color palette 
        {
            string fname = actualCPName + ".cp";
            using (FileStream fs = new FileStream(fname, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sr = new StreamWriter(fs))
                {
                    int ClusterCount = SamplePointIndexes.Count;
                    System.Collections.Generic.List<Color> colors = getColors();
                    string wrSt = "Index;Color";
                    sr.WriteLine(wrSt);
                    for (int i = 0; i < 256; i++)
                    {
                        int index = (int)Math.Floor((ClusterCount) * i / 257.0);
                        wrSt = i + ";" + System.Drawing.ColorTranslator.ToWin32(colors[index]);
                        sr.WriteLine(wrSt);
                    }
                    sr.Flush();
                }
            }
        }

        public void saveLUT()
        {
            string fname = actualCPName + ".lut";
            using (FileStream fs = new FileStream(fname, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sr = new StreamWriter(fs))
                {
                    int ClusterCount = SamplePointIndexes.Count;
                    System.Collections.Generic.List<String> categories = getCategories();
                    System.Collections.Generic.List<Color> colors = getColors();
                    string wrSt = "Start;Color;Category";
                    sr.WriteLine(wrSt);
                    for (int i = 0; i < categories.Count; i++)
                    {
                        int start = i * (256 / ClusterCount);
                        wrSt = start + ";" + ColorTranslator.ToWin32(colors[i]) + ";" + categories[i];
                        System.Diagnostics.Debug.WriteLine(start + ";" + colors[i] + ";" + categories[i]);
                        sr.WriteLine(wrSt);
                    }
                    sr.Flush();
                }
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            frmTextInput frmNewLut = new frmTextInput("LUT name");
            if (frmNewLut.ShowDialog() == DialogResult.OK)
            {
                actualCPName = frmNewLut.inpuText;
                InitTable();
                cmbColPaletteTables.Items.Add(actualCPName);
                cmbColPaletteTables.SelectedIndex = cmbColPaletteTables.Items.Count - 1;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveCP();
            saveLUT();
            MessageBox.Show("Files were successfully saved!");
        }

        private void dgvMCS_MouseLeave(object sender, EventArgs e)
        {
            _imW.ClearDrawings();
        }

        private void dgvMCS_MouseEnter(object sender, EventArgs e)
        {
            if (typeCmbx.SelectedItem.Equals("Point"))
                drawCrosses();
            else
                drawPolygons();
        }

        private void drawCrosses()
        {
            for (int i = 0; i < dgvMCS.Rows.Count - 1; ++i)
            {
                int locInd = samplePointIndexes[i];
                Color col = dgvMCS.Rows[i].Cells["Color"].Style.BackColor;
                _imW.DrawCross(locInd, col);
            }
        }

        private void drawPolygons()
        {
            System.Diagnostics.Debug.WriteLine("drawPolygons()");
            for (int i = 0; i < dgvMCS.Rows.Count - 1; ++i)
            {
                List<int> vertices = sampleAreasIndexes[i];
                Color col = dgvMCS.Rows[i].Cells["Color"].Style.BackColor;
                if (vertices.Count > 2)
                {
                    for (int v = 1; v < vertices.Count; ++v)
                    {
                        _imW.DrawLine(vertices[v - 1], vertices[v], col);
                    }
                    if (vertices[0] == vertices[vertices.Count - 1] && vertices.Count > 1)
                    {
                        _imW.fillPolygon(vertices, col);
                    }
                    else
                    {
                        _imW.DrawCross(vertices[0], col);
                    }
                }

            }
        }

        private void drawPolygon()
        {
            if (_sampleCellIndex != -1)
            {
                List<int> vertices = sampleAreasIndexes[_sampleCellIndex];
                Color col = dgvMCS.Rows[_sampleCellIndex].Cells["Color"].Style.BackColor;
                for (int v = 1; v < vertices.Count; ++v)
                {
                    _imW.DrawLine(vertices[v - 1], vertices[v], col);
                }

                if (vertices[0] == vertices[vertices.Count - 1] && vertices.Count > 1)
                    _imW.fillPolygon(vertices, col);
                else
                    _imW.DrawCross(vertices[0], col);
            }
        }

        private bool IsPointInPolygon(PointF[] polygon, int X, int Y)
        {
            bool result = false;
            int j = polygon.Length - 1;
            for (int i = 0; i < polygon.Length; i++)
            {
                if (polygon[i].Y < Y && polygon[j].Y >= Y || polygon[j].Y < Y && polygon[i].Y >= Y)
                {
                    if (polygon[i].X + (Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        public List<int> getPolyInPoints(int ind)
        {
            List<int> polyInPoints = new List<int>();
            List<int> vertices = sampleAreasIndexes[ind];
            if (vertices.Count > 0)
            {
                float minX = vertices[0] % imgWidth;
                float maxX = minX;
                float minY = vertices[0] / imgWidth;
                float maxY = minY;
                PointF[] polygon = new PointF[vertices.Count];
                for (int i = 0; i < vertices.Count; ++i)
                {
                    float y = vertices[i] / imgWidth;
                    float x = vertices[i] % imgWidth;
                    polygon[i] = new PointF(x, y);

                    if (x < minX) minX = x;
                    if (x > maxX) maxX = x;
                    if (y < minY) minY = y;
                    if (y > maxY) maxY = y;
                }

                for (int i = (int)minX; i < maxX; ++i)
                {
                    for (int j = (int)minY; j < maxY; ++j)
                    {
                        if (IsPointInPolygon(polygon, i, j)) polyInPoints.Add(imgWidth * j + i);
                    }
                }

            }
            return polyInPoints;
        }

        private void typeCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            isPoly = !typeCmbx.SelectedItem.Equals("Point");
        }
    }
}
