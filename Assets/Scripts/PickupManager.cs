using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    private List<Pickup> pickups;

    void Awake()
    {
        pickups = GetComponentsInChildren<Pickup>().ToList();
        foreach (Pickup pickup in pickups)
            pickup.Vanishing += Pickup_Vanishing;
    }

    private void Pickup_Vanishing(object sender, System.EventArgs e)
    {

        pickups.Remove(((Pickup)sender));
        if (pickups.Count == 0)
            print("Game Over!");

        print(pickups.Count + " pickups left");
    }
}
