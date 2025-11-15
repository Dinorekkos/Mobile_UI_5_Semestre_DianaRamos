using System;
using NaughtyAttributes;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    [SerializeField] private GameObject debugConsoleUI;
    private bool debugConsole = false;


    private void Awake()
    {
        if (Debug.isDebugBuild || Application.isEditor)
        {
            debugConsole = true;
            Debug.Log("Debug Logs Enabled");
        }
        
        debugConsoleUI.SetActive(debugConsole);
    }

    [Button]

    public void EnableDebugLogs()
    {
        debugConsole = true;
        debugConsoleUI.SetActive(debugConsole);
    }

    [Button]
    public void DisableDebugLogs()
    {
        debugConsole = false;
        debugConsoleUI.SetActive(debugConsole);
    }
}
