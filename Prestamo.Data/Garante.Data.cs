using Microsoft.Extensions.Options;
using Prestamo.Entidades;
using System.Data.SqlClient;
using System.Data;
namespace Prestamo.Data
{
    public class GaranteData
    {
        private readonly ConnectionStrings con;
        public GaranteData(IOptions<ConnectionStrings> options)
        {
            con = options.Value;
        }

        public async Task<List<Garante>> Lista()
        {
            List<Garante> lista = new List<Garante>();

            using (var conexion = new SqlConnection(con.CadenaSQL))
            {
                await conexion.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_listaGarante", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lista.Add(new Garante()
                        {
                            IdGarante = Convert.ToInt32(dr["IdGarante"]),
                            NroDocumento = dr["NroDocumento"].ToString()!,
                            Nombre = dr["Nombre"].ToString()!,
                            Apellido = dr["Apellido"].ToString()!,
                            Correo = dr["Correo"].ToString()!,
                            Telefono = dr["Telefono"].ToString()!,
                            FechaCreacion = dr["FechaCreacion"].ToString()!
                        });
                    }
                }
            }
            return lista;
        }
        public async Task<Garante> Obtener(string NroDocumento)
        {
            Garante objeto = new Garante();

            using (var conexion = new SqlConnection(con.CadenaSQL))
            {
                await conexion.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_obtenerGarante", conexion);
                cmd.Parameters.AddWithValue("@NroDocumento", NroDocumento);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        objeto = new Garante()
                        {
                            IdGarante = Convert.ToInt32(dr["IdGarante"]),
                            NroDocumento = dr["NroDocumento"].ToString()!,
                            Nombre = dr["Nombre"].ToString()!,
                            Apellido = dr["Apellido"].ToString()!,
                            Correo = dr["Correo"].ToString()!,
                            Telefono = dr["Telefono"].ToString()!,
                            FechaCreacion = dr["FechaCreacion"].ToString()!
                        };
                    }
                }
            }
            return objeto;
        }

        public async Task<string> Crear(Garante objeto)
        {

            string respuesta = "";
            using (var conexion = new SqlConnection(con.CadenaSQL))
            {
                await conexion.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_crearGarante", conexion);
                cmd.Parameters.AddWithValue("@NroDocumento", objeto.NroDocumento);
                cmd.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", objeto.Apellido);
                cmd.Parameters.AddWithValue("@Correo", objeto.Correo);
                cmd.Parameters.AddWithValue("@Telefono", objeto.Telefono);
                cmd.Parameters.Add("@msgError", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    respuesta = Convert.ToString(cmd.Parameters["@msgError"].Value)!;
                }
                catch
                {
                    respuesta = "Error al procesar";
                }
            }
            return respuesta;
        }

        public async Task<string> Editar(Garante objeto)
        {

            string respuesta = "";
            using (var conexion = new SqlConnection(con.CadenaSQL))
            {
                await conexion.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_editarGarante", conexion);
                cmd.Parameters.AddWithValue("@IdGarante", objeto.IdGarante);
                cmd.Parameters.AddWithValue("@NroDocumento", objeto.NroDocumento);
                cmd.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", objeto.Apellido);
                cmd.Parameters.AddWithValue("@Correo", objeto.Correo);
                cmd.Parameters.AddWithValue("@Telefono", objeto.Telefono);
                cmd.Parameters.Add("@msgError", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    respuesta = Convert.ToString(cmd.Parameters["@msgError"].Value)!;
                }
                catch
                {
                    respuesta = "Error al procesar";
                }
            }
            return respuesta;
        }

        public async Task<string> Eliminar(int Id)
        {

            string respuesta = "";
            using (var conexion = new SqlConnection(con.CadenaSQL))
            {
                await conexion.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_eliminarGarante", conexion);
                cmd.Parameters.AddWithValue("@IdGarante", Id);
                cmd.Parameters.Add("@msgError", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    respuesta = Convert.ToString(cmd.Parameters["@msgError"].Value)!;
                }
                catch
                {
                    respuesta = "Error al procesar";
                }
            }
            return respuesta;
        }
    }
}


