using System;
using model;
using GMap;
using System.Linq;
using System.Collections.Generic;
using GoogleDirections;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Drawing;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {

        //Constantes
        public const string API_KEY = "AIzaSyCevKRDYM7u0L7hZsVORxyXryiquDj3_vo";
        //Atributos
        public GMapOverlay markerOverlay = new GMapOverlay("Marcador");
        public Geocoder geocoder = new Geocoder(API_KEY);
        public Transito t;

        public Form1() {
            InitializeComponent();
            t = new Transito();
            t.load();
            addElementList(t.Accidents);

        }

        private void gMap_Load(object sender, EventArgs e) {
            // Initialize map:
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            //gMap.SetPositionByKeywords("Bogota, Colombia");
            var location = geocoder.Geocode("Bogota, Colombia");

            double lat = location.First().LatLng.Latitude;
            double lgn = location.First().LatLng.Longitude;

            gMap.Position = new GMap.NET.PointLatLng(lat, lgn);

            //Cambiando opciones del Gmap, no mostrar el centro y cambiando el boton derecho a izquierdo para mover el mapa.
            gMap.ShowCenter = false;
            gMap.DragButton = MouseButtons.Left;
            addMarkers(t.Accidents);
            gMap.Overlays.Add(markerOverlay);
            
        }

        public void addElementList(List<Accident> lista) {
            foreach (var l in lista) {
                ListViewItem list = new ListViewItem(l.Place);
                list.SubItems.Add(l.Date);
                list.SubItems.Add(l.Vehiculo);
                list.SubItems.Add(l.Placa);

                listView1.Items.Add(list);
            }

        }

     

        public void addMarkers(List<Accident> lista) {
            Bitmap bmp = (Bitmap) Image.FromFile("img/red-point.png");
            foreach (var l in lista) {
                var locations = geocoder.Geocode(l.Place);

                double lat = locations.First().LatLng.Latitude;
                double lgn = locations.First().LatLng.Longitude;

                GMarkerGoogle marker = new GMarkerGoogle(new GMap.NET.PointLatLng(lat, lgn), bmp);

                markerOverlay.Markers.Add(marker); //agregar marker al mapa
            }

        }

        private void button1_Click(object sender, EventArgs e) {
            string address = listView1.SelectedItems[0].Text;

            var locations = geocoder.Geocode(address);

            double lat = locations.First().LatLng.Latitude;
            double lgn = locations.First().LatLng.Longitude;

            gMap.Position = new GMap.NET.PointLatLng(lat, lgn);
            gMap.Zoom = 12;
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            if (listView1.SelectedIndices.Count <= 0) {
                return;
            }
            int intselectedindex = listView1.SelectedIndices[0];
            if (intselectedindex >= 0) {
                String text = listView1.Items[intselectedindex].Text;

                //do something
                //MessageBox.Show(listView1.Items[intselectedindex].Text); 
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {

        }
    }
}
