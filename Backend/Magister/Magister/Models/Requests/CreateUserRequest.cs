namespace Magister.Models.Requests
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string GroupName { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }


        // Учень   - ПІП, Курс, Ссилка на інсту, телегу
        // Вчитель - ПІП, Предмети, Сертифікати, Ссилка на інсту
    }
}
