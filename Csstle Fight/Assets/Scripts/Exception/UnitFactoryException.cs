[System.Serializable]
public class UnitFactoryException : System.Exception
{
    public UnitFactoryException() { }
    public UnitFactoryException(string message) : base(message) { }
    public UnitFactoryException(string message, System.Exception inner) : base(message, inner) { }
    protected UnitFactoryException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}