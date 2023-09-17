namespace Magister.Models.Requests
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        // Учень   - ПІП, Курс, Ссилка на інсту, телегу
        // Вчитель - ПІП, Предмети, Сертифікати, Ссилка на інсту
    }
}
