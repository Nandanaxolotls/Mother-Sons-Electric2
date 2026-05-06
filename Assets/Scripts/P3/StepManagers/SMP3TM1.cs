using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class SMP3TM1 : MonoBehaviour
{
    public ObjectActivator arrowActivator;
    public M1TooltipActivator tooltipActivator;
    [Header("Crack UpperCase")]
    public StepWiseHighlighter HighlightPCB;
    public GameObject ChipChecker1SnapPointObject;
    public GameObject SphereObjectChipInChecker1;
    public StepWiseHighlighter SphereHighlightChipInChecker1;
    public ChipCheckerSnapPoint1 checkerSnapPoint1;
    public GameObject ChipChecker1Script;
    public ChipChecker1Machine chipChecker1Machine;
    public StepWiseHighlighter CrackUpperCaseInRackHighlight;
    public XRGrabInteractable GrabCrackUpperCaseInRack;
    public GameObject NGdrawer1ScriptObject;
    public NGDrawer1P3 nGDrawer1;
    public P3NG1SnapPoint p3NG1SnapPoint;

    public GameObject RedNgSnapPointObject;
    public P3REDNGSnapPoint p3RedNGSnapPoint;


    public GameObject NgSnapPointObject;
    [Header("OK UpperCase")]
    public StepWiseHighlighter GoodUpperCaseInRackHighlight;
    public XRGrabInteractable GrabGoodUpperCaseInRack;
    public StepWiseHighlighter BrokenButtonInRackHighlight;
    public XRGrabInteractable GrabBrokenButtonInRack;
    public GameObject FrontCoverOnTableSnapPointObject;
    public GameObject SphereFrontCoverOnTable;
    public StepWiseHighlighter HighlightSphereFrontCoverOnTable;
    public FrontCoverOnTableSnapPoint FrontCoverOnTable;
    [Space]
    public StepWiseHighlighter GoodUpperCaseOnTableHighlight;
    public XRGrabInteractable GrabGoodUpperCaseOnTable;
    public StepWiseHighlighter GoodButtonInRackHighlight;
    public XRGrabInteractable GrabGoodButtonInRack;
    public GameObject ButtonOnKeySnapPointObject;
    public GameObject SphereObjectButtonOnKey;
    public StepWiseHighlighter HighlightSphereObjectButtonOnKey;
    public ButtonSnapPoint buttonSnapPoint;
    [Header("Cut RubberCover")]
    public StepWiseHighlighter CutRubberCoverInRackHighlight;
    public XRGrabInteractable GrabCutRubberCoverInRack;
    public GameObject FrontCoverOnTable2SnapPointObject;
    public FrontCoverOnTableSnapPoint2 FrontCoverOnTable2;
    [Header("Good RubberCover")]
    public StepWiseHighlighter GoodUpperCaseOnTable2Highlight;
    public XRGrabInteractable GrabGoodUpperCaseOnTable2;
    public StepWiseHighlighter GoodRubberCoverInRackHighlight;
    public XRGrabInteractable GrabGoodRubberCoverInRack;
    public GameObject RubberOnKeySnapPointObject;
    public GameObject SphereObjectRubberOnKey;
    public StepWiseHighlighter HighlightSphereObjectRubberOnKey;
    public RubberCoverSnapPoint rubberCoverSnapPoint;
    public GameObject FrontCoverOnWaitingTraySnapPointObject;
    public WaitingTraySnapPoint waitingTraySnapPoint;
    public XRGrabInteractable GrabChipFromChecker1;
    public StepWiseHighlighter HighlightChipFromChecker1;
    public ChipCheckerSnapPoint2 chipCheckerSnapPoint2;
    public GameObject ChipOnChecker2SnapPointObject;
    public GameObject SphereObjectChipOnChecker2;
    public StepWiseHighlighter HighlightSphereObjectChipOnChecker2;
    [Header(" Stop wait call ")]
    public GameObject canvas;
    public GameObject ring;
    public GameObject StopText;
    public TMP_Text countdownText;          // Countdown text (e.g. "5", "4", "3"…)
    public GameObject ProgressRing;
    public Image progressRing;              // Circular progress ring (type = Filled ? Radial 360)
    public GameObject countdownUI;
    public float countdownTime = 5f;        // Duration in seconds
    public GameObject CallButton;
    public GameObject CompletedText;
    public GameObject BendPin;
    public GameObject GoodPin;
    [Header(" Chip checker 2 NG ")]
    public GameObject ChipChecker2Script;
    public ChipChecker2Machine ChipChecker2Machine;
    public StepWiseHighlighter HighlightChipOnChecker2;
    public XRGrabInteractable GrabChipOnChecker2;
    [Header(" Chip checker 2 ok ")]
    public GameObject Chip2OnChecker1;
    public StepWiseHighlighter HighlightChip2OnChecker1;
    public GameObject ChipOnChecker2SnapPointObject2;
    public GameObject ChipChecker2Script2;
    public ChipChecker2SnapPoint2 chipChecker2SnapPoint2;
    public ChipChecker2Machine2 ChipChecker2Machine2;
    public XRGrabInteractable GrabChip2FromChecker2;
    public XRGrabInteractable GrabFrontCoverFromWaitingTray;
    [Header(" Drop Part ")]
    public GameObject ChipOnKeySnapPointObject;
    public GameObject SphereChipOnKey;
    public StepWiseHighlighter HighlightSphereChipOnKey;
    public ChipOnKeySnapPoint chipOnKeySnapPoint;
    public GameObject ChipInHand;
    public GameObject ChipOnGround;
    public XRGrabInteractable DroppedFrontCoverGrab;
    public GameObject FrontCover2AfterDropOnWaiting;
    public GameObject WaitingTray2SnapPointObject;
    public WaitingTraySnapPoint2 waitingTraySnapPoint2;

    public GameObject RedNgSnapPointObject2;
    public P3RED2NGSnapPoint p3RED2NGSnapPoint;

    [Header("Clipping")]
    public XRGrabInteractable GrabBackCoverFromTray;
    public StepWiseHighlighter HighlightBackCoverFromTray;
    public GameObject SphereBackCoverOnClipping;
    public StepWiseHighlighter HighlightSphereBackCoverOnClipping;
    public GameObject BackCoverOnClippingSnapPointObject;
    public BackCoverOnClipingSnapPoint backCoverOnClipingSnapPoint;
    public XRGrabInteractable GrabNGBackCoverFromTray;
    public StepWiseHighlighter HighlightNGBackCoverFromTray;
    public XRGrabInteractable GrabNGClipFromTray;
    public StepWiseHighlighter HighlightNGClipFromTray;
    public XRGrabInteractable GrabClipFromTray;
    public StepWiseHighlighter HighlightClipFromTray;
    public GameObject ClipOnBackCoverSnapPointObject;
    public GameObject SphereClipOnBackCover;
    public StepWiseHighlighter HighlightSphereClipOnBackCover;
    public StepWiseHighlighter HighlightTool;
    public ClipOnKeySnapPoint clipOnKeySnapPoint;

    public XRGrabInteractable GrabTool;
    public GameObject ToolCanvas;
    public GameObject ToolCheckSnapPoint;
    public ToolScript toolScript;
    public GameObject ToolSnapPoint;
    public ToolOriginalPosSnapPoint toolOriginalPosSnapPoint;
    public GameObject ClippingMachineScript;
    public ClippingMachine clippingMachine;
    public XRGrabInteractable GrabBacKCoverFromClipping;
    public GameObject BackCoverOnWaitingSnapPointObject;
    public BackCoverOnWaitingTraySnapPoint backCoverOnWaitingTraySnapPoint;
    public XRGrabInteractable GrabFrontCoverFromWaitingTray2;

    [Header("UI1")]
    public GameObject Checker1CheckButton;
    public GameObject Checker1OKButton;
    [Header("UI2")]
    public GameObject Checker2CheckButton;
    public GameObject Checker2NGButton;
    public GameObject Checker2OKButton;
    [Header(" Level ")]
    public TMP_Text subTitletxt;

    private int NGOpenCount = 0;
    private int NGCloseCount = 0;
    private int NgSnapCount = 0;

    public enum TrainingStep
    {
        None,
        ChipGrabbed,
        NGFrontCoverGrabbed,
        FrontCoverGrabbed,
        NGButtonGrabbed,
        FrontCoverFromTableGrabbed,
        ButtonGrabbed,
        NGRubberCoverGrabbed,
        FrontCoverFromTableGrabbed2,
        RubberCoverGrabbed,
        ChipFromCheckerGrabbed,
        ChipFromChecker2Grabbed,
        Chip2FromCheckerGrabbed,
        Chip2FromChecker2Grabbed,
        FrontCoverFromWaitGrabbed,
        DroppedFrontCoverGrabbed,
        FrontCoverFromWaitGrabbed2,
        NGBackCoverGrabbed,
        BackCoverGrabbed,
        NGClipGrabbed,
        ClipGrabbed,
        ToolGrabbed,
        BackCoverFromClipperGrabbed,
    }

    public TrainingStep currentStep = TrainingStep.None;
    void Start()
    {
        HighlightPCB.Highlight();
        checkerSnapPoint1.ChipSnapped += ChipSnappedToChecker1;
        chipChecker1Machine.onReachedDesired += Checker1Closed;
        nGDrawer1.onReachedDesired += OnNGDrawerOpenedDynamic;
        p3RedNGSnapPoint.OnObjectActivated += OnDefectSnappedToNGDynamic;
        p3NG1SnapPoint.OnObjectActivated += NGChipSnappedToNGBox;
        nGDrawer1.onReachedOriginal += OnNGDrawerClosedDynamic;
        FrontCoverOnTable.FrontCoverSnapped += FrontCoverSnappedToTable;
        buttonSnapPoint.ButtonSnapped += ButtonSnappedToKey;
        FrontCoverOnTable2.FrontCoverSnapped += FrontCoverSnappedToTable2;
        rubberCoverSnapPoint.RubberCoverSnapped += RubberSnappedToKey;
        waitingTraySnapPoint.KeyOnWaitingTraySnapped += FrontCoverSnappedToWaitingTray;
        chipChecker1Machine.onReachedOriginal += Checker1Opened;
        chipCheckerSnapPoint2.ChipSnapped += ChipSnappedToChecker2;
        ChipChecker2Machine.onReachedDesired += Checker2Closed;
        ChipChecker2Machine.onReachedOriginal += Checker2Opened;
        chipChecker2SnapPoint2.ChipSnapped += Chip2SnappedToChecker2;
        ChipChecker2Machine2.onReachedDesired += Checker2Closed2;
        ChipChecker2Machine2.onReachedOriginal += Checker2Opened2;
        chipOnKeySnapPoint.ChipOnKeySnapped += ChipSnappedToKey;
        waitingTraySnapPoint2.KeyOnWaitingTray2Snapped += FrontCoverSnappedToWaitingTray2;
        p3RED2NGSnapPoint.OnObjectActivated += DroppedKeySnappedToNGBox;
        backCoverOnClipingSnapPoint.BackCoverSnappedToClipping += BackCoverSnappedToClipping;
        clipOnKeySnapPoint.ClipOnKeySnapped += ClipSnappedToBackCover;
        toolScript.MarkingDone += ToolMarkingDone;
        toolOriginalPosSnapPoint.ToolSnapped += ToolSnapped;
        clippingMachine.onReachedOriginal += ClippingDone;
        backCoverOnWaitingTraySnapPoint.BackCoverOnWaitingSnapped += BackCoverSnappedToWaiting;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 0, subTitletxt); //Welcome to the Transmitter Line simulation tutorial
            StartCoroutine(SoundManager.instance.PlayDelayedSound(5, 1, subTitletxt, 3f)); // Go to first stage which is Write ID Data and Pick circuit assembly from tray using left hand
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
               // NGdrawerOpeningDone2();
                break;
            case 3:
                //NGdrawerOpeningDone3();
                break;
            case 4:
               // NGdrawerOpeningDone4();
                break;
            case 5:
               // NGdrawerOpeningDone5();
                break;
            case 6:
              //  NGdrawerOpeningDone6();
                break;
            case 7:
              //  NGdrawerOpeningDone7();
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
               // NGdrawerClosingDone2();
                break;
            case 3:
               // NGdrawerClosingDone3();
                break;
            case 4:
               // NGdrawerClosingDone4();
                break;
            case 5:
               // NGdrawerClosingDone5();
                break;
            case 6:
               // NGdrawerClosingDone6();
                break;
            case 7:
              //  NGdrawerClosingDone7();
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
                CrackFrontCoverSnappedToNGBox(obj);
                break;

            case 2:
                BrokenButtonSnappedToNGBox(obj);
                break;

            case 3:
                CutRubberCoverSnappedToNGBox(obj);
                break;
            case 4:
                ScratchBackCoverSnappedToNGBox(obj);
                break;
            case 5:
                NGClipSnappedToNGBox(obj);
                break;
            default:
                Debug.Log("Additional activations beyond the third.");
                break;
        }
    }
    public void ChipGrabbedFromRack()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.ChipGrabbed;
        arrowActivator.DeactivateObject(0);
        arrowActivator.ActivateObject(1);
        ChipChecker1SnapPointObject.SetActive(true); // chip on checker1 snappoint script attached object
        SphereObjectChipInChecker1.SetActive(true); // Chip place highlighter object 
        SphereHighlightChipInChecker1.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 2, subTitletxt); //Place the Circuit Assembly onto the highlighted jig
        }
    }
    public void ChipSnappedToChecker1()
    {
        arrowActivator.DeactivateObject(1);
        tooltipActivator.ActivateObject(0);
        SphereObjectChipInChecker1.SetActive(false);
        ChipChecker1Script.SetActive(true); // checker 1 moving handle script
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 3, subTitletxt); //Close the flap using right hand
        }
    }
    public void Checker1Closed()
    {
        arrowActivator.ActivateObject(2);
        tooltipActivator.DeactivateObject(0);
        CrackUpperCaseInRackHighlight.Highlight();
        GrabCrackUpperCaseInRack.enabled = true;
        StartCoroutine(CheckerDisplay1());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 4, subTitletxt); // Pick Case Upper from tray using left hand
        }
    }
    public IEnumerator CheckerDisplay1()
    {
        Checker1CheckButton.SetActive(true);
        yield return new WaitForSeconds(3);
        Checker1CheckButton.SetActive(false);
        Checker1OKButton.SetActive(true);
    }
    public void CrackFrontCoverGrabbed()
    {
        if (currentStep != TrainingStep.ChipGrabbed)
            return;

        currentStep = TrainingStep.NGFrontCoverGrabbed;
        arrowActivator.DeactivateObject(2);
        tooltipActivator.ActivateObject(1);
        arrowActivator.ActivateObject(31);
        RedNgSnapPointObject.SetActive(true);
        //tooltipActivator.ActivateObject(2);
        //arrowActivator.ActivateObject(3);
        // NGdrawer1ScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 5, subTitletxt); //It is a NG child part so put this Case Upper in the NG box
        }
    }

    public void CrackFrontCoverSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(31);
        arrowActivator.ActivateObject(5);
        GoodUpperCaseInRackHighlight.Highlight();
        GrabGoodUpperCaseInRack.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 6, subTitletxt); //Pick another Case Upper from tray using left hand
        }
    }
 
    public void GoodFrontCoverGrabbed()
    {
        if (currentStep != TrainingStep.NGFrontCoverGrabbed)
            return;

        currentStep = TrainingStep.FrontCoverGrabbed;
        RedNgSnapPointObject.SetActive(false);
        arrowActivator.DeactivateObject(5);
        arrowActivator.ActivateObject(6);
        tooltipActivator.ActivateObject(21);
        BrokenButtonInRackHighlight.Highlight();
        GrabBrokenButtonInRack.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 7, subTitletxt); //Pick Switch knob from tray using right hand
        }

    }
    public void BrokenButtonInRackGrabbed()
    {
        if (currentStep != TrainingStep.FrontCoverGrabbed)
            return;

        currentStep = TrainingStep.NGButtonGrabbed;
        arrowActivator.DeactivateObject(6);
        tooltipActivator.DeactivateObject(21);
        tooltipActivator.DeactivateObject(4);
        tooltipActivator.ActivateObject(5);
        arrowActivator.ActivateObject(7);
        FrontCoverOnTableSnapPointObject.SetActive(true);
        SphereFrontCoverOnTable.SetActive(true);
        HighlightSphereFrontCoverOnTable.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 8, subTitletxt); // It is a NG child part
            StartCoroutine(SoundManager.instance.PlayDelayedSound(5, 9, subTitletxt, 3f)); // Place Case Upper on table 
        }

    }
    public void FrontCoverSnappedToTable()
    {
        tooltipActivator.DeactivateObject(5);
        arrowActivator.DeactivateObject(7);
        SphereFrontCoverOnTable.SetActive(false);
        arrowActivator.ActivateObject(31);
        RedNgSnapPointObject.SetActive(true);
        // tooltipActivator.ActivateObject(2);
        // arrowActivator.ActivateObject(3);
        // NGdrawer1ScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 10, subTitletxt); //Put this Switch knob in the highlighted NG box
        }
    }

    public void BrokenButtonSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(31);
        GoodUpperCaseOnTableHighlight.Highlight();
        GrabGoodUpperCaseOnTable.enabled = true;
        arrowActivator.ActivateObject(7);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 11, subTitletxt); // Pick Case Upper from table
        }
    }

    public void FrontCoverOnTableGrabbed()
    {
        if (currentStep != TrainingStep.NGButtonGrabbed)
            return;

        currentStep = TrainingStep.FrontCoverFromTableGrabbed;
        arrowActivator.DeactivateObject(7);
        arrowActivator.ActivateObject(8);
        GoodButtonInRackHighlight.Highlight();
        GrabGoodButtonInRack.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 12, subTitletxt); //Pick another Switch knob from tray using right hand
        }
    }
    public void GoodButtonInRackGrabbed()
    {
        if (currentStep != TrainingStep.FrontCoverFromTableGrabbed)
            return;

        currentStep = TrainingStep.ButtonGrabbed;
        tooltipActivator.ActivateObject(22);
        arrowActivator.DeactivateObject(8);
        ButtonOnKeySnapPointObject.SetActive(true);
        SphereObjectButtonOnKey.SetActive(true);
        HighlightSphereObjectButtonOnKey.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 13, subTitletxt); //Place Switch knob on the Case Upper as highlighted
        }
    }
    public void ButtonSnappedToKey()
    {
        tooltipActivator.DeactivateObject(22);
        SphereObjectButtonOnKey.SetActive(false);
        arrowActivator.ActivateObject(9);
        CutRubberCoverInRackHighlight.Highlight();
        GrabCutRubberCoverInRack.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 14, subTitletxt); //Pick Rubber from tray using right hand 
        }
    }
    public void RubberCoverInRackGrabbed()
    {
        if (currentStep != TrainingStep.ButtonGrabbed)
            return;

        currentStep = TrainingStep.NGRubberCoverGrabbed;
        arrowActivator.DeactivateObject(9);
        tooltipActivator.ActivateObject(6);
        arrowActivator.ActivateObject(7);
        FrontCoverOnTable2SnapPointObject.SetActive(true);
        SphereFrontCoverOnTable.SetActive(true);
        HighlightSphereFrontCoverOnTable.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 15, subTitletxt); // It is a NG child part
            StartCoroutine(SoundManager.instance.PlayDelayedSound(5, 16, subTitletxt, 3f)); // Place Case Upper on table 
        }

    }
    public void FrontCoverSnappedToTable2()
    {
        tooltipActivator.DeactivateObject(6);
        arrowActivator.DeactivateObject(7);
        SphereFrontCoverOnTable.SetActive(false);
        arrowActivator.ActivateObject(31);
        RedNgSnapPointObject.SetActive(true);
        // tooltipActivator.ActivateObject(2);
        // arrowActivator.ActivateObject(3);
        //  NGdrawer1ScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 17, subTitletxt); // Put this Rubber in the highlighted NG box 
        }
    }

    public void CutRubberCoverSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(31);
        arrowActivator.ActivateObject(7);
        GoodUpperCaseOnTable2Highlight.Highlight();
        GrabGoodUpperCaseOnTable2.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 18, subTitletxt); //Pick Case Upper from table
        }
    }

    public void FrontCover2GrabbedFromTable()
    {
        if (currentStep != TrainingStep.NGRubberCoverGrabbed)
            return;

        currentStep = TrainingStep.FrontCoverFromTableGrabbed2;
        RedNgSnapPointObject.SetActive(false);
        arrowActivator.DeactivateObject(7);
        arrowActivator.ActivateObject(10);
        GoodRubberCoverInRackHighlight.Highlight();
        GrabGoodRubberCoverInRack.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 19, subTitletxt); //Pick another Rubber from tray using right hand
        }
    }

    public void GoodRubberCoverGrabbed()
    {
        if (currentStep != TrainingStep.FrontCoverFromTableGrabbed2)
            return;

        currentStep = TrainingStep.RubberCoverGrabbed;
        tooltipActivator.ActivateObject(22);

        arrowActivator.DeactivateObject(10);
        RubberOnKeySnapPointObject.SetActive(true);
        SphereObjectRubberOnKey.SetActive(true);
        HighlightSphereObjectRubberOnKey.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 20, subTitletxt); //Place Rubber on the Case Upper as highlighted
        }

    }
    public void RubberSnappedToKey()
    {
        tooltipActivator.DeactivateObject(22);

        SphereObjectRubberOnKey.SetActive(false);
        arrowActivator.ActivateObject(12);
        FrontCoverOnWaitingTraySnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 21, subTitletxt); //Place Case Upper on waiting tray as highlighted
        }
    }
    public void FrontCoverSnappedToWaitingTray()
    {
        arrowActivator.DeactivateObject(12);
        chipChecker1Machine.Unlock();
        tooltipActivator.ActivateObject(7);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 22, subTitletxt); //Open the flap using right hand
        }
    }

    public void Checker1Opened()
    {
        tooltipActivator.DeactivateObject(7);
        arrowActivator.ActivateObject(1);
        GrabChipFromChecker1.enabled = true;
        HighlightChipFromChecker1.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 23, subTitletxt); //Pick Circuit Assembly from jig
        }
    }
    public void ChipFromCheckerGrabbed()
    {
        if (currentStep != TrainingStep.RubberCoverGrabbed)
            return;

        currentStep = TrainingStep.ChipFromCheckerGrabbed;
        arrowActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(11);
        ChipOnChecker2SnapPointObject.SetActive(true);
        SphereObjectChipOnChecker2.SetActive(true);
        HighlightSphereObjectChipOnChecker2.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 24, subTitletxt); //Proceed to the next highlighted jig and place the circuit assembly onto it.
        }

    }
    public void ChipSnappedToChecker2()
    {
        arrowActivator.DeactivateObject(11);
        SphereObjectChipOnChecker2.SetActive(false);
        ring.SetActive(true);
        canvas.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 25, subTitletxt); //Pin bend ( Stop Call )
            StartCoroutine(SoundManager.instance.PlayDelayedSound(5, 26, subTitletxt, 3f)); // Press Call senior button to inform senior about pin bend and repair it
        }
    }
    public void StopWaitCalled()
    {
        StartCoroutine(WaitToRepair());
    }


    private IEnumerator WaitToRepair()
    {
        StopText.SetActive(false);
        CallButton.SetActive(false);
        countdownUI.SetActive(true);
        ProgressRing.SetActive(true);
        float timeLeft = countdownTime;

        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            float normalized = Mathf.Clamp01(timeLeft / countdownTime);

            // Update text and ring fill
            countdownText.text = Mathf.CeilToInt(timeLeft).ToString();
            progressRing.fillAmount = normalized;

            yield return null;
        }
        ProgressRing.SetActive(false);
        countdownUI.SetActive(false);
        CompletedText.SetActive(true);
        yield return new WaitForSeconds(1);
        ring.SetActive(false);
        canvas.SetActive(false);
        BendPin.SetActive(false);
        GoodPin.SetActive(true);
        tooltipActivator.ActivateObject(8);
        ChipChecker2Script.SetActive(true); // checker 1 moving handle script
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 27, subTitletxt); //Close the flap using right hand
        }
    }
    public void Checker2Closed()
    {
        tooltipActivator.DeactivateObject(8);
        StartCoroutine(CheckerDisplay2());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 28, subTitletxt); //Wait for the Result on monitor screen
        }
    }
    public IEnumerator CheckerDisplay2()
    {
        Checker2CheckButton.SetActive(true);
        yield return new WaitForSeconds(3);
        Checker2CheckButton.SetActive(false);
        Checker2NGButton.SetActive(true);
        ChipChecker2Machine.Unlock();
        tooltipActivator.ActivateObject(9);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 29, subTitletxt); //Open the flap using right hand
        }
    }
    public void Checker2Opened()
    {
        tooltipActivator.DeactivateObject(9);
        arrowActivator.ActivateObject(11);
        HighlightChipOnChecker2.Highlight();
        GrabChipOnChecker2.enabled = true;
        ChipChecker2Script.SetActive(false); // checker 1 moving handle script
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 30, subTitletxt); //Pick Circuit Assembly from jig using left hand
        }
    }
    public void ChipGrabbedFromChecker2()
    {
        if (currentStep != TrainingStep.ChipFromCheckerGrabbed)
            return;

        currentStep = TrainingStep.ChipFromChecker2Grabbed;
        arrowActivator.DeactivateObject(11);
        tooltipActivator.ActivateObject(2);
        arrowActivator.ActivateObject(3);
        NGdrawer1ScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 31, subTitletxt); //It is a NG child part so put this Case Upper in the highlighted NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(5, 32, subTitletxt, 4.5f)); //Open the NG box 
        }
    }

    private void NGdrawerOpeningDone()
    {
        NGdrawerOpened();
    }
    public void NGdrawerOpened()
    {
        tooltipActivator.DeactivateObject(2);
        arrowActivator.DeactivateObject(3);
        arrowActivator.ActivateObject(4);
        NgSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 33, subTitletxt); // Place NG Circuit Assembly in the NG box
        }
    }
    public void NGChipSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(4);
        tooltipActivator.ActivateObject(3);
        nGDrawer1.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 34, subTitletxt); //Close the NG box
        }
    }
    private void NGdrawerClosingDone()
    {
        NGdrawerClosed();
    }

    public void NGdrawerClosed()
    {
        Chip2OnChecker1.SetActive(true);
        arrowActivator.ActivateObject(1);
        HighlightChip2OnChecker1.Highlight();
        NGdrawer1ScriptObject.SetActive(false);
        NgSnapPointObject.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 35, subTitletxt); //Pick another Circuit Assembly from highlighted jig
        }
    }
    public void Chip2OnChecker1Grabbed()
    {
        if (currentStep != TrainingStep.ChipFromChecker2Grabbed)
            return;

        currentStep = TrainingStep.Chip2FromCheckerGrabbed;
        arrowActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(11);
        ChipOnChecker2SnapPointObject2.SetActive(true);
        SphereObjectChipOnChecker2.SetActive(true);
        HighlightSphereObjectChipOnChecker2.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 36, subTitletxt); //Proceed to the next highlighted jig and place the circuit assembly onto it.
        }
    }
    public void Chip2SnappedToChecker2()
    {
        SphereObjectChipOnChecker2.SetActive(false);
        arrowActivator.DeactivateObject(11);
        tooltipActivator.ActivateObject(8);
        ChipChecker2Script2.SetActive(true); // checker 1 moving handle script
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 37, subTitletxt); //Close the flap using right hand
        }
    }
    public void Checker2Closed2()
    {
        tooltipActivator.DeactivateObject(8);
        StartCoroutine(CheckerDisplay3());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 38, subTitletxt); //Wait for the Result on monitor screen
        }
    }
    public IEnumerator CheckerDisplay3()
    {
        Checker2NGButton.SetActive(false);
        Checker2CheckButton.SetActive(true);
        yield return new WaitForSeconds(3);
        Checker2CheckButton.SetActive(false);
        Checker2OKButton.SetActive(true);
        ChipChecker2Machine2.Unlock();
        tooltipActivator.ActivateObject(9);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 39, subTitletxt); //Open the flap using right hand
        }
    }
  
    public void Checker2Opened2()
    {
        tooltipActivator.DeactivateObject(9);
        arrowActivator.ActivateObject(11);
        GrabChip2FromChecker2.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 40, subTitletxt); //Pick Circuit Assembly from jig using left hand
        }
    }
  
    public void Chip2FromChecker2Grabbed()
    {
        if (currentStep != TrainingStep.Chip2FromCheckerGrabbed)
            return;

        currentStep = TrainingStep.Chip2FromChecker2Grabbed;
        arrowActivator.DeactivateObject(11);
        arrowActivator.ActivateObject(12);
        GrabFrontCoverFromWaitingTray.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 41, subTitletxt); //Pick Case Upper from waiting tray
        }
    }
  
    public void FrontCoverFromWaitingTrayGrabbed()
    {
        if (currentStep != TrainingStep.Chip2FromChecker2Grabbed)
            return;

        currentStep = TrainingStep.FrontCoverFromWaitGrabbed;
        arrowActivator.DeactivateObject(12);
        ChipOnKeySnapPointObject.SetActive(true);
        SphereChipOnKey.SetActive(true);
        HighlightSphereChipOnKey.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 42, subTitletxt); //Place Circuit Assembly on the Case Upper as highlighted
        }
    }
    public void ChipSnappedToKey()
    {
        SphereChipOnKey.SetActive(false);
        arrowActivator.ActivateObject(13);
        StartCoroutine(FrontCoverDropped()); 
    }

    public IEnumerator FrontCoverDropped()
    {
        yield return new WaitForSeconds(1);
        arrowActivator.DeactivateObject(13);
        ChipInHand.SetActive(false);
        ChipOnGround.SetActive(true);
        arrowActivator.ActivateObject(14);
        DroppedFrontCoverGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 43, subTitletxt); // The Case Upper has slipped from your hand. Locate it on the ground and pick it up.”
        }
    }
    public GameObject DropCanvas;
 
    public void DroppedFrontCoverGrabbed()
    {
        if (currentStep != TrainingStep.FrontCoverFromWaitGrabbed)
            return;

        currentStep = TrainingStep.DroppedFrontCoverGrabbed;
        arrowActivator.DeactivateObject(14);
        arrowActivator.ActivateObject(32);
        RedNgSnapPointObject2.SetActive(true);
        //  tooltipActivator.ActivateObject(2);
        //  arrowActivator.ActivateObject(3);
        // NGdrawer1ScriptObject.SetActive(true);
        DropCanvas.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 44, subTitletxt); // Fallen part should be placed in the highlighted NG box 
        }
    }

    public void DroppedKeySnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(32);
        DropCanvas.SetActive(false);
        arrowActivator.ActivateObject(12);
        FrontCover2AfterDropOnWaiting.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 45, subTitletxt); //Pick another Case Upper from waiting tray and make sure that it should not fall
        }
    }

    public void FrontCover2FromWaitingTrayGrabbed()
    {
        if (currentStep != TrainingStep.DroppedFrontCoverGrabbed)
            return;

        currentStep = TrainingStep.FrontCoverFromWaitGrabbed2;
        RedNgSnapPointObject2.SetActive(false);

        arrowActivator.DeactivateObject(12);
        arrowActivator.ActivateObject(13);
        WaitingTray2SnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 46, subTitletxt); //Place the Case Upper onto the waiting tray on the right, as highlighted
        }

    }
   
    public void FrontCoverSnappedToWaitingTray2()
    {
        arrowActivator.DeactivateObject(13);
        arrowActivator.ActivateObject(19);
        GrabNGBackCoverFromTray.enabled = true;
        HighlightNGBackCoverFromTray.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 47, subTitletxt); //Pick Case Lower from tray using left hand
        }
    }

    public void NGBackCoverFromTrayGrabbed()
    {
        if (currentStep != TrainingStep.FrontCoverFromWaitGrabbed2)
            return;

        currentStep = TrainingStep.NGBackCoverGrabbed;
        arrowActivator.DeactivateObject(19);
        tooltipActivator.ActivateObject(11);
        arrowActivator.ActivateObject(31);
        RedNgSnapPointObject.SetActive(true);
        //  tooltipActivator.ActivateObject(2);
        //   arrowActivator.ActivateObject(3);
        //   NGdrawer1ScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 48, subTitletxt); //It is a NG child part so put this Case Lower in the NG box
        }

    }
  
    public void ScratchBackCoverSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(31);
        arrowActivator.ActivateObject(15);
        GrabBackCoverFromTray.enabled = true;
        HighlightBackCoverFromTray.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 49, subTitletxt); //Pick another Case Lower from tray using left hand
        }

    }

    public void BackCoverFromTrayGrabbed()
    {
        if (currentStep != TrainingStep.NGBackCoverGrabbed)
            return;

        currentStep = TrainingStep.BackCoverGrabbed;
        tooltipActivator.ActivateObject(21);
        RedNgSnapPointObject.SetActive(false);

        arrowActivator.DeactivateObject(15);
        arrowActivator.ActivateObject(16);
        BackCoverOnClippingSnapPointObject.SetActive(true) ;
        SphereBackCoverOnClipping.SetActive(true);
        HighlightSphereBackCoverOnClipping.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 50, subTitletxt); //Place the Case Lower onto the highlighted jig
        }
    }

    public void BackCoverSnappedToClipping()
    {
        tooltipActivator.DeactivateObject(21);

        arrowActivator.DeactivateObject(16);
        SphereBackCoverOnClipping.SetActive(false);
        arrowActivator.ActivateObject(18);
        GrabNGClipFromTray.enabled = true ;
        HighlightNGClipFromTray.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 51, subTitletxt); // Pick Terminal from tray using left hand
        }
    }

    public void GrabbedNGClipFromTray()
    {
        if (currentStep != TrainingStep.BackCoverGrabbed)
            return;

        currentStep = TrainingStep.NGClipGrabbed;
        arrowActivator.DeactivateObject(18);
        tooltipActivator.ActivateObject(12);
        arrowActivator.ActivateObject(31);
        RedNgSnapPointObject.SetActive(true);
        // tooltipActivator.ActivateObject(2);
        // arrowActivator.ActivateObject(3);
        // NGdrawer1ScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 52, subTitletxt); // It is a NG child part so put this Terminal in the highlighted NG box
        }
    }
   
    public void NGClipSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(31);
        arrowActivator.ActivateObject(17);
        GrabClipFromTray.enabled = true;
        HighlightClipFromTray.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 53, subTitletxt); // Pick another Terminal from tray using left hand
        }
    }   

    public void GrabbedClipFromTray()
    {
        if (currentStep != TrainingStep.NGClipGrabbed)
            return;

        currentStep = TrainingStep.ClipGrabbed;
        RedNgSnapPointObject.SetActive(false);
        tooltipActivator.ActivateObject(21);
        arrowActivator.DeactivateObject(17);
        arrowActivator.ActivateObject(16);
        ClipOnBackCoverSnapPointObject.SetActive(true);
        SphereClipOnBackCover.SetActive(true);
        HighlightSphereClipOnBackCover.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 54, subTitletxt); //Place the Terminal onto the Case Lower
        }

    }
    public void ClipSnappedToBackCover()
    {
        tooltipActivator.DeactivateObject(21);
        arrowActivator.DeactivateObject(16);
        SphereClipOnBackCover.SetActive(false);
        HighlightTool.Highlight();
        tooltipActivator.ActivateObject(10);
        GrabTool.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 55, subTitletxt); //Now grab the highlighted tool
        }
    }
    public void ToolGrabbed()
    {
        if (currentStep != TrainingStep.ClipGrabbed)
            return;

        currentStep = TrainingStep.ToolGrabbed;
        tooltipActivator.DeactivateObject(10);
        ToolCanvas.SetActive(true);
        ToolCheckSnapPoint.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 56, subTitletxt); //Take the tool tip near the highlighted point on Case Lower to fit terminal into the Case Lower
        }
    }
  
    public void ToolMarkingDone()
    {
        ToolCanvas.SetActive(false);
        ToolSnapPoint.SetActive(true);
        arrowActivator.ActivateObject(20);
        ClippingMachineScript.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 57, subTitletxt); //Place tool back to it's stand
        }
    }

    public void ToolSnapped()
    {
        arrowActivator.DeactivateObject(20);
        clippingMachine.StartClipping();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 58, subTitletxt); //Now, Wait for the process to complete
        }
    }

    public void ClippingDone()
    {
        GrabBacKCoverFromClipping.enabled = true;
        arrowActivator.ActivateObject(16);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 59, subTitletxt); //Pick Case Lower Sub Assembly from jig using left hand
        }
    }
    public void BackCoverGrabbedFromClipping()
    {
        if (currentStep != TrainingStep.ToolGrabbed)
            return;

        currentStep = TrainingStep.BackCoverFromClipperGrabbed;
        arrowActivator.DeactivateObject(16);
        arrowActivator.ActivateObject(21);
        BackCoverOnWaitingSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 60, subTitletxt); //Place the Case Lower Sub Assembly onto the waiting tray on the right, as highlighted
        }
    }
 
    public void BackCoverSnappedToWaiting()
    {
        arrowActivator.DeactivateObject(21);
        arrowActivator.ActivateObject(13);
        GrabFrontCoverFromWaitingTray2.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 61, subTitletxt); //Pick Case Upper Sub Assembly from waiting tray
        }
    }
    public void FrontCoverFromWaitingTray2Grabbed()
    {
        arrowActivator.DeactivateObject(13);
    }

}

