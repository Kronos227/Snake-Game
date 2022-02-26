using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Snake

public class Snake : MonoBehaviour

{

    #region Properties

    /// <summary>

    /// Varible tipo enum que asigna a las variables left, right,

    ///up y down, valores constantes que no cambiaran en el transcurso de

    ///la ejecucion del programa

    /// </summary>

    //Estados o movimientos que puede tomar el player

    enum Movements
    {

        left,//Movimiento de la Serpiente a la Izquierda

        right,//Movimiento de la Serpiente a la Derecha

        up,//Movimiento de la Serpiente a Arriba

        down//Movimiento de la Serpiente a Abajo 

    }

    //Declaramos una variable de tipo Movements que se llama movement

    //para almacenar el movimiento que el player realice desde el teclado

    Movements _movement;

    //declaramos la variable frameRate que seria nuestra variable para tener

    //el tiempo que se estaria ejecutando cada frame, autodemoninado en Unity

    //como time.Deltatime se ejecuata cada 200 milisegundos

    public float _frameRate = 0.2f;

    //declaramos la variable nextStep para almacenar la distancia que se moveria por cada frameRate

    //la serpiente en este caso avanzaria cada 16 px

    public float _nextStep = 0.16f;

    //Declaramos una variable de tipo Vector3 que almacene la ultima posicion de la serpiente

    Vector3 _lastPos;

    public BoxCollider2D gridArea;


    #endregion

    #region Start

    // Start is called before the first frame update

    void Start()

    {

        //Invocamos al metodo Move en start para que se instancien las variables de

        //movement, junto con frameRate y nextStep

        //usamos el comando InvokeRepeating("MethodName", time.deltaTime,time.deltaTime)
        
        RandomizePosition();
        InvokeRepeating("Move", _frameRate, _frameRate);

    }

    #endregion

    #region Methods

    //Declaramos el metodo Move en este caso no regresa nada, solo revisa la ultima posicion de la serpiente

    void Move()
    {

        //que esta en la variable lastPos y se le asigna la propiedad transform.position

        _lastPos = transform.position;

        //Declaramos una varibale local nextPos de tipo Vector3 que inicialmente tomara los valores de 0 para

        //la posicion del vector

        Vector3 nextPos = Vector3.zero;

        //comparamos el valor almacenado en la variable movement y la comparamos con alguna de las

        //acciones realizadas en la variable enum Movements

        if (_movement == Movements.up)
        {

            //Si cumple con algunas de las acciones asignamos a la variable nextPos los valores del objeto

            //Vector3.movimiento en este caso hacia arriba

            nextPos = Vector3.up;

        }
        else if (_movement == Movements.down)
        {

            //Vector3.movimiento en este caso hacia abjao

            nextPos = Vector3.down;

        }
        else if (_movement == Movements.left)
        {

            //Vector3.movimiento en este caso hacia la izquierda

            nextPos = Vector3.left;

        }
        else if (_movement == Movements.right)
        {

            //Vector3.movimiento en este caso hacia la derecha

            nextPos = Vector3.right;

        }

        //ya que esta actualizado la variable con el movimiento que desea realizar el player

        //incrementamos el valor de nextPos multiplicando por el valor que avanza cada frame

        //que esta alamcenado en la variable nextStep

        nextPos *= _nextStep;

        //ahora ese valor de nextPos se lo asignamos a la propiedad transform.position para que actualice

        //los nuevos valores del vector postion en el trandform del Inspector

        transform.position += nextPos;

    }




    #endregion



    #region Update

    // Update is called once per frame

    /*private void Start()
    {
        RandomizePosition();
    }*/

    public void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;

        // Pick a random position inside the bounds
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // Round the values to ensure it aligns with the grid
        x = Mathf.Round(x);
        y = Mathf.Round(y);

        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y),0.0f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Borders"))
        {
            print("Game Over");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else if (collider.CompareTag("Apple"))
        {
            RandomizePosition();
            print("Eat the Apple");
        }
        
    }
    
    void Update()

    {

        //Compararemos las entradas del player para compararlas con los movimeintos que estan

        //declarados en la variable Movements left, right, up y down.

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            //Si cumple asignamos ese valor a la variable derivada de Movements : movement hacia arriba

            _movement = Movements.up;

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            //Si cumple asignamos ese valor a la variable derivada de Movements : movement hacia abajo

            _movement = Movements.down;

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            //Si cumple asignamos ese valor a la variable derivada de Movements : movement hacia la izquierda

            _movement = Movements.left;

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            //Si cumple asignamos ese valor a la variable derivada de Movements : movement hacia la derecha

            _movement = Movements.right;

        }

    }

    

    #endregion
}

#endregion
