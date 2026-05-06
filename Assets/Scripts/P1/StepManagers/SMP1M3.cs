using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SMP1M3 : MonoBehaviour
{
    public ObjectActivator arrowActivator;
    public M1TooltipActivator tooltipActivator;

    [Header("NG Cover")]
    public ComputerDisplayNG computerDisplayNG;
    public ComputerDisplay computerDisplay;

    public GameObject CoverInBoxSnapPointObject;
    public GameObject CoverOutBoxSphereObject;
    public StepWiseHighlighter HighlightCoverOutBoxSphereObject;
    public CoverToBackBox coverToBackBox;
    public GameObject HolderScriptObject;
    public HolderMachine holderMachine;
    public GameObject DoorScriptObject;
    public Door1 door1;

    public GameObject DisplayCanvasNG;
    public XRGrabInteractable GrabNGCoverFromBox;
    public GameObject NGboxSnapPointobject;
    public NGdrawer nGdrawer;
    public NG3SnapPoint nG3SnapPoint;

    [Header("Good Cover")]
    public GameObject GoodCOverActivateOnSoldering;
    public GameObject CoverInBoxSnapPointObject2;
    public CoverToBlackBox2 coverToBackBox2;
    public GameObject DisplayCanvasOK;
    public XRGrabInteractable GrabGoodCoverFromBox;
    [Header(" Level ")]
    public TMP_Text subTitletxt;
    public enum TrainingStep
    {
        None,
        NGCoverGrabbed,
        GoodCoverFromSolderingGrabbed
        
    }

    public TrainingStep currentStep = TrainingStep.None;


    private int HoldedCount = 0;
    private int ReleasedCount = 0;
    private int doorOpenCount = 0;
    private int doorCloseCount = 0;
    private int doorDisplayCount = 0;


    void Start()
    {
        arrowActivator.ActivateObject(12);
        CoverInBoxSnapPointObject.SetActive(true);
        CoverOutBoxSphereObject.SetActive(true);
        HighlightCoverOutBoxSphereObject.Highlight();
        coverToBackBox.CoversnappedToBlackBox += CoverSnappedToBox;
        holderMachine.onReachedDesired += OnHoldedDynamic;
        door1.Door1ReachedDesired += OnDoorClosedDynamic;
        computerDisplayNG.onProcessCompleted += DoorProcessCompleted;
        computerDisplay.onProcessCompleted += DoorProcessCompleted2;
        door1.Door1ReachedOriginal += OnDoorOpenedDynamic;
        holderMachine.onReachedOriginal += OnReleasedDynamic;
        nGdrawer.onReachedDesired += NGBoxOpened;
        nG3SnapPoint.OnObjectActivated += NGdefectSnapped;
        nGdrawer.onReachedOriginal += NGBoxClosed;
        coverToBackBox2.GoodCoversnappedToBlackBox2 += GoodCoverSnappedToBox;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 58, subTitletxt); // Go to next stage which is AOI and place it on the jig as highlighted

        }
    }
    private void OnHoldedDynamic()
    {
        HoldedCount++;

        Debug.Log($"Drawer opened {HoldedCount} times");

        switch (HoldedCount)
        {
            case 1:
                CoverHoldingDone();
                break;
            case 2:
                CoverHoldingDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnReleasedDynamic()
    {
        ReleasedCount++;

        Debug.Log($"Drawer opened {ReleasedCount} times");

        switch (ReleasedCount)
        {
            case 1:
                CoverReleasingDone();
                break;
            case 2:
                CoverReleasingDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnDoorClosedDynamic()
    {
        doorCloseCount++;

        Debug.Log($"Drawer opened {doorCloseCount} times");

        switch (doorCloseCount)
        {
            case 1:
                DoorClosingDone();
                break;
            case 2:
                DoorClosingDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
   
    private void OnDoorOpenedDynamic()
    {
        doorOpenCount++;

        Debug.Log($"Drawer opened {doorOpenCount} times");

        switch (doorOpenCount)
        {
            case 1:
                DoorOpeningDone();
                break;
            case 2:
                DoorOpeningDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    public void CoverSnappedToBox()
    {
        arrowActivator.DeactivateObject(12);
        tooltipActivator.DeactivateObject(41);

        CoverOutBoxSphereObject.SetActive(false);
        tooltipActivator.ActivateObject(8);
        HolderScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 59, subTitletxt); //Close the toggle clamp
        }
    }
    private void CoverHoldingDone()
    {
        CoverHolded();
    }
    public void CoverHolded()
    {
        tooltipActivator.DeactivateObject(8);
        tooltipActivator.ActivateObject(9);
        arrowActivator.ActivateObject(13);
        DoorScriptObject.SetActive(true);
        DisplayCanvasNG.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 60, subTitletxt); //Close the door of AOI 
        }

    }
    private void DoorClosingDone()
    {
        DoorClosed();
    }
    public void DoorClosed()
    {
        tooltipActivator.ActivateObject(10);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 61, subTitletxt); //Click the start button to start the process and Wait for the Result on monitor screen
        }
    }

    public void DoorProcessCompleted()
    {
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 62, subTitletxt); //Open the door of AOI
        }
    }
    private void DoorOpeningDone()
    {
        DoorOpened();
    }
    public void DoorOpened()
    {
        tooltipActivator.DeactivateObject(11);
        holderMachine.Unlock();
        tooltipActivator.ActivateObject(12);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 63, subTitletxt); //Open the toggle clamp
        }
    }
    private void CoverReleasingDone()
    {
        CoverReleased();
    }
    public void CoverReleased()
    {
        tooltipActivator.DeactivateObject(12);
        arrowActivator.ActivateObject(14);
        GrabNGCoverFromBox.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 64, subTitletxt); //Pick antenna sub assembly from AOI jig 
        }
    }
    public void NGCoverGrabbedFromBox()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.NGCoverGrabbed;
        arrowActivator.DeactivateObject(14);
        arrowActivator.ActivateObject(1);
        tooltipActivator.ActivateObject(0);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 65, subTitletxt); //It is a NG child part so put this antenna sub assembly in the NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(1, 66, subTitletxt, 4.2f)); // Open the NG box 
        }
    }
    public void NGBoxOpened()
    {
        NGboxSnapPointobject.SetActive(true);
        tooltipActivator.DeactivateObject(0);
        arrowActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(2);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 67, subTitletxt); //Place NG antenna sub assembly in the NG box
        }
    }
    public void NGdefectSnapped(GameObject obj)
    {
        arrowActivator.DeactivateObject(2);
        tooltipActivator.ActivateObject(1);
        nGdrawer.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 68, subTitletxt); //Close the NG box
        }
    }
    public void NGBoxClosed()
    {
        tooltipActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(15);
        GoodCOverActivateOnSoldering.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 69, subTitletxt); //Now pick another final antenna sub assembly child part of stage 2 on terminal robot soldering machine using left hand
        }

    }
    public void GoodCoverGrabbedFromSoldering()
    {
        if (currentStep != TrainingStep.NGCoverGrabbed)
            return;

        currentStep = TrainingStep.GoodCoverFromSolderingGrabbed;
        arrowActivator.DeactivateObject(15);
        arrowActivator.ActivateObject(12);
        CoverInBoxSnapPointObject2.SetActive(true);
        CoverOutBoxSphereObject.SetActive(true);
        HighlightCoverOutBoxSphereObject.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 70, subTitletxt); // Go to AOI and place it on the jig as highlighted
        }
    }
    public void GoodCoverSnappedToBox()
    {
        CoverOutBoxSphereObject.SetActive(false);
        arrowActivator.DeactivateObject(12);
        tooltipActivator.ActivateObject(8);
        HolderScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 71, subTitletxt); // Close the toggle clamp
        }
    }
    private void CoverHoldingDone2()
    {
        CoverHolded2();
    }
    public void CoverHolded2()
    {
        tooltipActivator.DeactivateObject(8);
        tooltipActivator.ActivateObject(9);
        arrowActivator.ActivateObject(13);
        DoorScriptObject.SetActive(true);
        DisplayCanvasNG.SetActive(false);
        DisplayCanvasOK.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 72, subTitletxt); // Close the door of AOI 

        }
    }
    private void DoorClosingDone2()
    {
        DoorClosed2();
    }
    public void DoorClosed2()
    {
        tooltipActivator.ActivateObject(10);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 73, subTitletxt); // Click the start button to start the process and Wait for the Result on monitor screen
        }
    }

    public void DoorProcessCompleted2()
    {
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 74, subTitletxt); //Open the door of AOI
        }
    }

    private void DoorOpeningDone2()
    {
        DoorOpened2();
    }
    public void DoorOpened2()
    {
        tooltipActivator.DeactivateObject(11);
        holderMachine.Unlock();
        tooltipActivator.ActivateObject(12);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 75, subTitletxt); //Open the toggle clamp
        }
    }
    private void CoverReleasingDone2()
    {
        CoverReleased2();
    }
    public void CoverReleased2()
    {
        tooltipActivator.DeactivateObject(12);
        arrowActivator.ActivateObject(14);
        GrabGoodCoverFromBox.enabled = true;
        NGboxSnapPointobject.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 76, subTitletxt); //Pick antenna sub assembly from AOI jig
        }
    }
    public void GoodCoverGrabbedFromBox()
    {
        arrowActivator.DeactivateObject(14);
    }
}

