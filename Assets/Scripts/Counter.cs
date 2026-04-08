using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{    
    [SerializeField] private float _increasingValue = 0.5f;
    [SerializeField] private int _timeDelay = 1;

    private Coroutine _coroutine;
    private bool isCounting = false;

    public event Action ValueChanged;

    public int ChangeableNumber { get; private set; } = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeValue();
        }
    }

    private void ChangeValue()
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
        var wait = new WaitForSeconds(_increasingValue);

        while (isCounting)
        {
            ChangeableNumber += _timeDelay;
            ValueChanged?.Invoke();

            yield return wait;
        }
    }
}
