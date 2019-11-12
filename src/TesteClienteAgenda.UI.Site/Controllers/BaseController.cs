using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TesteClienteAgenda.Domain.Interfaces.Notifications;
using TesteClienteAgenda.Domain.Notifications;

namespace TesteClienteAgenda.UI.Site.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificador _notificador;

        protected BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected IEnumerable<Notificacao> GetErros()
        {
            return _notificador.ObterNotificacoes();
        }
    }
}