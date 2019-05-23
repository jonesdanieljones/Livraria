using Livraria.IO.Domain.Core.Notifications;
using Livraria.IO.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Livraria.IO.Site.Controllers
{
    public class BaseController : Controller
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        private readonly IUser _user;

        public Guid EditoraId { get; set; }

        public BaseController(IDomainNotificationHandler<DomainNotification> notifications, 
                              IUser user)
        {
            _notifications = notifications;
            _user = user;

            if (_user.IsAuthenticated())
            {
                EditoraId = _user.GetUserId();
            }
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.HasNotifications());
        }
    }
}
