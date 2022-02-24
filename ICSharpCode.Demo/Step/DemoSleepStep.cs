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
    /// 耗时的等待算子
    /// </summary>
    class DemoSleepStep : AbstractStep
    {
        protected override StepResult OnRun(IStep caller, StepResult result, StepInterpreter inter = null)
        {
            //得到设置的延时时间
            string value = "1000";
            value = GetProprty("value", value);
            int ms = int.Parse(value);
            int time = 0;

            while (time < ms || !inter.IsQuit)//必须判断流程引擎是否已经要求退出循环，否则流程引擎无法结束本步骤
            {
                System.Threading.Thread.Sleep(100);
                if (!inter.IsPause) //流程已经暂停,不再及时(本步可选)
                {
                    time += 100;
                }
            }

            //按照要求返回
            return new StepResult()
            {
                Args = null,
                Out = StepOut.NEXT_1
            };
        }
        public override string Help
        {
            get
            {
                return "耗时操作步骤开发示意";
            }
        }

        public override void OnSetting()
        {
            //此处设置参数
             //SetProprty("value", "1000");
        }
    }
}
