using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject optionsMenu;
    [SerializeField]
    private GameObject audioMenu;
    [SerializeField]
    private GameObject journal;
    [SerializeField]
    private GameObject scroll;
    [SerializeField]
    private GameObject logsMenu;
    [SerializeField]
    private GameObject terminalsMenu;
    [SerializeField]
    private GameObject itemsMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        audioMenu.SetActive(false);
        journal.SetActive(false);
        scroll.SetActive(false);
        logsMenu.SetActive(false);
        terminalsMenu.SetActive(false);
        itemsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void Back()
    {
        if (audioMenu.activeSelf == true)
        {
            audioMenu.SetActive(false);
        }
        else if(scroll.activeSelf == true)
        {
            itemsMenu.SetActive(false);
            logsMenu.SetActive(false);
            terminalsMenu.SetActive(false);
            scroll.SetActive(false);
            journal.SetActive(true);
        }
        else
        {
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
            journal.SetActive(false);
        }
    }
    public void Audio()
    {
        audioMenu.SetActive(true);
    }
    public void Journal()
    {
        journal.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void Logs()
    {
        scroll.SetActive(true);
        logsMenu.SetActive(true);
        journal.SetActive(false);
    }
    public void Terminals()
    {
        scroll.SetActive(true);
        terminalsMenu.SetActive(true);
        journal.SetActive(false);
    }
    public void Items()
    {
        scroll.SetActive(true);
        itemsMenu.SetActive(true);
        journal.SetActive(false);
    }
}
