using UnityEngine;
public class Control : MonoBehaviour
{
    [SerializeField] private float _speed = 100;
    [SerializeField] private float _senstivity = 50;
    [SerializeField] private GameObject _camera;
    //[SerializeField] private Animator _animator;
    private Vector3 _direction = new Vector3(0,0,0);
    private Rigidbody _rigidbody;
    private float _xRotation, _yRotation;
    private float _shiftSpeed;
    void Awake()
    {
        //_animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Вычисление вращения камеры
        _yRotation += Input.GetAxis("Mouse X") *_senstivity * Time.deltaTime;
        _xRotation += Input.GetAxis("Mouse Y") *_senstivity * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -50f, 60f);

        //Вычисление перемещения
        //_direction = transform.position;
       // var Ray = Physics.Raycast(_camera.transform.position,_camera.transform.forward, 10f);
        //Debug.DrawRay(_camera.transform.position,_camera.transform.forward,Color.blue,1f);



        //_direction = _camera.transform.forward;
       // _direction.y = 0;
        _direction.x = Input.GetAxis("Horizontal") * Time.deltaTime;
        _direction.z = Input.GetAxis("Vertical") * Time.deltaTime;
        //При двиижении по диагонали скорость не будет увеличиваться 
        Vector3.ClampMagnitude(_direction, 1);
        //Ускорение бега
        if(Input.GetKey(KeyCode.LeftShift))   
            _shiftSpeed = 2f;
        else _shiftSpeed = 1;
    }
    void FixedUpdate()
    {
        //Движение и вращение
        _rigidbody.AddRelativeForce(_direction*_speed*_shiftSpeed,ForceMode.VelocityChange);
        Debug.DrawRay(_rigidbody.transform.position,_direction*20,Color.red,1f);

/*
Не могу разобраться, почему неправильно рисуется вектор приложения силы.
По управлению все получается правильно - игрок идет туда, куда смотрит камера, но если рисовать вектор
из позиции игрока по напрвлению приложения силы, то он всегда рисуется в глобальных координатах
Так получается просто из-за того, что DrawRay работает в глобальной сетке, и на самом деле все рисуется правильно,
если как-то перейти в локальную? Если да, то как можно это сделать.

Так же не понимаю, как убрать проблему дрожания камеры. Скорее всего возникает из-за координаты _direction.y,
но если ее не занулить игрок улетает с карты в неизвестном направлении)

В предыдущем курсе движение реализовывал через Translate, но я так понимаю его нужно делать через физику
*/



        //Поворот тела игрока в зависимости от поворота камеры
        transform.rotation = Quaternion.LookRotation(_camera.transform.forward);
        //Поворот камеры вверх и вниз, независимо от тела.
        _camera.transform.eulerAngles = Vector3.up*_yRotation;
    }
}