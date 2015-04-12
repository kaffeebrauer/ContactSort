namespace GlobalX.Console.ContactSort.BusinessLogic.Core
{
    public abstract class ModelFactory<T>
    {
        public abstract T Create(params object[] args);
    }
}
