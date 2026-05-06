using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class StepManagerP4 : MonoBehaviour
{
    [Header("Scene Settings")]
    public string nextSceneName = "NextScene"; // assign your next scene name in Inspector
    public int maxReloadCount = 7;             // how many times to reload before switching scene
    private string reloadKey;
    public P4ArrowsActivator arrowActivator;
    public P4TooltipActivator tooltipActivator;
    [Header("Lower")]
    public StepWiseHighlighter HighlightLowerInBox;
    public GameObject LowerOnTableSnapPointObject;
    public GameObject SphereLowerOnTable;
    public StepWiseHighlighter HighlightSphereLowerOnTable;
    public LowerOnCaseAssySnapPoint lowerOnCaseAssySnapPoint;
    [Header("Upper")]
    public XRGrabInteractable UpperInBoxGrab;
    public StepWiseHighlighter HighlightUpperInBox;
    public GameObject UpperOnTableSnapPointObject;
    public GameObject SphereUpperOnTable;
    public StepWiseHighlighter HighlightSphereUpperOnTable;
    public UpperOnCaseAssySnapPoint UpperOnCaseAssySnapPoint;
    [Header("Lower On Table")]
    public XRGrabInteractable LowerOnTableGrab;
    public StepWiseHighlighter HighlightLowerOnTable;
    public GameObject LowerOnAssySnapPointObject;
    public GameObject SphereLowerOnAssy;
    public StepWiseHighlighter HighlightSphereLowerOnAssy;
    public LowerOnMainAssySnapPoint lowerOnMainAssySnapPoint;
    [Header(" PCB ")]
    public XRGrabInteractable PCBInBoxGrab;
    public StepWiseHighlighter HighlightPCBInBox;
    public GameObject PCBOnAssySnapPointObject;
    public GameObject SpherePCBOnAssy;
    public StepWiseHighlighter HighlightPCBLowerOnAssy;
    public PCBOnMainAssySnapPoint pCBOnMainAssySnapPoint;
    public GameObject ScrewingJigScriptObject;
    public ScrewIngJigMachine screwIngJigMachine;
    public XRGrabInteractable DrilMachine;
    public StepWiseHighlighter HighlightDrillMachine;
    public GameObject ScrewSnapPoint1;
    public GameObject ScrewSnapPoint2;
    public GameObject ScrewSnapPoint3;
    public GameObject ScrewSnapPoint4;
    public StepWiseHighlighter Screw;
    public DrillMachine drillMachine;
    public ScrewingDoneCheck screwingDoneCheck;
    public GameObject DrilMachineSnapPoint;
    public GameObject SphereDrilMachine;
    public StepWiseHighlighter HighlightSphereDrilMachine;
    public DrilMachineSnapPoint drilMachineSnapPoint;
    [Header("Upper On Table")]
    public XRGrabInteractable UpperOnTableGrab;
    public StepWiseHighlighter HighlightUpperOnTable;
    public GameObject UpperOnAssySnapPoint;
    public GameObject SphereUpperOnAssy;
    public StepWiseHighlighter HighlightSphereUpperOnAssy;
    public UpperOnLowerSnapPoint UpperOnLower;

    public XRGrabInteractable LabelGrab;
    public StepWiseHighlighter HighlightLabel;
    public GameObject LabelSnapPointObject;
    public GameObject SphereLabel;
    public StepWiseHighlighter HighlightSphereLabel;
    public LabelOnMainSnapPoint LabelOnMainSnapPoint;
    public XRGrabInteractable ScannerGunGrab;
    public StepWiseHighlighter HighlightScannerGun;
    public GameObject Label2;


    public XRGrabInteractable MainOnAssyGrab;
    public StepWiseHighlighter HighlightMainOnAssy;

    public ScannerGun scannerGun;
    public ScannerChecking ScannerChecking;
    public GameObject ScanCheckScript;
    public GameObject MainOnFCScriptObject;
    public GameObject SphereMainOnFC;
    public StepWiseHighlighter HighlightSphereMainOnFC;
    public MainOnFCSnapPoint mainOnFCSnapPoint;
    public FunctionCheckerMachine functionCheckerMachine;
    public XRGrabInteractable MainFromFCGrab;
    public StepWiseHighlighter HighlightMainOnFC;


    public GameObject ScanCheckScript2;
    public ScannerChecking2 ScannerChecking2;

    public GameObject MainOnSCScriptObject; // SC = sensitivity checker
    public GameObject SphereMainOnSC;
    public StepWiseHighlighter HighlightSphereMainOnSC;
    public MainOnSCSnapPoint mainOnSCSnapPoint;


    public Renderer targetRenderer1;
    public Renderer targetRenderer2;
    public Renderer targetRenderer3;
    public Color RedColor;
    public Color GreenColor;

    public GameObject TrayScriptObject;
    public SensitivityCheckerTray sensitivityCheckerTray;

    public GameObject BoxDoorScript;
    public BoxDoorP4 BoxDoorP4;
    public XRGrabInteractable MainOnSCGrab;
    public StepWiseHighlighter HighlightMainOnSC;

    public GameObject ScanCheckScript3;
    public ScannerChecking3 ScannerChecking3;
    public GameObject FinalSnapPointScriptObject;
    public MainOnFinalSnapPoint mainOnFinalSnapPoint;


    [Header(" UI ")]
    public GameObject ShortCheckText;
    public GameObject CheckText;
    public GameObject OKText;

    public GameObject CheckButton;
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
    [Header(" Level ")]
    public TMP_Text subTitletxt;

    // public GameObject LabelCollider;

    public bool PickedFirst = false;
    private int OnScanCount = 0;

    public enum TrainingStep
    {
        None,   
        LowerCoverGrabbed,
        UpperCoverGrabbed,
        LowerFromTableGrabbed,
        PCBGrabbed,
        DrilGrabbed,
        UpperFromTableGrabbed,
        LabelGrabbed,
        ScannerGunGrabbed,
        MainFromAssyGrabbed,
        MainFromFcGrabbed,
        MainFromScGrabbed,


    }

    public TrainingStep currentStep = TrainingStep.None;

    void Start()
    {
        arrowActivator.ActivateObject(0);
        HighlightLowerInBox.Highlight();
        lowerOnCaseAssySnapPoint.LowerOnMachineSnapped += LowerSnappedToTable;
        UpperOnCaseAssySnapPoint.UpperOnMachineSnapped += UpperSnappedToTable;
        lowerOnMainAssySnapPoint.LowerOnMachineSnapped += LowerSnappedToAssy;
        pCBOnMainAssySnapPoint.PCBOnMachineSnapped += PCBSnappedToAssy;
        screwIngJigMachine.onReachedDesired += ScrewJigClosed;
        drillMachine.PickedScrew += PickedScrewFirst;
        screwingDoneCheck.AllScrewSnapped += AllScrewingDone;
        drilMachineSnapPoint.DrilSnapped += DrilMachineSnapped;
        screwIngJigMachine.onReachedOriginal += ScrewJigOpened;
        UpperOnLower.UpperOnLowerSnapped += UpperSnappedToLower;
        LabelOnMainSnapPoint.LabelOnMachineSnapped += LabelSnapped;
        scannerGun.LabelScanned += LabelScanningDone;
        ScannerChecking.Scanned += MainScanned;
        mainOnFCSnapPoint.MainOnFCSnapped += MainOnFCSnapped;
        functionCheckerMachine.FunctionCheckingDone += FunctionCheckingDone;
        ScannerChecking2.Scanned += MainScanned2;
        mainOnSCSnapPoint.MainOnSCSnapped += MainToSCSnapped;
        sensitivityCheckerTray.onReachedDesired += TrayPushedForward;
        BoxDoorP4.onReachedDesired += BoxDoorClosed;
        BoxDoorP4.onReachedOriginal += BoxDoorOpened;
        sensitivityCheckerTray.onReachedOriginal += TrayPulledForward;
        ScannerChecking3.Scanned += MainScanned3;
        mainOnFinalSnapPoint.MainOnFinalSnapped += MainOnFinalSnapped;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 0, subTitletxt); //Welcome to the BCM Line simulation tutorial
            StartCoroutine(SoundManager.instance.PlayDelayedSound(6, 1, subTitletxt, 3f)); //Go to first stage which is Case Assembly & Label Paste and Pick Case Upper from tray using right hand
        }
    }


    public void LowerFromBoxGrabbed()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.LowerCoverGrabbed;
        arrowActivator.DeactivateObject(0);
        arrowActivator.ActivateObject(1);
        LowerOnTableSnapPointObject.SetActive(true);
        SphereLowerOnTable.SetActive(true);
        HighlightSphereLowerOnTable.Highlight();
        CaseLowerDisplay.SetActive(true);
        CaseUpperDisplay.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 2, subTitletxt); //Place Case Upper on jig as highlighted
        }
    }
    public void LowerSnappedToTable()
    {
        arrowActivator.DeactivateObject(1);
        SphereLowerOnTable.SetActive(false);
        arrowActivator.ActivateObject(2);
        UpperInBoxGrab.enabled = true;
        HighlightUpperInBox.Highlight();
        CaseUpperDisplay.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 3, subTitletxt); //Pick Case Lower from tray using right hand
        }
    }
    public void UpperFromBoxGrabbed()
    {
        if (currentStep != TrainingStep.LowerCoverGrabbed)
            return;

        currentStep = TrainingStep.UpperCoverGrabbed;
        arrowActivator.DeactivateObject(2);
        arrowActivator.ActivateObject(3);
        UpperOnTableSnapPointObject.SetActive(true );
        SphereUpperOnTable.SetActive(true ) ;
        HighlightSphereUpperOnTable.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 4, subTitletxt); //Place Case Lower in place as highlighted
        }
    }
    public void UpperSnappedToTable()
    {
        arrowActivator.DeactivateObject(3);
        SphereUpperOnTable.SetActive(false);
        arrowActivator.ActivateObject(1);
        LowerOnTableGrab.enabled = true;
        HighlightLowerOnTable.Highlight();
        CaseLowerDisplay.SetActive(false);
        CaseUpperCenterDisplay.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 5, subTitletxt); //Pick Case Upper using right hand
        }
    }
    public void LowerFromTableGrabbed()
    {
        if (currentStep != TrainingStep.UpperCoverGrabbed)
            return;

        currentStep = TrainingStep.LowerFromTableGrabbed;
        arrowActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(4);
        LowerOnAssySnapPointObject.SetActive(true);
        SphereLowerOnAssy.SetActive(true);
        HighlightSphereLowerOnAssy.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 6, subTitletxt); //Place Case Upper in on center jig as highlighted
        }
    }
    public void LowerSnappedToAssy()
    {
        arrowActivator.DeactivateObject(4);
        arrowActivator.ActivateObject(5);
        SphereLowerOnAssy.SetActive(false);
        PCBInBoxGrab.enabled = true;
        HighlightPCBInBox.Highlight();
        CaseUpperCenterDisplay.SetActive(false);
        PCBOnCaseUpperCenterDisplay.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 7, subTitletxt); //Pick Circuit Assembly from tray using left hand
        }
    }
    public void PCBinBoxGrabbed()
    {
        if (currentStep != TrainingStep.LowerFromTableGrabbed)
            return;

        currentStep = TrainingStep.PCBGrabbed;
        arrowActivator.DeactivateObject(5);
        arrowActivator.ActivateObject(4);
        PCBOnAssySnapPointObject.SetActive(true);
        SpherePCBOnAssy.SetActive(true);
        HighlightPCBLowerOnAssy.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 8, subTitletxt); //Place Circuit Assembly on the Case Upper as 
        }
    }
   
    public void PCBSnappedToAssy()
    {
        arrowActivator.DeactivateObject(4);
        SpherePCBOnAssy.SetActive(false);
        ScrewingJigScriptObject.SetActive(true);
        tooltipActivator.ActivateObject(0);
        Panel1.SetActive(false);
        ScrewingPanel2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 9, subTitletxt); //Close the flap
        }

    }
    public void ScrewJigClosed()
    {
        tooltipActivator.DeactivateObject(0);
        DrilMachine.enabled = true ;
        HighlightDrillMachine.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 10, subTitletxt); //Pick up the drill machine using your right hand
        }
    }
    public void DrillGrabbed()
    {
        if (currentStep != TrainingStep.PCBGrabbed)
            return;

        currentStep = TrainingStep.DrilGrabbed;
        arrowActivator.ActivateObject(6);
        Screw.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 11, subTitletxt); //Pick screws from the screw dispenser one at a time. When you reach the screwing point, press the trigger button to start the screwing process.
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
            arrowActivator.DeactivateObject(6); // screw in machine to pick arrow
          
            PickedFirst = true;
        }
    }

    public void AllScrewingDone()
    {
        // DrilMachineSnapPoint.SetActive(true);
        // SphereDrilMachine.SetActive(true);
        //  HighlightSphereDrilMachine.Highlight();
        tooltipActivator.ActivateObject(1);
        screwIngJigMachine.Unlock();
        ScrewingPanel2.SetActive(false);
        UpperOnLowerPanel.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 12, subTitletxt); // Now ungrab the power screwdriver and Open the flap
        }
    }
    public void DrilMachineSnapped()
    {
       // SphereDrilMachine.SetActive(false);
      
    }

    public void ScrewJigOpened()
    {
        tooltipActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(3);
        UpperOnTableGrab.enabled = true;
        HighlightUpperOnTable.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 13, subTitletxt); //Pick Case Lower using left hand
        }
    }
    public void UpperOnTableGrabbed()
    {
        if (currentStep != TrainingStep.DrilGrabbed)
            return;

        currentStep = TrainingStep.UpperFromTableGrabbed;
        arrowActivator.DeactivateObject(3);
        arrowActivator.ActivateObject(4);
        UpperOnAssySnapPoint.SetActive(true);
        SphereUpperOnAssy.SetActive(true);
        HighlightSphereUpperOnAssy.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 14, subTitletxt); //Place Case Lower on the Case Upper as highlighted
        }
    }

    public void UpperSnappedToLower()
    {
        SphereUpperOnAssy.SetActive(false);
        arrowActivator.DeactivateObject(4);
        arrowActivator.ActivateObject(7);
        LabelGrab.enabled = true;
        HighlightLabel.Highlight();
        UpperOnLowerPanel.SetActive(false);
        LabelPastingPanel.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 15, subTitletxt); //Pick Label from Label printing machine
        }
    }

    public void LabelGrabbed()
    {
        if (currentStep != TrainingStep.UpperFromTableGrabbed)
            return;

        currentStep = TrainingStep.LabelGrabbed;
        arrowActivator.DeactivateObject(7);
        arrowActivator.ActivateObject(4);
        LabelSnapPointObject.SetActive(true);
        SphereLabel.SetActive(true);
        HighlightSphereLabel.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 16, subTitletxt); //Stick label on the Case Lower as highlighted
        }
    }

    public void LabelSnapped()
    {
        arrowActivator.DeactivateObject(4);
        arrowActivator.ActivateObject(8);
        SphereLabel.SetActive(false);
        ScannerGunGrab.enabled = true;
        HighlightScannerGun.Highlight();
        LabelPastingPanel.SetActive(false);
        Panel1.SetActive(true);
        CaseLowerDisplay.SetActive(true);
        CaseUpperDisplay.SetActive(true);
        PCBOnCaseUpperCenterDisplay.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 17, subTitletxt); //Pick Label scanning gun using right hand
        }
    }

    public void ScannerGunGrabbed()
    {
        if (currentStep != TrainingStep.LabelGrabbed)
            return;

        currentStep = TrainingStep.ScannerGunGrabbed;
        arrowActivator.DeactivateObject(8);
        arrowActivator.ActivateObject(4);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 18, subTitletxt); //Scan the sticked label by taking scanner near the label and pressing trigger button
        }

    }
    public void LabelScanningDone()
    {
        arrowActivator.DeactivateObject(4);
        arrowActivator.ActivateObject(4);
        MainOnAssyGrab.enabled = true;
        HighlightMainOnAssy.Highlight();
        Label2.SetActive(true);
        StartCoroutine(PackingCanvas());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 19, subTitletxt); //Pick BCM Assembly from the jig
        }
    }
    public void MainGrabbedFromAssy()
    {
        if (currentStep != TrainingStep.ScannerGunGrabbed)
            return;

        currentStep = TrainingStep.MainFromAssyGrabbed;
        HighlightMainOnAssy.Unhighlight();

        arrowActivator.DeactivateObject(4);
        arrowActivator.ActivateObject(9);
        ScanCheckScript.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 20, subTitletxt); //Now, Go to Second stage which is Function Checker - 1 and Scan the label on BCM Assembly
        }
    }

    public void MainScanned()
    {
        arrowActivator.DeactivateObject(9);
        arrowActivator.ActivateObject(10);
        Debug.Log("Scanned Main");
        MainOnFCScriptObject.SetActive(true);
        SphereMainOnFC.SetActive(true);
        HighlightSphereMainOnFC.Highlight();
        StartCoroutine(ChangeColor1());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 21, subTitletxt); //Place BCM Assembly on the Function Checker jig as highlighted
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

    public void MainOnFCSnapped()
    {
        ScanCheckScript.SetActive(false);
        arrowActivator.DeactivateObject(10);
        SphereMainOnFC.SetActive(false);
        functionCheckerMachine.StartProcess();
        StartCoroutine(FCDisplay());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 22, subTitletxt); // Wait for the Result on monitor screen
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
        OKText.SetActive(true);
    }
 
    public void FunctionCheckingDone()
    {
        arrowActivator.ActivateObject(10);
        MainFromFCGrab.enabled = true;
        HighlightMainOnFC.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 23, subTitletxt); // Pick BCM Assembly from Function Checker using left hand
        }
    }
    public void MainFromFCGrabbed()
    {
        if (currentStep != TrainingStep.MainFromAssyGrabbed)
            return;

        currentStep = TrainingStep.MainFromFcGrabbed;
        HighlightMainOnFC.Unhighlight();

        arrowActivator.DeactivateObject(10);
        arrowActivator.ActivateObject(11);
        ScanCheckScript2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 24, subTitletxt); // Now, Go to Forth stage which is Sensitivity Checker and Scan the label on BCM Assembly
        }
    }
   
    public void MainScanned2()
    {
        arrowActivator.DeactivateObject(11);
        arrowActivator.ActivateObject(12);
        MainOnSCScriptObject.SetActive(true); // SC = sensitivity checker
        SphereMainOnSC.SetActive(true);
        HighlightSphereMainOnSC.Highlight();
        StartCoroutine(ChangeColor2());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 25, subTitletxt); // Place BCM Assembly on the Sensitivity Checker jig as highlighted
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

    public void MainToSCSnapped()
    {
        ScanCheckScript2.SetActive(false);
        arrowActivator.DeactivateObject(12);
        SphereMainOnSC.SetActive(false);
        tooltipActivator.ActivateObject(2);
        TrayScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 26, subTitletxt); // Push forward
        }
    }
    public void TrayPushedForward()
    {
        tooltipActivator.DeactivateObject(2);
        tooltipActivator.ActivateObject(4);
        BoxDoorScript.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 27, subTitletxt); // Close the door
        }
    }
    public void BoxDoorClosed()
    {
        tooltipActivator.DeactivateObject(4);
        StartCoroutine(SensitivityCheckerDisplay());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 28, subTitletxt); // Wait for the Result on monitor screen
        }
    }
  
    public IEnumerator SensitivityCheckerDisplay()
    {
        CheckButton.SetActive(true);
        yield return new WaitForSeconds(6);
        CheckButton.SetActive(false);
        OKButton.SetActive(true);
        BoxDoorP4.Unlock();
        tooltipActivator.ActivateObject(5);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 29, subTitletxt); // Open the door
        }
    }
    public void BoxDoorOpened()
    {
        tooltipActivator.DeactivateObject(5);
        tooltipActivator.ActivateObject(3);
        sensitivityCheckerTray.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 30, subTitletxt); // Pull
        }
    }
   
    public void TrayPulledForward()
    {
        tooltipActivator.DeactivateObject(3);
        arrowActivator.ActivateObject(12);
        MainOnSCGrab.enabled = true;
        HighlightMainOnSC.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 31, subTitletxt); // Pick BCM Assembly from Sensitivity Checker using left hand
        }
    }
    public void MainOnSCGrabbed()
    {
        if (currentStep != TrainingStep.MainFromFcGrabbed)
            return;

        currentStep = TrainingStep.MainFromScGrabbed;
        HighlightMainOnSC.Unhighlight();
        arrowActivator.DeactivateObject(12);
        arrowActivator.ActivateObject(13);
        ScanCheckScript3.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 32, subTitletxt); //Scan the BCM assembly label using the scanner located on the right side of the sensitivity checker
        }
    }

    public void MainScanned3()
    {
        arrowActivator.DeactivateObject(13);
        arrowActivator.ActivateObject(14);
        FinalSnapPointScriptObject.SetActive(true);
        StartCoroutine(ChangeColor3());
        PackingLineDisplay.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 33, subTitletxt); //Now, Go to Fifth stage which is Packing and Place BCM assembly in the tray as highlighted
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
    public void MainOnFinalSnapped()
    {
        arrowActivator.DeactivateObject(14);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(6, 34, subTitletxt); //Congratulations!
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
            SceneManager.LoadScene("P4TNG");
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
