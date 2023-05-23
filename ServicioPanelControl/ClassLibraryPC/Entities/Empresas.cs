using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPC.Entities
{
    public class Empresas
    {
        public string idEmpresa { get; set; }
        public string NombreEmpresa { get; set; }

        public string Rfc { get; set; }





        public List<Empresas> CatalogoEmpresa()
        {
            List<Empresas> ListaEmpresas = new List<Empresas>();



            Conexion.Conexion oconexion = new Conexion.Conexion();
            using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_CatalogoEmpresas", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            Empresas oEmpresa = new Empresas();
                            oEmpresa.idEmpresa = reader[0].ToString();
                            oEmpresa.NombreEmpresa = reader[1].ToString();
                            oEmpresa.Rfc = reader[2].ToString();



                            ListaEmpresas.Add(oEmpresa);

                        }

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ListaEmpresas;
                }
            }
            return ListaEmpresas;
            ;


        }


        public int Alta_Empresa(Empresas oEmpe)
        {
            int Inserta = 0;

            try
            {

                Conexion.Conexion oconexion = new Conexion.Conexion();
                SqlConnection oConecta = new SqlConnection(oconexion.conexion.ConnectionString);

                // Ejecución de sentencias SQL
                // ---------------------------

                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("Sp_NewEmpresa", oconexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Empresa", SqlDbType.VarChar, 100).Value = oEmpe.NombreEmpresa;
                cmd.Parameters.Add("@Rfc", SqlDbType.VarChar, 100).Value = oEmpe.Rfc;


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


        public int Actualiza_Empresa(Empresas oEmpe)
        {
            int Inserta = 0;

            try
            {

                Conexion.Conexion oconexion = new Conexion.Conexion();
                SqlConnection oConecta = new SqlConnection(oconexion.conexion.ConnectionString);

                // Ejecución de sentencias SQL
                // ---------------------------

                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("Sp_UpdateEmpresa", oconexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CveEmpresa", SqlDbType.VarChar, 10).Value = oEmpe.idEmpresa;
                cmd.Parameters.Add("@Empresa", SqlDbType.VarChar, 100).Value = oEmpe.NombreEmpresa;
                cmd.Parameters.Add("@Rfc", SqlDbType.VarChar, 100).Value = oEmpe.Rfc;


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


        public int ValidaEmpresa(string rfc)
        {
            int reg = 0;



            Conexion.Conexion oconexion = new Conexion.Conexion();
            using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_ValidaEmpresa", conn);
                cmd.Parameters.Add("@Rfc", SqlDbType.VarChar, 30).Value = rfc;
                



                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            reg = (int)reader[0];

                        }

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return reg;


        }




    }

}
