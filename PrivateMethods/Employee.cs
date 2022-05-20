namespace PrivateMethods
{
    internal abstract class Employee
    {
        protected EmployeeType empType = EmployeeType.BAD;
        public string Name { get; set; }
        protected abstract string PrintInfo();

        protected Employee(string name)
        {
            this.Name = name;
            PrintInfo();
        }

        public bool ContainsIllegalChars()
        {
            if (this.Name.Contains("$"))
            {
                return true;
            }
            return false;
        }
    }

}
