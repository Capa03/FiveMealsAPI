namespace FiveMeals.WebAPI.Model.User
{
    public class ShowUserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        public DateTime Created { get; set; }
    }
}
