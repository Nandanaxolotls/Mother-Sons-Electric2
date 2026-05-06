using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class SMP1M2 : MonoBehaviour
{
    public ObjectActivator arrowActivator;
    public M1TooltipActivator tooltipActivator;
    [Header("LS , ES and Bridge defects")]
    public GameObject SphereObjectChipOnSoldering1;
    public StepWiseHighlighter HighlightChipOnSoldering1;
    public GameObject SnapPointObjectOfCoverOnSoldering1;
    public CoverToSoldering coverToSoldering;
    public SolderingMachine solderingMachine;
    public XRGrabInteractable GrabChipWithDefect1;
    public GameObject tooltipOfDefect1;
    public NGdrawer nGdrawer;
    public GameObject NGDefectSnapPointObject2;
    public NG2SnapPoint nG2SnapPoint;
    [Header("Jig placement defect")]
    public GameObject ActivateSecondObjectFromPunching;
    public GameObject SnapPointObjectOfCoverOnSoldering2;
    public CoverToSoldering2 coverToSoldering2;
    public GameObject tooltipOfDefect2;
    public XRGrabInteractable GrabChipWithDefect2;
    // public GameObject CorrectPlacementSnapPointObjectOnSoldering;


    [Header("Solder Ball and NO solder defects")]
    public GameObject ActivateThirdObjectFromPunching;
    public GameObject SnapPointObjectOfCoverOnSoldering3;
    public CoverToSoldering3 coverToSoldering3;
    public GameObject tooltipOfDefect3;
    public XRGrabInteractable GrabChipWithDefect3;

    [Header("Good Final")]
    public GameObject ActivateGoodObjectFromPunching;
    public GameObject SnapPointObjectOfCoverOnSoldering4;
    public CoverToSoldering4 coverToSoldering4;
    public XRGrabInteractable GrabChipWithDefect4;
    [Header(" Level ")]
    public TMP_Text subTitletxt;

    private int SolderingStartCount = 0;
    private int SolderingDoneCount = 0;
    private int drawerOpenCount = 0;
    private int drawerCloseCount = 0;
    private int activationCount = 0;
    public enum TrainingStep
    {
        None,
        NGCoverGrabbed,
        GoodCoverFromPunchGrabbed,
        NGCoverGrabbed2,
        GoodCoverFromPunchGrabbed2,      
    }

    public TrainingStep currentStep = TrainingStep.None;
    void Start()
    {
        arrowActivator.ActivateObject(15);
        SphereObjectChipOnSoldering1.SetActive(true);
        HighlightChipOnSoldering1.Highlight();
        SnapPointObjectOfCoverOnSoldering1.SetActive(true);
        coverToSoldering.CoversnappedToSoldering += CoverSnappedToSoldering;
        solderingMachine.onProcessStart += OnSolderingStartedDynamic;
        solderingMachine.onProcessComplete += OnSolderingCompletedDynamic;
        nGdrawer.onReachedDesired += OnDrawerOpenedDynamic;
        nGdrawer.onReachedOriginal += OnDrawerClosedDynamic;
        nG2SnapPoint.OnObjectActivated += OnDefectSnappedToNGDynamic;
        //coverToSoldering2.CoversnappedToSoldering2 += CoverSnappedToSoldering2;
        coverToSoldering3.CoversnappedToSoldering3 += CoverSnappedToSoldering3;
        coverToSoldering4.CoversnappedToSoldering4 += CoverSnappedToSoldering4;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 35, subTitletxt); // Go to next stage which is terminal robot soldering and place it on the jig as highlighted
        }
    }

    private void OnSolderingStartedDynamic()
    {
        SolderingStartCount++;

        Debug.Log($"Drawer opened {SolderingStartCount} times");

        switch (SolderingStartCount)
        {
            case 1:
                SolderingStarted();
                break;
            case 2:
                SolderingStarted2();
                break;
            case 3:
                SolderingStarted3();

                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }


    private void OnSolderingCompletedDynamic()
    {
        SolderingDoneCount++;

        Debug.Log($"Drawer opened {SolderingDoneCount} times");

        switch (SolderingDoneCount)
        {
            case 1:
                SolderingDone1();
                break;
            case 2:
                SolderingDone2();
                break;
            case 3:
                SolderingDone3();

                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    private void OnDrawerOpenedDynamic()
    {
        drawerOpenCount++;

        Debug.Log($"Drawer opened {drawerOpenCount} times");

        switch (drawerOpenCount)
        {
            case 1:
                FirstDrawerOpen();
                break;
            case 2:
                ThirdDrawerOpen();
                // SecondDrawerOpen();
                break;
            case 3:

                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnDrawerClosedDynamic()
    {
        drawerCloseCount++;
        switch (drawerCloseCount)
        {
            case 1:
                FirstDrawerClosed();
                break;
            case 2:
                ThirdDrawerClosed();
                // SecondDrawerClosed();
                break;
            case 3:

                break;
            default:
                Debug.Log("Drawer closed again, beyond the third time.");
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
                SolderingDefect1SnappedToNGbox(obj);
                break;

            case 2:
                NSSBDefect3SnappedToNGbox(obj);
                // FittingDefect2SnappedToNGbox(obj);
                break;

            case 3:

                break;

            default:
                Debug.Log("Additional activations beyond the third.");
                break;
        }
    }
    public void CoverSnappedToSoldering()
    {
        arrowActivator.DeactivateObject(15);
        tooltipActivator.DeactivateObject(41);
        SphereObjectChipOnSoldering1.SetActive(false);
        tooltipActivator.ActivateObject(39);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 36, subTitletxt); //Always check for the fitting on jig

        }

    }
    public void OkButtonToCheckFittingOnJig()
    {
        tooltipActivator.DeactivateObject(39);
        tooltipActivator.ActivateObject(13);
        solderingMachine.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 37, subTitletxt); //Press green button to start soldering
        }
    }

    public void SolderingStarted()
    {
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 38, subTitletxt); //Wait for the soldering process to complete 
        }
    }
    private void SolderingDone1()
    {
        SolderingCompleted();
    }
    public void SolderingCompleted()
    {
        arrowActivator.ActivateObject(15);
        GrabChipWithDefect1.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 39, subTitletxt); //Pick antenna sub assembly from soldering machine
        }
    }
    public void DefectCoverGrabbedFromSoldering1()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.NGCoverGrabbed;
        arrowActivator.DeactivateObject(15);
        tooltipOfDefect1.SetActive(true);
        arrowActivator.ActivateObject(1);
        tooltipActivator.ActivateObject(0);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 40, subTitletxt); // It is a NG child part so put this antenna sub assembly in the NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(1, 41, subTitletxt, 4.2f)); // Open the NG box 

        }
    }
    private void FirstDrawerOpen()
    {
        NGdrawerOpened();
    }
    public void NGdrawerOpened()
    {
        tooltipActivator.DeactivateObject(0);
        arrowActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(2);
        NGDefectSnapPointObject2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 42, subTitletxt); //Place NG antenna sub assembly in the NG box
        }
    }
    public void SolderingDefect1SnappedToNGbox(GameObject obj)
    {
        arrowActivator.DeactivateObject(2);
        tooltipActivator.ActivateObject(1);
        nGdrawer.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 43, subTitletxt); //Close the NG box
        }
    }
    private void FirstDrawerClosed()
    {
        NGdrawerClosed();
    }
    public void NGdrawerClosed()
    {
        tooltipActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(8);
        //  ActivateSecondObjectFromPunching.SetActive(true);
        ActivateThirdObjectFromPunching.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 44, subTitletxt); //Now pick another final antenna sub assembly child part of stage 1 on pressing machine using left hand
        }
    }
    //public void GrabbedSecondObjectFromPunching()
    //{
    //    arrowActivator.DeactivateObject(8);
    //    arrowActivator.ActivateObject(15);
    //    SphereObjectChipOnSoldering1.SetActive(true);
    //    HighlightChipOnSoldering1.Highlight();
    //    SnapPointObjectOfCoverOnSoldering2.SetActive(true);
    //}
    //public void CoverSnappedToSoldering2()
    //{
    //    arrowActivator.DeactivateObject(15);
    //    SphereObjectChipOnSoldering1.SetActive(false);
    //    tooltipOfDefect2.SetActive(true);
    //    StartCoroutine(ShowArrowAfterTime());
    //    GrabChipWithDefect2.enabled = true;
    //}
    //public IEnumerator ShowArrowAfterTime()
    //{
    //    yield return new WaitForSeconds(2);
    //    arrowActivator.ActivateObject(15);
    //}

    //public void DefectCoverGrabbedFromSoldering2()
    //{
    //    arrowActivator.DeactivateObject(15);
    //    arrowActivator.ActivateObject(15);
    //  //  CorrectPlacementSnapPointObjectOnSoldering.SetActive(true);
    //    arrowActivator.ActivateObject(1);
    //    tooltipActivator.ActivateObject(0);
    //}
    //private void SecondDrawerOpen()
    //{
    //    NGdrawerOpened2();
    //}
    //public void NGdrawerOpened2()
    //{
    //    tooltipActivator.DeactivateObject(0);
    //    arrowActivator.DeactivateObject(1);
    //    arrowActivator.ActivateObject(2);
    //    NGDefectSnapPointObject2.SetActive(true);
    //}
    //public void FittingDefect2SnappedToNGbox(GameObject obj)
    //{
    //    arrowActivator.DeactivateObject(2);
    //    tooltipActivator.ActivateObject(1);
    //    nGdrawer.Unlock();
    //}
    //private void SecondDrawerClosed()
    //{
    //    NGdrawerClosed2();
    //}
    //public void NGdrawerClosed2()
    //{
    //    tooltipActivator.DeactivateObject(1);
    //    arrowActivator.ActivateObject(8);
    //    ActivateThirdObjectFromPunching.SetActive(true);
    //}
    public void GrabbedThirdObjectFromPunching()
    {
        if (currentStep != TrainingStep.NGCoverGrabbed)
            return;

        currentStep = TrainingStep.GoodCoverFromPunchGrabbed;
        arrowActivator.DeactivateObject(8);
        arrowActivator.ActivateObject(15);
        SphereObjectChipOnSoldering1.SetActive(true);
        HighlightChipOnSoldering1.Highlight();
        SnapPointObjectOfCoverOnSoldering3.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 45, subTitletxt); //Go to terminal robot soldering and place it on the jig as highlighted
        }
    }
    public void CoverSnappedToSoldering3()
    {
        SphereObjectChipOnSoldering1.SetActive(false);
        arrowActivator.DeactivateObject(15);
        tooltipActivator.ActivateObject(13);
        solderingMachine.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 46, subTitletxt); //Press green button to start soldering
        }
    }
    public void SolderingStarted2()
    {
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 47, subTitletxt); //Wait for the soldering process to complete 
        }
    }
    private void SolderingDone2()
    {
        SolderingCompleted2();
    }
    public void SolderingCompleted2()
    {
        arrowActivator.ActivateObject(15);
        GrabChipWithDefect3.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 48, subTitletxt); //Pick antenna sub assembly from soldering machine
        }
    }
    public void DefectCoverGrabbedFromSoldering3()
    {
        if (currentStep != TrainingStep.GoodCoverFromPunchGrabbed)
            return;

        currentStep = TrainingStep.NGCoverGrabbed2;
        arrowActivator.DeactivateObject(15);
        tooltipOfDefect3.SetActive(true);
        arrowActivator.ActivateObject(1);
        tooltipActivator.ActivateObject(0);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 49, subTitletxt); //It is a NG child part so put this antenna sub assembly in the NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(1,50, subTitletxt, 4.2f)); // Open the NG box 
            

        }
    }
    private void ThirdDrawerOpen()
    {
        NGdrawerOpened3();
    }
    public void NGdrawerOpened3()
    {
        tooltipActivator.DeactivateObject(0);
        arrowActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(2);
        NGDefectSnapPointObject2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 51, subTitletxt); //Place NG antenna sub assembly in the NG box
        }
    }
    public void NSSBDefect3SnappedToNGbox(GameObject obj)
    {
        arrowActivator.DeactivateObject(2);
        tooltipActivator.ActivateObject(1);
        nGdrawer.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 52, subTitletxt); //Close the NG box
        }
    }
    private void ThirdDrawerClosed()
    {
        NGdrawerClosed3();
    }
    public void NGdrawerClosed3()
    {
        tooltipActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(8);
        ActivateGoodObjectFromPunching.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 53, subTitletxt); //Now pick another final antenna sub assembly child part of stage 1 on pressing machine using left hand
        }
    }
    public void GrabbedFourthObjectFromPunching()
    {
        if (currentStep != TrainingStep.NGCoverGrabbed2)
            return;

        currentStep = TrainingStep.GoodCoverFromPunchGrabbed2;
        arrowActivator.DeactivateObject(8);
        arrowActivator.ActivateObject(15);
        SphereObjectChipOnSoldering1.SetActive(true);
        HighlightChipOnSoldering1.Highlight();
        SnapPointObjectOfCoverOnSoldering4.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 54, subTitletxt); //Go to terminal robot soldering and place it on the jig as highlighted
        }
    }
    public void CoverSnappedToSoldering4()
    {
        SphereObjectChipOnSoldering1.SetActive(false);
        arrowActivator.DeactivateObject(15);
        tooltipActivator.ActivateObject(13);
        solderingMachine.enabled = true;
        NGDefectSnapPointObject2.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 55, subTitletxt); //Press green button to start soldering
        }
    }
    public void SolderingStarted3()
    {
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 56, subTitletxt); //Wait for the soldering process to complete 
        }
    }

    private void SolderingDone3()
    {
        SolderingCompleted3();
    }
    public void SolderingCompleted3()
    {
        arrowActivator.ActivateObject(15);
        GrabChipWithDefect4.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 57, subTitletxt); //Pick antenna sub assembly from soldering machine 
        }
    }
    public void GoodCoverGrabbedFromSoldering4()
    {
        arrowActivator.DeactivateObject(15);
        tooltipActivator.ActivateObject(41);
    }


}