using System;
using System.Collections.Generic;
using Dino.UtilityTools.Singleton;
using UnityEngine;
using UnityEngine.Events;

public class ResponsiveManager : Singleton<ResponsiveManager>
{
    public UnityEvent OnScreenSizeChanged { get; private set; } = new UnityEvent();
    private Vector2 _lastScreenSize;

    public ScreenOrientation CurrentOrientation => GetScreenOrientation();
    
    public DeviceType CurrentDeviceType
    {
        get
        {
            return GetDeviceTypeByResolution(Screen.width, Screen.height);
        }
    }

    #region Unity Methods
    
    private void OnEnable()
    {
        _lastScreenSize = new Vector2(Screen.width, Screen.height);
        Application.onBeforeRender += CheckScreenSizeChange;
    }

    private void OnDisable()
    {
        Application.onBeforeRender -= CheckScreenSizeChange;
    }

    private void Start()
    {
        Debug.Log(CurrentDeviceType);
    }
    #endregion

    private void CheckScreenSizeChange()
    {
        Vector2 currentScreenSize = new Vector2(Screen.width, Screen.height);
        if (_lastScreenSize != currentScreenSize)
        {
            _lastScreenSize = currentScreenSize;
            OnScreenSizeChanged?.Invoke();
            Debug.Log($"Screen size changed: {currentScreenSize.x}x{currentScreenSize.y} Orientation: {(IsPortrait() ? "Portrait" : "Landscape")}");
        }
    }
    
    public bool IsPortrait()
    {
        return Screen.width < Screen.height;
    }
    public bool IsLandscape()
    {
        return Screen.width >= Screen.height;
    }
    
    public ScreenOrientation GetScreenOrientation()
    {
        return IsPortrait() ? ScreenOrientation.Portrait : ScreenOrientation.Landscape;
    }
    
   public DeviceType GetDeviceTypeByResolution(int width, int height)
   {
       int minDimension = Math.Min(width, height);
       if (minDimension >= 600)
           return DeviceType.Tablet;
       else
           return DeviceType.Mobile;
   }
}

public enum ScreenOrientation
{
    Portrait,
    Landscape
}
public enum DeviceType
{
    Mobile,
    Tablet,
}