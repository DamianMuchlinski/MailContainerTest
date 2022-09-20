namespace MailContainerTest.Services.Validation.Custom
{
    public interface IMyValidator<T>
    {
        public bool Validate(T model);
    }
}