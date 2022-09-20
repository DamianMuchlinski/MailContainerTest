namespace MailContainerTest.Abstract
{
    public interface IMyValidator<T>
    {
        public bool Validate(T model);
    }
}