# BakeOff

## Descripcion del juego
¡Bienvenidos a la arena culinaria más feroz y emocionante! Aquí, los pasteleros no solo cocinan, sino que luchan por la gloria en tres intensas rondas de pura adrenalina y creatividad. En cada ronda, uno de estos valientes artistas del azúcar y la harina verá su sueño desvanecerse, dejando solo a los más fuertes para seguir batallando. Cada enfrentamiento es una sorpresa, con recetas al azar que desafían incluso a los más experimentados. Solo aquellos con un vasto conocimiento y habilidades excepcionales podrán mantenerse en pie. Un juez implacable, con ojo crítico y paladar exigente, evalúa cada creación. Al final de cada ronda, el pastelero con la puntuación más baja enfrentará la eliminación, y su horno se apagará para siempre. ¡Que comience la competencia y que el mejor pastelero emerja victorioso!

## Forma de juego
El jugador comienza eligiendo uno de los cuatro pasteleros disponibles, cada uno con una especialidad que garantiza una alta puntuación en ese campo específico. Las demás habilidades de los pasteleros se asignan al azar. Los personajes no seleccionados se convierten en los rivales del jugador.

El juego consta de tres rondas. En cada ronda, se selecciona un juez al azar, y cada juez tiene su propio criterio de evaluación, dando más importancia a ciertas características. Aquí es donde la especialidad del pastelero elegido juega un papel crucial.

Aunque el azar influye en el juego, también es fundamental la habilidad del jugador. En cada ronda, se selecciona una receta al azar, y el jugador debe responder correctamente tres preguntas relacionadas con la receta. La puntuación final de cada ronda se basa en la evaluación del juez, la habilidad del jugador en los campos evaluados, y principalmente en la precisión de las respuestas.

Al final de cada ronda, el jugador con la puntuación más baja es eliminado. El último jugador en pie se corona como el vencedor.

## Implementación
### Animaciones
Para las animaciones me inspiré en el siguiente video: https://www.youtube.com/shorts/fg6l2zlbdCk 
Al principio se ve una parte del código utilizado, pero no logré encontrarlo completo. 
Después de una larga búsqueda, encontré una siguiente página la cual usaba una idea similar: https://medium.com/@guy.signer/terminal-amination-with-c-raw-string-literals-2f28204a0851. Modifiqué dicho código para que se adapte a mis necesidades (una de las cuales era que se saltee solo transcurrido un tiempo determinado). 
El nuevo desafio que se presentaba era que necesitaba los fotogramas de la animación en ascii. Después de mucho buscar fotogramas relacionados con pastelería, y no tener suerte, se me ocurrió la idea de usar un gif. Para separar los fotogramas del gif usé https://ezgif.com/split; a las imagines obtenidas las convertí en ascii utilizando https://www.asciiart.eu/image-to-ascii. Finalmente, centré el ascii art obtenido manualmente. 

### Utilización de API
Decidí utilizar una API para obtener los nombres de los pasteleros, quienes serían mujeres por decisión propia. Usé la API de fakerapi.it, específicamente la siguiente URL: https://fakerapi.it/api/v1/users?_quantity=1&_gender=female.

### Menu
Para realizar el menú de opciones utilicé el código mostrado en el video https://www.youtube.com/watch?v=qAWhGEPMlS8&t=2206s con pequeñas modificaciones.

