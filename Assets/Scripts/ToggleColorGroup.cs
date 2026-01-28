using UnityEngine;
using UnityEngine.UI;

public class ToggleColorGroup : MonoBehaviour
{
    public Toggle[] toggles;
    public Color activeColor;
    public Color inactiveColor;

    int currentIndex = 0;

    void Start()
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            int index = i;
            toggles[i].onValueChanged.AddListener(isOn =>
            {
                if (isOn)
                    Activate(index);
                else if (index == currentIndex)
                    toggles[index].SetIsOnWithoutNotify(true);
            });
        }

        Activate(0);
    }

    void Activate(int index)
    {
        currentIndex = index;

        for (int i = 0; i < toggles.Length; i++)
        {
            bool active = i == index;

            toggles[i].SetIsOnWithoutNotify(active);

            Text text = toggles[i].GetComponentInChildren<Text>();
            if (text != null)
                text.color = active ? activeColor : inactiveColor;

            Image bg = toggles[i].targetGraphic as Image;
            if (bg != null)
                bg.color = active ? activeColor : inactiveColor;
        }
    }
}
