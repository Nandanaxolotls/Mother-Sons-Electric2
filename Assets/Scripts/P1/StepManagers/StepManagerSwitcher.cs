using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
   
}
