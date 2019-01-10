using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public BoxCollider2D PlatformBoxCollider;

    private void Start()
    {
        //PlatformBoxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                PlatformBoxCollider.enabled = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("restore");
        PlatformBoxCollider.enabled = true;
        Restore();
        //StartCoroutine("Restore", 0.5f);
    }

    void Restore()
    {
        PlatformBoxCollider.enabled = true;
    }
}
