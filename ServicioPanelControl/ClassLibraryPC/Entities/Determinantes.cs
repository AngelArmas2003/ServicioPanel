using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPC.Entities
{
    public class Determinantes
    {
        public string id {get;set;}
        public string Codigo_Proveedor { get; set; }
        public string CveEmpresa { get; set; }
        public string Nombre_Empresa { get; set; }
        public string CveEstamto { get; set; }

        public string Estacionamiento { get; set; }

        public string Determinante { get; set; }

        public bool Activo { get; set; }


        public List<Determinantes> DeterminantesActivas()
        {
            List<Determinantes> Listadeter = new List<Determinantes>();



            Conexion.Conexion oconexion = new Conexion.Conexion();
            using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_Lista_Plaza_Determinantes", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            Determinantes odeter = new Determinantes();
                            odeter.id = reader[0].ToString();
                            odeter.Codigo_Proveedor = reader[1].ToString();
                            odeter.CveEmpresa = reader[2].ToString();

                            odeter.Nombre_Empresa = reader[3].ToString();
                            odeter.CveEstamto = reader[4].ToString();
                            odeter.Estacionamiento = reader[5].ToString();

                            odeter.Determinante = reader[6].ToString();
                            odeter.Activo = Convert.ToBoolean(reader[7]);



                            Listadeter.Add(odeter);

                        }

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return Listadeter;
                }
            }
            return Listadeter;
         


        }

        public int Registra_Proveedor(Determinantes oDeterminantes)
        {
            int Inserta = 0;

            try
            {

                Conexion.Conexion oconexion = new Conexion.Conexion();
                SqlConnection oConecta = new SqlConnection(oconexion.conexion.ConnectionString);

                // Ejecución de sentencias SQL
                // ---------------------------

                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("Sp_RegistraProveedor", oconexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Codigo_Proveedor", SqlDbType.VarChar, 10).Value = oDeterminantes.Codigo_Proveedor;
                cmd.Parameters.Add("@CveEmpresa", SqlDbType.VarChar, 10).Value = oDeterminantes.CveEmpresa;
                cmd.Parameters.Add("@Determinante", SqlDbType.VarChar, 10).Value = oDeterminantes.Determinante;
                cmd.Parameters.Add("@CveEstamto", SqlDbType.VarChar, 10).Value = oDeterminantes.CveEstamto;
                cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = oDeterminantes.Activo;






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

        public int Update_Proveedor(Determinantes oDeterminantes)
        {
            int Inserta = 0;

            try
            {

                Conexion.Conexion oconexion = new Conexion.Conexion();
                SqlConnection oConecta = new SqlConnection(oconexion.conexion.ConnectionString);

                // Ejecución de sentencias SQL
                // ---------------------------

                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("Sp_UpdateProveedor", oconexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;


                
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = oDeterminantes.id;
                cmd.Parameters.Add("@Codigo_Proveedor", SqlDbType.VarChar, 10).Value = oDeterminantes.Codigo_Proveedor;
                cmd.Parameters.Add("@CveEmpresa", SqlDbType.VarChar, 10).Value = oDeterminantes.CveEmpresa;
                cmd.Parameters.Add("@Determinante", SqlDbType.VarChar, 10).Value = oDeterminantes.Determinante;
                cmd.Parameters.Add("@CveEstamto", SqlDbType.VarChar, 10).Value = oDeterminantes.CveEstamto;
                cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = oDeterminantes.Activo;






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

    }
}
