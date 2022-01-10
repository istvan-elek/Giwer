using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;

namespace catalog
{
    public partial class frmGMap : Form
    {
        double longi = 47.47495D; 
        double lati = 19.06222D;
        List<string> maplist = new List<string>();
        public frmGMap(List<string> pnt)
        {
            maplist = pnt;
            InitializeComponent();
            gMap.ShowCenter = false;
            if (pnt.Count != 0)
            {
                longi = Convert.ToDouble(pnt[0].Split(';')[1].Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
                lati = Convert.ToDouble(pnt[0].Split(';')[0].Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        private void tsbZoomIn_Click(object sender, EventArgs e)
        {
            gMap.Zoom += 1;
            gMap.Refresh();
        }

        private void tsbZoomOut_Click(object sender, EventArgs e)
        {
            gMap.Zoom -= 1;
            gMap.Refresh();
        }

        private void frmGMap_Load(object sender, EventArgs e)
        {
            gMap.MapProvider = GMap.NET.MapProviders.GoogleHybridMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMap.MinZoom = 2;
            gMap.MaxZoom = 20;
            gMap.Zoom = 14;
            cmbMapProviders.SelectedItem = Properties.Settings.Default.defaultMapProvider; // default is "GoogleHybridMapProvider";
            if (maplist.Count != 0)
            {
                foreach (string item in maplist)
                {
                    longi = Convert.ToDouble(item.Split(';')[1].Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
                    lati = Convert.ToDouble(item.Split(';')[0].Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
                    GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
                    GMap.NET.WindowsForms.GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new GMap.NET.PointLatLng(longi, lati), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_small);
                    markers.Markers.Add(marker);
                    gMap.Overlays.Add(markers);
                    gMap.Position = new GMap.NET.PointLatLng(longi, lati);
                }
            }
            else 
            { 
                gMap.Position = new GMap.NET.PointLatLng(longi, lati);
                GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
                GMap.NET.WindowsForms.GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new GMap.NET.PointLatLng(longi, lati), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_small);
                markers.Markers.Add(marker);
                gMap.Overlays.Add(markers);
            }
            gMap.Refresh();
        }


        private void gMap_MouseMove_1(object sender, MouseEventArgs e)
        {
            double x = gMap.FromLocalToLatLng(e.X, e.Y).Lng;
            string Longitude = x.ToString("0.0000000");
            double y = gMap.FromLocalToLatLng(e.X, e.Y).Lat;
            string Latitude = y.ToString("0.0000000");
            stslbl.Text = "Long: " + Longitude + "     Lat: " + Latitude;
        }


        private void cmbMapProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbMapProviders.SelectedItem.ToString())
            {
                case "GoogleMapProvider":
                    gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
                    gMap.Refresh();
                    break;
                case "ArcGIS_World_Topo_MapProvider":
                    gMap.MapProvider = GMap.NET.MapProviders.ArcGIS_World_Topo_MapProvider.Instance;
                    gMap.Refresh();
                    break;
                case "GoogleTerrainMapProvider":
                    gMap.MapProvider = GMap.NET.MapProviders.GoogleTerrainMapProvider.Instance;
                    gMap.Refresh();
                    break;
                case "GoogleSatelliteMapProvider":
                    gMap.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
                    gMap.Refresh();
                    break;
                case "BingHybridMapProvider":
                    gMap.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
                    gMap.Refresh();
                    break;
                case "GoogleHybridMapProvider":
                    gMap.MapProvider = GMap.NET.MapProviders.GoogleHybridMapProvider.Instance;
                    gMap.Refresh();
                    break;
                case "BingSatelliteMapProvider":
                    gMap.MapProvider = GMap.NET.MapProviders.BingSatelliteMapProvider.Instance;
                    gMap.Refresh();
                    break;
                case "BingMapProvider":
                    gMap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
                    gMap.Refresh();
                    break;
                case "OpenCycleLandscapeMapProvider":
                    gMap.MapProvider = GMap.NET.MapProviders.OpenCycleLandscapeMapProvider.Instance;
                    gMap.Refresh();
                    break;
                case "OpenCycleMapProvider":
                    gMap.MapProvider = GMap.NET.MapProviders.OpenCycleMapProvider.Instance;
                    gMap.Refresh();
                    break;

            }
        }

        private void frmGMap_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cmbMapProviders.SelectedIndex > -1)
            {
                Properties.Settings.Default["defaultMapProvider"] = cmbMapProviders.SelectedItem.ToString(); ;
                Properties.Settings.Default.Save();
            }

        }
    }
}

