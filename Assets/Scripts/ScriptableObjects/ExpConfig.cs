using UnityEngine;

namespace PM
{
    [CreateAssetMenu(fileName = "ExpConfig", menuName = "ScriptableObjects/ExpConfig")]
    public class ExpConfig : ScriptableObject
    {
        public int RequiredExpIncreaseFactor = 1000;
    }
}