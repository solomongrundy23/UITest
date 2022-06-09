using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.AppManager
{
    public class BaseController
    {
        protected ApplicationManager manager;
        protected BaseController(ApplicationManager applicationManager) => this.manager = applicationManager;
    }
}
