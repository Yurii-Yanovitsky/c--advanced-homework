namespace CommandInterface
{
    public interface ICommand
    {
        void Execute(string projectName, string path);
    }
}
