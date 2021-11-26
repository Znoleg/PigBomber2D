using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "FireGraphics",
    menuName = "ScriptableObjects/Graphics/FireGraphics")]
public class FireGraphics : ScriptableObject
{
    [SerializeField]
    private List<FireTypeSpritePair> _fireSprites;

    public IReadOnlyList<Sprite> GetFireSprites(FireType fireType)
    {
        return _fireSprites.First(pair => 
            pair.fireType.Equals(fireType)).animationSprites;
    }

    private void OnEnable()
    {
        int typesLength = Enum.GetValues(typeof(FireType)).Length;
        int listCount = _fireSprites.Count;
        if (_fireSprites.Count != typesLength)
        {
            Debug.LogWarning($"{name} fireSprites list has unimplemeted " +
                $"or recurring elements. List count: {listCount}; " +
                $"Expected: {typesLength}");
        }
    }


    [Serializable]
    private class FireTypeSpritePair
    {
        public FireType fireType;
        public List<Sprite> animationSprites;
    }
}

