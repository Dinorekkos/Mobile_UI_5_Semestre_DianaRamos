using System;
using System.Collections.Generic;
using Dino.UtilityTools.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class UILevelPreview : UIWindow
{
    #region Popup implementation
    
    #region serialized Fields

    [Header("UILevel Settings")] 
   
    [SerializeField] private Button _buttonPlay;
    [SerializeField] private Button _buttonReturn;
    [SerializeField] private List<GameObject> _rewards;
    [SerializeField] private GameObject _content; 
    [SerializeField] private TextMeshProUGUI _lvlNameText;
    #endregion

    public void ChangeName(string levelName)
    {
        _lvlNameText.text = levelName;
    }
    public void DisplayRewards()
    {
        for(int i = 0; i < _rewards.Count; i++)
        {
            Instantiate(_rewards[i], _content.transform);
        }
    }
    public void AddReward(GameObject reward)
    {
        _rewards.Add(reward);
    }
    public override void Initialize()
    {
        base.Initialize();
        _buttonReturn.onClick.AddListener(ReturnClick);
        _buttonPlay.onClick.AddListener(PlayClick);
        
        _lvlNameText.text = string.Empty;
    }

    private void OnDestroy()
    {
        _buttonReturn.onClick.RemoveListener(ReturnClick);
        _buttonPlay.onClick.RemoveListener(PlayClick);
    }

    
    
    private void PlayClick()
    {
        Debug.Log("Yes Clicked");
        Hide();
    }
    private void ReturnClick()
    {
        Debug.Log("No clicked");
        Hide();
    }
    #endregion
}
