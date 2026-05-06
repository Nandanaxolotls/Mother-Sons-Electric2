using UnityEngine;

public class DripTip : MonoBehaviour
{
    public DrillMachine drillMechanic;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Drill Tip Trigger Enter: " + other.name);
        drillMechanic.OnDrillTipTriggerEnter(other);
    }


    private void OnTriggerExit(Collider other)
    {
        drillMechanic.OnDrillTipTriggerExit(other);
    }
}
