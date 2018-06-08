using System;

namespace CSharpIsFun.UsefulCode
{
    /// <summary>
    /// Example of lazy configuration for Azure Functions projects
    /// This configuration uses environment variables
    /// </summary>
    /// <example>
    ///    // Property
    ///    private static readonly Lazy<IQueueClient> queueClient = new Lazy<IQueueClient>(() => new QueueClient(
    ///        LazyConfiguration.Instance.SBQueueConnectionString,
    ///        LazyConfiguration.Instance.MainSBQueueName));
    ///    ...
    ///    // Execution
    ///    await queueClient.Value.SendAsync(message);
    /// </example>
    public class LazyConfiguration
    {
        public static LazyConfiguration Instance => instance.Value;

        public string SBQueueConnectionString => sbQueueConnectionString ??
                                                    (sbQueueConnectionString =
                                                        Environment.GetEnvironmentVariable("SBQueueConnectionString"));

        public string MainSBQueueName => mainSBQueueName ??
                                                (mainSBQueueName =
                                                    Environment.GetEnvironmentVariable("MainSBQueueName"));

        #region Private
        private static readonly Lazy<LazyConfiguration> instance =
            new Lazy<LazyConfiguration>(() => new LazyConfiguration());

        private string sbQueueConnectionString;
        private string mainSBQueueName;
        #endregion
    }
}