using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (/*collision.CompareTag("Player") && */gameObject.GetComponent<Collider2D>().enabled == false)
        {
            Debug.Log("restore");
            gameObject.GetComponent<Collider2D>().enabled = true;
            //Invoke("Restore", 0.5f);
        }
    }

    void Restore()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
