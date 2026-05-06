using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class SMP3TM3 : MonoBehaviour
{
    public ObjectActivator arrowActivator;
    public M1TooltipActivator tooltipActivator;

    public GameObject KeySnapPointObject;
    public GameObject SphereKeyOnLaserChecker;
    public StepWiseHighlighter HighlightSphereKeyOnLaserChecker;
    public LaserMachineSnapPoint laserMachineSnapPoint;
    public LaserMachine laserMachine;

    public XRGrabInteractable NGKeyInLaserGrab;
    public StepWiseHighlighter HighlightNGKeyFromLaser;
    public GameObject NGdrawer1ScriptObject;
    public GameObject NgSnapPointObject;
    public NGDrawer3P3 nGDrawer;
    public P3NG3SnapPoint p3NG3SnapPoint;

    public GameObject GoodKeyOnPunching;
    public StepWiseHighlighter HighlightGoodKeyOnPunching;
    public GameObject LaserKeySnapPointObject2;
    public LaserMachineSnapPoint2 laserMachineSnapPoint2;
    public XRGrabInteractable GoodKeyInLaserGrab;
    public StepWiseHighlighter HighlightGoodKeyFromLaser;

    public GameObject FinalTraySnapPointObject;
    public GameObject SphereFinalKeyOnTray;
    public StepWiseHighlighter HighlightSphereFinalKeyOnTray;
    public FinalTraySnapPoint finalTraySnapPoint;

    [Header("UI")]
    public GameObject ButtonCheck;
    public GameObject ButtonNG1;
    public GameObject ButtonOK2;
    public GameObject ButtonNG3;
    public GameObject ButtonNG5;
    public GameObject ButtonNG6;
    public GameObject BackCheckButton;
    public GameObject BackOkButton;
    public GameObject BackNGButton;
    [Space]
    public GameObject ButtonOK1;
    public GameObject ButtonOK3;
    public GameObject ButtonOK4;
    public GameObject ButtonOK5;
    public GameObject ButtonOK6;
    public GameObject CongratsMessage;
    [Header(" Level ")]
    public TMP_Text subTitletxt;

    private int LaserCount = 0;


    public enum TrainingStep
    {
        None,
        NGKeyFromLaserGrabbed,
        GoodKeyFromDoorGrabbed,
        KeyFromLaserGrabbed,

    }

    public TrainingStep currentStep = TrainingStep.None;

    void Start()
    {
        arrowActivator.ActivateObject(27);
        KeySnapPointObject.SetActive(true);
        SphereKeyOnLaserChecker.SetActive(true);
        HighlightSphereKeyOnLaserChecker.Highlight();
        laserMachineSnapPoint.KeySnapped += KeySnappedToLaser;
        laserMachine.LaserMachineDone += OnLaserDoneDynamic;
        nGDrawer.onReachedDesired += NGdrawerOpened;
        p3NG3SnapPoint.OnObjectActivated += NGKeyFromLaserSnappedToNGBox;
        nGDrawer.onReachedOriginal += NGdrawerClosed;
        laserMachineSnapPoint2.KeySnapped += GoodKeySnappedToLaser;
        finalTraySnapPoint.FinalKeySnapped += FinalKeySnappedToTray;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 106, subTitletxt); // Now, Go to Sixth stage which is Immobi communication checker. Place Transmitter on the jig as highlighted
        }
    }

    private void OnLaserDoneDynamic()
    {
        LaserCount++;

        Debug.Log($"Drawer opened {LaserCount} times");

        switch (LaserCount)
        {
            case 1:
                LaseringDone();
                break;
            case 2:
                LaseringDone2();
                break;
            case 3:
                //NGdrawerClosingDone3();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }


    public void KeySnappedToLaser()
    {
        arrowActivator.DeactivateObject(27);
        SphereKeyOnLaserChecker.SetActive(false);
        laserMachine.StartProcess();
        StartCoroutine(DisplayOfDrawerOK());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 107, subTitletxt); //  Wait for the Result on monitor screen
        }
    }

    public IEnumerator DisplayOfDrawerOK()
    {
        BackCheckButton.SetActive(true);
        ButtonCheck.SetActive(true);
        yield return new WaitForSeconds(3);
        ButtonNG1.SetActive(true);
        ButtonOK2.SetActive(true);
        ButtonNG3.SetActive(true);
        ButtonNG5.SetActive(true);
        ButtonNG6.SetActive(true);
        ButtonCheck.SetActive(false);
        BackCheckButton.SetActive(false);
        BackNGButton.SetActive(true);
    }
    public void LaseringDone()
    {
        LaserMachineCompleted();
    }
    public void LaserMachineCompleted()
    {
        arrowActivator.ActivateObject(27);
        NGKeyInLaserGrab.enabled = true;
        HighlightNGKeyFromLaser.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 108, subTitletxt); //  Pick Transmitter from Immobi communication checker
        }

    }
    public void NGKeyGrabbedFromLaser()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.NGKeyFromLaserGrabbed;
        arrowActivator.DeactivateObject(27);
        tooltipActivator.ActivateObject(19);
        arrowActivator.ActivateObject(28);
        NGdrawer1ScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 109, subTitletxt); //It is a NG child part so put this Case Upper in the highlighted NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(5, 110, subTitletxt, 4.5f)); //Open the NG box 
        }
    }    


    public void NGdrawerOpened()
    {
        tooltipActivator.DeactivateObject(19);
        arrowActivator.DeactivateObject(28);
        arrowActivator.ActivateObject(29);
        NgSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 111, subTitletxt); // Place NG Transmitter in the NG box
        }
    }
    public void NGKeyFromLaserSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(29);
        tooltipActivator.ActivateObject(20);
        nGDrawer.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 112, subTitletxt); // Close the NG box
        }
    }

    public void NGdrawerClosed()
    {
        NGdrawer1ScriptObject.SetActive(false);
        NgSnapPointObject.SetActive(false);
        arrowActivator.ActivateObject(26);
        GoodKeyOnPunching.SetActive(true);
        HighlightGoodKeyOnPunching.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 113, subTitletxt); //Go to stage five which is Function Checker and pick another Transmitter  
        }
    }

    public void GoodKeyFromDoorGrabbed()
    {
        if (currentStep != TrainingStep.NGKeyFromLaserGrabbed)
            return;

        currentStep = TrainingStep.GoodKeyFromDoorGrabbed;
        arrowActivator.DeactivateObject(26);
        arrowActivator.ActivateObject(27);
        LaserKeySnapPointObject2.SetActive(true);
        SphereKeyOnLaserChecker.SetActive(true);
        HighlightSphereKeyOnLaserChecker.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 114, subTitletxt); // Now, Go to Sixth stage which is Immobi communication checker. Place Transmitter on the jig as highlighted
        }
    }
    public void GoodKeySnappedToLaser()
    {
        arrowActivator.DeactivateObject(27);
        SphereKeyOnLaserChecker.SetActive(false);
        laserMachine.StartProcess();
        StartCoroutine(DisplayOfDrawerNG());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 115, subTitletxt); // Wait for the Result on monitor screen
        }

    }
    public IEnumerator DisplayOfDrawerNG()
    {
        ButtonNG1.SetActive(false);
        ButtonOK2.SetActive(false);
        ButtonNG3.SetActive(false);
        ButtonNG5.SetActive(false);
        ButtonNG6.SetActive(false);
        BackNGButton.SetActive(false);
        ButtonCheck.SetActive(true);
        BackCheckButton.SetActive(true);
        yield return new WaitForSeconds(3);
        ButtonOK1.SetActive(true);
        ButtonOK3.SetActive(true);
        ButtonOK4.SetActive(true);
        ButtonOK5.SetActive(true);
        ButtonOK6.SetActive(true);
        ButtonCheck.SetActive(false);
        BackCheckButton.SetActive(false);
        BackOkButton.SetActive(true);
    }
    public void LaseringDone2()
    {
        LaserMachineCompleted2();
    }

    public void LaserMachineCompleted2()
    {

        arrowActivator.ActivateObject(27);
        GoodKeyInLaserGrab.enabled = true;
        HighlightGoodKeyFromLaser.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 116, subTitletxt); // Pick Transmitter from Immobi communication checker
        }

    }
    public void GoodKeyGrabbedFromLaser()
    {
        if (currentStep != TrainingStep.GoodKeyFromDoorGrabbed)
            return;

        currentStep = TrainingStep.KeyFromLaserGrabbed;
        arrowActivator.DeactivateObject(27);
        arrowActivator.ActivateObject(30);
        FinalTraySnapPointObject.SetActive(true);
        SphereFinalKeyOnTray.SetActive(true);
        HighlightSphereFinalKeyOnTray.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 117, subTitletxt); //Now, Go to Last stage which is Packing. Place Transmitter in the tray as highlighted
        }
    }
    public void FinalKeySnappedToTray()
    {
        arrowActivator.DeactivateObject(30);
        SphereFinalKeyOnTray.SetActive(false);
        CongratsMessage.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 118, subTitletxt); // Congratulations!
        }
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

  

