[System.Serializable]
public class TeamColorMeshPartException : System.Exception
{
    public TeamColorMeshPartException() { }
    public TeamColorMeshPartException(string message) : base(message) { }
    public TeamColorMeshPartException(string message, System.Exception inner) : base(message, inner) { }
    protected TeamColorMeshPartException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}