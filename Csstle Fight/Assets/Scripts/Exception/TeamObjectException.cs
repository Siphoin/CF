[System.Serializable]
public class TeamObjectException : System.Exception
{
    public TeamObjectException() { }
    public TeamObjectException(string message) : base(message) { }
    public TeamObjectException(string message, System.Exception inner) : base(message, inner) { }
    protected TeamObjectException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}