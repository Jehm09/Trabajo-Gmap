using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model {
    public class Transito {
        //Atributos
        private List<Accident> accidents;
        public const string path = "/Data/Data_Transito.csv";

        //Constructor
        public Transito() {
            Accidents = new List<Accident>();
        }

        //Get And Set
        public List<Accident> Accidents { get => accidents; set => accidents = value; }

        //Methods
        public void load() {
            try {

                StreamReader objReader = new StreamReader(path);
                string sLine = "";

                while (sLine != null) {
                    sLine = objReader.ReadLine();
                    Console.WriteLine(sLine);
                }
                objReader.Close();
            }
            catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }

}
