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
	private enum Colony {Forest,Grassland,Housing};

	[SerializeField] public Colony tileType;
```
