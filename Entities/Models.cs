namespace Models
{
    public class Models
    {
        public class LogIn
        {
            public int ID { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class User
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int LogInID { get; set; }
        }

        public class Task
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int Status { get; set; }
            public int Importance { get; set; }
            public int UserID { get; set;}
            public int CatID { get; set; }
        }

        public class Category
        {
            public int ID{ get; set; }
            public string Name { get; set; }
            public int TaskID { get; set; }
        }


    }
}