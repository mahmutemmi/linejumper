using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusControlScript : MonoBehaviour {
    HUDScript hud;

    void Start()
    {
        hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hud.IncreaseLine(1);
            Destroy(gameObject);
            return;
        }
    }
}
