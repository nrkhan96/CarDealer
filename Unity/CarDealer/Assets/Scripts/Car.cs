using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] TextMeshPro TextObj;
 
    public int value;
    
    void Start()
    {
        SetValueText();
    }

    private void SetValueText()
    {
        if (value >= 0)
        {
            TextObj.color = new Color(0, 255, 0, 255);
            TextObj.text = "$" + value;
        }
        else
        {
            TextObj.color = new Color(255, 0, 0, 255);
            TextObj.text = "-$" + (value*-1);
        }
        
    }

    void Update()
    {
        
    }
}
