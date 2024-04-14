using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InteractableToggle : Interactable
{
    [SerializeField] private UnityEvent<bool> _onChangeState;
    [SerializeField] private Color _onSelectedColor;

    private bool _isPressed;

    public Color NormalColor => _isPressed ? _onSelectedColor : OnPointerExitColor;

    protected override void Reset()
    {
        _onSelectedColor = Color.white;
        base.Reset();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        ChangeState();
        _onChangeState.Invoke(_isPressed);
        base.OnPointerClick(eventData);
    }

    protected override Color GetNormalColor() =>
        NormalColor;

    private void ChangeState() =>
        _isPressed = !_isPressed;
}
