using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public Animator menuAnimator;
    public Animator playerAnimator;
    public Animator cutsceneAnimator;

    public TMP_Text tutText;
    public GameObject tutWall;

    public int tutorialStage = 1;

    private bool _isPaused;

    // Start is called before the first frame update
    void Start()
    {
        tutorialStage = PlayerPrefs.GetInt("tutStage", 1);

        if (tutorialStage == 1)
        {
            cutsceneAnimator.SetBool("isCutscene", true);
            tutWall.SetActive(true);
            StartCoroutine(Tutorial(1));
        }
        else
        {
            tutWall.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialStage != 0)
        {
            if (Math.Abs(Input.GetAxisRaw("Horizontal")) > 0f)
            {
                StartCoroutine(Tutorial(4));
            }
            if (Input.GetButton("Jump"))
            {
                StartCoroutine(Tutorial(5));
            }
            else if (Input.GetButtonDown("Crouch"))
            {
                StartCoroutine(Tutorial(6));
            }
        }
        else
        {
            if (Input.GetButtonDown("Cancel")) if (!_isPaused) PauseGame(); else ResumeGame();
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

    public void PauseGame()
    {
        menuAnimator.SetBool("isClock", true);
        playerAnimator.SetTrigger("isClock");
        _isPaused = true;
    }

    public void ResumeGame()
    {
        menuAnimator.SetBool("isClock", false);
        playerAnimator.speed = 1f;

        _isPaused = false;
    }

    public void GoToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(1);
    }

    IEnumerator Tutorial(int key)
    {
        switch (tutorialStage)
        {
            case 1:
                if (key == 1)
                {
                    yield return new WaitForSeconds(4f);
                    tutorialStage = 2;
                    tutText.text = "Plusieurs obstacles se presenteront sur son chemin";
                    StartCoroutine(Tutorial(2));
                }
                break;
            case 2:
                if (key == 2)
                {
                    yield return new WaitForSeconds(4f);
                    tutorialStage = 3;
                    tutText.text = "Reussira t elle a rentrer chez elle saine et sauve";
                    StartCoroutine(Tutorial(3));
                }
                break;
            case 3:
                if (key == 3)
                {
                    yield return new WaitForSeconds(4f);
                    tutorialStage = 4;
                    tutText.text = "Appuyez sur a et d pour bouger";
                }
                break;
            case 4:
                if (key == 4)
                {
                    yield return new WaitForSeconds(0.5f);
                    tutorialStage = 5;
                    tutText.text = "Appuyez sur W pour sauter";
                }
                break;
            case 5:
                if (key == 5)
                {
                    yield return new WaitForSeconds(0.5f);
                    tutorialStage = 6;
                    tutText.text = "Appuyez sur S pour accroupir";
                }
                break;
            case 6:
                if (key == 6)
                {
                    yield return new WaitForSeconds(1.5f);
                    tutText.text = "IL EST LA";
                    yield return new WaitForSeconds(1.5f);
                    PlayerPrefs.SetInt("tutStage", 0);
                    tutorialStage = 0;
                    GetComponent<AudioSource>().Play();
                    tutWall.GetComponent<Animator>().Play("RockOut");
                    cutsceneAnimator.SetBool("isCutscene", false);
                }
                break;
        }
        
        PlayerPrefs.Save();
    }
}
