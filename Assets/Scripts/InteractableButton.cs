using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractableButton : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _onPointerEnterColor;

    private void Start() =>
        _image = GetComponent<Image>();

    public void OnPointerEnter(PointerEventData eventData) =>
        _image.color = _onPointerEnterColor;
}
