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
    
    public event Action<int> Changed;

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
                _coroutine = StartCoroutine(Counting());
            }
            else
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private IEnumerator Counting()
    {
        WaitForSeconds timeDelay = new WaitForSeconds(_delay);

        while (true)
        {            
            IncreaseCount();
            yield return timeDelay;
        }        
    }

    private void IncreaseCount()
    {
        _count++;
        Changed?.Invoke(_count);
    }
}
