using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Crafting : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private PlayerInventory _stuffInventory;
    [SerializeField] private PlayerItemInventory _itemInventory;

    private bool CanCraft(Recipe recipe)
    {
        foreach (var ingredient in recipe.Ingredients)
        {
            if (_stuffInventory.ConfigStuff(ingredient.Stuff) < ingredient.Amount)
            {
                return false;
            }
        }

        return true;
    }

    // UI와 연동
    public void Craft(Recipe recipe)
    {
        if (!CanCraft(recipe))
        {
            Debug.Log("쟤료 부족");
            return;
        }

        foreach (var ingredient in recipe.Ingredients)
        {
            _stuffInventory.RemoveStuff(ingredient.Stuff, ingredient.Amount);
        }
        
        _itemInventory.AddItem(recipe.Result);
        Debug.Log("제작 성공");
    }
}
