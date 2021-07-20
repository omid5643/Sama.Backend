using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omran.Sama.Server.Global
{
    public class ApplicationState
    {
        public int State { get; set;}
        private static ApplicationState _state;
        private ApplicationState()
        {

        }

        public static ApplicationState GetState()
        {
            if (_state == null)
                _state = new ApplicationState();
            return _state;
        }
    }
}
