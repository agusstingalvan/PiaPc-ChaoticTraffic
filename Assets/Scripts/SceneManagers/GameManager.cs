using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    [HideInInspector]
    public bool gameOver = false;

    [SerializeField]
    public int totalCrashes = 0;
    public int time = 0;

    [HideInInspector]
    public UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _uiManager.UpdateLives(totalCrashes);
        _uiManager.UpdateTime(time);

        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            gameOver = false;
            time = 0;
            totalCrashes = 0;
            
            SceneManager.LoadScene("GameOver");
            return;
        }
        
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);

        time--;
        _uiManager.UpdateTime(time);
        if (time <= 0)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            StartCoroutine(Timer());
        }

    }
}
