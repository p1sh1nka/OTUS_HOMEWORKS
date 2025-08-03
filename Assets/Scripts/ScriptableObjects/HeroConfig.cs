using System;
using System.Collections.Generic;
using UnityEngine;

namespace PM
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "ScriptableObjects/HeroConfig")]
    public class HeroConfig : ScriptableObject
    {
        //Info
        public string Name;
        public string Description;
        public Sprite Icon;

        //Level
        public int DefaultLevel;
        
        //Abilities
        public Dictionary<string, int> DefaultAbilities = new();
    }
}