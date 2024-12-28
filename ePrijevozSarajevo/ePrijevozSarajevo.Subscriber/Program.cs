// See https://aka.ms/new-console-template for more information
using ePrijevozSarajevo.Model.Messages;
using ePrijevozSarajevo.Services.Email;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;


Console.WriteLine("Waiting for Rabbit.");
Task.Delay(10000).Wait();
Console.WriteLine("Rabbit should be started now.");

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    Port = 5672,
    UserName = "guest",
    Password = "guest",
    ClientProvidedName = "Rabbit Test Consumer"
};

var connection = factory.CreateConnection();
var channel = connection.CreateModel();

string routingKey = "email_queue";

channel.QueueDeclare(queue:routingKey,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, args) =>
{
    var body = args.Body.ToArray();
    string message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Message received: {message}");
    var request = JsonConvert.DeserializeObject<RequestsProcessed>(message);

    string processResultMsg;
      
    if (request.requestApproved)
    {
        processResultMsg = "odobren";
    }
    else
    {
        processResultMsg = "odbijen";
    };
    Console.WriteLine($"1. Zahtjev za status: {request.requestedStatusName} od user:{request.userId} je {processResultMsg}.");
    Console.WriteLine($"2. Saljem mail useru id: {request.userId} na njegovu adressu: {request.userEmail}.");
    string subject = $"Zahtjev {request.requestedStatusName} je {processResultMsg}.";
    string content = $"Postovani,\n\n vas zahtjev za status {request.requestedStatusName} je {processResultMsg}.\n Ukoliko imate pitanja molimo Vas kontaktirajte na nas tim za podrsku. \n\n S postovanjem,\nVas ePrijevoz Sarajevo";

    EmailService emailService = new EmailService();
    emailService.SendNoReplyMail(request.userEmail, subject, content);

    channel.BasicAck(args.DeliveryTag, false);
};

channel.BasicConsume(routingKey, true, consumer);


Console.WriteLine("Listening for messages. Press [enter] to quit.");
Thread.Sleep(Timeout.Infinite);