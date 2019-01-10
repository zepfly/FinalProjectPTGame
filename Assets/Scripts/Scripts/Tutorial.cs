using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update

    public TipManager tipManager;
    public int tipnum = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (tipnum == 1)
                tipManager.tip1.enabled = true;
            else if (tipnum == 2)
            {
                tipManager.tip2.enabled = true;
                tipManager.txtTip2.enabled = true;
            }


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tipManager.tip1.enabled = false;
            tipManager.txtTip2.enabled = false;
            tipManager.tip2.enabled = false;
        }
    }
}
