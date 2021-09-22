namespace SalesForce.Structure
{
    public class ServerManager
    {
        private static ITaskManager _taskManager = null;
        public static ITaskManager GetTaskManager
        {
            get
            {
                ITaskManager objTaskManager = new ServerObject();
                return objTaskManager;
            }
        }
    }
}
