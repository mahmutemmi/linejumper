using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {

    public Transform player;

	void Start () {
		
	}
	
	void Update () {
        transform.position = new Vector3(player.position.x + 6, 0, -10);
	}
}
