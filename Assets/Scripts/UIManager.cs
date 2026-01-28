using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public CanvasGroup imageView;
    public Image imageViewPicture;

    public CanvasGroup premiumPopup;

    void Awake()
    {
        Instance = this;

        imageView.alpha = 0;
        imageView.gameObject.SetActive(false);

        premiumPopup.alpha = 0;
        premiumPopup.gameObject.SetActive(false);
    }

    public void OpenImage(Sprite sprite)
    {
        imageViewPicture.sprite = sprite;
        imageView.gameObject.SetActive(true);
        imageView.DOFade(1f, 0.25f);
    }

    public void CloseImage()
    {
        imageView.DOFade(0f, 0.2f).OnComplete(() =>
        {
            imageView.gameObject.SetActive(false);
        });
    }

    public void OpenPremium()
    {
        premiumPopup.gameObject.SetActive(true);
        premiumPopup.DOFade(1f, 0.25f);
    }

    public void ClosePremium()
    {
        premiumPopup.DOFade(0f, 0.2f).OnComplete(() =>
        {
            premiumPopup.gameObject.SetActive(false);
        });
    }
}
