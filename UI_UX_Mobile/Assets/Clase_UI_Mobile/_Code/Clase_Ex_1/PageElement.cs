using Dino.UtilityTools.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class PageElement : MonoBehaviour
{
    [SerializeField] LayoutElement layoutElement;
    
    
    void Start()
    {
        if (layoutElement == null)
        {
            layoutElement = GetComponent<LayoutElement>();
        }

        //Test en unity
        ResponsiveManager.Instance.OnScreenSizeChanged.AddListener(OnScreenChange);
        
        //Runtime Juego
        CheckDevice();
    }

    private void CheckDevice()
    {
        if (ResponsiveManager.Instance.CurrentDeviceType == DeviceType.Mobile)
        {
            layoutElement.preferredWidth = layoutElement.minWidth;
        }
        else if (ResponsiveManager.Instance.CurrentDeviceType == DeviceType.Tablet)
        {
            layoutElement.preferredWidth = 1660;
        }
        
        Debug.Log( $"[PageElement] DeviceType: {ResponsiveManager.Instance.CurrentDeviceType} - Width: {layoutElement.preferredWidth}".SetColor(ColorDebug.Purple));
            
    }

    private void OnScreenChange()
    {
        CheckDevice();   
    }
}
