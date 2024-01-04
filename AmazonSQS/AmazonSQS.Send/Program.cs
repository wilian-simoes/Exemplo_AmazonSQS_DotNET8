using AmazonSQS.Commands;

Console.WriteLine("AmazonSQS.Send started.");

QueueSQS queueSQS = new();
var response = await queueSQS.SendToQueue("teste 123 Wilian");

Console.WriteLine($"Mensagem Enviada. MessageId: {response.MessageId}");
