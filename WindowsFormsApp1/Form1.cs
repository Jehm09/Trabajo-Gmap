using System;
using GMap;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void gMap_Load(object sender, EventArgs e) {
            // Initialize map:
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            //gMap.Position = new GMap.NET.PointLatLng(48.8589507, 2.2775175);
            gMap.SetPositionByKeywords("Cali, Colombia");
            gMap.ShowCenter = false;
        }
    }
}
