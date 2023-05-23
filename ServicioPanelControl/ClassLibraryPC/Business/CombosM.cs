using ClassLibraryPC.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPC.Business
{
   public class CombosM
    {

        public int ComboNew(string obj)

        {
            Combos ocombo = new Combos();


            var myDeserializedClass = JsonConvert.DeserializeObject<Combos>(obj);

            ocombo = myDeserializedClass;

            int reg =  ocombo.Registra_Combo(ocombo);

          

            return reg;
        }

        public int UpdateCombo(string obj)

        {
            int reg = 0;
            Combos ocombo = new Combos();


            var myDeserializedClass = JsonConvert.DeserializeObject<Combos>(obj);

            ocombo = myDeserializedClass;

            reg=  ocombo.Update_Combo(ocombo);

           

            return reg;
        }


        public List<Combos> CatalogoCombo()

        {


            List<Combos> ocombo = new List<Combos>();

            Combos ocom = new Combos();

            ocombo = ocom.CatalogoCombos();


            //Catalogousuario =  JsonConvert.SerializeObject(oUsurs);


            return ocombo;
        }




    }
}
