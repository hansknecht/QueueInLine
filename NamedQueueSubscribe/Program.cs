using System;
using EasyNetQ;
using EasyNetQMessages;

namespace NamedQueueSubscribe
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.PubSub.Subscribe<CardPaymentNamedQueue>(string.Empty, HandleCardPaymentMessage);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                { }
            }
        }

        static void HandleCardPaymentMessage(CardPaymentNamedQueue paymentMessage)
        {
            Console.WriteLine("Processing Payment = <" +
                              paymentMessage.CardNumber + ", " +
                              paymentMessage.CardHolderName + ", " +
                              paymentMessage.ExpiryDate + ", " +
                              paymentMessage.Amount + ">");
        }
    }
}