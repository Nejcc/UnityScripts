# UnityScripts
Helpfull unity scripts

## Get tag 
```cs
if( hit.transform.gameObject.tag == "Interact"){
  Debug.Log("Colide with interact tile");
}
```
## Get dropdown in inspector
```cs
public enum TileSetType {Forest,Grassland,Housing};

[SerializeField] public TileSetType tileType;
```

## Spawn items in the world with X and z cordinats
```cs
public void SpawnUnitAt(GameObject PlayerUnitPrefab, int q, int r)
{
  GameObject myHex = hexToGameObjectMap[GetHexAt(q,r)];
  //Spawn player in
  Instantiate(PlayerUnitPrefab, myHex.transform.position, Quaternion.identity, myHex.transform);
}
```
