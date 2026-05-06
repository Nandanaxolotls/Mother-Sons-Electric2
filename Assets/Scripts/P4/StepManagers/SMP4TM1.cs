using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class SMP4TM1 : MonoBehaviour
{
    public P4ArrowsActivator arrowActivator;
    public P4TooltipActivator tooltipActivator;
    [Header(" Machine 1 ")]
    [Header(" Crack Lower Cover ")]
    public StepWiseHighlighter HighlightLowerCoverCrackNG;
    public GameObject RedNGBoxSnapPointObject;
    public P4NG1SnapPoint p4NG1SnapPoint;
    [Header(" Locking Point Broken Lower Cover ")]
    public StepWiseHighlighter HighlightLowerCoverLockingPointBrokenNG;
    public XRGrabInteractable LockingPointNGLowerCoverGrab;
    [Header(" Good Lower Cover ")]
    public StepWiseHighlighter HighlightGoodLowerCoverOnTray;
    public XRGrabInteractable GoodLowerCoverOnTrayGrab;
    public GameObject LowerOnTableSnapPointObject;
    public GameObject SphereLowerOnTable;
    public StepWiseHighlighter HighlightSphereLowerOnTable;
    public LowerOnCaseAssySnapPoint lowerOnCaseAssySnapPoint;
    [Header(" Crack Upper Cover ")]
    public XRGrabInteractable CrackUpperCoverOnTrayGrab;
    public StepWiseHighlighter HighlightCrackUpperCoverOnTrayGrab;
    [Header(" Scratched Upper Cover ")]
    public StepWiseHighlighter HighlightScratchedUpperCoverOnTray;
    public XRGrabInteractable ScratchedUpperCoverOnTrayGrab;
    [Header(" Good Upper Cover ")]
    public StepWiseHighlighter HighlightGoodUpperCoverOnTray;
    public XRGrabInteractable GoodUpperCoverOnTrayGrab;
    public GameObject UpperOnTableSnapPointObject;
    public GameObject SphereUpperOnTable;
    public StepWiseHighlighter HighlightSphereUpperOnTable;
    public UpperOnCaseAssySnapPoint upperOnCaseAssySnapPoint;
    [Header(" GoodLowerCover To Assy ")]
    public XRGrabInteractable GoodLowerCoverOnTableGrab;
    public StepWiseHighlighter HighlightGoodLowerCoverOnTableGrab;
    public GameObject LowerCoverOnAssySnapPointObject;
    public GameObject SphereLowerCoverOnAssy;
    public StepWiseHighlighter HighlightSphereLowerCoverOnAssy;
    public LowerOnMainAssySnapPoint lowerOnMainAssySnapPoint;
    [Header(" Pin Broken PCB ")]
    public StepWiseHighlighter HighlightPinBrokenNGPCB;
    public XRGrabInteractable PinBrokenPCBGrab;
    [Header(" Component Missing PCB ")]
    public StepWiseHighlighter HighlightCompMissPCB;
    public XRGrabInteractable CompMissPCBGrab;
    [Header(" Good PCB ")]
    public XRGrabInteractable GoodPCBFromTrayGrab;
    public StepWiseHighlighter HighlightGoodPCBOnTray;
    public GameObject GoodPCBOnAssySnapPointObject;
    public GameObject SphereGoodPCBOnAssy;
    public StepWiseHighlighter HighlightSphereGoodPCBOnAssy;
    public PCBOnMainAssySnapPoint pCBOnMainAssySnapPoint;
    [Header(" Screwing ")]
    public GameObject ScrewingJigScript;
    public StepWiseHighlighter Screw;
    public XRGrabInteractable DrilMachineGrab;
    public StepWiseHighlighter HighlightDrilMachine;
    public ScrewIngJigMachine screwIngJigMachine;
    public GameObject ScrewSnapPoint1;
    public GameObject ScrewSnapPoint2;
    public GameObject ScrewSnapPoint3;
    public GameObject ScrewSnapPoint4;
    public DrillMachine drillMachine;
    public ScrewingDoneCheck screwingDoneCheck;
    public GameObject DrilMachineSnapPoint;
    public GameObject SphereDrilMachine;
    public StepWiseHighlighter HighlightSphereDrilMachine;
    public DrilMachineSnapPoint drilMachineSnapPoint;
    [Header(" UpperCover To ASSY ")]
    public XRGrabInteractable UpperCoverFromTableGrab;
    public StepWiseHighlighter HighlightUpperCoverOnTable;
    public GameObject UpperCoverOnLowerSnapPointObject;
    public GameObject SphereUpperCoverOnLower;
    public StepWiseHighlighter HighlightSphereUpperCoverOnLower;
    public UpperOnLowerSnapPoint upperOnLowerSnapPoint;
    [Header(" NG label ")]
    public XRGrabInteractable NGLabel1Grab;
    public StepWiseHighlighter HighlightNGLabel1;
    public GameObject LabelNGBinSnapPointObject;
    public P4NG2BinSnapPoint p4NG2BinSnapPoint;
    [Space]
    public GameObject NGLabel2Activate;
    public StepWiseHighlighter HighlightNGLabel2;
    [Header(" Good label ")]
    public GameObject GoodLabelActivate;
    public StepWiseHighlighter HighlightGoodLabel;
    public GameObject GoodLabelSnapPointObject;
    public GameObject SphereLabelOnCover;
    public StepWiseHighlighter HighlightSphereLabelOnCover;
    public LabelOnMainSnapPoint labelOnMainSnapPoint;
    public GameObject Label2;
    [Header(" Scanning gun ")]
    public XRGrabInteractable ScanningGunGrab;
    public StepWiseHighlighter HighlightScanningGunGrab;
    public ScannerGun scannerGun;
    [Space]
    public XRGrabInteractable MainOnAssyGrab;
    public StepWiseHighlighter HighlightMainOnAssy;
    [Header(" Machine 2 ")]
    public GameObject ScanningMachine1;
    public ScannerChecking scannerChecking;
    public GameObject MainOnFCSnapPointObject;
    public GameObject SphereMainOnFC;
    public StepWiseHighlighter HighlightSphereMainOnFC;
    public Renderer targetRenderer1;
    public Renderer targetRenderer2;
    public Renderer targetRenderer3;
    public Color RedColor;
    public Color GreenColor;
    public MainOnFCSnapPoint mainOnFCSnapPoint;
    public FunctionCheckerMachine functioncheckerMachine;
    public XRGrabInteractable MainFromFCGrab;
    public StepWiseHighlighter HighlightMainFromFC;
    [Header(" Machine 3 ")]
    public GameObject ScanningMachine2;

    public GameObject NG3SnapPointObject;
    public P4NG3BinSnapPoint p4NG3BinSnapPoint;
    public MainOnFCSnapPoint2 mainOnFCSnapPoint2;
    [Header("Machine 5")]
    public GameObject MainOnSCSnapPointObject;
    public GameObject SphereMainOnSC;
    public StepWiseHighlighter HighlightSphereMainOnSC;
    public MainOnSCSnapPoint mainOnSCSnapPoint;
    public GameObject TrayScriptObject;
    public SensitivityCheckerTray sensitivityCheckerTray;
    public GameObject DoorScriptObject;
    public BoxDoorP4 BoxDoorP4;
    public ScannerChecking2 ScannerChecking2;
    public XRGrabInteractable MainOnSCGrab;
    public StepWiseHighlighter HighlightMainOnSC;
    public GameObject NGsnappoint4;
    public P4NG4BinSnapPoint p4NG4BinSnapPoint;
    public GameObject Main2OnFCActivate;
    public StepWiseHighlighter HighlightMain2OnFC;
    public GameObject MainOnSCSnapPointObject2;
    public MainOnSCSnapPoint2 mainOnSCSnapPoint2;
    public GameObject TrayScriptObject2;
    public SensitivityCheckerTray2 sensitivityCheckerTray2;
    public GameObject DoorScriptObject2;
    public BoxDoor2P4 BoxDoor2P4;
    public XRGrabInteractable Main2OnSCGrab;
    public StepWiseHighlighter HighlightMain2OnSC;
    public GameObject ScanChecker3Activate;
    public ScannerChecking3 scannerChecking3;
    public GameObject FinalSnapPointActivate;
    public MainOnFinalSnapPoint mainOnFinalSnapPointActivate;


    [Header(" UI ")]
    public GameObject ShortCheckText;
    public GameObject CheckText;
    public GameObject NGText;
    public GameObject OKText;
    [Space]
    public GameObject CheckButton;
    public GameObject NGButton;
    public GameObject OKButton;
    [Space]
    public GameObject CaseLowerDisplay;
    public GameObject CaseUpperDisplay;
    public GameObject CaseUpperCenterDisplay;
    public GameObject PCBOnCaseUpperCenterDisplay;
    public GameObject Panel1;
    public GameObject ScrewingPanel2;
    public GameObject UpperOnLowerPanel;
    public GameObject LabelPastingPanel;
    [Space]
    public GameObject NowPrintButton;
    public GameObject FinishButton;
    [Space]
    public GameObject PackingLineDisplay;
    public GameObject CongratsMessage;
    [Header(" Level ")]
    public TMP_Text subTitletxt;


    private int NgSnapCount = 0;
    private int NGBinSnapCount = 0;
    private int ScanningCheckedCount = 0;
    private int FunctionCheckingDoneCount = 0;
    private int ScanningChecked5Count = 0;
    private int ScanLabelCount = 0;
    private bool PickedFirst = false;
    public enum TrainingStep
    {
        None,
        NGLowerCoverGrabbed,
        NGLowerCoverGrabbed2,
        LowerCoverGrabbed,
        NGUpperCoverGrabbed,
        NGUpperCoverGrabbed2,
        UpperCoverGrabbed,
        LowerFromTableGrabbed,
        NGPCBGrabbed,
        NGPCBGrabbed2,
        PCBGrabbed,
        UpperFromTableGrabbed,
        NGLabelGrabbed,
        NGLabelGrabbed2,
        LabelGrabbed,
        MainFromAssyGrabbed,
        MainFromFcGrabbed,
        Main2FromAssyGrabbed,
        Main2FromFcGrabbed,
        NGMainFromScGrabbed,
        Main3FromFcGrabbed,
        MainFromSCGrabbed,


    }

    public TrainingStep currentStep = TrainingStep.None;

    void Start()
    {
        HighlightLowerCoverCrackNG.Highlight();
        p4NG1SnapPoint.OnObjectActivated += OnDefectSnappedToNGDynamic;
        lowerOnCaseAssySnapPoint.LowerOnMachineSnapped += GoodLowerCoverSnappedToTable;
        upperOnCaseAssySnapPoint.UpperOnMachineSnapped += GoodUpperCoverSnappedToTable;
        lowerOnMainAssySnapPoint.LowerOnMachineSnapped += GoodLowerCoverSnappedToAssy;
        pCBOnMainAssySnapPoint.PCBOnMachineSnapped += GoodPCBSnappedToAssy;
        screwIngJigMachine.onReachedDesired += ScrewingJigClosed;
        drillMachine.PickedScrew += PickedScrewFirst;
        screwingDoneCheck.AllScrewSnapped += AllScrewingDone;
        drilMachineSnapPoint.DrilSnapped += DrillMachineSnappedBack;
        screwIngJigMachine.onReachedOriginal += ScrewingJigOpened;
        upperOnLowerSnapPoint.UpperOnLowerSnapped += UpperCoverSnappedToLowerCover;
        p4NG2BinSnapPoint.OnObjectActivated += OnDefectSnappedToNGBinDynamic;
        labelOnMainSnapPoint.LabelOnMachineSnapped += LabelSnappedToCover;
        scannerGun.LabelScanned += OnScanningLabelDoneDynamic;
        scannerChecking.Scanned += OnScanningMachineDoneDynamic;
        mainOnFCSnapPoint.MainOnFCSnapped += MainSnappedToFC;
        functioncheckerMachine.FunctionCheckingDone += OnFunctionCheckerDoneDynamic;
        p4NG3BinSnapPoint.OnObjectActivated += NGMainSnappedToNGBox3;
        mainOnFCSnapPoint2.MainOnFCSnapped += MainSnappedToFC2;
        mainOnSCSnapPoint.MainOnSCSnapped += MainOnSCSnapped;
        sensitivityCheckerTray.onReachedDesired += TrayPushed;
        sensitivityCheckerTray.onReachedOriginal += TrayPulled;
        BoxDoorP4.onReachedDesired += BoxDoorClosed;
        BoxDoorP4.onReachedOriginal += BoxDoorOpened;
        ScannerChecking2.Scanned += OnScanningMachine5DoneDynamic;
        p4NG4BinSnapPoint.OnObjectActivated += NGMainFromSCSnapped;
        mainOnSCSnapPoint2.MainOnSCSnapped += MainOnSCSnapped2;
        sensitivityCheckerTray2.onReachedDesired += TrayPushed2;
        sensitivityCheckerTray2.onReachedOriginal += TrayPulled2;
        BoxDoor2P4.onReachedDesired += BoxDoorClosed2;
        BoxDoor2P4.onReachedOriginal += BoxDoorOpened2;
        scannerChecking3.Scanned += ScanningMachine5Done3;
        mainOnFinalSnapPointActivate.MainOnFinalSnapped += MainOnFinalSnappingDone;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 0, subTitletxt); //Welcome to the BCM Line simulation tutorial
            StartCoroutine(SoundManager.instance.PlayDelayedSound(7, 1, subTitletxt, 3f)); //Go to first stage which is Case Assembly & Label Paste and Pick Case Upper from tray using right hand
        }
    }
    private void OnDefectSnappedToNGDynamic(GameObject obj)
    {
        NgSnapCount++;
        Debug.Log($"[{NgSnapCount}] Received event: {obj.name} just activated!");

        switch (NgSnapCount)
        {
            case 1:
                LowerCrackNGPartSnappedToNGBox(obj);
                break;

            case 2:
                LockingPointNGLoverCoverSnappedToNGBox(obj);
                break;

            case 3:
                CrackNGUpperCoverSnappedToNGBox(obj);
                break;
            case 4:
                ScratchedNGUpperCoverSnappedToNGBox(obj);
                break;
            case 5:
                PinBrokenPCBSnappedToNGBox(obj);
                break;
            case 6:
                CompMissPCBSnappedToNGBox(obj);
                break;
            default:
                Debug.Log("Additional activations beyond the third.");
                break;
        }
    }

    private void OnDefectSnappedToNGBinDynamic(GameObject obj)
    {
        NGBinSnapCount++;
        Debug.Log($"[{NGBinSnapCount}] Received event: {obj.name} just activated!");

        switch (NGBinSnapCount)
        {
            case 1:
                NGLabel1SnappedToBin(obj);
                break;

            case 2:
                NGLabel2SnappedToBin(obj);
                break;

            case 3:
                // CrackNGUpperCoverSnappedToNGBox(obj);
                break;
            default:
                Debug.Log("Additional activations beyond the third.");
                break;
        }
    }
    private void OnScanningMachineDoneDynamic()
    {
        ScanningCheckedCount++;

        Debug.Log($"Drawer opened {ScanningCheckedCount} times");

        switch (ScanningCheckedCount)
        {
            case 1:
                Scanning1Done();
                break;
            case 2:
                Scanning2Done();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnFunctionCheckerDoneDynamic()
    {
        FunctionCheckingDoneCount++;

        Debug.Log($"Drawer opened {FunctionCheckingDoneCount} times");

        switch (FunctionCheckingDoneCount)
        {
            case 1:
                FunctionCheckingDone();
                break;
            case 2:
                FunctionCheckingDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    private void OnScanningMachine5DoneDynamic()
    {
        ScanningChecked5Count++;

        Debug.Log($"Drawer opened {ScanningChecked5Count} times");

        switch (ScanningChecked5Count)
        {
            case 1:
                ScanningMachine5Done();
                break;
            case 2:
                ScanningMachine5Done2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    private void OnScanningLabelDoneDynamic()
    {
        ScanLabelCount++;

        Debug.Log($"Drawer opened {ScanLabelCount} times");

        switch (ScanLabelCount)
        {
            case 1:
                ScannedReprintingLabel();
                break;
            case 2:
                ScannedReprintingLabel2();
                break;
            case 3:
                LabelScanningDone();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    public void LowerCrackNGPartGrabbed()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.NGLowerCoverGrabbed;
        tooltipActivator.ActivateObject(0);
        arrowActivator.DeactivateObject(0);
        arrowActivator.ActivateObject(1);
        RedNGBoxSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 2, subTitletxt); //It is a NG child part so put this Case Upper in the highlighted NG box 
        }
    }
    public void LowerCrackNGPartSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(2);
        HighlightLowerCoverLockingPointBrokenNG.Highlight();
        LockingPointNGLowerCoverGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 3, subTitletxt); //Pick another Case Upper from tray using right hand
        }
    }
    public void LockingPointNGLowerCoverGrabbed()
    {
        if (currentStep != TrainingStep.NGLowerCoverGrabbed)
            return;

        currentStep = TrainingStep.NGLowerCoverGrabbed2;
        arrowActivator.DeactivateObject(2);
        tooltipActivator.ActivateObject(1);
        arrowActivator.ActivateObject(1);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 4, subTitletxt); //It is a NG child part so put this Case Upper in the highlighted NG box 
        }
    }
    public void LockingPointNGLoverCoverSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(3);
        HighlightGoodLowerCoverOnTray.Highlight();
        GoodLowerCoverOnTrayGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 5, subTitletxt); //Pick another Case Upper from tray using right hand
        }
    }

    public void GoodLowerCoverGrabbed()
    {
        if (currentStep != TrainingStep.NGLowerCoverGrabbed2)
            return;

        currentStep = TrainingStep.LowerCoverGrabbed;
        tooltipActivator.ActivateObject(15);
        arrowActivator.DeactivateObject(3);
        arrowActivator.ActivateObject(4);
        LowerOnTableSnapPointObject.SetActive(true);
        SphereLowerOnTable.SetActive(true);
        HighlightSphereLowerOnTable.Highlight();
        CaseLowerDisplay.SetActive(true);
        CaseUpperDisplay.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 6, subTitletxt); //Place Case Upper in place as highlighted
        }
    }

    public void GoodLowerCoverSnappedToTable()
    {
        tooltipActivator.DeactivateObject(15);
        arrowActivator.DeactivateObject(4);
        arrowActivator.ActivateObject(5);
        SphereLowerOnTable.SetActive(false);
        CrackUpperCoverOnTrayGrab.enabled = true;
        HighlightCrackUpperCoverOnTrayGrab.Highlight();
        CaseUpperDisplay.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 7, subTitletxt); //Pick Case Lower from tray using left hand
        }

    }
    public void CrackNGUpperCoverGrabbed()
    {
        if (currentStep != TrainingStep.LowerCoverGrabbed)
            return;

        currentStep = TrainingStep.NGUpperCoverGrabbed;
        arrowActivator.DeactivateObject(5);
        arrowActivator.ActivateObject(1);
        tooltipActivator.ActivateObject(2);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 8, subTitletxt); //It is a NG child part so put this Case Lower in the highlighted NG box 
        }
    }
    public void CrackNGUpperCoverSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(6);
        HighlightScratchedUpperCoverOnTray.Highlight();
        ScratchedUpperCoverOnTrayGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7,9, subTitletxt); //Pick another Case Lower from tray using left hand
        }
    }
    public void ScratchedUpperCoverGrabbed()
    {
        if (currentStep != TrainingStep.NGUpperCoverGrabbed)
            return;

        currentStep = TrainingStep.NGUpperCoverGrabbed2;
        arrowActivator.DeactivateObject(6);
        arrowActivator.ActivateObject(1);
        tooltipActivator.ActivateObject(3);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 10, subTitletxt); //It is a NG child part so put this Case Lower in the highlighted NG box
        }
    }
    public void ScratchedNGUpperCoverSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(7);
        HighlightGoodUpperCoverOnTray.Highlight();
        GoodUpperCoverOnTrayGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 11, subTitletxt); //Pick another Case Lower from tray using left hand
        }
    }
    public void GoodUpperCoverGrabbed()
    {
        if (currentStep != TrainingStep.NGUpperCoverGrabbed2)
            return;

        currentStep = TrainingStep.UpperCoverGrabbed;
        tooltipActivator.ActivateObject(14);
        arrowActivator.DeactivateObject(7);
        arrowActivator.ActivateObject(8);
        UpperOnTableSnapPointObject.SetActive(true);
        SphereUpperOnTable.SetActive(true);
        HighlightSphereUpperOnTable.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 12, subTitletxt); //Place Case Lower in place as highlighted
        }
    }
    public void GoodUpperCoverSnappedToTable()
    {
        tooltipActivator.DeactivateObject(14);
        arrowActivator.DeactivateObject(8);
        arrowActivator.ActivateObject(4);
        SphereUpperOnTable.SetActive(false);
        GoodLowerCoverOnTableGrab.enabled = true;
        HighlightGoodLowerCoverOnTableGrab.Highlight();
        CaseLowerDisplay.SetActive(false);
        CaseUpperCenterDisplay.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 13, subTitletxt); //Pick Case Upper using right hand

        }

    }
    public void GoodLowerCowerFromTableGrabbed()
    {
        if (currentStep != TrainingStep.UpperCoverGrabbed)
            return;

        currentStep = TrainingStep.LowerFromTableGrabbed;
        arrowActivator.DeactivateObject(4);
        arrowActivator.ActivateObject(9);
        LowerCoverOnAssySnapPointObject.SetActive(true);
        SphereLowerCoverOnAssy.SetActive(true);
        HighlightSphereLowerCoverOnAssy.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 14, subTitletxt); //Place Case Upper in on center jig as highlighted
        }
    }

    public void GoodLowerCoverSnappedToAssy()
    {
        arrowActivator.DeactivateObject(9);
        arrowActivator.ActivateObject(10);
        SphereLowerCoverOnAssy.SetActive(false);
        PinBrokenPCBGrab.enabled = true;
        HighlightPinBrokenNGPCB.Highlight();
        CaseUpperCenterDisplay.SetActive(false);
        PCBOnCaseUpperCenterDisplay.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 15, subTitletxt); //Pick Circuit Assembly from tray using left hand
        }
    }

    public void PinBrokenPCBGrabbed()
    {
        if (currentStep != TrainingStep.LowerFromTableGrabbed)
            return;

        currentStep = TrainingStep.NGPCBGrabbed;
        arrowActivator.DeactivateObject(10);
        arrowActivator.ActivateObject(1);
        tooltipActivator.ActivateObject(4);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 16, subTitletxt); //It is a NG child part so put this Circuit Assembly in the highlighted NG box
        }
    }
    public void PinBrokenPCBSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(11);
        HighlightCompMissPCB.Highlight();
        CompMissPCBGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 17, subTitletxt); //Pick another Circuit Assembly from tray using left hand
        }
    }
    public void CompMissPCBGrabbed()
    {
        if (currentStep != TrainingStep.NGPCBGrabbed)
            return;

        currentStep = TrainingStep.NGPCBGrabbed2;
        arrowActivator.DeactivateObject(11);
        arrowActivator.ActivateObject(1);
        tooltipActivator.ActivateObject(5);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 18, subTitletxt); //It is a NG child part so put this Circuit Assembly in the highlighted NG box
        }
    }

    public void CompMissPCBSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(12);
        GoodPCBFromTrayGrab.enabled = true;
        HighlightGoodPCBOnTray.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 19, subTitletxt); //Pick another Circuit Assembly from tray using left hand
        }
    }

    public void GoodPCBFromTrayGrabbed()
    {
        if (currentStep != TrainingStep.NGPCBGrabbed2)
            return;

        currentStep = TrainingStep.PCBGrabbed;
        tooltipActivator.ActivateObject(14);
        arrowActivator.DeactivateObject(12);
        arrowActivator.ActivateObject(9);
        GoodPCBOnAssySnapPointObject.SetActive(true);
        SphereGoodPCBOnAssy.SetActive(true);
        HighlightSphereGoodPCBOnAssy.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 20, subTitletxt); // Place Circuit Assembly on the Case Upper as highlighted
        }
    }

    public void GoodPCBSnappedToAssy()
    {
        tooltipActivator.DeactivateObject(14);
        arrowActivator.DeactivateObject(9);
        tooltipActivator.ActivateObject(6);
        SphereGoodPCBOnAssy.SetActive(false);
        ScrewingJigScript.SetActive(true);
        PCBOnCaseUpperCenterDisplay.SetActive(false);
        Panel1.SetActive(false);
        ScrewingPanel2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 21, subTitletxt); // Close the flap
        }
    }

    public void ScrewingJigClosed()
    {
        tooltipActivator.DeactivateObject(6);
        DrilMachineGrab.enabled = true;
        HighlightDrilMachine.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 22, subTitletxt); // Pick up the Power screwdriver using your right hand
        }
    }
    private bool DrillMachineGrabbed = false;
    public void DrillGrabbed()
    {
        if (!DrillMachineGrabbed)
        {
            arrowActivator.ActivateObject(13);
            Screw.Highlight();
            DrillMachineGrabbed = true;
            if (GameManager.Instance.isTutorial)
            {
                SoundManager.instance.PlayVoiceOver(7, 23, subTitletxt); //Pick screws from the screw dispenser one at a time. When you reach the screwing point, press the trigger button to start the screwing process
            }
        }
    }
    public void PickedScrewFirst()
    {
        if (!PickedFirst)
        {
            Screw.Unhighlight();
            ScrewSnapPoint1.SetActive(true);
            ScrewSnapPoint2.SetActive(true);
            ScrewSnapPoint3.SetActive(true);
            ScrewSnapPoint4.SetActive(true);
            arrowActivator.DeactivateObject(13); // screw in machine to pick arrow

            PickedFirst = true;
        }
    }

    public void AllScrewingDone()
    {
        //  DrilMachineSnapPoint.SetActive(true);
        //  SphereDrilMachine.SetActive(true);
        //  HighlightSphereDrilMachine.Highlight();
        tooltipActivator.ActivateObject(7);
        screwIngJigMachine.Unlock();
        ScrewingPanel2.SetActive(false);
        UpperOnLowerPanel.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 24, subTitletxt); //Now ungrab the Power screwdriver and Open the flap
        }
    }
    public void DrillMachineSnappedBack()
    {
      //  SphereDrilMachine.SetActive(false);
        tooltipActivator.ActivateObject(7);
        screwIngJigMachine.Unlock();
    }

    public void ScrewingJigOpened()
    {
        tooltipActivator.DeactivateObject(7);
        arrowActivator.ActivateObject(8);
        UpperCoverFromTableGrab.enabled = true;
        HighlightUpperCoverOnTable.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 25, subTitletxt); //Pick Case Lower using left hand
        }
    }


    public void UpperCoverFromTableGrabbed()
    {
        if (currentStep != TrainingStep.PCBGrabbed)
            return;

        currentStep = TrainingStep.UpperFromTableGrabbed;
        arrowActivator.DeactivateObject(8);
        arrowActivator.ActivateObject(9);
        UpperCoverOnLowerSnapPointObject.SetActive(true);
        SphereUpperCoverOnLower.SetActive(true);
        HighlightSphereUpperCoverOnLower.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 26, subTitletxt); //Place Case Lower on the Case Upper as highlighted
        }
    }
    public void UpperCoverSnappedToLowerCover()
    {
        arrowActivator.DeactivateObject(9);
        SphereUpperCoverOnLower.SetActive(false);
        arrowActivator.ActivateObject(14);
        NGLabel1Grab.enabled = true;
        HighlightNGLabel1.Highlight();
        UpperOnLowerPanel.SetActive(false);
        LabelPastingPanel.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 27, subTitletxt); //Pick Label from Label printing machine
        }

    }
    public void NGLabel1Grabbed()
    {
        if (currentStep != TrainingStep.UpperFromTableGrabbed)
            return;

        currentStep = TrainingStep.NGLabelGrabbed;
        tooltipActivator.ActivateObject(8);
        arrowActivator.DeactivateObject(14);
        arrowActivator.ActivateObject(15);
        LabelNGBinSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 28, subTitletxt); //It is a NG Label so put this in the highlighted NG box
        }
    }

    public void NGLabel1SnappedToBin(GameObject obj)
    {
        arrowActivator.DeactivateObject(15);
        arrowActivator.ActivateObject(14);
        //NGLabel2Activate.SetActive(true);
        // HighlightNGLabel2.Highlight();
        ScanningGunGrab.enabled = true;
        HighlightScanningGunGrab.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 67, subTitletxt); //Pick label scanning gun and scan reprint label of the machine to reprint new label
        }
    }
    public void ScannedReprintingLabel()
    {
        arrowActivator.DeactivateObject(14);
        NGLabel2Activate.SetActive(true);
        HighlightNGLabel2.Highlight();
        HighlightScanningGunGrab.Unhighlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 29, subTitletxt); //Pick another Label from Label printing machine using right hand
        }
    }

    public void NGLabel2Grabbed()
    {
        if (currentStep != TrainingStep.NGLabelGrabbed)
            return;

        currentStep = TrainingStep.NGLabelGrabbed2;
        ScanningGunGrab.enabled = false;
        tooltipActivator.ActivateObject(9);
        arrowActivator.DeactivateObject(14);
        arrowActivator.ActivateObject(15);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 30, subTitletxt); //It is a NG Label so put this in the highlighted NG box
        }
    }
    public void NGLabel2SnappedToBin(GameObject obj)
    {
        arrowActivator.DeactivateObject(15);
        arrowActivator.ActivateObject(14);
        //GoodLabelActivate.SetActive(true);
        //HighlightGoodLabel.Highlight();
        ScanningGunGrab.enabled = true;
        HighlightScanningGunGrab.Highlight();
       
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 67, subTitletxt); //Pick label scanning gun and scan reprint label of the machine to reprint new label
        }
    }
    public void ScannedReprintingLabel2()
    {
        arrowActivator.DeactivateObject(14);
        GoodLabelActivate.SetActive(true);
        HighlightGoodLabel.Highlight();
        HighlightScanningGunGrab.Unhighlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 31, subTitletxt); //Pick another Label from Label printing machine using right hand
        }
    }
    public void GoodLablelGrabbed()
    {
        if (currentStep != TrainingStep.NGLabelGrabbed2)
            return;

        currentStep = TrainingStep.LabelGrabbed;
        ScanningGunGrab.enabled = false;
        arrowActivator.DeactivateObject(14);
        tooltipActivator.ActivateObject(15);
        arrowActivator.ActivateObject(9);
        GoodLabelSnapPointObject.SetActive(true);
        SphereLabelOnCover.SetActive(true);
        HighlightSphereLabelOnCover.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 32, subTitletxt); //Stick Label on the Case Lower as highlighted
        }
    }
    private bool isLabelsnapped = false;
    public void LabelSnappedToCover()
    {
        arrowActivator.DeactivateObject(9);
        tooltipActivator.DeactivateObject(15);
        SphereLabelOnCover.SetActive(false);
        arrowActivator.ActivateObject(16);
        ScanningGunGrab.enabled = true;
        HighlightScanningGunGrab.Highlight();
        LabelPastingPanel.SetActive(false);
        Panel1.SetActive(true);
        CaseLowerDisplay.SetActive(true);
        CaseUpperDisplay.SetActive(true);
        isLabelsnapped = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 33, subTitletxt); //Pick Label scanning gun using right hand
        }

    }
    public void ScanningGunGrabbed()
    {
        if (isLabelsnapped)
        {
            arrowActivator.DeactivateObject(16);
            arrowActivator.ActivateObject(9);
            if (GameManager.Instance.isTutorial)
            {
                SoundManager.instance.PlayVoiceOver(7, 34, subTitletxt); //Scan the sticked label by taking scanner near the label and pressing trigger button
            }
        } 
    }
    public void LabelScanningDone()
    {
        arrowActivator.DeactivateObject(9);
        MainOnAssyGrab.enabled = true;
        HighlightMainOnAssy.Highlight();
        Label2.SetActive(true);
        StartCoroutine(PackingCanvas());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 35, subTitletxt); //Pick BCM Assembly from the jig using left hand
        }
    }

    public void MainCoverFromAssyGrabbed()
    {
        if (currentStep != TrainingStep.LabelGrabbed)
            return;

        currentStep = TrainingStep.MainFromAssyGrabbed;
        arrowActivator.ActivateObject(17);
        HighlightMainOnAssy.Unhighlight();
        ScanningMachine1.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 36, subTitletxt); //Now, Go to Second stage which is Function Checker - 1 and Scan the label on BCM Assembly
        }
    }
    //Machine 2

    public void Scanning1Done()
    {
        arrowActivator.DeactivateObject(17);
        arrowActivator.ActivateObject(18);
        ScanningMachine1.SetActive(false);
        MainOnFCSnapPointObject.SetActive(true);
        SphereMainOnFC.SetActive(true);
        HighlightSphereMainOnFC.Highlight();
        StartCoroutine(ChangeColor1());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 37, subTitletxt); //Place BCM Assembly on the Function Checker jig as highlighted
        }
    }

    public IEnumerator ChangeColor1()
    {
        if (targetRenderer1 != null)
        {
            targetRenderer1.material.color = GreenColor; // Change color
        }
        yield return new WaitForSeconds(2);
        if (targetRenderer1 != null)
        {
            targetRenderer1.material.color = RedColor; // Change color
        }

    }

    public void MainSnappedToFC()
    {
        arrowActivator.DeactivateObject(18);
        SphereMainOnFC.SetActive(false);
        functioncheckerMachine.StartProcess();
        StartCoroutine(FCDisplay());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 38, subTitletxt); //Wait for the Result on monitor screen
        }
    }

    public IEnumerator FCDisplay()
    {
        ShortCheckText.SetActive(true);
        yield return new WaitForSeconds(4);
        ShortCheckText.SetActive(false);
        CheckText.SetActive(true);
        yield return new WaitForSeconds(6);
        CheckText.SetActive(false);
        NGText.SetActive(true);
    }

    public void FunctionCheckingDone()
    {
        arrowActivator.ActivateObject(18);
        MainFromFCGrab.enabled = true;
        HighlightMainFromFC.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 39, subTitletxt); //Pick BCM Assembly from Function Checker using left hand
        }
    }

    public void MainFromFCGrabbed()
    {
        if (currentStep != TrainingStep.MainFromAssyGrabbed)
            return;

        currentStep = TrainingStep.MainFromFcGrabbed;
        arrowActivator.DeactivateObject(18);
        HighlightMainFromFC.Unhighlight();
        arrowActivator.ActivateObject(20);
        NG3SnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 40, subTitletxt); //It is a NG BCM Assembly so put this BCM Assembly in the highlighted NG box 
        }
    }
    public GameObject MainFromAssy2;
    public StepWiseHighlighter HighlightMainFromAssy2;
    public GameObject MainOnFCSnapPointObject2;
    public XRGrabInteractable MainFromFCGrab2;
    public StepWiseHighlighter HighlightMainFromFC2;
    public void NGMainSnappedToNGBox3(GameObject obj)
    {
        arrowActivator.DeactivateObject(20);
        NG3SnapPointObject.SetActive(false);
        MainFromAssy2.SetActive(true);
        HighlightMainFromAssy2.Highlight();
        arrowActivator.ActivateObject(9);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 41, subTitletxt); //Pick another BCM Assembly from the stage 1 jig using left hand
        }
    }
    public void MainFromAssy2Grabbed()
    {
        if (currentStep != TrainingStep.MainFromFcGrabbed)
            return;

        currentStep = TrainingStep.Main2FromAssyGrabbed;
        arrowActivator.DeactivateObject(9);

        arrowActivator.ActivateObject(17);
        HighlightMainFromAssy2.Unhighlight();
        ScanningMachine1.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 42, subTitletxt); //Now, Go to Second stage which is Function Checker - 1 and Scan the label on BCM Assembly
        }
    }
    public void Scanning2Done()
    {
        arrowActivator.DeactivateObject(17);
        arrowActivator.ActivateObject(18);
        ScanningMachine1.SetActive(false);
        MainOnFCSnapPointObject2.SetActive(true);
        SphereMainOnFC.SetActive(true);
        HighlightSphereMainOnFC.Highlight();
        StartCoroutine(ChangeColor1());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 43, subTitletxt); //Place BCM Assembly on the Function Checker jig as highlighted
        }
    }
    public void MainSnappedToFC2()
    {
        arrowActivator.DeactivateObject(18);
        SphereMainOnFC.SetActive(false);
        functioncheckerMachine.StartProcess();
        StartCoroutine(FCDisplay2());
        if (GameManager.Instance.isTutorial)
        { 
            SoundManager.instance.PlayVoiceOver(7, 44, subTitletxt); //Wait for the Result on monitor screen
        }
    }
    public IEnumerator FCDisplay2()
    {
        OKText.SetActive(false);
        NGText.SetActive(false);
        ShortCheckText.SetActive(true);
        yield return new WaitForSeconds(4);
        ShortCheckText.SetActive(false);
        CheckText.SetActive(true);
        yield return new WaitForSeconds(6);
        CheckText.SetActive(false);
        OKText.SetActive(true);

    }
    public void FunctionCheckingDone2()
    {
        arrowActivator.ActivateObject(18);
        MainFromFCGrab2.enabled = true;
        HighlightMainFromFC2.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 45, subTitletxt); //Pick BCM Assembly from Function Checker using left hand
        }
    }
    public void Main2FromFCGrabbed()
    {
        if (currentStep != TrainingStep.Main2FromAssyGrabbed)
            return;

        currentStep = TrainingStep.Main2FromFcGrabbed;
        arrowActivator.DeactivateObject(18);
        arrowActivator.ActivateObject(21);
        ScanningMachine2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 46, subTitletxt); //Now, Go to Forth stage which is Sensitivity Checker and Scan the label on BCM Assembly
        }
    }

    public void ScanningMachine5Done()
    {
        arrowActivator.DeactivateObject(21);
        arrowActivator.ActivateObject(22);
        MainOnSCSnapPointObject.SetActive(true);
        SphereMainOnSC.SetActive(true);
        HighlightSphereMainOnSC.Highlight();
        StartCoroutine(ChangeColor2());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 47, subTitletxt); //Place BCM Assembly on the Sensitivity Checker jig as highlighted
        }
    }
    public IEnumerator ChangeColor2()
    {
        if (targetRenderer2 != null)
        {
            targetRenderer2.material.color = GreenColor; // Change color
        }
        yield return new WaitForSeconds(2);
        if (targetRenderer2 != null)
        {
            targetRenderer2.material.color = RedColor; // Change color
        }

    }
    public void MainOnSCSnapped()
    {
        arrowActivator.DeactivateObject(22);
        tooltipActivator.ActivateObject(10);
        SphereMainOnSC.SetActive(false);
        TrayScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 48, subTitletxt); //Push forward
        }

    }
    public void TrayPushed()
    {
        tooltipActivator.DeactivateObject(10);
        tooltipActivator.ActivateObject(12);
        DoorScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 49, subTitletxt); //Close the door
        }
    }
    public void BoxDoorClosed()
    {
        tooltipActivator.DeactivateObject(12);
        StartCoroutine(SensitivityCheckerDisplayNG());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 50, subTitletxt); //Wait for the Result on monitor screen
        }
    }
    public IEnumerator SensitivityCheckerDisplayNG()
    {
        CheckButton.SetActive(true);
        yield return new WaitForSeconds(6);
        CheckButton.SetActive(false);
        NGButton.SetActive(true);
        BoxDoorP4.Unlock();
        tooltipActivator.ActivateObject(11);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 51, subTitletxt); //Open the door
        }
    }
    public void BoxDoorOpened()
    {
        tooltipActivator.DeactivateObject(11);
        tooltipActivator.ActivateObject(13);
        sensitivityCheckerTray.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 52, subTitletxt); //Pull
        }
    }

    public void TrayPulled()
    {
        tooltipActivator.DeactivateObject(13);
        arrowActivator.ActivateObject(22);
        MainOnSCGrab.enabled = true;
        HighlightMainOnSC.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 53, subTitletxt); //  Pick BCM Assembly from Sensitivity Checker using left hand
        }
    }

    public void NGMainFromSCGrabbed()
    {
        if (currentStep != TrainingStep.Main2FromFcGrabbed)
            return;

        currentStep = TrainingStep.NGMainFromScGrabbed;
        HighlightMainOnSC.Unhighlight();
        arrowActivator.DeactivateObject(22);
        arrowActivator.ActivateObject(23);
        NGsnappoint4.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 54, subTitletxt); //It is a NG BCM Assembly so put this BCM Assembly in the highlighted NG box 
        }
    }
    public void NGMainFromSCSnapped(GameObject obj)
    {
        arrowActivator.DeactivateObject(23);
        arrowActivator.ActivateObject(18);
        Main2OnFCActivate.SetActive(true);
        HighlightMain2OnFC.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 55, subTitletxt); // Pick another BCM Assembly from the Function Checker - 1 jig using left hand
        }
    }
    public void Main3FromFCGrabbed()
    {
        if (currentStep != TrainingStep.NGMainFromScGrabbed)
            return;

        currentStep = TrainingStep.Main3FromFcGrabbed;
        HighlightMain2OnFC.Unhighlight();

        arrowActivator.DeactivateObject(18);
        arrowActivator.ActivateObject(21);
        ScanningMachine2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 56, subTitletxt); //Now, Go to Forth stage which is Sensitivity Checker and Scan the label on BCM Assembly
        }
    }

    public void ScanningMachine5Done2()
    {
        arrowActivator.DeactivateObject(21);
        arrowActivator.ActivateObject(22);
        MainOnSCSnapPointObject2.SetActive(true);
        SphereMainOnSC.SetActive(true);
        HighlightSphereMainOnSC.Highlight();
        StartCoroutine(ChangeColor2());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 57, subTitletxt); //Place BCM Assembly on the Sensitivity Checker jig as highlighted
        }
    }
    public void MainOnSCSnapped2()
    {
        arrowActivator.DeactivateObject(22);
        tooltipActivator.ActivateObject(10);
        SphereMainOnSC.SetActive(false);
        TrayScriptObject.SetActive(false);
        TrayScriptObject2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 58, subTitletxt); //Push forward
        }
    }

    public void TrayPushed2()
    {
        tooltipActivator.DeactivateObject(10);
        tooltipActivator.ActivateObject(12);
        DoorScriptObject.SetActive(false);
        DoorScriptObject2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 59, subTitletxt); //Close the door
        }

    }
    public void BoxDoorClosed2()
    {
        tooltipActivator.DeactivateObject(12);
        StartCoroutine(SensitivityCheckerDisplayOK());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 60, subTitletxt); //Wait for the Result on monitor screen
        }
    }
    public IEnumerator SensitivityCheckerDisplayOK()
    {
        NGButton.SetActive(false);
        CheckButton.SetActive(true);
        yield return new WaitForSeconds(6);
        CheckButton.SetActive(false);
        OKButton.SetActive(true);
        BoxDoor2P4.Unlock();
        tooltipActivator.ActivateObject(11);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 61, subTitletxt); //Open the door
        }
    }
    public void BoxDoorOpened2()
    {
        tooltipActivator.DeactivateObject(11);
        tooltipActivator.ActivateObject(13);
        sensitivityCheckerTray2.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 62, subTitletxt); // Pull
        }
    }

    public void TrayPulled2()
    {
        tooltipActivator.DeactivateObject(13);
        arrowActivator.ActivateObject(22);
        Main2OnSCGrab.enabled = true;
        HighlightMain2OnSC.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 63, subTitletxt); // Pick BCM Assembly from Sensitivity Checker using left hand
        }
    }

    public void MainFinalFromSCGrabbed()
    {
        if (currentStep != TrainingStep.Main3FromFcGrabbed)
            return;

        currentStep = TrainingStep.MainFromSCGrabbed;
        arrowActivator.DeactivateObject(22);
        arrowActivator.ActivateObject(24);
        ScanChecker3Activate.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 64, subTitletxt); // Scan the BCM assembly label using the scanner located on the right side of the sensitivity checker
        }
    }

    public void ScanningMachine5Done3()
    {
        arrowActivator.DeactivateObject(24);
        arrowActivator.ActivateObject(25);
        StartCoroutine(ChangeColor3());
        FinalSnapPointActivate.SetActive(true);
        PackingLineDisplay.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 65, subTitletxt); // Now, Go to Fifth stage which is Packing and Place BCM assembly in the tray as highlighted
        }
    }
    public IEnumerator PackingCanvas()
    {
        NowPrintButton.SetActive(true);
        yield return new WaitForSeconds(3);
        NowPrintButton.SetActive(false);
        FinishButton.SetActive(true);
    }
    public IEnumerator ChangeColor3()
    {
        if (targetRenderer3 != null)
        {
            targetRenderer3.material.color = GreenColor; // Change color
        }
        yield return new WaitForSeconds(2);
        if (targetRenderer3 != null)
        {
            targetRenderer3.material.color = RedColor; // Change color
        }
    }
    public void MainOnFinalSnappingDone()
    {
        arrowActivator.DeactivateObject(25);
        CongratsMessage.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(7, 66, subTitletxt); // Congratulations!
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
