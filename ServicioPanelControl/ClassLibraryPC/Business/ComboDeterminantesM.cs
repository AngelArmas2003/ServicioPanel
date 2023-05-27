using ClassLibraryPC.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPC.Business
{
   public class ComboDeterminantesM
    {
        public List<ComboDeterminantes> CatalogoComboDeterminantes(ComboDeterminantes ent)

        {


            List<ComboDeterminantes> ocombo = new List<ComboDeterminantes>();

            ComboDeterminantes ocom = new ComboDeterminantes();

            ocombo = ocom.CatalogoCombos(ent);


            //Catalogousuario =  JsonConvert.SerializeObject(oUsurs);


            return ocombo;
        }

        public int ComboDeterminanteReg_Act(string obj)
        {
            int reg = 0;
            ComboDeterminantes ocom = new ComboDeterminantes();
            var myDeserializedClass = JsonConvert.DeserializeObject<ComboDeterminantes>(obj);
            ocom = myDeserializedClass;
            reg = ocom.ComboDeterminanteReg_Act(ocom);
            return reg;
        }
    }
}
