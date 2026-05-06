using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SMP2TM5 : MonoBehaviour
{
    public ObjectActivator arrowActivator;
    public M1TooltipActivator tooltipActivator;
    public GameObject SphereObjectRemoteOnLaser;
    public StepWiseHighlighter SphereRemoteOnLaserHighlight;
    public GameObject RemoteKeySnapPointOnLaser;
    public RemoteKeyOnLaserSnapPoint remoteKeySnapPointOnLaser;
    public LaserMachine laserMachine;
    public XRGrabInteractable RemoteGrabFromLaser;
    public StepWiseHighlighter RemoteKeyFromLaserHighlight;
    public NGDrawer5P2 nGDrawer;
    public GameObject ScriptObjectNGBox;
    public GameObject NgSnapPointObject;
    public P2NG5SnapPoint p2NG5SnapPoint;
    [Space]
    public GameObject ActivateGoodKeyOnDrawer;
    public XRGrabInteractable GrabGoodKeyOnDrawer;

    public GameObject RemoteKeySnapPointOnLaser2;
    public RemoteKeyOnLaserSnapPoint2 remoteKeySnapPointOnLaser2;
    public XRGrabInteractable RemoteGrabFromLaser2;
    public StepWiseHighlighter RemoteKeyFromLaserHighlight2;

    public StepWiseHighlighter HighlightEmergencyKey;
    public Collider EmergencyKeyFromMainCollider;
    public XRGrabInteractable GrabEmergencyKeyFromMain;
    public GameObject KeySnapPointOnTable;
    public KeyOnTableP2M4SnapPoint2 keyOnTableP2M4SnapPoint2;


    [Header("UI")]
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
    [Header(" Level ")]
    public TMP_Text subTitletxt;

    private int LaserDoneCount = 0;
    public enum TrainingStep
    {
        None,
        RemoteFromLaserGrabbed,
        KeyGrabbed,
        GoodKeyFromDrawerGrabbed,
    }

    public TrainingStep currentStep = TrainingStep.None;

    void Start()
    {
        arrowActivator.ActivateObject(28);
        SphereObjectRemoteOnLaser.SetActive(true);
        SphereRemoteOnLaserHighlight.Highlight();
        RemoteKeySnapPointOnLaser.SetActive(true);
        remoteKeySnapPointOnLaser.RemoteKeySnapped += RemoteSnappedToLaser;
        laserMachine.LaserMachineDone += OnLaseringDoneDynamic;
        nGDrawer.onReachedDesired += NGdrawerOpened;
        p2NG5SnapPoint.OnObjectActivated += NGKeySnappedToNGBox;
        nGDrawer.onReachedOriginal += NGDrawerClosed;
        remoteKeySnapPointOnLaser2.RemoteKeySnapped += RemoteSnappedToLaser2;
        keyOnTableP2M4SnapPoint2.KeySnappedToTable += EmergencyKeySnappedToTable;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 115, subTitletxt); // Now, Move to Stage 6 which is Immobi communication checker. Align and place the Remocon onto the jig as highlighted
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
    public void RemoteSnappedToLaser()
    {
        arrowActivator.DeactivateObject(28);
        SphereObjectRemoteOnLaser.SetActive(false);
        laserMachine.StartProcess();
        StartCoroutine(DisplayOfDrawerNG());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 116, subTitletxt); // Wait for the Result on monitor screen
        }
    }
    public IEnumerator DisplayOfDrawerNG()
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
        RemoteGrabFromLaser.enabled = true;
        RemoteKeyFromLaserHighlight.Highlight();
        arrowActivator.ActivateObject(28);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 117, subTitletxt); //Pick Remocon from Immobi communication checker using left hand
        }
    }

    public void RemoteGrabbedFromLaser()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.RemoteFromLaserGrabbed;
        arrowActivator.DeactivateObject(28);
        HighlightEmergencyKey.Highlight();
        EmergencyKeyFromMainCollider.enabled = true;
        GrabEmergencyKeyFromMain.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 118, subTitletxt); //It is a NG part so put this Remocon in the NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(3, 119, subTitletxt, 4.2f)); // Before puting Remocon in the NG box first remove emergency key from Remocon 

        }
    }
    public void EmergencyKeyGrabbed()
    {
        if (currentStep != TrainingStep.RemoteFromLaserGrabbed)
            return;

        currentStep = TrainingStep.KeyGrabbed;
        KeySnapPointOnTable.SetActive(true);
        arrowActivator.ActivateObject(26);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 120, subTitletxt); //Place Emergency key on the table as highlighted
        }
    }
    public void EmergencyKeySnappedToTable()
    {
        arrowActivator.DeactivateObject(26);
        arrowActivator.ActivateObject(35);
        tooltipActivator.ActivateObject(32);
        ScriptObjectNGBox.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 121, subTitletxt); //Open the NG box
        }
    }

    public void NGdrawerOpened()
    {
        tooltipActivator.DeactivateObject(32);
        arrowActivator.DeactivateObject(35);
        arrowActivator.ActivateObject(36);
        NgSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 122, subTitletxt); //Place NG Remocon in the NG box
        }
    }
    public void NGKeySnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(36);
        tooltipActivator.ActivateObject(33);
        nGDrawer.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 123, subTitletxt); //Close the NG box
        }
    }
  
    public void NGDrawerClosed()
    {
        tooltipActivator.DeactivateObject(33);
        arrowActivator.ActivateObject(27);
        ActivateGoodKeyOnDrawer.SetActive(true);
        GrabGoodKeyOnDrawer.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 124, subTitletxt); //Now pick another final Remocon from Function Checker jig using left hand
        }
    }
    public void GrabbedGoodKeyFromDrawer()
    {
        if (currentStep != TrainingStep.KeyGrabbed)
            return;

        currentStep = TrainingStep.GoodKeyFromDrawerGrabbed;
        arrowActivator.DeactivateObject(27);
        arrowActivator.ActivateObject(28);
        SphereObjectRemoteOnLaser.SetActive(true);
        SphereRemoteOnLaserHighlight.Highlight();
        RemoteKeySnapPointOnLaser2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 125, subTitletxt); //Now, Move to Stage 6 which is Immobi communication checker. Align and place the Remocon onto the jig as highlighted
        }
    }
    public void RemoteSnappedToLaser2()
    {
        SphereObjectRemoteOnLaser.SetActive(false);
        arrowActivator.DeactivateObject(28);
        laserMachine.StartProcess();
        StartCoroutine(DisplayOfDrawerOK());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 126, subTitletxt); //Wait for the Result on monitor screen
        }
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
        RemoteGrabFromLaser2.enabled = true;
        RemoteKeyFromLaserHighlight2.Highlight();
        arrowActivator.ActivateObject(28);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 127, subTitletxt); //Pick Remocon from Immobi communication checker using left hand
        }
    }
    public void Remote2GrabbedFromLaser()
    {
        arrowActivator.DeactivateObject(28);
    }

}
