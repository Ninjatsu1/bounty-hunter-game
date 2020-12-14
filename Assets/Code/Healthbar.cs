using UnityEngine.UI;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
