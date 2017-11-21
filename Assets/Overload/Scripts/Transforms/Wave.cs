using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float amplitude = 0.5f;

    float defY;

    // Use this for initialization
    void Start()
    {
        this.defY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float nextY = this.defY + ((Mathf.PingPong(Time.time, 1f) - 0.5f) * amplitude);
        var pos = transform.position;
        pos.y = nextY;
        transform.position = pos;
    }
}
