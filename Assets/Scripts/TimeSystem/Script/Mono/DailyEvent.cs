using System;
using UnityEngine;

namespace TimeSystem
{
    public class DailyEvent : MonoBehaviour
    {
        [HideInInspector] public int Hour;
        [HideInInspector] public int Minute;
        [HideInInspector] public int Second;
        public TimeSpan LastUsedTime = TimerUtility.FirstDate.TimeOfDay;
        private TimeSpan renewalTime => new TimeSpan(Hour, Minute, Second);
        long currentTimeTicks => TimerUtility.CurrentTime.Ticks;
        long totalTicksExceptCurrentDay => currentTimeTicks - TimerUtility.CurrentTime.TimeOfDay.Ticks;
        long renewalTicks => totalTicksExceptCurrentDay+renewalTime.Ticks;
        public Action OnUsed; 
        
        public virtual void Use()
        {
            LastUsedTime = TimeSpan.FromTicks(currentTimeTicks);
            OnUsed?.Invoke();
        }

        public virtual bool IsReadyToUse()
        {
            var ticksFromLastUsed = (TimerUtility.CurrentTime - LastUsedTime).Ticks;
            if (ticksFromLastUsed>TimeSpan.TicksPerDay)
            {
                return true;
            }

            if (renewalTicks > LastUsedTime.Ticks)
            {
                return renewalTicks < currentTimeTicks;
            }

            return false;
        }

        public virtual TimeSpan GetRemainingTime()
        {
            if (IsReadyToUse())
            {
                return new TimeSpan();
            }
            else
            {
                long remainingTicks = renewalTicks-currentTimeTicks ;
                return TimeSpan.FromTicks(remainingTicks>0?remainingTicks:remainingTicks+TimeSpan.TicksPerDay);
            }

        }
        
    }
}
