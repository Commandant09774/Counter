using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountViewer : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TMP_Text _countText;

    
    private void Start()
    {
        
    }
    private void OnEnable()
    {
        _counter.CounterChanged += UpdateCounter;
    }

    private void OnDisable()
    {
        _counter.CounterChanged -= UpdateCounter;
    }

    private void UpdateCounter(int currentCount)
    {
        _countText.text = currentCount.ToString();
    }  
}

