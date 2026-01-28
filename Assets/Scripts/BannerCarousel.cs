using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BannerCarousel : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public ScrollRect scrollRect;
    public RectTransform content;
    public float autoScrollDelay = 3f;
    public float snapSpeed = 10f;

    public List<Image> dots;
    public Color activeDot;
    public Color inactiveDot;

    private int pageCount;
    private int currentIndex;
    private bool dragging;
    private float timer;
    private float[] pagePositions;

    void Start()
    {
        pageCount = content.childCount;
        CalculatePagePositions();
        CenterOnIndex(0);
        UpdateDots();
    }

    void Update()
    {
        if (dragging) return;

        timer += Time.deltaTime;
        if (timer >= autoScrollDelay)
        {
            timer = 0f;
            currentIndex = (currentIndex + 1) % pageCount;
        }

        float target = pagePositions[currentIndex];
        scrollRect.horizontalNormalizedPosition =
            Mathf.Lerp(scrollRect.horizontalNormalizedPosition, target, Time.deltaTime * snapSpeed);

        UpdateDots();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragging = false;
        timer = 0f;
        currentIndex = GetClosestIndex();
    }

    private void CalculatePagePositions()
    {
        pagePositions = new float[pageCount];

        if (pageCount == 1)
        {
            pagePositions[0] = 0.5f;
            return;
        }

        float contentWidth = content.rect.width;
        float viewportWidth = scrollRect.viewport.rect.width;
        float scrollableWidth = contentWidth - viewportWidth;

        for (int i = 0; i < pageCount; i++)
        {
            RectTransform child = content.GetChild(i) as RectTransform;
            float childCenter = -child.anchoredPosition.x - child.rect.width / 2;

            pagePositions[i] = childCenter / scrollableWidth;
        }

        for (int i = 0; i < pageCount; i++)
        {
            pagePositions[i] = i / (float)(pageCount - 1);
        }
    }

    private int GetClosestIndex()
    {
        float currentPos = scrollRect.horizontalNormalizedPosition;
        float minDistance = float.MaxValue;
        int closestIndex = 0;

        for (int i = 0; i < pageCount; i++)
        {
            float distance = Mathf.Abs(currentPos - pagePositions[i]);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestIndex = i;
            }
        }

        return closestIndex;
    }

    private void CenterOnIndex(int index)
    {
        scrollRect.horizontalNormalizedPosition = pagePositions[index];
        currentIndex = index;
    }

    private void UpdateDots()
    {
        for (int i = 0; i < dots.Count; i++)
            dots[i].color = i == currentIndex ? activeDot : inactiveDot;
    }

    public void GoToPage(int index)
    {
        if (index >= 0 && index < pageCount)
        {
            currentIndex = index;
            timer = 0f;
        }
    }
}