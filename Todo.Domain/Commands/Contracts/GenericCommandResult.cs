namespace Todo.Domain.Commands.Contracts
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult() { }
        public GenericCommandResult(bool success, string message, object data)
        {
            Success = success;
            this.message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string message { get; set; }
        public object Data { get; set; }

    }
}