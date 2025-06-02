using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : Singleton<HudManager>
{
    [Header("Drag&Drop")] 
    [SerializeField] private Image _hpImage;
    [SerializeField] private Image _mentalityImage;
    [SerializeField] private Image _hungerImage;
    
    private void UpdateHpUI(int curHp)
    {
        _hpImage.fillAmount = (float)curHp / 100;
    }

    private void UpdateMentalityUI(float curMentality)
    {
        _mentalityImage.fillAmount = curMentality / 100;
    }
    
    private void UpdateHungerUI(float curHunger)
    {
        _hungerImage.fillAmount = curHunger / 100;
    }

    public void Subscribe(PlayerProperty playerProperty)
    {
        playerProperty.Hp.OnChanged += UpdateHpUI;
        playerProperty.Mentality.OnChanged += UpdateMentalityUI;
        playerProperty.Hunger.OnChanged += UpdateHungerUI;
    }
}
