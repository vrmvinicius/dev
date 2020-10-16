using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEconomica.Vinicius.Dominio.Interfaces.Notification
{
    public interface INotificacaoDominio
    {
        bool Validado();
        bool TemAviso();

        IEnumerable<string> ErroMensagem { get; }
        IEnumerable<string> AvisoMensagem { get; }

        void AddErro(string mensagem);
        void AddAviso(string mensagem);
    }
}
