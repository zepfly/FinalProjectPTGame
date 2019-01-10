using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipManager : MonoBehaviour
{
    public Image tip2;
    public Text txtTip2;

    public Text tip1;

    // Start is called before the first frame update
    void Start()
    {
        tip2.enabled = false;
        tip1.enabled = false;
        txtTip2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
