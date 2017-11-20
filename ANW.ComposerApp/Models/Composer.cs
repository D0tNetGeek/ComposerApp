namespace ANW.ComposerApp.Models
{
    public sealed class Composer
    {

        public Composer()
        {
            Value = $@"{FirstName} {LastName}";
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Awards { get; set; }
        public string Value { get; set; }
        public string FullName
        {
            get { return $@"{FirstName} {LastName}"; }
            set { Value = value; }
        }
    }
}