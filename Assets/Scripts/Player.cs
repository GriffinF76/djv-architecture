using Sirenix.OdinInspector;

public class Player
{
    #region Properties

    [ShowInInspector] public int AttackPower => 4 + CurrentLevel;
    
    [ShowInInspector] public int CurrentLevel { get; private set; } = 1;
    
    [ShowInInspector] public int TotalEXP { get; private set; }
    
    [ShowInInspector] public int CurrentLevelEXP => GetRequiredEXP(CurrentLevel);
    
    [ShowInInspector] public int NextLevelEXP => GetRequiredEXP(CurrentLevel + 1);

    #endregion

    #region Public Methods

    [Button]
    public bool GainEXP(int exp)
    {
        if (NextLevelEXP - TotalEXP > exp)
        {
            TotalEXP += exp;
            GameUI.Instance.UIPlayer.Refresh();
            return false;
        }

        TotalEXP += exp;
        CurrentLevel++;
        GameUI.Instance.UIPlayer.Refresh();
        return true;
    }

    #endregion

    #region Private Methods

    private static int GetRequiredEXP(int level)
    {
        return (level - 1) * 100;
    }

    #endregion
}