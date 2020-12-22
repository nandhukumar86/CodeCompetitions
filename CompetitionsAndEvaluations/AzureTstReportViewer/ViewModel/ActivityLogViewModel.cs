using AzureTstReportViewer.Model;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AzureTstReportViewer.ViewModel
{
    public class ActivityLogViewModel
    {

        const string ServiceBusConnectionString = "Endpoint=sb://azuretstservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=mlQkjnF+y/RuotajlXFhhJu8FINkXZh3WIryHJ1smSw=";
        const string TopicName = "azuretsttopic";
        //const string SubscriptionName = "azuretsttopicsubscription";
        const string SubscriptionName = "dummysubscriber";
        public ISubscriptionClient subscriptionClient;

        public ObservableCollection<ActivityLog> ActivityLogs { get; set; } = new ObservableCollection<ActivityLog>();

        public BlockingCollection<ActivityLog> blockingCollection { get; set; } = new BlockingCollection<ActivityLog>();
        public ICommand ButtonCommand { get; set; }

        public ActivityLogViewModel()
        {
            subscriptionClient = new SubscriptionClient(ServiceBusConnectionString, TopicName, SubscriptionName);

            RegisterOnMessageHandlerAndReceiveMessages();

            //CloseSubscriptionClientAsync();

            ButtonCommand = new RelayCommand(new Action<object>(DoButtonCommand));

        }

        private void DoButtonCommand(object obj)
        {
            if (blockingCollection.Count > 0)
            {
                var data = blockingCollection.Take();
                ActivityLogs.Add(data);
            }
        }

        public void RegisterOnMessageHandlerAndReceiveMessages()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };
            subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            blockingCollection.TryAdd(JsonConvert.DeserializeObject<ActivityLog>(Encoding.UTF8.GetString(message.Body)));

            //await subscriptionClient.CompleteAsync(message.SystemProperties.LockToken); // this clears the message from topic
        }

        Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            MessageBox.Show(exceptionReceivedEventArgs.Exception.ToString());

            return Task.CompletedTask;
        }

        public async Task CloseSubscriptionClientAsync()
        {
            await subscriptionClient.CloseAsync();
        }

    }
}
