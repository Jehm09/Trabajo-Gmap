using System;
using model;
using System.Linq;
using System.Collections.Generic;
using GoogleDirections;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {

        //Constantes
        public const string API_KEY = "AIzaSyCevKRDYM7u0L7hZsVORxyXryiquDj3_vo";
        //Atributos
        public Geocoder geocoder = new Geocoder(API_KEY);

        public Form1() {
            InitializeComponent();
        }

        private void gMap_Load(object sender, EventArgs e) {
            // Initialize map:
            gMap.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMap.SetPositionByKeywords("Bogota, Colombia");

            //Cambiando opciones del Gmap, no mostrar el centro y cambiando el boton derecho a izquierdo para mover el mapa.
            gMap.ShowCenter = false;
            gMap.DragButton = MouseButtons.Left;
            
        }

        private void button1_Click(object sender, EventArgs e) {
            //gMap.SetPositionByKeywords(textBox1.Text);
            GMapOverlay markerOverlay = new GMapOverlay("Marcador");
            //GMap.NET.PointLatLng p = gMap.SetPositionByKeywords("asd", 464646,646546);
            //gMap.GetPositionByKeywords("Universidad Icesi, Colombia");
            //GMarkerGoogle marker = new GMarkerGoogle(gMap.GetPositionByKeywords("Universidad Icesi, Colombia"), GMarkerGoogleType.green);
            GMarkerGoogle marker = new GMarkerGoogle(new GMap.NET.PointLatLng(-25.971684, 32.589759), GMarkerGoogleType.black_small);
            markerOverlay.Markers.Add(marker); //agregar marker al mapa
            gMap.Position = new GMap.NET.PointLatLng(-25.971684, 32.589759);
            //var address = geocoder.ReverseGeocode(new LatLng(51.408580, -0.292470));
            //locations.
            var locations = geocoder.Geocode("Cali, Colombia");
            textBox1.Text = locations.First().LatLng.Latitude+"";
            //gMap.Position = new GMap.NET.PointLatLng(locations.);
           

        }

        public void addMarkers(List<Accident> lista) {



        }


    }
}
