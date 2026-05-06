using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class SMP1M6 : MonoBehaviour
{
    public ObjectActivator arrowActivator;
    public M1TooltipActivator tooltipActivator;

    public GameObject ScriptObjectStickerPressingSnapPoint;
    public StickerPressingSnapPoint stickerPressingSnapPoint;
    public GameObject StickerNG;
    public GameObject ScriptObjectStickerDustbin;
    public GameObject TooltipNGActivate;
    public StickerInDustbin stickerInDustbin;
    public GameObject Sticker;
    public GameObject ScriptObjectStickerPlacement;
    public stickerSnapPoint stickerSnapPoint;
    public GameObject StickerPressingScriptObject;
    public StickerPressing stickerPressing;
    public GameObject GreenButtonScriptObject;
    public GreenButton greenButton;
    public XRGrabInteractable MarkerGrab;
    public GameObject SphereObjectMarkerPoint;
    public GameObject ScriptObjectMarkerSnapPoint;
    public StepWiseHighlighter HighlightMarkingPoint;
    public Marking marking;
    public XRGrabInteractable GrabMainCoverFromStickerPressing;
    public GameObject FinalTrayScriptObject;
    public FinalStandSnapPoint finalStandSnapPoint;
    public GameObject CongratsMessage;
    [Header("Objects to Enable Grabbing")]
    public GameObject[] grabbableObjects;  // assign 11 objects here in Inspector
    [Header(" Level ")]
    public TMP_Text subTitletxt;
    public enum TrainingStep
    {
        None,
        NGStickerGrabbed,
        GoodStickerGrabbed,
        MarkerGrabbed,
        GrabbedMainCover
    }

    public TrainingStep currentStep = TrainingStep.None;

    void Start()
    {
        arrowActivator.ActivateObject(26);
        ScriptObjectStickerPressingSnapPoint.SetActive(true);
        stickerPressingSnapPoint.UpperCoverOnPressing += MainCoverSnappedToStickerPressing;
        stickerInDustbin.StickerDumped += NGStickerDumped;
        stickerSnapPoint.Stickersnapped += StickerSnappedToMainCover;
        stickerPressing.onReachedDesired += FlapClosed;
        greenButton.ButtonPressed += GreenButtonPressed;
        stickerPressing.onReachedOriginal += FlapOpened;
        marking.MarkingDone += Marked;
        finalStandSnapPoint.DoneLevel += LevelCompleted;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 117, subTitletxt); //Go to the next stage which is Label pasting and place it on the jig as highlighted

        }
    }
    public void MainCoverSnappedToStickerPressing()
    {
        arrowActivator.DeactivateObject(26);
        arrowActivator.ActivateObject(27);
        tooltipActivator.ActivateObject(28);
        StickerNG.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 118, subTitletxt); //Grab label from label printing machine
        }
    }
    public void NGStickerGrabbed()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.NGStickerGrabbed;
        arrowActivator.DeactivateObject(27);
        tooltipActivator.DeactivateObject(28);
        arrowActivator.ActivateObject(28);
        ScriptObjectStickerDustbin.SetActive(true);
        TooltipNGActivate.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 119, subTitletxt); //It is a NG label so put this label in the NG bin
        }
    }
    public void NGStickerDumped()
    {
        arrowActivator.DeactivateObject(28);
        arrowActivator.ActivateObject(27);
        tooltipActivator.ActivateObject(28);
        Sticker.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 120, subTitletxt); //Grab another label from label pasting machine
        }
    }
    public void GoodStickerGrabbed()
    {
        if (currentStep != TrainingStep.NGStickerGrabbed)
            return;

        currentStep = TrainingStep.GoodStickerGrabbed;
        tooltipActivator.ActivateObject(42);
        arrowActivator.DeactivateObject(27);
        tooltipActivator.DeactivateObject(28);
        arrowActivator.ActivateObject(26);
        ScriptObjectStickerPlacement.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 121, subTitletxt); //Stick label on the antenna sub assembly as highlighted
        }
    }
    public void StickerSnappedToMainCover()
    {
        tooltipActivator.DeactivateObject(42);
        arrowActivator.DeactivateObject(26);
        tooltipActivator.ActivateObject(29);
        StickerPressingScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 122, subTitletxt); //Close the flap using left hand 
        }
    }
    public void FlapClosed()
    {
        tooltipActivator.DeactivateObject(29);
        tooltipActivator.ActivateObject(30);
        GreenButtonScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 123, subTitletxt); //Press green button
        }
    }
    public void GreenButtonPressed()
    {
        tooltipActivator.DeactivateObject(30);
        tooltipActivator.ActivateObject(31);
        stickerPressing.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 124, subTitletxt); //Open the flap using left hand 
        }
    }
    public void FlapOpened()
    {
        tooltipActivator.DeactivateObject(31);
        arrowActivator.ActivateObject(29);
        MarkerGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 125, subTitletxt); //Grab the marker 
        }
    }
    public void MarkerGrabbed()
    {
        if (currentStep != TrainingStep.GoodStickerGrabbed)
            return;

        currentStep = TrainingStep.MarkerGrabbed;
        arrowActivator.DeactivateObject(29);
        SphereObjectMarkerPoint.SetActive(true);
        ScriptObjectMarkerSnapPoint.SetActive(true);
        HighlightMarkingPoint.Highlight();
        arrowActivator.ActivateObject(26);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 126, subTitletxt); //Make marking on antenna sub assembly as highlighted
        }
    }
    public void Marked()
    {
        SphereObjectMarkerPoint.SetActive(false);
        arrowActivator.DeactivateObject(26);
        GrabMainCoverFromStickerPressing.enabled = true;
        StartCoroutine(WaitToShowArrow());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 127, subTitletxt); // Leave marker on table and pick antenna sub assembly from label pasting jig 
        }
    }
    private IEnumerator WaitToShowArrow()
    {
        yield return new WaitForSeconds(2);
        arrowActivator.ActivateObject(26);
    }
    public void GrabbedMainCoverFromStickerPressing()
    {
        if (currentStep != TrainingStep.MarkerGrabbed)
            return;

        currentStep = TrainingStep.GrabbedMainCover;
        arrowActivator.DeactivateObject(26);
        arrowActivator.ActivateObject(30);
        FinalTrayScriptObject.SetActive(true);
        foreach (GameObject obj in grabbableObjects)
        {
            if (obj != null)
            {
                XRGrabInteractable grab = obj.GetComponent<XRGrabInteractable>();
                if (grab != null)
                    grab.enabled = true;
            }
        }
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 128, subTitletxt); //Now place the antenna sub assembly into the packing box and pack 12 antenna sub assembly at once in a row
        }
    }
    public void LevelCompleted()
    {
        arrowActivator.DeactivateObject(30);
        CongratsMessage.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 129, subTitletxt); //Congratulation!
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
