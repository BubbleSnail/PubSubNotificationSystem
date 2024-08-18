using System;
using System.Collections.Generic;
using Xunit;

namespace PubSubNotificationSystem.Tests
{
    public class PubSubTests
    {
        [Fact]
        public void Subscriber_ReceivesNotification_WhenNewPostIsPublished()
        {
            // Arrange
            var user1 = new User { Id = 1, Name = "User1" };
            var user2 = new User { Id = 2, Name = "User2", FollowedUserIds = new List<int> { 1 } };
            var users = new List<User> { user1, user2 };

            var post = new Poster { Id = 1, UserId = 1, Content = "Hello World!", Timestamp = DateTime.Now };

            var subscriber = new MockSubscriber(user2.Id);
            var publisher = new Publisher();
            publisher.Subscribe(subscriber);

            // Act
            publisher.PublishPost(post, users);

            // Assert
            Assert.Contains(post.Content, subscriber.ReceivedNotification);
        }
    }

    public class MockSubscriber : ISubscriber
    {
        public int UserId { get; }
        public string ReceivedNotification { get; private set; }

        public MockSubscriber(int userId)
        {
            UserId = userId;
        }

        public void ReceiveNotification(Poster post)
        {
            ReceivedNotification = post.Content;
        }
    }
}