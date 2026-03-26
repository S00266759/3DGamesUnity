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

    //public LevellingData LevellingData;

    //void Start()
    //{
    //    Debug.Log(LevellingData.GetRequiredXP(1));
    //    Debug.Log(LevellingData.GetRequiredXP(10));
    //    Debug.Log(LevellingData.GetRequiredXP(50));
    //    Debug.Log(LevellingData.GetRequiredXP(100));
    //}
}
