using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Game/Enemy")]
public class EnemyData : ScriptableObject
{
    #region Fields

    [SerializeField] private Sprite icon;

    [SerializeField] private string displayName;

    [SerializeField] private int hpMax;

    [SerializeField] private int baseExpReward;

    #endregion

    #region Properties

    public Sprite Icon => icon;

    public string DisplayName => displayName;

    public int HPMax => hpMax;

    public int BaseEXPReward => baseExpReward;

    #endregion
}