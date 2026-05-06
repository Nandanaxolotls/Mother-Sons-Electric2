using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SMP1M5 : MonoBehaviour
{
    public ObjectActivator arrowActivator;
    public M1TooltipActivator tooltipActivator;

    public GameObject SphereObjectMainCoverOnBox;
    public GameObject SnapPointObjectMainCoverToBox;
    public UpperToBlackBox upperToBlackBox;
    public GameObject GrabbingHandleScriptObject;
    public BoxHandle boxHandle;
    public ComputerDisplay2 computerDisplay2;
    public XRGrabInteractable WireEndGrab;
    public StepWiseHighlighter HighlightWireEnd;
    public GameObject ScriptObjectWireSnapPoint;
    public GameObject SphereObjectWirePoint;
    public WireSnapping wireSnapping;
    public Door2 door2;
    public GameObject DisplayCanvas;
    public XRGrabInteractable RemoveWireEndGrab;
    public StepWiseHighlighter HighlightRemoveWireEnd;
    public GameObject ScriptObjectRemoveWireSnapPoint;
    public GameObject SphereObjectRemovedWirePoint;
    public WireSnapping2 wireSnapping2;
    public XRGrabInteractable GrabMainCoverFromBox;
    [Header(" Level ")]
    public TMP_Text subTitletxt;
    private int HandleClosedCount = 0;
    private int OnDoorClosedCount = 0;
    public enum TrainingStep
    {
        None,
        WireGrabbed,
    }

    public TrainingStep currentStep = TrainingStep.None;

    void Start()
    {
        arrowActivator.ActivateObject(23);
        SphereObjectMainCoverOnBox.SetActive(true);
        SnapPointObjectMainCoverToBox.SetActive(true);
        upperToBlackBox.CoversnappedToBlackBox += MainCoverSnappedToBox;
        computerDisplay2.onProcessCompleted += DisplayShowingDone;
        boxHandle.onReachedDesired += OnHandleHoldedDynamic;
        wireSnapping.WireSnapped += WireSnapped;
        door2.Door2ReachedDesired += OnDoorClosedDynamic;
        door2.Door2ReachedOriginal += DoorOpened;
        boxHandle.onReachedOriginal += HandleReleased;
        wireSnapping2.WireRemoved += WireRemoved;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1,107, subTitletxt); //Go to next stage which is function checker and place it on the jig as highlighted
        }


    }

    private void OnHandleHoldedDynamic()
    {
        HandleClosedCount++;

        Debug.Log($"Drawer opened {HandleClosedCount} times");

        switch (HandleClosedCount)
        {
            case 1:
                HandleHoldingDone();
                break;
            case 2:
                //NGBoxOpeningDone2();
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
        OnDoorClosedCount++;

        Debug.Log($"Drawer opened {OnDoorClosedCount} times");

        switch (OnDoorClosedCount)
        {
            case 1:
                DoorClosingDone();
                break;
            case 2:
                //NGBoxOpeningDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    public void MainCoverSnappedToBox()
    {
        arrowActivator.DeactivateObject(23);
        SphereObjectMainCoverOnBox.SetActive(false);
        GrabbingHandleScriptObject.SetActive(true);
        tooltipActivator.ActivateObject(21);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 108, subTitletxt); // Close the toggle clamp

        }
    }
    public void HandleHoldingDone()
    {
        HandleHolded();
    }
    public void HandleHolded()
    {
        tooltipActivator.DeactivateObject(21);
        tooltipActivator.ActivateObject(22);
        WireEndGrab.enabled = true;
        HighlightWireEnd.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 109, subTitletxt); // Now grab the plug
        }
    }
    public void OnWireGrabbed()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.WireGrabbed;
        tooltipActivator.DeactivateObject(22);
        ScriptObjectWireSnapPoint.SetActive(true);
        SphereObjectWirePoint.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 110, subTitletxt); //Securely connect it to the highlighted port of the antenna sub assembly
        }

    }
    public void WireSnapped()
    {
        SphereObjectWirePoint.SetActive(false);
        tooltipActivator.ActivateObject(23);
        door2.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 111, subTitletxt); //Close the door of function checker using right hand
        }
    }
    public void DoorClosingDone()
    {
        DoorClosed();
    }
    public void DoorClosed()
    {
        tooltipActivator.DeactivateObject(23);
        tooltipActivator.ActivateObject(24);
        DisplayCanvas.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 112, subTitletxt); //Click the start button to start the process and Wait for the Result on monitor screen
        }
    }
    public void DisplayShowingDone()
    {
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 113, subTitletxt); // Open the door of function checker using right hand
        }
    }
    public void DoorOpened()
    {
        tooltipActivator.DeactivateObject(25);
        tooltipActivator.ActivateObject(26);
        boxHandle.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 114, subTitletxt); // Open the toggle clamp
        }
    }
    public void HandleReleased()
    {
        tooltipActivator.DeactivateObject(26);
        tooltipActivator.ActivateObject(27);
        RemoveWireEndGrab.enabled = true;
        HighlightRemoveWireEnd.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 115, subTitletxt); // Now disconnect wire from port
        }
    }
    public void RemovingWireGrabbed()
    {
        tooltipActivator.DeactivateObject(27);
        ScriptObjectRemoveWireSnapPoint.SetActive(true);
        SphereObjectRemovedWirePoint.SetActive(true);
    }
    public void WireRemoved()
    {
        SphereObjectRemovedWirePoint.SetActive(false);
        GrabMainCoverFromBox.enabled = true;
        arrowActivator.ActivateObject(23);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 116, subTitletxt); //Pick antenna sub assembly from Function checker jig
        }

    }
    public void MainCoverGrabbedFromBox()
    {
        arrowActivator.DeactivateObject(23);

    }
}
