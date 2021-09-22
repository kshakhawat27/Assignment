using SalesForce.Structure.TaskManager;

namespace SalesForce.Structure
{
    public class ServerObject : ITaskManager
    {
        public object Execute(string moduleId, string methodName, object param)
        {
            switch (moduleId)
            {
                case Module.Admin:
                    AdminTaskManager objADM = new AdminTaskManager();
                    return objADM.Execute(methodName, param);
             
                default:
                    break;
            }
            return null;
        }

        public object Execute(string moduleId, string methodName)
        {
            switch (moduleId)
            {
                case Module.Admin:
                    AdminTaskManager objADM = new AdminTaskManager();
                    return objADM.Execute(methodName);
                default:
                    break;
            }
            return null;
        }
    }
}
