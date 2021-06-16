[System.Serializable]
public class MatchManagerException : System.Exception
{
    public MatchManagerException() { }
    public MatchManagerException(string message) : base(message) { }
    public MatchManagerException(string message, System.Exception inner) : base(message, inner) { }
    protected MatchManagerException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}