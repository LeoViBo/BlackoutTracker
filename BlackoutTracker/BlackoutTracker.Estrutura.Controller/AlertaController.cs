using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackoutTracker.Estrutura.Model;
using BlackoutTracker.Estrutura.Repository;

namespace BlackoutTracker.Estrutura.Controller
{
    public class AlertaController
    {
        AlertaRepository repository = new AlertaRepository();
        public bool NewAlerta(string Tipo, string Descricao, string Bairro, string Data, string Hora)
        {
            return repository.NewAlerta(Tipo, Descricao, Bairro, Data, Hora);
        }
        public List<Alerta> GetAlertasPorBairro(string Bairro)
        {
            return repository.GetAlertasPorBairro(Bairro);
        }
        public List<Alerta> GetAllAlertasPorBairro()
        {
            return repository.GetAllAlertasPorBairro();
        }
        public bool DeleteAlerta(int ID)
        {
            return repository.DeleteAlerta(ID);
        }

        public bool AlertaExiste(int ID)
        {
            return repository.AlertaExiste(ID);
        }
    }
}
