using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml;
using System.Windows.Forms;

using ICSharpCode.Core.Properties;
using ICSharpCode.Core.AddIns.Codons;
using ICSharpCode.Core.AddIns;
using ICSharpCode.Core.Services;


namespace ICSharpCode.SharpDevelop
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            ArrayList commands = null;
            try
            {
                //初始化内核服务
                ServiceManager.Services.InitializeServicesSubsystem("/Workspace/Services");
                //从指定树中得到命令
                commands = AddInTreeSingleton.AddInTree.GetTreeNode("/Workspace/Autostart").BuildChildItems(null);
                //依次调用动态创建的命令
                for (int i = 0; i < commands.Count - 1; ++i)
                {
                    ((ICommand)commands[i]).Run();
                }
            }
            catch (XmlException e)
            {
                MessageBox.Show("Could not load XML :\n" + e.Message);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show("Loading error, please reinstall :\n" + e.ToString());
                return;
            }

            //run the last autostart command, this must be the workbench starting command
            if (commands.Count > 0)
            {
                ((ICommand)commands[commands.Count - 1]).Run();
            }

            //服务卸载,程序结束
            ServiceManager.Services.UnloadAllServices();
        }
    }
}
