# Unity Path (technical artist)

## Objetivos

- Configurar propiedades del juego desde una UI.
- Recolectar y mostrar datos de gameplay en UI.
- Programar un personaje que recorra un camino sobre el terreno.
- Programar un "spawner" de personajes.
- Debe ser 3d.
- Utilizar Unity 2020+.

## Guidelines

- Limitarse a los requerimientos dados.
- Código legible y prolijo, considerando que otra persona deba entenderlo.
- Seguir principios KISS, DRY, YAGNI.
- Utilizar los assets disponibles en el proyecto
- Trabajar sobre la escena Assets/Scenes/Demo

## Entorno

- Crear un terreno 3d por el cual puedan moverse personajes.
- Utilizar los assets de la carpeta Art a gusto para componer la escena.

## Camino
- Crear dos puntos lejanos que representen el inicio y fin del camino.
- Entre ambos puntos debe haber obstáculos pero se debe poder llegar caminando.
- El camino no es directo, sino que deben esquivar los obstáculos.
- El camino debe tener bifurcaciones.

## Items

- Dentro del camino, crear ítems los cuales puedan ser tocados por los personajes al paso.
- El item gráficamente debe utilizar Assets/Art/Item/Item.fbx compuesto con el gráfico 2d ubicado en Assets/Art/Item/MoneyIcon.png
- Cada vez que un item es tocado por un personaje, debe sumar dinero recaudado

## Personajes

- Los personajes deben recorrer un camino. Deben spawnear (ser creados) en el punto de inicio y desaparecer en el punto final.
- Los personajes deben poder tocar los items creados en el camino.
- Los personajes deben reproducir la animación de idle, caminar o correr según su velocidad.
- Cada personaje debe estar asociado con un indicador de felicidad por encima de su cabeza. 

## Hud

- "Spawn rate" es un slider que se debe poder interactuar para controlar cuantos personajes por segundo se crean.
- "Speed" es un slider que se debe poder interactuar para controlar la velocidad en la que se mueven los personajes.
- Preparar una jerarquía de objetos que sea responsive al tamaño que ocupe en la pantalla.
- Utilizar los gráficos dados en Assets/Art/Hud/
- Debe indicar la cantidad total de personajes que existen en cada instante.
- Debe indicar cuánto dinero ha recaudado hasta el momento.
- Debe actualizar el gráfico indicador de “felicidad” según la cantidad de ítems que haya agarrado cada 10 segundos. Por ejemplo, si dentro de 10 segundos agarró 7 items o más, se verá el gráfico contento. Si agarro menos de 2 se verá el gráfico triste. Balancear los límites a criterio personal.
- Encontraras imágenes de referencia en HUD/
