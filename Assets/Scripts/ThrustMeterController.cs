using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrustMeterController : MonoBehaviour
{
    public Canvas canvas;
    private UnityEngine.UI.Image bar;

    // Start is called before the first frame update
    void Start()
    {
        //canvas = this.GetComponent<Canvas>();
        bar = canvas.GetComponentInChildren<Image>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void setValue(float val) {
        if (val <= 0f)
        {
            bar.fillAmount = 0f;
        }
        else if (val >= 1f)
        {
            bar.fillAmount = 1f;
        }
        else {
            bar.fillAmount = val;
        }

    }
}
