using ClassLibraryPC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPC.Business
{
   public class ComboDeterminantesM
    {
        public List<ComboDeterminantes> CatalogoComboDeterminantes(string combo)

        {


            List<ComboDeterminantes> ocombo = new List<ComboDeterminantes>();

            ComboDeterminantes ocom = new ComboDeterminantes();

            ocombo = ocom.CatalogoCombos(combo);


            //Catalogousuario =  JsonConvert.SerializeObject(oUsurs);


            return ocombo;
        }
    }
}
