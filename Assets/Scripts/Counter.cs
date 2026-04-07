using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{    
    [SerializeField] private float _increasingValue = 0.5f;
    [SerializeField] private int _timeDelay = 1;

    public event Action OnValueChanged;

    public int ChangeableNumber { get; private set; } = 0;

    private Coroutine _coroutine;
    private bool isCounting = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounter();
        }
    }

    private void ToggleCounter()
    {
        if (isCounting == false)
        {
            isCounting = true;
            _coroutine = StartCoroutine(IncreaseValue());
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }

            isCounting = false;
        }
    }

    private IEnumerator IncreaseValue()
    {
        var wait = new WaitForSeconds(0.5f);

        while (isCounting)
        {
            ChangeableNumber += _timeDelay;
            OnValueChanged?.Invoke();

            yield return wait;
        }
    }
}
