using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabSystem tabSystem;
    public Image img;

    void Start()
    {
        img = GetComponent<Image>();
        tabSystem.AddTab(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabSystem.onTabPressed(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabSystem.onTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabSystem.onTabExit(this);
    }
}
