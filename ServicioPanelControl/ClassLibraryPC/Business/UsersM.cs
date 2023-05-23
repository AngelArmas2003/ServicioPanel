using ClassLibraryPC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClassLibraryPC.Business
{
    public class UsersM
    {
        public int UserNew(string obj)

        {
            Users oUsurs = new Users();


            var myDeserializedClass = JsonConvert.DeserializeObject<Users>(obj);

            oUsurs = myDeserializedClass;

            oUsurs.Registra_Usuarios(oUsurs);

            int reg = 0;

            return reg;
        }



        public int UpdateUser(string obj)

        {
            Users oUsurs = new Users();


            var myDeserializedClass = JsonConvert.DeserializeObject<Users>(obj);

            oUsurs = myDeserializedClass;

            oUsurs.Actualiza_Usuarios(oUsurs);

            int reg = 0;

            return reg;
        }

        public List<Users> CatalogoUsuario()

        {
         
                
            List<Users> oUsurs = new List<Users>();

            Users ousu = new Users();

            oUsurs = ousu.CatalogoUsuario();


          //Catalogousuario =  JsonConvert.SerializeObject(oUsurs);


            return oUsurs;
        }


        public int ValidaUsuario(string usu, string con)

        {


            int reg = 0;

             Users ousu = new Users();


            Utility outy = new Utility();

       


            ousu.Usuario = usu;
            ousu.Contraseña = outy.Desencripta(con);

           

            reg = ousu.ValidaUsuario(ousu);


            //Catalogousuario =  JsonConvert.SerializeObject(oUsurs);


            return reg;
        }


        public int ValidaUsuario2(string usu)

        {


            int reg = 0;

            Users ousu = new Users();


            Utility outy = new Utility();







            reg = ousu.ValidaUsuario2(usu);


            //Catalogousuario =  JsonConvert.SerializeObject(oUsurs);


            return reg;
        }


    }
}
