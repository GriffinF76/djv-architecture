using UnityEngine;

public class Enemy
{
    #region Constructors

    public Enemy(EnemyData data)
    {
        Data = data;
        HP = data.HPMax;
    }

    #endregion

    #region Properties

    public EnemyData Data { get; }
    
    public bool IsKO => HP == 0;

    public int HP { get; private set; } //pas de champs "HP" car auto property 

    #endregion

    #region Public Methods

    public void TakeDamage(int damage)
    {
        //enemy loses HP points
        HP = Mathf.Max(HP - damage, 0);
        var uiEnemy = GameUI.Instance.UIEnemies.Get(this);
        if (uiEnemy != null)
        {
            uiEnemy.Refresh();
        }
    }

    #endregion
}