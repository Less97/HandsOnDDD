using Marketplace;
using static System.Environment;
using static System.Reflection.Assembly;

public class Program
{
    private static string _currentDirectory;
    static Program() => _currentDirectory = Path.GetDirectoryName(GetEntryAssembly().Location);

    public static void Main(string[] args)
    {
        var configuration = BuildConfiguration(args);
        ConfigureWebHost(configuration).Build().Run();
    }

    public static IWebHostBuilder ConfigureWebHost(IConfiguration configuration)
        => new WebHostBuilder().UseStartup<Startup>()
            .UseConfiguration(configuration)
            .ConfigureServices(services => services.AddSingleton(configuration))
            .UseContentRoot(_currentDirectory)
            .UseKestrel();

    public static IConfiguration BuildConfiguration(string[] args)
        => new ConfigurationBuilder().SetBasePath(_currentDirectory).Build();
}