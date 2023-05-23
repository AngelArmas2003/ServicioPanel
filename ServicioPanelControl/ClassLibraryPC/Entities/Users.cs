using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPC.Entities
{
    public class Users
    {
        public string id { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }

        public string Contraseña { get; set; }

        public bool Activo { get; set; }

       



        public int Registra_Usuarios(Users  usuarios)
        {
            int Inserta = 0;

            try
            {

                Conexion.Conexion oconexion = new Conexion.Conexion();
                SqlConnection oConecta = new SqlConnection(oconexion.conexion.ConnectionString);

                // Ejecución de sentencias SQL
                // ---------------------------

                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("Sp_Registra_Usuarios", oconexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = usuarios.Nombre;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuarios.Usuario;
                cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50).Value = usuarios.Contraseña;
                
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


        public int Actualiza_Usuarios(Users usuarios)
        {
            int Inserta = 0;

            try
            {

                Conexion.Conexion oconexion = new Conexion.Conexion();
                SqlConnection oConecta = new SqlConnection(oconexion.conexion.ConnectionString);

                // Ejecución de sentencias SQL
                // ---------------------------

                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("Sp_Update_Usuarios", oconexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.VarChar, 10).Value = usuarios.id;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = usuarios.Nombre;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuarios.Usuario;
                cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50).Value = usuarios.Contraseña;
                cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = usuarios.Activo;
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




        public void Catalogo_Usuarios(List<Users> Data)
        {
            Conexion.Conexion oconexion = new Conexion.Conexion();
            SqlConnection oConecta = new SqlConnection(oconexion.conexion.ConnectionString);
            DataSet dsusuarios = new DataSet();

            SqlDataAdapter daEmpresa = new SqlDataAdapter("Sp_Catalogo_Usuarios", oconexion.conexion);
            daEmpresa.SelectCommand.CommandType = CommandType.StoredProcedure;

            //daEmpresa.Fill(dsusuarios, "Usuarios");
            //Data.DataSource = dsusuarios;
            //Data.DataMember = "Usuarios";
            //Data.Refresh();

        }

        public int Valida_Email_Usuarios(string email)
        {
            int Registros = 0;


            Conexion.Conexion oconexion = new Conexion.Conexion();
            using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select count(*) from Usuarios where Email = '" + email + "'", conn);
                cmd.CommandType = CommandType.Text;


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Registros = (int)reader[0];


                        }

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return Registros;


        }


        public int Cambia_Contraseña(string Contra, string email)
        {
            int Inserta = 0;

            try
            {

                Conexion.Conexion oconexion = new Conexion.Conexion();
                SqlConnection oConecta = new SqlConnection(oconexion.conexion.ConnectionString);

                // Ejecución de sentencias SQL
                // ---------------------------

                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("Update Usuarios set Contraseña = '" + Contra + "' where Email ='" + email + "'", oconexion.conexion);
                cmd.CommandType = CommandType.Text;

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

        public void UsuariosActivos(List<Users> cb, string cve)
        {
            Conexion.Conexion oconexion = new Conexion.Conexion();
            SqlConnection oConecta = new SqlConnection(oconexion.conexion.ConnectionString);
            DataSet dsEmpresa = new DataSet();

            SqlDataAdapter daEmpresa = new SqlDataAdapter("select Usuario,Nombre  from Usuarios where Usuario ='" + cve + "'", oconexion.conexion);
            daEmpresa.SelectCommand.CommandType = CommandType.Text;

            daEmpresa.Fill(dsEmpresa, "usu");

            //cb.DataSource = dsEmpresa.Tables["usu"];
            //cb.DisplayMember = "Nombre";
            //cb.ValueMember = "usuario";


        }

       
       
        public void UsuariosActivos(List<Users>  cb)
        {
            Conexion.Conexion oconexion = new Conexion.Conexion();
            SqlConnection oConecta = new SqlConnection(oconexion.conexion.ConnectionString);
            DataSet dsEmpresa = new DataSet();

            SqlDataAdapter daEmpresa = new SqlDataAdapter("select Usuario,Nombre  from Usuarios where Activo =1", oconexion.conexion);
            daEmpresa.SelectCommand.CommandType = CommandType.Text;

            daEmpresa.Fill(dsEmpresa, "usu");

            //cb.DataSource = dsEmpresa.Tables["usu"];
            //cb.DisplayMember = "Nombre";
            //cb.ValueMember = "usuario";


        }



        public List<Users> CatalogoUsuario()
        {
            List<Users> Listausers = new List<Users>();



            Conexion.Conexion oconexion = new Conexion.Conexion();
            using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_Catalogo_Usuarios", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                     
                        while (reader.Read())
                        {
                            Users ousers = new Users();
                            ousers.id = reader[0].ToString();
                            ousers.Nombre = (string)reader[1];
                            ousers.Usuario = (string)reader[2];
                            ousers.Contraseña = (string)reader[3];
                            ousers.Activo = (bool)reader[4];
                        
                            Listausers.Add(ousers);

                        }

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return Listausers;


        }


        public int ValidaUsuario( Users  ouser)
        {
            int reg = 0;



            Conexion.Conexion oconexion = new Conexion.Conexion();
            using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_ValidaUsuario", conn);
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = ouser.Usuario;
                cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar, 20).Value = ouser.Contraseña;



                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        Users ousers = new Users();
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


        public int ValidaUsuario2(string usuario)
        {
            int reg = 0;



            Conexion.Conexion oconexion = new Conexion.Conexion();
            using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_ValidaUsuario2", conn);
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = usuario;
       



                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        Users ousers = new Users();
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







        public bool Estatus_Usuarios(string usuario, string contra)
        {
            bool Registros = false;


            Conexion.Conexion oconexion = new Conexion.Conexion();
            using (SqlConnection conn = new SqlConnection(oconexion.conexion.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select Activo from Usuarios where Usuario ='" + usuario + "'  and Contraseña ='" + contra + "'", conn);
                cmd.CommandType = CommandType.Text;


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Registros = (bool)reader[0];


                        }

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return Registros;
        }
    }
}

 
