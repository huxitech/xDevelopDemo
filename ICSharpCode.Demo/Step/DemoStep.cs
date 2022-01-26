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
        /// <summary>
        /// Step运行函数,由框架调用，当流程进行到此处时，本函数会自动被框架调用
        /// </summary>
        /// <param name="caller">前序步骤对象</param>
        /// <param name="result">前序步骤的运行结果</param>
        /// <param name="inter">本次流程解析引擎</param>
        /// <returns>返回本次的运行结果</returns>
        protected override StepResult OnRun(IStep caller, StepResult result, StepInterpreter inter = null)
        {
            //支持从属性系统中加载属性,每一个step对象均包含一个属性字典供存储参数
            string name = GetProprty("NAME", "");
            //SetProprty("NAME", "");

            //整个框架包含一个全局变量表,支持编程方式操作变量
            object v = GetVar("P1"); //得到全局变量
            //SetVar("P1", new List<float>() { 1, 2, 3 });

            //可弹出线程与界面安全的交互对话框
            DemoStepDialog dialog = new DemoStepDialog();
            dialog.Args = v != null ? v.ToString() : "";
            dialog.Next = StepOut.NEXT_1; //默认输出

            //使用内置函数包装可支持遮盖层弹出
            DialogResult ret = ShowDialog(dialog,true);

            //返回执行结果
            return new StepResult()
            {
                    Args = new object[1]{dialog.Args}, //运算结果,为一个Object数组
                    Out = dialog.Next                  //条件分支,运算结果流出到哪一个出口
            };
        }

        /// <summary>
        /// 帮助信息
        /// </summary>
        public override string Help
        {
            get
            {
                return "Demo流程";
            }
        }
        

        /// <summary>
        /// 双击组件自动调用此函数
        /// </summary>
        public override void OnSetting()
        {
            MessageBox.Show("demo step设置");
            //可弹出设置窗口
            //设置属性
            SetProprty("NAME", "");
        }

    }
}
