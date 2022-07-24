using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ContinueGame() {
        if(!PlayerPrefs.HasKey("minigames finished")) {
            LoadNewGame();
            return;
        }
        int a = PlayerPrefs.GetInt("minigames finished");
        switch(a) {
            case 1:
                SceneManager.LoadScene("Chap2");
                break;
            case 2:
                SceneManager.LoadScene("Chap3");
                break;
            case 3:
                SceneManager.LoadScene("End1");
                break;
            case 4:
                SceneManager.LoadScene("End2");
                break;
            default:
                SceneManager.LoadScene("Chap1");
                break;
        }
    }

    public void LoadNewGame() {
        SceneManager.LoadScene("Chap1");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
