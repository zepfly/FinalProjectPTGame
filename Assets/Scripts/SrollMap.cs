using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SrollMap : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();   
    }

    private void FixedUpdate()
    {
        GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(player.transform.position.x * 0.1f,
            GetComponent<MeshRenderer>().material.mainTextureOffset.y);
    }
}
