using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Image startButton;
    public Image quitButton;
    public Image selectPointer;

    public Transform playerPosition;
    public Transform cameraPosition;

    private Image selected;

    // Start is called before the first frame update
    void Start()
    {
        selected = startButton;
        PointerPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            selected = quitButton;
            PointerPosition();
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            selected = startButton;
            PointerPosition();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            selected.GetComponent<MenuButtonUI>().OnClick();
        }

    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void StartGame()
    {
        //Start the game
        Debug.Log("Start Game");
        Destroy(gameObject);
    }

    public void PointerPosition()
    {
        selectPointer.transform.position = selected.transform.position + new Vector3(-2f, 0, 0);
    }

    public IEnumerator MoveCamera()
    {
        for(float t = 0.0f; t < 1.0f; t += Time.deltaTime * 1.0f)
        {
            //Move the camera

            yield return null;
        }
    }

}
