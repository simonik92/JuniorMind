namespace Alarm
{
    public class Program
    {

        [Flags]
    public enum Days
    {
        None = 0,
        Su = 1,
        Mo = 1 << 1,
        Tu = 1 << 2,
        We = 1 << 3,
        Th = 1 << 4,
        Fr = 1 << 5,
        Sa = 1 << 6
    }

    public struct Time
    {
        public int Hour;
        public int Minutes;

        public Time(int hour, int minutes)
        {
            this.Hour = hour;
            this.Minutes = minutes;
        }
    }

    public struct Alert
    {
        public Time Time;
        public Days Days;

        public Alert(Time time, Days days = Days.None)
        {
            this.Time = time;
            this.Days = days;
        }
    }

   
        public static void Main()
        {
            int countOfAlerts = Convert.ToInt32(Console.ReadLine());
            Alert[] alerts = new Alert[countOfAlerts];

            for (int i = 0; i < alerts.Length; i++)
            {
                alerts[i] = ReadAlert();
            }

            Time timeToCheck = ReadTime();
            Days dayToCheck = GetDay(Console.ReadLine());

            Console.WriteLine(CheckAlarm(alerts, timeToCheck, dayToCheck));
            Console.Read();
        }

        public static bool CheckAlarm(Alert[] alerts, Time timeToCheck, Days dayToCheck)
        {
            for (int i = 0; i < alerts.Length; i++)
            {
                if (!CheckAlarmTime(alerts[i].Time, timeToCheck))
                {
                    continue;
                }

                if (CheckAlarmDay(alerts[i].Days, dayToCheck))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool CheckAlarmDay(Days days, Days dayToCheck)
        {
            Days d = days & dayToCheck;
            return d != 0;
        }

        public static bool CheckAlarmTime(Time time, Time timeToCheck)
        {
            return time.Hour == timeToCheck.Hour && time.Minutes == timeToCheck.Minutes;
        }

        public static Alert ReadAlert()
        {
            Alert result = new Alert(ReadTime());

            string[] days = Console.ReadLine().Split(' ');
            for (int i = 0; i < days.Length; i++)
            {
                AddDayToAlert(ref result, GetDay(days[i]));
            }

            return result;
        }

        public static Time ReadTime()
        {
            string[] time = Console.ReadLine().Split(':');
            return new Time(Convert.ToInt32(time[0]), Convert.ToInt32(time[1]));
        }

        public static void AddDayToAlert(ref Alert result, Days day)
        {
            result.Days = result.Days | day;
        }

        public static Days GetDay(string day)
        {
            return day switch
            {
                "Mo" => Days.Mo,
                "Tu" => Days.Tu,
                "We" => Days.We,
                "Th" => Days.Th,
                "Fr" => Days.Fr,
                "Sa" => Days.Sa,
                _ => Days.Su,
            };
        }
    }
}

