using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AzureTstReportViewer.ViewModel;
using AzureTstReportViewer.Model;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using Microsoft.Azure.ServiceBus;
using System.Threading.Tasks;
using System.Threading;

namespace AzureTstReportViewer.View
{
    /// <summary>
    /// Interaction logic for ActivityLogView.xaml
    /// </summary>
    public partial class ActivityLogView : Window
    {

        //const string ServiceBusConnectionString = "Endpoint=sb://azuretstservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=mlQkjnF+y/RuotajlXFhhJu8FINkXZh3WIryHJ1smSw=";
        //const string TopicName = "azuretsttopic";
        //const string SubscriptionName = "azuretsttopicsubscription";
        //public ISubscriptionClient subscriptionClient;

        //public ObservableCollection<ActivityLog> ActivityLogs { get; set; } = new ObservableCollection<ActivityLog>()
        //{
        //    new ActivityLog()
        //};

        //public ConcurrentBag<ActivityLog> activityLogs = new ConcurrentBag<ActivityLog>();
        public ActivityLogView()
        {
            InitializeComponent();

            this.DataContext = new ActivityLogViewModel();

            //subscriptionClient = new SubscriptionClient(ServiceBusConnectionString, TopicName, SubscriptionName);

        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{


        //    RegisterOnMessageHandlerAndReceiveMessages();

        //    //Task.Delay(10000);
        //    //subscriptionClient.CloseAsync();
        //}



        //public void RegisterOnMessageHandlerAndReceiveMessages()
        //{
        //    var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
        //    {
        //        MaxConcurrentCalls = 1,
        //        AutoComplete = false
        //    };
        //    subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        //}

        //private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        //{
        //    //Task.Run(() =>
        //    //{
        //        MessageBox.Show("from message box");
        //        activityLogs.Add(new ActivityLog() { JSONString = "sample1" });
        //        ActivityLogs.Add(new ActivityLog() { JSONString = "sample1" });
        //        ActivityLogs.Add(new ActivityLog() { JSONString = Encoding.UTF8.GetString(message.Body) });

        //        dvActivityLogs.Dispatcher.Invoke(() =>
        //        {
        //            dvActivityLogs.ItemsSource = ActivityLogs;
        //        });

        //        btnSubmit.Dispatcher.Invoke(() =>
        //        {
        //            btnSubmit.Content = "Got this";
        //        });
        //    //});


        //    await subscriptionClient.CompleteAsync(message.SystemProperties.LockToken); // this clears the message from topic
        //}

        //Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        //{
        //    Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");

        //    return Task.CompletedTask;
        //}

        //public async Task CloseSubscriptionClientAsync()
        //{
        //    await subscriptionClient.CloseAsync();
        //}

    }
}
