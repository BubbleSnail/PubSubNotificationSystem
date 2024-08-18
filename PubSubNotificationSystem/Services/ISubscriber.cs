public interface ISubscriber
{
    int UserId { get; }
    void ReceiveNotification(Poster post);
}