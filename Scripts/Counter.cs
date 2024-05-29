using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay;
    
    private int _count;
    private Coroutine _coroutine;
    
    public event Action<int> CounterChanged;

    private void Awake()
    {
        _count = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(IncreaseCountUnstopable());
            }
            else
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private IEnumerator IncreaseCountUnstopable()
    {
        WaitForSeconds timeDelay = new WaitForSeconds(_delay);

        while (true)
        {            
            IncreaseCount();
            yield return timeDelay;
        }        
    }

    public void IncreaseCount()
    {
        _count++;
        CounterChanged?.Invoke(_count);
    }
}
