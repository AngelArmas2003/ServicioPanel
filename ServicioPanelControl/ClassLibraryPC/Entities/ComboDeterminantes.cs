using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPC.Entities
{
  public   class ComboDeterminantes
    {
     public string id { get; set; }

        public string NumeroCombo { get; set; }
        public string Determinante { get; set; }

        public string NombrePlaza { get; set; }
        
        public bool Activo { get; set; }



        public List<ComboDeterminantes> CatalogoCombos(string combo)
        {
            List<ComboDeterminantes> ListaCombosD = new List<ComboDeterminantes>();



            Conexion.Conexion oconexion = new Conexion.Conexion();
            using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_ComboDeterminantes", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Combo", SqlDbType.VarChar, 10).Value = combo;

                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            ComboDeterminantes ocombo = new ComboDeterminantes();
                            ocombo.id = Convert.ToString(reader[0]);
                            ocombo.NumeroCombo = reader[1].ToString();
                            ocombo.Determinante = reader[2].ToString();
                            ocombo.NombrePlaza = reader[3].ToString();
                            ocombo.Activo = Convert.ToBoolean(reader[4]);



                            ListaCombosD.Add(ocombo);

                        }

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ListaCombosD;
                }
            }
            return ListaCombosD;



        }


    }
}
