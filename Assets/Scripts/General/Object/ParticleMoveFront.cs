using UnityEngine;
using System.Collections;

//Originally created to attempt to solve a "bug" where the particle system wasn't causing the particles to appear
//before the other objects. Googling seemed to imply it was a sorting layer problem, and could be solved by adding a particle layer
//and moving that particle to that layer (through code). Did not work. Sometimes it did, and the particle appeared above the card, but more often than
//not it didn't. Also, this took time to occur, the particle started out below and would then suddenly appear over. This is extremely noticiable.

//Solution was at the ParticleSystem Component, Renderer Module. In that Module there is a variable SortingFudge that appears to set the
//z-index of the particles created, setting it to -4 solved it.

//Found another problem for the Poison particle system where it was constantly appearing below the Large Event Displayer; even doing the above
//did not solve it. However, adding this script does?????
public class ParticleMoveFront : MonoBehaviour 
{
	public string layerName;

	// Use this for initialization
	void Start ()
	{
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = layerName;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}