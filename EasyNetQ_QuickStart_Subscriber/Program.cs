using System;
using EasyNetQ;
using EasyNetQMessages;

namespace EasyNetQTestSubscriber
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.PubSub.Subscribe<TextMessage>("test", HandleTextMessage);

                Console.WriteLine("Listening for messages.");
                while (true) { }
            }
        }

        static void HandleTextMessage(TextMessage textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: {0}", textMessage.Text);
            Console.ResetColor();
        }
    }
}
