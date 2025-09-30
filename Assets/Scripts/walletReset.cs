using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

[InitializeOnLoad]
public static class walletReset
{
     static walletReset()
    {
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    private static void OnPlayModeChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingPlayMode)
        {
            WalletData wallet = AssetDatabase.LoadAssetAtPath<WalletData>("Assets/Resources/ScriptableObjects/WalletData.asset");
            if (wallet != null)
            {
                 var fields = typeof(WalletData).GetFields();
                foreach (var field in fields)
                {
                    if (field.FieldType == typeof(int))
                    {
                        field.SetValue(wallet, 0); 
                    }
                }
                EditorUtility.SetDirty(wallet); 
                Debug.Log("WalletData reset to 0 for Play mode.");
            }
        }
    }
}
