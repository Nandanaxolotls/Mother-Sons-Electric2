using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StepManagerSwitcher : MonoBehaviour
{

    public GameObject StepManagerM1;
    public GameObject StepManagerM2;
    public GameObject StepManagerM3;
    public GameObject StepManagerM4;
    public GameObject StepManagerM5;
    public GameObject StepManagerM6;


    public void Machine1Completed()
    {
        StepManagerM1.SetActive(false);
        StepManagerM2.SetActive(true);
    }
    public void Machine2Completed()
    {
        StepManagerM2.SetActive(false);
        StepManagerM3.SetActive(true);
    }
    public void Machine3Completed()
    {
        StepManagerM3.SetActive(false);
        StepManagerM4.SetActive(true);
    }
    public void Machine4Completed()
    {
        StepManagerM4.SetActive(false);
        StepManagerM5.SetActive(true);
    }
    public void Machine5Completed()
    {
        StepManagerM5.SetActive(false);
        StepManagerM6.SetActive(true);
    }
    public void Nextlevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

}
