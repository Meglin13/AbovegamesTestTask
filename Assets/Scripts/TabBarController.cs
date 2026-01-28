using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabBarController : MonoBehaviour
{
    public GalleryController gallery;

    public TextMeshProUGUI allText;
    public TextMeshProUGUI oddText;
    public TextMeshProUGUI evenText;

    public Image allLine;
    public Image oddLine;
    public Image evenLine;

    public Color activeColor;
    public Color inactiveColor;

    void Start()
    {
        ActivateAll();
    }

    void ResetVisuals()
    {
        allText.color = inactiveColor;
        oddText.color = inactiveColor;
        evenText.color = inactiveColor;

        allLine.gameObject.SetActive(false);
        oddLine.gameObject.SetActive(false);
        evenLine.gameObject.SetActive(false);
    }

    public void ActivateAll()
    {
        ResetVisuals();
        allText.color = activeColor;
        allLine.gameObject.SetActive(true);
        gallery.ShowAll();
    }

    public void ActivateOdd()
    {
        ResetVisuals();
        oddText.color = activeColor;
        oddLine.gameObject.SetActive(true);
        gallery.ShowOdd();
    }

    public void ActivateEven()
    {
        ResetVisuals();
        evenText.color = activeColor;
        evenLine.gameObject.SetActive(true);
        gallery.ShowEven();
    }
}
