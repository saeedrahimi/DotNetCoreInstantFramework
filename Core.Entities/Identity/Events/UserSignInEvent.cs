using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Core.Domain.Identity.Events
{
    public class UserSignInEvent : INotification
    {

        public string UserName { get; set; }

        public UserSignInEvent(string userName)
        {
            UserName = userName;
        }


    }


    public class UserSignInSmsEventHandler : INotificationHandler<UserSignInEvent>
    {

        public Task Handle(UserSignInEvent notification, CancellationToken cancellationToken)
        {

            // IMessageSender.Send($"Welcome {notification.FirstName} {notification.LastName} !")
            return Task.CompletedTask;
        }
    }


    public class UserSignInEmailEventHandler : INotificationHandler<UserSignInEvent>
    {

        public Task Handle(UserSignInEvent notification, CancellationToken cancellationToken)
        {

            // IMessageSender.Send($"Welcome {notification.FirstName} {notification.LastName} !")
            return Task.CompletedTask;
        }
    }

}
