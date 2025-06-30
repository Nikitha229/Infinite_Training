using System;

namespace Day7_Task
{
    public delegate void RingEventHandler();
    public class MobilePhone
    {
        public event RingEventHandler OnRing;
        public void ReceiveCall()
        {
            Console.WriteLine("Incoming call...");
            OnRing?.Invoke();
        }
    }

    public class RingtonePlayer
    {
        public void OnRing()
        {
            Console.WriteLine("Playing ringtone...");
        }
    }

    public class ScreenDisplay
    {
        public void OnRing()
        {
            Console.WriteLine("Displaying caller information...");
        }
    }
    public class VibrationMotor
    {
        public void OnRing()
        {
            Console.WriteLine("Phone is vibrating...");
        }
    }

    class Question_2
    {
        static void Main(string[] args)
        {
            MobilePhone phone = new MobilePhone();
            RingtonePlayer rop = new RingtonePlayer();
            ScreenDisplay sd = new ScreenDisplay();
            VibrationMotor vm = new VibrationMotor();
            phone.OnRing += rop.OnRing;
            phone.OnRing += sd.OnRing;
            phone.OnRing += vm.OnRing;
            phone.ReceiveCall();
            Console.Read();
        }
    }
}
