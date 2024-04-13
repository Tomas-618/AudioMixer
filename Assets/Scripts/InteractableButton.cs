using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractableButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _onPointerEnterColor;
    [SerializeField] private Color _onPointerExitColor;

    private void Start() =>
        _image = GetComponent<Image>();

    public void OnPointerEnter(PointerEventData eventData) =>
        _image.color = _onPointerEnterColor;

    public void OnPointerExit(PointerEventData eventData) =>
        _image.color = _onPointerExitColor;
}
