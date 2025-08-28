using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<UIWindow> uiWindows = new List<UIWindow>();
    
    public void ShowUIWindow(string windowUI)
    {
        foreach (var window in uiWindows)
        {
            if (window.WindowID == windowUI)
            {
                window.Show();
                return;
            }
        }
        Debug.LogWarning($"UI Window with name {windowUI} not found.");
    }
    
    public void HideUIWindow(string windowUI)
    {
        foreach (var window in uiWindows)
        {
            if (window.WindowID == windowUI)
            {
                window.Hide();
                return;
            }
        }
        Debug.LogWarning($"UI Window with name {windowUI} not found.");
    }


    #region Editor

    private void GetAllUIWindows()
    {
        uiWindows.Clear();
        UIWindow[] windows = FindObjectsOfType<UIWindow>(true);
        uiWindows.AddRange(windows);
    }

    #endregion
}
