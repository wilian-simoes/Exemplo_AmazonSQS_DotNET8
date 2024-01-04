using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace AmazonSQS.Commands
{
    public class QueueSQS
    {
        private readonly AmazonSQSClient _client;
        private const string QUEUE_URL = "https://sqs...";

        public QueueSQS()
        {
            _client = new AmazonSQSClient(RegionEndpoint.USEast1);
        }

        public async Task<SendMessageResponse> SendToQueue(string messageBody)
        {
            var request = new SendMessageRequest
            {
                QueueUrl = QUEUE_URL,
                MessageBody = messageBody,
                MessageGroupId = "teste",
                MessageDeduplicationId = Guid.NewGuid().ToString(),
            };

            return await _client.SendMessageAsync(request);
        }

        public async Task<ReceiveMessageResponse> ProcessQueue()
        {
            var request = new ReceiveMessageRequest
            {
                QueueUrl = QUEUE_URL
            };

            return await _client.ReceiveMessageAsync(request);
        }

        public async Task DeleteMessageQueue(string receiptHandle)
            => await _client.DeleteMessageAsync(QUEUE_URL, receiptHandle);
    }
}