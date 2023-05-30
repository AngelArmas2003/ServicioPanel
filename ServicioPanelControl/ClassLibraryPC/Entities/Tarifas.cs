using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPC.Entities
{
    public class Tarifas

    {

        public string id { get; set; }
        public string CveTarifa { get; set; }
        public int Minutos { get; set; }
        public double ImporteMinutos { get; set; }
        public int MinutoInicial { get; set; }
        public int MinutoFinal { get; set; }
        public double TotalAcumulado { get; set; }
        public string Determinante { get; set; }
        public int Opcion { get; set; }

        public List<Tarifas> Tarifaspordeterminante(Tarifas dete)
        {
            List<Tarifas> ListaTa = new List<Tarifas>();
            Conexion.Conexion oconexion = new Conexion.Conexion();
            using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_Listatari_Det", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Deter", SqlDbType.VarChar, 10).Value = dete.Determinante;
                cmd.Parameters.Add("@opc", SqlDbType.Int).Value = dete.Opcion;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Tarifas otarifa = new Tarifas();
                            otarifa.id = reader[0].ToString();
                            otarifa.CveTarifa = reader[1].ToString();
                            otarifa.Minutos = Convert.ToInt32(reader[2]);
                            otarifa.ImporteMinutos = Convert.ToDouble(reader[3]);
                            otarifa.MinutoInicial = Convert.ToInt32(reader[4]);
                            otarifa.MinutoFinal = Convert.ToInt32(reader[5]);
                            otarifa.TotalAcumulado = Convert.ToDouble(reader[6]);
                            otarifa.Determinante = reader[7].ToString();
                            ListaTa.Add(otarifa);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ListaTa;
                }
            }
            return ListaTa;
        }

        public string TarifaCveConsulta(Tarifas dete)
        {
            string result = "";
            Conexion.Conexion oconexion = new Conexion.Conexion();
            using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SpTarifaCveConsulta", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Determinante", SqlDbType.VarChar, 10).Value = dete.Determinante;
                cmd.Parameters.Add("@opc", SqlDbType.Int).Value = dete.Opcion;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = reader[0].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return result;
                }
            }
            return result;
        }

        public int TarifaDetExceReg_Act(Tarifas dete)
        {
            int Inserta = 0;
            try
            {
                Conexion.Conexion oconexion = new Conexion.Conexion();
                SqlConnection oConecta = new SqlConnection(oconexion.conexion.ConnectionString);
                // Ejecución de sentencias SQL
                // ---------------------------
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SpTarifaDetExce", oconexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@opc", SqlDbType.Int).Value = dete.Opcion;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(dete.id);
                cmd.Parameters.Add("@CveTarifa", SqlDbType.VarChar, 4).Value = dete.CveTarifa;
                cmd.Parameters.Add("@Minutos", SqlDbType.VarChar, 4).Value = dete.Minutos;
                cmd.Parameters.Add("@ImporteMinutos", SqlDbType.VarChar, 4).Value = dete.ImporteMinutos;
                cmd.Parameters.Add("@MinutoInicial", SqlDbType.VarChar, 4).Value = dete.MinutoInicial;
                cmd.Parameters.Add("@MinutoFinal", SqlDbType.VarChar, 4).Value = dete.MinutoFinal;
                cmd.Parameters.Add("@TotalAcumulado", SqlDbType.VarChar, 4).Value = dete.TotalAcumulado;
                cmd.Parameters.Add("@Determinante", SqlDbType.VarChar, 4).Value = dete.Determinante;
                cmd.Connection.Open();
                Inserta = Convert.ToInt32(cmd.ExecuteScalar());
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
