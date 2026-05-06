using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SMP1M4 : MonoBehaviour
{
    public ObjectActivator arrowActivator;
    public M1TooltipActivator tooltipActivator;
    [Header("Broken upperCover")]
    public GameObject MagnifyingChecker;
    public XRGrabInteractable UpperCoverBrokenGrab;
    public StepWiseHighlighter HighlightUpperCoverBroken;
    public GameObject ActivateNGTooltipOfBrokenCover;
    public GameObject SnapPointObjectCoverOnTable; // object which has snappoint sript of holding cover on table
    public CoverOnTableSnapPoint coverOnTableSnapPoint;
    public GameObject NGboxSnapPointobject;
    public NGdrawer2 nGdrawer2;
    public NG4SnapPoint nG4SnapPoint;
    [Header("Good upperCover but Cover Gap After Pressing")]
    public XRGrabInteractable CoverGrabFromTable;
    public StepWiseHighlighter HighlightCoverOnTable;
    public XRGrabInteractable UpperCoverGoodGrab;
    public StepWiseHighlighter HighlightUpperCoverGood;
    public GameObject UpperCoverSnappointOnCover;
    public GameObject SphereObjectUpperCover;
    public StepWiseHighlighter HighlightUpperCoverOnCover;
    public UpperCoverToMain upperCoverToMainCover;
    public GameObject SnapPointObjectMainCoverOnPunching;
    public GameObject SphereObjectMainCoverOnPUnching;
    public StepWiseHighlighter HighlightMainCoverOnPUnching;
    public UpperToPuncher upperToPuncher;
    public GameObject TooltipOfCheckingCoverSetProperly;
    public GameObject SideHandleActivate; //punching side handle
    public SideHandle2 sideHandle2;
    public PuncherHandle2 puncherHandle2;
    public GameObject HandleActivate; //punching side handle
    public XRGrabInteractable MainCoverOnPunchingGrab;
    public StepWiseHighlighter HighlightMainCoverOnPunching;
    public GameObject TooltipOfGapDefect;
    [Header("Good Main Part")]
    public GameObject GoodMainPart2OfBox;
    public StepWiseHighlighter HighlightGoodMainPart2OfBox;
    public GameObject MagnifyingChecker2;
    public XRGrabInteractable UpperCoverGoodGrab2;
    public StepWiseHighlighter HighlightUpperCoverGood2;

    public GameObject UpperCoverSnappointOnCover2;
    public GameObject SphereObjectUpperCover2;
    public StepWiseHighlighter HighlightUpperCoverOnCover2;
    public UpperCoverToMain2 upperCoverToMain2;
    public GameObject SnapPointObjectMainCoverOnPunching2;
    public UpperToPuncher2 upperToPuncher2;
    public XRGrabInteractable MainGoodCoverGrabFromPunching;
    public StepWiseHighlighter HighlightMainGoodCoverOnPunching;

    [Header(" Level ")]
    public TMP_Text subTitletxt;
    private int DrawerOpenedCount = 0;
    private int DrawerClosedCount = 0;
    private int activationCount = 0;
    private int SideHandleCloseCount = 0;
    private int SideHandleOpenCount = 0;
    private int PunchingDoneCount = 0;
    public enum TrainingStep
    {
        None,
        BackCoverGrabbed,
        BackCoverGrabbedFromTable,
        BackCoverGrabbed2,
        GoodCoverFromPunchGrabbed,
        GoodCoverFromBoxGrabbed,
        BackCoverGrabbed3

    }

    public TrainingStep currentStep = TrainingStep.None;
    void Start()
    {
        arrowActivator.ActivateObject(16);
        coverOnTableSnapPoint.CoversnappedToTable += CoverSnappingToTableDone;
        nGdrawer2.onReachedDesired += OnDrawerOpenedDynamic;
        nG4SnapPoint.OnObjectActivated += OnDefectSnappedToNGDynamic;
        nGdrawer2.onReachedOriginal += OnDrawerClosedDynamic;
        upperCoverToMainCover.UpperCoverSnappedToCover += UpperCoverSnappedToCover;
        upperToPuncher.UpperCoverSnappedToPuncher += MainCoverSnappedToPunching;
        sideHandle2.onReachedDesired += OnSideHandleClosedDynamic;
        puncherHandle2.onReachedOriginal += OnPunchingDoneDynamic;
        sideHandle2.onReachedOriginal += OnSideHandleOpenedDynamic;
        upperCoverToMain2.UpperCoverSnappedToCover2 += UpperCoverSnappedToCover2;
        upperToPuncher2.UpperCoverSnappedToPuncher2 += UpperCoverSnappedToPunching2;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 77, subTitletxt); // Go the next stage which is ANT cover assembly and start visual check for any defect under the magnifying glass
        }
    }
    private void OnDrawerOpenedDynamic()
    {
        DrawerOpenedCount++;

        Debug.Log($"Drawer opened {DrawerOpenedCount} times");

        switch (DrawerOpenedCount)
        {
            case 1:
                NGBoxOpeningDone();
                break;
            case 2:
                NGBoxOpeningDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnDrawerClosedDynamic()
    {
        DrawerClosedCount++;

        Debug.Log($"Drawer opened {DrawerClosedCount} times");

        switch (DrawerClosedCount)
        {
            case 1:
                NGBoxClosingDone();
                break;
            case 2:
                NGBoxClosingDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnDefectSnappedToNGDynamic(GameObject obj)
    {
        activationCount++;
        Debug.Log($"[{activationCount}] Received event: {obj.name} just activated!");

        switch (activationCount)
        {
            case 1:
                BrokenUpperCoverSnappedToNGBox(obj);
                break;

            case 2:
                GappedUpperCoverSnappedToNGBox(obj);
                break;

            case 3:
                //PinBentAfterPunching(obj);
                break;

            default:
                Debug.Log("Additional activations beyond the third.");
                break;
        }
    }

    private void OnSideHandleClosedDynamic()
    {
        SideHandleCloseCount++;

        Debug.Log($"Drawer opened {SideHandleCloseCount} times");

        switch (SideHandleCloseCount)
        {
            case 1:
                SideHandleLockingDone();
                break;
            case 2:
                 SideHandleLockingDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnSideHandleOpenedDynamic()
    {
        SideHandleOpenCount++;

        Debug.Log($"Drawer opened {SideHandleOpenCount} times");

        switch (SideHandleOpenCount)
        {
            case 1:
                SideHandleUnlockingDone();
                break;
            case 2:
                 SideHandleUnlockingDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
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
                PunchingDoneCorrectly();
                break;
            case 2:
                PunchingDoneCorrectly2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    public void MagnifyingChecked()
    {
        arrowActivator.DeactivateObject(16);
        arrowActivator.ActivateObject(17);
        UpperCoverBrokenGrab.enabled = true;
        HighlightUpperCoverBroken.Highlight();
        MagnifyingChecker.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 78, subTitletxt); //Pick antenna cover from tray using right hand
        }

    }
    public void BrokenUpperCoverGrabbed()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.BackCoverGrabbed;
        arrowActivator.DeactivateObject(17);
        ActivateNGTooltipOfBrokenCover.SetActive(true);
        arrowActivator.ActivateObject(21);
        SnapPointObjectCoverOnTable.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 79, subTitletxt); //It is a NG child part so put this antenna cover in the NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(1, 80, subTitletxt, 4.2f)); // Place antenna sub assembly on the table 
        }
    }


    public void CoverSnappingToTableDone()
    {
        arrowActivator.DeactivateObject(21);
        arrowActivator.ActivateObject(18);
        tooltipActivator.ActivateObject(14);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 81, subTitletxt); //Open the NG box
        }
    }
    private void NGBoxOpeningDone()
    {
        NGBoxOpened();
    }
    public void NGBoxOpened()
    {
        NGboxSnapPointobject.SetActive(true);
        tooltipActivator.DeactivateObject(14);
        arrowActivator.DeactivateObject(18);
        arrowActivator.ActivateObject(19);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 82, subTitletxt); //Place NG antenna cover in the NG box

        }
    }

    public void BrokenUpperCoverSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(19);
        tooltipActivator.ActivateObject(15);
        nGdrawer2.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 83, subTitletxt); //Close the NG box
        }
    }

    private void NGBoxClosingDone()
    {
        Debug.Log("First drawer open — NGdrawerClosed logic");
        // call your existing function here
        NGBoxClosed();
    }
    public void NGBoxClosed()
    {
        tooltipActivator.DeactivateObject(15);
        arrowActivator.ActivateObject(21);
        CoverGrabFromTable.enabled = true;
        HighlightCoverOnTable.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 84, subTitletxt); //Now pick antenna sub assembly from table using left hand
        }
    }


    public void CoverGrabbedFromTable()
    {
        if (currentStep != TrainingStep.BackCoverGrabbed)
            return;

        currentStep = TrainingStep.BackCoverGrabbedFromTable;
        arrowActivator.DeactivateObject(21);
        arrowActivator.ActivateObject(20);
        UpperCoverGoodGrab.enabled = true;
        HighlightUpperCoverGood.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 85, subTitletxt); //Pick antenna cover from tray using right hand
        }
    }
    public void GoodUpperCoverGrabbedFromTray()
    {
        if (currentStep != TrainingStep.BackCoverGrabbedFromTable)
            return;

        currentStep = TrainingStep.BackCoverGrabbed2;
        tooltipActivator.ActivateObject(42);
        arrowActivator.DeactivateObject(20);
        UpperCoverSnappointOnCover.SetActive(true);
        SphereObjectUpperCover.SetActive(true);
        HighlightUpperCoverOnCover.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 86, subTitletxt); //Place antenna cover on the antenna sub assembly same as highlighted
        }
    }

    public void UpperCoverSnappedToCover()
    {
        tooltipActivator.DeactivateObject(42);
        SphereObjectUpperCover.SetActive(false);
        arrowActivator.ActivateObject(22);
        SnapPointObjectMainCoverOnPunching.SetActive(true);
        SphereObjectMainCoverOnPUnching.SetActive(true);
        HighlightMainCoverOnPUnching.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 87, subTitletxt); //Go to the manual pressing machine and place the antenna sub assembly on the jig as highlighted
        }
    }
    public void MainCoverSnappedToPunching()
    {
        arrowActivator.DeactivateObject(22);
        SphereObjectMainCoverOnPUnching.SetActive(false);
        TooltipOfCheckingCoverSetProperly.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 88, subTitletxt); //Always ensure that the product is correctly positioned on the cover press jig.
        }
    }
    public void PressOKForCheckingFitting()
    {
        TooltipOfCheckingCoverSetProperly.SetActive(false);
        SideHandleActivate.SetActive(true);
        tooltipActivator.ActivateObject(17);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 89, subTitletxt); //After placing antenna sub assembly on jig , now close the toggle clamp
        }
    }
    private void SideHandleLockingDone()
    {
        SideHandleLocked();
    }
    public void SideHandleLocked()
    {
        tooltipActivator.DeactivateObject(17);
        tooltipActivator.ActivateObject(18);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 90, subTitletxt); //Always remember to close the toggle clamp
        }
        
    }
    public void PressOkForLockingCheckTooltip()
    {
        tooltipActivator.DeactivateObject(18);
        tooltipActivator.ActivateObject(19);
        HandleActivate.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 91, subTitletxt); //Pull the lever to press the antenna cover into the antenna sub assembly
        }

    }
    private void PunchingDoneCorrectly()
    {
        PunchingDone();
    }
    public void PunchingDone()
    {
        tooltipActivator.ActivateObject(20);
        sideHandle2.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 92, subTitletxt); //Open the toggle clamp
        }
    }
    private void SideHandleUnlockingDone()
    {
        SideHandleUnlocked();
    }
    public void SideHandleUnlocked()
    {
        tooltipActivator.DeactivateObject(20);
        MainCoverOnPunchingGrab.enabled = true;
        arrowActivator.ActivateObject(24);
        HighlightMainCoverOnPunching.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 93, subTitletxt); //Pick antenna sub assembly from manual punching machine
        }
    }
    public void GrabbedMainCoverFromPunching()
    {
        if (currentStep != TrainingStep.BackCoverGrabbed2)
            return;

        currentStep = TrainingStep.GoodCoverFromPunchGrabbed;
        arrowActivator.DeactivateObject(24);
        HighlightMainCoverOnPunching.Unhighlight();
        TooltipOfGapDefect.SetActive(true);
        arrowActivator.ActivateObject(18);
        tooltipActivator.ActivateObject(14);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 94, subTitletxt); //It is a NG child part so put this antenna sub assembly in the NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(1, 95, subTitletxt, 4.2f)); // Open the NG box 
        }
    }
    private void NGBoxOpeningDone2()
    {
        NGBoxOpened2();
    }
    public void NGBoxOpened2()
    {
        NGboxSnapPointobject.SetActive(true);
        tooltipActivator.DeactivateObject(14);
        arrowActivator.DeactivateObject(18);
        arrowActivator.ActivateObject(19);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 96, subTitletxt); // Place NG antenna cover in the NG box
        }
    }
    public void GappedUpperCoverSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(19);
        tooltipActivator.ActivateObject(15);
        nGdrawer2.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 97, subTitletxt); // Close the NG box
        }
    }

    private void NGBoxClosingDone2()
    {
        Debug.Log("First drawer open — NGdrawerClosed logic");
        // call your existing function here
        NGBoxClosed2();
    }
    public void NGBoxClosed2()
    {
        tooltipActivator.DeactivateObject(15);
        arrowActivator.ActivateObject(14);
        GoodMainPart2OfBox.SetActive(true);
        HighlightGoodMainPart2OfBox.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 98, subTitletxt); //  Now pick another final antenna sub assembly child part of stage 3 on AOI machine using left hand
        }
    }
    public void GrabbedGoodCoverFromBox()
    {
        if (currentStep != TrainingStep.GoodCoverFromPunchGrabbed)
            return;

        currentStep = TrainingStep.GoodCoverFromBoxGrabbed;
        arrowActivator.DeactivateObject(14);
        arrowActivator.ActivateObject(16);
        MagnifyingChecker2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 99, subTitletxt); //  Start visual check for any defect under the magnifying glass
        }
    }
    public void MagnifyingChecked2()
    {
        arrowActivator.DeactivateObject(16);
        arrowActivator.ActivateObject(25);
        UpperCoverGoodGrab2.enabled = true;
        HighlightUpperCoverGood2.Highlight();
        MagnifyingChecker2.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 100, subTitletxt); //Pick antenna cover from tray using right hand
        }
    }
    public void GrabbedUpperGoodCoverFromTray()
    {
        if (currentStep != TrainingStep.GoodCoverFromBoxGrabbed)
            return;

        currentStep = TrainingStep.BackCoverGrabbed3;
        tooltipActivator.ActivateObject(42);
        arrowActivator.DeactivateObject(25);
        UpperCoverSnappointOnCover2.SetActive(true);
        SphereObjectUpperCover2.SetActive(true);
        HighlightUpperCoverOnCover2.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 101, subTitletxt); //Place antenna cover on the antenna sub assembly same as highlighted
        }
    }

    public void UpperCoverSnappedToCover2()
    {
        tooltipActivator.DeactivateObject(42);
        SphereObjectUpperCover2.SetActive(false);
        arrowActivator.ActivateObject(22);
        SnapPointObjectMainCoverOnPunching2.SetActive(true);
        SphereObjectMainCoverOnPUnching.SetActive(true);
        HighlightMainCoverOnPUnching.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 102, subTitletxt); //Go to the manual pressing machine and place the antenna sub assembly on the jig as highlighted
        }
    }
    public void UpperCoverSnappedToPunching2()
    {
        arrowActivator.DeactivateObject(22);
        SphereObjectMainCoverOnPUnching.SetActive(false); 
        tooltipActivator.ActivateObject(17);
        puncherHandle2.UnlockHandle();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 103, subTitletxt); //After placing antenna sub assembly on jig , now close the toggle clamp
        }
    }
    private void SideHandleLockingDone2()
    {
        SideHandleLocked2();
    }
    public void SideHandleLocked2()
    {
        tooltipActivator.DeactivateObject(17);
        tooltipActivator.ActivateObject(19);
        HandleActivate.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 104, subTitletxt); //Pull the lever to press the antenna cover into the antenna sub assembly
        }
    }

    private void PunchingDoneCorrectly2()
    {
        PunchingDone2();
    }
    public void PunchingDone2()
    {
        tooltipActivator.ActivateObject(20);
        sideHandle2.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 105, subTitletxt); //Open the toggle clamp
        }
    }
    private void SideHandleUnlockingDone2()
    {
        SideHandleUnlocked2();
    }
    public void SideHandleUnlocked2()
    {
        tooltipActivator.DeactivateObject(20);
        arrowActivator.ActivateObject(24);
        MainGoodCoverGrabFromPunching.enabled = true;
        HighlightMainGoodCoverOnPunching.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 106, subTitletxt); //Pick antenna sub assembly from manual punching machine
        }
    }
    public void MainCoverGrabbedFromPunching2()
    {
        arrowActivator.DeactivateObject(24);
    }
}

