# PruebaTecnicaLitgm
Prueba técnica para la empresa Life is the game

Comenzando el proyecto base es uno de los ejemplos de aprendizaje de Unity, en esta ocasión utilice el ejemplo de FirstPersonShooter (FPS). Con esto demostrando que puedo acoplarme a sistemas ya existentes y agregar contenido o funcionalidades sin romper lo ya hecho.

Por lo que me centre en realizar lo que pidieron en la prueba que fue, realizar los siguientes features:

- Creación de un arma que dispara balas que realizan un tiro parabólico, hasta llegar al punto donde se apuntó; si este punto está muy lejano será unos metros por delante del jugador
- Creación de un arma que hace que objetos cercanos se acerquen y leviten al rededor
- Creación de un arma que corta los elementos del escenario.
- Creación de un arma que crea dos ventanas que se conectan entre ellas para ver atreves; esta arma iba a ser un arma replica de la mecánica del juego de portal, pero se complicó el teleport posiblemente por los controles del personaje base. No pude continuar con esta feature porque quien mueve el personaje es una clase externa la cual no pude modificarla para que sirviera con la nueva funcionalidad. Pero como me quedo bastante bien la primera parte de la mecánica, la deje. Y en lugar, cree el arma anterior que corta los elementos.


Patrones aplicados en la prueba:

- Patrón ObjectPool: este patrón se utilizó para poder ahorrar recursos durante el disparo de ciertas armas.
- Patrón ServiceLocator: Este patrón se utilizó para almacenar información entre escenas, y en la segunda escena se utiliza para acceder al ObjectPool
- Patrón Template Method: Este patrón se utilizó para la creación de las armas, ya que todas tienen un comportamiento similar.

Cosas adicionales que se hicieron:
- Utilización de la funcionalidad de los GitHub Actions que te permiten hacer algo de DevOps dentro de GitHub (Pestana de Actions: https://github.com/luisplata/PruebaTecnicaLitgm/actions)
- Realización de pruebas unitarias utilizando TDD, uno de los build del GitHub Actions, fallo por una prueba unitaria intencionalmente fallida.
- Implementación de una música y SFX para darle más ambiente
