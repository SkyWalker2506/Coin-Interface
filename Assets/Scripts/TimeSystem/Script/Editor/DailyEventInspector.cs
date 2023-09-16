using System;
using UnityEditor;
using UnityEngine;

namespace TimeSystem
{
    [CustomEditor(typeof(DailyEvent))]
    public class DailyEventInspector : Editor
    {
        private DailyEvent _dailyEvent;
        
        private void OnEnable()
        {
            _dailyEvent = (DailyEvent)target;
        }

        public override void OnInspectorGUI()
        {
            CurrentTime();
            ActionRenewalTime();
            LastUsedTime();
            RemainingTime();

        }

        private void CurrentTime()
        {
            TimeSpan td = TimerUtility.CurrentTime.TimeOfDay;
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Current Time:", GUILayout.Width(90));
            EditorGUILayout.LabelField($"{(td.Hours>9?td.Hours:"0"+td.Hours)}:{(td.Minutes>9?td.Minutes:"0"+td.Minutes)}:{(td.Seconds>9?td.Seconds:"0"+td.Seconds)} UTC");
            EditorGUILayout.EndHorizontal();
        }
        private void ActionRenewalTime()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Renewal Time:", GUILayout.Width(90));
            _dailyEvent.Hour = EditorGUILayout.IntField(Math.Clamp(_dailyEvent.Hour, 0, 23), GUILayout.Width(20));
            EditorGUILayout.LabelField(":", GUILayout.Width(5));
            _dailyEvent.Minute = EditorGUILayout.IntField(Math.Clamp(_dailyEvent.Minute, 0, 59), GUILayout.Width(20));
            EditorGUILayout.LabelField(":", GUILayout.Width(5));
            _dailyEvent.Second = EditorGUILayout.IntField(Math.Clamp(_dailyEvent.Second, 0, 59), GUILayout.Width(20));
            EditorGUILayout.LabelField("UTC");
            EditorGUILayout.EndHorizontal();
        }

        private void LastUsedTime()
        {
            TimeSpan td = TimerUtility.CurrentTime.TimeOfDay;
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Last Used Time:", GUILayout.Width(110));
            EditorGUILayout.LabelField($"{_dailyEvent.LastUsedTime}");
            EditorGUILayout.EndHorizontal();
        }
        
        private void RemainingTime()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Remaining Time:", GUILayout.Width(110));
            EditorGUILayout.LabelField($"{_dailyEvent.GetRemainingTime()}");
            EditorGUILayout.EndHorizontal();
        }

    }

}
