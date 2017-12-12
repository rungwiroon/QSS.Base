namespace Qss.Base.Models
{
    public class IdNameModel : IIntegerEntityKey
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IdNameModel()
        {
        }

        public IdNameModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}