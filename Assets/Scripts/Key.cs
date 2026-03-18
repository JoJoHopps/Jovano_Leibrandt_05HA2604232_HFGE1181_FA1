using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Player"))
        {
            transform.SetParent(trig.gameObject.transform.Find("Key Holder"));
            transform.localPosition = new Vector3(0, 0, 0);
            GameMNGR.instance.SetHasKey(true);
            Collider2D col = GetComponent<Collider2D>();
            col.enabled = false;
        }
    }

}
