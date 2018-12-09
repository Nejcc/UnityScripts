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
