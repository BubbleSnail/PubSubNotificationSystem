using System;
using System.Collections.Generic;

namespace PubSubNotificationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var user1 = new User { Id = 1, Name = "User1" };
            var user2 = new User { Id = 2, Name = "User2", FollowedUserIds = new List<int> { 1 } };
            var user3 = new User { Id = 3, Name = "User3", FollowedUserIds = new List<int> { 1 } };

            var users = new List<User> { user1, user2 , user3};

            var post = new Poster { Id = 1, UserId = 1, Content = "Xin chao!", Timestamp = DateTime.Now };

            var subscriber = new Subscriber(user2.Id);
            var subscriber2 = new Subscriber(user3.Id);

            var publisher = new Publisher();

            publisher.Subscribe(subscriber);
            publisher.Subscribe(subscriber2);


            publisher.PublishPost(post, users);
        }
    }
}