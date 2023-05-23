using ClassLibraryPC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClassLibraryPC.Business
{
   public class EstamtosM
    {
        //public int UserNew(string obj)

        //{
        //    Estamtos oUsurs = new Estamtos();


        //    var myDeserializedClass = JsonConvert.DeserializeObject<Estamtos>(obj);

        //    oUsurs = myDeserializedClass;

        //    oUsurs.Registra_Estamtos(oUsurs);

        //    int reg = 0;

        //    return reg;
        //}



        public int UpdateEstamto(string obj)

        {
            Estamtos oesta = new Estamtos();


            var myDeserializedClass = JsonConvert.DeserializeObject<Estamtos>(obj);

           var  esta = myDeserializedClass;

            oesta.Actualiza_Estamtos(esta);

            int reg = 0;

            return reg;
        }

        public List<Estamtos> CatalogoEstamtos()

        {


            List<Estamtos> oEstamtos = new List<Estamtos>();

            Estamtos ousu = new Estamtos();

            oEstamtos = ousu.CatalogoEstamtos();


            //Catalogousuario =  JsonConvert.SerializeObject(oUsurs);


            return oEstamtos;
        }

        public List<Estamtos> EstamtosActivos()

        {


            List<Estamtos> oEstamtos = new List<Estamtos>();

            Estamtos ousu = new Estamtos();

            oEstamtos = ousu.EstamtosActivos();


            //Catalogousuario =  JsonConvert.SerializeObject(oUsurs);


            return oEstamtos;
        }

        public int RegistraEstamto(string oes)

        {

            Estamtos oesta = new Estamtos();


            var myDeserializedClass = JsonConvert.DeserializeObject<Estamtos>(oes);

            oesta = myDeserializedClass;

            oesta.Registra_Estamtos(oesta);

            int reg = 0;

            return reg;
        }




        //public int ValidaUsuario(string usu, string con)

        //{


        //    int reg = 0;

        //    Estamtos ousu = new Estamtos();


        //    Utility outy = new Utility();

        //    var pass = outy.Desencripta(con);


        //    ousu.Usuario = usu;
        //    ousu.Contraseña = pass;



        //    reg = ousu.ValidaEstamtos(ousu);


        //    //Catalogousuario =  JsonConvert.SerializeObject(oUsurs);


        //    return reg;
        //}

    }

}
