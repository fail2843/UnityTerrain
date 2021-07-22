using UnityEngine;
public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Player _playerScript;
    void Awake()
    {
        _playerScript = _player.GetComponent<Player>();
    }
    void OnGUI()
    {
        GUI.Box(new Rect(10,10,200,400),"Control bar");
        if(GUI.Button(new Rect(20,30,100,20), "Self Damage"))
        _playerScript.TakeDamage(20);
        
        if(GUI.Button(new Rect(20,70,100,20), "Self Heal"))
        _playerScript.GetHealth(20);
        
        GUI.HorizontalSlider(new Rect(Screen.width/2 + 400,Screen.height - 20 ,150,40),_playerScript.HP, 0, 100);      
    }  
}