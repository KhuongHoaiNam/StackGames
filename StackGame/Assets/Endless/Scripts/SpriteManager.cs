using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
[CreateAssetMenu(menuName = "Sprite Manager", fileName = "Sprite Manager")]
public class SpriteManager : ScriptableObject
{
    public List<SpriteClass> spriteClasses;

    public Sprite GetRandomSprite()
    {
        int randomIndex = UnityEngine.Random.Range(0, spriteClasses[0].sprite.Count);
        return spriteClasses[Datamanager.Instance.idPlayer].sprite[randomIndex];
    }
}
[Serializable]
public class SpriteClass
{
    public int idSpr;
    public List<Sprite> sprite;
}