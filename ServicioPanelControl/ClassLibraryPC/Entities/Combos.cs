using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPC.Entities
{
   public class Combos
    {

        public string id { get; set; }
        public string Combo { get; set; }
        public bool Activo { get; set; }
        public string DescripcionCombo { get; set; }




        public List<Combos> CatalogoCombos(Combos entC)
        {   
            List<Combos> ListaCombos = new List<Combos>();



            Conexion.Conexion oconexion = new Conexion.Conexion();
            using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_Catalogo_Combos", conn);
                cmd.Parameters.Add("@Combo", SqlDbType.VarChar, 10).Value = entC.Combo;
                cmd.Parameters.Add("@DescripcionCombo", SqlDbType.VarChar, 100).Value = entC.DescripcionCombo;
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            Combos ocombo = new Combos();
                            ocombo.id = Convert.ToString(reader[0]);
                            ocombo.Combo = reader[1].ToString();
                            ocombo.Activo = Convert.ToBoolean(reader[2]);
                            ocombo.DescripcionCombo = reader[3].ToString();
                           


                            ListaCombos.Add(ocombo);

                        }

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ListaCombos;
                }
            }
            return ListaCombos;



        }

        public int Registra_Combo(Combos ocombo)
        {
            int Inserta = 0;

            try
            {

                Conexion.Conexion oconexion = new Conexion.Conexion();
                SqlConnection oConecta = new SqlConnection(oconexion.conexion.ConnectionString);

                // Ejecución de sentencias SQL
                // ---------------------------

                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("Sp_RegistraCombo", oconexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Combo", SqlDbType.VarChar, 10).Value = ocombo.Combo;
                cmd.Parameters.Add("@DescripcionCombo", SqlDbType.VarChar, 100).Value = ocombo.DescripcionCombo;
                cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = ocombo.Activo;







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

        public int Update_Combo(Combos ocombo)
        {
            int Inserta = 0;

            try
            {

                Conexion.Conexion oconexion = new Conexion.Conexion();
                SqlConnection oConecta = new SqlConnection(oconexion.conexion.ConnectionString);

                // Ejecución de sentencias SQL
                // ---------------------------

                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("[Sp_UpdateCombo]", oconexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ocombo.id;
                cmd.Parameters.Add("@Combo", SqlDbType.VarChar, 10).Value = ocombo.Combo;
                cmd.Parameters.Add("@DescripcionCombo", SqlDbType.VarChar, 100).Value = ocombo.DescripcionCombo;
                cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = ocombo.Activo;






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
