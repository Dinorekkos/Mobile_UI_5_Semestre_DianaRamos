using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICurrencyTrade : UIWindow
{
    [Header("CurrencyButtons")]
    [SerializeField]private Button _standardC;
    [SerializeField]private Button _premiumC;
    [Header("Payment")]
    [SerializeField]private TextMeshProUGUI _diamondsWager;
    [SerializeField]private TextMeshProUGUI _diamondsTotal;
    [SerializeField]private TextMeshProUGUI _gachaTotal;
    [SerializeField]private Image _gachaTotalIcon;
    [SerializeField]private Slider _purcharseSlider;
    [Header("ExitButtons")]
    [SerializeField]private Button _returnButton;
    [SerializeField]private Button _confirmButton;
    
}
