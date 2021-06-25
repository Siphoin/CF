[System.Serializable]
public class DynamicStatsUnitException : System.Exception
{
    public DynamicStatsUnitException() { }
    public DynamicStatsUnitException(string message) : base(message) { }
    public DynamicStatsUnitException(string message, System.Exception inner) : base(message, inner) { }
    protected DynamicStatsUnitException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}