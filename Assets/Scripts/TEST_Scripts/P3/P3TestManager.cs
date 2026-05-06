using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class P3TestManager : MonoBehaviour
{
    public M1TooltipActivator tooltipActivator;
    public GameObject ChipChecker1Script;
    public ChipCheckerSnapPoint1 checkerSnapPoint1;
    public ChipChecker1Machine chipChecker1Machine;
    public GameObject ButtonOnUpperCaseSnapPointObject;
    public GameObject ButtonOnNGUpperCaseSnapPointObject;
    public ButtonOnUpperCaseSnapPoint buttonOnUpperCaseSnapPoint;
    public ButtonOnUpperCaseSnapPoint buttonOnNGUpperCaseSnapPoint;
    public TestP3NGRedSnapPoint p3REDNGSnapPoint;
    public MultiDestroyManager manager;
    public GameObject NewUpperCase;
    public GameObject NewUpperCase2;
    public GameObject NewSwitchKnob;
    public GameObject NewSwitchKnob2;
    public P3RubberOnUpperCaseSnapPoint p3RubberOnUpperCase1SnapPoint;
    public P3RubberOnUpperCaseSnapPoint p3RubberOnUpperCase2SnapPoint;
    public P3RubberOnUpperCaseSnapPoint p3RubberOnUpperCase3SnapPoint;
    public XRGrabInteractable PCBOnChipChecker1Grab;
    public GameObject PCBOnChipChecker2SnapPoint;
    public GameObject ChipChecker2Script;
    public ChipCheckerSnapPoint2 chipCheckerSnapPoint2;
    public ChipChecker2Machine chipChecker2Machine;
    public XRGrabInteractable ChipOnChecker2Grab;
    public NGDrawer1P3 nGDrawer1P3;
    public TestP3NGRedSnapPoint testP3NGRedSnapPoint;
    public GameObject NGsnapPointScriptObject;
    public List<GameObject> objectsToActivateAfterChipGrabbed;
    public GameObject GoodChip2OnChecker1Activate;
    public GameObject Chip2OnChecker2SnapPointObject;
    public ChipChecker2SnapPoint2 chipChecker2SnapPoint2;
    public XRGrabInteractable Chip2OnChecker2Grab;
    public ChipOnKeySnapPoint chipOnKey1SnapPoint;
    public ChipOnKeySnapPoint chipOnKey2SnapPoint;
    public ChipOnKeySnapPoint chipOnKey3SnapPoint;
    public GameObject UpperCaseWaitingTraySnapPoint;
    public P3TestBackOnClippingSnapPoint p3TestBackOnClippingSnapPoint;
    public P3TestBackOnClippingSnapPoint p3TestBackOnClippingSnapPoint2;
    public XRGrabInteractable NGLowerCaseOnClippingGrab;
    public GameObject LowerOnClippingSnapPointObject;
    public GameObject LowerOnClippingSnapPointObject2;
    public P3TestClipOnMainSnapPoint p3TestClipOnMainSnapPoint;
    public XRGrabInteractable NGClipFromMainGrab;
    public GameObject ClipOnMainSnapPointObject;
    public GameObject ClipOnMainSnapPointObject2;
    public P3TestClipOnMainSnapPoint p3TestClipOnMainSnapPoint2;
    public GameObject ToolCheckPointObject;
    public ToolScript ToolScript;
    public GameObject ToolOriginalPositionSnapPoint;
    public ToolOriginalPosSnapPoint toolOriginalPosSnapPoint;
    public ClippingMachine clippingMachine;
    public XRGrabInteractable MainFromClippingGrab;
    public GameObject LowerCaseWaitingTraySnapPoint;
    public BackCoverOnWaitingTraySnapPoint backCoverOnWaitingTraySnapPoint;

    [Header("Machine 2")]
    public XRGrabInteractable UpperCaseOnWaitingGrab;
    public GameObject UpperOnPunchingSnapPointObject;
    public P3TestKeyOnPunchingSnapPoint keyOnPunchingSnapPoint;
    public GameObject BatteryToMainSnapPointObject;
    public BatteryOnKeySnapPoint batteryOnKeySnapPoint;

    public GameObject LowerOnPunchingSnapPointObject;
    public BackCoverOnPunchingSnapPoint backCoverOnPunchingSnapPoint;
    public PunchingMachieP3 punchingMachieP3;
    public XRGrabInteractable RubberBiteMainKeyGrab;
    public XRGrabInteractable KnobScratchMainKeyGrab;
    public XRGrabInteractable PushedButtonMainKeyGrab;
    public XRGrabInteractable GoodMainKeyGrab;
    public XRGrabInteractable GoodMainKeyGrab2;

    public NGDrawer2P3 nGDrawer2P3;
    public GameObject NGdrawer2SnapPointObject;
    public P3NG2SnapPoint p3NG2SnapPoint;
    public GameObject GoodKeyOnPunchingActivate;
    public GameObject MainOnDrawerMachineSnappointObject;
    public GoodKeyOnDoorSnapPoint goodKeyOnDoorSnapPoint;
    public GameObject DoorScriptObject;
    public DrawerP3 drawerP3;
    public XRGrabInteractable MainKeyFromDrawerGrab;
    public LaserMachine laserMachine;

    public LaserMachineSnapPoint laserMachineSnapPoint;
    public XRGrabInteractable NGMainkeyFromDrawerGrab;
    public NGDrawer3P3 nGDrawer3P3;
    public GameObject NGBox3SnapPointObject;
    public P3NG3SnapPoint p3NG3SnapPoint;
    public GameObject NewMainKeyOnDrawerActivate;
    public GameObject KeyOnLaserSnapPointObject2;
    public LaserMachineSnapPoint2 laserMachineSnapPoint2;
    public XRGrabInteractable GoodMainkeyFromLaseringGrab;
    public GameObject FinalKeyOnFinalTraySnapPointObject;
    public FinalTraySnapPoint finalTraySnapPoint;


    [Header("UI")]
    public GameObject Checker1CheckButton;
    public GameObject Checker1OKButton;
    [Space]
    public GameObject Checker2CheckButton;
    public GameObject Checker2OKButton;
    public GameObject Checker2NGButton;
    [Space]
    public GameObject DoorDisplayCheckButton;
    public GameObject DoorDisplayOkButton;
    [Space]
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



    public bool NGUpperCaseGrabbed = false;
    public bool GoodUpperCaseGrabbed = false;
    public bool NGRubberGrabbed = false;
    public bool GoodRubberGrabbed = false;
    private bool lastWasNG = false;
    private bool IfNGDisplayShown = false;


    private int NgSnapCount = 0;
    private int Checker2CloseCount = 0;

    private int Checker2OpenCount = 0;
    private int PunchingDoneCount = 0;
    private int LaseringDoneCount = 0;

    private void Awake()
    {
        // Assign functions to each list
        manager.lists[0].onAllDestroyed.AddListener(OnUpperCaseDestroyed);
        manager.lists[1].onAllDestroyed.AddListener(OnSwitchKnobDestroyed);
    }

    void Start()
    {
        checkerSnapPoint1.ChipSnapped += PCBSnappedToChecker1;
        chipChecker1Machine.onReachedDesired += ChipChecker1Closed;
        buttonOnNGUpperCaseSnapPoint.ChipSnapped += ButtonsnappedToBrokenUpper;
        buttonOnUpperCaseSnapPoint.ChipSnapped += ButtonsnappedToGoodUpper;
        p3REDNGSnapPoint.OnObjectActivated += OnDefectSnappedToNGDynamic;
        p3RubberOnUpperCase1SnapPoint.ChipSnapped += RubberOnUppercase1Snapped;
        p3RubberOnUpperCase2SnapPoint.ChipSnapped += RubberOnUppercase2Snapped;
        p3RubberOnUpperCase3SnapPoint.ChipSnapped += RubberOnUppercase3Snapped;
        chipChecker1Machine.onReachedOriginal += ChipChecker1Opened;
        chipCheckerSnapPoint2.ChipSnapped += PCBOnChipChecker2Snapped;
        chipChecker2Machine.onReachedDesired += OnChecker2CloseDynamic;
        chipChecker2Machine.onReachedOriginal += OnChecker2OpenDynamic;
        nGDrawer1P3.onReachedDesired += NGDrawerOpened;
        nGDrawer1P3.onReachedOriginal += NGDrawerClosed;
        chipChecker2SnapPoint2.ChipSnapped += Chip2OnChecker2Snapped;
        testP3NGRedSnapPoint.OnObjectActivated += NGChipSnappedToNGBox;

        chipOnKey1SnapPoint.ChipOnKeySnapped += ChipSnappedToKey;
        chipOnKey2SnapPoint.ChipOnKeySnapped += ChipSnappedToKey;
        chipOnKey3SnapPoint.ChipOnKeySnapped += ChipSnappedToKey;
        p3TestBackOnClippingSnapPoint.ChipSnapped += LowerCaseOnClippingSnapped;
        p3TestBackOnClippingSnapPoint2.ChipSnapped += LowerCaseOnClippingSnapped2;
        p3TestClipOnMainSnapPoint.ChipSnapped += ClipOnMainSnapped;
        p3TestClipOnMainSnapPoint2.ChipSnapped += ClipOnMainSnapped2;
        ToolScript.MarkingDone += MarkingDoneOnClip;
        toolOriginalPosSnapPoint.ToolSnapped += ToolSnappedBackToPos;
        clippingMachine.onReachedOriginal += ClippingDone;
        backCoverOnWaitingTraySnapPoint.BackCoverOnWaitingSnapped += LowerCaseSnappedToWaitingTray;
        keyOnPunchingSnapPoint.KeyOnPunchingSnapped += UpperOnPunchingSnapped;
        batteryOnKeySnapPoint.BatterySnapped += BatteryToMainSnapped;
        backCoverOnPunchingSnapPoint.BackSnappedOnPunching += LowerOnPunchingSnapped;
        punchingMachieP3.onReachedOriginal += OnPunchingDoneDynamic;
        nGDrawer2P3.onReachedDesired += NgDrawer2Opened;
        nGDrawer2P3.onReachedOriginal += NgDrawer2Closed;
        p3NG2SnapPoint.OnObjectActivated += RubberBiteMainSnappedToNGBox;
        goodKeyOnDoorSnapPoint.KeyOnDoorSnapped += MainKeySnappedToDrawer;
        drawerP3.onReachedDesired += DoorClosed;
        drawerP3.onReachedOriginal += DoorOpened;
        laserMachineSnapPoint.KeySnapped += MainKeySnappedToLasering;
        laserMachine.LaserMachineDone += OnLaseringDoneDynamic;

        nGDrawer3P3.onReachedDesired += NGbox3Opened;
        nGDrawer3P3.onReachedOriginal += NGbox3Closed;
        p3NG3SnapPoint.OnObjectActivated += NGLaserMainKeySnappedToNGBox;
        laserMachineSnapPoint2.KeySnapped += KeySnappedToLasering;
        finalTraySnapPoint.FinalKeySnapped += TestCompleted;

    }
    private void OnDefectSnappedToNGDynamic(GameObject obj)
    {
        NgSnapCount++;
        Debug.Log($"[{NgSnapCount}] Received event: {obj.name} just activated!");

        switch (NgSnapCount)
        {
            case 1:
                //CrackFrontCoverSnappedToNGBox(obj);
                break;

            case 2:
                //BrokenButtonSnappedToNGBox(obj);
                break;

            case 3:
                //CutRubberCoverSnappedToNGBox(obj);
                break;
            case 4:
                // ScratchBackCoverSnappedToNGBox(obj);
                break;
            case 5:
                // NGClipSnappedToNGBox(obj);
                break;
            default:
                Debug.Log("Additional activations beyond the third.");
                break;
        }
    }
    private void OnChecker2CloseDynamic()
    {
        Checker2CloseCount++;

        Debug.Log($"Drawer opened {Checker2CloseCount} times");

        switch (Checker2CloseCount)
        {
            case 1:
                ChipChecker2ClosingDone();
                break;
            case 2:
                ChipChecker2ClosingDone2();
                break;

            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    private void OnChecker2OpenDynamic()
    {
        Checker2OpenCount++;

        Debug.Log($"Drawer opened {Checker2OpenCount} times");

        switch (Checker2OpenCount)
        {
            case 1:
                ChipChecker2OpeningDone();
                break;
            case 2:
                ChipChecker2OpeningDone2();
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

            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    private void OnLaseringDoneDynamic()
    {
        LaseringDoneCount++;

        Debug.Log($"Drawer opened {LaseringDoneCount} times");

        switch (LaseringDoneCount)
        {
            case 1:
                LaserProcessDone();
                break;
            case 2:
                LaserProcessDone2();
                break;

            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    public void PCBFromTrayGrabbed()
    {
    }
    public void PCBSnappedToChecker1()
    {
        ChipChecker1Script.SetActive(true);
    }
    public void ChipChecker1Closed()
    {
        StartCoroutine(CheckerDisplay1());
    }
    public IEnumerator CheckerDisplay1()
    {
        Checker1CheckButton.SetActive(true);
        yield return new WaitForSeconds(3);
        Checker1CheckButton.SetActive(false);
        Checker1OKButton.SetActive(true);
    }
    public void ChipChecker1Opened()
    {
        PCBOnChipChecker1Grab.enabled = true;
        tooltipActivator.DeactivateObject(0);
    }

    public void UpperCaseFromTrayGrabbed()
    {
        GoodUpperCaseGrabbed = true;
        ButtonOnUpperCaseSnapPointObject.SetActive(true);
    }
    public void NGUpperCaseFromTrayGrabbed()
    {
        NGUpperCaseGrabbed = true;
        ButtonOnNGUpperCaseSnapPointObject.SetActive(true);
    }
    public void ButtonsnappedToBrokenUpper(string result)
    {
        if (result == "Good" && NGUpperCaseGrabbed)
        {
            Debug.Log("PCB good and cover NG ");
            tooltipActivator.ActivateObject(2);
        }
        else if (result == "Defect" && NGUpperCaseGrabbed)
        {
            tooltipActivator.ActivateObject(3);
            Debug.Log("Pin broken tooltip show");
        }
    }
    public void ButtonsnappedToGoodUpper(string result)
    {
        if (result == "Good" && GoodUpperCaseGrabbed)
        {
            Debug.Log("PCB good and cover NG ");
            tooltipActivator.ActivateObject(0);
        }
        else if (result == "Defect" && GoodUpperCaseGrabbed)
        {
            tooltipActivator.ActivateObject(4);
            Debug.Log("Pin broken tooltip show");
        }
    }
    private void OnUpperCaseDestroyed()
    {
        NewUpperCase.SetActive(true);
        NewUpperCase2.SetActive(true);
    }
    private void OnSwitchKnobDestroyed()
    {
        NewSwitchKnob.SetActive(true);
        NewSwitchKnob2.SetActive(true);
    }
    public void RubberFromTrayGrabbed()
    {
        GoodRubberGrabbed = true;
        tooltipActivator.DeactivateObject(0);

    }
    public void NGRubberFromTrayGrabbed()
    {
        NGRubberGrabbed = true;
        tooltipActivator.DeactivateObject(0);
    }
    public void RubberOnUppercase1Snapped(string result)
    {
        if (result == "Good")
        {
            Debug.Log("PCB good and cover NG ");
            tooltipActivator.ActivateObject(0);
            chipChecker1Machine.Unlock();

        }
        else if (result == "Defect")
        {
            tooltipActivator.ActivateObject(5);
            Debug.Log("Pin broken tooltip show");
        }
    }
    public void RubberOnUppercase2Snapped(string result)
    {
        if (result == "Good")
        {
            Debug.Log("PCB good and cover NG ");
            tooltipActivator.ActivateObject(0);
            chipChecker1Machine.Unlock();


        }
        else if (result == "Defect")
        {
            tooltipActivator.ActivateObject(6);
            Debug.Log("Pin broken tooltip show");
        }
    }
    public void RubberOnUppercase3Snapped(string result)
    {
        if (result == "Good")
        {
            Debug.Log("PCB good and cover NG ");
            tooltipActivator.ActivateObject(0);
            chipChecker1Machine.Unlock();

        }
        else if (result == "Defect")
        {
            tooltipActivator.ActivateObject(7);
            Debug.Log("Pin broken tooltip show");
        }
    }

    public void PCBFromChecker1Grabbed()
    {
        PCBOnChipChecker2SnapPoint.SetActive(true);
    }
    public void PCBOnChipChecker2Snapped()
    {
        ChipChecker2Script.SetActive(true);
    }
    public void ChipChecker2ClosingDone()
    {
        ChipChecker2Closed();
    }
    public void ChipChecker2Closed()
    {
        if (lastWasNG)
        {
            // Call OK version
            StartCoroutine(CheckerDisplay2());
            lastWasNG = false;   // Next time NG will run
        }
        else
        {
            // Call NG version
            StartCoroutine(CheckerDisplay2NG());
            lastWasNG = true;    // Next time OK will run
        }
    }
    public IEnumerator CheckerDisplay2()
    {
        Checker2NGButton.SetActive(false);
        Checker2CheckButton.SetActive(true);
        yield return new WaitForSeconds(3);
        Checker2CheckButton.SetActive(false);
        Checker2OKButton.SetActive(true);
        chipChecker2Machine.Unlock();
    }
    public IEnumerator CheckerDisplay2NG()
    {
        Checker2OKButton.SetActive(false);
        Checker2CheckButton.SetActive(true);
        yield return new WaitForSeconds(3);
        Checker2CheckButton.SetActive(false);
        Checker2NGButton.SetActive(true);
        chipChecker2Machine.Unlock();
        IfNGDisplayShown = true;
    }
    public void ChipChecker2OpeningDone()
    {
        ChipChecker2Opened();
    }
    public void ChipChecker2Opened()
    {
        ChipOnChecker2Grab.enabled = true;
    }
    public void ChipFromChecker2Grabbed()
    {
        if (IfNGDisplayShown)
        {
            GoodChip2OnChecker1Activate.SetActive(true);
        }
        else
        {
            foreach (var obj in objectsToActivateAfterChipGrabbed)
            {
                if (obj != null)
                    obj.SetActive(true);
            }
        }
    }
    public void NGDrawerOpened()
    {
        NGsnapPointScriptObject.SetActive(true);
    }
    public void NGChipSnappedToNGBox(GameObject obj)
    {
        nGDrawer1P3.Unlock();
    }
    public void NGDrawerClosed()
    {
        NGsnapPointScriptObject.SetActive(false);
    }
    public void Chip2OnChecker1Grabbed()
    {
        Chip2OnChecker2SnapPointObject.SetActive(true);
    }
    public void Chip2OnChecker2Snapped()
    {

    }
    public void ChipChecker2ClosingDone2()
    {
        ChipChecker2Closed();
    }
    public void ChipChecker2OpeningDone2()
    {
        ChipChecker2Opened2();
    }
    public void ChipChecker2Opened2()
    {
        Chip2OnChecker2Grab.enabled = true;
    }
    public void Chip2FromChecker2Grabbed()
    {
        foreach (var obj in objectsToActivateAfterChipGrabbed)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }
    public void ChipSnappedToKey()
    {
        UpperCaseWaitingTraySnapPoint.SetActive(true);
    }
    public void NGLowerCaseFromTrayGrabbed()
    {
        LowerOnClippingSnapPointObject.SetActive(true);
    }
    public void GoodLowerCaseFromTrayGrabbed()
    {

        if (NGLowerCaseGrabbed)
        {
            LowerOnClippingSnapPointObject2.SetActive(true);
        }
        else
        {
            LowerOnClippingSnapPointObject.SetActive(true);
        }
    }
    private bool NGLowerCaseGrabbed = false;
    public void LowerCaseOnClippingSnapped(string result)
    {
        if (result == "Good")
        {
            Debug.Log("Good lower snapped to clipper");
            ClipOnMainSnapPointObject.SetActive(true);
        }
        else if (result == "Defect")
        {
            tooltipActivator.ActivateObject(8);
            NGLowerCaseOnClippingGrab.enabled = true;
            NGLowerCaseGrabbed = true;
            Debug.Log("Pin broken tooltip show");
        }
    }
    public void LowerCaseOnClippingSnapped2(string result)
    {
        if (result == "Good")
        {
            Debug.Log("Good lower snapped to clipper");
            ClipOnMainSnapPointObject.SetActive(true);
        }
        else if (result == "Defect")
        { 
            Debug.Log("Pin broken tooltip show");
        }
    }

    public void ClipOnMainSnapped(string result)
    {
        if(result == "Good")
        {

        }
        else if (result == "Defect")
        {
            tooltipActivator.ActivateObject(9);
            NGClipFromMainGrab.enabled = true;
        }
    }
    public void NGClipFromMainGrabbed()
    {
        ClipOnMainSnapPointObject2.SetActive(true);
    }
    public void ClipOnMainSnapped2(string result)
    {
        if (result == "Good")
        {

        }
        else if (result == "Defect")
        {

        }
    }

    public void ToolGrabbed()
    {
        ToolCheckPointObject.SetActive(true);
    }

    public void MarkingDoneOnClip()
    {
        ToolOriginalPositionSnapPoint.SetActive(true);
    }
    public void ToolSnappedBackToPos()
    {
        clippingMachine.StartClipping();
    }
    public void ClippingDone()
    {
        MainFromClippingGrab.enabled = true;
    }
    public void MainFromClippingGrabbed()
    {
        LowerCaseWaitingTraySnapPoint.SetActive(true);
    }
    public void LowerCaseSnappedToWaitingTray()
    {
        UpperCaseOnWaitingGrab.enabled = true;
    }

    public void UpperFromWaitingGrabbed()
    {
        UpperOnPunchingSnapPointObject.SetActive(true);
    }
    public void UpperOnPunchingSnapped()
    {
    }
    public void LowerFromWaitingGrabbed()
    {
       
    }
    public void BatteryFromTrayGrabbed()
    {
        BatteryToMainSnapPointObject.SetActive(true);
    }
    public void BatteryToMainSnapped()
    {
        LowerOnPunchingSnapPointObject.SetActive(true);
    }
    public void LowerOnPunchingSnapped()
    {
    }
    public void PunchingProcessDone()
    {
        PunchingDone();
    }

    public void PunchingDone()
    {
        RubberBiteMainKeyGrab.enabled = true;
        KnobScratchMainKeyGrab.enabled = true;
        PushedButtonMainKeyGrab.enabled = true;
      //  GoodMainKeyGrab.enabled = true;
}
    public void RubberBiteGrabbedCallID1()
    {
        StartCoroutine(ShowTooltipAfter1());
    }

    public void KnobScratchGrabbedCallID2()
    {
        StartCoroutine(ShowTooltipAfter2());
    }

    public void PushedInsideGrabbedCallID3()
    {
        StartCoroutine(ShowTooltipAfter3());
    }
    public void GoodKeyFromPunchingGrabbed()
    {
        StartCoroutine(GoodTooltipShowAfter4());
    }
    public IEnumerator ShowTooltipAfter1()
    {
        yield return new WaitForSeconds(3);
        tooltipActivator.ActivateObject(10);
    }
    public IEnumerator ShowTooltipAfter2()
    {
        yield return new WaitForSeconds(3);
        tooltipActivator.ActivateObject(11);
    }
    public IEnumerator ShowTooltipAfter3()
    {
        yield return new WaitForSeconds(3);
        tooltipActivator.ActivateObject(12);
    }

    public IEnumerator GoodTooltipShowAfter4()
    {
        yield return new WaitForSeconds(3);
        tooltipActivator.ActivateObject(0);
        MainOnDrawerMachineSnappointObject.SetActive(true);
    }
    public void NgDrawer2Opened()
    {
        NGdrawer2SnapPointObject.SetActive(true);
    }
    public void RubberBiteMainSnappedToNGBox(GameObject obj)
    {
        GoodKeyOnPunchingActivate.SetActive(true);
        punchingMachieP3.Unlock();
        nGDrawer2P3.Unlock();
    }
    public void NgDrawer2Closed()
    {
        NGdrawer2SnapPointObject.SetActive(false);
    }
    public void PunchingProcessDone2()
    {
        PunchingDone2();
    }
    public void PunchingDone2()
    {      
        GoodMainKeyGrab.enabled = true ;
        GoodMainKeyGrab2.enabled = true ;
    }

    public void MainKeySnappedToDrawer()
    {
        DoorScriptObject.SetActive(true);
        tooltipActivator.DeactivateObject(0);

    }
    public void DoorClosed()
    {
        StartCoroutine(ShowDoorDisplay());
    }
    public IEnumerator ShowDoorDisplay()
    {
        DoorDisplayCheckButton.SetActive(true);
        yield return new WaitForSeconds(4);
        DoorDisplayCheckButton.SetActive(false);
        DoorDisplayOkButton.SetActive(true);
        drawerP3.Unlock();
    }
    public void DoorOpened()
    {
        MainKeyFromDrawerGrab.enabled = true;
    }
    public void MainKeyFromDrawerGrabbed()
    {
    }
    public void MainKeySnappedToLasering()
    {
        laserMachine.StartProcess();
        StartCoroutine(DisplayOfDrawerNG());
    }
    public IEnumerator DisplayOfDrawerNG()
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
    public void LaserProcessDone()
    {
        LaseringDone();
    }
    public void LaseringDone()
    {
        NGMainkeyFromDrawerGrab.enabled = true;
    }
    public void NGbox3Opened()
    {
        NGBox3SnapPointObject.SetActive(true);
    }
    public void NGLaserMainKeySnappedToNGBox(GameObject obj)
    {
        nGDrawer3P3.Unlock();
        NewMainKeyOnDrawerActivate.SetActive(true);
    }
    public void NGbox3Closed()
    {
        NGBox3SnapPointObject.SetActive(false);
    }
    public void NewMainKeyOnDrawerGrabbed()
    {
        KeyOnLaserSnapPointObject2.SetActive(true);
    }
    public void KeySnappedToLasering()
    {
        laserMachine.StartProcess();
        StartCoroutine(DisplayOfDrawerOK());
    }
    public IEnumerator DisplayOfDrawerOK()
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
    public void LaserProcessDone2()
    {
        LaseringDone2();
    }
    public void LaseringDone2()
    {
        GoodMainkeyFromLaseringGrab.enabled = true;
    }

    public void GoodFinalKeyFromLaseringGrabbed()
    {
        FinalKeyOnFinalTraySnapPointObject.SetActive(true);
    }
    public void TestCompleted()
    {
        CongratsMessage.SetActive(true);
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
