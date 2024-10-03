using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Contador Item
    public static GameManager Instance;
    public TMP_Text itemCountText;

    public int itemCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void CollectableItem(int value)
    {
        itemCount += value;
        UpdateitemCount();
    } 

    private void UpdateitemCount()
    {
        itemCountText.text = ": " + itemCount.ToString();
    }

}
