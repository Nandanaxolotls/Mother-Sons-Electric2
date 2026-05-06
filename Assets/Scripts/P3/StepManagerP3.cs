using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class StepManagerP3 : MonoBehaviour
{
    [Header("Scene Settings")]
    public string nextSceneName = "NextScene"; // assign your next scene name in Inspector
    public int maxReloadCount = 7;             // how many times to reload before switching scene
    private string reloadKey;
    [Header("Main Parts")]
    [Header("Machine1")]
    public GameObject ChipChecker1SnapPointObject;
    public GameObject ChipChecker1Script;
    public ChipCheckerSnapPoint1 checkerSnapPoint1;
    public ChipChecker1Machine chipChecker1Machine;
    public XRGrabInteractable FrontCoverGrab;
    public XRGrabInteractable ButtonsGrab;
    public GameObject ButtonSnapPointObject;
    public ButtonSnapPoint buttonSnapPoint;
    public XRGrabInteractable RubberCoverGrab;
    public GameObject RubberSnapPointObject;
    public RubberCoverSnapPoint rubberCoverSnapPoint;
    public GameObject WaitingTraySnapPointObject;
    public WaitingTraySnapPoint waitingTraySnapPoint;
    public XRGrabInteractable ChipOnChecker1Grab;
    [Header("Machine2")]
    public GameObject ChipChecker2SnapPointObject;
    public GameObject ChipChecker2Script;
    public ChipCheckerSnapPoint2 checkerSnapPoint2;
    public ChipChecker2Machine chipChecker2Machine;
    public XRGrabInteractable ChipOnChecker2Grab;
    public XRGrabInteractable FrontCoverOnTableGrab;
    public GameObject ChipOnKeySnapPointObject;
    public ChipOnKeySnapPoint chipOnKeySnapPoint;
    public GameObject WaitingTraySnapPointObject2;
    public WaitingTraySnapPoint2 waitingTraySnapPoint2;
    [Header("Machine3")]
    public XRGrabInteractable BackCoverGrab;
    public GameObject BackCoverInClippingSnapPointObject;
    public BackCoverOnClipingSnapPoint backCoverOnClipingSnapPoint;
    public XRGrabInteractable ClipOnTrayGrab;
    public GameObject ClipInClippingSnapPointObject;
    public ClipOnKeySnapPoint clipOnKeySnapPoint;
    public XRGrabInteractable ToolGrab;

    public GameObject ToolcheckSnapPoint;
    public ToolScript toolScript;
    public GameObject ToolPositionShowingCanvas;
    public GameObject ToolSnapPointObject;
    public ToolOriginalPosSnapPoint toolOriginalPosSnapPoint;
    public GameObject ClippingScriptObject;
    public ClippingMachine clippingMachine;
    [Header("Machine4")]
    public XRGrabInteractable BackCoverGrabFromClipping;
    public GameObject BackCoverInWaitingSnapPointObject;
    public BackCoverOnWaitingTraySnapPoint backCoverOnWaitingTraySnapPoint;
    public XRGrabInteractable KeyFromWaitingGrab;
    public GameObject KeyOnPunchingSnapPointObject;
    public KeyOnPunchingSnapPoint keyOnPunchingSnapPoint;
    public XRGrabInteractable BackCoverOnWaitingGrab;
    public XRGrabInteractable BatteryOnTrayGrab;
    public GameObject BatterySnapPointObject;
    public BatteryOnKeySnapPoint batteryOnKeySnapPoint;
    public GameObject BackCoverOnPunchingSnapPointObject;
    public BackCoverOnPunchingSnapPoint backCoverOnPunchingSnapPoint;
    public GameObject ScriptObjectPunchingMachine;
    public PunchingMachieP3 punchingMachieP3;
    public XRGrabInteractable KeyFromPunchingGrab;
    [Header("Machine5")]
    public GameObject KeyOnDoorSnapPointObject;
    public GameObject ScriptObjectDoor;
    public KeyOnDoorSnapPoint keyOnDoorSnapPoint;
    public DrawerP3 drawerP3;
    public XRGrabInteractable KeyOnDoorGrab;
    [Header("Machine6")]
    public GameObject KeyOnLaserSnapPointObject;
    public LaserMachineSnapPoint laserMachineSnapPoint;
    public LaserMachine laserMachine;
    public XRGrabInteractable KeyInLaserGrab;
    public GameObject KeyOnFinalTraySnapPointObject;
    public FinalTraySnapPoint finalTraySnapPoint;



    [Header("Highlighter")]
    [Header("Machine1")]
    public GameObject Arrow1;
    public GameObject Arrow2;
    public GameObject Tooltip1;
    public StepWiseHighlighter ChipInRack;
    public GameObject SphereObjectChipInChecker1;
    public StepWiseHighlighter SphereHighlightChipInChecker1;
    public StepWiseHighlighter FrontCoverInRackHighlight;
    public GameObject Arrow3;
    public GameObject Arrow4;
    public StepWiseHighlighter ButtonInRackHighlight;
    public GameObject SphereObjectButtonInFrontCover;
    public StepWiseHighlighter SphereHighlightButtonInFrontCover;
    public GameObject Arrow5;
    public StepWiseHighlighter RubberCoverInRackHighlight;
    public GameObject SphereObjectRubberInFrontCover;
    public StepWiseHighlighter SphereHighlightRubberInFrontCover;
    public GameObject Arrow6;
    public GameObject Arrow7;
    public GameObject Tooltip2;
    public StepWiseHighlighter ChipOnChecker1Highlight;
    public GameObject Arrow8;
    [Header("Machine2")]
    public GameObject SphereObjectChipInChecker2;
    public StepWiseHighlighter SphereHighlightChipInChecker2;
    public GameObject Tooltip3;
    public GameObject Tooltip4;
    public StepWiseHighlighter ChipOnChecker2Highlight;
    public GameObject SphereObjectChipOnKey;
    public StepWiseHighlighter SphereHighlightChipOnKey;
    public GameObject Arrow9;
    public GameObject Arrow10;
    public StepWiseHighlighter BackCoverInRackHighlight;
    [Header("Machine3")]
    public GameObject Arrow11;
    public GameObject SphereObjectBackCoverOnCliper;
    public StepWiseHighlighter SphereHighlightBackCoverOnCliper;
    public GameObject Arrow12;
    public StepWiseHighlighter ClipOnTrayHighlight;
    public GameObject SphereObjectClipOnKey;
    public StepWiseHighlighter SphereHighlightClipOnKey;
    public GameObject Arrow13;
    public GameObject Tooltip5;
    public StepWiseHighlighter ToolHighlight;
    public GameObject Arrow14;
    public StepWiseHighlighter HighlightKeyOnWaiting;
    [Header("Machine4")]
    public GameObject SphereObjectKeyOnPunching;
    public StepWiseHighlighter SphereHighlightKeyOnPunching;
    public GameObject Arrow15;
    public StepWiseHighlighter HighlightBackCoverOnWaiting;
    public GameObject Arrow16;
    public StepWiseHighlighter HighlightBatteryOnTray;
    public GameObject SphereObjectBatteryOnKey;
    public StepWiseHighlighter SphereHighlightBatteryOnKey;
    public GameObject SphereObjectBackCoverOnPunching;
    public StepWiseHighlighter SphereHighlightBackCoverOnPunching;
    public GameObject Tooltip6;
    public StepWiseHighlighter HighlightKeyOnPunching;
    public GameObject BatteryTerminalTooltip;
    [Header("Machine5")]
    public GameObject Arrow17;
    public GameObject SphereObjectKeyOnDoor;
    public StepWiseHighlighter SphereHighlightKeyOnDoor;
    public GameObject Tooltip7;
    public GameObject Tooltip8;
    [Header("Machine6")]
    public GameObject Arrow18;
    public GameObject SphereObjectKeyInLaser;
    public StepWiseHighlighter SphereHighlightKeyInLaser;
    public GameObject Arrow19;
    public GameObject SphereObjectKeyInFinalTray;
    public StepWiseHighlighter SphereHighlightKeyInFinalTray;

    [Header("UI")]
    public GameObject Checker1CheckButton;
    public GameObject Checker1OKButton;
    public GameObject Checker2CheckButton;
    public GameObject Checker2OKButton;
    public GameObject ButtonCheck;
    public GameObject BackButtonCheck;
    public GameObject BackButtonOK;
    public GameObject ButtonOK1;
    public GameObject ButtonOK2;
    public GameObject ButtonOK3;
    public GameObject ButtonOK5;
    public GameObject ButtonOK6;
    public GameObject DoorCheck;
    public GameObject DoorOK;
    [Header(" Level ")]
    public TMP_Text subTitletxt;

    public enum TrainingStep
    {
        None,
        ChipGrabbed,
        FrontCoverGrabbed,
        ButtonGrabbed,
        RubberCoverGrabbed,
        ChipFromCheckerGrabbed,
        ChipFromChecker2Grabbed,
        FrontCoverFromTableGrabbed,
        BackCoverGrabbed,
        ClipGrabbed,
        ToolGrabbed,
        BackCoverFromClipperGrabbed,
        KeyFromWaitingGrabbed,
        BackCoverFromWaitingGrabbed,
        BatteryGrabbed,
        KeyFromPunchGrabbed,
        KeyFromDoorGrabbed,
        KeyFromLaserGrabbed,


    }

    public TrainingStep currentStep = TrainingStep.None;

    void Awake()
    {
        // Use the scene name as a unique key for saving reload count
        reloadKey = SceneManager.GetActiveScene().name + "_ReloadCount";
    }

    void Start()
    {
        ChipInRack.Highlight();
        checkerSnapPoint1.ChipSnapped += ChipSnappedToChecker1;
        chipChecker1Machine.onReachedDesired += Checker1Closed;
        buttonSnapPoint.ButtonSnapped += ButtonSnapped;
        rubberCoverSnapPoint.RubberCoverSnapped += RubberCoverSnapped;
        waitingTraySnapPoint.KeyOnWaitingTraySnapped += KeySnappedToWaitingTray;
        chipChecker1Machine.onReachedOriginal += Checker1Opened;
        checkerSnapPoint2.ChipSnapped += ChipSnappedToChecker2;
        chipChecker2Machine.onReachedDesired += Checker2Closed;
        chipChecker2Machine.onReachedOriginal += Checker2Opened;
        chipOnKeySnapPoint.ChipOnKeySnapped += ChipSnappedToKey;
        waitingTraySnapPoint2.KeyOnWaitingTray2Snapped += KeySnappedToWaitingTray2;
        backCoverOnClipingSnapPoint.BackCoverSnappedToClipping += BackCoverSnappedToClipping;
        clipOnKeySnapPoint.ClipOnKeySnapped += ClipSnappedToKey;
        toolScript.MarkingDone += AfterToolUsed;
        toolOriginalPosSnapPoint.ToolSnapped += ToolSnappedToOrigine;
        clippingMachine.onReachedOriginal += ClippingMachineProcessDone;
        backCoverOnWaitingTraySnapPoint.BackCoverOnWaitingSnapped += BackCoverSnappedToWaiting;
        keyOnPunchingSnapPoint.KeyOnPunchingSnapped += KeySnappedToPunching;
        batteryOnKeySnapPoint.BatterySnapped += BatterySnappedToKey;
        backCoverOnPunchingSnapPoint.BackSnappedOnPunching += BackCoverSnappedToPunching;
        punchingMachieP3.onReachedOriginal += PunchingDone;
        keyOnDoorSnapPoint.KeyOnDoorSnapped += KeySnappedToDoor;
        drawerP3.onReachedDesired += DoorClosed;
        laserMachineSnapPoint.KeySnapped += KeySnappedToLaser;
        drawerP3.onReachedOriginal += DoorOpened;
        laserMachine.LaserMachineDone += LaserProcessDone;
        finalTraySnapPoint.FinalKeySnapped += FinalKeySnapped;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 0, subTitletxt); //Welcome to the Transmitter Line simulation tutorial
            StartCoroutine(SoundManager.instance.PlayDelayedSound(4, 1, subTitletxt, 3f)); //Go to first stage which is Write ID Data and Pick circuit assembly from tray using left hand
        }
    }

    public void ChipGrabbedFromRack()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.ChipGrabbed;
        Arrow1.SetActive(false);
        Arrow2.SetActive(true);
        ChipChecker1SnapPointObject.SetActive(true); // chip on checker1 snappoint script attached object
        SphereObjectChipInChecker1.SetActive(true); // Chip place highlighter object 
        SphereHighlightChipInChecker1.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 2, subTitletxt); //Place the Circuit Assembly onto the highlighted jig
        }
    }
    public void ChipSnappedToChecker1()
    {
        Arrow2.SetActive(false);
        Tooltip1.SetActive(true);
        SphereObjectChipInChecker1.SetActive(false);
        ChipChecker1Script.SetActive(true); // checker 1 moving handle script
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 3, subTitletxt); //Close the flap using right hand
        }
    }
    public void Checker1Closed()
    {
        Arrow3.SetActive(true);
        Tooltip1.SetActive(false);
        FrontCoverInRackHighlight.Highlight();
        FrontCoverGrab.enabled = true;
        StartCoroutine(CheckerDisplay1());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 4, subTitletxt); //Pick Case Upper from tray using left hand
        }
    }
 
    public IEnumerator CheckerDisplay1()
    {
        Checker1CheckButton.SetActive(true);
        yield return new WaitForSeconds(3);
        Checker1CheckButton.SetActive(false);
        Checker1OKButton.SetActive(true);
    }


    public void FrontCoverGrabbed()
    {
        if (currentStep != TrainingStep.ChipGrabbed)
            return;

        currentStep = TrainingStep.FrontCoverGrabbed;
        Arrow3.SetActive(false);
        Arrow4.SetActive(true);
        ButtonInRackHighlight.Highlight();
        ButtonsGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 5, subTitletxt); //Pick Switch knob from tray using right hand
        }
    }
    public void ButtonGrabbed()
    {
        if (currentStep != TrainingStep.FrontCoverGrabbed)
            return;

        currentStep = TrainingStep.ButtonGrabbed;
        Arrow4.SetActive(false);
        SphereObjectButtonInFrontCover.SetActive(true);
        SphereHighlightButtonInFrontCover.Highlight();
        ButtonSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 6, subTitletxt); // Place Switch knob on the Case Upper as highlighted
        }

    }
    public void ButtonSnapped()
    {
        SphereObjectButtonInFrontCover.SetActive(false);
        Arrow5.SetActive(true);
        RubberCoverInRackHighlight.Highlight();
        RubberCoverGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 7, subTitletxt); // Pick Rubber from tray using right hand
        }

    }
    public void RubberCoverGrabbed()
    {
        if (currentStep != TrainingStep.ButtonGrabbed)
            return;

        currentStep = TrainingStep.RubberCoverGrabbed;
        Arrow5.SetActive(false);
        SphereObjectRubberInFrontCover.SetActive(true);
        SphereHighlightRubberInFrontCover.Highlight();
        RubberSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 8, subTitletxt); // Place Rubber on the Case Upper as highlighted

        }
    }
    public void RubberCoverSnapped()
    {
        SphereObjectRubberInFrontCover.SetActive(false);
        Arrow6.SetActive(true);
        WaitingTraySnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 9, subTitletxt); //Place Case Upper on waiting tray as highlighted
        }
    }
    public void KeySnappedToWaitingTray()
    {
        Arrow6.SetActive(false);
        chipChecker1Machine.Unlock();
        Tooltip2.SetActive(true);
        Arrow7.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 10, subTitletxt); //Open the flap using right hand
        }
    }
    public void Checker1Opened()
    {

        Tooltip2.SetActive(false);
        ChipOnChecker1Grab.enabled = true;
        ChipOnChecker1Highlight.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 11, subTitletxt); //Pick Circuit Assembly from jig
        }
    }
    public void ChipOnChecker1Grabbed()
    {
        if (currentStep != TrainingStep.RubberCoverGrabbed)
            return;

        currentStep = TrainingStep.ChipFromCheckerGrabbed;
        Arrow7.SetActive(false);
        Arrow8.SetActive(true);
        ChipChecker2SnapPointObject.SetActive(true);
        SphereObjectChipInChecker2.SetActive(true);
        SphereHighlightChipInChecker2.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 12, subTitletxt); //Proceed to the next highlighted jig and place the circuit assembly onto it.
        }
    }
    public void ChipSnappedToChecker2()
    {
        Arrow8.SetActive(false);
        Tooltip3.SetActive(true);
        SphereObjectChipInChecker2.SetActive(false);
        ChipChecker2Script.SetActive(true); // checker 2 moving handle script
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 13, subTitletxt); //Close the flap using right hand
        }
    }
    public void Checker2Closed()
    {
        Tooltip3.SetActive(false);
        StartCoroutine(WaitingToCheck());
        StartCoroutine(CheckerDisplay2());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 14, subTitletxt); //Wait for the Result on monitor screen
        }
    }
    public IEnumerator CheckerDisplay2()
    {
        Checker2CheckButton.SetActive(true);
        yield return new WaitForSeconds(3);
        Checker2CheckButton.SetActive(false);
        Checker2OKButton.SetActive(true);
    }

    public IEnumerator WaitingToCheck()
    {
        yield return new WaitForSeconds(3);
        Tooltip4.SetActive(true);
        chipChecker2Machine.Unlock();
        Arrow8.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 15, subTitletxt); //Open the flap using right hand
        }
    }
    public void Checker2Opened()
    {
        Tooltip4.SetActive(false);
        Arrow8.SetActive(false);
        ChipOnChecker2Grab.enabled = true;
        ChipOnChecker2Highlight.Highlight();
        StartCoroutine(WaitingToShowArrow());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 16, subTitletxt); //Pick Circuit Assembly from jig using left hand
        }
    }
    public IEnumerator WaitingToShowArrow()
    {
        yield return new WaitForSeconds(0.5f);
        Arrow8.SetActive(true);

    }
    public void ChipOnChecker2Grabbed()
    {
        if (currentStep != TrainingStep.ChipFromCheckerGrabbed)
            return;

        currentStep = TrainingStep.ChipFromChecker2Grabbed;
        Arrow8.SetActive(false);
        Arrow6.SetActive(true);
        FrontCoverOnTableGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 17, subTitletxt); //Pick Case Upper from waiting tray
        }
    }
    public void FrontCoverOnTableGrabbed()
    {
        if (currentStep != TrainingStep.ChipFromChecker2Grabbed)
            return;

        currentStep = TrainingStep.FrontCoverFromTableGrabbed;
        Arrow6.SetActive(false);
        ChipOnKeySnapPointObject.SetActive(true);
        SphereObjectChipOnKey.SetActive(true);
        SphereHighlightChipOnKey.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 18, subTitletxt); //Place Circuit Assembly on the Case Upper as highlighted
        }
    }
    public void ChipSnappedToKey()
    {
        SphereObjectChipOnKey.SetActive(false);
        Arrow9.SetActive(true);
        WaitingTraySnapPointObject2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 19, subTitletxt); //Place the Case Upper onto the waiting tray on the right, as highlighted.
        }
    }
    public void KeySnappedToWaitingTray2()
    {
        Arrow9.SetActive(false);
        Arrow10.SetActive(true);
        BackCoverGrab.enabled = true;
        BackCoverInRackHighlight.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 20, subTitletxt); //Pick Case Lower from tray using left hand
        }
    }
    public void BackCoverInRackGrabbed()
    {
        if (currentStep != TrainingStep.FrontCoverFromTableGrabbed)
            return;

        currentStep = TrainingStep.BackCoverGrabbed;
        Arrow10.SetActive(false);
        Arrow11.SetActive(true);
        SphereObjectBackCoverOnCliper.SetActive(true);
        SphereHighlightBackCoverOnCliper.Highlight();
        BackCoverInClippingSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 21, subTitletxt); //Place the Case Lower onto the highlighted jig
        }
    }
    public void BackCoverSnappedToClipping()
    {
        Arrow11.SetActive(false);
        SphereObjectBackCoverOnCliper.SetActive(false);
        Arrow12.SetActive(true);
        ClipOnTrayHighlight.Highlight();
        ClipOnTrayGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 22, subTitletxt); // Pick Terminal from tray using left hand
        }
    }

    public void ClipFromTrayGrabbed()
    {
        if (currentStep != TrainingStep.BackCoverGrabbed)
            return;

        currentStep = TrainingStep.ClipGrabbed;
        Arrow12.SetActive(false);
        Arrow11.SetActive(true);
        ClipInClippingSnapPointObject.SetActive(true);
        SphereObjectClipOnKey.SetActive(true);
        SphereHighlightClipOnKey.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 23, subTitletxt); // Place the Terminal onto the Case Lower
        }

    }
    public void ClipSnappedToKey()
    {
        Arrow11.SetActive(false);
        SphereObjectClipOnKey.SetActive(false);
        ToolHighlight.Highlight();
        Tooltip5.SetActive(true);
        ToolGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 24, subTitletxt); // Now grab the highlighted tool
        }
    }
    public void ToolGrabbed()
    {
        if (currentStep != TrainingStep.ClipGrabbed)
            return;

        currentStep = TrainingStep.ToolGrabbed;
        Tooltip5.SetActive(false);
        ToolcheckSnapPoint.SetActive(true);
        ToolPositionShowingCanvas.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 25, subTitletxt); //Take the tool tip near the highlighted point on Case Lower to fit terminal into the Case Lower
        }
    }
    public void AfterToolUsed()
    {
        ToolPositionShowingCanvas.SetActive(false);
        ToolSnapPointObject.SetActive(true);
        Arrow13.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 26, subTitletxt); //Place tool back to it's stand
        }
    }
    public void ToolSnappedToOrigine()
    {
        Arrow13.SetActive(false);
        ClippingScriptObject.SetActive(true);
        clippingMachine.StartClipping();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 27, subTitletxt); // Now, Wait for the process to complete
        }
    }
    public void ClippingMachineProcessDone()
    {
        BackCoverGrabFromClipping.enabled = true;
        Arrow11.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 28, subTitletxt); //Pick Case Lower Sub Assy from jig using left hand
        }
    }
    public void BackCoverGrabbedFromClipping()
    {
        if (currentStep != TrainingStep.ToolGrabbed)
            return;

        currentStep = TrainingStep.BackCoverFromClipperGrabbed;
        Arrow11.SetActive(false);
        BackCoverInWaitingSnapPointObject.SetActive(true);
        Arrow14.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 29, subTitletxt); //Place the Case Lower Sub Assy onto the waiting tray on the right, as highlighted.
        }
    }
    public void BackCoverSnappedToWaiting()
    {
        Arrow14.SetActive(false);
        KeyFromWaitingGrab.enabled = true;
        Arrow9.SetActive(true);
        HighlightKeyOnWaiting.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 30, subTitletxt); //Pick Case Upper Sub Assy from waiting tray
        }
    }
    public void KeyGrabbedFromWaiting()
    {
        if (currentStep != TrainingStep.BackCoverFromClipperGrabbed)
            return;

        currentStep = TrainingStep.KeyFromWaitingGrabbed;
        Arrow9.SetActive(false);
        KeyOnPunchingSnapPointObject.SetActive(true);
        SphereObjectKeyOnPunching.SetActive(true);
        SphereHighlightKeyOnPunching.Highlight();
        Arrow15.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 31, subTitletxt); //Now, Go to forth stage which is Assembly Case Upper and fitting to Case Lower and Place Case Upper Sub Assy on the pressing jig as highlighted
        }
    }
    public void KeySnappedToPunching()
    {
        Arrow15.SetActive(false);
        SphereObjectKeyOnPunching.SetActive(false);
        BackCoverOnWaitingGrab.enabled = true;
        HighlightBackCoverOnWaiting.Highlight();
        Arrow14.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 32, subTitletxt); //Pick Case Lower Sub Assy from waiting tray
        }
    }
    public void BackCoverGrabbedFromWaiting()
    {
        if (currentStep != TrainingStep.KeyFromWaitingGrabbed)
            return;

        currentStep = TrainingStep.BackCoverFromWaitingGrabbed;
        Arrow14.SetActive(false);
        Arrow16.SetActive(true);
        BatteryOnTrayGrab.enabled = true;
        HighlightBatteryOnTray.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 33, subTitletxt); //Pick Battery from tray
        }
    }
    public void BatteryGrabbedFromTray()
    {
        if (currentStep != TrainingStep.BackCoverFromWaitingGrabbed)
            return;

        currentStep = TrainingStep.BatteryGrabbed;
        Arrow16.SetActive(false);
        HighlightBatteryOnTray.Unhighlight();
        BatterySnapPointObject.SetActive(true);
        SphereObjectBatteryOnKey.SetActive(true);
        SphereHighlightBatteryOnKey.Highlight();
        BatteryTerminalTooltip.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 34, subTitletxt); //Place Battery on the Case Lower Sub Assembly as highlighted
        }

    }
    public void BatterySnappedToKey()
    {
        SphereObjectBatteryOnKey.SetActive(false);
        Arrow15.SetActive(true);
        BackCoverOnPunchingSnapPointObject.SetActive(true);
        SphereObjectBackCoverOnPunching.SetActive(true);
        SphereHighlightBackCoverOnPunching.Highlight();
        BatteryTerminalTooltip.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 35, subTitletxt); // Go the pressing machine of stage forth and place Case Lower Sub Assembly on the Case Upper Sub Assembly
        }

    }
    public void BackCoverSnappedToPunching()
    {
        Arrow15.SetActive(false);
        SphereObjectBackCoverOnPunching.SetActive(false);
        ScriptObjectPunchingMachine.SetActive(true);
        Tooltip6.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 36, subTitletxt); // Pull the lever to press the Case Lower Sub Assy into the Case upper Sub Assy
        }
    }
    public void PunchingDone()
    {
        KeyFromPunchingGrab.enabled = true;
        Arrow15.SetActive(true);
        HighlightKeyOnPunching.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 37, subTitletxt); // Pick Transmitter from jig
        }

    }
    public void KeyGrabbedFromPunching()
    {
        if (currentStep != TrainingStep.BatteryGrabbed)
            return;

        currentStep = TrainingStep.KeyFromPunchGrabbed;
        Arrow15.SetActive(false);
        Arrow17.SetActive(true);
        KeyOnDoorSnapPointObject.SetActive(true);
        SphereObjectKeyOnDoor.SetActive(true);
        SphereHighlightKeyOnDoor.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 38, subTitletxt); // Now, Go to fifth stage which is Function Checker. Place Transmitter on the Function Checker as highlighted
        }
    }
    public void KeySnappedToDoor()
    {
        Arrow17.SetActive(false);
        SphereObjectKeyOnDoor.SetActive(false);
        Tooltip7.SetActive(true);
        ScriptObjectDoor.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 39, subTitletxt); //Close the door 
        }
    }
    public void DoorClosed()
    {
        Tooltip7.SetActive(false);
        StartCoroutine(DoorDisplay());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 40, subTitletxt); //Wait for the Result on monitor screen
        }
    }
   
    public IEnumerator DoorDisplay()
    {
        DoorCheck.SetActive(true);
        yield return new WaitForSeconds(4);
        DoorCheck.SetActive(false);
        DoorOK.SetActive(true);
        drawerP3.Unlock();
        Tooltip8.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 41, subTitletxt); //Open the door
        }
    }
    public void DoorOpened()
    {
        Tooltip8.SetActive(false);
        Arrow17.SetActive(true);
        KeyOnDoorGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 42, subTitletxt); // Pick Transmitter from Function Checker
        }
    }
    public void KeyGrabbedFromDoor()
    {
        if (currentStep != TrainingStep.KeyFromPunchGrabbed)
            return;

        currentStep = TrainingStep.KeyFromDoorGrabbed;
        Arrow17.SetActive(false);
        Arrow18.SetActive(true);
        KeyOnLaserSnapPointObject.SetActive(true);
        SphereObjectKeyInLaser.SetActive(true);
        SphereHighlightKeyInLaser.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 43, subTitletxt); //Now, Go to Sixth stage which is Immobi communication checker. Place Transmitter on the jig as highlighted
        }
    }
    public void KeySnappedToLaser()
    {
        Arrow18.SetActive(false);
        SphereObjectKeyInLaser.SetActive(false);
        laserMachine.StartProcess();
        StartCoroutine(DisplayOfDrawerOK());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 44, subTitletxt); //Wait for the Result on monitor screen
        }
    }
  
    public IEnumerator DisplayOfDrawerOK()
    {
      
        ButtonCheck.SetActive(true);
        BackButtonCheck.SetActive(true);    
        yield return new WaitForSeconds(3);
        BackButtonCheck.SetActive(false) ;
        BackButtonOK.SetActive(true);
        ButtonOK1.SetActive(true);
        ButtonOK2.SetActive(true);
        ButtonOK3.SetActive(true);
        ButtonOK5.SetActive(true);
        ButtonOK6.SetActive(true);
        ButtonCheck.SetActive(false);
    }


    public void LaserProcessDone()
    {
        Arrow18.SetActive(true);
        KeyInLaserGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 45, subTitletxt); //Pick Transmitter from Immobi communication checker
        }

    }
    public void KeyGrabbedFromLaser()
    {
        if (currentStep != TrainingStep.KeyFromDoorGrabbed)
            return;

        currentStep = TrainingStep.KeyFromLaserGrabbed;
        Arrow18.SetActive(false);
        Arrow19.SetActive(true);
        KeyOnFinalTraySnapPointObject.SetActive(true);
        SphereObjectKeyInFinalTray.SetActive(true);
        SphereHighlightKeyInFinalTray.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 46, subTitletxt); //Now, Go to Last stage which is Packing. Place Transmitter in the tray as highlighted
        }
    }
    public void FinalKeySnapped()
    {
        Arrow19.SetActive(false);
        SphereObjectKeyInFinalTray.SetActive(false);
        Debug.Log("Final Completed");
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(4, 47, subTitletxt); //Congratulations
            StartCoroutine(ReloadAfterDelay(3f));
        }    
    }
    private IEnumerator ReloadAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        HandleReloadLogic();
    }
    private void HandleReloadLogic()
    {
        // Get current reload count
        int reloadCount = PlayerPrefs.GetInt(reloadKey, 0);

        // Increment the reload counter
        reloadCount++;
        PlayerPrefs.SetInt(reloadKey, reloadCount);
        PlayerPrefs.Save();

        Debug.Log($"Scene reload count: {reloadCount}");

        if (reloadCount < maxReloadCount)
        {
            // Reload the same scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            // Reset counter and load next scene
            PlayerPrefs.SetInt(reloadKey, 0);
            PlayerPrefs.Save();
            Debug.Log("Reached max reloads — loading next scene!");
            SceneManager.LoadScene("P3TNG");
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

