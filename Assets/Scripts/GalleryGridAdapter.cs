using UnityEngine;
using UnityEngine.UI;

public class GalleryGridAdapter : MonoBehaviour
{
    public GridLayoutGroup grid;

    public int phoneColumns = 2;
    public int tabletColumns = 3;

    public float tabletMinInches = 7f;

    void Start()
    {
        Apply();
    }

#if UNITY_EDITOR
    void Update()
    {
        Apply();
    } 
#endif

    void Apply()
    {
        float diagonal = Mathf.Sqrt(
            Screen.width * Screen.width +
            Screen.height * Screen.height
        ) / Screen.dpi;

        bool isTablet = Screen.dpi > 0 && diagonal >= tabletMinInches;

        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = isTablet ? tabletColumns : phoneColumns;
    }
}
