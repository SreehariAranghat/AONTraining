
namespace HelloNEtCore
{
    public static class CreateGreeting
    {
        public static void ShowGreeting(dynamic greeting)
        {
            Console.WriteLine(JsonSerializer.Serialize(greeting));
        }
    }
}
