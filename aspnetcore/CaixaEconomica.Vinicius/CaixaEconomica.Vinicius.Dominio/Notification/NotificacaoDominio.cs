using CaixaEconomica.Vinicius.Dominio.Interfaces.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaixaEconomica.Vinicius.Dominio.Notification
{
    public class NotificacaoDominio : INotificacaoDominio
    {
        private List<string> _erroMensagem = new List<string>();
        public IEnumerable<string> ErroMensagem => _erroMensagem;

        private List<string> _avisoMensagem = new List<string>();
        public IEnumerable<string> AvisoMensagem => _avisoMensagem;

        public void AddAviso(string mensagem)
        {
            _avisoMensagem.Add(mensagem);
        }

        public void AddErro(string mensagem)
        {
            _erroMensagem.Add(mensagem);
        }

        public bool TemAviso()
        {
            return _avisoMensagem.Any();
        }

        public bool Validado()
        {
            if (_erroMensagem.Any())
                throw new ArgumentException(string.Join(". ", _erroMensagem.ToArray()));
            return true;
        }
    }
}
