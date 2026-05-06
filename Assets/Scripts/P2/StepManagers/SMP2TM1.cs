using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SMP2TM1 : MonoBehaviour
{
    public AnimatorChanger changer;
    public AnimatorChanger changer2;

    public ObjectActivator arrowActivator;
    public M1TooltipActivator tooltipActivator;
    [Header("Circuit assembly terminal missing")]
    public StepWiseHighlighter TerminalMissingChip;
    public NGDrawer1P2 NgDrawer1;
    public GameObject NgSnapPointObject;
    public P2NG1SnapPoint p2NG1SnapPoint;
    [Header("Chip Checked NG In Machine")]
    public StepWiseHighlighter HighlightNGMachineCheckChip;
    public XRGrabInteractable GrabNGMachineCheckChip;
    public GameObject DrawerScriptObject;
    public GameObject HandleScriptObject;
    public GameObject ChipSnapPointObjectOnDrawer;
    public GameObject SphereChipInDrawer;
    public StepWiseHighlighter HighlightChipInDrawer;
    public ChipToDrawerSnapPoint chipToDrawerSnapPoint;
    public DrawerP2Elextric drawerDoor;
    public DrawerHandleP2Elextric HandleDoor;
    public XRGrabInteractable GrabNGChipFromDrawer;
    [Header("Good Chip From Tray")]
    public StepWiseHighlighter HighlightGoodChipOfTray;
    public XRGrabInteractable GrabGoodChipFromTray;
    public GameObject ChipSnapPointObjectOnDrawer2;
    public GoodChipToDrawerSnapPoint goodChipToDrawerSnapPoint;
    public XRGrabInteractable GrabOKChipFromDrawer;


    [Header("Drawer Display UI")]
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3OK;
    [Header(" Level ")]
    public TMP_Text subTitletxt;

    private int NGOpenCount = 0;
    private int NGCloseCount = 0;
    private int NgSnapCount = 0;
    private int DrawerCloseCount = 0;
    private int DrawerOpenCount = 0;
    private int HandleOpenCount = 0;
    private int HandleCloseCount = 0;
    public enum TrainingStep
    {
        None,
        NGChipGrabbed,
        NGChipGrabbed2,
        NGChipGrabbed3,
        GoodChipGrabbed,

    }

    public TrainingStep currentStep = TrainingStep.None;

    void Start()
    {
        TerminalMissingChip.Highlight();
        NgDrawer1.onReachedDesired += OnNGDrawerOpenedDynamic;
        p2NG1SnapPoint.OnObjectActivated += OnDefectSnappedToNGDynamic;
        NgDrawer1.onReachedOriginal += OnNGDrawerClosedDynamic;
        chipToDrawerSnapPoint.Chipsnapped += NGChipSnappedToDrawer;
        drawerDoor.onReachedDesired += OnDrawerClosedDynamic;
        HandleDoor.onReachedDesired += OnDrawerHandleClosedDynamic;
        HandleDoor.onReachedOriginal += OnDrawerHandleOpenedDynamic;
        drawerDoor.onReachedOriginal += OnDrawerOpenedDynamic;
        goodChipToDrawerSnapPoint.Chipsnapped += GoodChipSnappedToDrawer;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 0, subTitletxt); //Welcome to the Remecon Line simulation tutorial
            StartCoroutine(SoundManager.instance.PlayDelayedSound(3, 1, subTitletxt, 3f)); // Go to first stage which is LF Auto Tuning and Pick circuit assembly from tray using left hand
        }
    }
    private void OnNGDrawerOpenedDynamic()
    {
        NGOpenCount++;

        Debug.Log($"Drawer opened {NGOpenCount} times");

        switch (NGOpenCount)
        {
            case 1:
                NGdrawerOpeningDone();
                break;
            case 2:
                NGdrawerOpeningDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnNGDrawerClosedDynamic()
    {
        NGCloseCount++;

        Debug.Log($"Drawer opened {NGCloseCount} times");

        switch (NGCloseCount)
        {
            case 1:
                NGdrawerClosingDone();
                break;
            case 2:
                NGdrawerClosingDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnDefectSnappedToNGDynamic(GameObject obj)
    {
        NgSnapCount++;
        Debug.Log($"[{NgSnapCount}] Received event: {obj.name} just activated!");

        switch (NgSnapCount)
        {
            case 1:
                ChipTerminalMissingSnappedToNGBox(obj);
                break;

            case 2:
                MachineNGChipSnappedToNGBox(obj);
                break;

            case 3:
                //PinBentAfterPunching(obj);
                break;

            default:
                Debug.Log("Additional activations beyond the third.");
                break;
        }
    }
    private void OnDrawerClosedDynamic()
    {
        DrawerCloseCount++;

        Debug.Log($"Drawer opened {DrawerCloseCount} times");

        switch (DrawerCloseCount)
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

    private void OnDrawerOpenedDynamic()
    {
        DrawerOpenCount++;

        Debug.Log($"Drawer opened {DrawerOpenCount} times");

        switch (DrawerOpenCount)
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
    private void OnDrawerHandleOpenedDynamic()
    {
        HandleOpenCount++;

        Debug.Log($"Drawer opened {HandleOpenCount} times");

        switch (HandleOpenCount)
        {
            case 1:
                HandleOpeningDone();
                break;
            case 2:
                HandleOpeningDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnDrawerHandleClosedDynamic()
    {
        HandleCloseCount++;

        Debug.Log($"Drawer opened {HandleCloseCount} times");

        switch (HandleCloseCount)
        {
            case 1:
                HandleClosingDone();
                break;
            case 2:
                HandleClosingDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    public void NGChipGrabbedFromTray()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.NGChipGrabbed;
        arrowActivator.DeactivateObject(0);
        tooltipActivator.ActivateObject(0);
        tooltipActivator.ActivateObject(1);
        arrowActivator.ActivateObject(1);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 2, subTitletxt); //It is a NG child part so put this Circuit Assembly in the NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(3, 3, subTitletxt, 4.2f)); // Open the NG box
        }
    }
    private void NGdrawerOpeningDone()
    {
        NGdrawerOpened();
    }
    public void NGdrawerOpened()
    {
        tooltipActivator.DeactivateObject(1);
        arrowActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(2);
        NgSnapPointObject.SetActive(true);
        NgDrawer1.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 4, subTitletxt); //Place NG Circuit Assembly in the NG box 
        }
    }
    public void ChipTerminalMissingSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(2);
        tooltipActivator.ActivateObject(2);
        NgDrawer1.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 5, subTitletxt); // Close the NG box
        }
    }
    private void NGdrawerClosingDone()
    {
        NGdrawerClosed();
    }
    public void NGdrawerClosed()
    {
        arrowActivator.ActivateObject(3);
        HighlightNGMachineCheckChip.Highlight();
        GrabNGMachineCheckChip.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 6, subTitletxt); // Now take another Circuit Assembly from tray using left hand

        }
    }
    public void NGChip2GrabbedFromTray()
    {
        if (currentStep != TrainingStep.NGChipGrabbed)
            return;

        currentStep = TrainingStep.NGChipGrabbed2;
        arrowActivator.DeactivateObject(3);
        tooltipActivator.ActivateObject(39);
       // tooltipActivator.ActivateObject(3);//
        arrowActivator.ActivateObject(4);
        ChipSnapPointObjectOnDrawer.SetActive(true);
        SphereChipInDrawer.SetActive(true);
        HighlightChipInDrawer.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 7, subTitletxt); //Place circuit assembly in the LF Auto Tuning machine same as highlighted
        }
    }
    public void NGChipSnappedToDrawer()
    {
        tooltipActivator.DeactivateObject(39);

        SphereChipInDrawer.SetActive(false);
        arrowActivator.DeactivateObject(4);
        DrawerScriptObject.SetActive(true);
        tooltipActivator.ActivateObject(4);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 8, subTitletxt); //Close the door
        }
    }
    private void DoorClosingDone()
    {
        DoorClosed();
    }
    public void DoorClosed()
    {
        tooltipActivator.DeactivateObject(4);
        tooltipActivator.ActivateObject(41);
        DrawerScriptObject.SetActive(false);
        HandleScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 9, subTitletxt); //Lock the door
        }

    }
    public void HandleClosingDone()
    {
        HandleLocked();
    }
    public void HandleLocked()
    {
        tooltipActivator.DeactivateObject(41);
        StartCoroutine(DoorDisplay());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 10, subTitletxt); //Wait for the Result on monitor screen
        }
    }

    public IEnumerator DoorDisplay()
    {
        Button1.SetActive(true);
        yield return new WaitForSeconds(4);
        Button1.SetActive(false);
        Button2.SetActive(true); 
        HandleDoor.Unlock();
        tooltipActivator.ActivateObject(42);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 11, subTitletxt); // Unlock the door
        }
    }

    public void HandleOpeningDone()
    {
        HandleUnlocked();   
    }
    public void HandleUnlocked()
    {
        tooltipActivator.DeactivateObject(42);
        tooltipActivator.ActivateObject(5);
        drawerDoor.Unlock();
        DrawerScriptObject.SetActive(true);
        HandleScriptObject.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 12, subTitletxt); // Open the door
        }
    }
    private void DoorOpeningDone()
    {
        DoorOpened();
    }
    public void DoorOpened()
    {
        tooltipActivator.DeactivateObject(5);
        arrowActivator.ActivateObject(4);
        GrabNGChipFromDrawer.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 13, subTitletxt); //Pick the Circuit Assembly from the LF Auto Tuning 
        }
    }
    public void GrabbedNGChipFromDrawer()
    {
        if (currentStep != TrainingStep.NGChipGrabbed2)
            return;

        currentStep = TrainingStep.NGChipGrabbed3;
        arrowActivator.DeactivateObject(4);
        tooltipActivator.ActivateObject(1);
        arrowActivator.ActivateObject(1);
        DrawerScriptObject.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 14, subTitletxt); // It is a NG child part so put this Circuit Assembly in the NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(3,15, subTitletxt, 4.2f)); // Open the NG box
        }

    }
    private void NGdrawerOpeningDone2()
    {
        NGdrawerOpened2();
    }
    public void NGdrawerOpened2()
    {
        tooltipActivator.DeactivateObject(1);
        arrowActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(2);
        NgSnapPointObject.SetActive(true);
        NgDrawer1.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 16, subTitletxt); // Place NG Circuit Assembly in the NG box
        }
    }
    public void MachineNGChipSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(2);
        tooltipActivator.ActivateObject(2);
        NgDrawer1.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 17, subTitletxt); //Close the NG box
        }
    }
    private void NGdrawerClosingDone2()
    {
        NGdrawerClosed2();
    }
    public void NGdrawerClosed2()
    {
        arrowActivator.ActivateObject(5);
        HighlightGoodChipOfTray.Highlight();
        GrabGoodChipFromTray.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 18, subTitletxt); //Now take another Circuit Assembly from tray using left hand
        }
    }
    public void GoodChipGrabbedFromTray()
    {
        if (currentStep != TrainingStep.NGChipGrabbed3)
            return;

        currentStep = TrainingStep.GoodChipGrabbed;
        arrowActivator.DeactivateObject(5);
        tooltipActivator.ActivateObject(39);
        arrowActivator.ActivateObject(4);
        ChipSnapPointObjectOnDrawer2.SetActive(true);
        SphereChipInDrawer.SetActive(true);
        HighlightChipInDrawer.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 19, subTitletxt); //Place Circuit assembly in the LF Auto Tuning machine same as highlighted
        }
    }
    public void GoodChipSnappedToDrawer()
    {
        tooltipActivator.DeactivateObject(39);
        DrawerScriptObject.SetActive(true);
        arrowActivator.DeactivateObject(4);
        SphereChipInDrawer.SetActive(false);
        tooltipActivator.ActivateObject(4);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 20, subTitletxt); //Close the door
        }
    }
    private void DoorClosingDone2()
    {
        DoorClosed2();
    }
    public void DoorClosed2()
    {
        tooltipActivator.DeactivateObject(4);
        tooltipActivator.ActivateObject(41);
        DrawerScriptObject.SetActive(false);
        HandleScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 21, subTitletxt); //Lock the door
        }

    }
    public void HandleClosingDone2()
    {
        HandleLocked2();
    }
    public void HandleLocked2()
    {
        tooltipActivator.DeactivateObject(41);
        StartCoroutine(DoorDisplay2());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 22, subTitletxt); //Wait for the Result on monitor screen
        }
    }

    public IEnumerator DoorDisplay2()
    {
        Button2.SetActive(false);
        Button1.SetActive(true);
        yield return new WaitForSeconds(4);
        Button1.SetActive(false);
        Button3OK.SetActive(true);
        HandleDoor.Unlock();
        tooltipActivator.ActivateObject(42);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 23, subTitletxt); //Unlock the door
        }
    }
   
    public void HandleOpeningDone2()
    {
        HandleUnlocked2();
    }
    public void HandleUnlocked2()
    {
        tooltipActivator.DeactivateObject(42);
        tooltipActivator.ActivateObject(5);
        drawerDoor.Unlock();
        DrawerScriptObject.SetActive(true);
        HandleScriptObject.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 24, subTitletxt); //Open the door
        }
    }

private void DoorOpeningDone2()
    {
        DoorOpened2();
    }
    public void DoorOpened2()
    {
        tooltipActivator.DeactivateObject(5);
        arrowActivator.ActivateObject(4);
        GrabOKChipFromDrawer.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 25, subTitletxt); //Pick the Circuit Assembly from the LF Auto Tuning 
        }
    }
    public void GrabbedGoodChipFromDrawer()
    {
        arrowActivator.DeactivateObject(4);

    }

}

