using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlarmClock
{
    //定义委托
    public delegate void AlarmHandler(object sender, DateTime time);
    class Alarm
    {
        //注册Alarm与Tick两个事件
        public event AlarmHandler OnAlarm;
        public event AlarmHandler OnTick;

        public void Start()
        {
            OnAlarm += OnAlarm_Process;
            OnTick += OnTick_Process;
            //闹钟定的时间（可自定义）
            DateTime AlarmTime = DateTime.Now.AddSeconds(5);
            while (true)
            {
                DateTime CurTime = DateTime.Now;
                TimeSpan delta = AlarmTime - CurTime;
                // 误差小于0.1秒触发闹钟事件
                if(Math.Abs(delta.TotalSeconds) < 0.1) { 
                    OnAlarm(this, AlarmTime); 
                }
                OnTick(this, CurTime);
                Thread.Sleep(1000);
            }
        }
        //定义OnAlarm与OnTick两个事件具体的处理方法
        void OnAlarm_Process(Object sender,DateTime time)
        {
            Console.WriteLine($"AlarmTime:{time}");
        }
        void OnTick_Process(Object sender,DateTime time)
        {
            Console.WriteLine($"CurrentTime:{time}");
        }
    }
}
