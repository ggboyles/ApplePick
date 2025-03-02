using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    public static float bottomY = -15f;

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Basket"))
        {
            Debug.Log("Branch hit a basket! Game Over!");

            // finds ApplePicker script and ends game
            ApplePicker apScript = FindFirstObjectByType<ApplePicker>(); 
            if (apScript != null)
            {
                apScript.GameOver();
            }

            Destroy(gameObject);
        }
    }
}
