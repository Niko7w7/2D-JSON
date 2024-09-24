using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Cherry")]
    public int value = 1;  //Valor Cherry

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Funciona :P");

            GameManager.Instance.CollectableItem(value);
            Destroy(gameObject);

            Debug.Log("Murió :(");
        }
    }
}
