using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.OnValueChanged += UpdateCounterDisplay;
    }

    private void OnDisable()
    {
        _counter.OnValueChanged -= UpdateCounterDisplay;
    }

    private void UpdateCounterDisplay()
    {
        if (_text != null)
        {
            int number = _counter.ChangeableNumber;
            _text.text = number.ToString();
        }
    }
}
