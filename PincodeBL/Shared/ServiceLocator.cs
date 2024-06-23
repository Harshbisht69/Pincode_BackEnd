using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PincodeBL.Shared
{
    public class ServiceLocator
    {
        public BaseResponse Execute(BaseRequest baseRequestObj)
        {
            Type classType = Type.GetType(baseRequestObj.BehaviourClass);


            BaseBehaviour baseBehaviourObj = (BaseBehaviour)Activator.CreateInstance(classType);

            BaseResponse baseResponse = new BaseResponse();

            baseResponse = baseBehaviourObj.Execute(baseRequestObj);

            return baseResponse;
        }
    }
}
