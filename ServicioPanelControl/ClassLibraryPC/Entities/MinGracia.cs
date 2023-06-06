using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibraryPC.Entities
{
    public class MinGracia
    {
        public string Opc { get; set; }

        public string Id { get; set; }
        public string MinutoGracia { get; set; }
        public string Descripcion { get; set; }
        public string MinGraciaP { get; set; }


        public List<MinGracia> CatalogoMinGracia(MinGracia entC)
        {
            List<MinGracia> ListaMinGracia = new List<MinGracia>();
            Conexion.Conexion oconexion = new Conexion.Conexion();
            using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SpMinGracia", conn);
                cmd.Parameters.Add("@Opc", SqlDbType.VarChar, 1).Value = entC.Opc;
                cmd.Parameters.Add("@Id", SqlDbType.VarChar,3).Value = entC.Id;
                cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar,500).Value = entC.Descripcion;
                cmd.Parameters.Add("@MinGracia", SqlDbType.VarChar,3).Value = entC.MinutoGracia;
                cmd.Parameters.Add("@MinGraciaP", SqlDbType.VarChar,3).Value = entC.MinGraciaP;                
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MinGracia ent = new MinGracia();
                            ent.Id = reader[0].ToString();
                            ent.MinutoGracia = reader[1].ToString();
                            ent.Descripcion = reader[2].ToString();
                            ent.MinGraciaP = reader[3].ToString();
                            ListaMinGracia.Add(ent);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ListaMinGracia;
                }
            }
            return ListaMinGracia;
        }

        public int MinGraciaAct(MinGracia entC)
        {
            int Inserta = 0;
            try
            {
                Conexion.Conexion oconexion = new Conexion.Conexion();
                SqlConnection oConecta = new SqlConnection(oconexion.conexion.ConnectionString);
                // Ejecución de sentencias SQL
                // ---------------------------
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SpMinGracia", oconexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Opc", SqlDbType.VarChar, 1).Value = entC.Opc;
                cmd.Parameters.Add("@Id", SqlDbType.VarChar, 3).Value = entC.Id;
                cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 500).Value = entC.Descripcion;
                cmd.Parameters.Add("@MinGracia", SqlDbType.VarChar, 3).Value = entC.MinutoGracia;
                cmd.Parameters.Add("@MinGraciaP", SqlDbType.VarChar, 3).Value = entC.MinGraciaP;

                cmd.Connection.Open();
                Inserta = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Connection.Close();
                //cmd.Connection.Open();
                //Inserta = cmd.ExecuteNonQuery();
                //cmd.Connection.Close();
                return Inserta;
            }
            catch (Exception e)
            {
                return Inserta;
            }
        }
    }
}
