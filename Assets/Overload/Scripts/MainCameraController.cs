using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour {

    public GameObject Player;

    private float offsetX = 7;
	
	// Update is called once per frame
	void Update () {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            var pX = player.transform.position.x;
            transform.position = new Vector3(pX + this.offsetX, transform.position.y, transform.position.z);
        }
	}
}
