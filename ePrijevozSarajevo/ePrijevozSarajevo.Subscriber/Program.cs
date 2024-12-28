// See https://aka.ms/new-console-template for more information
using ePrijevozSarajevo.Model.Messages;
using ePrijevozSarajevo.Services.Email;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Waiting for RabbitMQ.");
Task.Delay(10000).Wait();
Console.WriteLine("Rabbit should be started now.");

var factory = new ConnectionFactory()
{
    HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST")
    ?? "localhost"
    ,
    Port = int.Parse(Environment.GetEnvironmentVariable("RABBITMQ_PORT")
    ?? "5672"
    ),
    UserName = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME")
    ?? "guest"
    ,
    Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD")
    ?? "guest"
    ,
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
      
    if (request.RequestApproved)
    {
        processResultMsg = "odobren";
    }
    else
    {
        processResultMsg = "odbijen";
    };
    Console.WriteLine($"1. Zahtjev za status: {request.RequestedStatusName} od user: {request.UserId} je {processResultMsg}.");
    Console.WriteLine($"2. Šaljem mail useru id: {request.UserId} na njegovu adresu: {request.UserEmail}.");
    string subject = $"Zahtjev {request.RequestedStatusName} je {processResultMsg}.";
    string content = $"Poštovani, <br> Vaš zahtjev za status {request.RequestedStatusName} je {processResultMsg}.<br> Ukoliko imate pitanja molimo Vas kontaktirajte na naš tim za podršku. <br><br> S poštovanjem,<br>Vaš ePrijevoz Sarajevo";

    EmailService emailService = new EmailService();
    emailService.SendNoReplyMail(request.UserEmail, subject, content);

    channel.BasicAck(args.DeliveryTag, false);
};

channel.BasicConsume(routingKey, true, consumer);


Console.WriteLine("Listening for messages. Press [enter] to quit.");
Thread.Sleep(Timeout.Infinite);