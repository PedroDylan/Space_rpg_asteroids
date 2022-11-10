using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public float duration = 4f;


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
           StartCoroutine(Pickup(other));
        }

    }

    IEnumerator Pickup(Collider2D player)
    {
        player.transform.localScale *= 0.5f;

        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(duration);


        player.transform.localScale /= 0.5f;
        Destroy(gameObject);
    }

}
