namespace RulbWPF.Db
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }
    }
}