using TMPro;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private string _firstText;
    [SerializeField] private string _secondText;

    private TMP_Text _text;

    private void Start() =>
        _text = GetComponent<TMP_Text>();

    public void OnToggleChange(bool state) =>
        _text.text = state ? _secondText : _firstText;
}
