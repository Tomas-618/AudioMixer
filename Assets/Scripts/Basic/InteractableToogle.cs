using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class InteractableToogle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerClickHandler
{
    [SerializeField, Range(0, 1)] private float _deltaColorValue;

    [SerializeField] private UnityEvent _onClick;
    [SerializeField] private Color _onPointerEnterColor;
    [SerializeField] private Color _onPointerExitColor;
    [SerializeField] private Color _onSelectedColor;
    [SerializeField] private Color _onPointerDownColor;

    private Coroutine _coroutine;
    private Image _image;
    private bool _isPressed;

    public Color NormalColor => _isPressed ? _onSelectedColor : _onPointerExitColor;

    private void Reset()
    {
        _deltaColorValue = 0.05f;
        _onPointerEnterColor = Color.white;
        _onPointerExitColor = Color.white;
        _onSelectedColor = Color.white;
        _onPointerDownColor = Color.white;
    }

    private void Start() =>
        _image = GetComponent<Image>();

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeColor(_image.color, _onPointerEnterColor));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeColor(_image.color, NormalColor));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeColor(_image.color, _onPointerDownColor));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _onClick?.Invoke();
        _isPressed = !_isPressed;

        OnPointerEnter(eventData);
    }

    private IEnumerator ChangeColor(Color startColor, Color endColor)
    {
        float currentColorValue = 0;

        while (_image.color != endColor)
        {
            _image.color = Color.Lerp(startColor, endColor, currentColorValue += _deltaColorValue);

            yield return null;
        }
    }
}
