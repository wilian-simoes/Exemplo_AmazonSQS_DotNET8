using AmazonSQS.Commands;

Console.WriteLine("AmazonSQS.Process started.");

QueueSQS queueSQS = new();

while (true)
{
    var response = await queueSQS.ProcessQueue();

    response.Messages.ForEach(async message =>
    {
        Console.WriteLine($"Message: {message.Body}");
        await queueSQS.DeleteMessageQueue(message.ReceiptHandle);
    });
}