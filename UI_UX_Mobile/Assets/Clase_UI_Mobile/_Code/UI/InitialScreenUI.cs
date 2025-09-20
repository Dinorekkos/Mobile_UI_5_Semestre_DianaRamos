using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class InitialScreenUI : UIWindow
{
    [Header("INitial Screen UI")]
    [SerializeField] private Image _image1;
    [SerializeField] private Image _image2;


    public override void Initialize()
    {
        Hide(true);
    }

    public override void Show(bool instant = false)
    {
        _image1.rectTransform.DOAnchorPosX(100, AnimationTime);
        _image2.rectTransform.DOAnchorPosX(-100, AnimationTime);
    }

    public override void Hide(bool instant = false)
    {
        if (instant)
        {
            _image1.rectTransform.DOAnchorPosX(0, 0);
            _image2.rectTransform.DOAnchorPosX(0, 0);
        }
        else
        {
            _image1.rectTransform.DOAnchorPosX(0, AnimationTime);
            _image2.rectTransform.DOAnchorPosX(0, AnimationTime);
        }
        
    }
}
