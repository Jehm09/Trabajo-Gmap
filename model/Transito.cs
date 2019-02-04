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
        public const string path = "Data_Transito.csv";

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
                objReader.ReadLine();

                while (sLine != null ) {
                    sLine = objReader.ReadLine();
                    string[] sArr = sLine.Split(',');
                    
                    if(sLine.Length > 21) {
                        Accident temp = new Accident(sArr[4], sArr[5]+", Colombia", sArr[6], sArr[7]);
                        accidents.Add(temp);
                    }
                }
                objReader.Close();
            }
            catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }

}
