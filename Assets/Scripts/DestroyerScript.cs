using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector3 currentPlayerPosition = collision.transform.position;
            Rigidbody2D currentPlayerRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
            currentPlayerRigidBody.velocity = new Vector2(currentPlayerRigidBody.velocity.x, 0);
            collision.transform.position = new Vector3(currentPlayerPosition.x, 0.35f, currentPlayerPosition.z);
            return;
        }
        if (collision.gameObject.transform.parent)
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
