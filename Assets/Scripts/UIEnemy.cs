using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIEnemy : MonoBehaviour, IPointerDownHandler
{
    #region Fields

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private UIBar uiBar;

    #endregion
    
    #region Properties

    public Enemy Enemy { get; private set; }

    #endregion

    #region Public Methods

    public void OnPointerDown(PointerEventData ev)
    {
        Game.Instance.AttackEnemy(Enemy);
    }

    public void Initialize(Enemy newEnemy)
    {
        Enemy = newEnemy;
        icon.sprite = newEnemy.Data.Icon;
        nameText.text = newEnemy.Data.DisplayName;
        expText.text = $"+ {newEnemy.Data.BaseEXPReward} EXP";
        Refresh(); //initialise hpText et uiBar directement
    }

    public void Refresh()
    {
        hpText.text = $"{Enemy.HP} HP";
        uiBar.FillValue = (float) Enemy.HP / Enemy.Data.HPMax;
    }

    #endregion
}