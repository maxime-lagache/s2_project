using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float maxSpeed = 10;
    public float jumpForce;

    private bool isJumping;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    public static PlayerMovement instance;
    //initialisation de différentes variables

    void Update() //Mise à jour appelé à chaque image
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime; //horizontalMovement a une vitesse de déplacement spécifié dans l'inspecteur de Unity sur l'axe x et pendant un temps précis

        if (Input.GetButtonDown("Jump") && isGrounded) //Si on appuye sur la barre espace et que le joueur touche le sol
        {
            isJumping = true; //isJumping prend la valeur vraie
        }

        Flip(rb.velocity.x); //Permet la rotation du joueur lors d'un changement de direction

        float characterVelocity = Mathf.Abs(rb.velocity.x); //Créé une variable temporaire contenant la vitesse du personnage
        animator.SetFloat("Speed", characterVelocity); //En fonction de la vitesse du personnage, active les différentes animations du personnage

        if (rb.velocity.magnitude > maxSpeed) //Si la vitesse du personnage est supérieur à la vitesse max du personnage
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed); //Ajuste la vitesse pour ne pas dépasser la vitesse max
        }
    }

    void FixedUpdate() //Mise à jour indépendante de la fréquence d'images pour les calculs physiques
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers); // initialise la variable déterminant lorsque le joueur touche le sol
        MovePlayer(horizontalMovement); //Gère les déplacements du joueur de façon horizontal
    }

    void MovePlayer(float _horizontalMovement) //Méthode influant sur les déplacements du joueur
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y); //calcul la vitesse du personnage sur un nouveau vecteur vertical
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f); //Modifie progressivement la valeur de la vitesse en fonction des mouvements du joueur au fil du temps.

        if (isJumping == true) //Si isJumping est vraie
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
            //Le joueur ne peut plus sauter
        }
    }

    void Flip(float _velocity) //Gère la rotation du joueur
    {
        if (_velocity > 0.1f) //Si le joueur se dirige vers la droite
        {
            spriteRenderer.flipX = false; //Ne retourne pas le sprite du joueur
        }
        else if (_velocity < -0.1f) //Si le joueur se dirige vers la gauche 
        {
            spriteRenderer.flipX = true; //Retourne le sprite du joueur
        }
    }

    private void OnDrawGizmos() //Gère la collision du joueur avec le sol
    {
        Gizmos.color = Color.red; //Créé un cercle rouge
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius); //Dessine le cercle qui prend en paramètre la position du cercle et son rayon
    }
}