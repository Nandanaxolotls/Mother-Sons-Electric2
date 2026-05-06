using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class StepManagerP2 : MonoBehaviour
{
    [Header("Scene Settings")]
    public string nextSceneName = "NextScene"; // assign your next scene name in Inspector
    public int maxReloadCount = 7;             // how many times to reload before switching scene
    public AnimatorChanger changer;
    public AnimatorChanger changer2;

    private string reloadKey;
    [Header("MainObjects")]
    [Header("Machine1")]
    public GameObject ChipSnapPointObject; // object which has chip snapping script
    public ChipToDrawerSnapPoint chipToDrawerSnap; // after chip snapped then it send message
    public GameObject DoorScriptObject;
    public DrawerP2Elextric drawerDoor;
    public GameObject HandleScriptObject;
    public DrawerHandleP2Elextric drawerHandle;
    public XRGrabInteractable ChipInDrawer;
    [Header("Machine2")]
    public GameObject ChipOnCheckerSnapPointObject; //object which has chip snapping script on checker
    public ChipToChipCheckerSnapPoint chipTocheckerSnap;
    public GameObject ChipCheckerHandleScript;
    public CheckerHandle checkerHandle; // chip checker moving handle script
    public XRGrabInteractable BackCoverMain;
    public GameObject SphereObjectUnlockButton;
    public XRGrabInteractable UnlockButtonGrab; //Unlock button grabbable
    public UnlockButtonSnapPoint unlockButtonSnapPoint;
    public GameObject UnlockSnapPoint; // snappoint script attached object
    public XRGrabInteractable LockButtonGrab; // //Lock button grabbable
    public GameObject SphereObjectLockButton;
    public LockButtonSnapPoint lockButtonSnapPoint;
    public GameObject LockSnapPoint; //  snappoint script attached object
    public XRGrabInteractable RubberCoverGrab;
    public GameObject SphereObjectRubber;
    public GameObject RubberSnapPoint; //  snappoint script attached object
    public RubberSnapPoint rubberSnapPoint;
    public XRGrabInteractable ChipGrab;
    public GameObject SphereObjectChip;
    public GameObject ChipSnapPoint; //  snappoint script attached object
    public ChipToBackCoverSnapPoint chipTobackCoverSnapPoint;
    public GameObject SphereObjectCoverOnPunching;
    public GameObject PunchingMachineSnapPoint;  //  snappoint script attached object
    public PunchingMachineSnapPoint punchingMachineSnapPoint;
    public XRGrabInteractable BatteryPlacerGrab;
    public GameObject SphereObjectBatteryPlacer;
    public GameObject BatteryPlacerSnapPoint;
    public BatteryCoverSnapPoint batteryCoverSnapPoint;
    public PunchingMachine punchingMachine;
    public XRGrabInteractable BackCoverOnPunchingMachine;
    public GameObject PressingMachineScriptObject; // Punching script attached to object
    public XRGrabInteractable BatteryGrab;
    public GameObject BatterySnapPoint; // snappoint script attached object
    public GameObject SphereObjectBattery;
    public BatterySnapPoint batterySnapPoint;
    [Header("Machine3")]
    public GameObject SphereObjectBackCoverOnAssembly;
    public GameObject BackCoverSnapPointOnAssembly;
    public BackCoverOnAssembly backCoverOnAssembly;
    public XRGrabInteractable FrontCoverGrab;
    public GameObject FrontCoverOnAssemblySnapPoint; // snappoint script attached object
    public GameObject ButtonScriptObject;
    public GreenButtonP2 greenButtonP2;
    public XRGrabInteractable FrontCoverFromAssemblyGrab;
    public FrontCoverOnAssembly frontCoverOnAssembly;
    public GameObject SphereObjectFrontCoverOnBackCover;
    public GameObject FrontOnCoverSnapPoint; //snappoint script attached object
    public FrontOnBackSnapPoint frontOnBackSnapPoint;
    public GameObject PunchingMachineSlideScriptObject;
    public PunchingSlidingScript punchingSlidingScript;
    public GameObject PunchingMachineScriptObject;
    public PunchingMachine2 punchingMachine2;
    public XRGrabInteractable BackCoverGrabFromPunching;
    [Header("Machine4")]
    public KeySnapPoint keySnapPoint;
    public XRGrabInteractable KeyGrab;
    public GameObject SphereObjectKey;
    public GameObject KeySnapPoint;
    public GameObject RemoteKeyObjectSnapPoint;
    public GameObject SphereObjectRemotekey;
    public RemoteKeySnapPoint remoteKeySnapPoint;
    public GameObject Drawer2ScriptObject;
    public Drawer2 drawer2;
    public XRGrabInteractable RemoteKeyGrabbedFromDrawer;
    [Header("Machine5")]
    public GameObject SphereObjectRemoteOnLaser;
    public GameObject RemoteKeySnapPointOnLaser;
    public RemoteKeyOnLaserSnapPoint remoteKeySnapPointOnLaser;
    public LaserMachine laserMachine;
    public XRGrabInteractable RemoteGrabFromLaser;
    [Header("Machine6")]
    public GameObject RemoteOnBoxSnapPoint;
    public GameObject SphereObjectRemoteOnBox;
    public RemoteKeyInBoxSnapPoint remoteKeyInBoxSnapPoint;
    public GameObject BoxDoorScriptObject;
    public BoxDoorMovement boxDoorMovement;
    public XRGrabInteractable RemoteGrabFromBox;
    public GameObject RemoteKeyOutSnapPoint;
    public Collider KeyColliderOfRemote;
    public XRGrabInteractable KeyGrabbedFromRemote;
    public RemoteKeyOnTableSnapPoint remoteKeyOnTableSnapPoint;
    public GameObject KeyOnTableSnapPoint;
    public KeyOnTableSnapPoint keyOnTableSnapPoint;
    public XRGrabInteractable RemoteKeyOnTableGrab;
    public GameObject KeyInRemoteAfterRemoved;
    public GameObject FinalKeySnapPoint;
    public FinalKeyInBoxSnapPoint finalKeyInBoxSnapPoint;


    [Header("Highlighter")]
    [Header("Machine1")]
    public StepWiseHighlighter ChipInStartHighlight; //picking chip from table
    public GameObject Arrow1;
    public GameObject SphereObjectChipOnDrawer;
    public StepWiseHighlighter SphereChipOnDrawer; // sphere chip which highlights chip snapping position
    public GameObject Arrow2;
    public GameObject Tooltip1;
    public GameObject TooltipHandle1;
    public GameObject Tooltip2;
    public GameObject TooltipHandle2;


    public GameObject Arrow3;
    [Header("Machine2")]
    public GameObject Arrow4;
    public StepWiseHighlighter SphereChipOnChecker; // sphere chip which highlights chip snapping position on checker
    public GameObject SphereObjectChipOnChecker;
    public GameObject Tooltip3;
    public GameObject Arrow5;
    public StepWiseHighlighter SphereBackCoverMain;
    public GameObject Arrow6;
    public StepWiseHighlighter UnlockButton;
    public StepWiseHighlighter SphereUnlockHighlighter;
    public GameObject Arrow7;
    public StepWiseHighlighter LockButton;
    public StepWiseHighlighter SphereLockHighlighter;
    public GameObject Arrow8;
    public StepWiseHighlighter SphereRubberCoverHighlight;
    public StepWiseHighlighter SphereRubberHighlight;
    public GameObject Tooltip4;
    public GameObject Arrow9;
    public StepWiseHighlighter ChipOnCheckerHighlight;
    public StepWiseHighlighter SphereChipHighlight;
    public GameObject Arrow10;
    public StepWiseHighlighter SphereCoverOnPunchingHighlight;
    public GameObject Arrow11;
    public StepWiseHighlighter BatteryPlacerHighlight;
    public StepWiseHighlighter SphereHighlightBatteryPlacer;
    public GameObject Arrow12;
    public GameObject Tooltip5;
    public GameObject Arrow13;
    public StepWiseHighlighter BatteryHighlighter;
    public GameObject Arrow14;
    public StepWiseHighlighter SphereBatteryHighlighter;
    [Header("Machine3")]
    public StepWiseHighlighter SphereBackCover;
    public GameObject Tooltip6;
    public GameObject Arrow15;
    public StepWiseHighlighter FrontCoverHighlight;
    public GameObject Arrow16;
    public GameObject Tooltip7;
    public GameObject Arrow17;
    public StepWiseHighlighter FrontCoverOnAssemblyHighlight;
    public StepWiseHighlighter SphereFrontCoverOnBackCoverHighlight;
    public GameObject Tooltip8;

    public GameObject Tooltip14;
    public GameObject Tooltip15;

    public StepWiseHighlighter BackCoverAfterPunchingHighlight;
    [Header("Machine4")]
    public StepWiseHighlighter KeyHighlight;
    public GameObject ArrowAfterPunching;
    public GameObject Arrow18;
    public StepWiseHighlighter SphereObjectKeyHighlight;
    public GameObject Arrow19;
    public StepWiseHighlighter SphereRemoteKeyHighlight;
    public GameObject Tooltip9;
    public GameObject Tooltip10;
    public GameObject Arrow20;
    [Header("Machine5")]
    public GameObject Arrow21;
    public StepWiseHighlighter SphereRemoteOnLaserHighlight;
    public StepWiseHighlighter RemoteKeyFromLaserHighlight;
    public GameObject Arrow22;
    [Header("Machine6")]
    public GameObject Arrow23;
    public StepWiseHighlighter SphereRemoteOnBoxHighlight;
    public GameObject Tooltip11;
    public GameObject Tooltip12;
    public GameObject Arrow24;
    public StepWiseHighlighter KeyInRemote;
    public GameObject Arrow25;
    public GameObject Arrow26;
    public GameObject Arrow27;
    public GameObject Arrow28;
    public GameObject Tooltip13;

    [Header("Display1")]
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;
    public GameObject Button6;
    public GameObject Button7;
    public GameObject Button8;

    [Header("Laser Display")]
    public GameObject ButtonCheck;
    public GameObject BackButtonCheck;
    public GameObject ButtonOK1;
    public GameObject ButtonOK2;
    public GameObject ButtonOK3;
    public GameObject ButtonOK5;
    public GameObject ButtonOK6;
    public GameObject BackOkButton;
    [Header(" Level ")]
    public TMP_Text subTitletxt;
    public enum TrainingStep
    {
        None,
        ChipGrabbed,
        BackCoverGrabbed,
        UnlockButtonGrabbed,
        LockButtonGrabbed,
        RubberCoverGrabbed,
        ChipFromCheckerGrabbed,
        BatteryCoverGrabbed,
        ChipFromPunching,
        BatteryGrabbed,
        FrontGrabbed,
        FrontFromAssyGrabbed,
        RemoteFromPunchGrabbed,
        KeyGrabbed,
        RemoteKeyGrabbed,
        RemoteFromLaserGrabbed,
        RemoteFromBoxGrabbed,
        KeyFromRemoteGrabbed,

    }

    public TrainingStep currentStep = TrainingStep.None;
    void Awake()
    {
        // Use the scene name as a unique key for saving reload count
        reloadKey = SceneManager.GetActiveScene().name + "_ReloadCount";
    }
    void Start()
    {
        ChipInStartHighlight.Highlight();
        chipToDrawerSnap.Chipsnapped += ChipSnapped;
        drawerDoor.onReachedDesired += DoorClosed;
        drawerHandle.onReachedDesired += HandleLocked;
        drawerHandle.onReachedOriginal += HandleUnlocked;

        drawerDoor.onReachedOriginal += DoorOpened;
        chipTocheckerSnap.ChipsnappedToChecker += ChipSnappedToChecker;
        checkerHandle.onReachedDesired += CheckerClosed;
        unlockButtonSnapPoint.UnlockSnapped += UnlockButtonSnapped;
        lockButtonSnapPoint.LockSnapped += LockButtonSnapped;
        rubberSnapPoint.RubberSnapped += RubberSnapped;
        checkerHandle.onReachedOriginal += CheckerOpened;
        chipTobackCoverSnapPoint.ChipsnappedToBackCover += ChipSnappedToCover;
        punchingMachineSnapPoint.CoversnappedToPunching += CoverSnappedToPunching;
        batteryCoverSnapPoint.BatteryPlacerSnapped += BatteryPlacerSnapped;
        punchingSlidingScript.onReachedDesired += PushedSlider;
        punchingMachine.onReachedOriginal += PunchingDone;
        punchingSlidingScript.onReachedOriginal += PulledSlider;
        batterySnapPoint.BatterySnapped += BatterySnapped;
        backCoverOnAssembly.BackOnMachineSnapped += BackSnappedToAssembly;
        frontCoverOnAssembly.FrontOnMachineSnapped += FrontCoverSnapped;
        greenButtonP2.CameraChecked += CameraChecked;
        frontOnBackSnapPoint.FrontOnBackSnapped += FrontSnappedOnBack;
        punchingMachine2.onReachedOriginal += CoverPunchingDone;
        keySnapPoint.KeySnapped += KeySnapped;
        remoteKeySnapPoint.RemoteKeySnapped += RemoteKeySnapped;
        drawer2.onReachedDesired += Drawer2Closed;
        drawer2.onReachedOriginal += Drawer2Opened;
        remoteKeySnapPointOnLaser.RemoteKeySnapped += RemoteSnappedToLaser;
        laserMachine.LaserMachineDone += LaserDone;
        remoteKeyInBoxSnapPoint.RemoteKeySnappedToBox += RemoteSnappedToBox;
        boxDoorMovement.onReachedDesired += BoxDoorClosed;
        boxDoorMovement.onReachedOriginal += BoxDoorOpened;
       // remoteKeyOnTableSnapPoint.RemoteKeySnappedToTable += RemotePlaceOnTable;
        keyOnTableSnapPoint.KeySnappedToTable += KeySnappedToTable;
        finalKeyInBoxSnapPoint.FinalKeySnapped += FinalKeySnappedToBox;

        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 0, subTitletxt); //Welcome to the Remecon Line simulation tutorial
            StartCoroutine(SoundManager.instance.PlayDelayedSound(2, 1, subTitletxt, 3f)); // Go to first stage which is LF Auto Tuning and Pick circuit assembly from tray using left hand
        }
    }
    //Machine1
    private bool grabbingDone = false;
    public void ChipGrabbed()
    {
        if (!grabbingDone)
        {
            Arrow1.SetActive(false);
            SphereObjectChipOnDrawer.SetActive(true);
            SphereChipOnDrawer.Highlight();
            Arrow2.SetActive(true);
            ChipSnapPointObject.SetActive(true);
            grabbingDone = true;
            if (GameManager.Instance.isTutorial)
            {
                SoundManager.instance.PlayVoiceOver(2, 2, subTitletxt); //Place circuit assembly in the auto tuning machine same as highlighted
            }
        }

    }
    public void ChipSnapped()
    {
        Arrow2.SetActive(false);
        SphereObjectChipOnDrawer.SetActive(false);
        Tooltip1.SetActive(true);
        DoorScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 3, subTitletxt); // Close the door 
        }
    }
    public void DoorClosed()
    {
        Tooltip1.SetActive(false);
        TooltipHandle1.SetActive(true);
        DoorScriptObject.SetActive(false);
        HandleScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 4, subTitletxt); // Lock the door
        }
    }

    public void HandleLocked()
    {
        StartCoroutine(DoorDisplay());
        TooltipHandle1.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 5, subTitletxt); //Wait for the Result on monitor screen
        }

    }

    public IEnumerator DoorDisplay()
    {
        Debug.Log("Displaying");
        Button1.SetActive(true);
        yield return new WaitForSeconds(4);
        Button1.SetActive(false);
        Button2.SetActive(true);
        drawerHandle.Unlock();  
        TooltipHandle2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 6, subTitletxt); // Unlock the door
        }
    }
    public void HandleUnlocked()
    {
        TooltipHandle2.SetActive(false);
        Tooltip2.SetActive(true);
        DoorScriptObject.SetActive(true);
        HandleScriptObject.SetActive(false);
        drawerDoor.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 7, subTitletxt); // Open the door 
        }
    }
    public void DoorOpened()
    {
        Tooltip2.SetActive(false);
        ChipInDrawer.enabled = true;
        Arrow3.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 8, subTitletxt); // Pick the circuit assembly from the LF Auto Tuning 
        }
    }
    //Machine2
    public void ChipGrabbedFromDrawer()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.ChipGrabbed;
        Arrow3.SetActive(false);
        Arrow4.SetActive(true);
        ChipOnCheckerSnapPointObject.SetActive(true);
        SphereObjectChipOnChecker.SetActive(true);
        SphereChipOnChecker.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 9, subTitletxt); //Now, Move to Stage 2. Align and place the circuit assembly onto the highlighted jig
        }
    }
    public void ChipSnappedToChecker()
    {
        Arrow4.SetActive(false);
        SphereObjectChipOnChecker.SetActive(false);
        Tooltip3.SetActive(true);
        ChipCheckerHandleScript.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 10, subTitletxt); //Close the flap using right hand
        }
    }
    public void CheckerClosed()
    {
        Tooltip3.SetActive(false);
        Arrow5.SetActive(true);
        BackCoverMain.enabled = true;
        SphereBackCoverMain.Highlight();
        changer.SwitchToController1();
        StartCoroutine(DoorDisplay2());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 11, subTitletxt); //Pick upper case from tray using left hand
        }
    }
    public IEnumerator DoorDisplay2()
    {
        Button3.SetActive(true);
        yield return new WaitForSeconds(10);
        Button3.SetActive(false);
        Button4.SetActive(true);
    }
    public void BackCoverGrabbed()
    {
        if (currentStep != TrainingStep.ChipGrabbed)
            return;

        currentStep = TrainingStep.BackCoverGrabbed;
        Arrow5.SetActive(false);
        Arrow6.SetActive(true); // arrow for unlock button showing
        UnlockButton.Highlight();
        UnlockButtonGrab.enabled = true;
        changer2.SwitchToController2();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 12, subTitletxt); //Pick Switch knob unlock from tray using right hand
        }

    }

    public void UnlockButtonGrabbed()
    {
        if (currentStep != TrainingStep.BackCoverGrabbed)
            return;

        currentStep = TrainingStep.UnlockButtonGrabbed;
        Arrow6.SetActive(false);
        SphereObjectUnlockButton.SetActive(true);
        SphereUnlockHighlighter.Highlight();
        UnlockSnapPoint.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 13, subTitletxt); // Place switch knob on the upper case as highlighted
        }
    }
    public void UnlockButtonSnapped()
    {
        SphereObjectUnlockButton.SetActive(false);
        Arrow7.SetActive(true);
        LockButtonGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 14, subTitletxt); //Pick Switch knob lock from tray using right hand
        }

    }
    public void LockButtonGrabbed()
    {
        if (currentStep != TrainingStep.UnlockButtonGrabbed)
            return;

        currentStep = TrainingStep.LockButtonGrabbed;
        Arrow7.SetActive(false);
        SphereObjectLockButton.SetActive(true);
        SphereLockHighlighter.Highlight();
        LockSnapPoint.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 15, subTitletxt); // Place switch knob on the upper case as highlighted
        }
    }
    public void LockButtonSnapped()
    {
        SphereObjectLockButton.SetActive(false);
        Arrow8.SetActive(true);
        SphereRubberCoverHighlight.Highlight();
        RubberCoverGrab.enabled = true;
        changer2.SwitchToController1();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 16, subTitletxt); //Pick rubber from tray using right hand
        }

    }
    public void RubberCoverGrabbed()
    {
        if (currentStep != TrainingStep.LockButtonGrabbed)
            return;

        currentStep = TrainingStep.RubberCoverGrabbed;
        Arrow8.SetActive(false);
        SphereObjectRubber.SetActive(true);
        SphereRubberHighlight.Highlight();
        RubberSnapPoint.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 17, subTitletxt); // Place rubber on the upper case as highlighted
        }
    }
    public void RubberSnapped()
    {
        SphereObjectRubber.SetActive(false);
        checkerHandle.Unlock();
        Tooltip4.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 18, subTitletxt); //Open the flap using right hand
        }
    }
    public void CheckerOpened()
    {
        Tooltip4.SetActive(false);
        checkerHandle.PermanantlyLock();
        ChipOnCheckerHighlight.Highlight();
        Arrow9.SetActive(true);
        ChipGrab.enabled = true;
        changer2.SwitchToController1();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 19, subTitletxt); //Pick circuit assembly from jig
        }

    }
    public void ChipGrabbedFromChecker()
    {
        if (currentStep != TrainingStep.RubberCoverGrabbed)
            return;

        currentStep = TrainingStep.ChipFromCheckerGrabbed;
        Arrow9.SetActive(false);
        SphereObjectChip.SetActive(true);
        SphereChipHighlight.Highlight();
        ChipSnapPoint.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 20, subTitletxt); // Place circuit assembly on the upper case as highlighted
        }

    }
    public void ChipSnappedToCover()
    {
        SphereObjectChip.SetActive(false);
        Arrow10.SetActive(true);
        SphereObjectCoverOnPunching.SetActive(true);
        SphereCoverOnPunchingHighlight.Highlight();
        PunchingMachineSnapPoint.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 21, subTitletxt); //Now, Move to Stage 3. Align and place the upper case onto the pressing machine jig
        }
    }
    public void CoverSnappedToPunching()
    {
        Arrow10.SetActive(false);
        SphereObjectCoverOnPunching.SetActive(false);
        Arrow11.SetActive(true);
        BatteryPlacerGrab.enabled = true;
        BatteryPlacerHighlight.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 22, subTitletxt); //Pick case inner from tray
        }

    }
    public void BatteryCoverGrabbed()
    {
        if (currentStep != TrainingStep.ChipFromCheckerGrabbed)
            return;

        currentStep = TrainingStep.BatteryCoverGrabbed;
        Arrow11.SetActive(false);
        SphereObjectBatteryPlacer.SetActive(true);
        SphereHighlightBatteryPlacer.Highlight();
        Arrow12.SetActive(true);
        BatteryPlacerSnapPoint.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 23, subTitletxt); //Place case inner on the upper case as highlighted
        }

    }
    public void BatteryPlacerSnapped()
    {
        Arrow12.SetActive(false);
        SphereObjectBatteryPlacer.SetActive(false);
        Tooltip5.SetActive(true);
        PressingMachineScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 24, subTitletxt); //Pull the lever to press the Case Inner into the Case Upper Sub Assembly
        }
    }
    public void PunchingDone()
    {
        Debug.Log("PunchingDone ");
        BackCoverOnPunchingMachine.enabled = true;
        Arrow13.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 25, subTitletxt); //Pick Case Lower Sub Assembly from Pressing machine
        }
    }
    public void ChipGrabbedFromPunching()
    {
        if (currentStep != TrainingStep.BatteryCoverGrabbed)
            return;

        currentStep = TrainingStep.ChipFromPunching;
        Arrow13.SetActive(false);
        BatteryGrab.enabled = true;
        BatteryHighlighter.Highlight();
        Arrow14.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 26, subTitletxt); //Pick Battery from tray
        }
    }
    public void BatteryGrabbed()
    {
        if (currentStep != TrainingStep.ChipFromPunching)
            return;

        currentStep = TrainingStep.BatteryGrabbed;
        Arrow14.SetActive(false);
        BatterySnapPoint.SetActive(true);
        SphereObjectBattery.SetActive(true);
        SphereBatteryHighlighter.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 27, subTitletxt); //Place Battery on the Case Lower Sub Assembly as highlighted
        }

    }
    public void BatterySnapped()
    {
        SphereObjectBattery.SetActive(false);
        SphereObjectBackCoverOnAssembly.SetActive(true);
        BackCoverSnapPointOnAssembly.SetActive(true);
        SphereBackCover.Highlight();
        Tooltip6.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 28, subTitletxt); // Now, Move to Stage 4. Align and place the Case Lower Sub Assembly onto the highlighted jig
        }
    }
    public void BackSnappedToAssembly()
    {
        SphereObjectBackCoverOnAssembly.SetActive(false);
        Tooltip6.SetActive(false);
        FrontCoverGrab.enabled = true;
        Arrow15.SetActive(true);
        FrontCoverHighlight.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 29, subTitletxt); //Pick Lower Case from tray using left hand
        }
    }
    public void FrontCoverGrabbed()
    {
        if (currentStep != TrainingStep.BatteryGrabbed)
            return;

        currentStep = TrainingStep.FrontGrabbed;
        Arrow15.SetActive(false);
        Arrow16.SetActive(true);
        FrontCoverOnAssemblySnapPoint.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 30, subTitletxt); //Place it on the jig as highlighted
        }
    }
    public void FrontCoverSnapped()
    {
        Arrow16.SetActive(false);
        Tooltip7.SetActive(true);
        ButtonScriptObject.SetActive(true);
        greenButtonP2.FrontCoverSnapped();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 31, subTitletxt); //Press the button on right to start the process and Wait for the Result on monitor screen
        }
    }
    public void CameraChecked()
    {
        Arrow17.SetActive(true);
        FrontCoverOnAssemblyHighlight.Highlight();
        FrontCoverFromAssemblyGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 32, subTitletxt); //Pick Case Lower Sub Assembly from jig 
        }
    }
    public void FrontCoverGrabbedFromAssembly()
    {
        if (currentStep != TrainingStep.FrontGrabbed)
            return;

        currentStep = TrainingStep.FrontFromAssyGrabbed;
        Arrow17.SetActive(false);
        SphereObjectFrontCoverOnBackCover.SetActive(true);
        SphereFrontCoverOnBackCoverHighlight.Highlight();
        FrontOnCoverSnapPoint.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 33, subTitletxt); //Place it on the Case Upper Sub Assembly as highlighted
        }
    }
    public void FrontSnappedOnBack()
    {
        SphereObjectFrontCoverOnBackCover.SetActive(false);
        Tooltip14.SetActive(true);
        PunchingMachineSlideScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 34, subTitletxt); //Push the jig forward
        }
    }
    
    public void PushedSlider()
    {
        Tooltip8.SetActive(true);
        PunchingMachineScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 35, subTitletxt); //Pull the lever to press the Case Lower Sub Assy into the Case Upper Sub Assy
        }
    }

    public void CoverPunchingDone()
    {
       Tooltip15.SetActive(true);
       punchingSlidingScript.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 36, subTitletxt); //Pull the jig outward
        }
    }
    public void PulledSlider()
    {
        Tooltip15.SetActive(false);
        BackCoverGrabFromPunching.enabled = true;
        ArrowAfterPunching.SetActive(true);
        BackCoverAfterPunchingHighlight.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 37, subTitletxt); //Pick Remocon from jig
        }
    }

    public void RemoteGrabFromPunching()
    {
        if (currentStep != TrainingStep.FrontFromAssyGrabbed)
            return;

        currentStep = TrainingStep.RemoteFromPunchGrabbed;
        BackCoverAfterPunchingHighlight.Unhighlight();
        KeyHighlight.Highlight();
        ArrowAfterPunching.SetActive(false);
        Arrow18.SetActive(true);
        KeyGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 38, subTitletxt); //Pick Emergency key from tray
        }
    }
    //Machine 4
    public void KeyGrabbed()
    {
        if (currentStep != TrainingStep.RemoteFromPunchGrabbed)
            return;

        currentStep = TrainingStep.KeyGrabbed;
        Arrow18.SetActive(false);
        SphereObjectKey.SetActive(true);
        SphereObjectKeyHighlight.Highlight();   
        KeySnapPoint.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 39, subTitletxt); //Insert Emergency key in the Remocon as highlighted
        }
    }
    public void KeySnapped()
    {
        SphereObjectKey.SetActive(false);
        Arrow19.SetActive(true);
        RemoteKeyObjectSnapPoint.SetActive(true);
        SphereObjectRemotekey.SetActive(true);
        SphereRemoteKeyHighlight.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 40, subTitletxt); //Go to Stage 5 which is Function Checker. Align and place the Remocon in the Function Checker as highlighted
        }
    }
    public void RemoteKeySnapped()
    {
        Arrow19.SetActive(false);
        SphereObjectRemotekey.SetActive(false);
        Tooltip9.SetActive(true);
        Drawer2ScriptObject.SetActive(true) ;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 41, subTitletxt); //Close the door and Wait for the Result on monitor screen
        }

    }
    public void Drawer2Closed()
    {
        StartCoroutine(DisplayOfDrawer());
    }
    public IEnumerator DisplayOfDrawer()
    {
        Button5.SetActive(true);
        yield return new WaitForSeconds(5);
        Button5.SetActive(false);
        Button6.SetActive(true);
        drawer2.Unlock();
        Tooltip10.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 42, subTitletxt); //Open the door
        }
    }
    public void Drawer2Opened()
    {
        Tooltip10.SetActive(false);
        RemoteKeyGrabbedFromDrawer.enabled = true;
        Arrow20.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 43, subTitletxt); //Pick Remocon from Function Checker 
        }
    }
    public void RemoteKeyGrabbed()
    {
        if (currentStep != TrainingStep.KeyGrabbed)
            return;

        currentStep = TrainingStep.RemoteKeyGrabbed;
        Arrow20.SetActive(false);
        Arrow21.SetActive(true);
        SphereObjectRemoteOnLaser.SetActive(true);
        SphereRemoteOnLaserHighlight.Highlight();
        RemoteKeySnapPointOnLaser.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 44, subTitletxt); //Now, Move to Stage 6 which is Immobi communication checker. Align and place the Remocon onto the jig as highlighted
        }
    }
    public void RemoteSnappedToLaser()
    {
        Arrow21.SetActive(false);
        SphereObjectRemoteOnLaser.SetActive(false);
        laserMachine.StartProcess();
        StartCoroutine(DisplayOfDrawerOK());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 45, subTitletxt); //Wait for the Result on monitor screen
        }
    }

    public IEnumerator DisplayOfDrawerOK()
    {
        
        ButtonCheck.SetActive(true);
        BackButtonCheck.SetActive(true);
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
    public void LaserDone()
    {
        RemoteGrabFromLaser.enabled = true ;
        RemoteKeyFromLaserHighlight.Highlight() ;
        Arrow22.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 46, subTitletxt); //Pick Remocon from Immobi communication checker
        }
    }
    public void RemoteGrabbedFromLaser()
    {
        if (currentStep != TrainingStep.RemoteKeyGrabbed)
            return;

        currentStep = TrainingStep.RemoteFromLaserGrabbed;
        Arrow22.SetActive(false);
        RemoteKeyFromLaserHighlight.Unhighlight();
        Arrow23.SetActive(true);
        RemoteOnBoxSnapPoint.SetActive(true);
        SphereObjectRemoteOnBox.SetActive(true);
        SphereRemoteOnBoxHighlight.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 47, subTitletxt); // Now, Move to Stage 7 which is LF Reception sensitivity check. Align and place the Remocon onto the jig as highlighted
        }
    }
    public void RemoteSnappedToBox()
    {
        Tooltip11.SetActive(true);
        SphereObjectRemoteOnBox.SetActive(false);
        Arrow23.SetActive(false);
        BoxDoorScriptObject.SetActive(true );
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 48, subTitletxt); // Close the door and Wait for the Result on monitor screen
        }

    }
    public void BoxDoorClosed()
    {
        StartCoroutine(DisplayCheckingStart());
    }
    public IEnumerator DisplayCheckingStart()
    {
        Button7.SetActive(true);
        yield return new WaitForSeconds(5);
        Button7.SetActive(false);
        Button8.SetActive(true);
        boxDoorMovement.Unlock();
        Tooltip12.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 49, subTitletxt); //Open the door
        }

    }
    public void BoxDoorOpened()
    {
        boxDoorMovement.PermanantlyLock();
        Arrow24.SetActive(true);
        RemoteGrabFromBox.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 50, subTitletxt); //Pick Remocon from LF Reception sensitivity check
        }
    }
    public void RemoteKeyGrabbedFromBox()
    {
        if (currentStep != TrainingStep.RemoteFromLaserGrabbed)
            return;

        currentStep = TrainingStep.RemoteFromBoxGrabbed;
        Arrow24.SetActive(false);
        KeyInRemote.Highlight();
        KeyGrabbedFromRemote.enabled = true;
        KeyColliderOfRemote.enabled = true;
        Tooltip13.SetActive(true);
        //  Arrow25.SetActive(true);
        // RemoteKeyOutSnapPoint.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 51, subTitletxt); //Remove the Emergency Key from the Remocon by grabbing it with the right hand
        }

    }
   
    public void KeyGrabFromRemote()
    {
        if (currentStep != TrainingStep.RemoteFromBoxGrabbed)
            return;

        currentStep = TrainingStep.KeyFromRemoteGrabbed;
        Arrow26.SetActive(true);
        Tooltip13.SetActive(false);
        KeyInRemoteAfterRemoved.SetActive(false );
        KeyOnTableSnapPoint.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 52, subTitletxt); //Place Emergency key on the table as highlighted
        }
    }
    public void KeySnappedToTable()
    {
        Arrow26.SetActive(false);
        FinalKeySnapPoint.SetActive(true);
        Arrow28.SetActive(true);
        //  Arrow27.SetActive(true);
        // RemoteKeyOnTableGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 53, subTitletxt); //Now, Move to Stage 8 which is packing and place Remocon in the tray
        }
    }
  
    public void FinalKeySnappedToBox()
    {
        Arrow28.SetActive(false);
        Debug.Log("Level completed");
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(2, 54, subTitletxt); //Congratulations
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
            SceneManager.LoadScene("P2TNG");
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
 