using System;
using UnityEditor;
using UnityEngine;

namespace TimeSystem
{
    [CustomEditor(typeof(DailyEvent))]
    public class DailyEventInspector : Editor
    {
        private DailyEvent dailyEvent;
        private TimeSpan timeOfTheDay;
        
        private void OnEnable()
        {
            dailyEvent = (DailyEvent)target;
        }

        public override void OnInspectorGUI()
        {
            timeOfTheDay = TimerUtility.CurrentTime.TimeOfDay;
            CurrentTime();
            EditorGUILayout.BeginHorizontal();
            EventRenewalTime();
            SetEventRenewalTimeToSecondsLater(5);
            SetEventRenewalTimeToDefault(new TimeSpan(13, 0, 0));
            EditorGUILayout.Space();
            EditorGUILayout.EndHorizontal();
            LastUsedTime();
            RemainingTime();

        }

        private void CurrentTime()
        {
            timeOfTheDay = TimerUtility.CurrentTime.TimeOfDay;
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Current Time:", GUILayout.Width(90));
            EditorGUILayout.LabelField($"{(timeOfTheDay.Hours>9?timeOfTheDay.Hours:"0"+timeOfTheDay.Hours)}:{(timeOfTheDay.Minutes>9?timeOfTheDay.Minutes:"0"+timeOfTheDay.Minutes)}:{(timeOfTheDay.Seconds>9?timeOfTheDay.Seconds:"0"+timeOfTheDay.Seconds)} UTC");
            EditorGUILayout.EndHorizontal();
        }
        private void EventRenewalTime()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Renewal Time:", GUILayout.Width(90));
            dailyEvent.Hour = EditorGUILayout.IntField(Math.Clamp(dailyEvent.Hour, 0, 23), GUILayout.Width(20));
            EditorGUILayout.LabelField(":", GUILayout.Width(5));
            dailyEvent.Minute = EditorGUILayout.IntField(Math.Clamp(dailyEvent.Minute, 0, 59), GUILayout.Width(20));
            EditorGUILayout.LabelField(":", GUILayout.Width(5));
            dailyEvent.Second = EditorGUILayout.IntField(Math.Clamp(dailyEvent.Second, 0, 59), GUILayout.Width(20));
            EditorGUILayout.LabelField("UTC",GUILayout.Width(30));
            EditorGUILayout.EndHorizontal();
        }
        
        private void SetEventRenewalTimeToSecondsLater(int seconds)
        {
            if (GUILayout.Button($"Set To {seconds} Seconds Later"))
            {
                TimeSpan newRenewal = timeOfTheDay.Add(TimeSpan.FromSeconds(seconds));
                dailyEvent.Hour = newRenewal.Hours;
                dailyEvent.Minute = newRenewal.Minutes;
                dailyEvent.Second = newRenewal.Seconds;
            }
        }
        
        private void SetEventRenewalTimeToDefault(TimeSpan ts)
        {
            if (GUILayout.Button($"Set To {ts.Hours}:{ts.Minutes}:{ts.Seconds} UTC"))
            {
                dailyEvent.Hour = ts.Hours;
                dailyEvent.Minute = ts.Minutes;
                dailyEvent.Second = ts.Seconds;
            }
        }

        private void LastUsedTime()
        {
            TimeSpan td = TimerUtility.CurrentTime.TimeOfDay;
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Last Used Time:", GUILayout.Width(90));
            EditorGUILayout.LabelField($"{dailyEvent.LastUsedTime}");
            EditorGUILayout.EndHorizontal();
        }
        
        private void RemainingTime()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Remaining Time:", GUILayout.Width(90));
            EditorGUILayout.LabelField($"{dailyEvent.GetRemainingTime()}");
            EditorGUILayout.EndHorizontal();
        }

    }

}
