using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StepManagerP3T : MonoBehaviour
{
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



    //[Header("Highlighter")]
    //[Header("Machine1")]
    //public GameObject Arrow1;
    //public GameObject Arrow2;
    //public GameObject Tooltip1;
    //public StepWiseHighlighter ChipInRack;
    //public GameObject SphereObjectChipInChecker1;
    //public StepWiseHighlighter SphereHighlightChipInChecker1;
    //public StepWiseHighlighter FrontCoverInRackHighlight;
    //public GameObject Arrow3;
    //public GameObject Arrow4;
    //public StepWiseHighlighter ButtonInRackHighlight;
    //public GameObject SphereObjectButtonInFrontCover;
    //public StepWiseHighlighter SphereHighlightButtonInFrontCover;
    //public GameObject Arrow5;
    //public StepWiseHighlighter RubberCoverInRackHighlight;
    //public GameObject SphereObjectRubberInFrontCover;
    //public StepWiseHighlighter SphereHighlightRubberInFrontCover;
    //public GameObject Arrow6;
    //public GameObject Arrow7;
    //public GameObject Tooltip2;
    //public StepWiseHighlighter ChipOnChecker1Highlight;
    //public GameObject Arrow8;
    //[Header("Machine2")]
    //public GameObject SphereObjectChipInChecker2;
    //public StepWiseHighlighter SphereHighlightChipInChecker2;
    //public GameObject Tooltip3;
    //public GameObject Tooltip4;
    //public StepWiseHighlighter ChipOnChecker2Highlight;
    //public GameObject SphereObjectChipOnKey;
    //public StepWiseHighlighter SphereHighlightChipOnKey;
    //public GameObject Arrow9;
    //public GameObject Arrow10;
    //public StepWiseHighlighter BackCoverInRackHighlight;
    //[Header("Machine3")]
    //public GameObject Arrow11;
    //public GameObject SphereObjectBackCoverOnCliper;
    //public StepWiseHighlighter SphereHighlightBackCoverOnCliper;
    //public GameObject Arrow12;
    //public StepWiseHighlighter ClipOnTrayHighlight;
    //public GameObject SphereObjectClipOnKey;
    //public StepWiseHighlighter SphereHighlightClipOnKey;
    //public GameObject Arrow13;
    //public GameObject Tooltip5;
    //public StepWiseHighlighter ToolHighlight;
    //public GameObject Arrow14;
    //public StepWiseHighlighter HighlightKeyOnWaiting;
    //[Header("Machine4")]
    //public GameObject SphereObjectKeyOnPunching;
    //public StepWiseHighlighter SphereHighlightKeyOnPunching;
    //public GameObject Arrow15;
    //public StepWiseHighlighter HighlightBackCoverOnWaiting;
    //public GameObject Arrow16;
    //public StepWiseHighlighter HighlightBatteryOnTray;
    //public GameObject SphereObjectBatteryOnKey;
    //public StepWiseHighlighter SphereHighlightBatteryOnKey;
    //public GameObject SphereObjectBackCoverOnPunching;
    //public StepWiseHighlighter SphereHighlightBackCoverOnPunching;
    //public GameObject Tooltip6;
    //public StepWiseHighlighter HighlightKeyOnPunching;
    //[Header("Machine5")]
    //public GameObject Arrow17;
    //public GameObject SphereObjectKeyOnDoor;
    //public StepWiseHighlighter SphereHighlightKeyOnDoor;
    //public GameObject Tooltip7;
    //public GameObject Tooltip8;
    //[Header("Machine6")]
    //public GameObject Arrow18;
    //public GameObject SphereObjectKeyInLaser;
    //public StepWiseHighlighter SphereHighlightKeyInLaser;
    //public GameObject Arrow19;
    //public GameObject SphereObjectKeyInFinalTray;
    //public StepWiseHighlighter SphereHighlightKeyInFinalTray;



    [Header("UI")]
    public GameObject DoorCheck;
    public GameObject DoorOK;



    void Start()
    {
       // ChipInRack.Highlight();
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
    }

    public void ChipGrabbedFromRack()
    {
       // Arrow1.SetActive(false);
       // Arrow2.SetActive(true);
        ChipChecker1SnapPointObject.SetActive(true); // chip on checker1 snappoint script attached object
       // SphereObjectChipInChecker1.SetActive(true); // Chip place highlighter object 
       // SphereHighlightChipInChecker1.Highlight();
    }
    public void ChipSnappedToChecker1()
    {
      //  Arrow2.SetActive(false);
      //  Tooltip1.SetActive(true);
      //  SphereObjectChipInChecker1.SetActive(false);
        ChipChecker1Script.SetActive(true); // checker 1 moving handle script
    }
    public void Checker1Closed()
    {
     //   Arrow3.SetActive(true);
      //  Tooltip1.SetActive(false);
      //  FrontCoverInRackHighlight.Highlight();
        FrontCoverGrab.enabled = true;
    }
    public void FrontCoverGrabbed()
    {
      //  Arrow3.SetActive(false);
      //  Arrow4.SetActive(true);
       // ButtonInRackHighlight.Highlight();
        ButtonsGrab.enabled = true;
    }
    public void ButtonGrabbed()
    {
     //   Arrow4.SetActive(false);
      //  SphereObjectButtonInFrontCover.SetActive(true);
      //  SphereHighlightButtonInFrontCover.Highlight();
        ButtonSnapPointObject.SetActive(true);
    }
    public void ButtonSnapped()
    {
      //  SphereObjectButtonInFrontCover.SetActive(false);
      //  Arrow5.SetActive(true);
      //  RubberCoverInRackHighlight.Highlight();
        RubberCoverGrab.enabled = true;
    }
    public void RubberCoverGrabbed()
    {
      //  Arrow5.SetActive(false);
     //   SphereObjectRubberInFrontCover.SetActive(true);
      //  SphereHighlightRubberInFrontCover.Highlight();
        RubberSnapPointObject.SetActive(true);
    }
    public void RubberCoverSnapped()
    {
      //  SphereObjectRubberInFrontCover.SetActive(false);
      //  Arrow6.SetActive(true);
        WaitingTraySnapPointObject.SetActive(true);
    }
    public void KeySnappedToWaitingTray()
    {
     //   Arrow6.SetActive(false);
        chipChecker1Machine.Unlock();
      //  Tooltip2.SetActive(true);
      //  Arrow7.SetActive(true);
    }
    public void Checker1Opened()
    {

      //  Tooltip2.SetActive(false);
        ChipOnChecker1Grab.enabled = true;
      //  ChipOnChecker1Highlight.Highlight();
    }
    public void ChipOnChecker1Grabbed()
    {
      //  Arrow7.SetActive(false);
      //  Arrow8.SetActive(true);
        ChipChecker2SnapPointObject.SetActive(true);
     //   SphereObjectChipInChecker2.SetActive(true);
     //   SphereHighlightChipInChecker2.Highlight();
    }
    public void ChipSnappedToChecker2()
    {
      //  Arrow8.SetActive(false);
      //  Tooltip3.SetActive(true);
      //  SphereObjectChipInChecker2.SetActive(false);
        ChipChecker2Script.SetActive(true); // checker 2 moving handle script
    }
    public void Checker2Closed()
    {
      //  Tooltip3.SetActive(false);
        StartCoroutine(WaitingToCheck());
    }
    public IEnumerator WaitingToCheck()
    {
        yield return new WaitForSeconds(3);
      //  Tooltip4.SetActive(true);
        chipChecker2Machine.Unlock();
      //  Arrow8.SetActive(true);
    }
    public void Checker2Opened()
    {
      //  Tooltip4.SetActive(false);
      //  Arrow8.SetActive(false);
        ChipOnChecker2Grab.enabled = true;
      //  ChipOnChecker2Highlight.Highlight();
        StartCoroutine(WaitingToShowArrow());
    }
    public IEnumerator WaitingToShowArrow()
    {
        yield return new WaitForSeconds(1.5f);
      //  Arrow8.SetActive(true);

    }
    public void ChipOnChecker2Grabbed()
    {
       // Arrow8.SetActive(false);
      //  Arrow6.SetActive(true);
        FrontCoverOnTableGrab.enabled = true;
    }
    public void FrontCoverOnTableGrabbed()
    {
      //  Arrow6.SetActive(false);
        ChipOnKeySnapPointObject.SetActive(true);
      //  SphereObjectChipOnKey.SetActive(true);
      //  SphereHighlightChipOnKey.Highlight();
    }
    public void ChipSnappedToKey()
    {
      //  SphereObjectChipOnKey.SetActive(false);
       // Arrow9.SetActive(true);
        WaitingTraySnapPointObject2.SetActive(true);
    }
    public void KeySnappedToWaitingTray2()
    {
      //  Arrow9.SetActive(false);
      //  Arrow10.SetActive(true);
        BackCoverGrab.enabled = true;
      //  BackCoverInRackHighlight.Highlight();
    }
    public void BackCoverInRackGrabbed()
    {
     //   Arrow10.SetActive(false);
     //   Arrow11.SetActive(true);
     //   SphereObjectBackCoverOnCliper.SetActive(true);
      //  SphereHighlightBackCoverOnCliper.Highlight();
        BackCoverInClippingSnapPointObject.SetActive(true);
    }
    public void BackCoverSnappedToClipping()
    {
       // Arrow11.SetActive(false);
      //  SphereObjectBackCoverOnCliper.SetActive(false);
      //  Arrow12.SetActive(true);
      //  ClipOnTrayHighlight.Highlight();
        ClipOnTrayGrab.enabled = true;
    }
    public void ClipFromTrayGrabbed()
    {
     //   Arrow12.SetActive(false);
      //  Arrow11.SetActive(true);
        ClipInClippingSnapPointObject.SetActive(true);
      //  SphereObjectClipOnKey.SetActive(true);
      //  SphereHighlightClipOnKey.Highlight();

    }
    public void ClipSnappedToKey()
    {
      //  Arrow11.SetActive(false);
      //  SphereObjectClipOnKey.SetActive(false);
      //  ToolHighlight.Highlight();
       // Tooltip5.SetActive(true);
        ToolGrab.enabled = true;
    }
    public void ToolGrabbed()
    {

      //  Tooltip5.SetActive(false);
        ToolcheckSnapPoint.SetActive(true);
        ToolPositionShowingCanvas.SetActive(true);
    }
    public void AfterToolUsed()
    {
        ToolPositionShowingCanvas.SetActive(false);
        ToolSnapPointObject.SetActive(true);
      //  Arrow13.SetActive(true);
    }
    public void ToolSnappedToOrigine()
    {
      //  Arrow13.SetActive(false);
        ClippingScriptObject.SetActive(true);
        clippingMachine.StartClipping();

    }
    public void ClippingMachineProcessDone()
    {
        BackCoverGrabFromClipping.enabled = true;
      //  Arrow11.SetActive(true);
    }
    public void BackCoverGrabbedFromClipping()
    {
       // Arrow11.SetActive(false);
        BackCoverInWaitingSnapPointObject.SetActive(true);
       // Arrow14.SetActive(true);
    }
    public void BackCoverSnappedToWaiting()
    {
      //  Arrow14.SetActive(false);
        KeyFromWaitingGrab.enabled = true;
      //  Arrow9.SetActive(true);
     //   HighlightKeyOnWaiting.Highlight();
    }
    public void KeyGrabbedFromWaiting()
    {
       // Arrow9.SetActive(false);
        KeyOnPunchingSnapPointObject.SetActive(true);
      //  SphereObjectKeyOnPunching.SetActive(true);
      //  SphereHighlightKeyOnPunching.Highlight();
      //  Arrow15.SetActive(true);
    }
    public void KeySnappedToPunching()
    {
      //  Arrow15.SetActive(false);
      //  SphereObjectKeyOnPunching.SetActive(false);
        BackCoverOnWaitingGrab.enabled = true;
       // HighlightBackCoverOnWaiting.Highlight();
      //  Arrow14.SetActive(true);
    }
    public void BackCoverGrabbedFromWaiting()
    {
      //  Arrow14.SetActive(false);
      //  Arrow16.SetActive(true);
        BatteryOnTrayGrab.enabled = true;
      //  HighlightBatteryOnTray.Highlight();
    }
    public void BatteryGrabbedFromTray()
    {
      //  Arrow16.SetActive(false);
        BatterySnapPointObject.SetActive(true);
       // SphereObjectBatteryOnKey.SetActive(true);
       // SphereHighlightBatteryOnKey.Highlight();

    }
    public void BatterySnappedToKey()
    {
       // SphereObjectBatteryOnKey.SetActive(false);
      //  Arrow15.SetActive(true);
        BackCoverOnPunchingSnapPointObject.SetActive(true);
      //  SphereObjectBackCoverOnPunching.SetActive(true);
      //  SphereHighlightBackCoverOnPunching.Highlight();

    }
    public void BackCoverSnappedToPunching()
    {
       // Arrow15.SetActive(false);
      //  SphereObjectBackCoverOnPunching.SetActive(false);
        ScriptObjectPunchingMachine.SetActive(true);
      //  Tooltip6.SetActive(true);
    }
    public void PunchingDone()
    {
        KeyFromPunchingGrab.enabled = true;
      //  Arrow15.SetActive(true);
       // HighlightKeyOnPunching.Highlight();

    }
    public void KeyGrabbedFromPunching()
    {
       // Arrow15.SetActive(false);
      //  Arrow17.SetActive(true);
        KeyOnDoorSnapPointObject.SetActive(true);
      //  SphereObjectKeyOnDoor.SetActive(true);
      //  SphereHighlightKeyOnDoor.Highlight();
    }
    public void KeySnappedToDoor()
    {
       // Arrow17.SetActive(false);
       // SphereObjectKeyOnDoor.SetActive(false);
        //Tooltip7.SetActive(true);
        ScriptObjectDoor.SetActive(true);
    }
    public void DoorClosed()
    {
      //  Tooltip7.SetActive(false);
        StartCoroutine(DoorDisplay());
    }

    public IEnumerator DoorDisplay()
    {
        DoorCheck.SetActive(true);
        yield return new WaitForSeconds(4);
        DoorCheck.SetActive(false);
        DoorOK.SetActive(true);
        drawerP3.Unlock();
      //  Tooltip8.SetActive(true);
    }
    public void DoorOpened()
    {
     //   Tooltip8.SetActive(false);
      //  Arrow17.SetActive(true);
        KeyOnDoorGrab.enabled = true;
    }
    public void KeyGrabbedFromDoor()
    {
     //   Arrow17.SetActive(false);
      //  Arrow18.SetActive(true);
        KeyOnLaserSnapPointObject.SetActive(true);
     //   SphereObjectKeyInLaser.SetActive(true);
     //   SphereHighlightKeyInLaser.Highlight();
    }
    public void KeySnappedToLaser()
    {
     //   Arrow18.SetActive(false);
       // SphereObjectKeyInLaser.SetActive(false);
        laserMachine.StartProcess();


    }
    public void LaserProcessDone()
    {
       // Arrow18.SetActive(true);
        KeyInLaserGrab.enabled = true;

    }
    public void KeyGrabbedFromLaser()
    {
        //Arrow18.SetActive(false);
       // Arrow19.SetActive(true);
        KeyOnFinalTraySnapPointObject.SetActive(true);
      //  SphereObjectKeyInFinalTray.SetActive(true);
      //  SphereHighlightKeyInFinalTray.Highlight();
    }
    public void FinalKeySnapped()
    {
     //   Arrow19.SetActive(false);
      //  SphereObjectKeyInFinalTray.SetActive(false);
        Debug.Log("Final Completed");
    }

}

