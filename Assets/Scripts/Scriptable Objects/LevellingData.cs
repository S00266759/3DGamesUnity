using UnityEngine;

[CreateAssetMenu(
    fileName = "Levelling Curve", 
    menuName = "Custom/Levelling Curve")]
public class LevellingData : ScriptableObject
{
    [SerializeField] private AnimationCurve Curve;

    public int GetRequiredXP(int level)
    {
        return (int)Curve.Evaluate(level);
    }
}
