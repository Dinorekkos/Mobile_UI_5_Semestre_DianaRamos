using UnityEngine;
using UnityEngine.Events;

public class UIWindow : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private string windowID;
    [SerializeField] private Canvas windowCanvas;
    [SerializeField] private CanvasGroup windowCanvasGroup;
    
    [Header("Options")]
    [SerializeField] private bool hideOnStart = true;
    
    public UnityEvent OnStartShowingUI { get; private set; } = new UnityEvent();
    public UnityEvent OnFinishedShowingUI {get; private set;} = new UnityEvent();
    
    public UnityEvent OnStartHidingUI { get; private set; } = new UnityEvent();
    public UnityEvent OnFinishedHidingUI { get; private set; } = new UnityEvent();
    
    
    public bool IsShowing { get; private set; } = false;
    public string WindowID => windowID;
    
    private void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        if(hideOnStart) Hide(true);
        
    }
    public virtual void Show(bool instant = false)
    {
        windowCanvas.gameObject.SetActive(true);
    }
    
    public virtual void Hide(bool instant = false)
    {
        windowCanvas.gameObject.SetActive(false);
    }
    
    
    
}
