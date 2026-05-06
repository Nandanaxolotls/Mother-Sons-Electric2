using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;
using UnityEngine.XR.Interaction.Toolkit;

public class GreenButtonP2Test : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject ButtonNG;
    [Header("HMI screen")]
    public GameObject PanelDefault;
    public GameObject PanelFirst;
    public GameObject PanelSecond;

    [Header("Input")]
    public InputActionProperty selectAction;
    private bool isHovered = false;
    private bool doorclosed = false;
    private bool lastGood = false;
    private bool lastNG = false;
    public event System.Action<string> CameraChecked;

    void Start()
    {
       
    }
    public void EnableDoor(bool isGood, bool isNG)
    {
        // store result
        lastGood = isGood;
        lastNG = isNG;

        doorclosed = true;
        Canvas.SetActive(true);
    }
    public void OnHoverEntered(HoverEnterEventArgs args) => isHovered = true;
    public void OnHoverExited(HoverExitEventArgs args) => isHovered = false;

    void Update()
    {
        if (doorclosed && isHovered && selectAction.action.WasPressedThisFrame())
        {
            StopAllCoroutines();

            if (lastGood)
                StartCoroutine(Displaying());
            else if (lastNG)
                StartCoroutine(DisplayingNG());
        }
    }
    public void OnFrontCoverResult(bool isGood, bool isNG)
    {
        Canvas.SetActive(true);   // Show canvas always

        StopAllCoroutines();      // Prevent overlapping UI

        if (isGood)
            StartCoroutine(Displaying());   // Good flow
        else if (isNG)
            StartCoroutine(DisplayingNG()); // NG flow
    }


    public IEnumerator Displaying()
    {
        Button2.SetActive(false);
        ButtonNG.SetActive(false);
        Button1.SetActive(true);
        PanelDefault.SetActive(false);
        PanelSecond.SetActive(false);
        PanelFirst.SetActive(true);
        yield return new WaitForSeconds(3f);
        Button1.SetActive(true);
        Button2.SetActive(true);
        PanelFirst.SetActive(false);
        PanelSecond.SetActive(true);
        CameraChecked?.Invoke("Good");
    }
    public IEnumerator DisplayingNG()
    {
        Button2.SetActive(false);
        Button1.SetActive(true);
        PanelDefault.SetActive(false);
        PanelSecond.SetActive(false);
        PanelFirst.SetActive(true);
        yield return new WaitForSeconds(3f);
        PanelFirst.SetActive(false);
        PanelSecond.SetActive(true);
        Button1.SetActive(true);
        ButtonNG.SetActive(true);
        CameraChecked?.Invoke("Defect");
    }

}
