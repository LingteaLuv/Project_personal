using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Crafting/Recipe")]
public class Recipe : ScriptableObject
{
    [System.Serializable]
    public class Ingredient
    {
        public Stuff Stuff;
        public int Amount;
    }

    public List<Ingredient> Ingredients;
    public Item Result;
}
