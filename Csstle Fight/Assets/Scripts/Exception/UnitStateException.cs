[System.Serializable]
public class UnitStateException : System.Exception
{
    public UnitStateException() { }
    public UnitStateException(string message) : base(message) { }
    public UnitStateException(string message, System.Exception inner) : base(message, inner) { }
    protected UnitStateException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}