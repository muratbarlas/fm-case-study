using UnityEngine;
using System.Reflection;
using TMPro;

public class WalletManager : MonoBehaviour
{
    public GameObject prefab;
    public Sprite[] sprites;
    public Vector2 startPos = new Vector2(); 
    public Vector2 spacing = new Vector2();
    public WalletData WalletData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
 void Start()
    {
        int spriteIndex = 0;
        
        for (int row = 0; row < 2; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                Vector3 pos = new Vector3(
                startPos.x + col * spacing.x,
                startPos.y - row * spacing.y,
                0f
                );
                GameObject go = Instantiate(prefab, pos, Quaternion.identity, transform);
                SpriteRenderer sr = go.GetComponentInChildren<SpriteRenderer>();
                sr.sprite = sprites[spriteIndex];
                go.name = sprites[spriteIndex].name.Replace("-", "");

                //Debug.Log(go.name);
                //string cleaned_loopup = go.name.Replace("-", "");
                FieldInfo field = typeof(WalletData).GetField(go.name);
                int fieldValue = (int)field.GetValue(WalletData);
                go.GetComponentInChildren<TextMeshPro>().text = fieldValue.ToString();
                spriteIndex++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
