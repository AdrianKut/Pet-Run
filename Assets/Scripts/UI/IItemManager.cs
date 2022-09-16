using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemManager 
{
    public void InstantiateItem(string message) { }
    public void ChangeColorHighscoreItem(string nameOfGameObject, Color color) { }

    void InstantiateItem(string text, Color color, GameObject gameObject = null);
}
