namespace mekashron.backend.Models
{
    public class LoginReturnModel
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
