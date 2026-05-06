using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class P2TestManager : MonoBehaviour
{
    public M1TooltipActivator tooltipActivator;
    [Header(" Chip and NG Chip ")]
    public ChipOnDrawer1TestSnapPoint chipOnDrawer1TestSnapPoint;
    public GameObject ChipOnDrawerSnapPoint;
    public NGDrawer1P2 nGDrawer1P2;
    public GameObject NG1SnapPointObject;
    public P2NG1SnapPoint p2NG1SnapPoint;
    public DrawerP2Elextric drawerDoor;
    public DrawerHandleP2Elextric drawerHandle;
    public GameObject DrawerDoorScriptObject;
    public GameObject DrawerHandleScriptObject;
    public XRGrabInteractable NGChipFromDrawerGrab;
    public XRGrabInteractable GoodChipFromDrawerGrab;
    [Header(" Machine 2 ")]
    public GameObject ChipCheckerSnapPoint;
    public ChipToChipCheckerSnapPoint chipToChipCheckerSnapPoint;
    public CheckerHandle checkerHandle;
    public UnlockSnapPointP2Test unlockSnapPointP2Test;
    public UnlockSnapPointP2Test NGunlockSnapPointP2Test;
    public LockSnapPointP2Test lockSnapPointP2Test;
    public LockSnapPointP2Test NGlockSnapPointP2Test;
    public RubberSnapPointP2Test rubberSnapPointP2Test;
    public ChipToBackSnapPointP2Test chipToBackSnapPointP2Test;
    public ChipToBackSnapPointP2Test Good2hipToBackSnapPoint;
    public GameObject GoodBackCover2Activate;
    public RubberSnapPointP2Test Good2BackrubberSnapPoint;
    public NGDrawer2P2 nGDrawer2P2;
    public GameObject NG2SnapPointObject;
    public P2NG2SnapPointTest p2NG2SnapPointTest;
    [Space]
    public GameObject BackCoverOnPunchingSnapPoint;
    public CoverOnPunchingP2Test coverOnPunchingP2Test;
    public PunchingMachine punchingMachine;
    public BatteryCoverSnapPoint NGbatteryCoverSnapPoint;
    public XRGrabInteractable DeforCoverFromAssyGrab;
    public BatterySnapPoint batterySnapPoint;
    public GameObject GoodBackCoverOnPunchingActivate;
    public XRGrabInteractable GoodCoverFromPunchingGrab;

    [Header(" Machine 3 ")]
    public GameObject BackCoverOnAssySnapPoint;
    public BackCoverOnAssembly backCoverOnAssembly;
    public GameObject FrontCoverOnAssySnapPoint;
    public FrontOnAssySnapPointP2Test frontCoverOnPunchingP2Test;
    public GreenButtonP2Test greenButton;
    public XRGrabInteractable GoodFrontFromAssyGrab;
    public XRGrabInteractable NGFrontFromAssyGrab;
    public GameObject FrontCoverToBackSnapPointObject;
    public NGDrawer3P2 nGDrawer3P2;
    public GameObject NG3SnapPointObject;
    public P2NG3SnapPoint p2NG3SnapPoint;
    public FrontOnBackSnapPoint frontOnBackSnapPoint;
    public GameObject SlidingScriptActivate;
    public PunchingSlidingScript punchingSlidingScript;
    public GameObject PunchingScriptObject;
    public PunchingMachine2 punchingMachine2;
    public XRGrabInteractable MainFromAssyGrab;
    public GameObject KeySnapPointObject;
    public KeySnapPoint keySnapPoint;

    [Header(" Machine 4 ")]
    public RemoteKeySnapPoint remoteKeySnapPoint;
    public Drawer2P2Test drawer2;
    public XRGrabInteractable MainFromDoor2Grab;
    [Header(" Machine 5 ")]
    public GameObject RemoteKeyOnLaserSnapPointObject;
    public RemoteKeyOnLaserSnapPoint remoteKeyOnLaserSnapPoint;
    public LaserMachine laserMachine;
    public XRGrabInteractable NGMainFromLaserGrab;
    public NGDrawer5P2 nGDrawer5;
    public GameObject NGSnapPointObject5;
    public P2NG5SnapPoint p2NG5SnapPoint;
    public GameObject GoodOnDoor2Activate;
    public GameObject MainKey2OnLaserSnapPoint2;
    public RemoteKeyOnLaserSnapPoint2 remoteKeyOnLaserSnapPoint2;
    public XRGrabInteractable GoodMainFromLaserGrab;
    [Header(" Machine 6 ")]
    public GameObject RemoteKeyInBoxMachineSnapPointObject;
    public RemoteKeyInBoxSnapPoint remoteKeyInBoxSnapPoint;
    public GameObject Door3ScriptObject;
    public BoxDoorMovement boxDoorMovement;
    public XRGrabInteractable NGRemoteKeyFromBoxGrab;
    public GameObject NG6SnapPointObject;
    public NGDrawer6P2 nGDrawer6P2;
    public P2NG6SnapPoint p2NG6SnapPoint;
    public GameObject MainKey2OnLaserActivate;
    public XRGrabInteractable KeyFromMainGrab;
    public Collider KeyCollider;
    public GameObject KeyOnTableSnapPoint;
    public KeyOnTableSnapPoint keyOnTableSnapPoint;
    public GameObject RemoteKeyOnBoxSnapPoint2;
    public RemoteKeyInBoxSnapPoint2 remoteKeyInBoxSnapPoint2;
    public XRGrabInteractable GoodRemoteKeyFromBoxGrab;
    public XRGrabInteractable Key2FromMainGrab;
    public Collider KeyCollider2;
    public GameObject KeyOnTableSnapPoint2;
    public KeyOnTableSnapPoint2 keyOnTableSnapPoint2;
    public GameObject MainKeyToFinalTraySnapPoint;
    public FinalKeyInBoxSnapPoint finalKeyInBoxSnapPoint;


    [Header(" Drawer Box Display UI")]
    public GameObject Button1;
    public GameObject Button2;
    public GameObject ButtonNG;
    [Header(" Checker Display UI ")]
    public GameObject CheckerButton1;
    public GameObject CheckerButtonOK;
    [Header(" Door 2 Display ")]
    public GameObject Door2Button1;
    public GameObject Door2Button2;
    public GameObject Door2ButtonNG;

    [Header("Laser Machine Display")]
    public GameObject BackButtonCheck;
    public GameObject BackNGButton;
    public GameObject ButtonCheck;
    public GameObject ButtonNG1;
    public GameObject ButtonNG2;
    public GameObject ButtonNG3;
    public GameObject ButtonNG4;
    public GameObject ButtonOK4;
    public GameObject BackOkButton;
    public GameObject ButtonOK1;
    public GameObject ButtonOK2;
    public GameObject ButtonOK3;
    public GameObject ButtonOK5;
    public GameObject ButtonOK6;
    [Header(" Machine 6 Display ")]
    public GameObject CheckButton;
    public GameObject CheckButtonOK;
    public GameObject CheckButtonNG;

    public GameObject CongratsMessage;

    private bool NGChipGrab = false;
    private bool GoodChipGrab = false;
    private bool isPcbDefective = false;
    private int OnCoverSnappedToPunchingCount = 0;
    private int PunchingDoneCount = 0;
    private int LaserDoneCount = 0;
    private int BoxDoorCloseCount = 0;
    private int BoxDoorOpenCount = 0;
    void Start()
    {
        chipOnDrawer1TestSnapPoint.ChipSnapped += PCBsnappedToDrawer;
        nGDrawer1P2.onReachedDesired += NGDrawer1Opened;
        p2NG1SnapPoint.OnObjectActivated += NGchipSnappedToNGBox;
        drawerDoor.onReachedDesired += DoorClosed;
        drawerHandle.onReachedDesired += HandleClosed;
        drawerHandle.onReachedOriginal += HandleOpened;
        chipToChipCheckerSnapPoint.ChipsnappedToChecker += ChipSnappedToChecker;
        checkerHandle.onReachedDesired += CheckerClosed;
        NGunlockSnapPointP2Test.UnlockSnapped += UnLocksnappedToNGBack;
        unlockSnapPointP2Test.UnlockSnapped += UnLocksnappedToGoodBack;
        lockSnapPointP2Test.LockSnapped += LocksnappedToGoodBack;
        NGlockSnapPointP2Test.LockSnapped += LocksnappedToNGBack;
        rubberSnapPointP2Test.RubberSnapped += RubberSnappedToGoodBack;
        Good2BackrubberSnapPoint.RubberSnapped += RubberSnappedToGoodBack;
        checkerHandle.onReachedOriginal += CheckerOpened;
        chipToBackSnapPointP2Test.ChipSnapped += ChipSnappedToGoodBack;
        Good2hipToBackSnapPoint.ChipSnapped += ChipSnappedToGoodBack2;
        nGDrawer2P2.onReachedDesired += NGDrawer2Opened;
        nGDrawer2P2.onReachedOriginal += NGDrawer2Closed;
        p2NG2SnapPointTest.OnObjectActivated += NGScratchBackCover;
        coverOnPunchingP2Test.OnObjectActivated += OnCoverSnappedToPunchingDynamic;
        punchingMachine.onReachedOriginal += OnPunchingDoneDynamic;
        NGbatteryCoverSnapPoint.BatteryPlacerSnapped += BatteryPlacerSnapped;
        batterySnapPoint.BatterySnapped += BatterySnapped;
        backCoverOnAssembly.BackOnMachineSnapped += BackCoverOnAssySnapped;
        frontCoverOnPunchingP2Test.ChipSnapped += FrontCoverSnappedToAssy;
        greenButton.CameraChecked += GreenButtonPressed;
        nGDrawer3P2.onReachedDesired += NGDrawer3Opened;
        nGDrawer3P2.onReachedOriginal += NGDrawer3Closed;
        p2NG3SnapPoint.OnObjectActivated += NGScratchFrontCover;
        frontOnBackSnapPoint.FrontOnBackSnapped += FrontOnBackCoverSnapped;
        punchingSlidingScript.onReachedDesired += SliderPushed;
        punchingSlidingScript.onReachedOriginal += SliderPulled;
        punchingMachine2.onReachedOriginal += AssyPunchingDone;
        keySnapPoint.KeySnapped += KeySnappedToMain;
        remoteKeySnapPoint.RemoteKeySnapped += MainSnappedToDrawer;
        drawer2.onReachedDesired += Door2Closed;
        drawer2.onReachedOriginal += Door2Opened;
        remoteKeyOnLaserSnapPoint.RemoteKeySnapped += MainKeyToLaserMachineSnapped;
        laserMachine.LaserMachineDone += OnLaseringDoneDynamic;
        nGDrawer5.onReachedDesired += NGDrawer5Opened;
        p2NG5SnapPoint.OnObjectActivated += NGMainKeySnappedToNGBox5;
        nGDrawer5.onReachedOriginal += NGDrawer5Closed;
        remoteKeyOnLaserSnapPoint2.RemoteKeySnapped += MainKey2ToLaserMachineSnapped;
        remoteKeyInBoxSnapPoint.RemoteKeySnappedToBox += MainKeySnappedToBox;
        boxDoorMovement.onReachedDesired += OnBoxDoorCloseDynamic;
        boxDoorMovement.onReachedOriginal += OnBoxDoorOpenDynamic;
        nGDrawer6P2.onReachedDesired += NGdrawer6Opened;
        p2NG6SnapPoint.OnObjectActivated += NGOnBoxDoorSnapped;
        nGDrawer6P2.onReachedOriginal += NGdrawer6Closed;
        keyOnTableSnapPoint.KeySnappedToTable += KeySnappedToTable;
        remoteKeyInBoxSnapPoint2.RemoteKeySnappedToBox += RemoteKey2OnBoxSnapped;
        keyOnTableSnapPoint2.KeySnappedToTable += Key2SnappedToTable;
        finalKeyInBoxSnapPoint.FinalKeySnapped += FinalKeySnappedToTray;


    }
    private void OnCoverSnappedToPunchingDynamic(GameObject obj)
    {
        OnCoverSnappedToPunchingCount++;
        Debug.Log($"[{OnCoverSnappedToPunchingCount}] Received event: {obj.name} just activated!");

        switch (OnCoverSnappedToPunchingCount)
        {
            case 1:
                CoverSnappedToPunching(obj); // Deformation
                break;

            case 2:
               //
                break;

            case 3:
               //
                break;

            default:
                Debug.Log("Additional activations beyond the third.");
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
                Debug.Log("done punching");
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

    private void OnLaseringDoneDynamic()
    {
        LaserDoneCount++;

        Debug.Log($"Drawer opened {LaserDoneCount} times");

        switch (LaserDoneCount)
        {
            case 1:
                LaseringDone();
                break;
            case 2:
                LaseringDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    private void OnBoxDoorCloseDynamic()
    {
        BoxDoorCloseCount++;

        Debug.Log($"Drawer opened {BoxDoorCloseCount} times");

        switch (BoxDoorCloseCount)
        {
            case 1:
                BoxDoorClosingDone();
                break;
            case 2:
                BoxDoorClosingDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnBoxDoorOpenDynamic()
    {
        BoxDoorOpenCount++;

        Debug.Log($"Drawer opened {BoxDoorOpenCount} times");

        switch (BoxDoorOpenCount)
        {
            case 1:
                BoxDoorOpeningDone();
                break;
            case 2:
                BoxDoorOpeningDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    public void NGchipOnTrayGrabbed()
    {
        NGChipGrab = true;
        ChipOnDrawerSnapPoint.SetActive(true);
    }
    public void GoodChipOnTrayGrabbed()
    {
        GoodChipGrab = true;
        ChipOnDrawerSnapPoint.SetActive(true);

    }
    public void NGchipSnappedToNGBox(GameObject obj)
    {
        //score
    }
    public void NGScratchBackCover(GameObject obj)
    {
        //score
    }
    public void NGScratchFrontCover(GameObject obj)
    {
        //Score
    }
    public void NGDrawer1Opened()
    {
        nGDrawer1P2.Unlock();
        NG1SnapPointObject.SetActive(true);
        //score
    }
    public void NGDrawer1Closed()
    {
        NG1SnapPointObject.SetActive(false);
    }
    public void NGDrawer2Opened()
    {
        nGDrawer2P2.Unlock();
        NG2SnapPointObject.SetActive(true);
    }

    public void NGDrawer2Closed()
    {
        NG2SnapPointObject.SetActive(false);
        if(DeforBackCoverGrab)
        {
            GoodBackCoverOnPunchingActivate.SetActive(true);
            DeforBackCoverGrab = false;
        }
    }
    public void NGDrawer3Opened()
    {
        NG3SnapPointObject.SetActive(true);
        nGDrawer3P2.Unlock();
    }
    public void NGDrawer3Closed()
    {
        NG3SnapPointObject.SetActive(false);

    }

    public void PCBsnappedToDrawer(string result)
    {
        if (result == "Good") // pcb good and cover NG
        {
            isPcbDefective = false;

        }
        else if (result == "Defect") // PCB NG and Cover NG
        {
            isPcbDefective = true;
        }
    }
   
    public void DoorClosed()
    {
        
        DrawerDoorScriptObject.SetActive(false);
        DrawerHandleScriptObject.SetActive(true);
    }
    public void HandleClosed()
    {
        StopAllCoroutines(); // avoid multiple coroutines running

        if (isPcbDefective)
            StartCoroutine(DoorDisplayNG());
        else
            StartCoroutine(DoorDisplay());

    }

    public IEnumerator DoorDisplay()
    {
        ButtonNG.SetActive(false);
        Button1.SetActive(true);
        yield return new WaitForSeconds(4);
        Button1.SetActive(false);
        Button2.SetActive(true);
        drawerHandle.Unlock();
        GoodChipFromDrawerGrab.enabled = true;
    }
    public IEnumerator DoorDisplayNG()
    {
        Button2.SetActive(false);
        Button1.SetActive(true);
        yield return new WaitForSeconds(4);
        Button1.SetActive(false);
        ButtonNG.SetActive(true);
        drawerHandle.Unlock();
        NGChipFromDrawerGrab.enabled = true;
    }
    public void HandleOpened()
    {
        DrawerDoorScriptObject.SetActive(true);
        DrawerHandleScriptObject.SetActive(false);
        drawerDoor.Unlock();
    }

    public void NGChipFromDrawerGrabbed()
    {
      
    }
    public void GoodChipFromDrawerGrabbed()
    {
        ChipCheckerSnapPoint.SetActive(true);
        
    }
    public void ChipSnappedToChecker()
    {
    }
    public void CheckerClosed()
    {
        StartCoroutine(CheckerDisplay());
    }
    public IEnumerator CheckerDisplay()
    {
        CheckerButton1.SetActive(true);
        yield return new WaitForSeconds(10);
        CheckerButton1.SetActive(false);
        CheckerButtonOK.SetActive(true);
    }
    private bool NGBackCoverPicked = false;
    private bool GoodBackCoverPicked = false;
    private bool GoodBackCoverPicked2 = false;
    private bool BatteryPlacerGrab = false;
    private bool DeforBackCoverGrab = false;
    public void NGBackCoverGrabbed()
    {
        NGBackCoverPicked = true;
    }
    public void GoodBackCoverGrabbed()
    {
        GoodBackCoverPicked=true;
    }
    public void Good2BackCoverGrabbed()
    {
        GoodBackCoverPicked2 = true;
    }
    public void LocksnappedToGoodBack(string result)
    {
        if (result == "Good" && GoodBackCoverPicked) 
        {      
        }
    }
    public void LocksnappedToNGBack(string result)
    {
        if (result == "Good" && NGBackCoverPicked)
        {
            tooltipActivator.ActivateObject(1);

        }
        else if (result == "Defect" && NGBackCoverPicked)
        { 
        }
    }
    public void UnLocksnappedToGoodBack(string result)
    {
        if (result == "Good" && GoodBackCoverPicked) 
        {
            //score
        }
        else if (result == "Defect" && GoodBackCoverPicked)
        {
            tooltipActivator.ActivateObject(0);
            GoodBackCover2Activate.SetActive(true);
        }
    }
    public void UnLocksnappedToNGBack(string result)
    {
        if (result == "Good" && NGBackCoverPicked)
        {
            tooltipActivator.ActivateObject(1);

        }
        else if (result == "Defect" && NGBackCoverPicked)
        {
            tooltipActivator.ActivateObject(2);
        }
    }
    public void RubberFromTrayGrabbed()
    {
    }
    public void RubberSnappedToGoodBack(string result)
    {
        if (result == "Good" && GoodBackCoverPicked)
        {
            checkerHandle.Unlock();
        }
    }
    public void CheckerOpened()
    {
    }
    public void ChipSnappedToGoodBack(string result)
    {
        if (result == "Good" && GoodBackCoverPicked) 
        {
            //score
            BackCoverOnPunchingSnapPoint.SetActive(true);
        }
    }
    public void ChipSnappedToGoodBack2(string result)
    {
        if (result == "Good" && GoodBackCoverPicked)
        {
            //score
            BackCoverOnPunchingSnapPoint.SetActive(true);
        }
    }
    public void CoverSnappedToPunching(GameObject obj)
    {
    }
    public void BatteryPlacerGrabbed()
    {
        BatteryPlacerGrab = true;
    }
    public void BatteryPlacerSnapped()
    {
    }
    public void PunchingProcessDone()
    {
        PunchingDone();
    }
    public void PunchingDone()
    {
    }
 
    public void DeformationCoverFromPunchingGrabbed()
    {
        DeforBackCoverGrab = true;
    }
    public void BatteryGrabbed()
    {
        if (DeforBackCoverGrab)
        {
            tooltipActivator.ActivateObject(3);
            Debug.Log("Cover is going to activate");
            GoodBackCoverOnPunchingActivate.SetActive(true);
            Debug.Log("Cover Activated");
        }
    }
 
    public void PunchingProcessDone2()
    {
        PunchingDone2();
    }
    public void PunchingDone2()
    {
        Debug.Log("Can grab");
        GoodCoverFromPunchingGrab.enabled = true;
    }
    public void GoodBackCoverFromPunchingGrabbed()
    {

    }
    public void BatterySnapped()
    {
        //score
        BackCoverOnAssySnapPoint.SetActive(true);
    }
    public void BackCoverOnAssySnapped()
    {

    }
    private bool NGFrontGrab = false;
    private bool FrontGrab = false;
    private bool GoodFrontSnapped = false;
    private bool NGFrontSnapped = false;


    public void NGFrontCoverGrabbed()
    {
        NGFrontGrab = true;
        FrontCoverOnAssySnapPoint.SetActive(true);
    }
    public void FrontCoverGrabbed()
    {
        FrontGrab = true;
        FrontCoverOnAssySnapPoint.SetActive(true) ;
    }
    public void FrontCoverSnappedToAssy(string result)
    {
        GoodFrontSnapped = (result == "Good");
        NGFrontSnapped = (result == "Defect");

        // Tell GreenButton that snap happened
        greenButton.EnableDoor(GoodFrontSnapped, NGFrontSnapped);
    }

    public void GreenButtonPressed(string result)
    {
        if(result == "Good")
        {
            GoodFrontFromAssyGrab.enabled = true;
}
        else if (result == "Defect")
        {
            tooltipActivator.ActivateObject(4);
            NGFrontFromAssyGrab.enabled = true;
            NGFrontSnapped = false;
        }
    }
    public void GoodFrontCoverFromAssyGrabbed()
    {
        FrontCoverToBackSnapPointObject.SetActive(true);
    }
    public void NGFrontCoverFronAssyGrabbed()
    {
        //Score
    }
    public void FrontOnBackCoverSnapped()
    {
        SlidingScriptActivate.SetActive(true);
    }
    public void SliderPushed()
    {
        PunchingScriptObject.SetActive(true);
    }
    public void AssyPunchingDone()
    {
        punchingSlidingScript.Unlock();
    }
    public void SliderPulled()
    {
        MainFromAssyGrab.enabled = true;
    }
    public  void KeyGrabbedFromTray()
    {
        KeySnapPointObject.SetActive(true);
    }
    public void KeySnappedToMain()
    {
    }
    public void MainSnappedToDrawer()
    {
    }
    public void Door2Closed()
    {
        StartCoroutine(DisplayOfDrawer2());
    }
    public IEnumerator DisplayOfDrawer2()
    {
        Door2Button1.SetActive(true);
        yield return new WaitForSeconds(5);
        Door2Button1.SetActive(false);
        Door2Button2.SetActive(true);
        drawer2.Unlock();
    }

    public void Door2Opened()
    {
        MainFromDoor2Grab.enabled = true;
    }
    public void MainKeyFromDoor2Grabbed()
    {
        RemoteKeyOnLaserSnapPointObject.SetActive(true);
    }
    public void MainKeyToLaserMachineSnapped()
    {
        laserMachine.StartProcess();
        StartCoroutine(DisplayOfLaserNG());
    }
    public IEnumerator DisplayOfLaserNG()
    {
        BackButtonCheck.SetActive(true);
        ButtonCheck.SetActive(true);
        yield return new WaitForSeconds(4);
        ButtonNG1.SetActive(true);
        ButtonNG2.SetActive(true);
        ButtonNG3.SetActive(true);
        ButtonNG4.SetActive(true);
        ButtonOK4.SetActive(true);
        ButtonCheck.SetActive(false);
        BackButtonCheck.SetActive(false);
        BackNGButton.SetActive(true);
    }
    private void LaseringDone()
    {
        LaserDone();
    }
    public void LaserDone()
    {
        NGMainFromLaserGrab.enabled = true;
    }
    public void NGMainFromLaserGrabbed()
    {

    }
    public void NGDrawer5Opened()
    {
        NGSnapPointObject5.SetActive(true);
        nGDrawer5.Unlock();
    }
    public void NGMainKeySnappedToNGBox5(GameObject obj)
    {
        GoodOnDoor2Activate.SetActive(true);
    }
    public void NGDrawer5Closed()
    {
        NGSnapPointObject5.SetActive(false);
    }

    public void GoodMainKey2FromDoor2Grabbed()
    {
        MainKey2OnLaserSnapPoint2.SetActive(true);
    }
    public void MainKey2ToLaserMachineSnapped()
    {
        laserMachine.StartProcess();
        StartCoroutine(DisplayOfDrawerOK());
    }
    public IEnumerator DisplayOfDrawerOK()
    {
        ButtonNG1.SetActive(false);
        ButtonNG2.SetActive(false);
        ButtonNG3.SetActive(false);
        ButtonNG4.SetActive(false);
        ButtonOK4.SetActive(false);
        ButtonCheck.SetActive(true);
        BackButtonCheck.SetActive(true);
        BackNGButton.SetActive(false);
        yield return new WaitForSeconds(3);
        ButtonOK1.SetActive(true);
        ButtonOK2.SetActive(true);
        ButtonOK3.SetActive(true);
        ButtonOK5.SetActive(true);
        ButtonOK6.SetActive(true);
        ButtonCheck.SetActive(false);
        BackButtonCheck.SetActive(false);
        BackOkButton.SetActive(true);
    }
    private void LaseringDone2()
    {
        LaserDone2();
    }
    public void LaserDone2()
    {
        GoodMainFromLaserGrab.enabled = true;
    }

    public void GoodMainKeyFromLaserGrabbed()
    {
        RemoteKeyInBoxMachineSnapPointObject.SetActive(true);
    }

    public void MainKeySnappedToBox()
    {
        Door3ScriptObject.SetActive(true);
    }
    private void BoxDoorClosingDone()
    {
        BoxDoorClosed();
    }
    public void BoxDoorClosed()
    {
        StartCoroutine(DisplayCheckingStartNG());
    }
    public IEnumerator DisplayCheckingStartNG()
    {
        CheckButton.SetActive(true);
        yield return new WaitForSeconds(5);
        CheckButton.SetActive(false);
        CheckButtonNG.SetActive(true);
        boxDoorMovement.Unlock(); 
    }
    private void BoxDoorOpeningDone()
    {
        BoxDoorOpened();
    }
    public void BoxDoorOpened()
    {
        NGRemoteKeyFromBoxGrab.enabled = true;
    }

    public void NGRemoteKeyFromBoxGrabbed()
    {
        KeyFromMainGrab.enabled = true;
        KeyCollider.enabled = true;
    }
    public void KeyFromMainGrabbedOut()
    {
        KeyOnTableSnapPoint.SetActive(true);
    }
    public void KeySnappedToTable()
    {
    }
    public void NGdrawer6Opened()
    {
        NG6SnapPointObject.SetActive(true);
        nGDrawer6P2.Unlock();
    }
    public void NGOnBoxDoorSnapped(GameObject obj)
    {
        MainKey2OnLaserActivate.SetActive(true);
    }
    public void NGdrawer6Closed()
    {
        NG6SnapPointObject.SetActive(false);
    }

    public void MainKey2OnLaserGrabbed()
    {
        RemoteKeyOnBoxSnapPoint2.SetActive(true);
    }
    public void RemoteKey2OnBoxSnapped()
    {

    }
    private void BoxDoorClosingDone2()
    {
        BoxDoorClosed2();
    }
    public void BoxDoorClosed2() 
    {
        StartCoroutine(DisplayCheckingStartOK());
    }
    public IEnumerator DisplayCheckingStartOK()
    {
        CheckButtonNG.SetActive(false);
        CheckButton.SetActive(true);
        yield return new WaitForSeconds(5);
        CheckButton.SetActive(false);
        CheckButtonOK.SetActive(true);
        boxDoorMovement.Unlock();
    }
    private void BoxDoorOpeningDone2()
    {
        BoxDoorOpened2();
    }
    public void BoxDoorOpened2()
    {
        GoodRemoteKeyFromBoxGrab.enabled = true;
    }


    public void GoodRemoteKeyFromBoxGrabbed()
    {
        Key2FromMainGrab.enabled = true;
        KeyCollider2.enabled = true;
    }
    public void KeyFromMainGrabbedOut2()
    {
        KeyOnTableSnapPoint2.SetActive(true);
    }

    public void Key2SnappedToTable()
    {
        MainKeyToFinalTraySnapPoint.SetActive(true);
    }
    public void FinalKeySnappedToTray()
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
    
