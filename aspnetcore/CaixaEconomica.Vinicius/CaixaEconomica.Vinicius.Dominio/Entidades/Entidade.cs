using CaixaEconomica.Vinicius.Dominio.Interfaces.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEconomica.Vinicius.Dominio.Entidades
{
    public abstract class Entidade
    {
        private INotificacaoDominio _notificacaoDominio;
        protected INotificacaoDominio NotificacaoDominio
        {
            get
            {
                return _notificacaoDominio == null ?
                       throw new Exception("Erro: NotificacaoDominio não foi instanciado. Favor chamar o método SetNotificacao.") :
                       _notificacaoDominio;
            }
        }

        public void SetNotificacao(INotificacaoDominio notificacaoDominio)
        {
            _notificacaoDominio = notificacaoDominio;
        }

        public bool EhValido()
        {
            return _notificacaoDominio.Validado();
        }
    }
}
