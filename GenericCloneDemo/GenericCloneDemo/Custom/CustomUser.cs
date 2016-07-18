namespace GenericCloneDemo.Custom
{
    public class CustomUser
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Id { get; set; }

        public CustomGroup CustomGroup { get; set; }

        public string GroupName => $"{CustomGroup.Name} - {CustomGroup.SubName}";
        public string FullName => $"{FirstName} {Name} {LastName}";

        public override string ToString()
        {
            return $"{new string('-', 20)}\n\t{FullName}\t{Id}\n\t{GroupName}\n\tGroup Id: {CustomGroup.Id}{new string('-', 20)}";
        }
    }
}