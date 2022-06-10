using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] TextMeshPro TextObj;

    void Start()
    {
        SetValueText();
    }

    void Update()
    {
        
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
            TextObj.text = "-$" + (value * -1);
        }

    }

    public void AddValueText(int val) 
    {
        value += val;
        SetValueText();
    }
}
