// See https://aka.ms/new-console-template for more information
using EasyNetQ;
using ePrijevozSarajevo.Model.Messages;

Console.WriteLine("Hello, World!");


var bus = RabbitHutch.CreateBus("host=localhost");

await bus.PubSub.SubscribeAsync<TicketsActivated>
    ("console_printer", msg =>
    {
        Console.WriteLine($"1. Ticket activated: {msg.Ticket.Name}");
    });

await bus.PubSub.SubscribeAsync<TicketsActivated>
    ("console_printer", msg =>
    {
        Console.WriteLine($"2. Ticket activated: {msg.Ticket.Name}");
    });

await bus.PubSub.SubscribeAsync<TicketsActivated>
    ("mail_sender", msg =>
    {
        Console.WriteLine($"Sending email for: {msg.Ticket.Name}");
        //ToDo: send email
    });

Console.WriteLine("Listening for the messages, press ENTER to close!");
Console.ReadLine();