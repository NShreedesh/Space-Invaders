using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionAnimation : MonoBehaviour
{
    private int childCount;
    private int childOfChildCount;

    private int parentChildCount;
    private int childChildCount;

    private void Awake()
    {
        parentChildCount = transform.childCount;
        childChildCount = transform.GetChild(childCount).childCount;
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
        transform.GetChild(childCount).GetChild(childOfChildCount).gameObject.SetActive(true);

        if(childOfChildCount < childChildCount - 1)
        {
            childOfChildCount++;
        }
        else if (childCount < parentChildCount - 1)
        {
            childCount++;
            childOfChildCount = 0;
        }
        else
        {
            CancelInvoke();
        }
    }
}
