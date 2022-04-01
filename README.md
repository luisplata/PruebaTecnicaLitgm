# PruebaTecnicaLitgm
Prueba tecnica para la empresa Life is the game

Comenzando el proyecto base es uno de los ejemplos de aprendizaje de Unity, en esta ocacion utilize el ejemplo de FirstPersonShooter (FPS). Con esto demostrando que puedo acoplarme a sistemas ya existentes y agregar contenido o funcionalidades sin romper lo ya hecho.

Por lo que me centre en realizar lo que pidieron en la prueba que fue, realizar los siguientes features:

- Creacion de un arma que dispara balas que realizan un tiro parabolico, hasta llegar al punto donde se apunto; si este punto esta muy lejano sera unos metros por delante del jugador
- Creacion de un arma que hace que objetos cercanos se acerquen y leviten al rededor
- Creacion de un arma que corta los elementos del escenario.
- Creacion de un arma que crea dos ventanas que se conectan entre ellas para ver atravez; esta arma iba a ser una arma replica de la mecanica del juego de portal, pero se complico el teleport posiblmente por los controles del personaje base. No pude continuar con esta feature porque quien mueve el personaje es una clase externa la cual no pude modificarla para que sirviera con la nueva funcionalidad. Pero como me quedo bastante bien la primera parte de la mecanica, la deje. Y en lugar, cree el arma anterior que corta los elementos.


Patrones aplicados en la prueba:

- Patron ObjectPool: este patron se utilizo para poder ahorar recursos durante el disparo de ciertas armas.
- Patron ServiceLocator: Este patron se utilizo para almacenar informacion entre escenas, y en la segunda escena se utiliza para acceder al ObjectPool
- Patron Template Method: Este patron se utilizo para la creacion de las armas, ya que todas tienen un comportamiento similar.

Cosas adicionales que se hicieron:
- Utilizacion de la funcionalidad de los GitHub Actions que te permiten hacer algo de DevOps dentro de GitHub (Pestana de Actions: https://github.com/luisplata/PruebaTecnicaLitgm/actions)
- Realizacion de pruebas unitarias utilizando TDD
- Implementacion de una musica y SFX para darle mas ambiente
