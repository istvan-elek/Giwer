using System.Windows.Forms;

namespace Giwer.dataStock
{
    public partial class EditHeader : Form
    {
        GeoImageData gimData;

        public EditHeader(GeoImageData giDa)
        {
            InitializeComponent();
            gimData = giDa;
            foreach (var prop in giDa.GetType().GetProperties())
            {
                dgv.Rows.Add(prop.Name, prop.GetValue(giDa)); //tbH.AppendText( prop.Name + ", " + prop.GetValue(giDa, null));
            }
            dgv.Columns[0].ReadOnly = true;
            dgv.Columns[1].ReadOnly = true;
        }


        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows[e.RowIndex].Cells[0].Value.ToString() == "Comment" || dgv.Rows[e.RowIndex].Cells[0].Value.ToString() == "Layout" || dgv.Rows[e.RowIndex].Cells[0].Value.ToString() == "LocationName" || dgv.Rows[e.RowIndex].Cells[0].Value.ToString() == "CoordSystem")
            {
                dgv.Rows[e.RowIndex].Cells[1].ReadOnly = false;
            }
        }


        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string val = dgv.Rows[e.RowIndex].Cells[0].Value.ToString().ToLower();
                switch (val)
                {
                    case "comment":
                        gimData.Comment = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        break;
                    case "layout":
                        gimData.Layout = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        break;
                    case "coordsys":
                        gimData.CoordSystem = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        break;
                    case "locationname":
                        gimData.LocationName = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        break;
                }
            }

        }

        private void EditHeader_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeoImageTools gtool = new GeoImageTools(gimData);
            gtool.saveHeader2Giwer(gimData.FileName);

        }
    }
}
