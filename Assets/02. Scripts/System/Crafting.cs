using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Crafting : MonoBehaviour
{
    [Header("Drag&Drop")] 
    [SerializeField] private List<Recipe> _recipes;

    private CraftStuff _craftUI;
    public CraftStuff CraftUI => _craftUI;
    
    private List<Stuff> _craftStuff;
    public List<Stuff> CraftStuff => _craftStuff;

    private int _maxCount;
    public int MaxCount => _maxCount;

    private void Awake()
    {
        Init();
    }
    
    private void Start()
    {
        UIBinder.Instance.Mediate(this);
        _craftUI = UIBinder.Instance.GetCraftUI();
    }
    
    public Recipe CanCraft()
    {
        foreach (var recipe in _recipes)
        {
            int count = 0;
            foreach (var ingredient in recipe.Ingredients)
            {
                if (_craftStuff.Contains(ingredient.Stuff))
                {
                    count++;
                }
            }
            if (count == 2)
            {
                return recipe;
            }
        }
        return null;
    }
    
    public Item Craft(Recipe recipe)
    {
        foreach (var ingredient in recipe.Ingredients)
        {
            _craftStuff.Remove(ingredient.Stuff);
        }
        return recipe.Result;
    }

    public Stuff FindObject(int index)
    {
        if (index >= _craftStuff.Count) return null;
        return _craftStuff[index];
    }
    
    public void RemoveStuff(Stuff stuff)
    {
        _craftStuff.Remove(stuff);
    }
    
    private void Init()
    {
        _craftStuff = new List<Stuff>();
        _maxCount = 2;
    }
}
