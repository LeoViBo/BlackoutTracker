using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackoutTracker.Estrutura.Repository;

namespace BlackoutTracker.Estrutura.Controller
{
    public class UsuarioController
    {
        UsuarioRepository repositorio = new UsuarioRepository();
        public bool validarUsuarioSenha(string Nome, string Senha)
        {
            return repositorio.validarLogin(Nome, Senha);
        }
        public int GetID()
        {
            return repositorio.GetID();
        }
        public string GetBairro(int ID)
        {
            return repositorio.GetBairro(ID);
        }

        public string GetTipo(int ID)
        {
            return repositorio.GetTipo(ID);
        }
    }

}
