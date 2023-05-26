using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ClassLibraryPC.Business;
using ClassLibraryPC.Entities;


namespace ServicioPanelControl
{
    /// <summary>
    /// Descripción breve de WSPanelControl
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSPanelControl : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }


        [WebMethod]
        public int UserNew(string Users)
        {
            int registro = 0;

            UsersM oUser = new UsersM();
            oUser.UserNew(Users);
;


            return registro;
            
        }

        [WebMethod]
        public int UpdaterNew(string Users)
        {
            int registro = 0;

            UsersM oUser = new UsersM();
            oUser.UpdateUser(Users);
            ;


            return registro;

        }


        [WebMethod]
        public List<Users> CatalogoUsuario(Users entUser)
        {

            List<Users> oCatalogousuario = new List<Users>();


            UsersM oUser = new UsersM();
           oCatalogousuario = oUser.CatalogoUsuario(entUser);

           

            return oCatalogousuario;

        }

        [WebMethod]
        public int ValidaUsuarios(string usu, string con)
        {

            int Registro = 0;


             UsersM oUser = new UsersM();
            Registro = oUser.ValidaUsuario( usu,  con);



            return Registro;

        }


        [WebMethod]
        public int ValidaUsuarios2(string usu)
        {
            int Registro = 0;
            UsersM oUser = new UsersM();
            Registro = oUser.ValidaUsuario2(usu);
            return Registro;
        }




        [WebMethod]

        public List<Estamtos> CatalogEstamtos(Estamtos entEst)
        {

            List<Estamtos> oCatalogousuario = new List<Estamtos>(); 


            EstamtosM ocata = new EstamtosM();
            oCatalogousuario = ocata.CatalogoEstamtos(entEst);



            return oCatalogousuario;

        }

        [WebMethod]
        public List<Estamtos> EstamtosActivos()
        {

            List<Estamtos> oCatalogousuario = new List<Estamtos>();


            EstamtosM ocata = new EstamtosM();
            oCatalogousuario = ocata.EstamtosActivos();


            return oCatalogousuario;

        }
        [WebMethod]
        public List<Empresas> CatalogEmpresa(Empresas entEmp)
        {

            List<Empresas> oCatalogEmpresas = new List<Empresas>();


            EmpresasM oemp = new EmpresasM();
            oCatalogEmpresas = oemp.CatalogoEmpresa(entEmp);



            return oCatalogEmpresas;

        }

        [WebMethod]
        public int NewEstamto(string obj)
        {
            int registro = 0;

            EstamtosM oEstamto = new EstamtosM();
            oEstamto.RegistraEstamto(obj);
            


            return registro;

        }

        [WebMethod]
        public int UpdateEstamto(string Estamto)
        {
            int registro = 0;

            EstamtosM oesta = new EstamtosM();
            oesta.UpdateEstamto(Estamto);
            


            return registro;

        }
        [WebMethod]
        public int UpdaterEmpresa(string obj)
        {
            int registro = 0;

            EmpresasM oEsta = new EmpresasM();
            oEsta.Acyualiza_Empresa(obj);
            ;

            return registro;

        }

        [WebMethod]
        public int NewEmpresa(string obj)
        {
            int registro = 0;

            EmpresasM oEsta = new EmpresasM();
            oEsta.RegistraEmpresa(obj);
            ;

            return registro;

        }


        [WebMethod]
        public List<Determinantes> DeterminantesActivas(Determinantes entDet)
        {

            List<Determinantes> oListdeters = new List<Determinantes>();


            DeterminantesM odet = new DeterminantesM();
            oListdeters = odet.ListaDeterminantesActivas(entDet);



            return oListdeters;

        }
        [WebMethod]
        public int NewProveedor(string obj)
        {

            int registro = 0;

            DeterminantesM oDete = new DeterminantesM();
            registro= oDete.Newdeterminante(obj);
            

            return registro;


        }

        [WebMethod]
        public int UpdateProveedor(string obj)
        {

            int registro = 0;

            DeterminantesM oDete = new DeterminantesM();
            registro = oDete.Updatedeterminante(obj);


            return registro;


        }


        [WebMethod]
        public List<Tarifas> TafiasDeterminantes(string dete)
        {

            List<Tarifas> Listtarifadeterminantes = new List<Tarifas>();


            TarifasM otarifas = new TarifasM();
            Listtarifadeterminantes = otarifas.TarifasDeterminantes(dete);


            return Listtarifadeterminantes;

        }

        [WebMethod]
        public List<Combos> CatalogoCombos(Combos entC)
        {

            List<Combos> oListdeters = new List<Combos>();


            CombosM ocombos = new CombosM();
            oListdeters = ocombos.CatalogoCombo(entC);



            return oListdeters;

        }


        [WebMethod]
        public List<ComboDeterminantes> CatalogoCombosdeterminantes(string combo)
        {

            List<ComboDeterminantes> oListdeters = new List<ComboDeterminantes>();


            ComboDeterminantesM ocombos = new ComboDeterminantesM();
            oListdeters = ocombos.CatalogoComboDeterminantes(combo);



            return oListdeters;

        }



        [WebMethod]
        public int NewCombo(string obj)
        {

             int registro = 0;

                  CombosM oco = new CombosM();
           

             registro = oco.ComboNew(obj);


            return registro;


        }




        [WebMethod]
        public int Updatecombo(string obj)
        {

            int registro = 0;

            CombosM oco = new CombosM();
            registro = oco.UpdateCombo(obj);


            return registro;


        }


        [WebMethod]
        public int ValidaEmpresa(string rfc)
        {
            
            int Registro = 0;


            EmpresasM oEmprer = new EmpresasM();
            Registro = oEmprer.ValidaEmpresa(rfc);



            return Registro;

        }



    }
}
