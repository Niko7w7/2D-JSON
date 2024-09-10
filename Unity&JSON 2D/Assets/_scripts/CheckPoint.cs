using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public static CheckPoint activeCheckpoint;

    public bool Activated = false;

    private void OntriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !Activated)
        {
            Activated = true;

            activeCheckpoint = this;

            PlayerPrefs.SetFloat("PlayerPosX".other.transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY".other.transform.position.y);

            PlayerPrefs.Save();
        }
    } 
}
    