using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sunny.UI;

namespace ICSharpCode.Demo
{
    public class DemoWorkPanel : ICSharpCode.UI.Layout.IWorkPanel
    {

        public string Name
        {
            get { return "Demo"; }
        }

        public string Icon
        {
            get { return "61461"; }
        }

        public UIPage CreatePage()
        {
            return new DemoForm();
        }

        public bool CanAccess()
        {
            return true;
           // UserService srv = ServiceManager.Services.GetRequiredService<UserService>();
           // return ((null != srv.CurrentUser) && (srv.CurrentUser.Group == UserGroup.ADMIN));
        }
    }
}
