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





        public List<Tarifas> Tarifaspordeterminante(string dete)
        {
            List<Tarifas> ListaTa = new List<Tarifas>();



            Conexion.Conexion oconexion = new Conexion.Conexion();
            using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_Listatari_Det", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Deter", SqlDbType.VarChar, 10).Value = dete;


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
    }
}
