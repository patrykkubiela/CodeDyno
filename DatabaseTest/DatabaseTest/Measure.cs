using System.Dynamic;

namespace DatabaseTest
{
    public class Measure
    {
        public string MeasureName { get; set; }
        public int IntMeasureValue { get; set; }
        public decimal DecMeasureValue { get; set; }
        public Measure[] SomeOtherMeasures { get; set; }
    }
}