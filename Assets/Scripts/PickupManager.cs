using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupManager : MonoBehaviour
{
    public Image apple;
    public Image banana;
    public Image pear;
    public Image avocado;
    public Image lemon;
    public AudioSource winMusic;
    public GameObject winScreen;

    private List<Pickup> pickups;

    void Awake()
    {
        pickups = GetComponentsInChildren<Pickup>().ToList();
        foreach (Pickup pickup in pickups)
            pickup.Vanishing += Pickup_Vanishing;
    }

    private void Pickup_Vanishing(object sender, System.EventArgs e)
    {
        Pickup pickedUp = (Pickup)sender;
        string name = pickedUp.gameObject.name;
        switch(name)
        {
            case "Lemon":
                lemon.color = Color.white;
                break;
            case "Pear":
                pear.color = Color.white;
                break;
            case "Banana":
                banana.color = Color.white;
                break;
            case "Avocado":
                avocado.color = Color.white;
                break;
            case "Apple":
                apple.color = Color.white;
                break;
            default:
                Debug.Log("Broken switch on fruit name");
                break;
        }

        pickups.Remove(((Pickup)sender));
        if (pickups.Count == 0)
        {
            winScreen.SetActive(true);

            AudioSource[] sounds = FindObjectsOfType<AudioSource>();
            foreach (AudioSource sound in sounds)
                sound.enabled = false;
            winMusic.Play();
        }
            
            
            
        print(pickups.Count + " pickups left");
    }
}
