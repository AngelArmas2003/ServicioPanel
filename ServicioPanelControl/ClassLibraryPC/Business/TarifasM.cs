using ClassLibraryPC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPC.Business
{
  public  class TarifasM
    {
        public List<Tarifas> TarifasDeterminantes(string dete)

        {


            List<Tarifas> ListaTarifas = new List<Tarifas>();

            Tarifas otarifas = new Tarifas();

            ListaTarifas = otarifas.Tarifaspordeterminante(dete);


            //Catalogousuario =  JsonConvert.SerializeObject(oUsurs);


            return ListaTarifas;
        }
    }
}
