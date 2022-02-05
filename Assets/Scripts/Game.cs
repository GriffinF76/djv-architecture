using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Game : Singleton<Game>
{
    #region Fields

    [ShowInInspector] private readonly List<Enemy> enemies = new List<Enemy>();

    #endregion

    #region Properties

    [ShowInInspector] public Player Player { get; private set; } = new Player();

    #endregion

    #region Public Methods

    public void AttackEnemy(Enemy enemy)
    {
        enemy.TakeDamage(Player.AttackPower);

        if (!enemy.IsKO) return;

        Player.GainEXP(enemy.Data.BaseEXPReward);
        GameUI.Instance.UIEnemies.Remove(enemy);
        enemies.Remove(enemy);
    }

    #endregion

    #region Unity Event Functions

    protected void Start()
    {
        AddEnemy();
        StartCoroutine(FrequentlyAddEnemy());
    }

    #endregion

    #region Private Methods

    [Button]
    private void AddEnemy()
    {
        var allEnemyData = GameResources.Instance.Enemies;
        var index = Random.Range(0, allEnemyData.Count);
        var enemy = new Enemy(allEnemyData[index]);
        enemies.Add(enemy);
        GameUI.Instance.UIEnemies.Add(enemy);
    }

    private IEnumerator FrequentlyAddEnemy()
    {
        while (enabled) //tant que le script est activé
        {
            if (enemies.Count >= 4)
            {
                yield return null;
                continue;
            }

            float dt = Random.Range(3, 7);
            yield return new WaitForSeconds(dt);
            AddEnemy();
        }
    }

    #endregion
}