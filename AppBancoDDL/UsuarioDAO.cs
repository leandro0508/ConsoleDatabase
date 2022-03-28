using AppBancoADO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDDL
{
    public class UsuarioDAO
    {
        private ClasseBanco db;

        public void Insert(Usuario usuario)
        {
            string dataNasc = usuario.DataNasc.ToString("yyyy-MM-dd");
            var StrQuery = "";
            StrQuery += "INSERT INTO tbUsuario(nomeUsu, cargo, DataNasc)";
            StrQuery += string.Format(" VALUES ('{0}', '{1}', '{2}');",
                                             usuario.nomeUsu, usuario.cargo, dataNasc);
            using (db = new ClasseBanco())
            {
                db.ExecutaComando(StrQuery);
            }
        }


        public void Atualizar(Usuario usuario)
        {
            var StrQuery = "";
            string dataNasc = usuario.DataNasc.ToString("yyyy-MM-dd");
            StrQuery += "UPDATE tbUsuario SET ";
            StrQuery += string.Format(" nomeUsu ='{0}', ", usuario.nomeUsu);
            StrQuery += string.Format(" cargo ='{0}', ", usuario.cargo);
            StrQuery += string.Format(" DataNasc ='{0}' ", dataNasc);
            StrQuery += string.Format(" WHERE IdUsu = {0} ", usuario.IdUsu);

            using (db = new ClasseBanco())
            {
                db.ExecutaComando(StrQuery);
            }
        }


        public void Excluir (Usuario usuario)
        {
            using (db = new ClasseBanco())
            {
                var StrQuery = string.Format(" DELETE FROM tbUsuario WHERE IdUsu = {0}", usuario.IdUsu);
                db.ExecutaComando(StrQuery);
            }
        }


        public List<Usuario> Listar()
        {
            using (db = new ClasseBanco())
            {
                var StrQuery = "SELECT * FROM tbUsuario;";
                var retorno = db.RetornaComando(StrQuery);
                return ListaDeUsuario(retorno);
            }
        }

        public List<Usuario> ListaDeUsuario(MySqlDataReader retorno)
        {
            var usuarios = new List<Usuario>();
            while (retorno.Read())
            {
                var TempUsuario = new Usuario()
                {
                        IdUsu = int.Parse(retorno["IdUsu"].ToString()),
                        nomeUsu = retorno ["nomeUsu"].ToString(),
                        cargo = retorno ["cargo"].ToString(),
                        DataNasc = DateTime.Parse(retorno["DataNasc"].ToString())
                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();
            return usuarios;
        }







    }
}
        
 