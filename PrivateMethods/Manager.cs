using System;

namespace PrivateMethods
{
    internal class Manager : Employee
    {
        public Manager(string name) : base(name)
        {
            if (Name == "Bob")
            {
                this.empType = EmployeeType.BAD;
            }
            else if (Name == "Pete")
            {
                this.empType = EmployeeType.OK;
            }
            else if (Name.IndexOfAny("AaBbCcDdEeFfGg".ToCharArray()) != -1)
            {
                this.empType = EmployeeType.GOOD;
            }
            else
            {
                this.empType = EmployeeType.DICTATOR;
            }
        }

        protected override string PrintInfo()
        {
            string ret = $"I'm Manager {Name} . I'm ";
            switch (empType)
            {
                case EmployeeType.BAD:
                    ret += " serious badass";
                    break;
                case EmployeeType.OK:
                    ret += " pretty ok";
                    break;
                case EmployeeType.GOOD:
                    ret += " really nice";
                    break;
                default:
                    throw new ArgumentException("really not a type we like!");
            }

            return ret;
        }
    }
}