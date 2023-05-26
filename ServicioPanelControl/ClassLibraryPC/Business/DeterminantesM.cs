using ClassLibraryPC.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPC.Business
{
 public   class DeterminantesM
    {

        public List<Determinantes> ListaDeterminantesActivas(Determinantes entDet)

        {


            List<Determinantes> ODete = new List<Determinantes>();

            Determinantes odetermi = new Determinantes();

            ODete = odetermi.DeterminantesActivas(entDet);


            //Catalogousuario =  JsonConvert.SerializeObject(oUsurs);


            return ODete;
        }


        public int Newdeterminante(string obj)

        {
            int reg = 0;
            Determinantes oProve = new Determinantes();


            var myDeserializedClass = JsonConvert.DeserializeObject<Determinantes>(obj);

            oProve = myDeserializedClass;

            reg= oProve.Registra_Proveedor(oProve);

         

            return reg;
        }

        public int Updatedeterminante(string obj)

       
        {
            int reg = 0;
            Determinantes oProve = new Determinantes();


            var myDeserializedClass = JsonConvert.DeserializeObject<Determinantes>(obj);

            oProve = myDeserializedClass;

            reg =oProve.Update_Proveedor(oProve);

       

            return reg;
        }
    }
}
