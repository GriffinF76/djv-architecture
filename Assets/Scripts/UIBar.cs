using Sirenix.OdinInspector;
using UnityEngine;

public class UIBar : MonoBehaviour
{
    #region Fields

    [SerializeField] private RectTransform fillRectTransform;

    #endregion

    #region Properties

    [ShowInInspector, PropertyRange(0, 1)]
    public float FillValue
    {
        get => fillRectTransform.anchorMax.x;
        set
        {
            if (value < 0f) value = 0f;
            if (value > 1f) value = 1f;

            //copie du Vector2D anchorMax
            var anchorMax = fillRectTransform.anchorMax;

            //modification de la première coordonnées de cette copie
            anchorMax.x = value;

            //remplacement de l'ancien anchorMax par la copie modifiée.
            fillRectTransform.anchorMax = anchorMax;
        }
    }

    #endregion
}