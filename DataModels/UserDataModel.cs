namespace DataModels
{
    public class UserDataModel
    {
        public int id { get; set; }
        public string username{ get; set; }
        public string password{ get; set; }

        public bool blocked = false;

        public override string ToString()
        {
            return $"{username}";
        }
    }
}
