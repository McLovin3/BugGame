using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Button : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public UI_System menuSys;

    void Start()
    {
        menuSys.AddUIbutton(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.current.PlaySFX(SoundManager.current.btnSelectSfx);
        menuSys.onUIbtnPressed(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundManager.current.PlaySFX(SoundManager.current.btnEnterSfx);
        menuSys.onUIbtnEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        menuSys.onUIbtnExit(this);
    }
}
