using UnityEngine;
using DG.Tweening;

public class SplashController : MonoBehaviour
{
    public CanvasGroup logo;
    public CanvasGroup mainMenu;

    public float logoFadeDuration = 1f;
    public float logoShowDelay = 1f;
    public float menuFadeDuration = 0.8f;

    void Start()
    {
        logo.alpha = 0;
        mainMenu.alpha = 0;

        logo.DOFade(1f, logoFadeDuration)
            .OnComplete(() =>
            {
                DOVirtual.DelayedCall(logoShowDelay, ShowMenu);
            });
    }

    void ShowMenu()
    {
        logo.DOFade(0f, 0.5f);
        mainMenu.DOFade(1f, menuFadeDuration);
    }
}
