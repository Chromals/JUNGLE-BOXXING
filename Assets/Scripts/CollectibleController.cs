using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Powerbomb"))
        {
            UIController.Instance.IncreaseCountCollectible();
            Destroy(gameObject);
        }
    }
}
