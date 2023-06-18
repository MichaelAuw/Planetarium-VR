using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonOnClick : MonoBehaviour
{   

    public GameObject MainMenu;
    public GameObject About;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void returnButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void startButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }

    public void aboutButtonClicked()
    {
        MainMenu.SetActive(false);
        About.SetActive(true);
    }

    public void returnAboutButtonClicked()
    {
        MainMenu.SetActive(true);
        About.SetActive(false);
    }

    public void exitButtonClicked()
    {
        Application.Quit();
    }
}
