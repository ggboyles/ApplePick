using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
public ScoreCounter scoreCounter;
private ApplePicker applePicker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // find a GameObject named ScoreCounter in scene hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // get the ScoreCounter (script) component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        // find ApplePicker
        applePicker = FindFirstObjectByType<ApplePicker>();
    }

    // Update is called once per frame
    void Update()
    {
        // get current screen position of mouse from input
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;

        // converts point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        // find out what hit basket
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);

            if(applePicker != null)
            {
                applePicker.IncreaseAppleCount();
            }
        }
    }
}
