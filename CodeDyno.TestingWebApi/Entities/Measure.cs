using CodeDyno.DatabaseLocal;

namespace CodeDyno.TestingWebApi.Entities
{
    public class Measure : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}