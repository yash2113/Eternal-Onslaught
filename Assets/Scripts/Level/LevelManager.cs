using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private bool gameActive;
    public float timer;

    public float waitToShowEndScreen = 2f;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameActive = true;
    }

    private void Update()
    {
        if(gameActive)
        {
            timer += Time.deltaTime;
            UIController.instance.UpdateTimer(timer);
        }
    }

    public void EndLevel()
    {
        gameActive = false;

        StartCoroutine(EndLevelCoroutine());
    }

    IEnumerator EndLevelCoroutine()
    {
        yield return new WaitForSeconds(waitToShowEndScreen);

        float minutes = Mathf.FloorToInt(timer / 60f);
        float seconds = Mathf.FloorToInt(timer % 60);

        UIController.instance.endTimeText.text = minutes.ToString() + " mins " + seconds.ToString("00") + " secs";
        UIController.instance.levelEndScreen.SetActive(true);
    }

}
