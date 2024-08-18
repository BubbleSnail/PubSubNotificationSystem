public class Subscriber : ISubscriber
{
    public int UserId { get; private set; }

    public Subscriber(int userId)
    {
        UserId = userId;
    }

    public void ReceiveNotification(Poster post)
    {
        Console.WriteLine($"User {UserId} received a notification: New post by User {post.UserId} - {post.Content}");
    }
}