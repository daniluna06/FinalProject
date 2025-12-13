using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Coffee/Recipe")]
public class Recipes : ScriptableObject
{
    public enum IngredientType
    {
        Coffee,
        WholeMilk, OatMilk, AlmondMilk,
        CaramelSyrup, LavenderSyrup, MochaSyrup
    }
    public string recipeName;
    public List<IngredientType> requiredIngredients;
}
