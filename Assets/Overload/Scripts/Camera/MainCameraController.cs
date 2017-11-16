using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public float MaxX = 0;

    private GameObject Player;
    private float offsetX = 6;

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && !this.MaxX.Equals(0) && transform.position.x < this.MaxX)
        {
            var pX = player.transform.position.x;
            transform.position = new Vector3(pX + this.offsetX, transform.position.y, transform.position.z);
        } else {
            var pos = transform.position;
            pos.x = this.MaxX;
            transform.position = pos;
        }
    }
}
