using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public bool Activated = true;

    public static CheckPoint instance;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !Activated)
        {
            Activated = true;

            instance = this;

            PlayerPrefs.SetFloat("PlayerPosX", other.transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", other.transform.position.y);

            PlayerPrefs.Save();
            Debug.Log("Funciona :D");
        }
    }
}
