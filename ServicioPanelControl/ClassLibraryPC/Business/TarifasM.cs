using ClassLibraryPC.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPC.Business
{
  public  class TarifasM
    {
        public List<Tarifas> TarifasDeterminantes(Tarifas dete)
        {
            List<Tarifas> ListaTarifas = new List<Tarifas>();
            Tarifas otarifas = new Tarifas();
            ListaTarifas = otarifas.Tarifaspordeterminante(dete);
            return ListaTarifas;
        }

        public string TarifaCveConsulta(Tarifas dete)
        {
            string result = "";
            Tarifas otarifas = new Tarifas();
            result = otarifas.TarifaCveConsulta(dete);
            return result;
        }

        public int TarifaDetExceReg_Act(string obj)
        {
            int reg = 0;
            Tarifas ocom = new Tarifas();
            var myDeserializedClass = JsonConvert.DeserializeObject<Tarifas>(obj);
            ocom = myDeserializedClass;
            reg = ocom.TarifaDetExceReg_Act(ocom);
            return reg;
        }
    }
}
