using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPC.Entities
{
  public   class Estamtos
    {

        public string CveEmpresa { get; set; }
        public string CveEstamto { get; set; }
        public string NombreEstamto { get; set; }
        public string NombreEmpresa { get; set; }
        public string Pais { get; set; }
        public string Entidad { get; set; }
        public string Delegacion { get; set; }
        public string Colonia { get; set; }
        public string Cp { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Condicion { get; set; }
        public string Tipo { get; set; }
        public string CveEstamtoAdmin { get; set; }



        public int Registra_Estamtos(Estamtos oestamtos)
        {
            int Inserta = 0;

            try
            {

                Conexion.Conexion oconexion = new Conexion.Conexion();
                SqlConnection oConecta = new SqlConnection(oconexion.conexion.ConnectionString);

                // Ejecución de sentencias SQL
                // ---------------------------

                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("Sp_Registra_Estamto", oconexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cveEmpresa", SqlDbType.VarChar, 100).Value = oestamtos.CveEmpresa;
                cmd.Parameters.Add("@NombreEstamto", SqlDbType.VarChar, 50).Value = oestamtos.NombreEstamto;
               
                cmd.Connection.Open();
                Inserta = cmd.ExecuteNonQuery();
                cmd.Connection.Close();




                return Inserta;
            }
            catch (Exception e)
            {
                return Inserta;
            }
        }


        public int Actualiza_Estamtos(Estamtos Oestamtos)
        {
            int Inserta = 0;

            try
            {

                Conexion.Conexion oconexion = new Conexion.Conexion();
                SqlConnection oConecta = new SqlConnection(oconexion.conexion.ConnectionString);

                // Ejecución de sentencias SQL
                // ---------------------------

                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("Sp_Update_Estamtos", oconexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CveEstamto", SqlDbType.VarChar, 10).Value = Oestamtos.CveEstamto;
                cmd.Parameters.Add("@NombreEstamto", SqlDbType.VarChar, 100).Value = Oestamtos.NombreEstamto;
                

                cmd.Connection.Open();
                Inserta = cmd.ExecuteNonQuery();
                cmd.Connection.Close();



                return Inserta;
            }
            catch (Exception e)
            {
                return Inserta;
            }
        }




      


        public List<Estamtos> CatalogoEstamtos(Estamtos entEst)
        {
            List<Estamtos> ListaEstamtos = new List<Estamtos>();



            Conexion.Conexion oconexion = new Conexion.Conexion();
            using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_Catalogo_Estamtos", conn);
                cmd.Parameters.Add("@NombreEsta", SqlDbType.VarChar, 10).Value = entEst.NombreEstamto;
                cmd.Parameters.Add("@NombreEmp", SqlDbType.VarChar, 100).Value = entEst.NombreEmpresa;
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                       
                        while (reader.Read())
                        {
                            Estamtos oEstam = new Estamtos();
                            oEstam.CveEmpresa = reader[0].ToString();
                            oEstam.CveEstamto = reader[1].ToString();
                            oEstam.NombreEstamto = reader[2].ToString();
                            oEstam.NombreEmpresa= reader[3].ToString();
                            oEstam.Pais = reader[4].ToString();
                            oEstam.Entidad = reader[5].ToString();
                            oEstam.Delegacion = reader[6].ToString();
                            oEstam.Colonia = reader[7].ToString();
                            oEstam.Cp = reader[8].ToString();
                            oEstam.Calle = reader[9].ToString();
                            oEstam.Numero = reader[10].ToString();
                            oEstam.Condicion = reader[11].ToString();
                            oEstam.Tipo = reader[12].ToString();
                            oEstam.CveEstamtoAdmin = reader[13].ToString();

                         
                            ListaEstamtos.Add(oEstam);

                        }

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ListaEstamtos;
                }
            }
            return ListaEstamtos;
            


        }
        public List<Estamtos> EstamtosActivos()
        {
            List<Estamtos> ListaEstamtos = new List<Estamtos>();



            Conexion.Conexion oconexion = new Conexion.Conexion();
            using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_EstamtosActvos", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            Estamtos oEstam = new Estamtos();
                          
                            oEstam.CveEstamto = reader[0].ToString();
                            oEstam.NombreEstamto = reader[1].ToString();
                           


                            ListaEstamtos.Add(oEstam);

                        }

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ListaEstamtos;
                }
            }
            return ListaEstamtos;
            ;


        }


        //public int ValidaUsuario(Users ouser)
        //{
        //    int reg = 0;



        //    Conexion.Conexion oconexion = new Conexion.Conexion();
        //    using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("Sp_ValidaUsuario", conn);
        //        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = ouser.Usuario;
        //        cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar, 20).Value = ouser.Contraseña;



        //        cmd.CommandType = CommandType.StoredProcedure;


        //        try
        //        {
        //            conn.Open();

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            if (reader.HasRows)
        //            {
        //                Users ousers = new Users();
        //                while (reader.Read())
        //                {

        //                    reg = (int)reader[0];

        //                }

        //            }


        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //    return reg;


        //}








        //public bool Estatus_Usuarios(string usuario, string contra)
        //{
        //    bool Registros = false;


        //    Conexion.Conexion oconexion = new Conexion.Conexion();
        //    using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("Select Activo from Usuarios where Usuario ='" + usuario + "'  and Contraseña ='" + contra + "'", conn);
        //        cmd.CommandType = CommandType.Text;


        //        try
        //        {
        //            conn.Open();

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {

        //                    Registros = (bool)reader[0];


        //                }

        //            }


        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //    return Registros;
        //}
    }
}
