using System.Reflection;

namespace AdditionalTask
{
    public class Validator
    {
        public (bool isValid, string name) Validate(Worker worker)
        {
            var type = worker.GetType();

            var accessLevel = type.GetCustomAttribute<AccessLevelAttribute>(true).AccessLevel;

            if ((AccessLevel.Middle & accessLevel) != 0)
            {
                return (true, worker.GetType().Name);
            }
            else
            {
                return (false, worker.GetType().Name);
            }
        }
    }
}
