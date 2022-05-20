namespace PrivateMethods
{
    internal class DeliveryManager : Employee
    {
        public DeliveryManager(string name) : base(name)
        {
            empType = EmployeeType.OK;
        }
        protected override string PrintInfo()
        {
            return $"I'm Delivery Manager {Name} ";
        }
    }
}
