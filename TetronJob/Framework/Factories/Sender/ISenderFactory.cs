namespace Framework.Factories.Sender
{
    public interface ISenderFactory
    {
        Task Welcome(string name, string phoneNumber);
        Task Accept(string name, string phoneNumber);
        Task Cancel(string name, string phoneNumber);
    }
}
