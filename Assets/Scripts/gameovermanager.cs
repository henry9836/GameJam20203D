using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameovermanager : MonoBehaviour
{
    public bool gameover = false;
    public float deathdistance = 60.0f;
    public float screenshotThreshold = 0.01f;
    public GameObject player;
    public GameObject canvas;
    private float fixedDeltaTime;

    void Awake()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = (1.0f / 60.0f);
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, Vector3.zero) >= deathdistance && gameover == false)
        {
            player.transform.GetChild(0).GetComponent<MouseLook>().enabled = false;
            gameover = true;
            GameObject.Find("Canvas").gameObject.SetActive(false);
            canvas.gameObject.SetActive(true);
            canvas.transform.GetChild(0).GetComponent<Text>().text = "Score: " + this.gameObject.GetComponent<score>().thescore.ToString("F0");

            StartCoroutine(slow());
        }
    }

    public IEnumerator slow()
    {
        for (float t = 0.0f; t < 1.0f; t += Time.unscaledDeltaTime * 0.3f)
        {
            Debug.Log(Time.timeScale);
            Time.timeScale = Mathf.Lerp(1.0f, screenshotThreshold, t);
            Time.fixedDeltaTime = .02f * Time.timeScale;

            yield return null;
        }

        //save and freeze game
        Debug.LogWarning("fddf");
        Time.timeScale = 0.0f;
        Time.fixedDeltaTime = 0.0f;

        //take screenshot
        GetComponent<GameOverEvent>().ScreenShot();

        yield return new WaitForSecondsRealtime(1.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }




}
