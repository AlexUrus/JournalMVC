namespace JournalMVC.CustomException
{
    public class ActivitiesRepositoryException : Exception
    {
        public ActivitiesRepositoryException()
        {
            
        }
        public ActivitiesRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public ActivitiesRepositoryException(string message) : base(message) {}
    }
}
