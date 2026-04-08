using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ValueChanged += UpdateCounterDisplay;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= UpdateCounterDisplay;
    }

    private void UpdateCounterDisplay()
    {
        int number = _counter.ChangeableNumber;
        _text.text = number.ToString();
    }
}
