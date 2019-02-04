using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model {
    public class Accident {
        private string date;
        private string place;
        private string vehicle;
        private string plateNumber;

        public Accident(string date, string place, string vehicle, string plateNumber) {
            this.date = date;
            this.place = place;
            this.vehicle = vehicle;
            this.plateNumber = plateNumber;
        }

        public string Date { get => date; set => date = value; }
        public string Place { get => place; set => place = value; }
        public string Vehiculo { get => vehicle; set => vehicle = value; }
        public string Placa { get => plateNumber; set => plateNumber = value; }
    }
}
