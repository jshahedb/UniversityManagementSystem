namespace UniversityManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string RegNo { get; set; }
        public string PhoneNo { get; set; }

        public int? DepartmentId { get; set; }
    }
}