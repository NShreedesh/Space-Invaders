using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionAnimation : MonoBehaviour
{
    [Header("Initial Child Count")]
    private int _noOfChild;
    private int _noOfChildsChild;

    [Header("Update Child Count During Animation Check")]
    private int _checkForChild;
    private int _checkForChilsChild;

    private void Awake()
    {
        _noOfChild = transform.childCount;
        _noOfChildsChild = transform.GetChild(_checkForChild).childCount;
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
        transform.GetChild(_checkForChild).GetChild(_checkForChilsChild).gameObject.SetActive(true);

        if(_checkForChilsChild < _noOfChildsChild - 1)
        {
            _checkForChilsChild++;
        }
        else if (_checkForChild < _noOfChild - 1)
        {
            _checkForChild++;
            _checkForChilsChild = 0;
        }
        else
        {
            CancelInvoke();
        }
    }
}
