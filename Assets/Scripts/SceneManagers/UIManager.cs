using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] TMPro.TextMeshProUGUI textLives;
    [SerializeField] TMPro.TextMeshProUGUI textTime;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int live)
    {
        textLives.text = "Vidas: " + live.ToString();
    }

    public void UpdateTime(int time)
    {
        textTime.text = time.ToString() + " seg";
    }
}
