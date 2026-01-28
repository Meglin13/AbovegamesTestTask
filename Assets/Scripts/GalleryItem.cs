using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using DG.Tweening;
using System.Collections;
using TMPro;

public class GalleryItem : MonoBehaviour
{
    public Image picture;
    public GameObject premiumBadge;
    public TextMeshProUGUI text;

    public int Index { get; private set; }

    string imageUrl;
    bool isPremium;
    bool isLoaded;

    RectTransform rect;
    ScrollRect scrollRect;

    public void Init(int imageIndex, string url, ScrollRect sr)
    {
        Index = imageIndex;
        imageUrl = url;
        scrollRect = sr;
        text.text = imageIndex.ToString();

        isPremium = Index % 4 == 0;
        premiumBadge.SetActive(isPremium);

        rect = GetComponent<RectTransform>();
        picture.color = new Color(1, 1, 1, 0);
    }

    void Update()
    {
        if (isLoaded)
            return;

        if (IsVisible())
            StartCoroutine(LoadImage());
    }

    bool IsVisible()
    {
        Rect viewport = scrollRect.viewport.rect;

        Vector3[] corners = new Vector3[4];
        rect.GetWorldCorners(corners);

        for (int i = 0; i < 4; i++)
        {
            Vector3 local = scrollRect.viewport.InverseTransformPoint(corners[i]);
            if (viewport.Contains(local + Vector3.up * 200))
                return true;
        }

        return false;
    }

    IEnumerator LoadImage()
    {
        isLoaded = true;

        UnityWebRequest req = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return req.SendWebRequest();

        if (req.result != UnityWebRequest.Result.Success)
            yield break;

        Texture2D tex = DownloadHandlerTexture.GetContent(req);
        picture.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        picture.DOFade(1f, 0.3f);
    }

    public void OnClick()
    {
        if (isPremium)
            Debug.Log("Open Premium Popup");
        else
            Debug.Log("Open Image Popup " + Index);
    }
}
