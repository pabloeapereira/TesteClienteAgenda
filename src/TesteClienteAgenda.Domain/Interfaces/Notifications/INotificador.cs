using System.Collections.Generic;
using TesteClienteAgenda.Domain.Notifications;

namespace TesteClienteAgenda.Domain.Interfaces.Notifications
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}