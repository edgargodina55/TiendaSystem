namespace MasterLoyaltyStore.Bussiness.Exceptions;

public class ActionFailedException : Exception
{
    public ActionFailedException() : base() { }
    
    public ActionFailedException(string message): base(message){}
    
    public ActionFailedException(string message, Exception innerException): base(message, innerException){}
}