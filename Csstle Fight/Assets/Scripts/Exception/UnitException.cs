[System.Serializable]
public class UnitException : System.Exception
{
    public UnitException() { }
    public UnitException(string message) : base(message) { }
    public UnitException(string message, System.Exception inner) : base(message, inner) { }
    protected UnitException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}