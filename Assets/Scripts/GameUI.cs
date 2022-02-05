using UnityEngine;

[SingletonOptions(name: "GAME-UI", isPrefab: true)]
public class GameUI : Singleton<GameUI>
{
    #region Fields

    [SerializeField] private UIEnemies uiEnemies;
    [SerializeField] private UIPlayer uiPlayer;

    #endregion

    #region Properties

    public UIEnemies UIEnemies => uiEnemies;
    
    public UIPlayer UIPlayer => uiPlayer;

    #endregion
}