using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GalleryController : MonoBehaviour
{
    public Transform content;
    public GalleryItem itemPrefab;
    public ScrollRect scrollRect;

    const string baseUrl = "http://data.ikppbb.com/test-task-unity-data/pics/";

    List<GalleryItem> items = new List<GalleryItem>();

    void Start()
    {
        BuildGallery();
        ShowAll();
    }

    void BuildGallery()
    {
        for (int i = 1; i <= 66; i++)
        {
            GalleryItem item = Instantiate(itemPrefab, content);
            item.Init(i, baseUrl + i + ".jpg", scrollRect);
            items.Add(item);
        }
    }

    void ScrollToTop()
    {
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 1f;
    }

    public void ShowAll()
    {
        foreach (var item in items)
            item.gameObject.SetActive(true);

        ScrollToTop();
    }

    public void ShowOdd()
    {
        foreach (var item in items)
            item.gameObject.SetActive(item.Index % 2 == 1);

        ScrollToTop();
    }

    public void ShowEven()
    {
        foreach (var item in items)
            item.gameObject.SetActive(item.Index % 2 == 0);

        ScrollToTop();
    }
}
