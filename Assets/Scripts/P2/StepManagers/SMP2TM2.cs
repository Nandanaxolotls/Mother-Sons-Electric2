using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SMP2TM2 : MonoBehaviour
{
    public AnimatorChanger changer;
    public AnimatorChanger changer2;
    public ObjectActivator arrowActivator;
    public M1TooltipActivator tooltipActivator;
    [Header("Chip On Chip Checker")]
    public GameObject SphereObjectChipOnChecker;
    public StepWiseHighlighter HighlightSphereChipOnChecker;
    public GameObject ScriptObjectChipOnCheckerSnapPoint;
    public ChipToChipCheckerSnapPoint chipToChipCheckerSnapPoint;
    public GameObject CheckerHandleScriptObject;
    public CheckerHandle checkerHandle;
    [Header("Back Cover Damage")]
    public StepWiseHighlighter HighlightNGBackCover;
    public XRGrabInteractable GrabNGBackCover;
    public GameObject NGbox2ScriptObject;
    public NGDrawer2P2 nGDrawer;
    public GameObject NGBoxSnapPointObject;
    public P2NG2SnapPoint p2NG2SnapPoint;
    [Header("Good Back Cover")]
    public StepWiseHighlighter HighlightGoodBackCover;
    public XRGrabInteractable GrabGoodBackCover;
    [Header("NG unlock button")]
    public StepWiseHighlighter HighlightNGUnlockButton;
    public XRGrabInteractable GrabNGUnlockButton;
    public GameObject ScriptObjectBackCoverOnTableSnapPoint;
    public BackCoverOnTable backCoverOnTable;
    [Header("Good unlock and lock button")]
    public StepWiseHighlighter HighlightBackCoverOnTable;
    public XRGrabInteractable GrabBackCoverOnTable;
    [Space]
    public StepWiseHighlighter HighlightUnlockButton;
    public XRGrabInteractable GrabUnlockButton;
    public GameObject ScriptObjectUnlockButtonSnapPoint;
    public GameObject SphereUnlockButton;
    public StepWiseHighlighter HighlightSphereUnlockButton;
    public UnlockButtonSnapPoint unlockButtonSnapPoint;
    [Space]
    public StepWiseHighlighter HighlightLockButton;
    public XRGrabInteractable GrabLockButton;
    public GameObject ScriptObjectLockButtonSnapPoint;
    public GameObject SphereLockButton;
    public StepWiseHighlighter HighlightSphereLockButton;
    public LockButtonSnapPoint lockButtonSnapPoint;
    [Space]
    public StepWiseHighlighter HighlightRubberCover;
    public XRGrabInteractable GrabRubberCover;
    public GameObject ScriptObjectRubberCoverSnapPoint;
    public GameObject SphereRubberCover;
    public StepWiseHighlighter HighlightSphereRubberCover;
    public RubberSnapPoint rubberSnapPoint;
    public GameObject RubberCheckCanvas;
    [Space]
    public StepWiseHighlighter HighlightChipOnChecker;
    public XRGrabInteractable GrabChipFromChecker;
    public GameObject ScriptObjectChipSnapPoint;
    public GameObject SphereChipOnMain;
    public StepWiseHighlighter HighlightSphereChipOnMain;
    public ChipToBackCoverSnapPoint chipToBackCoverSnapPoint;
    [Space]
    public GameObject ScriptObjectMainToPunchingSnapPoint;
    public GameObject SphereMainOnPunching;
    public StepWiseHighlighter HighlightSphereMainOnPunching;
    public PunchingMachineSnapPoint punchingMachineSnapPoint;
    public StepWiseHighlighter HighlightBatteryPlacer;
    public XRGrabInteractable GrabBatteryPlacer;
    public GameObject ScriptObjectBatteryPlacerSnapPoint;
    public GameObject SphereBatteryPlacer;
    public StepWiseHighlighter HighlightSphereBatteryPlacer;
    public BatteryCoverSnapPoint batteryCoverSnapPoint;
    public GameObject ScriptObjectPunchingHandle;
    public PunchingMachine punchingMachine;
    public StepWiseHighlighter HighlightMainAfterPunching;
    public XRGrabInteractable GrabMainFromPunching;
    [Header("Good Final")]
    public GameObject GoodMainPartOnPunching;
    public StepWiseHighlighter HighlightGoodMainAfterPunching;
    public XRGrabInteractable GrabGoodMainFromPunching;
    public StepWiseHighlighter HighlightBattery;
    public XRGrabInteractable GrabBattery;
    public GameObject TerminalCheckCanvas;
    public GameObject ScriptObjectBatterySnapPoint;
    public GameObject SphereBattery;
    public StepWiseHighlighter HighlightSphereBattery;
    public BatterySnapPoint batterySnapPoint;
    public GameObject TerminalUpwardCanvas;
    public StepManagerSwitcher stepManagerSwitcher;



    [Header("UI")]
    public GameObject Button1;
    public GameObject Button2;
    [Header(" Level ")]
    public TMP_Text subTitletxt;
    private int NGDrawerOpenCount = 0;
    private int NGSnappedCount = 0;
    private int NGDrawerClosedCount = 0;
    private int PunchingDoneCount = 0;
    public enum TrainingStep
    {
        None,
        NGBackCoverGrabbed,
        GoodBackCoverGrabbed,
        NGUnlockButtonGrabbed,
        BackCoverFromTableGrabbed,
        UnlockButtonGrabbed,
        LockButtonGrabbed,
        RubberCoverGrabbed,
        ChipFromCheckerGrabbed,
        BatteryCoverGrabbed,
        MainFromPunching,
        MainFromPunching2,
        BatteryGrabbed,

    }

    public TrainingStep currentStep = TrainingStep.None;
    void Start()
    {
        arrowActivator.ActivateObject(6);
        SphereObjectChipOnChecker.SetActive(true);
        HighlightSphereChipOnChecker.Highlight();
        ScriptObjectChipOnCheckerSnapPoint.SetActive(true);
        chipToChipCheckerSnapPoint.ChipsnappedToChecker += ChipSnappedToChecker;
        checkerHandle.onReachedDesired += CheckerClosed;
        nGDrawer.onReachedDesired += OnNGDrawerOpenedDynamic;
        p2NG2SnapPoint.OnObjectActivated += OnDefectSnappedToNGDynamic;
        nGDrawer.onReachedOriginal += OnNGDrawerClosedDynamic;
        backCoverOnTable.BackOnTableSnapped += BackCoverOnTableSnapped;
        unlockButtonSnapPoint.UnlockSnapped += UnlockButtonSnapped;
        lockButtonSnapPoint.LockSnapped += LockButtonSnapped;
        rubberSnapPoint.RubberSnapped += RubberCoverSnapped;
        checkerHandle.onReachedOriginal += CheckerOpened;
        chipToBackCoverSnapPoint.ChipsnappedToBackCover += ChipSnappedToMain;
        punchingMachineSnapPoint.CoversnappedToPunching += MainSnappedToPunching;
        batteryCoverSnapPoint.BatteryPlacerSnapped += BatteryPlacerSnappedToMain;
        punchingMachine.onReachedOriginal += OnPunchingDoneDynamic;
        batterySnapPoint.BatterySnapped += BatterySnappingDone;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 26, subTitletxt); //Now, Move to Stage 2. Align and place the Circuit Assembly onto the highlighted jig
        }
    }
    private void OnNGDrawerOpenedDynamic()
    {
        NGDrawerOpenCount++;

        Debug.Log($"Drawer opened {NGDrawerOpenCount} times");

        switch (NGDrawerOpenCount)
        {
            case 1:
                NGdrawerOpeningDone();
                break;
            case 2:
                NGdrawerOpeningDone2();
                break;
            case 3:
                NGdrawerOpeningDone3();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnDefectSnappedToNGDynamic(GameObject obj)
    {
        NGSnappedCount++;
        Debug.Log($"[{NGSnappedCount}] Received event: {obj.name} just activated!");

        switch (NGSnappedCount)
        {
            case 1:
                NGBackCoverSnappedToNGBox(obj);
                break;

            case 2:
                NGUnlockButtonSnappedToNGBox(obj);
                break;

            case 3:
                NGMainCoverSnappedToNGBox(obj);
                break;

            default:
                Debug.Log("Additional activations beyond the third.");
                break;
        }
    }
    private void OnNGDrawerClosedDynamic()
    {
        NGDrawerClosedCount++;

        Debug.Log($"Drawer opened {NGDrawerClosedCount} times");

        switch (NGDrawerClosedCount)
        {
            case 1:
                NGdrawerClosingDone();
                break;
            case 2:
                NGdrawerClosingDone2();
                break;
            case 3:
                NGdrawerClosingDone3();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    private void OnPunchingDoneDynamic()
    {
        PunchingDoneCount++;

        Debug.Log($"Drawer opened {PunchingDoneCount} times");

        switch (PunchingDoneCount)
        {
            case 1:
                PunchingProcessDone();
                break;
            case 2:
                PunchingProcessDone2();
                break;
            case 3:
               // NGdrawerOpeningDone3();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    public void ChipSnappedToChecker()
    {
        arrowActivator.DeactivateObject(6);
        SphereObjectChipOnChecker.SetActive(false);
        CheckerHandleScriptObject.SetActive(true);
        tooltipActivator.ActivateObject(7);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 27, subTitletxt); //Close the flap using right hand
        }

    }
    public void CheckerClosed()
    {
        tooltipActivator.DeactivateObject(7);
        arrowActivator.ActivateObject(7);
        HighlightNGBackCover.Highlight();
        GrabNGBackCover.enabled = true;
        StartCoroutine(DoorDisplay());
        changer.SwitchToController1();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 28, subTitletxt); //Pick Upper Case from tray using left hand
        }
    }
    public IEnumerator DoorDisplay()
    {
        Button1.SetActive(true);
        yield return new WaitForSeconds(10);
        Button1.SetActive(false);
        Button2.SetActive(true);
    }
    public void NGBackCoverGrabbed()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.NGBackCoverGrabbed;
        arrowActivator.DeactivateObject(7);
        arrowActivator.ActivateObject(8);
        tooltipActivator.ActivateObject(10);
        tooltipActivator.ActivateObject(8);
        NGbox2ScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 29, subTitletxt); //It is a NG child part so put this Upper Case in the NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(3, 30, subTitletxt, 4.2f)); // Open the NG box
        }
    }
    private void NGdrawerOpeningDone()
    {
        NGDrawerOpened();
    }
    public void NGDrawerOpened()
    {
        tooltipActivator.DeactivateObject(8);
        arrowActivator.DeactivateObject(8);
        arrowActivator.ActivateObject(9);
        NGBoxSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 31, subTitletxt); //Place NG Circuit Assembly in the NG box
        }
    }
    public void NGBackCoverSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(9);
        tooltipActivator.ActivateObject(9);
        nGDrawer.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 32, subTitletxt); // Close the NG box
        }
    }
    private void NGdrawerClosingDone()
    {
        NGDrawerClosed();
    }
    public void NGDrawerClosed()
    {
        arrowActivator.ActivateObject(10);
        HighlightGoodBackCover.Highlight();
        GrabGoodBackCover.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 33, subTitletxt); // Now take another Upper Case from tray using left hand
        }
    }
    public void GoodBackCoverGrabbed()
    {
        if (currentStep != TrainingStep.NGBackCoverGrabbed)
            return;

        currentStep = TrainingStep.GoodBackCoverGrabbed;
        tooltipActivator.ActivateObject(39);
        arrowActivator.DeactivateObject(10);
        arrowActivator.ActivateObject(11);
        HighlightNGUnlockButton.Highlight();
        GrabNGUnlockButton.enabled = true;
        changer2.SwitchToController2();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 34, subTitletxt); // Pick Switch knob unlock from tray using right hand
        }
    }
    public void NGUnlockButtonGrabbed()
    {
        if (currentStep != TrainingStep.GoodBackCoverGrabbed)
            return;

        currentStep = TrainingStep.NGUnlockButtonGrabbed;
        tooltipActivator.DeactivateObject(39);
        arrowActivator.DeactivateObject(11);
        arrowActivator.ActivateObject(12);
        tooltipActivator.ActivateObject(11);
        ScriptObjectBackCoverOnTableSnapPoint.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 35, subTitletxt); //It is a NG child part so put this Switch knob in the NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(3, 36, subTitletxt, 4.2f)); // Place Upper Case on table
        }
    }
    public void BackCoverOnTableSnapped()
    {
        arrowActivator.DeactivateObject(12);
        arrowActivator.ActivateObject(8);
        tooltipActivator.ActivateObject(8);
        NGbox2ScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 37, subTitletxt); // Open the NG box
        }
    }
    private void NGdrawerOpeningDone2()
    {
        NGDrawerOpened2();
    }
    public void NGDrawerOpened2()
    {
        tooltipActivator.DeactivateObject(8);
        arrowActivator.DeactivateObject(8);
        arrowActivator.ActivateObject(9);
        NGBoxSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 38, subTitletxt); //Place NG Switch Knob in the NG box
        }
    }
    public void NGUnlockButtonSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(9);
        tooltipActivator.ActivateObject(9);
        nGDrawer.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 39, subTitletxt); // Close the NG box
        }
    }
    private void NGdrawerClosingDone2()
    {
        NGDrawerClosed2();
    }
    public void NGDrawerClosed2()
    {
        arrowActivator.ActivateObject(12);
        HighlightBackCoverOnTable.Highlight();
        GrabBackCoverOnTable.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 40, subTitletxt); // Pick Upper Case from table
        }
    }
    public void GrabbedBackCoverFromTable()
    {
        if (currentStep != TrainingStep.NGUnlockButtonGrabbed)
            return;

        currentStep = TrainingStep.BackCoverFromTableGrabbed;
        arrowActivator.DeactivateObject(12);
        arrowActivator.ActivateObject(13);
        HighlightUnlockButton.Highlight();
        GrabUnlockButton.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 41, subTitletxt); // Now take another Switch knob unlock from tray using left hand
        }
    }
    public void GrabbedUnlockButtonFromTray()
    {
        if (currentStep != TrainingStep.BackCoverFromTableGrabbed)
            return;

        currentStep = TrainingStep.UnlockButtonGrabbed;
        tooltipActivator.ActivateObject(40);
        arrowActivator.DeactivateObject(13);
        ScriptObjectUnlockButtonSnapPoint.SetActive(true);
        SphereUnlockButton.SetActive(true);
        HighlightSphereUnlockButton.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 42, subTitletxt); // Place Switch knob on the Upper Case as highlighted
        }
    }
    public void UnlockButtonSnapped()
    {
        tooltipActivator.DeactivateObject(40);
        SphereUnlockButton.SetActive(false);
        arrowActivator.ActivateObject(14);
        HighlightLockButton.Highlight();
        GrabLockButton.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 43, subTitletxt); //Pick Switch knob lock from tray using right hand
        }
    }
    public void GrabbedLockButtonFromTray()
    {
        if (currentStep != TrainingStep.UnlockButtonGrabbed)
            return;

        currentStep = TrainingStep.LockButtonGrabbed;
        arrowActivator.DeactivateObject(14);
        ScriptObjectLockButtonSnapPoint.SetActive(true);
        SphereLockButton.SetActive(true);
        HighlightSphereLockButton.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 44, subTitletxt); //Place Switch knob on the Upper case as highlighted
        }
    }
    public void LockButtonSnapped()
    {
        SphereLockButton.SetActive(false);
        arrowActivator.ActivateObject(15);
        HighlightRubberCover.Highlight();
        GrabRubberCover.enabled = true;
        changer2.SwitchToController1();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 45, subTitletxt); //Pick Rubber from tray using right hand
        }
    }
    public void GrabbedRubberCoverFromTray()
    {
        if (currentStep != TrainingStep.LockButtonGrabbed)
            return;

        currentStep = TrainingStep.RubberCoverGrabbed;
        arrowActivator.DeactivateObject(15);
        ScriptObjectRubberCoverSnapPoint.SetActive(true);
        SphereRubberCover.SetActive(true);
        HighlightSphereRubberCover.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 46, subTitletxt); //Place Rubber on the Upper Case as highlighted
        }
    }
    public void RubberCoverSnapped()
    {
        SphereRubberCover.SetActive(false);
        RubberCheckCanvas.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 47, subTitletxt); //Always check the direction from Switch Knob to rubber. It should be same as shown
        }
    }
    public void OkAfterRubberCoverChecked()
    {
        RubberCheckCanvas.SetActive(false);
        checkerHandle.Unlock();
        tooltipActivator.ActivateObject(12);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 48, subTitletxt); //Open the flap using right hand
        }
    }
    public void CheckerOpened()
    {
        tooltipActivator.DeactivateObject(12);
        arrowActivator.ActivateObject(6);
        HighlightChipOnChecker.Highlight();
        GrabChipFromChecker.enabled = true;
        changer2.SwitchToController1();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 49, subTitletxt); //Pick Circuit Assembly from jig
        }

    }
    public void GrabbedChipFromChecker()
    {
        if (currentStep != TrainingStep.RubberCoverGrabbed)
            return;

        currentStep = TrainingStep.ChipFromCheckerGrabbed;
        arrowActivator.DeactivateObject(6);
        ScriptObjectChipSnapPoint.SetActive(true);
        SphereChipOnMain.SetActive(true);
        HighlightSphereChipOnMain.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 50, subTitletxt); //Place Circuit Assembly on the Upper Case as highlighted
        }
    }

    public void ChipSnappedToMain()
    {
        SphereChipOnMain.SetActive(false);
        arrowActivator.ActivateObject(16);
        ScriptObjectMainToPunchingSnapPoint.SetActive(true);
        SphereMainOnPunching.SetActive(true);
        HighlightSphereMainOnPunching.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 51, subTitletxt); //Now, Move to Stage 3 which is Case inner sub assembly. Align and place the Upper Case onto the Pressing machine jig
        }
    }
    public void MainSnappedToPunching()
    {
        arrowActivator.DeactivateObject(16);
        SphereMainOnPunching.SetActive(false);
        arrowActivator.ActivateObject(17);
        HighlightBatteryPlacer.Highlight();
        GrabBatteryPlacer.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 52, subTitletxt); //Pick Case Inner from tray
        }

    }
    public void GrabbedBateryPlacerFromTray()
    {
        if (currentStep != TrainingStep.ChipFromCheckerGrabbed)
            return;

        currentStep = TrainingStep.BatteryCoverGrabbed;
        arrowActivator.DeactivateObject(17);
        tooltipActivator.ActivateObject(40);
        arrowActivator.ActivateObject(16);
        ScriptObjectBatteryPlacerSnapPoint.SetActive(true);
        SphereBatteryPlacer.SetActive(true);
        HighlightSphereBatteryPlacer.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 53, subTitletxt); //Place Case Inner on the Upper Case as highlighted
        }

    }
    public void BatteryPlacerSnappedToMain()
    {
        arrowActivator.DeactivateObject(16);
        tooltipActivator.DeactivateObject(40);

        SphereBatteryPlacer.SetActive(false);
        tooltipActivator.ActivateObject(13);
        ScriptObjectPunchingHandle.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 54, subTitletxt); //Pull the lever to press the Case Inner into the Case Upper Sub Assembly
        }
    }

    private void PunchingProcessDone()
    {
        PunchingDone();
    }
    public void PunchingDone()
    {
        tooltipActivator.DeactivateObject(13);
        arrowActivator.ActivateObject(16);
        HighlightMainAfterPunching.Highlight();
        GrabMainFromPunching.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 55, subTitletxt); // Pick Case Upper Sub Assembly from Pressing machine using left hand
        }
    }
    public void GrabbedMainFromPunching()
    {
        if (currentStep != TrainingStep.BatteryCoverGrabbed)
            return;

        currentStep = TrainingStep.MainFromPunching;
        ScriptObjectPunchingHandle.SetActive(false);
        arrowActivator.DeactivateObject(16);
        arrowActivator.ActivateObject(8);
        tooltipActivator.ActivateObject(14);
        tooltipActivator.ActivateObject(8);
        NGbox2ScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 56, subTitletxt); //It is a NG child part so put this Upper Case in the NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(3, 57, subTitletxt, 4.2f)); // Open the NG box
        }

    }
    private void NGdrawerOpeningDone3()
    {
        NGDrawerOpened3();
    }
    public void NGDrawerOpened3()
    {
        tooltipActivator.DeactivateObject(8);
        arrowActivator.DeactivateObject(8);
        arrowActivator.ActivateObject(9);
        NGBoxSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 58, subTitletxt); // Place NG Case Upper Sub Assembly in the NG box
        }
    }
    public void NGMainCoverSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(9);
        tooltipActivator.ActivateObject(9);
        nGDrawer.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 59, subTitletxt); // Close the NG box
        }
    }
    private void NGdrawerClosingDone3()
    {
        NGDrawerClosed3();
    }
    public void NGDrawerClosed3()
    {
        GoodMainPartOnPunching.SetActive(true);
        arrowActivator.ActivateObject(16);
        tooltipActivator.ActivateObject(15);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 60, subTitletxt); // Do this pressing process again
        }
    }
    public void OkOfLetsDoAgain()
    {
        tooltipActivator.DeactivateObject(15);
        arrowActivator.DeactivateObject(16);
        tooltipActivator.ActivateObject(13);
        ScriptObjectPunchingHandle.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 61, subTitletxt); // Pull the lever to press the Case Inner into the Case Upper Sub Assembly
        }
    }
    private void PunchingProcessDone2()
    {
        PunchingDone2();
    }
    public void PunchingDone2()
    {
        tooltipActivator.DeactivateObject(13);
        arrowActivator.ActivateObject(16);
        HighlightGoodMainAfterPunching.Highlight();
        GrabGoodMainFromPunching.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 62, subTitletxt); //Pick Case Upper Sub Assembly from Pressing machine using left hand
        }
    }
    public void GrabbedFinalMainFromPunching()
    {
        if (currentStep != TrainingStep.MainFromPunching)
            return;

        currentStep = TrainingStep.MainFromPunching2;
        // tooltipActivator.ActivateObject(16);
        tooltipActivator.ActivateObject(39);

        arrowActivator.DeactivateObject(16);
        arrowActivator.ActivateObject(18);
        HighlightBattery.Highlight();
        GrabBattery.enabled = true;
        TerminalCheckCanvas.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 63, subTitletxt); //Pick Battery from tray
        }
    }
    public void GrabbedBatteryFromTray()
    {
        if (currentStep != TrainingStep.MainFromPunching2)
            return;

        currentStep = TrainingStep.BatteryGrabbed;
        tooltipActivator.ActivateObject(40);

        tooltipActivator.DeactivateObject(39);
        arrowActivator.DeactivateObject(18);
        tooltipActivator.DeactivateObject(16);
        ScriptObjectBatterySnapPoint.SetActive(true);
        SphereBattery.SetActive(true);
        HighlightSphereBattery.Highlight();
        TerminalCheckCanvas.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 64, subTitletxt); //Place Battery on the Case Lower Sub Assembly as highlighted
        }

    }
    public void BatterySnappingDone()
    {
        tooltipActivator.DeactivateObject(40);
        SphereBattery.SetActive(false);
        TerminalUpwardCanvas.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 65, subTitletxt); //There should be no incorrect assembly of the battery into the lower case — the positive (+) terminal must always face upward
        }

    }
    public void OkForTerminalUpward()
    {
        TerminalUpwardCanvas.SetActive(false);
        stepManagerSwitcher.Machine2Completed();
    }


}


