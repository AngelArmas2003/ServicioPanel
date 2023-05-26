using ClassLibraryPC.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPC.Business
{
 public   class EmpresasM
    {

        public List<Empresas> CatalogoEmpresa(Empresas entEmp)

        {


            List<Empresas> oEmpresas = new List<Empresas>();

            Empresas oEmp = new Empresas();

            oEmpresas = oEmp.CatalogoEmpresa(entEmp);


            //Catalogousuario =  JsonConvert.SerializeObject(oUsurs);


            return oEmpresas;
        }


        public int RegistraEmpresa(string oem)

        {

            Empresas oempr = new Empresas();
            


            var myDeserializedClass = JsonConvert.DeserializeObject<Empresas>(oem);

            oempr = myDeserializedClass;

            oempr.Alta_Empresa(oempr);

            int reg = 0;

            return reg;
        }

        public int Acyualiza_Empresa(string oem)

        {

            Empresas oempr = new Empresas();



            var myDeserializedClass = JsonConvert.DeserializeObject<Empresas>(oem);

            oempr = myDeserializedClass;

            oempr.Actualiza_Empresa(oempr);

            int reg = 0;

            return reg;
        }



        public int ValidaEmpresa(string rfc)

        {


            int reg = 0;

            Empresas oempr = new Empresas();


         
            reg = oempr.ValidaEmpresa(rfc);


            //Catalogousuario =  JsonConvert.SerializeObject(oUsurs);


            return reg;
        }


    }
}
