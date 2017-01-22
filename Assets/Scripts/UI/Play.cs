using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public GameObject mainMenu;

    public void Begin()
    {
        mainMenu.SetActive(false);
    }
}