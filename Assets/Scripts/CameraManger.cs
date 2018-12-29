using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManger : MonoBehaviour
{
    public GameObject player;

    public float smoothtimeX, smoothtimeY;
    public Vector2 velocity;
    public bool isBound;
    public Vector2 minPos, maxPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        float x = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothtimeX);
        float y = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothtimeY);
        transform.position = new Vector3(x, y, transform.position.z);

        if (isBound)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x),
               Mathf.Clamp(transform.position.y, minPos.y, maxPos.y),
               transform.position.z);
        }
    }
}
