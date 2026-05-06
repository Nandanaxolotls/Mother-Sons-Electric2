using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class P4TestManager : MonoBehaviour
{
    public P4TestLowerOnTableSnapPoint p4TestLowerOnTableSnapPoint;
    public P4NG1SnapPoint p4NG1SnapPoint;
    public GameObject UpperOnTableSnapPointObject;
    public P4TestUpperOnTableSnapPoint p4TestUpperOnTableSnapPoint;
    public XRGrabInteractable LowerOnTableGrab;
    public GameObject LowerOnAssySnapPointObject;
    public LowerOnMainAssySnapPoint lowerOnMainAssySnapPoint;
    public GameObject PCBtoLowerSnapPointObject;
    public P4TestPCBOnLowerSnapPoint p4TestPCBOnLowerSnapPoint;
    public GameObject ScrewingJigScriptObject;
    public ScrewIngJigMachine screwIngJigMachine;
    public XRGrabInteractable DrilMachineGrab;
    public ScrewingDoneCheck screwingDoneCheck;
    public XRGrabInteractable UpperOnTableGrab;
    public GameObject UpperToLowerSnapPointObject;
    public UpperOnLowerSnapPoint upperOnLowerSnapPoint;
    public GameObject LabelOnMainSnapPointObject;
    public GameObject NGLabelBinSnapPointObject;
    public P4NG2BinSnapPoint p4NG2BinSnapPoint;
    public GameObject NGLabel2Activate;
    public GameObject GoodLabelActivate;
    public P4TestLabelOnMainSnapPoint p4TestLabelOnMainSnapPoint;
    public ScannerGun scannerGun;
    public GameObject GoodLabel2Activate;
    public XRGrabInteractable MainFromAssyGrab;
    public GameObject ScannerScript;
    public ScannerChecking ScannerChecking;
    public GameObject MainOnFCSnapPointObject;
    public MainOnFCSnapPoint mainOnFCSnapPoint;
    public FunctionCheckerMachine functioncheckerMachine;
    public XRGrabInteractable NGMainFromFCGrab;
    public P4NG3BinSnapPoint p4NG3BinSnapPoint;
    public GameObject Main2OnAssyActivate;
    public GameObject MainOnFCSnapPointObject2;
    public MainOnFCSnapPoint2 mainOnFCSnapPoint2;
    public XRGrabInteractable GoodMainFromFCGrab;
    public GameObject ScannerScript2;
    public ScannerChecking2 ScannerChecking2;
    public GameObject MainOnSCSnapPointObject;
    public MainOnSCSnapPoint mainOnSCSnapPoint;
    public GameObject TrayScriptObject;
    public SensitivityCheckerTray sensitivityCheckerTray;
    public GameObject DoorScriptObject;
    public BoxDoorP4 boxDoorP4;
    public XRGrabInteractable NGMainOnSCGrab;
    public P4NG4BinSnapPoint p4NG4BinSnapPoint;
    public GameObject Main2OnFCActivate;
    public GameObject MainOnSCSnapPointObject2;
    public MainOnSCSnapPoint2 mainOnSCSnapPoint2;
    public GameObject TrayScriptObject2;
    public SensitivityCheckerTray2 sensitivityCheckerTray2;
    public GameObject DoorScriptObject2;
    public BoxDoor2P4 boxDoor2P4;
    public XRGrabInteractable GoodMainOnSCGrab;
    public GameObject ScannerScript3;
    public ScannerChecking3 scannerChecking3;
    public GameObject FinalSnapPointObject;
    public MainOnFinalSnapPoint mainOnFinalSnapPoint;

    public Renderer targetRenderer1;
    public Renderer targetRenderer2;
    public Renderer targetRenderer3;
    public Color RedColor;
    public Color GreenColor;
    [Header("UI")]
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
    public GameObject ShortCheckText;
    public GameObject CheckText;
    public GameObject NGText;
    public GameObject OKText;
    [Space]
    public GameObject CheckButton;
    public GameObject NGButton;
    public GameObject OKButton;
    [Space]
    public GameObject ActivateOnPacking;
    public GameObject CongratsMessage;

    private bool LowerSnappedToTable = false;
    private bool UpperSnappedToTable = false;
    private bool LabelSnappingDone = false;
    private bool ScanningGunTriggered = false;
    private int NgSnapCount = 0;
    private int NgBinSnapCount = 0;
    private int Scanner1Count = 0;
    private int Scanner2Count = 0;
    private int FunctionCheckingDoneCount = 0;


    void Start()
    {
        p4TestLowerOnTableSnapPoint.LowerOnMachineSnapped += LowerOnTableSnapped;
        p4NG1SnapPoint.OnObjectActivated += OnDefectSnappedToNG1Dynamic;
        p4TestUpperOnTableSnapPoint.UpperOnMachineSnapped += UpperOnTableSnapped;
        lowerOnMainAssySnapPoint.LowerOnMachineSnapped += LowerOnAssySnapped;
        p4TestPCBOnLowerSnapPoint.PCBonLowerSnapped += PCBtoLowerSnapped;
        screwIngJigMachine.onReachedDesired += ScrewingJigClosed;
        screwingDoneCheck.AllScrewSnapped += AllScrewingDone;
        screwIngJigMachine.onReachedOriginal += ScrewingJigOpened;
        upperOnLowerSnapPoint.UpperOnLowerSnapped += UpperToLowerSnapped;
        p4NG2BinSnapPoint.OnObjectActivated += OnDefectSnappedToNGBinDynamic;
        p4TestLabelOnMainSnapPoint.LabelOnMainSnapped += GoodLabelToMainSnapped;
        scannerGun.LabelScanned += GunScanningDone;
        ScannerChecking.Scanned += OnScanner1ScannedDynamic;
        mainOnFCSnapPoint.MainOnFCSnapped += MainOnFcSnapped;
        functioncheckerMachine.FunctionCheckingDone += OnFunctionCheckerDoneDynamic;
        p4NG3BinSnapPoint.OnObjectActivated += NGMainSnappedToNGBox;
        mainOnFCSnapPoint2.MainOnFCSnapped += Main2OnFCSnapped;
        ScannerChecking2.Scanned += OnScanner2ScannedDynamic;
        mainOnSCSnapPoint.MainOnSCSnapped += MainOnSCSnapped;
        sensitivityCheckerTray.onReachedDesired += TrayPushed;
        boxDoorP4.onReachedDesired += DoorClosed;
        boxDoorP4.onReachedOriginal += DoorOpened;
        sensitivityCheckerTray.onReachedOriginal += TrayPulled;
        p4NG4BinSnapPoint.OnObjectActivated += NGMainFromSCSnappedToNGBox;
        mainOnSCSnapPoint2.MainOnSCSnapped += Main2OnSCSnapped;
        sensitivityCheckerTray2.onReachedDesired += TrayPushed2;
        boxDoor2P4.onReachedDesired += DoorClosed2;
        boxDoor2P4.onReachedOriginal += DoorOpened2;
        sensitivityCheckerTray2.onReachedOriginal += TrayPulled2;
        scannerChecking3.Scanned += Scanner3Scanned;
        mainOnFinalSnapPoint.MainOnFinalSnapped += LevelCompleted;

    }
    private void OnDefectSnappedToNG1Dynamic(GameObject obj)
    {
        NgSnapCount++;
        Debug.Log($"[{NgSnapCount}] Received event: {obj.name} just activated!");

        switch (NgSnapCount)
        {
            case 1:
                NGCrackLowerSnappedToNGBox(obj);
                break;

            case 2:
                NGBrokenLowerSnappedToNGBox(obj);
                break;

            case 3:
                NGCrackUpperSnappedToNGBox(obj);
                break;
            case 4:
                NGScratchUpperSnappedToNGBox(obj);
                break;
            case 5:
                NGBrokenPCBSnappedToNGBox(obj);
                break;
            case 6:
                NGCompMissPCBSnappedToNGBox(obj);
                break;
            default:
                Debug.Log("Additional activations beyond the third.");
                break;
        }
    }
    private void OnDefectSnappedToNGBinDynamic(GameObject obj)
    {
        NgBinSnapCount++;
        Debug.Log($"[{NgBinSnapCount}] Received event: {obj.name} just activated!");

        switch (NgBinSnapCount)
        {
            case 1:
                NGLabel1SnappedToNGBox(obj);
                break;

            case 2:
                NGLabel2SnappedToNGBox(obj);
                break;

            case 3:
               // NGCrackUpperSnappedToNGBox(obj);
                break;
            default:
                Debug.Log("Additional activations beyond the third.");
                break;
        }
    }
    private void OnScanner1ScannedDynamic()
    {
        Scanner1Count++;

        Debug.Log($"Drawer opened {Scanner1Count} times");

        switch (Scanner1Count)
        {
            case 1:
                Scanner1ScanningDone();
                break;
            case 2:
                Scanner1ScanningDone2();
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
    private void OnScanner2ScannedDynamic()
    {
        Scanner2Count++;

        Debug.Log($"Drawer opened {Scanner2Count} times");

        switch (Scanner2Count)
        {
            case 1:
                Scanner2ScanningDone();
                break;
            case 2:
                Scanner2ScanningDone2();
                break;

            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    public void NGCrackLowerFromTrayGrabbed()
    {
    }
    public void NGCrackLowerSnappedToNGBox(GameObject obj)
    {
    }
    public void NGBrokenLowerFromTrayGrabbed()
    {
    }
    public void NGBrokenLowerSnappedToNGBox(GameObject obj)
    {
    }
    public void GoodLowerFromTrayGrabbed()
    {
        CaseLowerDisplay.SetActive(true);
        CaseUpperDisplay.SetActive(true);
    }
    public void LowerOnTableSnapped()
    {
        LowerSnappedToTable = true;
        UpperOnTableSnapPointObject.SetActive(true);
        ActivateLowerGrabbable();
        CaseUpperDisplay.SetActive(false);
    }
    public void NGCrackUpperFromTrayGrabbed()
    {

    }
    public void NGCrackUpperSnappedToNGBox(GameObject obj)
    {
    }
    public void NGScratchUpperFromTrayGrabbed()
    {

    }
    public void NGScratchUpperSnappedToNGBox(GameObject obj)
    {
    }
    public void GoodUpperFromTrayGrabbed()
    {
    }
    public void UpperOnTableSnapped()
    {
        UpperSnappedToTable = true;
        ActivateLowerGrabbable();
        CaseLowerDisplay.SetActive(false);
        CaseUpperCenterDisplay.SetActive(true);
    }

    public void ActivateLowerGrabbable()
    {
        if (UpperSnappedToTable && LowerSnappedToTable)
        {
            LowerOnTableGrab.enabled = true;
        }
    }
    public void LowerFromTableGrabbed()
    {
        LowerOnAssySnapPointObject.SetActive(true);
    }
    public void LowerOnAssySnapped()
    {
        PCBtoLowerSnapPointObject.SetActive(true);
        CaseUpperCenterDisplay.SetActive(false);
        PCBOnCaseUpperCenterDisplay.SetActive(true);
    }
    public void NGBrokenPCBFromTrayGrabbed()
    {

    }
    public void NGBrokenPCBSnappedToNGBox(GameObject obj)
    {
    }
    public void NGCompMissPCBFromTrayGrabbed()
    {

    }
    public void NGCompMissPCBSnappedToNGBox(GameObject obj)
    {
    }
    public void GoodPCBFromTrayGrabbed()
    {

    }
    public void PCBtoLowerSnapped()
    {
        ScrewingJigScriptObject.SetActive(true);
        PCBOnCaseUpperCenterDisplay.SetActive(false);
        Panel1.SetActive(false);
        ScrewingPanel2.SetActive(true);
    }
    public void ScrewingJigClosed()
    {
        DrilMachineGrab.enabled = true;
    }
    public void DrilMachineGrabbed()
    {

    }
    public void AllScrewingDone()
    {
        screwIngJigMachine.Unlock();
        ScrewingPanel2.SetActive(false);
        UpperOnLowerPanel.SetActive(true);
    }
    public void ScrewingJigOpened()
    {
        UpperOnTableGrab.enabled = true;
    }
    public void UpperOnTableGrabbed()
    {
        UpperToLowerSnapPointObject.SetActive(true);
    }

    public void UpperToLowerSnapped()
    {
        LabelOnMainSnapPointObject.SetActive(true);
        UpperOnLowerPanel.SetActive(false);
        LabelPastingPanel.SetActive(true);
    }
    public void NGLabel1Grabbed()
    {
        NGLabelBinSnapPointObject.SetActive(true);
    }
    public void NGLabel1SnappedToNGBox(GameObject obj)
    {
        NGLabelBinSnapPointObject.SetActive(false);
        NGLabel2Activate.SetActive(true);
    }
    public void NGLabel2Grabbed()
    {
        NGLabelBinSnapPointObject.SetActive(true);
    }
    public void NGLabel2SnappedToNGBox(GameObject obj)
    {
        NGLabelBinSnapPointObject.SetActive(false);
        GoodLabelActivate.SetActive(true);
    }
    public void GoodLabelGrabbed()
    {

    }

    public void GoodLabelToMainSnapped()
    {
        LabelSnappingDone = true;
        LabelPastingPanel.SetActive(false);
        Panel1.SetActive(true);
        CaseLowerDisplay.SetActive(true);
        CaseUpperDisplay.SetActive(true);
        PCBOnCaseUpperCenterDisplay.SetActive(false);
        LabelScanned();
    }
    public void GunScanningDone()
    {
        if(LabelSnappingDone)
        {
            ScanningGunTriggered = true;
            LabelScanned();
        }
    }

    public void LabelScanned()
    {
        if(LabelSnappingDone && ScanningGunTriggered)
        {
            StartCoroutine(LabelPrintingCanvas());
            MainFromAssyGrab.enabled = true;
        }
    }
    public IEnumerator LabelPrintingCanvas()
    {
        NowPrintButton.SetActive(true);
        yield return new WaitForSeconds(2);
        NowPrintButton.SetActive(false);
        FinishButton.SetActive(true);
        GoodLabel2Activate.SetActive(true);   
    }
    public void Scanner1ScanningDone()
    {
        Scanner1Scanned();
    }
    public void Scanner1Scanned()
    {
        MainOnFCSnapPointObject.SetActive(true);
        StartCoroutine(ChangeColor1());
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
    public void MainOnFcSnapped()
    {
        ScannerScript.SetActive(false);
        functioncheckerMachine.StartProcess();
        StartCoroutine(FCDisplayNG());
    }
    public IEnumerator FCDisplayNG()
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
        NGMainFromFCGrab.enabled = true;
    }
    public void NGMainFromFCGrabbed()
    {
    }
    public void NGMainSnappedToNGBox(GameObject obj)
    {
        Main2OnAssyActivate.SetActive(true);
    }
    public void Main2FromAssyGrabbed()
    {     
        ScannerScript.SetActive(true);
    }
    public void Scanner1ScanningDone2()
    {
        Scanner1Scanned2();
    }
    public void Scanner1Scanned2()
    {
        StartCoroutine(ChangeColor1());
        MainOnFCSnapPointObject2.SetActive(true);
    }
    public void Main2OnFCSnapped()
    {
        StartCoroutine(FCDisplayOK());
        functioncheckerMachine.StartProcess();
    }
    public IEnumerator FCDisplayOK()
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
        GoodMainFromFCGrab.enabled = true;
    }
    public void MainFromFCGrabbed()
    {
        ScannerScript2.SetActive(true);
    }
    public void Scanner2ScanningDone()
    {
        Scanner2Scanned();
    }
    public void Scanner2Scanned()
    {
        MainOnSCSnapPointObject.SetActive(true);
        StartCoroutine(ChangeColor2());
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
        TrayScriptObject.SetActive(true);
    }

    public void TrayPushed()
    {
        DoorScriptObject.SetActive(true);
    }
    public void DoorClosed()
    {
        StartCoroutine(SensitivityCheckerDisplayNG());
    }
    public IEnumerator SensitivityCheckerDisplayNG()
    {
        CheckButton.SetActive(true);
        yield return new WaitForSeconds(6);
        CheckButton.SetActive(false);
        NGButton.SetActive(true);
        boxDoorP4.Unlock();
    }
    public void DoorOpened()
    {
        sensitivityCheckerTray.Unlock();
    }
    public void TrayPulled()
    {
        NGMainOnSCGrab.enabled = true;
    }
    public void NGMainFromSCSnappedToNGBox(GameObject obj)
    {
        Main2OnFCActivate.SetActive(true);
    }
    public void Main2FromFCGrabbed()
    {
    }
    public void Scanner2ScanningDone2()
    {
        Scanner2Scanned2();
    }
    public void Scanner2Scanned2()
    {
        MainOnSCSnapPointObject2.SetActive(true);
        StartCoroutine(ChangeColor2());
    }
    public void Main2OnSCSnapped()
    {
        TrayScriptObject.SetActive(false);
        TrayScriptObject2.SetActive(true);
    }
    public void TrayPushed2()
    {
        DoorScriptObject.SetActive(false);
        DoorScriptObject2.SetActive(true);
    }
    public void DoorClosed2()
    {
        StartCoroutine(SensitivityCheckerDisplayOK());
    }
    public IEnumerator SensitivityCheckerDisplayOK()
    {
        NGButton.SetActive(false);
        CheckButton.SetActive(true);
        yield return new WaitForSeconds(6);
        CheckButton.SetActive(false);
        OKButton.SetActive(true);
        boxDoor2P4.Unlock();
    }
    public void DoorOpened2()
    {
        sensitivityCheckerTray2.Unlock();
    }
    public void TrayPulled2()
    {
        GoodMainOnSCGrab.enabled = true;
    }
    public void GoodMainFromSCGrabbed()
    {
        ScannerScript3.SetActive(true);
    }
    public void Scanner3Scanned()
    {
        ActivateOnPacking.SetActive(true);
        FinalSnapPointObject.SetActive(true);
    }
    public void LevelCompleted()
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
