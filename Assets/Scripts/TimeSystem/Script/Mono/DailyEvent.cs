using System;
using UnityEngine;

namespace TimeSystem
{
    public class DailyEvent : MonoBehaviour
    {
        [HideInInspector] public int Hour;
        [HideInInspector] public int Minute;
        [HideInInspector] public int Second;
        public DateTime LastUsedTime = new DateTime();
        long LastUsedTimeWithoutTimeOfDayTicks => LastUsedTime.Ticks-LastUsedTime.TimeOfDay.Ticks;
        TimeSpan renewalTime => new TimeSpan(Hour, Minute, Second);
        
        DateTime renewalDate
        {
            get
            {
                long ticks = LastUsedTimeWithoutTimeOfDayTicks + renewalTime.Ticks;
                return renewalTime > LastUsedTime.TimeOfDay
                    ? new DateTime(ticks)
                    : new DateTime(ticks+TimeSpan.TicksPerDay);
            }
        }

        long currentTimeTicks => TimerUtility.CurrentTime.Ticks;
        long totalTicksExceptCurrentDay => currentTimeTicks - TimerUtility.CurrentTime.TimeOfDay.Ticks;
        long renewalTicks => totalTicksExceptCurrentDay + renewalTime.Ticks;
        
        public virtual void Use()
        {
            LastUsedTime = TimerUtility.CurrentTime;
        }

        public virtual bool IsReadyToUse()
        {
            return renewalDate < TimerUtility.CurrentTime;
        }

        public virtual TimeSpan GetRemainingTime()
        {
            if (IsReadyToUse())
            {
                return new TimeSpan();
            }
            else
            {
                return renewalDate - TimerUtility.CurrentTime;
            }
        }
        
    }
}
