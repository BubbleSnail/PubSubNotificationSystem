using System.Collections.Generic;

public class Publisher
{
    private readonly List<ISubscriber> _subscribers = new List<ISubscriber>();

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void PublishPost(Poster post, List<User> users)
    {
        foreach (var user in users)
        {
            if (user.FollowedUserIds.Contains(post.UserId))
            {
                NotifySubscribers(user, post);
            }
        }
    }

    private void NotifySubscribers(User user, Poster post)
    {
        foreach (var subscriber in _subscribers)
        {
            if (subscriber.UserId == user.Id)
            {
                subscriber.ReceiveNotification(post);
            }
        }
    }
}