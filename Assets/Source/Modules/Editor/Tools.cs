using Source.Modules.Data;
using UnityEditor;
using UnityEngine;

namespace Source.Modules.Editor
{
    public class Tools 
    {
        [MenuItem("Tools/ClearPrefs")]
        public static void ClearPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
        [MenuItem("Tools/ShowPrefs")]
        public static void ShowPrefs()
        {
            //PlayerPrefs.GetString("Progress").ToDeserialized<PlayerProgress>();
        }
    }
}