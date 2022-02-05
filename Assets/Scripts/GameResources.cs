
using System.Collections.Generic;
using UnityEngine;

[SingletonOptions(name:"GAME-RESOURCES", isPrefab: true)]
public class GameResources : Singleton<GameResources>
{
    
    #region Fields
    [SerializeField] private EnemyData[] enemies;
    
    #endregion

    
    #region Properties
    
    //verif de non modif de la liste d'ennemis par le joueur
    public IReadOnlyList<EnemyData> Enemies => enemies;

    public override bool DontInstantiate => true;

    #endregion

}
