using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

using ICSharpCode.Core.Services;
using ICSharpCode.Motion.Services;
using ICSharpCode.Motion.Entity;
using ICSharpCode.Motion.Model;

namespace ICSharpCode.Demo
{
    partial class DemoForm : UIPage
    {
        //日志服务
        LoggingService log_srv = ServiceManager.Services.GetRequiredService<LoggingService>();

        public DemoForm()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            Sunny.UI.UIMessageBox.ShowWarning("仅展示调用方式,为了安全起见此处不进行实际调用,请查看本按钮绑定的源代码");
            return;
            //得到运动服务,所有运动相关的功能全部由此服务提供
            MotionService motion_srv = ServiceManager.Services.GetRequiredService<MotionService>();
            //基于名称得到工站运动模型,真正运动的接口来自于此模型
            IStationModel stationModel = motion_srv.MotionFactory.GetStationModel("上料工站");
            //基于名称得到工站示教组件,存储的示教点位来自于此实体
            StationEntity stationEntity = motion_srv.EntityFactory.StationList.Find(item=> item.Name == "上料工站");

            Debug.Assert(stationModel != null && stationEntity != null);
      
            //查找需要运动的固定点位
            PointEntity pointEntity = stationEntity.PointList.Find(item => item.Name == "示教位置点");
            Debug.Assert(pointEntity != null);

            //全速按照示教点运动
            if (!stationModel.MoveAbs(pointEntity, 100)) log_srv.Error("运动失败");
         

            //全速按照指定点运动
            List<float> target = new List<float>(){
                1000,2000,
            };
            if (!stationModel.MoveAbs(target, 100)) log_srv.Error("运动失败");

            //如下代码可获取轴的位置
            bool ok = false;
            List<float> targets = new List<float>();
            for (int i = 0; i < stationEntity.AxisLists.Count; i++)
            {
                AxisEntity axis = stationEntity.AxisLists[i];
                IAxisModel model = motion_srv.MotionFactory.GetAxisModel(axis.Id);
                AxisModelStat stat = model.Stat(out ok); //得到轴状态
                targets.Add(stat.Mcs); //得到当前的轴位置
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            Sunny.UI.UIMessageBox.ShowWarning("仅展示调用方式,为了安全起见此处不进行实际调用,请查看本按钮绑定的源代码");
            return;
            //得到运动服务,所有运动相关的功能全部由此服务提供
            MotionService motion_srv = ServiceManager.Services.GetRequiredService<MotionService>();
            //基于名称得到IO模型,真正控制IO的接口来自于此模型
            IIOModel io_mode = motion_srv.MotionFactory.GetIOModel("IO输入1");
            Debug.Assert(io_mode != null);
            io_mode.SetOut(true); //打开IO
            io_mode.SetOut(false); //关闭IO
        }
    }
}
