using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : Singleton<HudManager>
{
    [Header("Drag&Drop")] 
    [SerializeField] private Image _hpImage;
    [SerializeField] private Image _mentalityImage;
    [SerializeField] private Image _hungerImage;
    [SerializeField] private TMP_Text _hpText;
    [SerializeField] private TMP_Text _mentalityText;
    [SerializeField] private TMP_Text _hungerText;
    
    
    private void UpdateHpUI(int curHp)
    {
        _hpImage.fillAmount = (float)curHp / 100;
        _hpText.text = $"{curHp}";
    }

    private void UpdateMentalityUI(float curMentality)
    {
        _mentalityImage.fillAmount = curMentality / 100;
        _mentalityText.text = $"{(int)curMentality}";
    }
    
    private void UpdateHungerUI(float curHunger)
    {
        _hungerImage.fillAmount = curHunger / 100;
        _hungerText.text = $"{(int)curHunger}";
    }

    public void Subscribe(PlayerProperty playerProperty)
    {
        playerProperty.Hp.OnChanged += UpdateHpUI;
        playerProperty.Mentality.OnChanged += UpdateMentalityUI;
        playerProperty.Hunger.OnChanged += UpdateHungerUI;
    }
}
