using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.Follow.Steps.Model;
using ICSharpCode.Follow.Steps.Controller;
namespace ICSharpCode.Demo
{
  /// <summary>
    /// Demo步骤
    /// </summary>
    class DemoStep : AbstractStep
    {
        protected override StepResult OnRun(IStep caller, StepResult result, StepInterpreter inter = null)
        {
            //得到属性
            string name = GetProprty("NAME", "");
            object v = GetVar("P1"); //得到全局变量

            //可弹出交互对话框
            DemoStepDialog dialog = new DemoStepDialog();
            dialog.Args = v != null ? v.ToString() : "";
            dialog.Next = StepOut.NEXT_1; //默认输出

            //使用内置函数包装可支持遮盖层弹出
            ShowDialog(dialog);

            return new StepResult()
            {
                    Args = new object[1]{dialog.Args},
                    Out = dialog.Next
            };
        }
        public override string Help
        {
            get
            {
                return "Demo流程";
            }
        }
        public override void OnSetting()
        {
            MessageBox.Show("demo step设置");
            //可弹出设置窗口
            //设置属性
            SetProprty("NAME", "");
        }

    }
}
