namespace SalesForce.Structure
{
    public interface ITaskManager
    {
        object Execute(string moduleId, string methodName, object param);
        object Execute(string moduleId, string methodName);
    }
}
