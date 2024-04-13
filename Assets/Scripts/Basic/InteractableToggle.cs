using UnityEngine;

public class InteractableToggle : InteractableButton
{
    [SerializeField] private Color _onSelectedColor;

    private bool _isPressed;

    public Color NormalColor => _isPressed ? _onSelectedColor : OnPointerExitColor;

    protected override void Reset()
    {
        _onSelectedColor = Color.white;
        base.Reset();
    }

    private void OnEnable() =>
        OnClick += ChangeState;

    private void OnDisable() =>
        OnClick -= ChangeState;

    protected override Color GetNormalColor() =>
        NormalColor;

    private void ChangeState() =>
        _isPressed = !_isPressed;
}
