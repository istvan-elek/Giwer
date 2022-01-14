using catalog.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace catalog
{
    public partial class frmMain : Form
    {
        SQLiteConnectionStringBuilder cnsb = new SQLiteConnectionStringBuilder();
        string tableName = "images";
        string defaultFileName;
        string destinationFolder;
        Int32 selectedIndex;
        string selectedFileFullPath;
        frmDisplayExif exif;
        frmImageViewer imageViewer;
        string[] cols;
        List<string> selectedMaps = new List<string>();


        public frmMain()
        {
            InitializeComponent();
            AddToEnvironmentVariable("Path", Application.StartupPath, EnvironmentVariableTarget.User);
            this.KeyPreview = true;
            this.Location = new Point(0, 0);
            //this.initDir = Properties.Settings.Default.InitDir; 
            this.destinationFolder = Properties.Settings.Default.destinationFolder;
            this.defaultFileName = Properties.Settings.Default.defaultFileName;
            dbConnection();
        }


        void dbConnection()
        {
            if (defaultFileName == null)  //there is no database yet
            {
                menuStrip1.Visible = true;
                // create database by the menu
            }
            else
            {
                // open database
                menuStrip1.Visible = false;
                if (File.Exists(defaultFileName))
                {
                    this.Text = defaultFileName;
                    cnsb.DataSource = defaultFileName;
                    bs.DataSource = loadTableData("select * from " + tableName + " ORDER by id");
                    dataGridView1.DataSource = bs;
                    bttnFolderTree.Enabled = true;
                    if (bs.DataSource != null)
                    {
                        dataGridView1.Columns["filename"].ReadOnly = true;
                        dataGridView1.Columns["id"].ReadOnly = true;
                        dataGridView1.Columns["timestamp"].ReadOnly = true;
                        dataGridView1.Columns["longitude"].ReadOnly = true;
                        dataGridView1.Columns["latitude"].ReadOnly = true;
                        dataGridView1.Columns["folder"].ReadOnly = true;
                        dataGridView1.Columns["image_size"].ReadOnly = true;
                        dataGridView1.Columns["file_size"].ReadOnly = true;
                        dataGridView1.Columns["bitspersample"].ReadOnly = true;
                        dataGridView1.Columns["samplesperpixel"].ReadOnly = true;
                        dataGridView1.Columns["camera"].ReadOnly = true;
                        bn.Enabled = true;
                        if (bs.Count > 0)
                        {
                            bttnDisplayEXIF.Enabled = true;
                            bttnDisplayReport.Enabled = true;
                            bttnImageViewer.Enabled = true;
                            bttnSelectAll.Enabled = true;
                            bttnQuery.Enabled = true;
                            dataGridView1.Visible = true;
                            lblCursorPos.Text = "1/" + bs.Count;
                        }
                        cols = new string[dataGridView1.Columns.Count];
                        int k = 0;
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            if (!dataGridView1.Columns[i].ReadOnly)
                            {
                                cols[k] = dataGridView1.Columns[i].Name;
                                k++;
                            }
                        }
                    }
                }
                else
                {
                    menuStrip1.Visible = true;
                    MessageBox.Show("Missing database. Create new one by clicking " + Environment.NewLine + "'Catalog/Create new catalog' menu item", "Missing database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        DataTable loadTableData(string cmdSql)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                try
                {
                    cnn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(cmdSql, cnn))
                    {
                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                    }
                    if (dt.Rows.Count != 0)
                    {
                        bttnDisplayEXIF.Enabled = true;
                        bttnDisplayReport.Enabled = true;
                        bttnImageViewer.Enabled = true;
                        bttnSelectAll.Enabled = true;
                        bttnQuery.Enabled = true;
                    }
                    else
                    {
                        bttnDisplayEXIF.Enabled = false;
                        bttnDisplayReport.Enabled = false;
                        bttnImageViewer.Enabled = false;
                        bttnSelectAll.Enabled = false;
                        bttnQuery.Enabled = false;
                    }
                    return dt;
                }
                catch (SQLiteException e)
                {
                    MessageBox.Show("Error in SQL command:" + e.Message, "Sql error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        public void AddToEnvironmentVariable(string variable, string newValue, EnvironmentVariableTarget target)
        {
            var content = Environment.GetEnvironmentVariable(variable, target) ?? string.Empty;
            if (content.Contains(newValue))
                return;
            var varBuilder = new StringBuilder(content);
            if (content != string.Empty && !content.EndsWith(";"))
                varBuilder.Append(";");
            varBuilder.Append(newValue);
            var finalValue = varBuilder.ToString();
            Environment.SetEnvironmentVariable(variable, finalValue, EnvironmentVariableTarget.Process);
            if (target != EnvironmentVariableTarget.Process)
                Environment.SetEnvironmentVariable(variable, finalValue, target);
        }


        public string[] getExifData(string file)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "exiftool.exe";
            proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(file);
            proc.StartInfo.Arguments = Path.GetFileName(file);
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();

            string ex = proc.StandardOutput.ReadToEnd();
            string[] exi = ex.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            List<string> l = new List<string>();
            for (int i = 0; i < exi.Length; i++)
            {
                if (exi[i] != "") l.Add(exi[i].Split(':')[0].Trim() + ";" + exi[i].Split(':')[1]);
            }
            string[] exif = l.ToArray();
            return exif;
        }

        double convertDegree2Decimal(string inSt)
        {
            string[] outSt = inSt.Split(' ');
            int deg = Convert.ToInt16(outSt[0]);
            int min = Convert.ToInt16(outSt[2].Substring(0, outSt[2].Length - 1), CultureInfo.InvariantCulture);
            Single sec = Convert.ToSingle(outSt[3].Substring(0, outSt[3].Length - 1), CultureInfo.InvariantCulture);
            double coord = deg + Convert.ToDouble(min) / 60D + Convert.ToDouble(sec) / 3600D;
            return coord;
        }


        void updateCatalog(Int32 index, string cellName, string newCellValue)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                cnn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = cnn;
                    string sql = "UPDATE images SET " + cellName + "='" + newCellValue + "' WHERE id=" + index;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 ind = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
            updateCatalog(ind, dataGridView1.Columns[e.ColumnIndex].Name, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        }

        DataTable refreshDatagrid()
        {
            return loadTableData("select * from " + tableName + " ORDER by id");
        }

        private void bindingNavigatorDeleteItem_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                File.Delete(selectedFileFullPath);
                deleteSelectedRecord(selectedIndex);
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            catch (Exception)
            {
                MessageBox.Show("File delete error. The '" + Path.GetFileName(selectedFileFullPath) + "' file is locked, probably it is being used. Close the file and try to delete again.", "File dele error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bindingNavigatorDeleteItem.Enabled = false;
        }


        void deleteSelectedRecord(Int32 id)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                cnn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = "DELETE FROM " + tableName + " WHERE id = " + id;
                    cmd.ExecuteNonQuery();
                }
            }
        }



        private void tbSqlCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadTableData(tbSqlCommand.Text);   //loadTableData("select * from " + tableName);
                dataGridView1.DataSource = null;
                bs.DataSource = loadTableData(tbSqlCommand.Text);
                dataGridView1.DataSource = bs;
                refreshDatagrid();
            }
        }

        private void dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (dataGridView1.Rows[dataGridView1.Rows.Count].Selected) return;
            selectedIndex = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            selectedFileFullPath = dataGridView1.Rows[e.RowIndex].Cells["folder"].Value.ToString() + "\\" + dataGridView1.Rows[e.RowIndex].Cells["filename"].Value.ToString();
            //selectedMaps = dataGridView1.Rows[e.RowIndex].Cells["longitude"].Value.ToString() + ";" + dataGridView1.Rows[e.RowIndex].Cells["latitude"].Value.ToString();
            bindingNavigatorDeleteItem.Enabled = true;
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bindingNavigatorDeleteItem.Enabled = false;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bindingNavigatorDeleteItem.Enabled = false;
        }

        private void CreateNewCatalogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputBox inpBox = new inputBox("New catalog name", "dronimagecatalog");
            if (inpBox.ShowDialog() == DialogResult.OK)
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();
                if (fb.ShowDialog() == DialogResult.OK)
                {
                    defaultFileName = fb.SelectedPath + "\\" + inpBox.inputText + ".s3db";
                    createNewCatalog(defaultFileName);
                }
            }
        }

        void createNewCatalog(string newName)
        {
            cnsb.DataSource = newName;
            SQLiteConnection.CreateFile(newName);
            cnsb.DataSource = newName;
            cnsb.Version = 3;
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                cnn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = "CREATE DATABASE " + newName + " ENCODING = 'UTF8' LC_COLLATE = 'Hungarian_Hungary.1250' LC_CTYPE = 'Hungarian_Hungary.1250'  CONNECTION LIMIT = -1; ";
                    //cmd.CommandText = "CREATE DATABASE " + newName + " WITH OWNER = postgres ENCODING = 'UTF8' LC_COLLATE = 'Hungarian_Hungary.1250' LC_CTYPE = 'Hungarian_Hungary.1250' TABLESPACE = pg_default   CONNECTION LIMIT = -1; ";
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException e)
                    {
                        if (e.ErrorCode == -2147467259)
                        {
                            MessageBox.Show("'" + newName + "' is an existing database. Give an other name, or delete the existing one directly in Postgres", "Error in database creation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                dataGridView1.DataSource = null;
                //cnsb.DataSource = newName;
                createTable();
                this.Text = "Catalog: " + cnsb.DataSource;
                MessageBox.Show("'" + cnsb.DataSource + "' successfully created. Click to 'open' menu item");
            }
        }

        void createTable()
        {
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                cnn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText =
                        "CREATE TABLE images" +
                        "(" +
                        "id integer PRIMARY KEY AUTOINCREMENT NOT NULL," +
                        "filename character varying," +
                        "timestamp timestamp," +
                        "type character varying," +
                        "bitspersample integer," +
                        "samplesperpixel integer," +
                        "image_size character varying," +
                        "file_size integer," +
                        "location character varying," +
                        "longitude double precision," +
                        "latitude double precision," +
                        "dron_type character varying," +
                        "camera character varying," +
                        "purpose character varying," +
                        "operator character varying," +
                        "author character varying," +
                        "meteo character varying," +
                        "content character varying," +
                        "public boolean," +
                        "comment character varying," +
                        "folder character varying" +
                        ")";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) menuStrip1.Visible = !menuStrip1.Visible;
            if (e.KeyCode == Keys.F12) tbSqlCommand.Visible = !tbSqlCommand.Visible;
        }

        private void EraseCatalogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //inputBox ib = new inputBox("Catalog name", "dronimagecatalog");
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "SqLite database files|*.s3db";

            if (of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Delete(defaultFileName);
                    MessageBox.Show("'" + defaultFileName + "'database erased succefully");
                    dataGridView1.DataSource = null;
                    bs.DataSource = null; // loadTableData("select * from " + tableName);
                    dataGridView1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("'" + defaultFileName + "'database has not erased. " + ex.Message);
                }

            }
        }



        private void bttnImageViewer_Click(object sender, EventArgs e)
        {
            string filename = dataGridView1.Rows[bs.Position].Cells["filename"].Value.ToString();
            string folder = dataGridView1.Rows[bs.Position].Cells["folder"].Value.ToString();
            string fullname = folder + "\\" + filename;
            imageViewer = new frmImageViewer(fullname);
            imageViewer.Location = new Point(this.Location.X, this.Location.Y + this.Height);
            imageViewer.Show();
        }

        private void bttnDisplayEXIF_Click(object sender, EventArgs e)
        {
            string filename = dataGridView1.Rows[bs.Position].Cells["filename"].Value.ToString();
            string folder = dataGridView1.Rows[bs.Position].Cells["folder"].Value.ToString();
            string fullname = folder + "\\" + filename;
            exif = new frmDisplayExif(fullname);
            exif.Location = new Point(this.Location.X + this.Size.Width, this.Location.Y);
            exif.Show();
        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            //if (dataGridView1.Rows.Count == 0) return;
            //if (dataGridView1.Rows[dataGridView1.Rows.Count].Selected) return;
            if (dataGridView1.Rows.Count <= 1) return;
            lblCursorPos.Text = (bs.Position + 1).ToString() + "/" + (dataGridView1.Rows.Count - 1).ToString();
            string filename = "";
            if (bs.Position == -1) return;
            filename = dataGridView1.Rows[bs.Position].Cells["filename"].Value.ToString();
            string folder = dataGridView1.Rows[bs.Position].Cells["folder"].Value.ToString();
            this.Text = filename;
            string fullname = folder + "\\" + filename;
            if (File.Exists(folder + "\\report")) bttnDisplayReport.Image = imglist.Images[1];
            else bttnDisplayReport.Image = imglist.Images[0];
            if (imageViewer != null)
            {
                if (imageViewer.Visible == true) imageViewer.loadImage(fullname);
            }
            if (exif != null)
            {
                if (exif.Visible == true) exif.loadExif(fullname);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            frmAttributes attributes = new frmAttributes(cols);
            if (attributes.ShowDialog() == DialogResult.OK)
            {
                OpenFileDialog of = new OpenFileDialog();
                of.InitialDirectory = destinationFolder;
                of.Multiselect = true;
                of.Filter = "Image files (jpg, tif)|*.jpg;*.tif";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    //initDir = Path.GetDirectoryName(of.FileName);
                    this.Cursor = Cursors.WaitCursor;
                    tspb.Maximum = of.FileNames.Length;
                    tspb.Visible = true;
                    foreach (string files in of.FileNames)
                    {
                        tspb.PerformStep();
                        FileInfo fi = new FileInfo(files);
                        string[] exif = getExifData(files);

                        Int32 filesize = (Int32)fi.Length;
                        string imagesize = "";
                        string camera = "";
                        int bitspersample = 0;
                        int sampleperpixel = 0;
                        string fname = Path.GetFileName(files);
                        DateTime dt = File.GetLastWriteTime(files);
                        string met = attributes.meteo;
                        string auth = attributes.author;
                        double longit = 0;
                        double latit = 0;

                        for (int i = 0; i < exif.Length; i++)
                        {
                            string[] sline = exif[i].Split(';');
                            if (sline[0].ToLower() == "gps longitude")
                            {
                                longit = convertDegree2Decimal(sline[1].Trim());
                            }
                            if (sline[0].ToLower() == "gps latitude")
                            {
                                latit = convertDegree2Decimal(sline[1].Trim());
                            }
                            if (sline[0].ToLower() == "image size")
                            {
                                imagesize = sline[1].Trim();
                            }
                            if (sline[0].ToLower() == "make")
                            {
                                camera = sline[1].Trim();
                            }
                            if (sline[0].ToLower() == "bits per sample")
                            {
                                bitspersample = Convert.ToInt16(sline[1].Trim());
                            }
                            if (sline[0].ToLower() == "samples per pixel")
                            {
                                sampleperpixel = Convert.ToInt16(sline[1].Trim());
                            }
                            if (sline[0].ToLower() == "color components")
                            {
                                sampleperpixel = Convert.ToInt16(sline[1].Trim());
                            }
                        }
                        string location = attributes.loc;
                        string content = attributes.content;
                        string purpose = attributes.purpose;
                        Boolean pub = attributes.publi;
                        string tipus = attributes.tipus;
                        string comment = attributes.comment;
                        string drontipus = attributes.drontype;
                        string oper = attributes.opera;
                        insertFile(fname, tipus, Path.GetDirectoryName(files), dt, location, met, content, longit, latit, auth, purpose, pub, comment, filesize, imagesize, camera, bitspersample, sampleperpixel, drontipus, oper);
                    }
                    bs.DataSource = refreshDatagrid();
                    this.Cursor = Cursors.Default;
                    tspb.Visible = false;
                    tspb.Value = 0;
                }
            }
        }

        void insertFile(string fname, string typ, string folder, DateTime creationTime, string location, string meteo, string content, double longi, double lati, string author, string purpose, Boolean publi, string comm, Int32 filesize, string imagesize, string camera, int bitspersample, int sampleperpixel, string drontip, string operat)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                cnn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    DateTime timest = creationTime; //DateTime.Now;
                    cmd.Connection = cnn;
                    cmd.CommandText = "INSERT INTO " + tableName + " (filename, type, folder, timestamp, location, longitude, latitude, meteo, content, author, purpose, public, comment, file_size, image_size, camera, bitspersample, samplesperpixel, dron_type, operator) VALUES (@fn, @Typ, @Fold, @tm, @Loc, @Longitude, @Latitude, @Meteor, @Content, @Auth, @Purpos, @Publi, @Comment, @fsize, @imsize, @cam, @colord,@sampleperpix, @drontp, @operator)";

                    SQLiteParameter operato = cmd.CreateParameter();
                    operato.ParameterName = "operator";
                    operato.Value = operat;
                    cmd.Parameters.Add(operato);

                    SQLiteParameter drontp = cmd.CreateParameter();
                    drontp.ParameterName = "drontp";
                    drontp.Value = drontip;
                    cmd.Parameters.Add(drontp);

                    SQLiteParameter sampleperpix = cmd.CreateParameter();
                    sampleperpix.ParameterName = "sampleperpix";
                    sampleperpix.Value = sampleperpixel;
                    cmd.Parameters.Add(sampleperpix);

                    SQLiteParameter camer = cmd.CreateParameter();
                    camer.ParameterName = "cam";
                    camer.Value = camera;
                    cmd.Parameters.Add(camer);

                    SQLiteParameter colord = cmd.CreateParameter();
                    colord.ParameterName = "colord";
                    colord.Value = bitspersample;
                    cmd.Parameters.Add(colord);

                    SQLiteParameter imsize = cmd.CreateParameter();
                    imsize.ParameterName = "imsize";
                    imsize.Value = imagesize;
                    cmd.Parameters.Add(imsize);

                    SQLiteParameter fsize = cmd.CreateParameter();
                    fsize.ParameterName = "fsize";
                    fsize.Value = filesize;
                    cmd.Parameters.Add(fsize);

                    SQLiteParameter fnm = cmd.CreateParameter();
                    fnm.ParameterName = "fn";
                    fnm.Value = fname;
                    cmd.Parameters.Add(fnm);

                    SQLiteParameter tm = cmd.CreateParameter();
                    tm.ParameterName = "tm";
                    tm.Value = timest;
                    cmd.Parameters.Add(tm);

                    SQLiteParameter Loc = cmd.CreateParameter();
                    Loc.ParameterName = "Loc";
                    Loc.Value = location.ToString();
                    cmd.Parameters.Add(Loc);

                    SQLiteParameter Fold = cmd.CreateParameter();
                    Fold.ParameterName = "Fold";
                    Fold.Value = folder;
                    cmd.Parameters.Add(Fold);

                    SQLiteParameter Meteor = cmd.CreateParameter();
                    Meteor.ParameterName = "Meteor";
                    Meteor.Value = meteo;
                    cmd.Parameters.Add(Meteor);

                    SQLiteParameter Content = cmd.CreateParameter();
                    Content.ParameterName = "Content";
                    Content.Value = content;
                    cmd.Parameters.Add(Content);

                    SQLiteParameter Longitude = cmd.CreateParameter();
                    Longitude.ParameterName = "Longitude";
                    Longitude.Value = longi;
                    cmd.Parameters.Add(Longitude);

                    SQLiteParameter Latitude = cmd.CreateParameter();
                    Latitude.ParameterName = "Latitude";
                    Latitude.Value = lati;
                    cmd.Parameters.Add(Latitude);

                    SQLiteParameter Auth = cmd.CreateParameter();
                    Auth.ParameterName = "Auth";
                    Auth.Value = author;
                    cmd.Parameters.Add(Auth);

                    SQLiteParameter Purpos = cmd.CreateParameter();
                    Purpos.ParameterName = "Purpos";
                    Purpos.Value = purpose;
                    cmd.Parameters.Add(Purpos);

                    SQLiteParameter Publi = cmd.CreateParameter();
                    Publi.ParameterName = "Publi";
                    Publi.Value = publi;
                    cmd.Parameters.Add(Publi);

                    SQLiteParameter Typ = cmd.CreateParameter();
                    Typ.ParameterName = "Typ";
                    Typ.Value = typ;
                    cmd.Parameters.Add(Typ);

                    SQLiteParameter Comment = cmd.CreateParameter();
                    Comment.ParameterName = "Comment";
                    Comment.Value = comm;
                    cmd.Parameters.Add(Comment);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void bttnAddFolderContent_Click(object sender, EventArgs e)
        {
            frmAttributes attributes = new frmAttributes(cols);
            if (attributes.ShowDialog() == DialogResult.OK)
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();
                //fb.SelectedPath = initDir;
                fb.ShowNewFolderButton = false;
                fb.SelectedPath = destinationFolder;
                if (fb.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    List<string> flist = new List<string>();
                    flist = Directory.GetFiles(fb.SelectedPath, "*.tif").ToList();
                    flist.AddRange(Directory.GetFiles(fb.SelectedPath, "*.jpg").ToList());
                    string[] fn = flist.ToArray();
                    tspb.Maximum = fn.Length;
                    tspb.Visible = true;
                    foreach (string files in fn)
                    {
                        tspb.PerformStep();
                        string[] exif = getExifData(files);
                        FileInfo fi = new FileInfo(files);
                        Int32 filesize = (Int32)fi.Length;
                        string imagesize = "";
                        string camera = "";
                        int bitspersample = 0;
                        int sampleperpixel = 0;
                        string fname = Path.GetFileName(files);
                        DateTime dt = File.GetLastWriteTime(files);
                        string met = attributes.meteo;
                        string auth = attributes.author;
                        double longit = 0;
                        double latit = 0;
                        for (int i = 0; i < exif.Length; i++)
                        {
                            string[] sline = exif[i].Split(';');
                            if (sline[0].ToLower() == "gps longitude")
                            {
                                longit = convertDegree2Decimal(sline[1].Trim());
                            }
                            if (sline[0].ToLower() == "gps latitude")
                            {
                                latit = convertDegree2Decimal(sline[1].Trim());
                            }
                            if (sline[0].ToLower() == "image size")
                            {
                                imagesize = sline[1].Trim();
                            }
                            if (sline[0].ToLower() == "make")
                            {
                                camera = sline[1].Trim();
                            }
                            if (sline[0].ToLower() == "bits per sample")
                            {
                                bitspersample = Convert.ToInt16(sline[1].Trim());
                            }
                            if (sline[0].ToLower() == "samples per pixel")
                            {
                                sampleperpixel = Convert.ToInt16(sline[1].Trim());
                            }
                            if (sline[0].ToLower() == "color components")
                            {
                                sampleperpixel = Convert.ToInt16(sline[1].Trim());
                            }
                        }
                        string location = attributes.loc;
                        string content = attributes.content;
                        string purpose = attributes.purpose;
                        Boolean pub = attributes.publi;
                        string tipus = attributes.tipus;
                        string comment = attributes.comment;
                        string drontipus = attributes.drontype;
                        string oper = attributes.opera;
                        insertFile(fname, tipus, Path.GetDirectoryName(files), dt, location, met, content, longit, latit, auth, purpose, pub, comment, filesize, imagesize, camera, bitspersample, sampleperpixel, drontipus, oper);
                    }
                    bs.DataSource = refreshDatagrid();
                    tspb.Value = 0;
                    tspb.Visible = false;
                    this.Cursor = Cursors.Default;
                }
            }
        }


        private void bttnFolderTree_Click(object sender, EventArgs e)
        {
            frmFolderStructure folderStruc = new frmFolderStructure(this.Location.X + this.Size.Width);
            folderStruc.Show();
        }

        private void dbConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "SqLite database file|*.s3db";
            if (of.ShowDialog() == DialogResult.OK)
            {
                defaultFileName = of.FileName;
                dbConnection();
            }

        }

        private void bttnQuery_Click(object sender, EventArgs e)
        {
            frmQueryEditor query = new frmQueryEditor(cnsb, getFieldNames());
            if (query.ShowDialog() == DialogResult.OK)
            {
                bs.DataSource = query.dtOut;
            }
        }

        List<string> getFieldNames()
        {
            List<string> fields = new List<string>();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                fields.Add(dataGridView1.Columns[i].Name);
            }
            return fields;
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Properties.Settings.Default["initDir"] = initDir;
            Properties.Settings.Default["defaultFileName"] = defaultFileName;
            Settings.Default.Save();
        }


        private void bttnDisplayReport_Click(object sender, EventArgs e)
        {
            string reportFileDir = dataGridView1.Rows[bs.Position].Cells["folder"].Value.ToString();
            frmReport report = new frmReport(reportFileDir);
            report.ShowDialog();
        }


        private void bttnViewOnMap_Click(object sender, EventArgs e)
        {
            selectedMaps.Clear();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string coords = row.Cells["longitude"].Value.ToString() + ";" + row.Cells["latitude"].Value.ToString();
                selectedMaps.Add(coords);
            }
            frmGMap gmap = new frmGMap(selectedMaps);
            gmap.Show();
        }

        private void bttnSelectAll_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bs.DataSource = loadTableData("select * from " + tableName);
            }
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < bs.Count; i++)
                {
                    dataGridView1.Rows[i].Selected = true;
                }
            }
        }
    }
}
