namespace GatewayService.Logger
{
    public static class FileLoggerExtensions
    {
        public static ILoggerFactory AddFile(this LoggerFactory factory,
                                        string filePath)
        {
            factory.AddProvider(new FileLoggerProvider(filePath));
            return factory;
        }
    }
}
