using TMPro;
using UnityEngine;

public class UIPlayer : MonoBehaviour
{
    #region Fields

    [SerializeField] private TextMeshProUGUI atkText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private UIBar uiBar;
    [SerializeField] private TextMeshProUGUI levelText;
    
    private Player player;

    #endregion

    #region Public Methods

    public void Refresh()
    {
        atkText.text = $"ATK {player.AttackPower}";
        expText.text = $"NEXT: {player.NextLevelEXP - player.TotalEXP} EXP";
        levelText.text = $"Level {player.CurrentLevel}";

        //Lerp computes a value btw 0 and 1 depending on the value you want
        uiBar.FillValue = Mathf.InverseLerp(player.CurrentLevelEXP, player.NextLevelEXP, player.TotalEXP);
    }
    
    #endregion

    #region Unity Event Functions

    protected void Awake()
    {
        player = Game.Instance.Player;
        Refresh();
    }

    #endregion
}