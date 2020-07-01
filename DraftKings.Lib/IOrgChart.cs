namespace DraftKings.Lib
{
    public interface IOrgChart
    {
        void Add(int employeeId, string name, int managerId);
        int CountEmployeesOf(int employeeId);
        void Move(int employeeId, int fromManagerId, int toManagerId);
        void Print();
        void Remove(int employeeId);
    }
}