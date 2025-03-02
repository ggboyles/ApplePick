using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    [SerializeField] private GameObject gameOverPanel;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    [Header("Round Settings")]
    public int roundNumber = 1;
    public int applesCaught = 0;
    public int applesPerRound = 10;
    public TextMeshProUGUI roundText;
   
    public void GameOver()
    {
        Debug.Log("Game Over!");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateRoundText()
{
    roundText.text = "Round " + roundNumber;
}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateRoundText();
        
        if (gameOverPanel == null)
        {
            gameOverPanel = GameObject.Find("GameOverPanel");
        }
        gameOverPanel.SetActive(false);

        basketList = new List<GameObject>();
        for(int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleMissed()
    {
        // destroy all falling apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        // destroy one of the baskets
        int basketIndex = basketList.Count - 1;
        // get reference to that Basket GameObject
        GameObject basketGO = basketList[basketIndex];
        // remove the basket from the list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        // if no baskets left, game over
        if(basketList.Count == 0)
        {
            if(basketList.Count == 0)
            {
                GameOver();
            }
        }
    }

    public void IncreaseAppleCount()
    {
        applesCaught++;

        // checks if round increases
        if (applesCaught >= applesPerRound && roundNumber < 4)
        {
            roundNumber++;
            applesCaught = 0;
            UpdateRoundText();
        }
    }


}
