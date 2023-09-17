using System;
using UnityEngine;

namespace TimeSystem
{
    public class DailyEvent : MonoBehaviour
    {
        public int Hour;
        public int Minute;
        public int Second;
        public int DailyLimit = 5;
        public int UsedAmount;
        public DateTime LastUsedTime = new DateTime();
        private long LastUsedTimeWithoutTimeOfDayTicks => LastUsedTime.Ticks-LastUsedTime.TimeOfDay.Ticks;
        private TimeSpan renewalTime => new TimeSpan(Hour, Minute, Second);
        
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

        public float TickInterval = TimeSpan.TicksPerSecond*.5f;
        private long lastTick;
        public Action OnTick;
        public Action OnRenewal;
        public Action OnDailyLimitEnded;

        protected virtual void Awake()
        {
            lastTick = TimerUtility.CurrentTime.Ticks;
            if (IsRenewalTimePassed())
            {
                ResetUsedAmount();
            }
            if (!IsReadyToUse())
            {
                OnDailyLimitEnded?.Invoke();
            }
        }

        private void Update()
        {
            if (lastTick + TickInterval > TimerUtility.CurrentTime.Ticks)
            {
                Tick();
            }
        }

        void Tick()
        {
            if (IsRenewalTimePassed())
            {
                if (UsedAmount > 0)
                {
                    FirstTickAfterRenewal();
                }
            }            
            OnTick?.Invoke();
        }

        private void FirstTickAfterRenewal()
        {
            ResetUsedAmount();
            OnRenewal?.Invoke();
        }

        public virtual void Use()
        {
            LastUsedTime = TimerUtility.CurrentTime;
            UsedAmount++;
            if (!IsReadyToUse())
            {
                OnDailyLimitEnded?.Invoke();
            }
        }
        
        protected virtual void ResetUsedAmount()
        {
            UsedAmount = 0;
        }

        private bool IsRenewalTimePassed()
        {
            return renewalDate < TimerUtility.CurrentTime;
        }
        
        public bool IsReadyToUse()
        {
            return UsedAmount < DailyLimit;
        }

        public TimeSpan GetRemainingTime()
        {
            if (IsRenewalTimePassed())
            {
                return new TimeSpan();
            }

            return renewalDate - TimerUtility.CurrentTime;
        }
        
    }
}
