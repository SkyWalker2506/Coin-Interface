using System;
using TimeSystem;
using UnityEditor;
using UnityEngine;

namespace Game.TimeSystem
{
    [CustomEditor(typeof(SavableDailyEvent))]
    public class SavableDailyEventInspector : DailyEventInspector
    {
        private SavableDailyEvent savableDailyEvent;
        protected override void OnEnable()
        {
            base.OnEnable();
            savableDailyEvent = (SavableDailyEvent)target;
        }        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            SaveData();
        }
        
        
        private void SaveData()
        {
            savableDailyEvent.SaveKey = EditorGUILayout.TextField("Save Key: ",savableDailyEvent.SaveKey);
        }
    }
}