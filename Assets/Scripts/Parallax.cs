using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Renderer objRender;
    private Material objMaterial;
    public float offset;
    public float offsetIncrement;
    public float offsetVelocity;

    public string sortingLayer;
    public int orderinLayer;

    void Start()
    {
        objRender = GetComponent<MeshRenderer>();

        objRender.sortingLayerName = sortingLayer;
        objRender.sortingOrder = orderinLayer;

        objMaterial = objRender.material;
    }

    void Update()
    {
        offset += offsetIncrement;
        objMaterial.SetTextureOffset("_MainTex", new Vector2(offset * offsetVelocity, 0));
    }

}



