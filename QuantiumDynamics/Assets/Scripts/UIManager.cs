using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public void Respawn() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void Quit() {

        SceneManager.LoadScene("Menu");

    }

}
