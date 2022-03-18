using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionAnimation : MonoBehaviour
{
    private int _childCount;
    private int _childOfChildCount;

    private int _parentChildCount;
    private int _childChildCount;

    private void Awake()
    {
        _parentChildCount = transform.childCount;
        _childChildCount = transform.GetChild(_childCount).childCount;
    }

    private void Start()
    {
        DisableInstruction();

        InvokeRepeating(nameof(EnableInstruction), 1, 0.5f);
    }

    private void DisableInstruction()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            for(int j = 0; j < transform.GetChild(i).childCount; j++)
            {
                transform.GetChild(i).GetChild(j).gameObject.SetActive(false);
            }
        }
    }

    private void EnableInstruction()
    {
        transform.GetChild(_childCount).GetChild(_childOfChildCount).gameObject.SetActive(true);

        if(_childOfChildCount < _childChildCount - 1)
        {
            _childOfChildCount++;
        }
        else if (_childCount < _parentChildCount - 1)
        {
            _childCount++;
            _childOfChildCount = 0;
        }
        else
        {
            CancelInvoke();
        }
    }
}
