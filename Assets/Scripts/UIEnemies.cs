using System.Collections.Generic;
using UnityEngine;

public class UIEnemies : MonoBehaviour
{
    #region Fields

    [SerializeField] private UIEnemy template;

    private readonly Dictionary<Enemy, UIEnemy> enemies = 
        new Dictionary<Enemy, UIEnemy>(); //readonly empêche l'assignation

    #endregion

    #region Public Methods

    public UIEnemy Get(Enemy enemy) =>
        enemies.TryGetValue(enemy, out var value)
            ? value
            : null;

    public void Add(Enemy enemy)
    {
        var uiEnemy = Instantiate(template, transform);
        uiEnemy.Initialize(enemy);
        enemies.Add(enemy, uiEnemy);
    }

    public void Remove(Enemy enemy)
    {
        if (!enemies.ContainsKey(enemy)) return;

        Destroy(enemies[enemy].gameObject);
        enemies.Remove(enemy);
    }

    #endregion
}